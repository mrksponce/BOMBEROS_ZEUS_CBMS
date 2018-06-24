'********************************************************************************************************
'File Name: clsLabelClass.vb
'Description: Friend class stores information about labels.   
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
'5/21/2007 - Tom Shanley (tws) - lock the map while adding labels to prevent repeated repaint
'********************************************************************************************************
Imports System.Drawing

Friend Class LabelInfo

    'member variables
    Public extents As MapWinGIS.Extents
    Public UseMinZoomLevel As Boolean

    Public Sub New(ByVal UseZoomLevel As Boolean, ByVal ex As MapWinGIS.Extents)
        extents = ex
        UseMinZoomLevel = UseZoomLevel
    End Sub

    Public Sub New(ByVal UseZoomLevel As Boolean, ByVal xMin As Double, ByVal yMin As Double, ByVal xMax As Double, ByVal yMax As Double)
        extents = New MapWinGIS.Extents
        extents.SetBounds(xMin, yMin, 0, xMax, yMax, 0)
        UseMinZoomLevel = UseZoomLevel
    End Sub
End Class

Friend Class LabelClass

    'create own point class
    Private Class Point
        Public x As Double
        Public y As Double

        Public Sub New(ByVal newX As Double, ByVal newY As Double)
            x = newX
            y = newY
        End Sub

        'calculate the dist from this point to point p
        Public Function Dist(ByVal p As Point) As Double
            Return Math.Sqrt(Math.Pow((y - p.y), 2) + Math.Pow((x - p.x), 2))
        End Function

    End Class

    'member variables
    Private m_Layers As Collections.Hashtable

    Public Sub New()
        m_Layers = New Collections.Hashtable
    End Sub

    Public Function LoadLabelInfo(ByVal layer As MapWindow.Layer, ByVal owner As System.Windows.Forms.Form, Optional ByVal OverrideFilename As String = "") As Boolean
        Dim filename As String = ""
        'Try the file within the project-level settings first
        'http://www.mapwindow.org/phorum/read.php?4,7945,7956#msg-7956
        '...but only if the user wants us to
        If AppInfo.LabelsUseProjectLevel Then
            If frmMain.Project.FileName IsNot Nothing AndAlso Not frmMain.Project.FileName.Trim() = "" Then filename = System.IO.Path.GetFileNameWithoutExtension(frmMain.Project.FileName) & "\" & System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(layer.FileName), ".lbl")
        End If

        'No project-level label file, or user doesn't want to use project-level labels
        If filename = "" OrElse Not System.IO.File.Exists(filename) Then
            'Try the shapefile-level label file
            filename = System.IO.Path.ChangeExtension(layer.FileName, ".lbl")
        End If

        If Not OverrideFilename = "" Then filename = OverrideFilename

        If Not System.IO.File.Exists(filename) Then Return False

        Try
            Dim doc As Xml.XmlDocument = New Xml.XmlDocument

            'load the xml file
            doc.Load(filename)

            'get the root of the file
            Dim root As Xml.XmlElement = doc.DocumentElement
            Dim node As Xml.XmlElement = root.Item("Labels")

            'get the font
            Dim fontName As String = node.Attributes.GetNamedItem("Font").InnerText
            Dim size As Double = Double.Parse(node.Attributes.GetNamedItem("Size").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(CInt(node.Attributes.GetNamedItem("Color").InnerText))
            Dim justification As Integer = CInt(node.Attributes.GetNamedItem("Justification").InnerText)
            Dim UseZoomLevel As Boolean = CBool(node.Attributes.GetNamedItem("UseMinZoomLevel").InnerText)
            Dim Scaled As Boolean = False
            Dim UseShadows As Boolean = False
            Dim ShadowColor As System.Drawing.Color = Drawing.Color.White
            Dim Offset As Integer = 0
            Dim StandardViewWidth As Double = 0
            Dim UseLabelCollision As Boolean = False
            Dim RemoveDuplicateLabels As Boolean = False
            Dim RotationField As String = ""
            Dim AppendLine1 As String = ""
            Dim AppendLine2 As String = ""
            Dim PrependLine1 As String = ""
            Dim PrependLine2 As String = ""

            'If the .lbl file is a new version, get the new label information
            'CDM 6/2/2007 for Bugzilla 489 -- sequential version numbering can't be relied on for detecting if new label information should be read.
            Try
                If Not node.Attributes.GetNamedItem("Scaled") Is Nothing Then Scaled = CBool(node.Attributes.GetNamedItem("Scaled").InnerText)
            Catch
                Scaled = False
            End Try
            Try
                If Not node.Attributes.GetNamedItem("UseShadows") Is Nothing Then UseShadows = CBool(node.Attributes.GetNamedItem("UseShadows").InnerText)
            Catch
                UseShadows = False
            End Try
            Try
                If Not node.Attributes.GetNamedItem("ShadowColor") Is Nothing Then ShadowColor = System.Drawing.Color.FromArgb(CInt(node.Attributes.GetNamedItem("ShadowColor").InnerText))
            Catch
                ShadowColor = Drawing.Color.White
            End Try
            Try
                If Not node.Attributes.GetNamedItem("Offset") Is Nothing Then Offset = CInt(node.Attributes.GetNamedItem("Offset").InnerText)
            Catch
                Offset = 0
            End Try
            Try
                If Not node.Attributes.GetNamedItem("StandardViewWidth") Is Nothing Then StandardViewWidth = Double.Parse(node.Attributes.GetNamedItem("StandardViewWidth").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            Catch
                StandardViewWidth = 0
            End Try

            If Not node.Attributes.GetNamedItem("UseLabelCollision") Is Nothing Then
                UseLabelCollision = CBool(node.Attributes.GetNamedItem("UseLabelCollision").InnerText)
            End If
            If Not node.Attributes.GetNamedItem("RemoveDuplicateLabels") Is Nothing Then
                RemoveDuplicateLabels = CBool(node.Attributes.GetNamedItem("RemoveDuplicateLabels").InnerText)
            End If
            Dim xMin As Double = Double.Parse(node.Attributes.GetNamedItem("xMin").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            Dim yMin As Double = Double.Parse(node.Attributes.GetNamedItem("yMin").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            Dim xMax As Double = Double.Parse(node.Attributes.GetNamedItem("xMax").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
            Dim yMax As Double = Double.Parse(node.Attributes.GetNamedItem("yMax").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)

            'save the label information
            Dim lbInfo As New LabelInfo(UseZoomLevel, xMin, yMin, xMax, yMax)
            If (m_Layers.ContainsKey(layer.Handle)) Then
                m_Layers(layer.Handle) = lbInfo
            Else
                m_Layers.Add(layer.Handle, lbInfo)
            End If

            'set all the properties of the label
            Dim font As Font = New System.Drawing.Font(fontName, CSng(size))
            layer.Font(font.Name, CInt(font.Size))

            layer.LabelsScale = Scaled
            layer.LabelsShadow = UseShadows
            layer.LabelsShadowColor = ShadowColor
            layer.LabelsOffset = Offset
            layer.StandardViewWidth = StandardViewWidth

            If Not node.Attributes.GetNamedItem("UseLabelCollision") Is Nothing Then
                layer.UseLabelCollision = UseLabelCollision
            End If

            'clear all previous labels
            layer.ClearLabels()

            ' lock the map so it doesn't redraw on each label (tws)
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)

            'add all the points to this label
            Dim x As Double, y As Double, rotation As Integer = 0, value As String

            'ARA 2/17/2009 If header with no labels is found, regenerate the labels
            Dim sf As MapWinGIS.Shapefile = layer.GetObject()
            If node.ChildNodes.Count = 0 And sf.NumShapes <> 0 Then
                frmMain.Plugins.BroadcastMessage("LABEL_RELABEL:" & layer.Handle)
            End If

            Dim enumerator As System.Collections.IEnumerator = node.ChildNodes.GetEnumerator()
            While (enumerator.MoveNext())

                node = CType(enumerator.Current, Xml.XmlElement)

                ' Paul Meems, 15 August 2008, Issue #975
                ' Added Try Catch Continue block around reading X and Y
                Try
                    x = Double.Parse(node.Attributes.GetNamedItem("X").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                    y = Double.Parse(node.Attributes.GetNamedItem("Y").InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture)
                Catch
                    Continue While
                End Try

                Try
                    If Not node.Attributes.GetNamedItem("Rotation") Is Nothing Then rotation = CInt(node.Attributes.GetNamedItem("Rotation").InnerText)
                Catch
                    rotation = 0
                End Try
                value = node.Attributes.GetNamedItem("Name").InnerText

                'draw label, using either the old way, or the new way with rotation enabled
                If Not rotation = 0 Then
                    layer.AddLabelEx(value, color, x, y, CType(justification, MapWinGIS.tkHJustification), rotation)
                Else
                    layer.AddLabel(value, color, x, y, CType(justification, MapWinGIS.tkHJustification))
                End If
            End While

            ' Paul Meems, 15 August 2008, Issue #975
            ' Move these lines to the Finally block, so MW doesn't stay locked on error:
            ' unlock the map so it will redraw now (tws)
            ' frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
            ' frmMain.m_Labels.TestLabelZoomExtents()
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(owner, "Error reading " + filename + ". Message: " & ex.Message, "Corrupted file ", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            Return False
        Finally
            ' Paul Meems, 15 August 2008, Issue #975 
            ' Moved these lines so MW doesn't stay locked on error:
            ' unlock the map so it will redraw now (tws)
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
            ' Start assuming visible - if we have labels, we want to shown them
            ' Override via TestLabelZoomExtents if needed
            layer.LabelsVisible = True
            frmMain.m_Labels.TestLabelZoomExtents()
            ' The labels aren't shown when using zoom level, not until doing a zoom in and zoom out first:
            frmMain.Refresh()
        End Try

        Return True
    End Function

    Public Sub TestLabelZoomExtents()
        Dim lbInfo As LabelInfo
        Dim dict As System.Collections.DictionaryEntry
        Dim enumerator As System.Collections.IEnumerator = m_Layers.GetEnumerator()
        Dim success As Boolean = True
        Dim keysToDelete As New ArrayList

        'cycle through all the stored labels
        While (enumerator.MoveNext())
            success = True
            dict = CType(enumerator.Current, System.Collections.DictionaryEntry)
            lbInfo = CType(dict.Value, MapWindow.LabelInfo)

            'check to make sure this is a valid layer
            If (Not frmMain.Layers.IsValidHandle(CInt(dict.Key))) Then
                keysToDelete.Add(dict.Key)
                success = False
            End If

            If (lbInfo.UseMinZoomLevel = False) Then
                'Make no arbitrary changes to label visibility (bug 806) except when applying labels directly from editor.
                'If frmMain.Layers(CInt(dict.Key)) Is Nothing Then
                'Else
                '    frmMain.Layers(CInt(dict.Key)).LabelsVisible = True
                'End If
                success = False
            End If

            If (success) Then

                'calculate the dist from the saved extents
                Dim p1 As Point = New Point(lbInfo.extents.xMin, lbInfo.extents.yMin)
                Dim p2 As Point = New Point(lbInfo.extents.xMax, lbInfo.extents.yMax)

                Dim dist1 As Double = p1.Dist(p2)

                'calculate the dist form the view extents
                Dim p3 As Point = New Point(frmMain.View.Extents.xMin, frmMain.View.Extents.yMin)
                Dim p4 As Point = New Point(frmMain.View.Extents.xMax, frmMain.View.Extents.yMax)

                Dim dist2 As Double = p3.Dist(p4)

                'check to see if the labels are within tolerance
                If (dist1 >= dist2) Then
                    frmMain.Layers(CInt(dict.Key)).LabelsVisible = True
                Else
                    frmMain.Layers(CInt(dict.Key)).LabelsVisible = False
                End If
            End If
        End While

        'delete any invalid layers
        Dim handle As Integer
        For Each handle In keysToDelete
            m_Layers.Remove(handle)
        Next
    End Sub
End Class
