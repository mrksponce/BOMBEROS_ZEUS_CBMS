'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
namespace GoldParser

  ' While the Symbol represents a class of terminals and nonterminals,
  ' the Token represents an individual piece of information.
  Public Class Token
  Inherits Symbol

    Private m_state As Integer
    Private m_data As Object

    ' constructors

    '
    Friend Sub New()
      MyBase.New(-1, "", SymbolType.Error)
      m_state = -1
      m_data = ""
    End Sub

    '
    Friend Sub New(ByVal p_symbol As Symbol)
      MyBase.New(p_symbol.TableIndex, p_symbol.Name, p_symbol.Kind)
      SetParent(p_symbol)
    End Sub

    ' properties

    ' Gets the state 
    Friend Property State() As Integer

      Get
        State = m_state
      End Get
      Set(ByVal Value As Integer)
        m_state = Value
      End Set
    End Property

    ' Gets or sets the information stored in the token.
    Public Property Data() As Object

      Get
        Return m_data
      End Get
      Set(ByVal Value As Object)
        m_data = Value
      End Set
    End Property

    ' public methods

    ' 
    Friend Sub SetParent(ByVal p_symbol As Symbol)

      CopyData(p_symbol)
    End Sub

    ' <summary>Returns the text representation of the token's parent symbol.</summary>
    ' <remarks>In the case of nonterminals, the name is delimited by angle brackets, 
    ' special terminals are delimited by parenthesis and terminals are delimited 
    ' by single quotes (if special characters are present).</remarks>
    Public Overrides Function ToString() As String

      Return Me.ToString()
    End Function

    Public ReadOnly Property Definition() As String
    Get
        If TypeOf m_data Is String Then
          Return Name & " = " & m_data
        Else
          Return ""
        End If
    End Get
    End Property
  End Class
end namespace