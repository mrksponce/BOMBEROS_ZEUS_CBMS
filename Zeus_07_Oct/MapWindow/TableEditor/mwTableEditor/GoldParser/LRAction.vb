'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.Text

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
namespace GoldParser

  ' This class represents an action in a LALR State. 
  ' There is one and only one action for any given symbol.
  Friend Class LRAction

    Private m_symbol As Symbol
    Private m_action As Action
    Private m_value As Integer

    ' properties

    Public Property Symbol() As Symbol

      Get
        Symbol = m_symbol
      End Get
      Set(ByVal Value As Symbol)
        m_symbol = Value
      End Set
    End Property

    Public Property Action() As GoldParser.Action

      Get
        Action = m_action
      End Get
      Set(ByVal Value As Action)
         m_action = Value
      End Set
    End Property

    Public Property Value() As Integer
      Get
        Value = m_value
      End Get
      Set(ByVal Value As Integer)
        m_value = Value
      End Set
    End Property

    ' public methods

    Public Overrides Function ToString() As String
            Dim result As New StringBuilder
      result.Append("LALR action [symbol=")
      result.Append(m_symbol)
      result.Append(",action=")
      result.Append(m_action)
      result.Append(",value=")
      result.Append(m_value & "]")
      ToString = result.ToString '"LALR action [symbol=" + m_symbol + ",action=" + m_action + ",value=" + m_value & "]"
    End Function
  End Class
end namespace
