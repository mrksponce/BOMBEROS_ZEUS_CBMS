'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.Text
Imports System.Collections

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
Namespace GoldParser

  ' This class is used by the engine to hold a reduced rule. Rather than contain
  ' a list of Symbols, a reduction contains a list of Tokens corresponding to the
  ' the rule it represents. This class is important since it is used to store the
  ' actual source program parsed by the Engine.
  Public Class Reduction

    Private m_tokens As ArrayList
    Private m_parentRule As Rule
    Private m_tag As Object

    ' constructor

    ' Creates a new Reduction.
    Friend Sub New()

      m_tokens = New ArrayList()
    End Sub

    ' properties

    ' Returns an <c>ArrayList</c> containing the <c>Token</c>s in this reduction.
    Public ReadOnly Property Tokens() As ArrayList

      Get
        Tokens = m_tokens
      End Get
    End Property

    ' Returns the <c>Rule</c> that this <c>Reduction</c> represents.
    Public Property ParentRule() As Rule

      Get
        ParentRule = m_parentRule
      End Get
      Set(ByVal Value As Rule)
        m_parentRule = Value
      End Set
    End Property

    ' This is a general purpose field that can be used at the developer's leisure. 
    Public Property Tag() As Object

      Get
        Tag = m_tag
      End Get
      Set(ByVal Value As Object)
        m_tag = Value
      End Set
    End Property

    ' public methods

    ' Returns the token with the specified index.
    Public Function GetToken(ByVal p_index As Integer) As Token

      GetToken = m_tokens(p_index)
    End Function

    ' Returns a string-representation of this Reduction.
    Public Overrides Function ToString() As String

      ToString = m_parentRule.ToString()
    End Function

    ' <summary>Makes the <c>IGoldVisitor</c> visit this <c>Reduction</c>.</summary>
    ' <example>See the GoldTest sample project.</example>
    Public Sub Accept(ByVal p_visitor As IGoldVisitor)

      p_visitor.Visit(Me)
    End Sub

    ' <summary>Makes the <c>IGoldVisitor</c> visit the children of this 
    '          <c>Reduction</c>.</summary>
    ' <example>See the GoldTest sample project.</example>
    Public Sub ChildrenAccept(ByVal p_visitor As IGoldVisitor)

      Dim token As Token
      For Each token In m_tokens

        If (token.Kind = SymbolType.NonTerminal) Then
           If TypeOf token.Data Is Reduction Then
             Dim reductiondata As Reduction = token.Data
             reductiondata.Accept(p_visitor)
           'More here?
           End If
'           token.Data.Accept(p_visitor)
        End If
      Next

      'Dim lngLoopIndex As Long
      'Dim lngloopMax As Long = m_tokens.Count - 1
      'For lngLoopIndex = 0 To lngloopMax
      '  token.Data()
      'Next

    End Sub

    ' friend methods

    '
    Friend Sub AddToken(ByVal p_token As Token)

      m_tokens.Add(p_token)
    End Sub
  End Class
end namespace