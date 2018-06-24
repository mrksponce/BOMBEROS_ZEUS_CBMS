'GoldParser tool - in support of Field Calculator tool. Brought in from the USU code base
'during merger by Chris M on April 21 2006. Thanks to USU
'for this!

Imports System

' VB.NET Translation of GoldParser, by Reggie Wilbanks <AppDeveloper@starband.net> converted (by hand) from,
' C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
' Based on GOLDParser by Devin Cook <http://www.devincook.com/goldparser>.
namespace GoldParser
  ' Thrown by the parser when an error occurs.
  ' Specialized exceptions may be added at a later time. 
  Public Class ParserException
    Inherits Exception

    ' Creates a new ParserException with the specified error string.
    Public Sub New(ByVal p_error As String)

    End Sub

    ' Creates a new ParserException with the specified error string and inner-exception.
    Public Sub New(ByVal p_error As String, ByVal p_exception As Exception)

    End Sub
  End Class

End Namespace
