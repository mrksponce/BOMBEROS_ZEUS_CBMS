'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.Text

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
Namespace GoldParser

  ' This class is used to store the nonterminals used by the DFA and LALR parser
  ' Symbols can be either terminals (which represent a class of tokens, such as
  ' identifiers) or non-terminals (which represent the rules and structures of
  ' the grammar). Symbols fall into several categories for use by the 
  ' GoldParser Engine which are enumerated in type <c>SymbolType</c> enum.
  Public Class Symbol

        Private Const c_quotedChars As String = "|-+*?()[]}<>!\x0022"

    Private m_tableIndex As Integer
    Private m_name As String
    Private m_kind As SymbolType

    ' constructor

    ' Creates a new Symbol object.
    Friend Sub New(ByVal p_index As Integer, ByVal p_name As String, ByVal p_kind As SymbolType)

      m_tableIndex = p_index
      m_name = p_name
      m_kind = p_kind
    End Sub

    '
    Protected Friend Sub New()
      MyClass.New(-1, "", SymbolType.Error)

    End Sub

    ' properties

    ' Gets the index of this symbol in the GoldParser's symbol table.
    Public ReadOnly Property TableIndex() As Integer

      Get
        TableIndex = m_tableIndex
      End Get
    End Property

    ' Gets the name of the symbol.
    Public Property Name() As String

      Get
        Name = m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
      End Set
   End Property


    ' Gets the <c>SymbolType</c> of the symbol.
    Public ReadOnly Property Kind() As SymbolType

      Get
        Kind = m_kind
      End Get
    End Property

    ' public methods

    ' Returns true if the specified symbol is equal to this one.
    Public Overloads Overrides Function Equals(ByVal p_object As Object) As Boolean

      Dim symbol As Symbol = p_object
      Equals = m_name.Equals(symbol.Name) And m_kind = symbol.Kind
    End Function

    ' Returns the hashcode for the symbol.
    Public Overrides Function GetHashCode() As Integer

      GetHashCode = m_name + "||" + m_kind.GetHashCode()
    End Function

    ' <summary>Returns the text representation of the symbol.</summary>
    ' <remarks>In the case of nonterminals, the name is delimited by angle brackets, 
    ' special terminals are delimited by parenthesis and terminals are delimited 
    ' by single quotes (if special characters are present).</remarks>
    Public Overrides Function ToString() As String

      Dim result As New StringBuilder()

      If (m_kind = SymbolType.NonTerminal) Then
        result.Append("<").Append(m_name).Append(">")
      ElseIf (m_kind = SymbolType.Terminal) Then
        ' PatternFormat(m_name, result)
         result.Append(m_name)
      Else
        result.Append("(").Append(m_name).Append(")")
      End If
      ToString = result.ToString()
    End Function

    ' private methods		

    '
    Private Sub PatternFormat(ByVal p_source As String, ByVal p_target As StringBuilder)

      Dim i As Integer
      For i = 0 To p_source.Length - 1
        Dim ch As Char = p_source.Chars(i)
        If (ch = "'") Then
          p_target.Append("''")
        ElseIf (c_quotedChars.IndexOf(ch) <> -1) Then
          p_target.Append("'").Append(ch).Append("'")
        Else
          p_target.Append(ch)
        End If
      Next
    End Sub

    '
    Protected Friend Sub CopyData(ByVal p_symbol As Symbol)

      m_name = p_symbol.Name
      m_kind = p_symbol.Kind
      m_tableIndex = p_symbol.TableIndex
    End Sub
  End Class
end namespace