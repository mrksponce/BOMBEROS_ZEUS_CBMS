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

  ' This class contains the actions (reduce/shift) and goto information
  ' for a STATE in a LR parser. Essentially, this is just a row of actions in
  ' the LR state transition table. The only data structure is a list of
  ' LR Actions.
  Friend Class LRActionTable

    Private m_members As ArrayList

    ' constructor

    Public Sub New()

      m_members = New ArrayList()
    End Sub

    ' properties

    Public ReadOnly Property Count() As Integer

      Get
         Count = m_members.Count
      End Get
    End Property

    Public ReadOnly Property Members() As ArrayList

      Get
          Members = m_members
      End Get
    End Property

    ' public methods

    Public Function GetActionForSymbol(ByVal p_symbolIndex As Integer) As LRAction

      ' kan met hashtable bv.
      Dim action As LRAction
      For Each action In m_members

        If (action.Symbol.TableIndex = p_symbolIndex) Then
          GetActionForSymbol = action
          Exit Function
        End If
      Next

      GetActionForSymbol = Nothing
    End Function

    Public Function GetItem(ByVal p_index As Integer) As LRAction

      If (p_index >= 0 And p_index < m_members.Count) Then
        GetItem = m_members(p_index)
      Else
        GetItem = Nothing
      End If
    End Function

    ' <summary>Adds an new LRAction to this table.</summary>
    ' <param name="p_symbol">The Symbol.</param>
    ' <param name="p_action">The Action.</param>
    ' <param name="p_value">The value.</param>
    Public Sub AddItem(ByVal p_symbol As Symbol, ByVal p_action As Action, ByVal p_value As Integer)

      Dim item As New LRAction()
      item.Symbol = p_symbol
      item.Action = p_action
      item.Value = p_value
      m_members.Add(item)
    End Sub

    Public Overrides Function ToString() As String

      Dim result As New StringBuilder()
      result.Append("LALR table:" & Microsoft.VisualBasic.vbCrLf)

      Dim action As LRAction()
      For Each action In m_members

        result.Append("- ").Append(action.ToString() + Microsoft.VisualBasic.vbCrLf)
      Next
      ToString = result.ToString()
    End Function
  End Class
end namespace
