'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.Text
Imports System.Collections

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http://www.devincook.com/goldparser>.
namespace GoldParser
  ' Each state in the Determinstic Finite Automata contains multiple edges which
  ' link to other states in the automata. This class is used to represent an edge.
  Friend Class FAEdge
    Private m_characters As String
    Private m_targetIndex As Integer

    ' constructor 

    Public Sub New(ByVal p_characters As String, ByVal p_targetIndex As Integer)
      m_characters = p_characters
      m_targetIndex = p_targetIndex
    End Sub

    ' properties

    Public Property Characters() As String
      Get
        Characters = m_characters
      End Get
      Set(ByVal value As String)
         m_characters = value
      End Set
    End Property

    Public Property TargetIndex() As Integer
      Get
        TargetIndex = m_targetIndex
      End Get
      Set(ByVal value As Integer)
        m_targetIndex = value
      End Set
    End Property

    ' public methods

    Public Sub AddCharacters(ByVal p_characters As String)
      m_characters = m_characters + p_characters
    End Sub

    Public Overrides Function ToString() As String
      ToString = "DFA edge [chars=[" + m_characters + "],action=" + m_targetIndex + "]"
    End Function
  End Class

  ' Represents a state in the Deterministic Finite Automata which is used by
  ' the tokenizer.
  Friend Class FAState

    Private m_edges As ArrayList
    Private m_acceptSymbol As Integer

    ' constructor

    Public Sub New()
      m_edges = New ArrayList()
      m_acceptSymbol = -1
    End Sub

    ' properties

    Public ReadOnly Property Edges() As ArrayList
      Get
        Edges = m_edges
      End Get
    End Property

    Public Property AcceptSymbol() As Integer
      Get
        Acceptsymbol = m_acceptSymbol
      End Get
      Set(ByVal value As Integer)
        m_acceptSymbol = value
      End Set
    End Property

    Public ReadOnly Property EdgeCount() As Integer
      Get
        EdgeCount = m_edges.Count
      End Get
    End Property

    ' public methods

    Public Function GetEdge(ByVal p_index As Integer) As FAEdge
      If (p_index >= 0 And p_index < m_edges.Count) Then
        GetEdge = m_edges(p_index)
      Else
        GetEdge = Nothing
      End If
    End Function

    Public Sub AddEdge(ByVal p_characters As String, ByVal p_targetIndex As Integer)
      If (p_characters.Equals("")) Then
        Dim edge As New FAEdge(p_characters, p_targetIndex)
        m_edges.Add(edge)
      Else
        Dim index As Integer = -1
        Dim EdgeCount As Integer = m_edges.Count

        ' find the edge with the specified index
        Dim n As Integer = 0
        Do While (n < edgeCount) And (index = -1)
          Dim edge As FAEdge = m_edges(n)
          If (edge.TargetIndex = p_targetIndex) Then
            index = n
          End If
          n = n + 1
        Loop

        ' if not found, create a new edge
        If (index = -1) Then
          Dim edge As New FAEdge(p_characters, p_targetIndex)
          m_edges.Add(edge)
        'else add the characters to the existing edge
        Else
          Dim edge As FAEdge = m_edges(index)
          edge.AddCharacters(p_characters)
        End If
      End If
    End Sub

    Public Overrides Function ToString() As String
      Dim result As new StringBuilder()
      result.Append("DFA state:" & Microsoft.VisualBasic.vbCrLf)

      Dim edge As FAEdge
      For Each edge In m_edges
        result.Append("- ").Append(edge).Append(microsoft.VisualBasic.vbcrlf)
      Next

      If (m_acceptSymbol <> -1) Then
        result.Append("- accept symbol: ").Append(m_acceptSymbol).Append(microsoft.VisualBasic.vbcrlf)
      End If
      ToString = result.ToString()
    End Function
  End Class
End Namespace
