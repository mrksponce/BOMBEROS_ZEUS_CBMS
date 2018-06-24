'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.Collections

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
namespace GoldParser
'
  '
  Public Class TokenStack
  '
    Private m_items As ArrayList

    ' constructor

    '
    Friend Sub New()
    '
      m_items = New ArrayList()
    End Sub

    ' indexer

    ' Returns the token at the specified position from the top.
    Public ReadOnly Property this(ByVal p_index As Integer) As Token
    '
      Get
        this = m_items(p_index)
      End Get
    End Property

    ' properties

    ' Gets the number of items in the stack.
    Public ReadOnly Property Count() As Integer
    '
      Get
        Count = m_items.Count
      End Get
    End Property

    ' public methods

    ' Removes all tokens from the stack.
    Public Sub Clear()
    '
      m_items.Clear()
    End Sub

    ' Pushes the specified token on the stack.
    Public Sub PushToken(ByVal p_token As Token)
    '
      m_items.Add(p_token)
    End Sub

    ' Returns the token on top of the stack.
    Public Function PeekToken() As Token
    '
      Dim last As Integer = m_items.Count - 1
      PeekToken = Microsoft.VisualBasic.IIf(last < 0, Nothing, m_items(last))
    End Function

    ' <summary>Pops a token from the stack.</summary>
    ' <remarks>The token on top of the stack will be removed and returned 
    ' by the method.</remarks>
    Public Function PopToken() As Token
    '
      Dim last As Integer = m_items.Count - 1
      If (last < 0) Then
        PopToken = Nothing
        Exit Function
      End If
      Dim result As Token = m_items(last)
      m_items.RemoveAt(last)
      PopToken = result
    End Function

    ' Pops the specified number of tokens from the stack and adds them
    ' to the specified <c>Reduction</c>.
    Public Sub PopTokensInto(ByVal p_reduction As Reduction, ByVal p_count As Integer)
    '
      Dim start As Integer = m_items.Count - p_count
      Dim loop_end As Integer = m_items.Count - 1
      Dim i As Integer
      For i = start To loop_end
        p_reduction.AddToken(m_items(i))
      Next
      m_items.RemoveRange(start, p_count)
    End Sub

    ' <summary>Returns the token at the specified position from the top.</summary>
    ' <example>GetToken(0) returns the token on top off the stack, GetToken(1)
    ' the next one, etc.</example>
    Public Function GetToken(ByVal p_index As Integer) As Token
    '
      Return m_items(p_index)
    End Function

    ' Returns an <c>IEnumerator</c> for the tokens on the stack.
    Public Function GetEnumerator() As IEnumerator
    '
      GetEnumerator = m_items.GetEnumerator()
    End Function
  End Class
end namespace
