'********************************************************************************************************
'File Name: XMLLabelFile.vb
'Description: Label Configuration File Editor Class.
'********************************************************************************************************
'The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
'you may not use this file except in compliance with the License. You may obtain a copy of the License at 
'http://www.mozilla.org/MPL/ 
'Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
'ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
'limitations under the License. 
'The Original Code is MapWindow Open Source. 
'This code was originally written in C# in the Label Editor Plugin.
'
'The initial developer of this vb.net version is Lailin Chen
'
'Contributor(s): (Open source contributors should list themselves and their modifications here). 



Option Strict Off
Imports System.Xml

Public Class XMLLabelFile

    Private m_MapWin As MapWindow.Layer
    Private m_MapWinVersion As String
    Private m_doc As New System.Xml.XmlDocument
    Private axMap As AxMapWinGIS.AxMap

    Public Sub New(ByVal mapwin As MapWindow.Layer, ByVal map As AxMapWinGIS.AxMap, ByVal mapVersion As String)
        m_MapWin = mapwin
        m_MapWinVersion = mapVersion
        axMap = map
    End Sub

    'This function will only save the font, extent, color inforamtion to the first line of the 
    'config file, all the remaining lines will remain untouched if the file already exists, or, would
    'be created from the shapefile 
    Public Sub SaveLabelHeaderInfo(ByVal labelex As LabelEx, ByVal fileName As String)
        If System.IO.File.Exists(fileName) Then
            Try
                'find out what mapwindow version is
                m_doc.Load(fileName)
                Dim root As System.Xml.XmlElement = m_doc.DocumentElement

                Dim Labels As XmlElement = m_doc.GetElementsByTagName("Labels")(0)
                Dim Field As XmlAttribute = Labels.Attributes("Field")
                Dim Font As XmlAttribute = Labels.Attributes("Font")
                Dim Size As XmlAttribute = Labels.Attributes("Size")
                Dim Color As XmlAttribute = Labels.Attributes("Color")
                Dim Justification As XmlAttribute = Labels.Attributes("Justification")
                Dim UseMinZoomLevel As XmlAttribute = Labels.Attributes("UseMinZoomLevel")
                Dim xMin As XmlAttribute = Labels.Attributes("xMin")
                Dim yMin As XmlAttribute = Labels.Attributes("yMin")
                Dim xMax As XmlAttribute = Labels.Attributes("xMax")
                Dim yMax As XmlAttribute = Labels.Attributes("yMax")

                'save the layer label properties
                Field.InnerText = labelex.field.ToString()
                Font.InnerText = labelex.font.Name
                Size.InnerText = labelex.font.Size.ToString()
                Color.InnerText = labelex.color.ToArgb().ToString()
                Justification.InnerText = labelex.alignment
                UseMinZoomLevel.InnerText = labelex.UseMinExtents.ToString()

                If Not labelex.extents Is Nothing Then

                    xMin.InnerText = labelex.extents.xMin.ToString()
                    yMin.InnerText = labelex.extents.yMin.ToString()
                    xMax.InnerText = labelex.extents.xMax.ToString()
                    yMax.InnerText = labelex.extents.yMax.ToString()

                Else

                    xMin.InnerText = "0"
                    yMin.InnerText = "0"
                    xMax.InnerText = "0"
                    yMax.InnerText = "0"
                End If

                m_doc.Save(fileName)

            Catch ex As System.Exception
                System.Diagnostics.Trace.WriteLine(ex.ToString())
            End Try
        Else 'The label doesn't exist, creat one and work on it.
            Try
                'find out what mapwindow version is
                m_doc.LoadXml("<MapWindow version= '" + m_MapWinVersion + "'></MapWindow>")
                Dim root As System.Xml.XmlElement = m_doc.DocumentElement

                Dim Labels As XmlElement = m_doc.CreateElement("Labels")
                Dim Field As XmlAttribute = m_doc.CreateAttribute("Field")
                Dim Font As XmlAttribute = m_doc.CreateAttribute("Font")
                Dim Size As XmlAttribute = m_doc.CreateAttribute("Size")
                Dim Color As XmlAttribute = m_doc.CreateAttribute("Color")
                Dim Justification As XmlAttribute = m_doc.CreateAttribute("Justification")
                Dim UseMinZoomLevel As XmlAttribute = m_doc.CreateAttribute("UseMinZoomLevel")
                Dim xMin As XmlAttribute = m_doc.CreateAttribute("xMin")
                Dim yMin As XmlAttribute = m_doc.CreateAttribute("yMin")
                Dim xMax As XmlAttribute = m_doc.CreateAttribute("xMax")
                Dim yMax As XmlAttribute = m_doc.CreateAttribute("yMax")

                'save the layer label properties
                Field.InnerText = labelex.field.ToString()
                Font.InnerText = labelex.font.Name
                Size.InnerText = labelex.font.Size.ToString()
                Color.InnerText = labelex.color.ToArgb().ToString()
                Justification.InnerText = labelex.alignment
                UseMinZoomLevel.InnerText = labelex.UseMinExtents.ToString()

                If Not labelex.extents Is Nothing Then

                    xMin.InnerText = labelex.extents.xMin.ToString()
                    yMin.InnerText = labelex.extents.yMin.ToString()
                    xMax.InnerText = labelex.extents.xMax.ToString()
                    yMax.InnerText = labelex.extents.yMax.ToString()

                Else

                    xMin.InnerText = "0"
                    yMin.InnerText = "0"
                    xMax.InnerText = "0"
                    yMax.InnerText = "0"
                End If

                'add the attributes to the Labels node
                Labels.Attributes.Append(Field)
                Labels.Attributes.Append(Font)
                Labels.Attributes.Append(Size)
                Labels.Attributes.Append(Color)
                Labels.Attributes.Append(Justification)
                Labels.Attributes.Append(UseMinZoomLevel)
                Labels.Attributes.Append(xMin)
                Labels.Attributes.Append(yMin)
                Labels.Attributes.Append(xMax)
                Labels.Attributes.Append(yMax)

                Dim shpFile As MapWinGIS.Shapefile
                shpFile = m_MapWin.GetObject()

                Dim name As String
                Dim i As Integer = 0

                For i = 0 To shpFile.NumShapes - 1
                    name = shpFile.CellValue(labelex.field - 1, i).ToString()
                    Dim x, y As Integer
                    FindXYValues(shpFile, i, x, y)
                    Dim p As Point = New Point(x, y)
                    AddPointLabel(p, name, Labels)
                Next

                'add all of the lablels to the root
                root.AppendChild(Labels)

                'save the lable file
                m_doc.Save(fileName)

            Catch ex As System.Exception
                System.Diagnostics.Trace.WriteLine(ex.ToString())
            End Try
        End If

    End Sub

    Private Sub FindXYValues(ByVal shpFile As MapWinGIS.Shapefile, ByVal shapeIndex As Integer, ByRef x As Double, ByRef y As Double)

        Dim dist As Double = 0
        Dim area As Double = 0
        Dim cX As Double = 0
        Dim cY As Double = 0
        Dim p1, p2 As MapWinGIS.Point

        Dim Shape As MapWinGIS.Shape = shpFile.Shape(shapeIndex)
        Dim count As Integer = Shape.numPoints

        If (Shape.ShapeType = MapWinGIS.ShpfileType.SHP_POLYGON) Then
            If count <= 4 Then

                dist = Math.Sqrt(Math.Pow(Shape.Extents.xMin - Shape.Extents.xMax, 2) + Math.Pow((Shape.Extents.yMin - Shape.Extents.yMin), 2)) / 2
                cX = Shape.Extents.xMax - dist

                dist = Math.Sqrt(Math.Pow(Shape.Extents.xMin - Shape.Extents.xMin, 2) + Math.Pow((Shape.Extents.yMin - Shape.Extents.yMax), 2)) / 2
                cY = Shape.Extents.yMax - dist

                x = cX
                y = cY
                Return
            Else
                'calculate the area of the poly
                Dim i As Integer = 0
                For i = 0 To count - 1

                    p1 = Shape.Point(i)

                    If i = count - 1 Then
                        p2 = Shape.Point(0)
                    Else
                        p2 = Shape.Point(i + 1)
                    End If

                    area += (p1.x * p2.y - p2.x * p1.y)
                Next
                area *= 0.5

                'calculate the centroid
                For i = 0 To count - 1

                    p1 = Shape.Point(i)

                    If i = count - 1 Then
                        p2 = Shape.Point(0)
                    Else
                        p2 = Shape.Point(i + 1)
                    End If

                    cX += (p1.x + p2.x) * (p1.x * p2.y - p2.x * p1.y)
                    cY += (p1.y + p2.y) * (p1.x * p2.y - p2.x * p1.y)
                Next
                cX *= 1 / (6 * area)
                cY *= 1 / (6 * area)

                shpFile.BeginPointInShapefile()
                'test to make sure the centroid is the poly
                If (shpFile.PointInShape(shapeIndex, cX, cY) = False) Then
                    FindXY(shpFile, shapeIndex, cX, cY)
                End If

                x = cX
                y = cY
                Return

            End If ' count<4
        ElseIf (Shape.ShapeType = MapWinGIS.ShpfileType.SHP_POINT) Then
            x = Shape.Extents.xMax
            y = Shape.Extents.yMax
            Return
        ElseIf (Shape.ShapeType = MapWinGIS.ShpfileType.SHP_POLYLINE) Then
            Dim cnt As Integer = Shape.numPoints
            x = Shape.Point(cnt / 2).x
            y = Shape.Point(cnt / 2).y
            Return
        End If ' for other shapes

    End Sub


    Private Sub FindXY(ByVal shpFile As MapWinGIS.Shapefile, ByVal shapeIndex As Integer, ByRef cX As Double, ByRef cY As Double)

        Dim shape As MapWinGIS.Shape = shpFile.Shape(shapeIndex)

        Dim xFirst As Double = -1
        Dim xLast As Double = -1
        Dim tolx1 As Double = 0
        Dim toly1 As Double = 0
        Dim tolx2 As Double = 0
        Dim toly2 As Double = 0
        Dim stepSize As Double


        'caluculate step size
        axMap.PixelToProj(0, 0, tolx1, toly1)
        axMap.PixelToProj(1, 0, tolx2, toly2)
        stepSize = System.Math.Pow((tolx1 - tolx2), 2) + System.Math.Pow((toly1 - toly2), 2)

        Dim xMin As Double = shape.Extents.xMin
        Dim xMax As Double = shape.Extents.xMax
        Dim i As Integer
        For i = xMin To xMax Step stepSize
            If (shpFile.PointInShape(shapeIndex, i, cY)) Then
                'if the x value is in the boundary and it's the first time found then save
                If (xFirst = -1) Then
                    xFirst = i
                    'if the end x value is in the shape then set that to the last point
                ElseIf (i + stepSize >= xMax) Then
                    xLast = i
                End If
            Else

                'if the first x value was already found then save the last x value
                If (xFirst <> -1) Then
                    xLast = i
                    'exit from the for loop
                    Exit For
                End If
            End If
        Next

        'return the x value that lies between the two poly boundary
        cX = xFirst + (xLast - xFirst) / 2

    End Sub








    Public Sub SaveLabelInfo(ByVal labelex As LabelEx, ByVal fileName As String)
        Try
            'find out what mapwindow version is
            m_doc.LoadXml("<MapWindow version= '" + m_MapWinVersion + "'></MapWindow>")
            Dim root As System.Xml.XmlElement = m_doc.DocumentElement

            Dim Labels As XmlElement = m_doc.CreateElement("Labels")
            Dim Field As XmlAttribute = m_doc.CreateAttribute("Field")
            Dim Font As XmlAttribute = m_doc.CreateAttribute("Font")
            Dim Size As XmlAttribute = m_doc.CreateAttribute("Size")
            Dim Color As XmlAttribute = m_doc.CreateAttribute("Color")
            Dim Justification As XmlAttribute = m_doc.CreateAttribute("Justification")
            Dim UseMinZoomLevel As XmlAttribute = m_doc.CreateAttribute("UseMinZoomLevel")
            Dim xMin As XmlAttribute = m_doc.CreateAttribute("xMin")
            Dim yMin As XmlAttribute = m_doc.CreateAttribute("yMin")
            Dim xMax As XmlAttribute = m_doc.CreateAttribute("xMax")
            Dim yMax As XmlAttribute = m_doc.CreateAttribute("yMax")

            'save the layer label properties
            Field.InnerText = labelex.field.ToString()
            Font.InnerText = labelex.font.Name
            Size.InnerText = labelex.font.Size.ToString()
            Color.InnerText = labelex.color.ToArgb().ToString()
            Justification.InnerText = labelex.alignment
            UseMinZoomLevel.InnerText = labelex.UseMinExtents.ToString()

            If Not labelex.extents Is Nothing Then

                xMin.InnerText = labelex.extents.xMin.ToString()
                yMin.InnerText = labelex.extents.yMin.ToString()
                xMax.InnerText = labelex.extents.xMax.ToString()
                yMax.InnerText = labelex.extents.yMax.ToString()

            Else

                xMin.InnerText = "0"
                yMin.InnerText = "0"
                xMax.InnerText = "0"
                yMax.InnerText = "0"
            End If

            'add the attributes to the Labels node
            Labels.Attributes.Append(Field)
            Labels.Attributes.Append(Font)
            Labels.Attributes.Append(Size)
            Labels.Attributes.Append(Color)
            Labels.Attributes.Append(Justification)
            Labels.Attributes.Append(UseMinZoomLevel)
            Labels.Attributes.Append(xMin)
            Labels.Attributes.Append(yMin)
            Labels.Attributes.Append(xMax)
            Labels.Attributes.Append(yMax)

            Dim shpFile As MapWinGIS.Shapefile
            shpFile = m_MapWin.GetObject()

            Dim name As String
            Dim i As Integer = 0

            For i = 0 To shpFile.NumShapes - 1
                name = shpFile.CellValue(labelex.field - 1, i).ToString()
                Dim x As Integer = 0
                Dim y As Integer = 0
                Dim p As New Point

                FindXYValues(shpFile, i, x, y)
                Dim pt As Point = New Point(x, y)
                AddPointLabel(pt, name, Labels)

            Next

            'add all of the lablels to the root
            root.AppendChild(Labels)

            'save the lable file
            m_doc.Save(fileName.Substring(0, fileName.Length - 4) + ".lbl")

        Catch ex As System.Exception
            System.Diagnostics.Trace.WriteLine(ex.ToString())
        End Try

    End Sub

    Private Sub AddPointLabel(ByVal p As Point, ByVal labelName As String, ByVal parent As XmlElement)
        Try
            Dim Label As XmlElement = m_doc.CreateElement("Label")
            Dim X As XmlAttribute = m_doc.CreateAttribute("X")
            Dim Y As XmlAttribute = m_doc.CreateAttribute("Y")
            Dim Name As XmlAttribute = m_doc.CreateAttribute("Name")

            X.InnerText = p.X.ToString()
            Y.InnerText = p.Y.ToString()
            Name.InnerText = labelName

            Label.Attributes.Append(X)
            Label.Attributes.Append(Y)
            Label.Attributes.Append(Name)

            parent.AppendChild(Label)
        Catch ex As System.Exception
            System.Diagnostics.Trace.WriteLine(ex.ToString())
        End Try

    End Sub

    Public Function LoadLabelInfo(ByVal layer As MapWindow.Layer, ByRef label As LabelEx, ByVal owner As System.Windows.Forms.Form) As Boolean
        Dim filename As String = System.IO.Path.ChangeExtension(layer.FileName, ".lbl")
        If Not System.IO.File.Exists(filename) Then
            Return False
        End If

        Try
            'load the xml file
            m_doc.Load(filename)

            'get the root of the file
            Dim root As System.Xml.XmlElement = m_doc.DocumentElement

            label.points = New System.Collections.ArrayList

            Dim nodeList As XmlNodeList = root.GetElementsByTagName("Labels")

            'get the font
            Dim field As Integer = Integer.Parse(nodeList(0).Attributes.GetNamedItem("Field").InnerText)
            Dim fontName As String = nodeList(0).Attributes.GetNamedItem("Font").InnerText
            Dim size As String = Double.Parse(nodeList(0).Attributes.GetNamedItem("Size").InnerText)
            Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(Integer.Parse(nodeList(0).Attributes.GetNamedItem("Color").InnerText))
            Dim justification As Integer = Integer.Parse(nodeList(0).Attributes.GetNamedItem("Justification").InnerText)
            Dim UseMinZoom As Boolean = Boolean.Parse(nodeList(0).Attributes.GetNamedItem("UseMinZoomLevel").InnerText)
            Dim xMin As Double = Double.Parse(nodeList(0).Attributes.GetNamedItem("xMin").InnerText)
            Dim yMin As Double = Double.Parse(nodeList(0).Attributes.GetNamedItem("yMin").InnerText)
            Dim xMax As Double = Double.Parse(nodeList(0).Attributes.GetNamedItem("xMax").InnerText)
            Dim yMax As Double = Double.Parse(nodeList(0).Attributes.GetNamedItem("yMax").InnerText)

            'Set all the properties of the label
            label.font = New System.Drawing.Font(fontName, size)
            label.color = color
            label.field = field
            label.alignment = justification
            label.UseMinExtents = UseMinZoom
            label.extents = New MapWinGIS.ExtentsClass
            label.extents.SetBounds(xMin, yMin, 0, xMax, yMax, 0)
            label.Modified = False
            label.LabelExtentsChanged = False

            'add all the points to this label
            Dim p As Point
            Dim node As XmlNode
            Dim x, y As Double
            Dim enumerator As System.Collections.IEnumerator = nodeList(0).ChildNodes.GetEnumerator()
            While (enumerator.MoveNext())
                node = CType(enumerator.Current, XmlNode)
                x = Double.Parse(node.Attributes.GetNamedItem("X").InnerText)
                y = Double.Parse(node.Attributes.GetNamedItem("Y").InnerText)

                p = New Point
                p.X = x
                p.Y = y
                label.points.Add(p)
            End While
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(owner, "The file " + filename + " may be corrupted.", "Corrupted file", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            System.Diagnostics.Trace.WriteLine(ex.ToString())
            Return False
        End Try

        Return True

    End Function

End Class
