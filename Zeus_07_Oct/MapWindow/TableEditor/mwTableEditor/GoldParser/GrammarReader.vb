'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System
Imports System.IO
Imports System.Text
Imports System.Collections

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http:'www.devincook.com/goldparser>.
Namespace GoldParser

  ' <summary>This class is used to read information stored in the very simple file
  ' structure used by the Compiled Grammar Table file.</summary>
  Friend Class GrammarReader

        Private Const c_filetype As String = "GOLD Parser Tables/v1.0"

    Private m_encoding As Encoding
    Private m_reader As BinaryReader
    Private m_entryQueue As Queue

        ' constructor

        Public Sub New(ByVal p_filename As String)

            Try

                m_encoding = New UnicodeEncoding(False, True)

                '"CompiledCalculatorGrammar.cgt"
                m_reader = New BinaryReader(New FileStream(p_filename, FileMode.Open))
                m_entryQueue = New Queue

            Catch e As Exception

                Throw New ParserException("Error constructing GrammarReader", e)
            End Try

            If (Not HasValidHeader()) Then
                Throw New ParserException("Incorrect file header")
            End If

        End Sub

        Public Sub FinalizeReader()
            m_reader.Close()
        End Sub



        ' public methods

        Public Function MoveNext() As Boolean

            Try
                Dim content As EntryContent = m_reader.ReadByte()
                If (content = EntryContent.Multi) Then

                    m_entryQueue.Clear()
                    Dim count As Integer = m_reader.ReadInt16()

                    Dim n As Integer
                    For n = 0 To count - 1
                        ReadEntry()
                    Next
                    Return True
                Else
                    Return False
                End If
            Catch e As IOException

                Return False
            End Try
        End Function

        Public Function RetrieveNext() As Object

            If (m_entryQueue.Count = 0) Then
                RetrieveNext = Nothing
            Else
                RetrieveNext = m_entryQueue.Dequeue()
            End If
        End Function

        Public Function RetrieveDone() As Boolean

            RetrieveDone = (m_entryQueue.Count = 0)
        End Function

        ' private methods

        Private Function HasValidHeader() As Boolean

            Dim filetype As New String(ReadString())
            HasValidHeader = filetype.Equals(c_filetype)
        End Function

        Private Function ReadString() As String

            Dim pos As Integer
            Dim buffer(1024) As Byte

            Do While (True)

                m_reader.Read(buffer, pos, 2)
                If (buffer(pos) = 0) Then Exit Do
                pos = pos + 2
            Loop

            ReadString = m_encoding.GetString(buffer, 0, pos)
        End Function

        Private Sub ReadEntry()
            Dim content As EntryContent = m_reader.ReadByte()
            Select Case content

                Case EntryContent.Empty
                    m_entryQueue.Enqueue(New Object)
                Case EntryContent.Boolean
                    Dim boolvalue As Boolean = (m_reader.ReadByte() = 1)
                    m_entryQueue.Enqueue(boolvalue)
                Case EntryContent.Byte
                    Dim bytevalue As Byte = m_reader.ReadByte()
                    m_entryQueue.Enqueue(bytevalue)
                Case EntryContent.Integer
                    Dim intvalue As Int16 = m_reader.ReadInt16()
                    m_entryQueue.Enqueue(intvalue)
                Case EntryContent.String
                    Dim strvalue As New String(ReadString())
                    m_entryQueue.Enqueue(strvalue)
                Case Else
                    Throw New ParserException("Error reading CGT: unknown entry-content type")
            End Select
        End Sub

    End Class
End Namespace
