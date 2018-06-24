'********************************************************************************************************
'File Name: clsDraw.vb
'Description: Public class used to access drawing functions through the plugin interface.
'********************************************************************************************************
'The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
'you may not use this file except in compliance with the License. You may obtain a copy of the License at 
'http://www.mozilla.org/MPL/ 
'Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
'ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
'limitations under the License. 
'
'The Original Code is MapWindow Open Source. 
'
'The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
'Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
'public domain in March 2004.  
'
'Contributor(s): (Open source contributors should list themselves and their modifications here). 
'1/31/2005 - No change from the public domain version.
'7/3/2007 - Dan Ames - Modified DrawPolygon to work.  Pass in the full array of points, not just the first element.
'********************************************************************************************************

Public Class Draw
    Implements Interfaces.Draw

    '--------------------------------------Draw Public Interface--------------------------------------
    '27 Aug 2001  Darrel Brown.  Refer to Document "MapWindow 2.0 Public Interface" Page 3
    '------------------------------------------------------------------------------------------------------------

    '-------------------Subs-------------------
    Public Sub ClearDrawing(ByVal DrawHandle As Integer) Implements Interfaces.Draw.ClearDrawing
        frmMain.MapMain.ClearDrawing(DrawHandle)
    End Sub

    Public Sub ClearDrawings() Implements Interfaces.Draw.ClearDrawings
        frmMain.MapMain.ClearDrawings()
    End Sub

    Public Sub DrawCircle(ByVal x As Double, ByVal y As Double, ByVal PixelRadius As Double, ByVal Color As System.Drawing.Color, ByVal FillCircle As Boolean) Implements Interfaces.Draw.DrawCircle
        frmMain.MapMain.DrawCircle(x, y, PixelRadius, MapWinUtility.Colors.ColorToUInteger(Color), FillCircle)
    End Sub

    Public Sub DrawLine(ByVal X1 As Double, ByVal Y1 As Double, ByVal X2 As Double, ByVal Y2 As Double, ByVal PixelWidth As Integer, ByVal Color As System.Drawing.Color) Implements Interfaces.Draw.DrawLine
        frmMain.MapMain.DrawLine(X1, Y1, X2, Y2, PixelWidth, MapWinUtility.Colors.ColorToUInteger(Color))
    End Sub

    Public Sub DrawPoint(ByVal x As Double, ByVal y As Double, ByVal PixelSize As Integer, ByVal Color As System.Drawing.Color) Implements Interfaces.Draw.DrawPoint
        frmMain.MapMain.DrawPoint(x, y, PixelSize, MapWinUtility.Colors.ColorToUInteger(Color))
    End Sub

    Public Sub DrawPolygon(ByVal x() As Double, ByVal y() As Double, ByVal Color As System.Drawing.Color, ByVal FillPolygon As Boolean) Implements Interfaces.Draw.DrawPolygon
        'frmMain.MapMain.DrawPolygon(CType(x(0), Object), CType(y(0), Object), y.Length, MapWinUtility.Colors.ColorToUInteger(Color), FillPolygon)
        'Dan Ames July 2007 - pass in the full array, not just the first element!
        frmMain.MapMain.DrawPolygon(CType(x, Object), CType(y, Object), y.Length, MapWinUtility.Colors.ColorToUInteger(Color), FillPolygon)
    End Sub


    '-------------------Functions-------------------
    <CLSCompliant(False)> _
    Public Function NewDrawing(ByVal Projection As MapWinGIS.tkDrawReferenceList) As Integer Implements Interfaces.Draw.NewDrawing
        NewDrawing = frmMain.MapMain.NewDrawing(Projection)
    End Function


    '-------------------Properties-------------------
    Public Property DoubleBuffer() As Boolean Implements Interfaces.Draw.DoubleBuffer
        Get
            DoubleBuffer = frmMain.MapMain.DoubleBuffer
        End Get
        Set(ByVal Value As Boolean)
            frmMain.MapMain.DoubleBuffer = Value
        End Set
    End Property

    'Public Property DrawingKey(ByVal DrawingHandle As Integer) As Integer Implements Interfaces.Draw.DrawingKey
    '    Get
    '        DrawingKey = frmMain.MapMain.get_DrawingKey(DrawingHandle)
    '    End Get
    '    Set(ByVal Value As Integer)
    '        frmMain.MapMain.set_DrawingKey(DrawingHandle, Value)
    '    End Set
    'End Property

End Class


