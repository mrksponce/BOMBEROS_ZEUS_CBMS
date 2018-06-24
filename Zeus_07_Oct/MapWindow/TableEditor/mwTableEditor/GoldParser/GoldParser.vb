'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.IO
Imports System.Text
Imports System.Collections
Imports Console = System.Console

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
Namespace GoldParser

  ' This is the main class in the GoldParser Engine and is used to perform
  ' all duties required to the parsing of a source text string. This class
  ' contains the LALR(1) State Machine code, the DFA State Machine code,
  ' character table (used by the DFA algorithm) and all other structures and
  ' methods needed to interact with the developer.
  Public Class Parser
    Private m_parameters As Hashtable
    Private m_symbols() As Symbol
    Private m_charsets() As String
    Private m_rules() As Rule
    Private m_DfaStates() As FAState
    Private m_LalrTables() As LRActionTable

    Private m_initialized As Boolean
    Private m_caseSensitive As Boolean
    Private m_startSymbol As Integer
    Private m_initDfaState As Integer
    Private m_errorSymbol As Symbol
    Private m_endSymbol As Symbol
    Private m_source As LookAheadReader

    Private m_lineNumber As Integer
    Private m_haveReduction As Boolean
    Private m_trimReductions As Boolean
    Private m_commentLevel As Integer
    Private m_initLalrState As Integer
    Private m_LalrState As Integer

    Private m_inputTokens As TokenStack ' Stack of tokens to be analyzed
    Private m_outputTokens As TokenStack ' The set of tokens for 1. Expecting during error, 2. Reduction
    Private m_tempStack As TokenStack ' I often dont know what to call variables. 

    ' constructor
        Public Sub New(ByVal p_string As String, ByVal xml As Boolean)

            m_parameters = New Hashtable
            m_inputTokens = New TokenStack
            m_outputTokens = New TokenStack
            m_tempStack = New TokenStack
            m_initialized = False
            m_trimReductions = False

            If xml Then
                LoadTablesXML(p_string)
            Else
                LoadTables(p_string)
            End If
        End Sub

        ' <summary>Creates a new <c>Parser</c> object for the specified 
        '          CGT file.</summary>
        ' <param name="p_filename">The name of the CGT file.</param>
        Public Sub New(ByVal p_filename As String)

            m_parameters = New Hashtable
            m_inputTokens = New TokenStack
            m_outputTokens = New TokenStack
            m_tempStack = New TokenStack
            m_initialized = False
            m_trimReductions = False

            LoadTables(p_filename)
        End Sub

        ' properties 

        ' Gets or sets whether or not to trim reductions which contain 
        ' only one non-terminal.
        Public Property TrimReductions() As Boolean

            Get
                TrimReductions = m_trimReductions
            End Get
            Set(ByVal value As Boolean)
                m_trimReductions = value
            End Set
        End Property

        ' Gets the current token.
        Public ReadOnly Property CurrentToken() As Token
            Get
                CurrentToken = m_inputTokens.PeekToken()
            End Get
        End Property

        ' <summary>Gets the <c>Reduction</c> made by the parsing engine.</summary>
        ' <remarks>The value of this property is only valid when the Parse-method
        '          returns <c>ParseMessage.Reduction</c>.</remarks>
        Public ReadOnly Property CurrentReduction() As Reduction
            Get

                If (m_haveReduction) Then
                    Dim token As Token = m_tempStack.PeekToken()
                    CurrentReduction = token.Data
                Else
                    CurrentReduction = Nothing
                End If
            End Get
        End Property

        ' Gets the line number that is currently being processed.
        Public ReadOnly Property CurrentLineNumber() As Integer

            Get
                CurrentLineNumber = m_lineNumber
            End Get
        End Property

        ' public methods

        ' Pushes the specified token onto the internal input queue. 
        ' It will be the next token analyzed by the parsing engine.
        Public Sub PushInputToken(ByVal p_token As Token)
            m_inputTokens.PushToken(p_token)
        End Sub

        ' Pops the next token from the internal input queue.
        Public Function PopInputToken() As Token
            PopInputToken = m_inputTokens.PopToken()
        End Function
        '	
        '  ' Returns the token at the specified index.
        '  Public Function GetToken(p_index as integer) As Token
        '
        '    GetToken =  m_outputTokens.GetToken(p_index)
        '  End Function

        ' Returns a <c>TokenStack</c> containing the tokens for the reduced rule or
        ' the tokens that where expected when a syntax error occures.
        Public Function GetTokens() As TokenStack
            GetTokens = m_outputTokens
        End Function

        ' <summary>Returns a string containing the value of the specified parameter.</summary>
        ' <remarks>These parameters include: Name, Version, Author, About, Case Sensitive 
        ' and Start Symbol. If the name specified is invalid, this method will 
        ' return an empty string.</remarks>
        Public Function GetParameter(ByVal p_name As String) As String

            Dim result As New String(m_parameters(p_name))
            GetParameter = Microsoft.VisualBasic.IIf(Not result Is Nothing, result, "")
        End Function

        ' Opens the file with the specified name for parsing.
        Public Function OpenFile(ByVal p_filename As String) As Boolean
            Try
                Reset()

                m_source = New LookAheadReader(New StreamReader(New FileStream(p_filename, FileMode.Open)))

                PrepareToParse()
            Catch
                Return False
            End Try
            Return True
        End Function

        ' Closes the file opened with <c>OpenFile</c>.
        Public Sub CloseFile()

            ' This will automaticly close the FileStream (I think :))
            If (Not m_source Is Nothing) Then
                m_source.Close()
            End If
            m_source = Nothing
        End Sub

        ' <summary>Executes a parse-action.</summary>
        ' <remarks>When this method is called, the parsing engine 
        ' reads information from the source text and then reports what action was taken. 
        ' This ranges from a token being read and recognized from the source, a parse 
        ' reduction, or some type of error.</remarks>
        Public Function Parse() As ParseMessage

            Do While (True)

                If (m_inputTokens.Count = 0) Then

                    ' we must read a token.				
                    Dim token As Token = RetrieveToken()

                    If (token Is Nothing) Then
                        Throw New ParserException("RetrieveToken returned null")
                    End If
                    If (token.Kind <> SymbolType.Whitespace) Then

                        m_inputTokens.PushToken(token)

                        If (m_commentLevel = 0 And Not CommentToken(token)) Then
                            Parse = ParseMessage.TokenRead
                        End If
                    End If
                ElseIf (m_commentLevel > 0) Then

                    ' we are in a block comment.
                    Dim token As Token = m_inputTokens.PopToken()

                    Select Case (token.Kind)
                        Case SymbolType.CommentStart
                            m_commentLevel = m_commentLevel + 1
                        Case SymbolType.CommentEnd
                            m_commentLevel = m_commentLevel - 1
                        Case SymbolType.End
                            Parse = ParseMessage.CommentError
                    End Select
                Else

                    ' we are ready to parse.
                    Dim token As Token = m_inputTokens.PeekToken()
                    Select Case (token.Kind)

                        Case SymbolType.CommentStart
                            m_inputTokens.PopToken()
                            m_commentLevel = m_commentLevel + 1
                        Case SymbolType.CommentLine
                            m_inputTokens.PopToken()
                            DiscardLine()
                        Case Else
                            Dim result As ParseResult = ParseToken(token)
                            Select Case (result)

                                Case ParseResult.Accept
                                    Parse = ParseMessage.Accept
                                    Exit Function
                                Case ParseResult.InternalError
                                    Parse = ParseMessage.InternalError
                                    Exit Function
                                Case ParseResult.ReduceNormal
                                    Parse = ParseMessage.Reduction
                                    Exit Function
                                Case ParseResult.Shift
                                    m_inputTokens.PopToken()
                                    Exit Function
                                Case ParseResult.SyntaxError
                                    Parse = ParseMessage.SyntaxError
                                    Exit Function
                            End Select
                    End Select ' switch
                End If ' else
            Loop ' while
        End Function

        ' private methods

        Private Function FixCase(ByVal p_char As Char) As Char

            If (m_caseSensitive) Then
                FixCase = p_char
            Else
                FixCase = Char.ToLower(p_char)
            End If
        End Function

        Private Function FixCase(ByVal p_string As String) As String

            If (m_caseSensitive) Then
                FixCase = p_string
            Else
                FixCase = p_string.ToLower()
            End If
        End Function

        Private Sub AddSymbol(ByVal p_symbol As Symbol)

            If (Not m_initialized) Then
                Throw New ParserException("Table sizes not initialized")
            End If
            Dim index As Integer = p_symbol.TableIndex
            m_symbols(index) = p_symbol
        End Sub

        Private Sub AddCharset(ByVal p_index As Integer, ByVal p_charset As String)

            If (Not m_initialized) Then
                Throw New ParserException("Table sizes not initialized")
            End If

            m_charsets(p_index) = FixCase(p_charset)
        End Sub

        Private Sub AddRule(ByVal p_rule As Rule)

            If (Not m_initialized) Then
                Throw New ParserException("Table sizes not initialized")
            End If
            Dim index As Integer = p_rule.TableIndex
            m_rules(index) = p_rule
        End Sub

        Private Sub AddDfaState(ByVal p_index As Integer, ByVal p_fastate As FAState)

            If (Not m_initialized) Then
                Throw New ParserException("Table sizes not initialized")
            End If

            m_DfaStates(p_index) = p_fastate
        End Sub

        Private Sub AddLalrTable(ByVal p_index As Integer, ByVal p_table As LRActionTable)

            If (Not m_initialized) Then
                Throw New ParserException("Table counts not initialized")
            End If
            m_LalrTables(p_index) = p_table
        End Sub

        Private Sub LoadTables(ByVal p_filename As String)

            Dim obj As Object, index As Int16
            Dim reader As New GrammarReader(p_filename)

            Do While (reader.MoveNext())

                Dim id As Byte = reader.RetrieveNext()

                Select Case (id)

                    Case RecordId.Parameters
                        m_parameters("Name") = reader.RetrieveNext()
                        m_parameters("Version") = reader.RetrieveNext()
                        m_parameters("Author") = reader.RetrieveNext()
                        m_parameters("About") = reader.RetrieveNext()
                        m_caseSensitive = reader.RetrieveNext()
                        m_startSymbol = reader.RetrieveNext()

                    Case RecordId.TableCounts
                        ReDim m_symbols(reader.RetrieveNext() - 1)
                        ReDim m_charsets(reader.RetrieveNext() - 1)
                        ReDim m_rules(reader.RetrieveNext() - 1)
                        ReDim m_DfaStates(reader.RetrieveNext() - 1)
                        ReDim m_LalrTables(reader.RetrieveNext() - 1)
                        m_initialized = True

                    Case RecordId.Initial
                        m_initDfaState = reader.RetrieveNext()
                        m_initLalrState = reader.RetrieveNext()

                    Case RecordId.Symbols
                        index = reader.RetrieveNext()
                        Dim name As New String(reader.RetrieveNext())
                        Dim kind As SymbolType = reader.RetrieveNext()
                        Dim symbol As New Symbol(index, name, kind)
                        AddSymbol(symbol)

                    Case RecordId.CharSets
                        index = reader.RetrieveNext()
                        Dim charset As New String(reader.RetrieveNext())
                        AddCharset(index, charset)

                    Case RecordId.Rules
                        index = reader.RetrieveNext()
                        Dim head As Symbol = m_symbols(reader.RetrieveNext())
                        Dim Rule As New Rule(index, head)

                        reader.RetrieveNext() ' reserved
                        obj = reader.RetrieveNext()
                        Do While (Not obj Is Nothing)
                            Rule.AddItem(m_symbols(obj))
                            obj = reader.RetrieveNext()
                        Loop
                        AddRule(Rule)

                    Case RecordId.DFAStates
                        Dim FAState As New FAState
                        index = reader.RetrieveNext()

                        If (reader.RetrieveNext()) Then
                            FAState.AcceptSymbol = reader.RetrieveNext()
                        Else
                            reader.RetrieveNext()
                        End If
                        reader.RetrieveNext() ' reserverd					

                        Do While (Not reader.RetrieveDone())

                            Dim ci As Int16 = reader.RetrieveNext()
                            Dim ti As Int16 = reader.RetrieveNext()
                            reader.RetrieveNext() ' reserved
                            FAState.AddEdge(m_charsets(ci), ti)
                        Loop

                        AddDfaState(index, FAState)

                    Case RecordId.LRTables
                        Dim table As New LRActionTable
                        index = reader.RetrieveNext()
                        reader.RetrieveNext() ' reserverd

                        Do While (Not reader.RetrieveDone())

                            Dim sid As Int16 = reader.RetrieveNext()
                            Dim action As Int16 = reader.RetrieveNext()
                            Dim tid As Int16 = reader.RetrieveNext()
                            reader.RetrieveNext() ' reserved
                            table.AddItem(m_symbols(sid), action, tid)
                        Loop

                        AddLalrTable(index, table)

                    Case RecordId.Comment
                        Console.WriteLine("Comment record encountered")

                    Case Else
                        Throw New ParserException("Wrong id for record")
                End Select
            Loop
            reader.FinalizeReader()
        End Sub

        'Added by Levi Barton to allow use of parser without file dependency for compiled grammar tables
        '  June 2005
        Private Sub LoadTablesXML(ByVal p_xmlstring As String)
            Dim xml As New Xml.XmlDocument
            xml.LoadXml(p_xmlstring)

            Dim tables As Xml.XmlElement = xml.DocumentElement()
            Dim parameters As Xml.XmlElement = tables.Item("Parameters")
            Dim symboltable As Xml.XmlElement = tables.Item("SymbolTable")
            Dim ruletable As Xml.XmlElement = tables.Item("RuleTable")
            Dim charsettable As Xml.XmlElement = tables.Item("CharSetTable")
            Dim dfatable As Xml.XmlElement = tables.Item("DFATable")
            Dim lalrtable As Xml.XmlElement = tables.Item("LALRTable")

            Dim index As Int16

            'RecordId.Parameters
            Dim i As Integer
            For i = 0 To parameters.ChildNodes.Count - 1
                Select Case parameters.ChildNodes.Item(i).Attributes.GetNamedItem("Name").InnerText
                    Case "Name"
                        m_parameters("Name") = parameters.ChildNodes.Item(i).Attributes.GetNamedItem("Value").InnerText
                    Case "Version"
                        m_parameters("Version") = parameters.ChildNodes.Item(i).Attributes.GetNamedItem("Value").InnerText
                    Case "Author"
                        m_parameters("Author") = parameters.ChildNodes.Item(i).Attributes.GetNamedItem("Value").InnerText
                    Case "About"
                        m_parameters("About") = parameters.ChildNodes.Item(i).Attributes.GetNamedItem("Value").InnerText
                    Case "CaseSensitive"
                        m_caseSensitive = parameters.ChildNodes.Item(i).Attributes.GetNamedItem("Value").InnerText
                    Case "StartSymbol"
                        m_startSymbol = parameters.ChildNodes.Item(i).Attributes.GetNamedItem("Value").InnerText
                End Select
            Next i

            'RecordId.TableCounts
            ReDim m_symbols(CInt(symboltable.Attributes.GetNamedItem("Count").InnerText) - 1)
            ReDim m_charsets(CInt(charsettable.Attributes.GetNamedItem("Count").InnerText) - 1)
            ReDim m_rules(CInt(ruletable.Attributes.GetNamedItem("Count").InnerText) - 1)
            ReDim m_DfaStates(CInt(dfatable.Attributes.GetNamedItem("Count").InnerText) - 1)
            ReDim m_LalrTables(CInt(lalrtable.Attributes.GetNamedItem("Count").InnerText) - 1)
            m_initialized = True

            'RecordId.Initial
            m_initDfaState = CInt(dfatable.Attributes.GetNamedItem("InitialState").InnerText)
            m_initLalrState = CInt(lalrtable.Attributes.GetNamedItem("InitialState").InnerText)

            'RecordId.Symbols
            For i = 0 To symboltable.ChildNodes.Count - 1
                index = CType(symboltable.ChildNodes.Item(i).Attributes.GetNamedItem("Index").InnerText, Short)
                Dim name As New String(symboltable.ChildNodes.Item(i).Attributes.GetNamedItem("Name").InnerText)
                Dim kind As SymbolType = CInt(symboltable.ChildNodes.Item(i).Attributes.GetNamedItem("Kind").InnerText)
                Dim symbol As New Symbol(index, name, kind)
                AddSymbol(symbol)
            Next i

            'RecordId.CharSets
            For i = 0 To charsettable.ChildNodes.Count - 1
                index = CType(charsettable.ChildNodes.Item(i).Attributes.GetNamedItem("Index").InnerText, Short)
                Dim charset As String = ""
                Dim j As Integer
                For j = 0 To charsettable.ChildNodes.Item(i).ChildNodes.Count - 1
                    charset = String.Concat(charset, Microsoft.VisualBasic.Chr(CInt(charsettable.ChildNodes.Item(i).ChildNodes.Item(j).Attributes.GetNamedItem("UnicodeIndex").InnerText)))
                Next j
                AddCharset(index, charset)
            Next i

            'RecordId.Rules
            For i = 0 To ruletable.ChildNodes.Count - 1
                index = CType(ruletable.ChildNodes.Item(i).Attributes.GetNamedItem("Index").InnerText, Short)

                Dim head As Symbol = m_symbols(CInt(ruletable.ChildNodes.Item(i).Attributes.GetNamedItem("NonTerminalIndex").InnerText))
                Dim Rule As New Rule(index, head)


                Dim j As Integer
                For j = 0 To ruletable.ChildNodes.Item(i).ChildNodes.Count - 1
                    Rule.AddItem(m_symbols(CInt(ruletable.ChildNodes.Item(i).ChildNodes.Item(j).Attributes.GetNamedItem("SymbolIndex").InnerText)))
                Next j

                AddRule(Rule)
            Next i

            'RecordId.DFAStates
            For i = 0 To dfatable.ChildNodes.Count - 1
                Dim FAState As New FAState
                index = CType(dfatable.ChildNodes.Item(i).Attributes.GetNamedItem("Index").InnerText, Short)

                FAState.AcceptSymbol = CInt(dfatable.ChildNodes.Item(i).Attributes.GetNamedItem("AcceptSymbol").InnerText)

                Dim j As Integer
                For j = 0 To dfatable.ChildNodes.Item(i).ChildNodes.Count - 1
                    Dim ci As Int16 = CType(dfatable.ChildNodes.Item(i).ChildNodes.Item(j).Attributes.GetNamedItem("CharSetIndex").InnerText, Int16)
                    Dim ti As Int16 = CType(dfatable.ChildNodes.Item(i).ChildNodes.Item(j).Attributes.GetNamedItem("Target").InnerText, Int16)

                    FAState.AddEdge(m_charsets(ci), ti)
                Next j

                AddDfaState(index, FAState)
            Next i

            'RecordId.LRTables
            For i = 0 To lalrtable.ChildNodes.Count - 1
                Dim table As New LRActionTable
                index = CType(lalrtable.ChildNodes.Item(i).Attributes.GetNamedItem("Index").InnerText, Short)

                Dim j As Integer
                For j = 0 To lalrtable.ChildNodes.Item(i).ChildNodes.Count - 1
                    Dim sid As Int16 = CType(lalrtable.ChildNodes.Item(i).ChildNodes.Item(j).Attributes.GetNamedItem("SymbolIndex").InnerText, Int16)
                    Dim action As Int16 = CType(lalrtable.ChildNodes.Item(i).ChildNodes.Item(j).Attributes.GetNamedItem("Action").InnerText, Int16)
                    Dim tid As Int16 = CType(lalrtable.ChildNodes.Item(i).ChildNodes.Item(j).Attributes.GetNamedItem("Value").InnerText, Int16)
                    table.AddItem(m_symbols(sid), action, tid)
                Next j

                AddLalrTable(index, table)
            Next i
        End Sub

        Private Sub Reset()

            Dim mysymbol As Symbol
            For Each mysymbol In m_symbols

                If (mysymbol.Kind = SymbolType.Error) Then
                    m_errorSymbol = mysymbol
                ElseIf (mysymbol.Kind = SymbolType.End) Then
                    m_endSymbol = mysymbol
                End If
            Next

            m_haveReduction = False
            m_LalrState = m_initLalrState
            m_lineNumber = 1
            m_commentLevel = 0

            m_inputTokens.Clear()
            m_outputTokens.Clear()
            m_tempStack.Clear()
        End Sub

        Private Sub PrepareToParse()
            Dim token As New Token
            token.State = m_initLalrState
            token.SetParent(m_symbols(m_startSymbol))
            m_tempStack.PushToken(token)
        End Sub

        Private Sub DiscardLine()

            m_source.DiscardLine()
            m_lineNumber = m_lineNumber + 1
        End Sub

        ' Returns true if the specified token is a CommentLine or CommentStart-symbol.
        Private Function CommentToken(ByVal p_token As Token) As Boolean

            CommentToken = ((p_token.Kind = SymbolType.CommentLine) Or (p_token.Kind = SymbolType.CommentStart))
        End Function

        ' This function analyzes a token and either:
        '   1. Makes a SINGLE reduction and pushes a complete Reduction object on the stack
        '   2. Accepts the token and shifts
        '   3. Errors and places the expected symbol indexes in the Tokens list
        ' The Token is assumed to be valid and WILL be checked
        Private Function ParseToken(ByVal p_token As Token) As ParseResult
            Dim result As ParseResult = ParseResult.InternalError
            Dim table As LRActionTable = m_LalrTables(m_LalrState)
            Dim Action As LRAction = table.GetActionForSymbol(p_token.TableIndex)

            If (Not Action Is Nothing) Then

                m_haveReduction = False
                m_outputTokens.Clear()

                Select Case (Action.Action)

                    Case GoldParser.Action.Accept
                        m_haveReduction = True
                        result = ParseResult.Accept
                    Case GoldParser.Action.Shift
                        p_token.State = Action.Value
                        m_LalrState = Action.Value
                        m_tempStack.PushToken(p_token)
                        result = ParseResult.Shift
                    Case GoldParser.Action.Reduce
                        result = Reduce(m_rules(Action.Value))
                End Select
            Else

                ' syntax error - fill expected tokens.				
                m_outputTokens.Clear()
                Dim a As LRAction
                For Each a In table.Members
                    Dim kind As SymbolType = a.Symbol.Kind

                    If (kind = SymbolType.Terminal Or kind = SymbolType.End) Then
                        m_outputTokens.PushToken(New Token(a.Symbol))
                    End If
                Next
                result = ParseResult.SyntaxError
            End If

            ParseToken = result
        End Function

        ' <summary>Produces a reduction.</summary>
        ' <remarks>Removes as many tokens as members in the rule and pushes a 
        '          non-terminal token.</remarks>
        Private Function Reduce(ByVal p_rule As Rule) As ParseResult

            Dim result As ParseResult
            Dim head As Token

            If (m_trimReductions And p_rule.ContainsOneNonTerminal) Then

                ' The current rule only consists of a single nonterminal and can be trimmed from the
                ' parse tree. Usually we create a new Reduction, assign it to the Data property
                ' of Head and push it on the stack. However, in this case, the Data property of the
                ' Head will be assigned the Data property of the reduced token (i.e. the only one
                ' on the stack). In this case, to save code, the value popped of the stack is changed 
                ' into the head.
                head = m_tempStack.PopToken()
                head.SetParent(p_rule.RuleNonTerminal)

                result = ParseResult.ReduceEliminated
            Else
                Dim Reduction As New Reduction
                Reduction.ParentRule = p_rule

                m_tempStack.PopTokensInto(Reduction, p_rule.SymbolCount)

                head = New Token
                head.Data = Reduction
                head.SetParent(p_rule.RuleNonTerminal)

                m_haveReduction = True
                result = ParseResult.ReduceNormal
            End If

            Dim index As Integer = m_tempStack.PeekToken().State
            Dim Action As LRAction = m_LalrTables(index).GetActionForSymbol(p_rule.RuleNonTerminal.TableIndex)

            If (Not Action Is Nothing) Then

                m_LalrState = Action.Value
                head.State = m_LalrState
                m_tempStack.PushToken(head)
            Else
                Throw New ParserException("Action for LALR state is null")
            End If

            Reduce = result
        End Function

        ' This method implements the DFA algorithm and returns a token
        ' to the LALR state machine.
        Private Function RetrieveToken() As Token

            Dim result As Token = Nothing
            Dim currentPos As Integer = 0
            Dim lastAcceptState As Long = -1
            Dim lastAcceptPos As Long = -1
            Dim currentState As FAState = m_DfaStates([m_initDfaState])

            Try

                Do While (True)

                    ' This code searches all the branches of the current DFA state for the next
                    ' character in the input LookaheadStream. If found the target state is returned.
                    ' The InStr() function searches the string pCharacterSetTable.Member(CharSetIndex)
                    ' starting at position 1 for ch.  The pCompareMode variable determines whether
                    ' the search is case sensitive.
                    Dim target As Long = -1
                    Dim ch As Char = FixCase(m_source.LookAhead(currentPos))
                    If ch = Microsoft.VisualBasic.Chr(0) Then
                        target = -1
                        If currentPos = 0 Then Throw New EndOfStreamException
                    Else
                        Dim edge As FAEdge
                        For Each edge In currentState.Edges

                            Dim chars As New String(edge.Characters)

                            If (chars.IndexOf(ch) <> -1) Then
                                target = edge.TargetIndex
                                GoTo BREAK_OUT_OF_FOR
                            End If
                        Next
                    End If
BREAK_OUT_OF_FOR:
                    ' This block-if statement checks whether an edge was found from the current state.
                    ' If so, the state and current position advance. Otherwise it is time to exit the main loop
                    ' and report the token found (if there was it fact one). If the LastAcceptState is -1,
                    ' then we never found a match and the Error Token is created. Otherwise, a new token
                    ' is created using the Symbol in the Accept State and all the characters that
                    ' comprise it.
                    If (target <> -1) Then

                        ' This code checks whether the target state accepts a token. If so, it sets the
                        ' appropiate variables so when the algorithm is done, it can return the proper
                        ' token and number of characters.
                        If (m_DfaStates(target).AcceptSymbol <> -1) Then

                            lastAcceptState = target
                            lastAcceptPos = currentPos
                        End If

                        currentState = m_DfaStates(target)
                        currentPos = currentPos + 1
                    Else

                        If (lastAcceptState = -1) Then

                            result = New Token(m_errorSymbol)
                            result.Data = m_source.Read(1)
                        Else

                            Dim mySymbol As Symbol = m_symbols(m_DfaStates(lastAcceptState).AcceptSymbol)
                            result = New Token(mySymbol)
                            result.Data = m_source.Read(lastAcceptPos + 1)
                        End If
                        Exit Do
                    End If
                Loop
            Catch EndOfStreamException As Exception

                result = New Token(m_endSymbol)
                result.Data = ""
            End Try

            UpdateLineNumber(result.Data)

            RetrieveToken = result
        End Function

        Private Sub UpdateLineNumber(ByVal p_string As String)
            Dim index As Integer
            Dim pos As Integer = 0

            index = p_string.IndexOf(Microsoft.VisualBasic.vbCrLf, pos)
            Do While (index <> -1)

                pos = index + 1
                m_lineNumber = m_lineNumber + 1
                index = p_string.IndexOf(Microsoft.VisualBasic.vbCrLf, pos)
            Loop
        End Sub

    End Class
end namespace
