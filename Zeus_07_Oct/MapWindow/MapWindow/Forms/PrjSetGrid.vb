'********************************************************************************************************
'File Name: PrjSetGrid.vb
'Description: Main GUI interface for the MapWindow application.
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
'10/6/2005 - Initial version created by Lailin Chen
'1/22/2006 - cdm - Added the ResizeBehavior property
'5/11/2007 - Tom Shanley (tws) - added the SaveShapeSettings property
'3/31/2008 - Jiri Kadlec (jk) - added the Language Settings options (OverrideSystemLocale and Locale)
'5/4/2008 - Jiri Kadlec (jk) - moved application-level settings to AppSetGrid, enabled internationalization
'                              The "Category", "Display Name" and "Description" entries are now stored in the 
'                              resource file (PrjSetGrid.resx) enabling translation to other languages
'5/26/2008 - Jiri Kadlec (jk) - added a "Configuration File Name" property. This is the .mwcfg file where the
'                               MapWindow application-level configuration settings are saved.
'********************************************************************************************************
Option Strict Off
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Imports MapWindow.PropertyGridUtils

'5/6/2008 jk - the following attribute enables localization of the class
<TypeConverter(GetType(MapWindow.PropertyGridUtils.GlobalizedTypeConverter))> _
Public Class PrjSetGrid

    ' The original [Project projection] Tab
    Private m_enableSpecifyProjection As Boolean
    Private m_MainCategory As String
    Private m_SubCategory As String
    Private m_Name As String
    Public Shared m_CurrentMain As String
    Public Shared m_CurrentSub As String

    ' The original [Coordinate Display] Tab
    Private m_MapCoordinates As Boolean
    Private m_LatitudeLongitude As Boolean

    Private projections As New clsProjections
    '---------------------------------------------------------------------------------

#Region "PrjSetGrid Constructor"

    Public Sub New()
        'If there's a project projection, load it
        If Not modMain.ProjInfo.ProjectProjection = "" Then
            m_enableSpecifyProjection = True
            Dim p As clsProjections.clsProjection = projections.FindProjectionByPROJ4(modMain.ProjInfo.ProjectProjection)
            ' Chris M - test for nothing first, in case of *very* unrecognized unprojection in the above function.
            If Not p Is Nothing Then
                m_MainCategory = p.MainCateg
                m_SubCategory = p.Category
                m_Name = p.Name
                m_CurrentMain = m_MainCategory
                m_CurrentSub = m_SubCategory
            Else
                m_enableSpecifyProjection = False
                m_MainCategory = ""
                m_SubCategory = ""
                m_Name = ""
                m_CurrentMain = ""
                m_CurrentSub = ""
            End If
        Else
            m_enableSpecifyProjection = False
            m_MainCategory = ""
            m_SubCategory = ""
            m_Name = ""
            m_CurrentMain = ""
            m_CurrentSub = ""
        End If
    End Sub

#End Region

#Region "Property Grid Entries"

    ' DISPLAY OPTIONS -- Use Default Background Color
    ' Set this option to "False" to change the map background color of this 
    ' project and override the application-level background color settings.

    <GlobalizedProperty(CategoryId:="DisplayOptionsCategory"), _
    PropertyOrder(0), ReadOnlyAttribute(False)> _
    Public Property BackgroundColor_UseDefault() As Boolean
        Get
            Return modMain.ProjInfo.UseDefaultBackColor
        End Get
        Set(ByVal Value As Boolean)
            modMain.ProjInfo.UseDefaultBackColor = Value '5/5/2008 JK

            'frmMain.MapMain.CtlBackColor = Value
            'Bug 767 - for some reason, this is necessary in order to pick up
            'system colors. Makes sense somewhat given how the object gets translated
            'to the OCX later on.
            Dim backColor As Color = AppInfo.DefaultBackColor
            If Value = True Then
                backColor = AppInfo.DefaultBackColor
                frmMain.View.BackColor = Color.FromArgb(backColor.A, backColor.R, backColor.G, backColor.B)
                frmMain.SetModified(True)
            Else
                backColor = modMain.ProjInfo.ProjectBackColor
                frmMain.View.BackColor = Color.FromArgb(backColor.A, backColor.R, backColor.G, backColor.B)
                frmMain.SetModified(True)
            End If
        End Set
    End Property


    ' DISPLAY OPTIONS -- Map Background Color
    ' Background color of main map (project-level). This setting overrides
    ' the default application-level map background color.

    <GlobalizedProperty(CategoryId:="DisplayOptionsCategory"), _
    PropertyOrder(1), ReadOnlyAttribute(False)> _
    Public Property BackgroundColor() As System.Drawing.Color
        Get
            Return modMain.ProjInfo.ProjectBackColor
        End Get
        Set(ByVal Value As System.Drawing.Color)

            modMain.ProjInfo.ProjectBackColor = Value '5/5/2008 JK

            If modMain.ProjInfo.UseDefaultBackColor = False Then
                'frmMain.MapMain.CtlBackColor = Value
                'Bug 767 - for some reason, this is necessary in order to pick up
                'system colors. Makes sense somewhat given how the object gets translated
                'to the OCX later on.
                frmMain.View.BackColor = Color.FromArgb(Value.A, Value.R, Value.G, Value.B)
                frmMain.SetModified(True)
            End If
        End Set
    End Property

    ' DISPLAY OPTIONS -- Transparent Selection
    ' Indicates whether selected shapes should be shown as transparent.

    <GlobalizedProperty(CategoryId:="DisplayOptionsCategory"), _
    PropertyOrder(2), ReadOnlyAttribute(False)> _
    Public Property TransparentSelection() As Boolean
        Get
            Return ProjInfo.TransparentSelection
        End Get
        Set(ByVal Value As Boolean)
            ProjInfo.TransparentSelection = Value

            frmMain.SetModified(True)
        End Set
    End Property

    ' PROJECT PROJECTION -- Name
    ' The name of the projection for this project. Choose this third._
    <GlobalizedProperty(CategoryId:="ProjectProjectionCategory"), _
    TypeConverter(GetType(NameCls)), _
    ReadOnlyAttribute(False)> _
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal Value As String)
            m_Name = Value
            UpdateProjectionSelection()
            frmMain.SetModified(True)
        End Set
    End Property

    ' PROJECT PROJECTION -- Subcategory
    ' The subcategory of projection for this project. Choose this second.
    <GlobalizedProperty(CategoryId:="ProjectProjectionCategory"), _
    TypeConverter(GetType(SubCategoryCls)), _
    ReadOnlyAttribute(False)> _
    Public Property Group() As String
        Get
            Return m_SubCategory
        End Get
        Set(ByVal Value As String)
            If m_MainCategory = "" Then 'Should select MainCategory first
                MessageBox.Show("Please Select MainCategory")
                Return
            End If
            m_SubCategory = Value
            m_CurrentSub = Value
            Name = ""   'refresh Name because subcategory has changed
            UpdateProjectionSelection()
            frmMain.SetModified(True)
        End Set
    End Property

    ' PROJECT PROJECTION -- Main Category
    ' The main category of projection for this project. Choose this first.
    <GlobalizedProperty(CategoryId:="ProjectProjectionCategory"), _
    TypeConverter(GetType(MainCategoryCls)), _
    ReadOnlyAttribute(False)> _
    Public Property Category() As String
        Get
            Return m_MainCategory
        End Get
        Set(ByVal Value As String)
            m_MainCategory = Value
            m_CurrentMain = Value

            If Value = "Custom Projection" Then
                Group = "Custom Projection"
                Name = "Custom Projection"
                If (UseSpecifyProjection) Then
                    'They already marked to use it, so go get the custom projection now.
                    GetCustomProjection()
                Else
                    'Don't prompt them to get it now. Eventually
                    'they'll need to turn on UseSpecifyProjection,
                    'so get it from them then.
                End If
            Else
                Group = ""
                Name = ""
            End If

            UpdateProjectionSelection()
            frmMain.SetModified(True)
        End Set
    End Property

    ' PROJECT PROJECTION -- Use Projection Info?
    ' Specifies that the projection information specified above should be used; 
    ' choose this last after choosing a projection above."), _
    <GlobalizedProperty(CategoryId:="ProjectProjectionCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property UseSpecifyProjection() As Boolean
        Get
            Return m_enableSpecifyProjection
        End Get
        Set(ByVal Value As Boolean)
            If Value = True And ("" = m_Name Or "" = m_MainCategory Or "" = m_SubCategory) Then
                MessageBox.Show("Please select Category, Group and Name Properly!") ' Should have projection properly selected before enable it
                Return
            End If
            If Value And Name = "Custom Projection" Then
                GetCustomProjection()
            ElseIf Value Then
                ProjInfo.ProjectProjection = projections.FindProjectionByCatAndName(m_MainCategory, m_SubCategory, m_Name)
            Else
                ProjInfo.ProjectProjection = ""
            End If
            Me.m_enableSpecifyProjection = Value
            frmMain.SetModified(True)
        End Set
    End Property

    Private Sub GetCustomProjection()
        '8/1/2006 - pm Changed for translation
        'Dim customPrjForm As New frmProjSettings()
        Dim customPrjForm As New frmCustomProjection()
        If customPrjForm.ShowDialog() = DialogResult.OK Then
            ProjInfo.ProjectProjection = customPrjForm.toString()
        Else
            ProjInfo.ProjectProjection = ""
        End If
    End Sub

    ' PROJECT PROJECTION -- Show Mismatch Warnings?
    ' Sets whether to prompt when a projection mismatch is detected between datasets.
    <GlobalizedProperty(CategoryId:="ProjectProjectionCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property ShowProjectionMismatchWarnings() As Boolean
        Get
            Return Not AppInfo.NeverShowProjectionDialog
        End Get
        Set(ByVal Value As Boolean)
            AppInfo.NeverShowProjectionDialog = Not Value
            frmMain.SetModified(True)
        End Set
    End Property

    ' COORDINATE DISPLAY -- Show Map Data Units
    ' Sets whether the coordinates should be displayed in the status bar in the map data units.
    <GlobalizedProperty(CategoryId:="CoordinateDisplayCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property ShowDataUnits() As Boolean
        Get
            Return modMain.ProjInfo.ShowStatusBarCoords_Projected
        End Get
        Set(ByVal Value As Boolean)
            modMain.ProjInfo.ShowStatusBarCoords_Projected = Value
            frmMain.SetModified(True)
        End Set
    End Property

    ' COORDINATE DISPLAY -- Show Additional Unit
    ' Indicates whether additional units should be shown in addition to the map data units.
    <GlobalizedProperty(CategoryId:="CoordinateDisplayCategory"), _
    TypeConverter(GetType(MapUnitCls)), _
    ReadOnlyAttribute(False)> _
    Public Property ShowAdditionalUnits() As String
        Get
            'If it's not set to anything and the map units are not lat/long, default to lat/long.
            If modMain.ProjInfo.ShowStatusBarCoords_Alternate = "(None)" And Not modMain.ProjInfo.m_MapUnits = "" And Not modMain.ProjInfo.m_MapUnits = "Lat/Long" Then
                modMain.ProjInfo.ShowStatusBarCoords_Alternate = "Lat/Long"
            End If
            Return modMain.ProjInfo.ShowStatusBarCoords_Alternate
        End Get
        Set(ByVal Value As String)
            modMain.ProjInfo.ShowStatusBarCoords_Alternate = Value
        End Set
    End Property

    ' COORDINATE DISPLAY -- Status Bar Decimals (Standard)
    ' Number of digits to round on standard coordinates.
    <GlobalizedProperty(CategoryId:="CoordinateDisplayCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property StatusCoordsRounding() As Integer
        Get
            Return modMain.ProjInfo.StatusBarCoordsNumDecimals
        End Get
        Set(ByVal value As Integer)
            modMain.ProjInfo.StatusBarCoordsNumDecimals = value
        End Set
    End Property

    ' COORDINATE DISPLAY -- Status Bar Decimals (Additional)
    ' Number of digits to round on alternate coordinates.
    <GlobalizedProperty(CategoryId:="CoordinateDisplayCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property StatusAlternateCoordsRounding() As Integer
        Get
            Return modMain.ProjInfo.StatusBarAlternateCoordsNumDecimals
        End Get
        Set(ByVal value As Integer)
            modMain.ProjInfo.StatusBarAlternateCoordsNumDecimals = value
        End Set
    End Property

    ' COORDINATE DISPLAY -- Status Bar Comma Separators (Standard)
    ' Display commas in coordinates?
    <GlobalizedProperty(CategoryId:="CoordinateDisplayCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property StatusCoordsCommas() As Boolean
        Get
            Return modMain.ProjInfo.StatusBarCoordsUseCommas
        End Get
        Set(ByVal value As Boolean)
            modMain.ProjInfo.StatusBarCoordsUseCommas = value
        End Set
    End Property

    ' COORDINATE DISPLAY -- Status Bar Comma Separators (Additional)
    ' Display commas in coordinates?
    <GlobalizedProperty(CategoryId:="CoordinateDisplayCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property StatusAlternateCoordsCommas() As Boolean
        Get
            Return modMain.ProjInfo.StatusBarAlternateCoordsUseCommas
        End Get
        Set(ByVal value As Boolean)
            modMain.ProjInfo.StatusBarAlternateCoordsUseCommas = value
        End Set
    End Property

    ' COORDINATE DISPLAY -- Map Data Units
    ' Sets the unit that the map data is assumed to be in.
    <GlobalizedProperty(CategoryId:="CoordinateDisplayCategory"), _
    TypeConverter(GetType(MapUnitCls)), _
    ReadOnlyAttribute(False)> _
    Public Property DataUnits() As String
        Get
            If (modMain.frmMain.Project.MapUnits = "") Then
                Return "(None)"
            Else
                Return modMain.frmMain.Project.MapUnits
            End If
        End Get
        Set(ByVal Value As String)
            If (Value = "(None)") Then
                modMain.frmMain.Project.MapUnits = ""
            Else
                modMain.frmMain.Project.MapUnits = Value
            End If
            frmMain.SetModified(True)
        End Set
    End Property

    ' tws 05/11/2007
    ' PROJECT BEHAVIOR -- Save Shape-level Settings
    ' Sets whether any shape-level formatting should be saved in the project file/shape properties file.
    <GlobalizedProperty(CategoryId:="ProjectBehaviorCategory"), _
    ReadOnlyAttribute(False)> _
    Public Property SaveShapeSettings() As Boolean
        Get
            Return modMain.ProjInfo.SaveShapeSettings
        End Get
        Set(ByVal Value As Boolean)
            If Value <> modMain.ProjInfo.SaveShapeSettings Then
                modMain.ProjInfo.SaveShapeSettings = Value
                frmMain.SetModified(True)
            End If
        End Set
    End Property

    <GlobalizedProperty(CategoryId:="ProjectBehaviorCategory"), _
    ReadOnlyAttribute(True)> _
    Public Property MwConfigFileName() As String
        Get
            Return modMain.ProjInfo.ConfigFileName
        End Get
        Set(ByVal value As String)
            modMain.ProjInfo.ConfigFileName = value
        End Set
    End Property

#End Region

#Region "Update Projection Selection"

    Private Sub UpdateProjectionSelection()
        If m_enableSpecifyProjection = True And ("" = m_Name Or "" = m_MainCategory Or "" = m_SubCategory) Then
            ' Can't do anything now
            Return
        Else
            If m_enableSpecifyProjection And Name = "Custom Projection" Then
                'Do nothing here either -- wait for the dialog
                'to be presented elsewhere.
            ElseIf m_enableSpecifyProjection Then
                ProjInfo.ProjectProjection = projections.FindProjectionByCatAndName(m_MainCategory, m_SubCategory, m_Name)
            End If

            frmMain.SetModified(True)
        End If
    End Sub

#End Region

#Region "Projection Classes"

    'Projection main category (used for selecting projections)
    Public Class MainCategoryCls
        Inherits StringConverter
        Private projections As New clsProjections
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function

        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Dim list As New ArrayList
            For i As Integer = 0 To projections.ProjectionList.Count - 1
                If Not list.Contains(projections.ProjectionList.Item(i).MainCateg) Then
                    list.Add(projections.ProjectionList.Item(i).MainCateg)
                End If
            Next

            list.Sort()

            list.Add("Custom Projection")
            Return New StandardValuesCollection(list)

        End Function

        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            Return False
        End Function

    End Class

    'Projection subcategory (used for selecting projections)
    Public Class SubCategoryCls
        Inherits StringConverter
        Private projections As New clsProjections
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function

        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Dim list As New ArrayList
            For i As Integer = 0 To projections.ProjectionList.Count - 1
                If projections.ProjectionList.Item(i).MainCateg.ToLower() = PrjSetGrid.m_CurrentMain.ToLower() Then
                    If Not list.Contains(projections.ProjectionList.Item(i).Category) Then
                        list.Add(projections.ProjectionList.Item(i).Category)
                    End If
                End If
            Next

            list.Sort()

            Return New StandardValuesCollection(list)

        End Function

        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            Return False
        End Function

    End Class

    'Projection Name (used for selecting projections)
    Public Class NameCls
        Inherits StringConverter
        Private projections As New clsProjections

        'support combo box style select
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function

        'generate the list for selection
        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Dim list As New ArrayList
            For i As Integer = 0 To projections.ProjectionList.Count - 1
                If projections.ProjectionList.Item(i).MainCateg.ToLower() = PrjSetGrid.m_CurrentMain.ToLower() And projections.ProjectionList.Item(i).Category.ToLower() = m_CurrentSub.ToLower() Then
                    If Not list.Contains(projections.ProjectionList.Item(i).Name) Then
                        list.Add(projections.ProjectionList.Item(i).Name)
                    End If
                End If
            Next

            list.Sort()

            Return New StandardValuesCollection(list)

        End Function

        'do not need the values exclusive to each other
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            Return False
        End Function

    End Class

#End Region

#Region "Map Unit Class"

    'List of Map Data Units
    Public Class MapUnitCls
        Inherits StringConverter

        'support combo box style select
        Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function

        'generate the list for selection
        Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
            Dim list As New ArrayList

            list.Add("Lat/Long")
            list.Add("Meters")
            list.Add("Centimeters")
            list.Add("Feet")
            list.Add("Inches")
            list.Add("Kilometers")
            list.Add("Miles")
            list.Add("Millimeters")
            list.Add("Yards")
            list.Add("NauticalMiles") '08/28/2008

            Return New StandardValuesCollection(list)

        End Function

        'do not need the values exclusive to each other
        Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
            Return False
        End Function
    End Class
#End Region

End Class
