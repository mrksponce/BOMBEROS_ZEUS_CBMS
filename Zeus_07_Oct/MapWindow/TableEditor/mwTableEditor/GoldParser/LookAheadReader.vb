'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.IO

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
Namespace GoldParser

  ' This is a wrapper around StreamReader which supports lookahead.
  Friend Class LookAheadReader

        Private Const BUFSIZE As Integer = 256

    Private m_reader As StreamReader
    Private m_buffer() As Char
    Private m_curpos As Integer
    Private m_buflen As Integer

    ' constructor

    ' Creates a new LookAheadReader around the specified StreamReader.
    Public Sub New(ByVal p_reader As StreamReader)

      m_reader = p_reader
      m_curpos = -1
      ReDim m_buffer(BUFSIZE - 1)
    End Sub

    ' private methods

    ' Makes sure there are enough characters in the buffer.
    Private Sub FillBuffer(ByVal p_length As Integer)
      Dim av As Integer = m_buflen - m_curpos ' het aantal chars na curpos

      If (m_curpos = -1) Then

        ' fill the buffer
        m_buflen = m_reader.Read(m_buffer, 0, BUFSIZE)
        m_curpos = 0
      ElseIf (av < p_length) Then

        If (m_buflen < BUFSIZE) Then
          ' not available
          Throw New EndOfStreamException()
        Else

          ' re-fill the buffer								
          Array.Copy(m_buffer, m_curpos, m_buffer, 0, av)
          m_buflen = m_reader.Read(m_buffer, av, m_curpos) + av
          m_curpos = 0
        End If
      End If

      ' append a newline on EOF
      If (m_buflen < BUFSIZE) Then
        m_buffer(m_buflen) = Microsoft.VisualBasic.Chr(0)
        m_buflen = m_buflen + 1
      End If
    End Sub

    ' public methods 

    ' Returns the next char in the buffer but doesn't advance the current position.
    Public Function LookAhead() As Char

      FillBuffer(1)
      LookAhead = m_buffer(m_curpos)
    End Function

    ' <summary>Returns the char at current position + the specified number of characters.
    ' Does not change the current position.</summary>
    ' <param name="p_pos">The position after the current one where the character to return is</param>
    Public Function LookAhead(ByVal p_pos As Integer) As Char

      FillBuffer(p_pos + 1)
      LookAhead = m_buffer(m_curpos + p_pos)
    End Function

    ' Returns the next char in the buffer and advances the current position by one.
    Public Function Read() As Char

      FillBuffer(1)
      Read = m_buffer(m_curpos)
      m_curpos = m_curpos + 1
    End Function

    ' Returns the next n characters in the buffer and advances the current position by n.
    Public Function Read(ByVal p_length As Integer) As String

      FillBuffer(p_length)
      Dim result As New String(m_buffer, m_curpos, p_length)
      m_curpos = m_curpos + p_length
      Read = result
    End Function

    ' Advances the current position in the buffer until a newline is encountered.
    Public Sub DiscardLine()

      Do While (LookAhead() <> Microsoft.VisualBasic.vbCr)
        m_curpos = m_curpos + 1
      Loop
    End Sub

    ' Closes the underlying StreamReader.
    Public Sub Close()

      m_reader.Close()
    End Sub
  End Class
End Namespace
