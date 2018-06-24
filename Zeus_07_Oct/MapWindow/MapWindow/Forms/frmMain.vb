'********************************************************************************************************
'File Name: frmMain.vb
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
'1/15/2005 - Streamline work to speed up loading. Created sub main entry point in modMain. (dpa)
'1/31/2005 - Total overhaul to remove DotNetBar component. (dpa)
'2/2/2005  - Clarified comments and inserted questions(jlk)
'3/16/2005 - Overhaul to add menus at run time based on a key using the same function plugins use. (dpa)
'3/23/2005 - fixed Recent Projects menu (mgray)
'6/30/2005 - cdm - Fixed recent projects menu to be able to handle a project stored in a path whose name has a space
'6/30/2005 - cdm - We now allow a plug-in to specify that it belongs in a submenu of the plugins menu via the syntax "Subcategory::Plugin Name" as the plugin name string.
'7/11/2005 - cdm - added custom window title option support
'8/20/2005 - cdm - Sort the plugins menu
'8/29/2005 - Lailin Chen - Fixed the annoying bug that prevents you from using the form designer
'8/30/2005 - Lailin Chen - Implemented the zoom drop down menu.
'9/07/2005 - Lailin Chen - Implemented the default mwZoom function.
'10/13/2005 - Paul Meems - Starting again with transferring all strings to the resourcefiles.
'9/07/2005 - Lailin Chen - Get the "Zoom to layer" and "Remove Layer" right click menu back.
'2/7/2006 - cdm - Implemented the measuring tool contributed by Jack MacDonald. Extended it
'                 to consider map units & projection, and extended it to do a mapinfo-style
'                 cumulative measure. Measuring tool now on toolbar next to select.
'6/1/2006 - Christopher Michaelis (cdm) - Massive overhaul for a new GUI. Changed lots and lots of stuff.
'6/12/2006 - cdm - Added fully dockable tool panels and menus.
'7/20/2006 - cdm - Added 'Check for Updates' functionality using
'                  the UpdateCheck tool provided by Aqua TERRA Consultants.
'7/31/2006 - Paul Meems (pm) - Translated some new strings to Dutch
'4/26/2007 - Tom Shanley (tws) - Enhanced doSaveGeoreferenced() to support hi-res exports
'6/01/2007 - Tom Shanley (tws) - show hourglass during save project - whcih can take a while now if you save shape-level formatting
'1/28/2008 - Jiri Kadlec (jk) - Changed the declaration of ResourceManager to access strings in the 
'                               new separate resource file GlobalResources.resx
'3/10/2008 - Dan Ames (dpa) - mnuOpen now also can be used to open a single layer (as well as a project)
'                           to support novice users who run the program and can't find the "Add Layer" button
'                           but instead try to open their layer with the "open" button or menu.
'3/18/2008 - jk - corrected area and distance measurement for shapefiles with lat/long coordinates
'4/05/2008 - Earljon Hidalgo - Fixed a bug when Right-clicking Properties context menu with a blank layer in DoEditProperties() function
'5/05/2008 - jk - changed the default location of MapWindowDock.config to "Application data" special folder.
'8/28/2008 - jk - fixed area and distance measurement when using alternate units - use a new conversion method
'10/1/2008 - Earljon Hidalgo (ejh) - Added icons for MapWindow UI including context menus. Icons provided by famfamfam.
'10/4/2008 - ejh - Enhancement: Added dynamic icon menu loading based on the state of plugin (enabled, disabled and/or belongs to a submenu
'********************************************************************************************************
Option Compare Text         'So that in text comparisons, ".mwprj" and ".MWPRJ" are equivalent
Imports MapWindow.Interfaces
Imports System.Threading


Friend Class MapWindowForm
    'We can't call this class frmMain because the instance of the form that we use throughout is "frmMain"
    Inherits System.Windows.Forms.Form
    Implements Interfaces.IMapWin

#Region "Declarations"
    Friend dckPanel As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend previewPanel As clsMWDockPanel
    Friend legendPanel As clsMWDockPanel
    Friend mapPanel As clsMWDockPanel

    Friend m_FloatingScalebar_Enabled As Boolean = False
    Private m_FloatingScalebar_PictureBox As PictureBox = Nothing
    Friend m_FloatingScalebar_ContextMenu_SelectedPosition As String = "LowerRight"
    Friend m_FloatingScalebar_ContextMenu_SelectedUnit As String = ""
    Friend m_FloatingScalebar_ContextMenu_ForeColor As System.Drawing.Color = System.Drawing.Color.Black
    Friend m_FloatingScalebar_ContextMenu_BackColor As System.Drawing.Color = System.Drawing.Color.White
    Friend WithEvents m_FloatingScalebar_ContextMenu As ContextMenu
    Friend WithEvents m_FloatingScalebar_ContextMenu_UL As Windows.Forms.MenuItem
    Friend WithEvents m_FloatingScalebar_ContextMenu_UR As Windows.Forms.MenuItem
    Friend WithEvents m_FloatingScalebar_ContextMenu_LL As Windows.Forms.MenuItem
    Friend WithEvents m_FloatingScalebar_ContextMenu_LR As Windows.Forms.MenuItem
    Friend WithEvents m_FloatingScalebar_ContextMenu_FC As Windows.Forms.MenuItem
    Friend WithEvents m_FloatingScalebar_ContextMenu_BC As Windows.Forms.MenuItem
    Friend WithEvents m_FloatingScalebar_ContextMenu_CU As Windows.Forms.MenuItem

    Friend Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Int32) As Integer
    Declare Function GetWindowDC Lib "user32" (ByVal hwnd As Integer) As Integer
    Declare Function GetDeviceCaps Lib "gdi32" (ByVal hDC As Integer, ByVal nIndex As Integer) As Integer

    Friend Const vbLeftButton As Integer = 1 'Microsoft.VisualBasic.Compatibility.VB6.MouseButtonConstants.LeftButton
    Friend Const vbRightButton As Integer = 2 'Microsoft.VisualBasic.Compatibility.VB6.MouseButtonConstants.RightButton
    Friend Const vbMiddleButton As Integer = 4 'Microsoft.VisualBasic.Compatibility.VB6.MouseButtonConstants.MiddleButton

    Friend m_ComboBoxes As New Hashtable        'Stores combo boxes that were dynamically added as controls to the toolbar area.

    Public m_PointImageSchemes As New Hashtable
    Public m_FillStippleSchemes As New Hashtable
    Friend m_UserInteraction As New clsUserInteraction
    Friend m_Project As MapWindow.Project
    Friend m_layers As MapWindow.Layers
    Friend m_View As MapWindow.View
    Friend m_UIPanel As New MapWindow.clsUIPanel
    Friend m_Reports As MapWindow.Reports
    Friend m_Menu As MapWindow.Menus
    Friend m_PreviewMapContextMenuStrip As New ContextMenuStrip
    Friend m_HasBeenSaved As Boolean
    Friend m_PreviewMap As MapWindow.PreviewMap
    Friend m_Toolbar As MapWindow.Toolbar
    Friend m_PluginManager As PluginTracker
    Friend m_StatusBar As MapWindow.StatusBar
    Friend m_GroupHandle As Integer 'used for legend events
    Friend m_Extents As ArrayList
    Friend m_CurrentExtent As Integer
    Friend m_IsManualExtentsChange As Boolean
    Friend g_ViewBackColor As Integer
    Friend g_ColorPalettes As Xml.XmlElement
    Friend g_PreviewMapProp As BarsProperties
    Friend g_LegendProp As BarsProperties
    Friend m_Labels As LabelClass
    Friend m_AutoVis As DynamicVisibilityClass = New DynamicVisibilityClass()
    Friend WithEvents m_legendEditor As LegendEditorForm
    Friend m_LoadingProject As Boolean
    Friend m_HandleFileDrop As Boolean = True

    Private Const RecentProjectPrefix As String = "mnuRecentProjects_"
    Private Const BookmarkedViewPrefix As String = "mnuBookmarkedView_"

    Private m_startX, m_startY As Integer
    Private oldX, oldY As Integer

    Friend CustomWindowTitle As String = ""
    Friend Title_ShowFullProjectPath As Boolean = False

    'Jiri Kadlec 1/31/2008
    Private resources As System.Resources.ResourceManager = _
        New System.Resources.ResourceManager("MapWindow.GlobalResource", System.Reflection.Assembly.GetExecutingAssembly())
    'Private resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MapWindowForm))
    Private MeasureCursor As Cursor = Nothing

    Private MapToolTipObject As New ToolTip
    Private WithEvents MapToolTipTimer As New System.Windows.Forms.Timer
    Private MapToolTipsLastMoveTime As DateTime = Now
    Private m_MapToolTipsAtLeastOneLayer As Boolean = False
    Public Property MapTooltipsAtLeastOneLayer() As Boolean
        Get
            Return m_MapToolTipsAtLeastOneLayer
        End Get
        Set(ByVal value As Boolean)
            m_MapToolTipsAtLeastOneLayer = value
            MapToolTipTimer.Enabled = value
            If value Then
                MapToolTipTimer.Start()
            Else
                MapToolTipTimer.Stop()
            End If
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        InitializeMapsAndLegends()

        MapToolTipTimer.Interval = 1000
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents StripDocker As ToolStripContainer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuLegend As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTableEditorLaunch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuBreak1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuBreak2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuLabelSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuRelabel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tlbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents ilsToolbar As System.Windows.Forms.ImageList
    Friend WithEvents tbbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbPan As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbZoom As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuZoom As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuZoomPrevious As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomPreviewMap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomNext As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomMax As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomSelected As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomShape As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbbSelect As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbBreak1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbbAddRemove As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tbbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbBreak2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbbBreak3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayerButton As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MapPreview As AxMapWinGIS.AxMap
    Friend WithEvents Legend As LegendControl.Legend
    Friend WithEvents MapMain As AxMapWinGIS.AxMap
    Friend WithEvents mnuBtnAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBtnRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBtnClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents tmrMenuTips As System.Windows.Forms.Timer
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tbbMeasure As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbbMeasureArea As System.Windows.Forms.ToolStripButton
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MapWindowForm))
        Me.StripDocker = New System.Windows.Forms.ToolStripContainer
        Me.panel1 = New System.Windows.Forms.Panel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tlbMain = New System.Windows.Forms.ToolStrip
        Me.ilsToolbar = New System.Windows.Forms.ImageList(Me.components)
        Me.tbbNew = New System.Windows.Forms.ToolStripButton
        Me.tbbOpen = New System.Windows.Forms.ToolStripButton
        Me.tbbSave = New System.Windows.Forms.ToolStripButton
        Me.tbbBreak1 = New System.Windows.Forms.ToolStripSeparator
        Me.tbbPrint = New System.Windows.Forms.ToolStripButton
        Me.tbbAddRemove = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuLayerButton = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuBtnAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBtnRemove = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBtnClear = New System.Windows.Forms.ToolStripMenuItem
        Me.tbbBreak2 = New System.Windows.Forms.ToolStripSeparator
        Me.tbbPan = New System.Windows.Forms.ToolStripButton
        Me.tbbSelect = New System.Windows.Forms.ToolStripButton
        Me.tbbMeasure = New System.Windows.Forms.ToolStripButton
        Me.tbbMeasureArea = New System.Windows.Forms.ToolStripButton
        Me.tbbZoomIn = New System.Windows.Forms.ToolStripButton
        Me.tbbZoomOut = New System.Windows.Forms.ToolStripButton
        Me.tbbZoom = New System.Windows.Forms.ToolStripDropDownButton
        Me.mnuZoom = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuZoomPrevious = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuZoomNext = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem30 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuZoomPreviewMap = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuZoomMax = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuZoomLayer = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuZoomSelected = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuZoomShape = New System.Windows.Forms.ToolStripMenuItem
        Me.tbbBreak3 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuLegend = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuBreak1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTableEditorLaunch = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuLabelSetup = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuRelabel = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuBreak2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel
        Me.MapPreview = New AxMapWinGIS.AxMap
        Me.MapMain = New AxMapWinGIS.AxMap
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrMenuTips = New System.Windows.Forms.Timer(Me.components)
        Me.StripDocker.ContentPanel.SuspendLayout()
        Me.StripDocker.TopToolStripPanel.SuspendLayout()
        Me.StripDocker.SuspendLayout()
        Me.tlbMain.SuspendLayout()
        Me.mnuLayerButton.SuspendLayout()
        Me.mnuZoom.SuspendLayout()
        Me.mnuLegend.SuspendLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StripDocker
        '
        '
        'StripDocker.ContentPanel
        '
        Me.StripDocker.ContentPanel.Controls.Add(Me.panel1)
        resources.ApplyResources(Me.StripDocker.ContentPanel, "StripDocker.ContentPanel")
        resources.ApplyResources(Me.StripDocker, "StripDocker")
        Me.StripDocker.Name = "StripDocker"
        '
        'StripDocker.TopToolStripPanel
        '
        Me.StripDocker.TopToolStripPanel.Controls.Add(Me.tlbMain)
        Me.StripDocker.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
        '
        'panel1
        '
        resources.ApplyResources(Me.panel1, "panel1")
        Me.panel1.Name = "panel1"
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'tlbMain
        '
        resources.ApplyResources(Me.tlbMain, "tlbMain")
        Me.tlbMain.ImageList = Me.ilsToolbar
        Me.tlbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbbNew, Me.tbbOpen, Me.tbbSave, Me.tbbBreak1, Me.tbbPrint, Me.tbbAddRemove, Me.tbbBreak2, Me.tbbPan, Me.tbbSelect, Me.tbbMeasure, Me.tbbMeasureArea, Me.tbbZoomIn, Me.tbbZoomOut, Me.tbbZoom, Me.tbbBreak3})
        Me.tlbMain.Name = "tlbMain"
        '
        'ilsToolbar
        '
        Me.ilsToolbar.ImageStream = CType(resources.GetObject("ilsToolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilsToolbar.TransparentColor = System.Drawing.Color.Transparent
        Me.ilsToolbar.Images.SetKeyName(0, "")
        Me.ilsToolbar.Images.SetKeyName(1, "")
        Me.ilsToolbar.Images.SetKeyName(2, "")
        Me.ilsToolbar.Images.SetKeyName(3, "")
        Me.ilsToolbar.Images.SetKeyName(4, "")
        Me.ilsToolbar.Images.SetKeyName(5, "")
        Me.ilsToolbar.Images.SetKeyName(6, "")
        Me.ilsToolbar.Images.SetKeyName(7, "")
        Me.ilsToolbar.Images.SetKeyName(8, "")
        Me.ilsToolbar.Images.SetKeyName(9, "")
        Me.ilsToolbar.Images.SetKeyName(10, "")
        Me.ilsToolbar.Images.SetKeyName(11, "")
        Me.ilsToolbar.Images.SetKeyName(12, "")
        Me.ilsToolbar.Images.SetKeyName(13, "")
        Me.ilsToolbar.Images.SetKeyName(14, "")
        Me.ilsToolbar.Images.SetKeyName(15, "")
        Me.ilsToolbar.Images.SetKeyName(16, "")
        Me.ilsToolbar.Images.SetKeyName(17, "")
        Me.ilsToolbar.Images.SetKeyName(18, "")
        Me.ilsToolbar.Images.SetKeyName(19, "")
        Me.ilsToolbar.Images.SetKeyName(20, "")
        Me.ilsToolbar.Images.SetKeyName(21, "")
        Me.ilsToolbar.Images.SetKeyName(22, "")
        Me.ilsToolbar.Images.SetKeyName(23, "")
        '
        'tbbNew
        '
        Me.tbbNew.Image = Global.MapWindow.GlobalResource.imgNew
        Me.tbbNew.Name = "tbbNew"
        resources.ApplyResources(Me.tbbNew, "tbbNew")
        '
        'tbbOpen
        '
        Me.tbbOpen.Image = Global.MapWindow.GlobalResource.imgFolder
        Me.tbbOpen.Name = "tbbOpen"
        resources.ApplyResources(Me.tbbOpen, "tbbOpen")
        '
        'tbbSave
        '
        Me.tbbSave.Image = Global.MapWindow.GlobalResource.imgSave
        Me.tbbSave.Name = "tbbSave"
        resources.ApplyResources(Me.tbbSave, "tbbSave")
        '
        'tbbBreak1
        '
        Me.tbbBreak1.Name = "tbbBreak1"
        resources.ApplyResources(Me.tbbBreak1, "tbbBreak1")
        '
        'tbbPrint
        '
        Me.tbbPrint.Image = Global.MapWindow.GlobalResource.imgPrinter
        Me.tbbPrint.Name = "tbbPrint"
        resources.ApplyResources(Me.tbbPrint, "tbbPrint")
        '
        'tbbAddRemove
        '
        Me.tbbAddRemove.DropDown = Me.mnuLayerButton
        Me.tbbAddRemove.Image = Global.MapWindow.GlobalResource.mnuLayerAdd
        Me.tbbAddRemove.Name = "tbbAddRemove"
        resources.ApplyResources(Me.tbbAddRemove, "tbbAddRemove")
        '
        'mnuLayerButton
        '
        Me.mnuLayerButton.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBtnAdd, Me.mnuBtnRemove, Me.mnuBtnClear})
        Me.mnuLayerButton.Name = "mnuLayerButton"
        Me.mnuLayerButton.OwnerItem = Me.tbbAddRemove
        resources.ApplyResources(Me.mnuLayerButton, "mnuLayerButton")
        '
        'mnuBtnAdd
        '
        Me.mnuBtnAdd.Checked = True
        Me.mnuBtnAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuBtnAdd.Image = Global.MapWindow.GlobalResource.mnuLayerAdd
        Me.mnuBtnAdd.Name = "mnuBtnAdd"
        resources.ApplyResources(Me.mnuBtnAdd, "mnuBtnAdd")
        '
        'mnuBtnRemove
        '
        Me.mnuBtnRemove.Image = Global.MapWindow.GlobalResource.mnuLayerRemove
        Me.mnuBtnRemove.Name = "mnuBtnRemove"
        resources.ApplyResources(Me.mnuBtnRemove, "mnuBtnRemove")
        '
        'mnuBtnClear
        '
        Me.mnuBtnClear.Image = Global.MapWindow.GlobalResource.mnuLayerClear
        Me.mnuBtnClear.Name = "mnuBtnClear"
        resources.ApplyResources(Me.mnuBtnClear, "mnuBtnClear")
        '
        'tbbBreak2
        '
        Me.tbbBreak2.Name = "tbbBreak2"
        resources.ApplyResources(Me.tbbBreak2, "tbbBreak2")
        '
        'tbbPan
        '
        resources.ApplyResources(Me.tbbPan, "tbbPan")
        Me.tbbPan.Name = "tbbPan"
        '
        'tbbSelect
        '
        resources.ApplyResources(Me.tbbSelect, "tbbSelect")
        Me.tbbSelect.Name = "tbbSelect"
        '
        'tbbMeasure
        '
        Me.tbbMeasure.Name = "tbbMeasure"
        resources.ApplyResources(Me.tbbMeasure, "tbbMeasure")
        '
        'tbbMeasureArea
        '
        Me.tbbMeasureArea.Name = "tbbMeasureArea"
        resources.ApplyResources(Me.tbbMeasureArea, "tbbMeasureArea")
        '
        'tbbZoomIn
        '
        resources.ApplyResources(Me.tbbZoomIn, "tbbZoomIn")
        Me.tbbZoomIn.Name = "tbbZoomIn"
        '
        'tbbZoomOut
        '
        resources.ApplyResources(Me.tbbZoomOut, "tbbZoomOut")
        Me.tbbZoomOut.Name = "tbbZoomOut"
        '
        'tbbZoom
        '
        Me.tbbZoom.DropDown = Me.mnuZoom
        resources.ApplyResources(Me.tbbZoom, "tbbZoom")
        Me.tbbZoom.Name = "tbbZoom"
        '
        'mnuZoom
        '
        Me.mnuZoom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuZoomPrevious, Me.mnuZoomNext, Me.ToolStripMenuItem30, Me.mnuZoomPreviewMap, Me.mnuZoomMax, Me.mnuZoomLayer, Me.mnuZoomSelected, Me.mnuZoomShape})
        Me.mnuZoom.Name = "mnuZoom"
        Me.mnuZoom.OwnerItem = Me.tbbZoom
        resources.ApplyResources(Me.mnuZoom, "mnuZoom")
        '
        'mnuZoomPrevious
        '
        Me.mnuZoomPrevious.Name = "mnuZoomPrevious"
        resources.ApplyResources(Me.mnuZoomPrevious, "mnuZoomPrevious")
        '
        'mnuZoomNext
        '
        Me.mnuZoomNext.Name = "mnuZoomNext"
        resources.ApplyResources(Me.mnuZoomNext, "mnuZoomNext")
        '
        'ToolStripMenuItem30
        '
        Me.ToolStripMenuItem30.Name = "ToolStripMenuItem30"
        resources.ApplyResources(Me.ToolStripMenuItem30, "ToolStripMenuItem30")
        '
        'mnuZoomPreviewMap
        '
        resources.ApplyResources(Me.mnuZoomPreviewMap, "mnuZoomPreviewMap")
        Me.mnuZoomPreviewMap.Name = "mnuZoomPreviewMap"
        '
        'mnuZoomMax
        '
        Me.mnuZoomMax.Name = "mnuZoomMax"
        resources.ApplyResources(Me.mnuZoomMax, "mnuZoomMax")
        '
        'mnuZoomLayer
        '
        Me.mnuZoomLayer.Checked = True
        Me.mnuZoomLayer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuZoomLayer.Name = "mnuZoomLayer"
        resources.ApplyResources(Me.mnuZoomLayer, "mnuZoomLayer")
        '
        'mnuZoomSelected
        '
        Me.mnuZoomSelected.Name = "mnuZoomSelected"
        resources.ApplyResources(Me.mnuZoomSelected, "mnuZoomSelected")
        '
        'mnuZoomShape
        '
        Me.mnuZoomShape.Name = "mnuZoomShape"
        resources.ApplyResources(Me.mnuZoomShape, "mnuZoomShape")
        '
        'tbbBreak3
        '
        Me.tbbBreak3.Name = "tbbBreak3"
        resources.ApplyResources(Me.tbbBreak3, "tbbBreak3")
        '
        'mnuLegend
        '
        Me.mnuLegend.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuBreak1, Me.ToolStripMenuItem8, Me.mnuTableEditorLaunch, Me.ToolStripMenuLabelSetup, Me.ToolStripMenuRelabel, Me.ToolStripMenuItem9, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12, Me.ToolStripMenuItem13, Me.ToolStripMenuItem14, Me.ToolStripMenuBreak2, Me.ToolStripMenuItem16})
        Me.mnuLegend.Name = "mnuLegend"
        resources.ApplyResources(Me.mnuLegend, "mnuLegend")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.MapWindow.GlobalResource.imgGroupAdd
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.MapWindow.GlobalResource.imgLayerAdd
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = Global.MapWindow.GlobalResource.imgLayerRemove
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = Global.MapWindow.GlobalResource.imgLayerClear
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Image = Global.MapWindow.GlobalResource.imgZoomToLayer
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        '
        'ToolStripMenuBreak1
        '
        Me.ToolStripMenuBreak1.Name = "ToolStripMenuBreak1"
        resources.ApplyResources(Me.ToolStripMenuBreak1, "ToolStripMenuBreak1")
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Image = Global.MapWindow.GlobalResource.imgMetadata
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        '
        'mnuTableEditorLaunch
        '
        Me.mnuTableEditorLaunch.Image = Global.MapWindow.GlobalResource.imgTableEditor
        Me.mnuTableEditorLaunch.Name = "mnuTableEditorLaunch"
        resources.ApplyResources(Me.mnuTableEditorLaunch, "mnuTableEditorLaunch")
        '
        'ToolStripMenuLabelSetup
        '
        Me.ToolStripMenuLabelSetup.Image = Global.MapWindow.GlobalResource.imgLabel
        Me.ToolStripMenuLabelSetup.Name = "ToolStripMenuLabelSetup"
        resources.ApplyResources(Me.ToolStripMenuLabelSetup, "ToolStripMenuLabelSetup")
        '
        'ToolStripMenuRelabel
        '
        Me.ToolStripMenuRelabel.Image = Global.MapWindow.GlobalResource.imgRelabel
        Me.ToolStripMenuRelabel.Name = "ToolStripMenuRelabel"
        resources.ApplyResources(Me.ToolStripMenuRelabel, "ToolStripMenuRelabel")
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        resources.ApplyResources(Me.ToolStripMenuItem9, "ToolStripMenuItem9")
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        resources.ApplyResources(Me.ToolStripMenuItem11, "ToolStripMenuItem11")
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Image = Global.MapWindow.GlobalResource.imgExpandAll
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        resources.ApplyResources(Me.ToolStripMenuItem12, "ToolStripMenuItem12")
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        resources.ApplyResources(Me.ToolStripMenuItem13, "ToolStripMenuItem13")
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Image = Global.MapWindow.GlobalResource.imgCollapseAll
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        resources.ApplyResources(Me.ToolStripMenuItem14, "ToolStripMenuItem14")
        '
        'ToolStripMenuBreak2
        '
        Me.ToolStripMenuBreak2.Name = "ToolStripMenuBreak2"
        resources.ApplyResources(Me.ToolStripMenuBreak2, "ToolStripMenuBreak2")
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Image = Global.MapWindow.GlobalResource.imgProperties
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        resources.ApplyResources(Me.ToolStripMenuItem16, "ToolStripMenuItem16")
        '
        'ProgressBar1
        '
        resources.ApplyResources(Me.ProgressBar1, "ProgressBar1")
        Me.ProgressBar1.Name = "ProgressBar1"
        '
        'StatusBar1
        '
        resources.ApplyResources(Me.StatusBar1, "StatusBar1")
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3})
        Me.StatusBar1.ShowPanels = True
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        resources.ApplyResources(Me.StatusBarPanel1, "StatusBarPanel1")
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        resources.ApplyResources(Me.StatusBarPanel2, "StatusBarPanel2")
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        resources.ApplyResources(Me.StatusBarPanel3, "StatusBarPanel3")
        '
        'MapPreview
        '
        resources.ApplyResources(Me.MapPreview, "MapPreview")
        Me.MapPreview.Name = "MapPreview"
        Me.MapPreview.OcxState = CType(resources.GetObject("MapPreview.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'MapMain
        '
        resources.ApplyResources(Me.MapMain, "MapMain")
        Me.MapMain.Name = "MapMain"
        Me.MapMain.OcxState = CType(resources.GetObject("MapMain.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'tmrMenuTips
        '
        Me.tmrMenuTips.Interval = 1000
        '
        'MapWindowForm
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.StripDocker)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.KeyPreview = True
        Me.Name = "MapWindowForm"
        Me.StripDocker.ContentPanel.ResumeLayout(False)
        Me.StripDocker.TopToolStripPanel.ResumeLayout(False)
        Me.StripDocker.TopToolStripPanel.PerformLayout()
        Me.StripDocker.ResumeLayout(False)
        Me.StripDocker.PerformLayout()
        Me.tlbMain.ResumeLayout(False)
        Me.tlbMain.PerformLayout()
        Me.mnuLayerButton.ResumeLayout(False)
        Me.mnuZoom.ResumeLayout(False)
        Me.mnuLegend.ResumeLayout(False)
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Public Properties"
    Public ReadOnly Property UserInteraction() As UserInteraction Implements Interfaces.IMapWin.UserInteraction
        Get
            Return m_UserInteraction
        End Get
    End Property

    Public Sub ClearCustomWindowTitle() Implements Interfaces.IMapWin.ClearCustomWindowTitle
        CustomWindowTitle = ""
    End Sub

    Public ReadOnly Property GetOCX() As Object Implements Interfaces.IMapWin.GetOCX
        Get
            Return MapMain
        End Get
    End Property

    Public WriteOnly Property DisplayFullProjectPath() As Boolean Implements Interfaces.IMapWin.DisplayFullProjectPath
        Set(ByVal Value As Boolean)
            Title_ShowFullProjectPath = Value
            SetModified(False) 'Force rewrite of title
        End Set
    End Property

    Public Sub SetCustomWindowTitle(ByVal NewTitleText As String) Implements Interfaces.IMapWin.SetCustomWindowTitle
        CustomWindowTitle = NewTitleText
        SetModified(False) 'Force rewrite of title
    End Sub

    Public ReadOnly Property LastError() As String Implements Interfaces.IMapWin.LastError
        Get
            Dim tStr As String

            If g_error Is Nothing Then Return ""

            tStr = tStr.Copy(g_error)
            g_error = ""
            Return tStr
        End Get
    End Property

    Public ReadOnly Property Layers() As Interfaces.Layers Implements Interfaces.IMapWin.Layers
        Get
            Return m_layers
        End Get
    End Property

    Public ReadOnly Property View() As Interfaces.View Implements Interfaces.IMapWin.View
        Get
            Return m_View
        End Get
    End Property

    Public ReadOnly Property Menus() As Interfaces.Menus Implements Interfaces.IMapWin.Menus
        Get
            Return m_Menu
        End Get
    End Property

    Public ReadOnly Property Plugins() As Interfaces.Plugins Implements Interfaces.IMapWin.Plugins
        Get
            Return m_PluginManager.oldInt
        End Get
    End Property

    Public ReadOnly Property PreviewMap() As Interfaces.PreviewMap Implements Interfaces.IMapWin.PreviewMap
        Get
            Return m_PreviewMap
        End Get
    End Property

    Public ReadOnly Property StatusBar() As Interfaces.StatusBar Implements Interfaces.IMapWin.StatusBar
        Get
            Return m_StatusBar
        End Get
    End Property

    Public ReadOnly Property Toolbar() As Interfaces.Toolbar Implements Interfaces.IMapWin.Toolbar
        Get
            Return m_Toolbar
        End Get
    End Property

    Public ReadOnly Property Reports() As MapWindow.Interfaces.Reports Implements MapWindow.Interfaces.IMapWin.Reports
        Get
            Return m_Reports
        End Get
    End Property

    Public ReadOnly Property UIPanel() As MapWindow.Interfaces.UIPanel Implements MapWindow.Interfaces.IMapWin.UIPanel
        Get
            Return m_UIPanel
        End Get
    End Property

    Public ReadOnly Property Project() As MapWindow.Interfaces.Project Implements MapWindow.Interfaces.IMapWin.Project
        Get
            Return m_Project
        End Get
    End Property

#End Region

#Region "MapWindowForm Events"
    Private Function HandleShortcutKeys(ByVal e As Keys) As Boolean
        'Chris Michaelis - May 2006. See BugZilla 124.

        'The following is the only reliable way to detect control AND other keys
        'using ProcessCmdKey.
        Dim keycodes As New Hashtable
        Dim keystates As New Hashtable
        keycodes.Add("control", &H11)
        keycodes.Add("shift", &H10)
        keycodes.Add("ks", &H53)
        keycodes.Add("ko", &H4F)
        keycodes.Add("kc", &H43)
        keycodes.Add("kp", &H50)
        keycodes.Add("ki", &H49)
        keycodes.Add("kh", &H48)
        keycodes.Add("kprint", &H2A)
        keycodes.Add("kf4", &H73)
        keycodes.Add("khome", &H24)
        keycodes.Add("kinsert", &H2D)
        keycodes.Add("kdelete", &H2E)
        keycodes.Add("kpageup", &H21)
        keycodes.Add("kpagedown", &H22)
        keycodes.Add("kleftarrow", &H25)
        keycodes.Add("kuparrow", &H26)
        keycodes.Add("krightarrow", &H27)
        keycodes.Add("kdownarrow", &H28)
        keycodes.Add("kplus", &HBB)
        keycodes.Add("kminus", &HBD)
        keycodes.Add("kspacebar", &H20)
        keycodes.Add("kenter", &HD)
        keycodes.Add("bs", &H8)


        Dim i As IEnumerator = keycodes.GetEnumerator()
        While i.MoveNext
            If CBool(GetAsyncKeyState(i.Current.value)) = True Then keystates.Add(i.Current.key, True)
        End While

        Dim o As Object = Nothing
        If Not o Is Nothing Then
            'awkward
        ElseIf o IsNot Nothing Then

        End If

        If keystates.Contains("ks") AndAlso keystates.Contains("control") Then
            DoSave()
            Return True
        ElseIf keystates.Contains("bs") Then
            DoZoomPrevious()
        ElseIf keystates.Contains("kp") AndAlso keystates.Contains("shift") AndAlso keystates.Contains("control") Then
            HandleButtonClick("tbbPan")
        ElseIf keystates.Contains("ko") AndAlso keystates.Contains("shift") AndAlso keystates.Contains("control") Then
            HandleButtonClick("tbbZoomOut")
        ElseIf keystates.Contains("ki") AndAlso keystates.Contains("shift") AndAlso keystates.Contains("control") Then
            HandleButtonClick("tbbZoomIn")
        ElseIf keystates.Contains("ki") AndAlso keystates.Contains("control") Then
            HandleButtonClick("Identify")
        ElseIf keystates.Contains("kh") AndAlso keystates.Contains("control") Then
            HandleButtonClick("tbbSelect")
        ElseIf keystates.Contains("kenter") And keystates.Contains("control") Then
            If Not Legend.SelectedLayer = -1 Then
                If m_legendEditor Is Nothing Then
                    m_legendEditor = LegendEditorForm.CreateAndShowLYR()
                Else
                    m_legendEditor.LoadProperties(Handle, True)
                End If
            End If
        ElseIf keystates.Contains("kspacebar") And keystates.Contains("control") Then
            Legend.Layers.ItemByHandle(Legend.SelectedLayer).Visible = Not Legend.Layers.ItemByHandle(Legend.SelectedLayer).Visible
        ElseIf keystates.Contains("kuparrow") And keystates.Contains("control") Then
            Dim ar As New ArrayList()
            For z As Integer = 0 To Legend.Groups.Count - 1
                For zz As Integer = 0 To Legend.Groups(z).LayerCount - 1
                    ar.Add(Legend.Groups(z).Item(zz).Handle)
                Next
            Next

            For z As Integer = 0 To ar.Count - 1
                If Legend.SelectedLayer = ar(z) And z + 1 < ar.Count Then
                    Legend.SelectedLayer = ar(z + 1)
                    Exit For
                End If
            Next
        ElseIf keystates.Contains("kdownarrow") And keystates.Contains("control") Then
            'Legend selection shift
            Dim ar As New ArrayList()
            For z As Integer = 0 To Legend.Groups.Count - 1
                For zz As Integer = 0 To Legend.Groups(z).LayerCount - 1
                    ar.Add(Legend.Groups(z).Item(zz).Handle)
                Next
            Next

            For z As Integer = 0 To ar.Count - 1
                If Legend.SelectedLayer = ar(z) And z - 1 > -1 Then
                    Legend.SelectedLayer = ar(z - 1)
                    Exit For
                End If
            Next

        ElseIf keystates.Contains("ko") AndAlso keystates.Contains("control") Then
            DoOpen()
            Return True
        ElseIf keystates.Contains("kc") AndAlso keystates.Contains("control") Then
            doCopyMap()
            Return True
        ElseIf keystates.Contains("kp") AndAlso keystates.Contains("control") Then
            DoPrint()
            Return True
        ElseIf keystates.Contains("kprint") Then
            DoPrint()
            Return True
        ElseIf keystates.Contains("kf4") AndAlso keystates.Contains("control") Then
            doClose()
            Return True
        ElseIf keystates.Contains("khome") AndAlso keystates.Contains("control") Then
            If Not Legend Is Nothing Then
                If Legend.SelectedLayer <> -1 Then
                    DoZoomToLayer()
                End If
            End If
            Return True
        ElseIf keystates.Contains("kdelete") Then
            If Not Legend Is Nothing Then
                If Legend.SelectedLayer <> -1 Then
                    '7/31/2006 PM
                    'If mapwinutility.logger.msg("Are you sure you wish to remove the currently selected layer?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Remove Current Layer?") = MsgBoxResult.Yes Then
                    If MapWinUtility.Logger.Msg(resources.GetString("msgHandleShortcutKeys.Text"), MsgBoxStyle.YesNo + MsgBoxStyle.Question, AppInfo.Name) = MsgBoxResult.Yes Then
                        DoRemoveLayer()
                    End If
                End If
            End If
            Return True
        ElseIf keystates.Contains("kinsert") Then
            DoAddLayer()
            Return True
        ElseIf keystates.Contains("khome") Then
            doZoomToFullExtents()
            Return True
        ElseIf keystates.Contains("kpageup") Then
            'Pan up slightly - 50% of view
            Dim exts As MapWinGIS.Extents = MapMain.Extents
            If Not exts.xMin = 0 And Not exts.xMax = 0 And Not exts.yMin = 0 And Not exts.yMax = 0 Then
                Dim ydiff As Double = (exts.yMax - exts.yMin) / 2
                exts.SetBounds(exts.xMin, exts.yMin + ydiff, exts.zMin, exts.xMax, exts.yMax + ydiff, exts.zMax)
                MapMain.Extents = exts
            End If
            Return True
        ElseIf keystates.Contains("kpagedown") Then
            'Pan down slightly - 50% of view
            Dim exts As MapWinGIS.Extents = MapMain.Extents
            If Not exts.xMin = 0 And Not exts.xMax = 0 And Not exts.yMin = 0 And Not exts.yMax = 0 Then
                Dim ydiff As Double = (exts.yMax - exts.yMin) / 2
                exts.SetBounds(exts.xMin, exts.yMin - ydiff, exts.zMin, exts.xMax, exts.yMax - ydiff, exts.zMax)
                MapMain.Extents = exts
            End If
            Return True
        ElseIf keystates.Contains("kuparrow") And MapMain.Focused Then
            'Pan up slightly - 25% of view
            Dim exts As MapWinGIS.Extents = MapMain.Extents
            If Not exts.xMin = 0 And Not exts.xMax = 0 And Not exts.yMin = 0 And Not exts.yMax = 0 Then
                Dim ydiff As Double = (exts.yMax - exts.yMin) / 4
                exts.SetBounds(exts.xMin, exts.yMin + ydiff, exts.zMin, exts.xMax, exts.yMax + ydiff, exts.zMax)
                MapMain.Extents = exts
            End If
            Return True
        ElseIf keystates.Contains("kdownarrow") And MapMain.Focused Then
            'Pan down slightly - 25% of view
            Dim exts As MapWinGIS.Extents = MapMain.Extents
            If Not exts.xMin = 0 And Not exts.xMax = 0 And Not exts.yMin = 0 And Not exts.yMax = 0 Then
                Dim ydiff As Double = (exts.yMax - exts.yMin) / 4
                exts.SetBounds(exts.xMin, exts.yMin - ydiff, exts.zMin, exts.xMax, exts.yMax - ydiff, exts.zMax)
                MapMain.Extents = exts
            End If
            Return True
        ElseIf keystates.Contains("kleftarrow") And MapMain.Focused Then
            'Pan Left slightly - 25% of view
            Dim exts As MapWinGIS.Extents = MapMain.Extents
            If Not exts.xMin = 0 And Not exts.xMax = 0 And Not exts.yMin = 0 And Not exts.yMax = 0 Then
                Dim xdiff As Double = (exts.xMax - exts.xMin) / 4
                exts.SetBounds(exts.xMin - xdiff, exts.yMin, exts.zMin, exts.xMax - xdiff, exts.yMax, exts.zMax)
                MapMain.Extents = exts
            End If
            Return True
        ElseIf keystates.Contains("krightarrow") And MapMain.Focused Then
            'Pan Right slightly - 25% of view
            Dim exts As MapWinGIS.Extents = MapMain.Extents
            If Not exts.xMin = 0 And Not exts.xMax = 0 And Not exts.yMin = 0 And Not exts.yMax = 0 Then
                Dim xdiff As Double = (exts.xMax - exts.xMin) / 4
                exts.SetBounds(exts.xMin + xdiff, exts.yMin, exts.zMin, exts.xMax + xdiff, exts.yMax, exts.zMax)
                MapMain.Extents = exts
            End If
            Return True
        ElseIf keystates.Contains("kplus") Then
            'Zoom in by 25%
            MapMain.ZoomIn(0.25)
            Return True
        ElseIf keystates.Contains("kminus") Then
            'Zoom out by 25%
            MapMain.ZoomOut(0.25)
            Return True
        End If

        Return False
    End Function

    Private Function BuildDockContent(ByVal persistString As String) As WeifenLuo.WinFormsUI.Docking.IDockContent
        Select Case persistString
            Case "mwDockPanel_Legend"
                Return CreateLegendPanel()
            Case "mwDockPanel_Preview Map"
                Return CreatePreviewPanel()
            Case "mwDockPanel_Map View"
                Return CreateMapPanel()
            Case "MapWindow.LegendEditorForm"
                Return Nothing 'We won't be able to recreate it at this point.
            Case Else
                Return Nothing
        End Select
        Return Nothing
    End Function


    Private Sub MapWindowForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        MapMain.Focus()
    End Sub

    Private Sub MapWindowForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'For i As Integer = 0 To Application.OpenForms.Count
        '    If Application.OpenForms(i).Modal Then
        '        Application.OpenForms(i).Close()
        '    End If
        'Next
    End Sub
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    If m.Msg = 41251 Then
    '        Application.Exit()
    '    Else
    '        MyBase.WndProc(m)
    '    End If
    'End Sub

    Private Sub MapWindowForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeVars()
        ' mover a segundo monitor
        If Screen.AllScreens.Length > 1 Then
            Me.Location = New Point(Screen.AllScreens(1).Bounds.Left, Location.Y)
        End If
    End Sub

    'Overriding ProcessCmdKey is needed to get the arrow keys;
    'it seems to catch other keys better than KeyDown as well.
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        'Check to ensure we're focused before doing things to the map (Bugzilla 366)
        If MapMain.Focused() OrElse StripDocker.Focused OrElse MapPreview.Focused OrElse Legend.Focused Then
            'If the message was WM_KEYDOWN...
            If msg.Msg = &H100 Then
                'Try to handle it. If I don't care about the particular key, pass it
                'on to someone who does
                If Not HandleShortcutKeys(keyData) Then
                    MyBase.ProcessCmdKey(msg, keyData)
                End If
            Else
                'Perhaps someone else cares about this message?
                MyBase.ProcessCmdKey(msg, keyData)
            End If
        End If
    End Function

    Private Sub MapWindowForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

    End Sub

    Private Sub MapWindowForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Not m_StatusBar Is Nothing Then m_StatusBar.ResizeProgressBar()

        UpdateFloatingScalebar()
    End Sub

    Private Sub MapWindowForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ProjInfo.SaveConfig()

        'If Not m_HasBeenSaved Or ProjInfo.Modified Then
        '    If PromptToSaveProject() = MsgBoxResult.Cancel Then
        '        e.Cancel = True
        '        Me.DialogResult = DialogResult.Cancel
        '        Exit Sub
        '    End If
        'End If

        If Not m_legendEditor Is Nothing Then m_legendEditor.Close()

        g_SyncPluginMenuDefer = True
        m_PluginManager.UnloadAll() ' cleans up plugins on shutdown
        m_PluginManager.UnloadApplicationPlugins()
        Me.DialogResult = DialogResult.OK
        'm_PluginManager.WriteSettingsFile()
    End Sub

#End Region

#Region "Legend Events"

    Private Sub Legend_GroupExpandedChanged(ByVal Handle As Integer, ByVal Expanded As Boolean) Handles Legend.GroupExpandedChanged
        SetModified(True)
    End Sub

    'Chris Michaelis 11/11/2006, see http://bugs.mapwindow.org/show_bug.cgi?id=340
    ' 10/17/2007 - SaveShapeLayerProps == misnomer - can also be used for saving grid coloring scheme.
    ' Can't change name now without breaking interface
    Friend Function SaveShapeLayerProps(ByVal handle As Integer, Optional ByVal filename As String = "") As Boolean
        If Layers(handle).LayerType = eLayerType.LineShapefile Or Legend.Layers.ItemByHandle(handle).Type = eLayerType.PointShapefile Or Legend.Layers.ItemByHandle(handle).Type = eLayerType.PolygonShapefile Then
            Dim doc As New Xml.XmlDocument
            Dim outfn As String = filename
            Dim node As Xml.XmlNode = doc.CreateElement("SFRendering")
            ProjInfo.AddLayerElement(doc, Layers(handle), node)
            doc.AppendChild(node)
            Try
                If outfn = "" Then outfn = System.IO.Path.ChangeExtension(CType(MapMain.get_GetObject(handle), MapWinGIS.Shapefile).Filename, ".mwsr")
                doc.Save(outfn)
            Catch e As Exception
                Dim errmsg As String = e.ToString() 'Default to exception text
                Try
                    If System.IO.File.Exists(outfn) Then
                        Dim fi As New System.IO.FileInfo(outfn)
                        'Note -- parenthesis in line below are critical (will always return true without)
                        If (fi.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                            errmsg = "File is read-only: " + outfn
                        End If
                    ElseIf System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outfn)) Then
                        Dim fi As New System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(outfn))
                        'Note -- parenthesis in line below are critical (will always return true without)
                        If (fi.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                            errmsg = "Directory is read-only: " + System.IO.Path.GetDirectoryName(outfn)
                        End If
                    End If
                Catch
                End Try
                MapWinUtility.Logger.Dbg("Unable to save shapefile properties (mwsr file): " + errmsg)
                'Likely no need to worry; almost always is an access denied message for one reason or another.
            End Try
            Return True
        ElseIf Layers(handle).LayerType = eLayerType.Grid Then
            ' SaveShapeLayerProps == misnomer - can also be used for saving grid coloring scheme.
            ' Can't change name now without breaking interface
            Try
                Dim outfn As String = filename
                If outfn = "" Then outfn = System.IO.Path.ChangeExtension(Layers(handle).FileName, ".mwsr")
                ColoringSchemeTools.ExportScheme(Layers(handle), outfn)
            Catch
            End Try
        End If

        Return False
    End Function

    'Chris Michaelis 11/11/2006, see http://bugs.mapwindow.org/show_bug.cgi?id=340
    Friend Function LoadShapeLayerProps(ByVal handle As Integer, Optional ByVal filename As String = "", Optional ByVal PluginCall As Boolean = False) As Boolean
        If Layers(handle).LayerType = eLayerType.LineShapefile Or Legend.Layers.ItemByHandle(handle).Type = eLayerType.PointShapefile Or Legend.Layers.ItemByHandle(handle).Type = eLayerType.PolygonShapefile Then
            If filename = "" Then
                If System.IO.File.Exists(System.IO.Path.ChangeExtension(CType(MapMain.get_GetObject(handle), MapWinGIS.Shapefile).Filename, ".mwsr")) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(System.IO.Path.ChangeExtension(CType(MapMain.get_GetObject(handle), MapWinGIS.Shapefile).Filename, ".mwsr"))
                    If Not doc.GetElementsByTagName("SFRendering").Count = 0 AndAlso Not doc.GetElementsByTagName("SFRendering")(0).ChildNodes.Count = 0 Then
                        ProjInfo.LoadLayerProperties(doc.GetElementsByTagName("SFRendering")(0).ChildNodes(0), handle, PluginCall)
                        SetModified(True)
                        Return True
                    End If
                End If
            Else
                If System.IO.File.Exists(filename) Then
                    Dim doc As New Xml.XmlDocument
                    doc.Load(filename)
                    If Not doc.GetElementsByTagName("SFRendering").Count = 0 AndAlso Not doc.GetElementsByTagName("SFRendering")(0).ChildNodes.Count = 0 Then
                        ProjInfo.LoadLayerProperties(doc.GetElementsByTagName("SFRendering")(0).ChildNodes(0), handle, PluginCall)
                        SetModified(True)
                        Return True
                    End If
                End If
            End If
        ElseIf Layers(handle).LayerType = eLayerType.Grid Then
            ' SaveShapeLayerProps == misnomer - can also be used for saving grid coloring scheme.
            ' Can't change name now without breaking interface
            If filename = "" Then
                If System.IO.File.Exists(System.IO.Path.ChangeExtension(Layers(handle).FileName, ".mwsr")) Then
                    filename = System.IO.Path.ChangeExtension(Layers(handle).FileName, ".mwsr")
                Else
                    'May be too early for grid filename to be set
                    Try
                        If Not frmMain.MapMain.get_GetObject(handle) Is Nothing Then
                            filename = System.IO.Path.ChangeExtension(CType(frmMain.MapMain.get_GetObject(handle), MapWinGIS.ImageClass).Filename, ".mwsr")
                        End If
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine(ex.ToString())
                    End Try
                End If
            End If
            If System.IO.File.Exists(filename) Then Layers(handle).ColoringScheme = ColoringSchemeTools.ImportScheme(Layers(handle), filename)
        End If

        Return False
    End Function

    Private Sub Legend_GroupMouseDown(ByVal Handle As Integer, ByVal button As System.Windows.Forms.MouseButtons) Handles Legend.GroupMouseDown
        'Display the context menu for the legend - based on a click on a group.
        '4/24/2005 - dpa - Fixed location display of the menu 
        Dim newPt As System.Drawing.Point
        If m_PluginManager.LegendMouseDown(Handle, button, Interfaces.ClickLocation.Group) = False Then
            If button = MouseButtons.Right Then
                m_GroupHandle = Handle
                mnuLegend.Items(2).Enabled = True
                'Corrected the error of missing "Remove layer" --- Lailin Chen 10/21/2005
                'mnuLegend.Items(12).Visible = True
                newPt.X = Legend.PointToClient(Legend.MousePosition).X
                newPt.Y = Legend.PointToClient(Legend.MousePosition).Y
                mnuLegend.Show(frmMain, newPt)

                mnuLegend.Items(2).Visible = True
                If Legend.Groups.ItemByHandle(m_GroupHandle).LayerCount > 0 Then
                    mnuLegend.Items(4).Enabled = True
                Else
                    mnuLegend.Items(4).Enabled = False
                    mnuLegend.Items(5).Enabled = False
                End If
                mnuLegend.Items(2).Text = resources.GetString("mnuRemoveGroup.Text")
                mnuLegend.Items(4).Text = resources.GetString("mnuZoomToGroup.Text")

                newPt.X = Legend.PointToClient(Legend.MousePosition).X
                newPt.Y = Legend.PointToClient(Legend.MousePosition).Y

                'Note the duplicate calls to .Show (one above higher) -- seems to be required, especially when undocked
                mnuLegend.Show(Legend, newPt)
            End If
        End If
    End Sub

    Private Sub Legend_GroupDoubleClick(ByVal Handle As Integer) Handles Legend.GroupDoubleClick
        'First see if the plug-ins want this event.  
        'If not then show the legend editor.
        If m_PluginManager.LegendDoubleClick(Handle, Interfaces.ClickLocation.Group) = False Then
            If m_legendEditor Is Nothing Then
                'Make this dockable. 11/27/2006 CDM
                m_legendEditor = LegendEditorForm.CreateAndShowGRP(Handle)
                'm_legendEditor = New LegendEditorForm(Handle, False, Me.MapMain)
                'Me.AddOwnedForm(m_legendEditor)
                'm_legendEditor.Show()
            Else
                m_legendEditor.LoadProperties(Handle, False)
            End If
        End If
    End Sub

    Private Sub Legend_LegendClick(ByVal button As System.Windows.Forms.MouseButtons, ByVal Location As System.Drawing.Point) Handles Legend.LegendClick
        'Display the context menu for the legend.
        '4/24/2005 - dpa - Fixed location display of the menu 
        'Dim Pt As System.Drawing.Point
        Dim newPt As System.Drawing.Point
        If m_PluginManager.LegendMouseDown(-1, button, Interfaces.ClickLocation.None) = False Then
            If button = MouseButtons.Right Then
                m_GroupHandle = -1
                'Pt = MapWinUtility.MiscUtils.GetCursorLocation()
                'newPt.X = CType((Pt.X - Me.Left + 5), Integer)
                'newPt.Y = CType((Pt.Y - Me.Top - 40), Integer)
                newPt.X = Legend.PointToClient(Legend.MousePosition).X
                newPt.Y = Legend.PointToClient(Legend.MousePosition).Y
                mnuLegend.Show(frmMain, newPt)
                mnuLegend.Items(2).Enabled = False
                mnuLegend.Items(4).Enabled = False
                mnuLegend.Items(5).Enabled = False
                mnuLegend.Items(12).Visible = False
                'Note the duplicate calls to .Show (one above higher) -- seems to be required, especially when undocked
                mnuLegend.Show(Legend, newPt)
            End If
        End If
    End Sub

    Private Sub Legend_LayerSelected(ByVal Handle As Integer) Handles Legend.LayerSelected
        Try
            Dim lastMode As MapWinGIS.tkCursorMode = MapMain.CursorMode

            m_View.ClearSelectedShapes()
            m_layers.CurrentLayer = Handle

            If Not m_legendEditor Is Nothing Then
                If Handle < 0 Then
                    m_legendEditor.Close()
                    m_legendEditor = Nothing
                    Exit Sub
                End If
                m_legendEditor.LoadProperties(Handle, True)
            End If
            m_PluginManager.LayerSelected(Handle)

            'Hide the attribute table menu item if the plugin is not available.
            If Not Plugins Is Nothing AndAlso Not frmMain.m_PluginManager.m_ApplicationPlugins Is Nothing Then
                mnuTableEditorLaunch.Visible = (frmMain.m_PluginManager.m_ApplicationPlugins.Contains("mwTableEditor_mwTableEditorClass"))
            End If

            'Prevent any plug-ins from changing current map cursor mode on this event:
            MapMain.CursorMode = lastMode
            UpdateZoomButtons()
        Catch
        End Try
    End Sub

    Private Sub Legend_GroupMouseUp(ByVal Handle As Integer, ByVal button As System.Windows.Forms.MouseButtons) Handles Legend.GroupMouseUp
        'This one only gets passed to the plugins
        m_PluginManager.LegendMouseUp(Handle, CInt(IIf(button = MouseButtons.Left, vbLeftButton, vbRightButton)), Interfaces.ClickLocation.Group)
    End Sub

    Private Sub Legend_LayerMouseDown(ByVal Handle As Integer, ByVal button As System.Windows.Forms.MouseButtons) Handles Legend.LayerMouseDown
        'Display the context menu for the legend on a right click on a layer.
        '4/24/2005 - dpa - Fixed location display of the menu 
        Dim Pt As New System.Drawing.Point, newPT As New System.Drawing.Point

        Legend.SelectedLayer = Handle
        'first see if the plugins are going to handle it.
        If m_PluginManager.LegendMouseDown(Handle, button, Interfaces.ClickLocation.Layer) = False Then
            If button = MouseButtons.Right Then
                m_GroupHandle = -1
                mnuLegend.Items(2).Enabled = True
                'Pt = MapWinUtility.MiscUtils.GetCursorLocation()
                'newPT.X = CType((Pt.X - Me.Left + 5), Integer)
                'newPT.Y = CType((Pt.Y - Me.Top - 40), Integer)
                newPT.X = Legend.PointToClient(Legend.MousePosition).X
                newPT.Y = Legend.PointToClient(Legend.MousePosition).Y
                mnuLegend.Show(frmMain, newPT)
                'Note the duplicate calls to .Show -- seems to be required, especially when undocked

                ' 4/05/2008 Earljon Hidalgo - display first the items before renaming the Text
                mnuLegend.Items(2).Visible = True
                mnuLegend.Items(4).Enabled = True

                ' 4/4/2008 jk - make sure "Remove Layer" and "Zoom to Layer" is displayed correctly
                mnuLegend.Items(2).Text = resources.GetString("mnuRemoveLayer.Text")
                mnuLegend.Items(4).Text = resources.GetString("mnuZoomToLayer.Text")

                mnuLegend.Show(Legend, newPT)
            End If
        End If
    End Sub
    Private Sub DoAddGroup()
        Legend.Groups.Add()
        SetModified(True)
    End Sub
    Private Sub DoRemoveGroup()
        If Legend.Groups.IsValidHandle(m_GroupHandle) Then
            Dim groupName As String = Legend.Groups.ItemByHandle(m_GroupHandle).Text
            If Legend.Groups.ItemByHandle(m_GroupHandle).LayerCount > 0 Then
                '10/12/2005 PM
                'If mapwinutility.logger.msg("Are you sure you want to remove the" & vbCrLf & "selected group and its layer(s)?", MsgBoxStyle.YesNo, "Remove Group?") = MsgBoxResult.Yes Then
                If MapWinUtility.Logger.Msg(resources.GetString("msgRemoveGroup.Text"), MsgBoxStyle.YesNo, resources.GetString("titleRemoveGroup.Text")) = MsgBoxResult.Yes Then
                    Legend.Groups.Remove(m_GroupHandle)
                    SetModified(True)
                End If
            Else
                Legend.Groups.Remove(m_GroupHandle)
                SetModified(True)
            End If
            '---Cho 12/31/2008: Let plugins know that a group was removed.
            frmMain.Plugins.BroadcastMessage("GroupRemoved Name=" + groupName)
        End If
    End Sub
    Private Sub DoZoomToLayer()
        MapMain.ZoomToLayer(Legend.SelectedLayer)
        SetModified(True)
    End Sub
    Private Sub DoZoomToGroup()
        Dim maxX As Double, maxY As Double
        Dim minX As Double, minY As Double
        Dim dx As Double, dy As Double
        Dim i As Integer, tExts As MapWinGIS.Extents
        Dim bFoundVisibleLayer As Boolean

        If Legend.Groups.IsValidHandle(m_GroupHandle) = False Then Exit Sub
        bFoundVisibleLayer = False
        Dim LayersInGroup As New ArrayList
        For i = 0 To Legend.Groups.ItemByHandle(m_GroupHandle).LayerCount - 1
            LayersInGroup.Add(Legend.Groups.ItemByHandle(m_GroupHandle)(i).Handle)
        Next
        For Each i In LayersInGroup
            If MapMain.get_LayerVisible(i) = True Then
                tExts = Layers(i).Extents
                With tExts
                    If bFoundVisibleLayer = False Then
                        maxX = .xMax
                        minX = .xMin
                        maxY = .yMax
                        minY = .yMin
                        bFoundVisibleLayer = True
                    Else
                        If .xMax > maxX Then maxX = .xMax
                        If .yMax > maxY Then maxY = .yMax
                        If .xMin < minX Then minX = .xMin
                        If .yMin < minY Then minY = .yMin
                    End If
                End With
            End If
        Next i
        ' Pad extents now
        dx = maxX - minX
        dx = dx * MapMain.ExtentPad
        maxX = maxX + dx
        minX = minX - dx
        dy = maxY - minY
        dy = dy * MapMain.ExtentPad
        maxY = maxY + dy
        minY = minY - dy
        tExts = New MapWinGIS.Extents
        tExts.SetBounds(minX, minY, 0, maxX, maxY, 0)
        MapMain.Extents = tExts
        tExts = Nothing
        SetModified(True)

    End Sub
    Private Sub DoViewMetaData()
        Dim MetaDataFiles() As String = MapWinUtility.DataManagement.GetMetaDataFiles(Layers(Layers.CurrentLayer).FileName)
        If MetaDataFiles Is Nothing OrElse MetaDataFiles(0) Is Nothing Then
            MsgBox("No metadata is available. It can be created using the Open Metadata Manager, or may be available from the original data source.", MsgBoxStyle.Information, "No Metadata Available")
            Exit Sub
        Else
            System.Diagnostics.Process.Start(MetaDataFiles(0))
        End If

        'March 2008 - Should this launch the Metadata Editor plug-in Allen wrote?
    End Sub
    Private Sub DoExpandGroups()
        Legend.Groups.ExpandAll()
        SetModified(True)
    End Sub
    Private Sub DoExpandAll()
        Legend.Lock()
        Legend.Groups.ExpandAll()
        Legend.Layers.ExpandAll()
        Legend.Unlock()
        SetModified(True)
    End Sub
    Private Sub DoCollapseGroups()
        Legend.Groups.CollapseAll()
        SetModified(True)
    End Sub
    Private Sub DoCollapseAll()
        Legend.Lock()
        Legend.Groups.CollapseAll()
        Legend.Layers.CollapseAll()
        Legend.Unlock()
        SetModified(True)
    End Sub
    Private Sub DoEditProperties()
        If m_legendEditor Is Nothing Then
            If Legend.Groups.IsValidHandle(m_GroupHandle) Then
                'm_legendEditor = New LegendEditorForm(m_GroupHandle, False, Me.MapMain)
                m_legendEditor = LegendEditorForm.CreateAndShowGRP(m_GroupHandle)
            Else
                ' 04/05/2008 by Earljon Hidalgo - Handles a bug when right clicking context menu Properties
                ' Need to check first if there's any layer has been added.
                If Legend.Layers.Count = 0 Then Exit Sub
                'm_legendEditor = New LegendEditorForm(Legend.SelectedLayer, True, Me.MapMain)
                m_legendEditor = LegendEditorForm.CreateAndShowLYR()
            End If
            'Me.AddOwnedForm(m_legendEditor)
            'm_legendEditor.Show()
        Else
            If Legend.Groups.IsValidHandle(m_GroupHandle) Then
                m_legendEditor.LoadProperties(m_GroupHandle, False)
            Else
                m_legendEditor.LoadProperties(Legend.SelectedLayer, True)
            End If
        End If
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        DoAddGroup()
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        DoAddLayer()
    End Sub
    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Dim menuText As String
        menuText = ToolStripMenuItem4.Text

        If ToolStripMenuItem4.Text = resources.GetString("mnuRemoveGroup.Text") Then
            DoRemoveGroup()
        Else
            DoRemoveLayer()
        End If
    End Sub
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        DoClearLayers()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Dim menuText As String
        menuText = resources.GetString("mnuZoomToLayer.Text")

        If menuText = resources.GetString("mnuZoomToLayer.Text") Then
            DoZoomToLayer()
        Else
            DoZoomToGroup()
        End If

        'Notify plugins - since this is done after handing it locally,
        'they can't override it -- but they do notice it.
        m_PluginManager.ItemClicked(menuText)
    End Sub
    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        DoViewMetaData()
    End Sub
    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        DoExpandGroups()
    End Sub
    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        DoExpandAll()
    End Sub
    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        DoCollapseGroups()
    End Sub
    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        DoCollapseAll()
    End Sub
    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        DoEditProperties()
    End Sub

    Private Sub mnuTableEditorLaunch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTableEditorLaunch.Click
        Plugins.BroadcastMessage("TableEditorStart")
    End Sub

    Private Sub Legend_LayerMouseUp(ByVal Handle As Integer, ByVal button As System.Windows.Forms.MouseButtons) Handles Legend.LayerMouseUp
        m_PluginManager.LegendMouseUp(Handle, CInt(IIf(button = MouseButtons.Left, vbLeftButton, vbRightButton)), Interfaces.ClickLocation.Layer)
    End Sub

    Private Sub Legend_GroupPositionChanged(ByVal Handle As Integer) Handles Legend.GroupPositionChanged
        'All we do here is mark a modification for later saving.
        SetModified(True)
    End Sub

    Private Sub Legend_LayerDoubleClick(ByVal Handle As Integer) Handles Legend.LayerDoubleClick
        'If the plug-ins don't want this event then we handle it by showing layer properties.
        If m_PluginManager.LegendDoubleClick(Handle, Interfaces.ClickLocation.Layer) = False Then
            If frmMain.m_layers(Handle).LayerType <> Interfaces.eLayerType.Invalid Then
                If m_legendEditor Is Nothing Then
                    m_legendEditor = LegendEditorForm.CreateAndShowLYR()
                    'Make this dockable. 11/27/2006 CDM
                    'm_legendEditor.Show()
                Else
                    m_legendEditor.LoadProperties(Handle, True)
                End If

            Else
                '10/13/2005 PM
                'mapwinutility.logger.msg("No properties available for this layer type.", , "Error")
                MapWinUtility.Logger.Msg(resources.GetString("msgLegendLayerDoubleClick.Text"), resources.GetString("msgError.Text"))
            End If
        End If
    End Sub

    Private Sub Legend_LayerPositionChanged(ByVal Handle As Integer) Handles Legend.LayerPositionChanged
        SetModified(True)
    End Sub

    Private Sub Legend_LayerVisibleChanged(ByVal Handle As Integer, ByVal NewState As Boolean, ByRef Cancel As Boolean) Handles Legend.LayerVisibleChanged
        '12/13/2008 ARA modified to use new application setting as well as to cancel layer change when coming out of dynamic visibility in order to ensure proper functionality
        Dim SendMsgOverload As Boolean = False
        If Not m_AutoVis(Handle) Is Nothing Then
            If m_AutoVis(Handle).UseDynamicExtents = True Then
                Cancel = True 'Always cancel for layer display when exiting dynamic visibility

                If AppInfo.ShowDynamicVisibilityWarnings Then
                    Dim DynVisMsg As String
                    If AppInfo.ShowLayerAfterDynamicVisibility Then
                        DynVisMsg = resources.GetString("DisableDynamicVis.Text")
                    Else
                        DynVisMsg = resources.GetString("DisableDynamicVis2.Text")
                    End If
                    If MapWinUtility.Logger.Msg(DynVisMsg, MsgBoxStyle.YesNo Or MsgBoxStyle.Question, AppInfo.Name) = MsgBoxResult.Yes Then
                        m_layers(Handle).UseDynamicVisibility = False
                        m_layers(Handle).Visible = AppInfo.ShowLayerAfterDynamicVisibility
                        NewState = AppInfo.ShowLayerAfterDynamicVisibility
                        SendMsgOverload = True
                        SetModified(True)
                    End If
                Else
                    m_layers(Handle).UseDynamicVisibility = False
                    m_layers(Handle).Visible = AppInfo.ShowLayerAfterDynamicVisibility
                    NewState = AppInfo.ShowLayerAfterDynamicVisibility
                    SendMsgOverload = True
                    SetModified(True)
                End If
            End If
        Else
            SetModified(True)
        End If
        If SendMsgOverload Or Not Cancel Then frmMain.Plugins.BroadcastMessage("LayerVisibleChanged " + NewState.ToString() + " Handle=" + Handle.ToString())
    End Sub

    Private Sub m_legendEditor_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_legendEditor.Closed
        m_legendEditor = Nothing
    End Sub

    Private Sub Legend_LayerCheckboxClicked(ByVal Handle As Integer, ByVal NewState As Boolean) Handles Legend.LayerCheckboxClicked
        frmMain.Plugins.BroadcastMessage("LayerCheckboxClicked " + NewState.ToString() + " Handle=" + Handle.ToString())
    End Sub

    Public Sub RefreshDynamicVisibility1() Implements Interfaces.IMapWin.RefreshDynamicVisibility
        m_AutoVis.TestLayerZoomExtents()
    End Sub

#End Region

#Region "MapPreview Events"

    Private Sub MapPreview_MouseDownEvent(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_MouseDownEvent) Handles MapPreview.MouseDownEvent
        If e.button = vbRightButton Then
            'Note the duplicate calls -- seems to be required, especially when undocked
            m_PreviewMapContextMenuStrip.Show(frmMain, MapPreview.PointToClient(MapPreview.MousePosition))
            m_PreviewMapContextMenuStrip.Show(MapPreview, MapPreview.PointToClient(MapPreview.MousePosition))
        Else
            'Determine if the box will start dragging
            If InBox(m_PreviewMap.g_ExtentsRect, CDbl(e.x), CDbl(e.y)) Then
                m_PreviewMap.g_Dragging = True
                oldX = e.x
                oldY = e.y
                m_startX = e.x
                m_startY = e.y
            Else
                m_PreviewMap.g_Dragging = False
            End If
        End If
    End Sub

    Private Sub MapPreview_MouseUpEvent(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_MouseUpEvent) Handles MapPreview.MouseUpEvent
        'Stop Dragging
        Dim newExts As New MapWinGIS.Extents
        Dim xMin, xMax, yMin, yMax As Double

        If m_PreviewMap.g_Dragging Then
            MapPreview.PixelToProj(m_PreviewMap.g_ExtentsRect.Left, m_PreviewMap.g_ExtentsRect.Top, xMin, yMax)
            MapPreview.PixelToProj(m_PreviewMap.g_ExtentsRect.Right, m_PreviewMap.g_ExtentsRect.Bottom, xMax, yMin)
            With newExts
                newExts.SetBounds(xMin, yMin, 0, xMax, yMax, 0)
            End With
            ' set the cursor
            MapPreview.MapCursor = MapWinGIS.tkCursor.crsrSizeAll
            ' apply the extents
            MapMain.Extents = newExts
            newExts = Nothing
            MapMain.Focus()
        Else
            ' Probably clicked outside the box, center on that location.
            Dim curCenterX, curCenterY As Integer
            With m_PreviewMap.g_ExtentsRect
                curCenterX = CInt((.Right + .Left) / 2)
                curCenterY = CInt((.Bottom + .Top) / 2)
                .Offset(e.x - curCenterX, e.y - curCenterY)
            End With
            MapPreview.PixelToProj(m_PreviewMap.g_ExtentsRect.Left, m_PreviewMap.g_ExtentsRect.Top, xMin, yMax)
            MapPreview.PixelToProj(m_PreviewMap.g_ExtentsRect.Right, m_PreviewMap.g_ExtentsRect.Bottom, xMax, yMin)
            With newExts
                newExts.SetBounds(xMin, yMin, 0, xMax, yMax, 0)
            End With
            ' set the cursor
            MapPreview.MapCursor = MapWinGIS.tkCursor.crsrSizeAll
            ' apply the extents
            MapMain.Extents = newExts
            newExts = Nothing
            MapMain.Focus()
        End If
        m_PreviewMap.g_Dragging = False
    End Sub

    Private Sub MapPreview_MouseMoveEvent(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_MouseMoveEvent) Handles MapPreview.MouseMoveEvent
        'Move the Box
        If m_PreviewMap.g_Dragging = True AndAlso e.button = vbLeftButton Then
            m_PreviewMap.g_ExtentsRect.Offset(e.x - oldX, e.y - oldY)
            m_PreviewMap.DrawBox(m_PreviewMap.g_ExtentsRect)
            oldX = e.x
            oldY = e.y
        Else
            If e.button <> vbLeftButton Then m_PreviewMap.g_Dragging = False
            If InBox(m_PreviewMap.g_ExtentsRect, CDbl(e.x), CDbl(e.y)) Then
                MapPreview.MapCursor = MapWinGIS.tkCursor.crsrSizeAll
            Else
                MapPreview.MapCursor = MapWinGIS.tkCursor.crsrArrow
            End If
        End If
    End Sub

#End Region

#Region "MapMain Events"

    Private Sub MapMain_MouseUpEvent(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_MouseUpEvent) Handles MapMain.MouseUpEvent
        If tbbMeasure.Checked Then
            'Measure distance - right mouse button clicked
            If e.button = 2 Then
                'End the current chunk of segments being measured
                AppInfo.MeasuringStartX = 0
                AppInfo.MeasuringStartY = 0
                AppInfo.MeasuringScreenPointStart = Nothing
                AppInfo.MeasuringScreenPointFinish = Nothing
                AppInfo.MeasuringTotalDistance = 0
                AppInfo.MeasuringPreviousSegments.Clear()
                If (Not AppInfo.MeasuringDrawing = -1) Then
                    MapMain.ClearDrawing(AppInfo.MeasuringDrawing)
                    AppInfo.MeasuringDrawing = -1
                End If
                'modified hereunder by Fugro Geoid, Cornelius Mende, 2007
                StatusBar.Item(GetOrRemovePanel(resources.GetString("msgPanelDistance.Text"))).Text = resources.GetString("msgPanelDistance.Text")
                Exit Sub
            End If

            Dim a As Double
            Dim b As Double
            MapMain.PixelToProj(CDbl(e.x), CDbl(e.y), a, b)
            If AppInfo.MeasuringStartX = 0 And AppInfo.MeasuringStartY = 0 Then
                AppInfo.MeasuringStartX = a
                AppInfo.MeasuringStartY = b
                AppInfo.MeasuringScreenPointStart = New Point(e.x, e.y)
            Else
                'Add this segment to the list of priors
                AppInfo.MeasuringPreviousSegments.Add(AppInfo.MeasuringScreenPointStart.X)
                AppInfo.MeasuringPreviousSegments.Add(AppInfo.MeasuringScreenPointStart.Y)
                AppInfo.MeasuringPreviousSegments.Add(e.x)
                AppInfo.MeasuringPreviousSegments.Add(e.y)

                AppInfo.MeasuringTotalDistance += distance(AppInfo.MeasuringStartX, AppInfo.MeasuringStartY, a, b)

                Dim DataUnit As UnitOfMeasure    'the unit specified in Project Settings..Map Data Units
                Dim MeasureUnit As UnitOfMeasure 'the unit specified in Project Settings..Show Additional Unit
                DataUnit = MapWinGeoProc.UnitConverter.StringToUOM(modMain.frmMain.Project.MapUnits)
                MeasureUnit = DataUnit
                MeasureUnit = MapWinGeoProc.UnitConverter.StringToUOM(modMain.ProjInfo.ShowStatusBarCoords_Alternate)

                'if Map Data Units are DecimalDegrees, the distance() function returns the result in kilometers
                If DataUnit = UnitOfMeasure.DecimalDegrees Then DataUnit = UnitOfMeasure.Kilometers
                If MeasureUnit = UnitOfMeasure.DecimalDegrees Then MeasureUnit = DataUnit

                'convert the total distance from Map Data units to Alternate units
                Dim newDist As Double = AppInfo.MeasuringTotalDistance
                newDist = MapWinGeoProc.UnitConverter.ConvertLength(DataUnit, MeasureUnit, newDist)

                '3/18/2008 JK - internationalization - show distance the in status bar
                StatusBar.Item(GetOrRemovePanel(resources.GetString("msgPanelDistance.Text"))).Text = _
                    resources.GetString("msgPanelDistance.Text") & " " & formatDistance(newDist) & _
                    " " & MeasureUnit.ToString & " " & resources.GetString("msgClickNextPoint.Text")

                AppInfo.MeasuringStartX = a
                AppInfo.MeasuringStartY = b
                AppInfo.MeasuringScreenPointStart = New Point(e.x, e.y)
                AppInfo.MeasuringScreenPointFinish = Nothing
            End If
        ElseIf tbbMeasureArea.Checked Then
            'Handle area measurement (1/23/2009 added by JK)
            If AppInfo.AreaMeasuringlstDrawPoints.Count < 3 Then
                StatusBar.Item(GetOrRemovePanel(resources.GetString("msgPanelArea.Text"))).Text = _
                    resources.GetString("msgPanelArea.Text") + " " + _
                    resources.GetString("msgPanelAreaClick.Text")
            Else
                'To display the area, the user must click at least three points.
                Dim resultArea As String = AreaMeasuringCalculate()

                'Show area in the in status bar
                StatusBar.Item(GetOrRemovePanel(resources.GetString("msgPanelArea.Text"))).Text = _
                    resources.GetString("msgPanelArea.Text") + " " + resultArea + " " + _
                    resources.GetString("msgPanelAreaClick.Text")

                ' User clicked the right mouse button -- stop measuring area and display message
                If e.button = 2 Then
                    MapWinUtility.Logger.Msg(resources.GetString("msgAreaDrawnPolygon.Text") + resultArea)
                    AreaMeasuringStop()
                    'Start the next one, after having cleared settings from the previous
                    AreaMeasuringBegin()
                End If

            End If

        Else

            Dim tSI As MapWindow.SelectInfo
            Dim ctrlDown As Boolean

            If MapMain.NumLayers <> 0 Then
                If MapMain.CursorMode = MapWinGIS.tkCursorMode.cmPan Or MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn Or MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut Then
                    m_PreviewMap.UpdateLocatorBox()
                ElseIf (MapMain.CursorMode = MapWinGIS.tkCursorMode.cmSelection) And (e.button = vbLeftButton) Then
                    If m_PluginManager.MapMouseUp(e.button, e.shift, e.x, e.y) = False Then
                        'dpa 02/15/02
                        'Chris M 12/13/2006 for Bugzilla 378 -- change the "OrElse" in the statement below to "And".
                        If Layers(Legend.SelectedLayer).LayerType <> eLayerType.Image And Layers(Legend.SelectedLayer).LayerType <> eLayerType.Grid Then
                            If (e.shift = 2) Or (e.shift = 3) Then ctrlDown = True Else ctrlDown = False
                            tSI = m_View.SelectShapesByPoint(e.x, e.y, ctrlDown)

                            m_PluginManager.ShapesSelected(Legend.SelectedLayer, tSI)
                            UpdateZoomButtons()
                            'End If
                        End If
                    End If
                    Exit Sub
                End If
            End If

            m_PluginManager.MapMouseUp(e.button, e.shift, e.x, e.y)
        End If
    End Sub

    Private Sub MapMain_ExtentsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MapMain.ExtentsChanged
        If m_Extents Is Nothing Then Exit Sub
        If MapMain.NumLayers = 0 Then Exit Sub

        m_PreviewMap.UpdateLocatorBox()
        UpdateFloatingScalebar()

        If m_IsManualExtentsChange = True Then
            m_IsManualExtentsChange = False 'reset the flag for the next extents change
        Else
            FlushForwardHistory()
            m_Extents.Add(MapMain.Extents)
            m_CurrentExtent = m_Extents.Count - 1
        End If

        UpdateZoomButtons()

        'update label/layer info to see if labels/layers need to be visible or not
        m_Labels.TestLabelZoomExtents()
        m_AutoVis.TestLayerZoomExtents()

        m_PluginManager.MapExtentsChanged()

        'Commented this next line out because this function gets called when the project is loading, so the following line makes it so that you always have to deal with the "save project" dialog.
        'SetModified(True)
    End Sub

    Private Sub MapMain_FileDropped(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_FileDroppedEvent) Handles MapMain.FileDropped
        'Chris M Oct 24 2007 for Bugzilla #560
        'ATC Apr 15 2008 - if RunProjectCommandLine does not recognize file, try the plugins
        Dim lBroadcast As Boolean = False
        If m_HandleFileDrop Then
            'Chris M April 17 2006 for Bugzilla #123
            'Since the filename could now be a project file, grid, shapefile,
            'or even script -- just run it using the "RunProjectCommandLine" function,
            'which does the same thing we're aiming at here.
            RunProjectCommandLine(e.filename, lBroadcast)

            'Old -- just added the layer blindly as if it were data
            'm_layers.AddLayer(e.filename)
        Else
            lBroadcast = True
        End If
        If lBroadcast Then
            Dim pnt As Point = MapMain.PointToClient(Cursor.Position)
            Dim MousedownX As Double = 0
            Dim MousedownY As Double = 0
            View.PixelToProj(pnt.X, pnt.Y, MousedownX, MousedownY)
            Plugins.BroadcastMessage("FileDropEvent|" + MousedownX.ToString() + "|" + MousedownY.ToString() + "|" + e.filename)
        End If
    End Sub

    Private Sub MapMain_MouseDownEvent(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_MouseDownEvent) Handles MapMain.MouseDownEvent
        If (MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn Or MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut Or MapMain.CursorMode = MapWinGIS.tkCursorMode.cmPan) Then
            SetModified(True)
        End If

        If AppInfo.AreaMeasuringCurrently Then
            'Handle area measurement
            Dim CurrentLayerGood As Boolean = False
            Dim currPoint As New MapWinGIS.Point
            Dim locx, locy As Double

            ' Get actual location and store it in a point which is added to point list
            View.PixelToProj(e.x, e.y, locx, locy)
            currPoint.x = locx
            currPoint.y = locy
            AppInfo.AreaMeasuringlstDrawPoints.Add(currPoint)

            If View.CursorMode = MapWinGIS.tkCursorMode.cmNone Then
                ' User clicked the right mouse button -- stop measuring area and display message
                If e.button = 2 Then
                    '1/23/09 JK moved the code to MouseUpEvent
                    'AreaMeasuringDisplayResult()
                    'AreaMeasuringStop()
                    ''Start the next one, after having cleared settings from the previous
                    'AreaMeasuringBegin()
                Else
                    View.Draw.DrawPoint(locx, locy, 3, Drawing.Color.Red)
                    If (AppInfo.AreaMeasuringLastStartPtX = -1) Then
                        AppInfo.AreaMeasuringLastStartPtX = System.Windows.Forms.Control.MousePosition.X
                        AppInfo.AreaMeasuringLastStartPtY = System.Windows.Forms.Control.MousePosition.Y
                        AppInfo.AreaMeasuringStartPtX = AppInfo.AreaMeasuringLastStartPtX
                        AppInfo.AreaMeasuringStartPtY = AppInfo.AreaMeasuringLastStartPtY
                        AppInfo.AreaMeasuringEraseLast = False
                    Else
                        'Reverse the one to the start place
                        System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringStartPtX, AppInfo.AreaMeasuringStartPtY), New System.Drawing.Point(AppInfo.AreaMeasuringLastEndX, AppInfo.AreaMeasuringLastEndY), AppInfo.AreaMeasuringmycolor)
                        'Permanently draw line (already drawn, don't erase -- just move it)
                        AppInfo.AreaMeasuringReversibleDrawn.Add(AppInfo.AreaMeasuringLastStartPtX)
                        AppInfo.AreaMeasuringReversibleDrawn.Add(AppInfo.AreaMeasuringLastStartPtY)
                        AppInfo.AreaMeasuringReversibleDrawn.Add(System.Windows.Forms.Control.MousePosition.X)
                        AppInfo.AreaMeasuringReversibleDrawn.Add(System.Windows.Forms.Control.MousePosition.Y)
                        'Update for next loop
                        AppInfo.AreaMeasuringLastStartPtX = System.Windows.Forms.Control.MousePosition.X
                        AppInfo.AreaMeasuringLastStartPtY = System.Windows.Forms.Control.MousePosition.Y
                        AppInfo.AreaMeasuringEraseLast = False
                    End If
                End If
            End If
        Else
            m_PluginManager.MapMouseDown(e.button, e.shift, e.x, e.y)
        End If
    End Sub

    Private Sub MapMain_MouseMoveEvent(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_MouseMoveEvent) Handles MapMain.MouseMoveEvent
        If AppInfo.AreaMeasuringCurrently Then
            AppInfo.AreaMeasuringmycolor = Drawing.Color.White
            If AppInfo.AreaMeasuringEraseLast Then
                System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringLastStartPtX, AppInfo.AreaMeasuringLastStartPtY), New System.Drawing.Point(AppInfo.AreaMeasuringLastEndX, AppInfo.AreaMeasuringLastEndY), AppInfo.AreaMeasuringmycolor)
                System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringStartPtX, AppInfo.AreaMeasuringStartPtY), New System.Drawing.Point(AppInfo.AreaMeasuringLastEndX, AppInfo.AreaMeasuringLastEndY), AppInfo.AreaMeasuringmycolor)
            End If
            If Not AppInfo.AreaMeasuringLastStartPtX = -1 Then
                AppInfo.AreaMeasuringLastEndX = System.Windows.Forms.Control.MousePosition.X
                AppInfo.AreaMeasuringLastEndY = System.Windows.Forms.Control.MousePosition.Y
                System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringLastStartPtX, AppInfo.AreaMeasuringLastStartPtY), New System.Drawing.Point(AppInfo.AreaMeasuringLastEndX, AppInfo.AreaMeasuringLastEndY), AppInfo.AreaMeasuringmycolor)
                System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringStartPtX, AppInfo.AreaMeasuringStartPtY), New System.Drawing.Point(AppInfo.AreaMeasuringLastEndX, AppInfo.AreaMeasuringLastEndY), AppInfo.AreaMeasuringmycolor)
                AppInfo.AreaMeasuringEraseLast = True
            End If
        ElseIf AppInfo.MeasuringCurrently Then
            'Handle distance measurement
            Dim a As Double
            Dim b As Double
            If AppInfo.MeasuringStartX <> 0 And AppInfo.MeasuringStartY <> 0 Then ' a start point has been established
                MapMain.PixelToProj(e.x, e.y, a, b)

                'the units specified in File..Settings..Project Settings..Map Data Units (default - meters)
                Dim DataUnit As UnitOfMeasure = MapWinGeoProc.UnitConverter.StringToUOM(modMain.frmMain.Project.MapUnits)

                Dim MeasureUnit As UnitOfMeasure = DataUnit 'the unit specified in Project Settings..Show Additional Unit
                'Prefer alternate units
                MeasureUnit = MapWinGeoProc.UnitConverter.StringToUOM(modMain.ProjInfo.ShowStatusBarCoords_Alternate)

                'Don't add to cumulative distance yet - do that on mouse up.
                'For now, just add the length of the current segment to the prior segments.
                Dim tempAdditionalDistance As Double = distance(AppInfo.MeasuringStartX, AppInfo.MeasuringStartY, a, b)

                'Since the Distance function made the conversion from DecimalDegrees to Kilometers, 
                'data units are now effectively kilometers.
                If DataUnit = UnitOfMeasure.DecimalDegrees Then DataUnit = UnitOfMeasure.Kilometers
                If MeasureUnit = UnitOfMeasure.DecimalDegrees Then MeasureUnit = DataUnit

                'Allow Convert to handle it properly to return the unit the user wants.
                'Jiri Kadlec 8/28/2008 use the new unit conversion code from MapWinGeoProc
                Dim newDist As Double = 0
                Try
                    newDist = MapWinGeoProc.UnitConverter.ConvertLength(DataUnit, MeasureUnit, _
                        AppInfo.MeasuringTotalDistance + tempAdditionalDistance)
                Catch ex As Exception
                    newDist = AppInfo.MeasuringTotalDistance + tempAdditionalDistance
                End Try

                '3/16/2008 JK - internationalization
                StatusBar.Item(GetOrRemovePanel(resources.GetString("msgPanelDistance.Text"))).Text = _
                    resources.GetString("msgPanelDistance.Text") & " " & formatDistance(newDist) & _
                    " " & MeasureUnit.ToString & " " & resources.GetString("msgDistanceStartOver.Text")

                ' establish a new finishPoint and draw the line
                AppInfo.MeasuringScreenPointFinish = New Point(e.x, e.y)

                If (Not AppInfo.MeasuringDrawing = -1) Then
                    MapMain.ClearDrawing(AppInfo.MeasuringDrawing)
                    AppInfo.MeasuringDrawing = MapMain.NewDrawing(MapWinGIS.tkDrawReferenceList.dlScreenReferencedList)
                End If

                If AppInfo.MeasuringDrawing = -1 Then AppInfo.MeasuringDrawing = MapMain.NewDrawing(MapWinGIS.tkDrawReferenceList.dlScreenReferencedList)

                MeasuringDrawPreviousSegments()

                MapMain.DrawLine(AppInfo.MeasuringScreenPointStart.X, AppInfo.MeasuringScreenPointStart.Y, AppInfo.MeasuringScreenPointFinish.X, AppInfo.MeasuringScreenPointFinish.Y, 2, Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)))
            End If
        End If

        'Still notify other plugins of the move, even if measuring:
        m_PluginManager.MapMouseMove(e.x, e.y)

        'Map Tooltips - update last move time
        If MapTooltipsAtLeastOneLayer Then MapToolTipsLastMoveTime = Now

        ' 2/20/08 LCW: this will allow you to edit one of the auto-hide property grids (leaving it selected) and then move the mouse back over the graph
        ' and have it dismiss the property grid without clicking on the graph
        If dckPanel.ActivePane IsNot Nothing Then
            If Not dckPanel.ActivePane.NestedDockingStatus.IsDisplaying Then MapMain.Focus()
        End If

    End Sub

    Private Sub MapToolTipTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MapToolTipTimer.Tick
        'If we've held the mouse position steady for 1 second, proceed and show a tooltip
        If Now.Subtract(MapToolTipsLastMoveTime).Seconds < 1 Then Return

        'Prevent calling multiple searches for a tooltip at once
        '(e.g., huge shapefile)

        MapToolTipTimer.Stop()
        MapToolTipTimer.Enabled = False

        Try
            'The first layer to match is going to win...
            For i As Integer = 0 To Legend.Layers.Count - 1
                If Legend.Layers(i).MapTooltipsEnabled And (Legend.Layers(i).Type = eLayerType.LineShapefile Or Legend.Layers(i).Type = eLayerType.PointShapefile Or Legend.Layers(i).Type = eLayerType.PolygonShapefile) Then
                    Dim shapes As Object = Nothing
                    Dim sf As MapWinGIS.Shapefile = MapMain.get_GetObject(Legend.Layers(i).Handle)
                    Dim ec As Point = MapMain.PointToClient(System.Windows.Forms.Cursor.Position)
                    Dim a, b, c, d As Double
                    MapMain.PixelToProj(ec.X - 8, ec.Y - 8, a, b)
                    MapMain.PixelToProj(ec.X + 8, ec.Y + 8, c, d)
                    Dim extents As New MapWinGIS.Extents
                    extents.SetBounds(a, b, 0, c, d, 0)
                    'Use my own tolerance (in pixels) rather than SelectShapes tolerance (in map units)
                    If sf.SelectShapes(extents, 0, MapWinGIS.SelectMode.INTERSECTION, shapes) AndAlso (shapes IsNot Nothing AndAlso shapes.Length > 0) Then
                        'Assume only first
                        Dim fp As Point = Me.PointToClient(System.Windows.Forms.Cursor.Position)
                        MapToolTipObject.Show(sf.CellValue(Legend.Layers(i).MapTooltipFieldIndex, CType(shapes(0), Integer)), Me, fp.X, fp.Y, 2000)
                        Exit For 'Found one - call it good. We don't want to be showing multiple tooltips.
                    End If
                End If
            Next
        Catch
        End Try

        '...and back on:
        MapToolTipTimer.Enabled = True
        MapToolTipTimer.Start()
    End Sub

    Public Sub UpdateMapToolTipsAtLeastOneLayer()
        MapTooltipsAtLeastOneLayer = False
        Try
            'The first layer to match is going to win...
            For i As Integer = 0 To Legend.Layers.Count - 1
                If Legend.Layers(i).MapTooltipsEnabled And (Legend.Layers(i).Type = eLayerType.LineShapefile Or Legend.Layers(i).Type = eLayerType.PointShapefile Or Legend.Layers(i).Type = eLayerType.PolygonShapefile) Then
                    MapTooltipsAtLeastOneLayer = True
                    Return 'No need to keep going
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub MapMain_SelectBoxFinal(ByVal sender As System.Object, ByVal e As AxMapWinGIS._DMapEvents_SelectBoxFinalEvent) Handles MapMain.SelectBoxFinal
        Const vbKeyControl As Integer = 17
        Dim tSI As MapWindow.SelectInfo

        If MapMain.NumLayers = 0 Then Exit Sub

        If MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn Then
            m_PreviewMap.UpdateLocatorBox()

        ElseIf MapMain.CursorMode = MapWinGIS.tkCursorMode.cmSelection Then
            If m_PluginManager.MapDragFinished(New Rectangle(e.left, e.top, e.right - e.left, e.top - e.bottom)) = False Then
                'dpa 02/15/02
                If Layers(Legend.SelectedLayer).LayerType = eLayerType.Image Then Exit Sub
                tSI = m_View.SelectShapesByRectangle(e.left, e.right, e.top, e.bottom, CBool(GetAsyncKeyState(vbKeyControl)))
                m_PluginManager.ShapesSelected(Legend.SelectedLayer, tSI)
                UpdateZoomButtons()
            End If
        End If
    End Sub

#End Region

#Region "Toolbar Functions"

    Friend Sub UpdateZoomButtons()
        'Sets the enabled status of the multi-zoom drop down button.
        'Updated 1/20/2005
        Dim lt As eLayerType
        If Legend Is Nothing OrElse Legend.SelectedLayer = -1 Then
            tbbMeasure.Enabled = False
            tbbMeasureArea.Enabled = False
            tbbSelect.Enabled = False
            tbbPan.Enabled = False
            tbbZoomIn.Enabled = False
            tbbZoomOut.Enabled = False
            tbbZoom.Enabled = False
            mnuZoomPrevious.Enabled = False
            mnuZoomNext.Enabled = False
            mnuZoomMax.Enabled = False
            mnuZoomLayer.Enabled = False
            mnuZoomSelected.Enabled = False
            mnuZoomShape.Enabled = False
            Me.mnuZoomPreviewMap.Enabled = False
            If Not m_Menu.Item("mnuZoomToPreviewExtents") Is Nothing Then m_Menu.Item("mnuZoomToPreviewExtents").Enabled = False
        Else
            If Legend.SelectedLayer >= 0 Then
                If m_layers Is Nothing OrElse m_layers(Legend.SelectedLayer) Is Nothing Then
                    lt = eLayerType.Invalid
                Else
                    lt = m_layers(Legend.SelectedLayer).LayerType
                End If

            End If
            tbbMeasure.Enabled = (MapMain.NumLayers > 0)
            tbbMeasureArea.Enabled = (MapMain.NumLayers > 0)
            tbbSelect.Enabled = (MapMain.NumLayers > 0)
            tbbPan.Enabled = (MapMain.NumLayers > 0)
            tbbZoomIn.Enabled = (MapMain.NumLayers > 0)
            tbbZoomOut.Enabled = (MapMain.NumLayers > 0)
            tbbZoom.Enabled = (MapMain.NumLayers > 0)
            Me.mnuZoomPreviewMap.Enabled = (MapMain.NumLayers > 0 And PreviewMapExtentsValid())
            If Not m_Menu.Item("mnuZoomToPreviewExtents") Is Nothing Then m_Menu.Item("mnuZoomToPreviewExtents").Enabled = (MapMain.NumLayers > 0 And PreviewMapExtentsValid())
            mnuZoomPrevious.Enabled = (m_Extents.Count > 0) AndAlso m_CurrentExtent > 0
            mnuZoomNext.Enabled = (m_CurrentExtent < m_Extents.Count - 1) And (m_Extents.Count > 0)
            mnuZoomMax.Enabled = (MapMain.NumLayers > 0)
            mnuZoomLayer.Enabled = True
            mnuZoomSelected.Enabled = m_View.SelectedShapes.NumSelected > 0
            If Legend.SelectedLayer >= 0 Then
                mnuZoomShape.Enabled = (lt = eLayerType.LineShapefile Or _
                                                  lt = eLayerType.PointShapefile Or _
                                                  lt = eLayerType.PolygonShapefile)
            End If
        End If

        'Next, toggle the zoom buttons if anything has changed:
        Dim value As MapWinGIS.tkCursorMode = MapMain.CursorMode
        tbbSelect.Checked = (value = MapWinGIS.tkCursorMode.cmSelection)
        tbbPan.Checked = (value = MapWinGIS.tkCursorMode.cmPan)
        tbbZoomIn.Checked = (value = MapWinGIS.tkCursorMode.cmZoomIn)
        tbbZoomOut.Checked = (value = MapWinGIS.tkCursorMode.cmZoomOut)

        If (tbbSelect.Checked Or tbbPan.Checked Or tbbZoomIn.Checked Or tbbZoomOut.Checked) Then MapMain.MapCursor = MapWinGIS.tkCursor.crsrMapDefault
    End Sub

    Public Sub tlbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tlbMain.ItemClicked
        Dim Btn As Windows.Forms.ToolStripItem = e.ClickedItem
        Dim BtnName As String = CType(Btn.Name, String)
        If BtnName.Trim() = "" And TypeOf (Btn.Tag) Is String Then BtnName = CStr(Btn.Tag)
        HandleButtonClick(BtnName, Btn)
    End Sub

    Public Sub HandleButtonClick(ByVal BtnName As String, Optional ByVal Btn As ToolStripItem = Nothing)
        If AppInfo.MeasuringCurrently And Not BtnName = "tbbMeasure" Then MeasuringStop()
        If AppInfo.AreaMeasuringCurrently And Not BtnName = "tbbMeasureArea" Then AreaMeasuringStop()

        Dim Handled As Boolean
        Select Case BtnName
            Case "tbbAddRemove"
                If Not Btn Is Nothing Then CType(Btn, ToolStripDropDownButton).HideDropDown()

                If mnuBtnAdd.Checked Then
                    DoAddLayer()
                ElseIf mnuBtnRemove.Checked Then
                    DoRemoveLayer()
                ElseIf mnuBtnClear.Checked Then
                    DoClearLayers()
                End If

            Case "tbbZoom"
                If Not Btn Is Nothing Then CType(Btn, ToolStripDropDownButton).HideDropDown()

                If mnuZoomPrevious.Checked Then
                    DoZoomPrevious()
                ElseIf mnuZoomNext.Checked Then
                    DoZoomNext()
                ElseIf mnuZoomMax.Checked Then
                    DoZoomMax()
                ElseIf mnuZoomLayer.Checked Then
                    DoZoomLayer()
                ElseIf mnuZoomSelected.Checked Then
                    DoZoomSelected()
                ElseIf mnuZoomShape.Checked Then
                    DoZoomShape()
                ElseIf mnuZoomPreviewMap.Checked Then
                    doZoomToPreview()
                End If

            Case "tbbZoomIn"
                If AppInfo.MeasuringCurrently Then MeasuringStop()
                If AppInfo.AreaMeasuringCurrently Then AreaMeasuringStop()
                doZoomIn()
                'Notify plugins - since this is done after handing it locally,
                'they can't override it -- but they do notice it.
                Handled = m_PluginManager.ItemClicked(BtnName)

            Case "tbbZoomOut"
                If AppInfo.MeasuringCurrently Then MeasuringStop()
                If AppInfo.AreaMeasuringCurrently Then AreaMeasuringStop()
                doZoomOut()
                'Notify plugins - since this is done after handing it locally,
                'they can't override it -- but they do notice it.
                Handled = m_PluginManager.ItemClicked(BtnName)

            Case "tbbPan"
                If AppInfo.MeasuringCurrently Then MeasuringStop()
                If AppInfo.AreaMeasuringCurrently Then AreaMeasuringStop()
                MapMain.CursorMode = MapWinGIS.tkCursorMode.cmPan
                UpdateZoomButtons()
                'Notify plugins - since this is done after handing it locally,
                'they can't override it -- but they do notice it.
                Handled = m_PluginManager.ItemClicked(BtnName)

            Case "tbbSelect"
                If AppInfo.MeasuringCurrently Then MeasuringStop()
                If AppInfo.AreaMeasuringCurrently Then AreaMeasuringStop()
                MapMain.CursorMode = MapWinGIS.tkCursorMode.cmSelection
                UpdateZoomButtons()
                'Notify plugins - since this is done after handing it locally,
                'they can't override it -- but they do notice it.
                Handled = m_PluginManager.ItemClicked(BtnName)
            Case "tbbMeasure"
                If Not AppInfo.MeasuringCurrently Then
                    MeasuringBegin()
                Else
                    MeasuringStop()
                End If
                UpdateZoomButtons()
                'Notify plugins - since this is done after handing it locally,
                'they can't override it -- but they do notice it.
                Handled = m_PluginManager.ItemClicked(BtnName)

            Case "tbbMeasureArea"
                If Not AppInfo.AreaMeasuringCurrently Then
                    AreaMeasuringBegin()
                Else
                    AreaMeasuringStop()
                End If
                UpdateZoomButtons()
                'Notify plugins - since this is done after handing it locally,
                'they can't override it -- but they do notice it.
                Handled = m_PluginManager.ItemClicked(BtnName)

            Case Else ' Plugins can override anything else
                Handled = m_PluginManager.ItemClicked(BtnName)
                If Handled = False Then 'the plugin didn't override the other buttons (print etc). So handle them now.
                    Select Case BtnName
                        Case "tbbPrint"
                            DoPrint()
                        Case "tbbSave"
                            DoSave()
                        Case "tbbNew"
                            DoNew()
                        Case "tbbOpen"
                            DoOpen()
                    End Select
                End If
        End Select

        'Now that the plug-in manager has possibly sent off plug-in requests,
        'make sure that no plug-ins changed map cursor states:
        UpdateZoomButtons()
    End Sub

    Public Sub CustomCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Fires when user clicks a custom combo box on the main toolbar or floating toolbar.
        Dim cbClicked As Windows.Forms.ToolStripItem = CType(sender, Windows.Forms.ToolStripItem)
        m_PluginManager.ItemClicked(cbClicked.Name)
    End Sub

#End Region

#Region "Menu Functions"
    'All of these menu functions were extracted from DotNetBar code and are
    'new in the open source version 4
    'updated 1/25/2005

    'updated 10/1/2008 - Earljon Hidalgo (ejh) - Added icons for MapWindow UI including context menus
    Public Sub SetUpMenus()
        Dim Nil As Object = Nothing
        'Set up the File menu
        m_Menu.AddMenu("mnuFile", Nil, resources.GetString("mnuFile.Text"))
        m_Menu.AddMenu("mnuNew", "mnuFile", resources.GetObject("imgNew"), resources.GetString("mnuNew.Text"))
        m_Menu.AddMenu("mnuOpen", "mnuFile", resources.GetObject("imgFolder"), resources.GetString("mnuOpen.Text"))
        m_Menu.AddMenu("mnuFileBreak0", "mnuFile", Nil, "-")
        m_Menu.AddMenu("mnuOpenProjectIntoGroup", "mnuFile", resources.GetObject("imgOpenGroup"), resources.GetString("mnuOpenProjectIntoGroup.Text"))
        m_Menu.AddMenu("mnuFileBreak1", "mnuFile", Nil, "-")
        m_Menu.AddMenu("mnuSave", "mnuFile", resources.GetObject("imgSave"), resources.GetString("mnuSave.Text"))
        m_Menu.AddMenu("mnuSaveAs", "mnuFile", resources.GetObject("imgSaveAs"), resources.GetString("mnuSaveAs.Text"))
        m_Menu.AddMenu("mnuFileBreak2", "mnuFile", Nil, "-")
        m_Menu.AddMenu("mnuPrint", "mnuFile", resources.GetObject("imgPrinter"), resources.GetString("mnuPrint.Text"))
        m_Menu.AddMenu("mnuFileBreak3", "mnuFile", Nil, "-")
        m_Menu.AddMenu("mnuProjectSettings", "mnuFile", resources.GetObject("imgSettings"), resources.GetString("mnuProjectSettings.Text"))
        m_Menu.AddMenu("mnuRecentProjects", "mnuFile", resources.GetObject("imgHistory"), resources.GetString("mnuRecentProjects.Text"))
        m_Menu.AddMenu("mnuFileBreak4", "mnuFile", Nil, "-")
        m_Menu.AddMenu("mnuCheckForUpdates", "mnuFile", resources.GetObject("imgUpdate"), resources.GetString("mnuCheckUpdates.Text"))
        m_Menu.AddMenu("mnuFileBreak5", "mnuFile", Nil, "-")
        m_Menu.AddMenu("mnuClose", "mnuFile", resources.GetObject("imgClose"), resources.GetString("mnuClose.Text"))
        m_Menu.AddMenu("mnuExit", "mnuFile", Nil, resources.GetString("mnuExit.Text"))

        'Set up the Edit menu
        m_Menu.AddMenu("mnuEdit", Nil, resources.GetString("mnuEdit.Text"))

        'Add a Copy menu with sub menus. 
        m_Menu.AddMenu("mnuCopy", "mnuEdit", resources.GetObject("imgCopy"), resources.GetString("mnuCopy.Text"))
        m_Menu.AddMenu("mnuCopyMap", "mnuCopy", resources.GetObject("imgMap"), resources.GetString("mnuCopyMap.Text"))
        m_Menu.AddMenu("mnuCopyLegend", "mnuCopy", resources.GetObject("imgCopyLegend"), resources.GetString("mnuCopyLegend.Text"))
        m_Menu.AddMenu("mnuCopyScaleBar", "mnuCopy", Nil, resources.GetString("mnuCopyScaleBar.Text"))
        m_Menu.AddMenu("mnuCopyNorthArrow", "mnuCopy", Nil, resources.GetString("mnuCopyNorthArrow.Text"))

        'Add a Save menu (should this be "Export"?) with sub menus
        m_Menu.AddMenu("mnuExport", "mnuEdit", resources.GetObject("imgExport"), resources.GetString("mnuExport.Text"))
        m_Menu.AddMenu("mnuSaveMapImage", "mnuExport", resources.GetObject("imgMap"), resources.GetString("mnuSaveMapImage.Text"))
        m_Menu.AddMenu("mnuSaveGeorefMapImage", "mnuExport", Nil, resources.GetString("mnuSaveGeorefMapImage.Text"))
        m_Menu.AddMenu("mnuSaveScaleBar", "mnuExport", Nil, resources.GetString("mnuSaveScaleBar.Text"))
        m_Menu.AddMenu("mnuSaveNorthArrow", "mnuExport", Nil, resources.GetString("mnuSaveNorthArrow.Text"))
        m_Menu.AddMenu("mnuSaveLegend", "mnuExport", resources.GetObject("imgCopyLegend"), resources.GetString("mnuSaveLegend.Text"))

        'Add a break
        m_Menu.AddMenu("mnuEditBreak2", "mnuEdit", Nil, "-")

        'Add Preview map functions
        m_Menu.AddMenu("mnuPreview", "mnuEdit", resources.GetObject("imgMapPreview"), resources.GetString("mnuPreview.Text"))
        m_Menu.AddMenu("mnuUpdatePreviewFull", "mnuPreview", Nil, resources.GetString("mnuUpdatePreviewFull.Text"))
        m_Menu.AddMenu("mnuUpdatePreviewCurr", "mnuPreview", Nil, resources.GetString("mnuUpdatePreviewCurr.Text"))
        m_Menu.AddMenu("mnuClearPreview", "mnuPreview", Nil, resources.GetString("mnuClearPreview.Text"))

        m_PreviewMapContextMenuStrip.Items.Add(resources.GetString("mnuUpdatePreviewFull.Text"), Nothing, New System.EventHandler(AddressOf PreviewMapContextMenuStrip_UpdatePreviewFull))
        m_PreviewMapContextMenuStrip.Items.Add(resources.GetString("mnuUpdatePreviewCurr.Text"), Nothing, New System.EventHandler(AddressOf PreviewMapContextMenuStrip_UpdatePreview))
        m_Menu.AddMenu("mnuUpdatePreviewCurr", "mnuPreview", Nil, resources.GetString("mnuUpdatePreviewCurr.Text"))

        m_PreviewMapContextMenuStrip.Items.Add(resources.GetString("mnuClearPreview.Text"), Nothing, New System.EventHandler(AddressOf PreviewMapContextMenuStrip_ClearPreview))

        'Set up the View menu
        m_Menu.AddMenu("mnuView", Nil, resources.GetString("mnuView.Text"))
        m_Menu.AddMenu("mnuAddLayer", "mnuView", resources.GetObject("imgLayerAdd"), resources.GetString("mnuAddLayer.Text"))
        m_Menu.AddMenu("mnuRemoveLayer", "mnuView", resources.GetObject("imgLayerRemove"), resources.GetString("mnuRemoveLayer.Text"))
        m_Menu.AddMenu("mnuClearLayer", "mnuView", resources.GetObject("imgLayerClear"), resources.GetString("mnuClearLayer.Text"))
        m_Menu.AddMenu("mnuViewBreak1", "mnuView", Nil, "-")
        m_Menu.AddMenu("mnuClearSelectedShapes", "mnuView", Nil, resources.GetString("mnuClearSelectedShapes.Text")).Enabled = False
        m_Menu.AddMenu("mnuViewBreak2", "mnuView", Nil, "-")
        m_Menu.AddMenu("mnuSetScale", "mnuView", Nil, resources.GetString("mnuSetScale.Text"))
        m_Menu.AddMenu("mnuShowScaleBar", "mnuView", Nil, resources.GetString("mnuShowScaleBar.Text"))
        m_Menu.AddMenu("mnuViewBreak3", "mnuView", Nil, "-")
        m_Menu.AddMenu("mnuZoomIn", "mnuView", resources.GetObject("imgZoomIn"), resources.GetString("mnuZoomIn.Text"))
        m_Menu.AddMenu("mnuZoomOut", "mnuView", resources.GetObject("imgZoomOut"), resources.GetString("mnuZoomOut.Text"))
        m_Menu.AddMenu("mnuZoomToFullExtents", "mnuView", resources.GetObject("imgZoomExtent"), resources.GetString("mnuZoomToFullExtents.Text"))
        'Start this one disabled
        m_Menu.AddMenu("mnuZoomToPreviewExtents", "mnuView", resources.GetObject("imgMapExtents"), resources.GetString("mnuZoomToPreviewExtents.Text")).Enabled = False
        m_Menu.AddMenu("mnuViewBreak4", "mnuView", Nil, "-")
        m_Menu.AddMenu("mnuPreviousZoom", "mnuView", Nil, resources.GetString("mnuPreviousZoom.Text"))
        m_Menu.AddMenu("mnuNextZoom", "mnuView", Nil, resources.GetString("mnuNextZoom.Text"))
        m_Menu.AddMenu("mnuViewBreak5", "mnuView", Nil, "-")
        m_Menu.AddMenu("mnuBookmarkView", "mnuView", resources.GetObject("imgBookmarkAdd"), resources.GetString("mnuBookmarkView.Text"))
        m_Menu.AddMenu("mnuBookmarkDelete", "mnuView", resources.GetObject("imgBookmarkDelete"), resources.GetString("mnuBookmarkDelete.Text"))
        m_Menu.AddMenu("mnuBookmarkedViews", "mnuView", resources.GetObject("imgBookmarkView"), resources.GetString("mnuBookmarkedViews.Text"))
        'Panels Menu
        m_Menu.AddMenu("mnuPanelSep", "mnuView", Nil, "-")
        m_Menu.AddMenu("mnuRestoreMenu", "mnuView", resources.GetObject("imgPanels"), resources.GetString("mnuPanels.Text"))
        m_Menu.AddMenu("mnuLegendVisible", "mnuRestoreMenu", Nil, resources.GetString("mnuShowLegend.Text")).Checked = IIf(legendPanel Is Nothing, False, True)
        m_Menu.AddMenu("mnuPreviewVisible", "mnuRestoreMenu", Nil, resources.GetString("mnuShowPreviewMap.Text")).Checked = IIf(previewPanel Is Nothing, False, True)

        'Set up the Plug-ins menu
        m_Menu.AddMenu("mnuPlugins", Nil, resources.GetString("mnuPlugins.Text"))
        m_Menu.AddMenu("mnuEditPlugins", "mnuPlugins", resources.GetObject("imgPluginEdit"), resources.GetString("mnuEditPlugins.Text"))
        m_Menu.AddMenu("mnuScript", "mnuPlugins", resources.GetObject("imgScripts"), resources.GetString("mnuScript.Text"))
        m_Menu.AddMenu("mnuPluginsBreak1", "mnuPlugins", Nil, "-")

        'Set up the Help menu
        m_Menu.AddMenu("mnuHelp", Nil, resources.GetString("mnuHelp.Text"))
        m_Menu.AddMenu("mnuContents", "mnuHelp", Nil, resources.GetString("mnuContents.Text"))

        'Additional help menu items - cdm 12/22/2005.
        'These are hidden or displayed according to need in modMain.LoadMainForm.
        'This includes hiding offline if connection is available, etc.
        m_Menu.AddMenu("mnuOnlineDocs", "mnuHelp", resources.GetObject("imgHelp"), resources.GetString("mnuOnlineDocs.Text"))
        m_Menu.AddMenu("mnuOfflineDocs", "mnuHelp", resources.GetObject("imgHelp"), resources.GetString("mnuOfflineDocs.Text"))

        m_Menu.AddMenu("mnuHelpBreak1", "mnuHelp", Nil, "-")
        m_Menu.AddMenu("mnuShortcuts", "mnuHelp", resources.GetObject("imgKeyboard"), resources.GetString("mnuShortcuts.Text"))
        m_Menu.AddMenu("mnuHelpBreak2", "mnuHelp", Nil, "-")

        m_Menu.AddMenu("mnuWelcomeScreen", "mnuHelp", resources.GetObject("imgWelcome"), resources.GetString("mnuWelcomeScreen.Text"))
        m_Menu.AddMenu("mnuAboutMapWindow", "mnuHelp", resources.GetObject("imgAbout"), resources.GetString("mnuAboutMapWindow.Text"))

        'Set up the new toolbar button. Do this from code now that we have
        'internationalization - otherwise would need to add to every resource
        'file individually
        Dim image As System.Drawing.Icon = New System.Drawing.Icon(Me.GetType, "measure_1.ico")
        ilsToolbar.Images.Add(image)
        tbbMeasure.ImageIndex = ilsToolbar.Images.Count - 1

        Dim image2 As System.Drawing.Icon = New System.Drawing.Icon(Me.GetType, "measure_2.ico")
        ilsToolbar.Images.Add(image2)
        tbbMeasureArea.ImageIndex = ilsToolbar.Images.Count - 1

        Dim image3 As System.Drawing.Icon = New System.Drawing.Icon(Me.GetType, "hand.ico")
        ilsToolbar.Images.Add(image3)
        tbbPan.ImageIndex = ilsToolbar.Images.Count - 1

        Dim image4 As System.Drawing.Bitmap = New System.Drawing.Bitmap(Me.GetType, "select.ico")
        ilsToolbar.Images.Add(image4)
        tbbSelect.ImageIndex = ilsToolbar.Images.Count - 1

        'The default zoom action is now to zoom to layer.
        'Dim image5 As System.Drawing.Bitmap = New System.Drawing.Bitmap(Me.GetType, "zoom_layer_16_1.ico")
        'ilsToolbar.Images.Add(image5)
        'tbbZoom.ImageIndex = ilsToolbar.Images.Count - 1
        'tbbZoom.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_layer_16_2.ico")
        tbbZoom.Image = New System.Drawing.Bitmap(Me.GetType, "zoom.ico")

        'Dim image6 As System.Drawing.Bitmap = New System.Drawing.Bitmap(Me.GetType, "zoom_in_16_2.ico")
        Dim image6 As System.Drawing.Bitmap = New System.Drawing.Bitmap(Me.GetType, "zoom_in.ico")
        ilsToolbar.Images.Add(image6)
        tbbZoomIn.ImageIndex = ilsToolbar.Images.Count - 1

        'Dim image7 As System.Drawing.Bitmap = New System.Drawing.Bitmap(Me.GetType, "zoom_out_16.ico")
        Dim image7 As System.Drawing.Bitmap = New System.Drawing.Bitmap(Me.GetType, "zoom_out.ico")
        ilsToolbar.Images.Add(image7)
        tbbZoomOut.ImageIndex = ilsToolbar.Images.Count - 1

        mnuZoomPrevious.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_back_16.ico")

        mnuZoomNext.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_forward_16_2.ico")

        'mnuZoomLayer.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_layer_16_2.ico")
        mnuZoomLayer.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_to_layer.ico")

        'mnuZoomMax.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_fit_16_3.ico")
        mnuZoomMax.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_full_extent.ico")

        mnuZoomSelected.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_select_16_2.ico")

        'Commented, image already in place on the toolbar - ejh 10/01/2008
        'mnuBtnAdd.Image = New System.Drawing.Bitmap(Me.GetType, "add.ico")
        'mnuBtnClear.Image = New System.Drawing.Bitmap(Me.GetType, "Delete_all_16.ico")
        'mnuBtnRemove.Image = New System.Drawing.Bitmap(Me.GetType, "delete.ico")

        mnuZoomPreviewMap.Image = New System.Drawing.Bitmap(Me.GetType, "zoom_preview.ico")

        'Context menu for floating scale bar
        m_FloatingScalebar_ContextMenu = New ContextMenu()
        m_FloatingScalebar_ContextMenu_UL = New Windows.Forms.MenuItem(resources.GetString("sbContextMenu_UpperLeft.Text"), AddressOf FloatingScalebar_UpperLeft_Click)
        m_FloatingScalebar_ContextMenu.MenuItems.Add(m_FloatingScalebar_ContextMenu_UL)
        m_FloatingScalebar_ContextMenu_UR = New Windows.Forms.MenuItem(resources.GetString("sbContextMenu_UpperRight.Text"), AddressOf FloatingScalebar_UpperRight_Click)
        m_FloatingScalebar_ContextMenu.MenuItems.Add(m_FloatingScalebar_ContextMenu_UR)
        m_FloatingScalebar_ContextMenu_LL = New Windows.Forms.MenuItem(resources.GetString("sbContextMenu_LowerLeft.Text"), AddressOf FloatingScalebar_LowerLeft_Click)
        m_FloatingScalebar_ContextMenu.MenuItems.Add(m_FloatingScalebar_ContextMenu_LL)
        m_FloatingScalebar_ContextMenu_LR = New Windows.Forms.MenuItem(resources.GetString("sbContextMenu_LowerRight.Text"), AddressOf FloatingScalebar_LowerRight_Click)
        m_FloatingScalebar_ContextMenu_LR.Checked = True
        m_FloatingScalebar_ContextMenu.MenuItems.Add(m_FloatingScalebar_ContextMenu_LR)
        m_FloatingScalebar_ContextMenu.MenuItems.Add("-")
        m_FloatingScalebar_ContextMenu_FC = New Windows.Forms.MenuItem(resources.GetString("sbContextMenu_ChooseForecolor.Text"), AddressOf FloatingScalebar_ChooseForecolor_Click)
        m_FloatingScalebar_ContextMenu.MenuItems.Add(m_FloatingScalebar_ContextMenu_FC)
        m_FloatingScalebar_ContextMenu_BC = New Windows.Forms.MenuItem(resources.GetString("sbContextMenu_ChooseBackcolor.Text"), AddressOf FloatingScalebar_ChooseBackcolor_Click)
        m_FloatingScalebar_ContextMenu.MenuItems.Add(m_FloatingScalebar_ContextMenu_BC)
        m_FloatingScalebar_ContextMenu_CU = New Windows.Forms.MenuItem(resources.GetString("sbContextMenu_ChangeUnits.Text"), AddressOf FloatingScalebar_ChangeUnits_Click)
        m_FloatingScalebar_ContextMenu.MenuItems.Add(m_FloatingScalebar_ContextMenu_CU)
    End Sub

    Private Sub doSaveGeoreferenced()
        Dim newfilename As String
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.Filter = "All Image Types (*.bmp; *.gif; *.jpg)|*.bmp;*.gif;*.jpg|JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|GIF Image (*.gif)|*.gif"

        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        ' tws 04/062007: moved to options dialog
        'If saveFileDialog1.ShowDialog() = DialogResult.OK Then
        '    newfilename = saveFileDialog1.FileName
        'Else
        '    Exit Sub
        'End If

        Dim image As New MapWinGIS.Image
        Dim success As Boolean
        '+ tws 04/06 2007:
        ' optionally clip the output to one of the layers in the map
        ' and size/zoom it to the user's preference
        '
        Dim dlgExport As New frmExport
        dlgExport.MainForm = Me
        dlgExport.sfd = saveFileDialog1
        Dim ok As DialogResult = dlgExport.ShowDialog()
        If ok <> Windows.Forms.DialogResult.OK Or dlgExport.newfilename Is Nothing Then
            Exit Sub
        End If
        newfilename = dlgExport.newfilename
        Dim oldMsg As String = modMain.g_error
        If dlgExport.SelectedLayer > -1 Then
            image = CType(MapMain.SnapShot2(dlgExport.SelectedLayer, dlgExport.ImageZoom, dlgExport.ImageWidth), MapWinGIS.Image)
        Else
            Dim extents As MapWinGIS.Extents = MapMain.Extents
            image = CType(MapMain.SnapShot(extents), MapWinGIS.Image)
        End If
        If image Is Nothing Then
            ' it looks like something SHOULD: implement MapWinGIS.ICallback,
            '    AND call CMap::SetGlobalCallback; and its .Error() should put the last error in 
            '    modmain.g_error; right now 04/26/2007 nothing actually does that (clsLayers implements the
            '    interface but nothing ever calls the method to set it). if that is done, and we have failed here, 
            '    we should have a new message from the code in the ocx to display here
            Dim errTxt As String = "Export failed"
            If Not oldMsg Is modMain.g_error Then
                errTxt &= vbCrLf & modMain.g_error
            End If
            MapWinUtility.Logger.Msg(errTxt, MsgBoxStyle.Critical)
            Me.RefreshMap() ' need to refresh, to be sure we cleaned up
            Return
        End If
        '- tws

        Dim configpath As String

        Dim deltax, deltay, xtopleft, ytopleft As Double

        If newfilename <> "" Then
            success = image.Save(newfilename, False, MapWinGIS.ImageType.USE_FILE_EXTENSION)
            'If the save wasn't successful display an error message
            If Not success Then
                '12/10/2005 PM:
                'mapwinutility.logger.msg("There were errors saving the image", MsgBoxStyle.Exclamation, "Could Not Save")
                MapWinUtility.Logger.Msg(resources.GetString("msgErrorSavingImage.Text"), MsgBoxStyle.Exclamation, resources.GetString("titleErrorSavingImage.Text"))
                Exit Sub
            End If

            'this bit creates the world file
            'Set Pathname to the text file:

            deltax = Math.Round(image.dX, 10)
            deltay = image.dY
            xtopleft = Math.Round(image.XllCenter, 6)
            ytopleft = Math.Round((image.YllCenter + Math.Abs((image.Height - 2) * deltay)), 6)
            deltay = Math.Round(deltay, 10)

            'Set the appropriate world file path
            Dim pathNoExt As String = System.IO.Path.GetDirectoryName(newfilename) + "\" + System.IO.Path.GetFileNameWithoutExtension(newfilename)
            Dim ext As String = "wld"
            Select Case System.IO.Path.GetExtension(newfilename).ToLower
                Case ".bmp"
                    ext = ".bpw"
                Case ".gif"
                    ext = ".gfw"
                Case ".jpg", ".jpeg"
                    ext = ".jgw"
            End Select

            configpath = pathNoExt + ext

            FileOpen(100, configpath, OpenMode.Output)

            PrintLine(100, deltax)
            PrintLine(100, "0")
            PrintLine(100, "0")
            PrintLine(100, "-" & deltay)
            PrintLine(100, xtopleft)
            PrintLine(100, ytopleft)

            FileClose(100)
        End If

        Try
            image.Close()
            image = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Public Function GetLayerPrettyProjection(ByVal Handle As Long) As String
        If Not m_layers.IsValidHandle(Handle) Then Return ""

        Dim proj As String = ""

        If m_layers(Handle).LayerType = eLayerType.LineShapefile Or m_layers(Handle).LayerType = eLayerType.PointShapefile Or m_layers(Handle).LayerType = eLayerType.PolygonShapefile Then
            Try
                proj = CType(frmMain.Layers(Handle).GetObject(), MapWinGIS.Shapefile).Projection
            Catch
            End Try
        ElseIf m_layers(Handle).LayerType = eLayerType.Grid Then
            Try
                proj = CType(frmMain.Layers(Handle).GetGridObject(), MapWinGIS.Grid).Header.Projection
            Catch
            End Try
        ElseIf m_layers(Handle).LayerType = eLayerType.Image Then
            Try
                proj = CType(frmMain.Layers(Handle).GetObject(), MapWinGIS.Image).GetProjection()
            Catch
            End Try
        Else
            Return ""
        End If

        If proj = "" Then Return "(None)"
        Dim projUtil As New clsProjections
        proj = projUtil.FindProjectionByPROJ4(proj).Name + " (" + proj + ")"
        Return proj
    End Function

    Private Sub doSetScale()
        If MapMain.NumLayers = 0 Then
            MapWinUtility.Logger.Msg("Please add data to the map before setting the scale.", MsgBoxStyle.Information, "Add Data First")
            Return
        End If

        Dim getscale As New frmSetScale(GetCurrentScale)
        If getscale.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SetScale(getscale.txtNewScale.Text)
        End If
    End Sub

    Public Function GetScaleUnit() As MapWindow.Interfaces.UnitOfMeasure
        Dim ScaleUnit As MapWindow.Interfaces.UnitOfMeasure

        'Try map units
        Select Case frmMain.Project.MapUnits
            Case MapWindow.Interfaces.UnitOfMeasure.Centimeters.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Centimeters
            Case MapWindow.Interfaces.UnitOfMeasure.Feet.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Feet
            Case MapWindow.Interfaces.UnitOfMeasure.Inches.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Inches
            Case MapWindow.Interfaces.UnitOfMeasure.Kilometers.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Kilometers
            Case MapWindow.Interfaces.UnitOfMeasure.Meters.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Meters
            Case MapWindow.Interfaces.UnitOfMeasure.Miles.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Miles
            Case MapWindow.Interfaces.UnitOfMeasure.Millimeters.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Millimeters
            Case MapWindow.Interfaces.UnitOfMeasure.Yards.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Yards
            Case MapWindow.Interfaces.UnitOfMeasure.DecimalDegrees.ToString()
                'Disallow showing degrees as a measurement.
                ScaleUnit = MapWindow.Interfaces.UnitOfMeasure.Kilometers
            Case "Lat/Long"
                ScaleUnit = MapWindow.Interfaces.UnitOfMeasure.Kilometers
        End Select

        'Prefer alternate coordinate system, it set
        Select Case modMain.ProjInfo.ShowStatusBarCoords_Alternate
            Case MapWindow.Interfaces.UnitOfMeasure.Centimeters.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Centimeters
            Case MapWindow.Interfaces.UnitOfMeasure.Feet.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Feet
            Case MapWindow.Interfaces.UnitOfMeasure.Inches.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Inches
            Case MapWindow.Interfaces.UnitOfMeasure.Kilometers.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Kilometers
            Case MapWindow.Interfaces.UnitOfMeasure.Meters.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Meters
            Case MapWindow.Interfaces.UnitOfMeasure.Miles.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Miles
            Case MapWindow.Interfaces.UnitOfMeasure.Millimeters.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Millimeters
            Case MapWindow.Interfaces.UnitOfMeasure.Yards.ToString()
                ScaleUnit = Interfaces.UnitOfMeasure.Yards
            Case MapWindow.Interfaces.UnitOfMeasure.DecimalDegrees.ToString()
                'Disallow showing degrees as a measurement.
                ScaleUnit = MapWindow.Interfaces.UnitOfMeasure.Kilometers
            Case "Lat/Long"
                ScaleUnit = MapWindow.Interfaces.UnitOfMeasure.Kilometers
        End Select

        'Lastly, if the floating scale bar unit is set, use that
        If Not frmMain.m_FloatingScalebar_ContextMenu_SelectedUnit = "" Then
            Select Case frmMain.m_FloatingScalebar_ContextMenu_SelectedUnit
                Case MapWindow.Interfaces.UnitOfMeasure.Centimeters.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Centimeters
                Case MapWindow.Interfaces.UnitOfMeasure.Feet.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Feet
                Case MapWindow.Interfaces.UnitOfMeasure.Inches.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Inches
                Case MapWindow.Interfaces.UnitOfMeasure.Kilometers.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Kilometers
                Case MapWindow.Interfaces.UnitOfMeasure.Meters.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Meters
                Case MapWindow.Interfaces.UnitOfMeasure.Miles.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Miles
                Case MapWindow.Interfaces.UnitOfMeasure.Millimeters.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Millimeters
                Case MapWindow.Interfaces.UnitOfMeasure.Yards.ToString()
                    ScaleUnit = Interfaces.UnitOfMeasure.Yards
                Case MapWindow.Interfaces.UnitOfMeasure.DecimalDegrees.ToString()
                    'Disallow showing degrees as a measurement.
                    ScaleUnit = MapWindow.Interfaces.UnitOfMeasure.Kilometers
                Case "Lat/Long"
                    ScaleUnit = MapWindow.Interfaces.UnitOfMeasure.Kilometers
            End Select
        End If
        Return ScaleUnit
    End Function

    Private Sub doSaveScaleBarImage()
        Dim newfilename As String
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.Filter = "Image Files(*.BMP;*.GIF)|*.bmp;*.gif"

        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            newfilename = saveFileDialog1.FileName
        Else
            Exit Sub
        End If

        If newfilename <> "" Then
            Dim sb As New ScaleBarUtility
            Dim img As Image

            Dim mapunit As UnitOfMeasure = UnitOfMeasure.Meters 'default

            If (Not modMain.frmMain.Project.MapUnits = "") Then
                Select Case modMain.frmMain.Project.MapUnits.ToLower()
                    Case "lat/long"
                        mapunit = UnitOfMeasure.DecimalDegrees
                    Case "meters"
                        mapunit = UnitOfMeasure.Meters
                    Case "centimeters"
                        mapunit = UnitOfMeasure.Centimeters
                    Case "feet"
                        mapunit = UnitOfMeasure.Feet
                    Case "inches"
                        mapunit = UnitOfMeasure.Inches
                    Case "kilometers"
                        mapunit = UnitOfMeasure.Kilometers
                    Case "meters"
                        mapunit = UnitOfMeasure.Meters
                    Case "miles"
                        mapunit = UnitOfMeasure.Miles
                    Case "millimeters"
                        mapunit = UnitOfMeasure.Millimeters
                    Case "yards"
                        mapunit = UnitOfMeasure.Yards
                End Select
            End If

            Dim sbunit As UnitOfMeasure = GetScaleUnit()
            If sbunit = UnitOfMeasure.DecimalDegrees Then sbunit = UnitOfMeasure.Meters

            img = sb.GenerateScaleBar(CType(frmMain.MapMain.Extents, MapWinGIS.Extents), mapunit, sbunit, 300, Color.White, Color.Black)
            img.Save(newfilename)
        End If
    End Sub

    Private Sub doSaveNorthArrow()
        Dim newfilename As String
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.Filter = "Image Files(*.BMP;*.GIF)|*.bmp;*.gif"

        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            newfilename = saveFileDialog1.FileName
        Else
            Exit Sub
        End If

        Dim image As System.Drawing.Bitmap
        image = New System.Drawing.Bitmap(Me.GetType, "NorthArrow.ico")

        If newfilename <> "" Then
            image.Save(newfilename)
        End If
    End Sub

    Private Sub doCopyNorthArrow()
        Dim image As System.Drawing.Bitmap
        image = New System.Drawing.Bitmap(Me.GetType, "NorthArrow.png")
        Clipboard.SetDataObject(image)
    End Sub

    Private Sub doCopyScaleBar()
        Dim sb As New ScaleBarUtility
        Dim img As Image

        Dim mapunit As UnitOfMeasure = UnitOfMeasure.Meters 'default

        If (Not modMain.frmMain.Project.MapUnits = "") Then
            Select Case modMain.frmMain.Project.MapUnits.ToLower()
                Case "lat/long"
                    mapunit = UnitOfMeasure.DecimalDegrees
                Case "meters"
                    mapunit = UnitOfMeasure.Meters
                Case "centimeters"
                    mapunit = UnitOfMeasure.Centimeters
                Case "feet"
                    mapunit = UnitOfMeasure.Feet
                Case "inches"
                    mapunit = UnitOfMeasure.Inches
                Case "kilometers"
                    mapunit = UnitOfMeasure.Kilometers
                Case "meters"
                    mapunit = UnitOfMeasure.Meters
                Case "miles"
                    mapunit = UnitOfMeasure.Miles
                Case "millimeters"
                    mapunit = UnitOfMeasure.Millimeters
                Case "yards"
                    mapunit = UnitOfMeasure.Yards
            End Select
        End If

        Dim sbunit As UnitOfMeasure = GetScaleUnit()
        If sbunit = UnitOfMeasure.DecimalDegrees Then sbunit = UnitOfMeasure.Meters

        img = sb.GenerateScaleBar(CType(frmMain.MapMain.Extents, MapWinGIS.Extents), mapunit, sbunit, 300, Color.White, Color.Black)

        Clipboard.SetDataObject(img)
    End Sub

    Private Sub doSaveMapImage()
        Dim newfilename As String
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.Filter = "All Image Types (*.bmp; *.gif; *.jpg)|*.bmp;*.gif;*.jpg|JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|GIF Image (*.gif)|*.gif"

        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            newfilename = saveFileDialog1.FileName
        Else
            Exit Sub
        End If

        Dim image As New MapWinGIS.Image
        Dim success As Boolean
        image = CType(MapMain.SnapShot(MapMain.Extents), MapWinGIS.Image)

        If newfilename <> "" Then
            success = image.Save(newfilename, False, MapWinGIS.ImageType.USE_FILE_EXTENSION)
            'If the save wasn't successful display an error message
            If Not success Then
                MapWinUtility.Logger.Msg("There were errors saving the image.", MsgBoxStyle.Exclamation, "Could Not Save")
                Exit Sub
            End If
        End If

        Try
            image.Close()
            image = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Private Sub doCopyMap()
        'Copies the current map view to the clipboard
        Dim cvter As New MapWinUtility.ImageUtils
        Clipboard.SetDataObject(cvter.IPictureDispToImage(CType(MapMain.SnapShot(MapMain.Extents), MapWinGIS.Image).Picture))
    End Sub

    Private Sub doCopyLegend()
        'Copies the current legend to the clipboard
        Clipboard.SetDataObject(Legend.Snapshot(True, Legend.Width))
        MapMain.Focus()
        Legend.Focus()
    End Sub

    Private Sub doSaveLegend()
        Dim newfilename As String
        Dim saveFileDialog1 As New SaveFileDialog

        saveFileDialog1.Filter = "Image Files(*.BMP;*.GIF)|*.bmp;*.gif"

        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            newfilename = saveFileDialog1.FileName
        Else
            Exit Sub
        End If

        If newfilename <> "" Then
            Legend.Snapshot(True, Legend.Width).Save(newfilename)
            MapMain.Focus()
            Legend.Focus()
        End If
    End Sub

    Private Sub doClose()
        'Closes the current project
        'If Not m_HasBeenSaved Or ProjInfo.Modified Then
        '    If PromptToSaveProject() = MsgBoxResult.Cancel Then
        '        Exit Sub
        '    End If
        'End If
        ProjInfo.ProjectFileName = ""
        frmMain.Layers.Clear()
        frmMain.Legend.Groups.Clear()
        ProjInfo.BookmarkedViews.Clear()
        frmMain.BuildBookmarkedViewsMenu()
        ClearPreview()
        m_AutoVis = New DynamicVisibilityClass
        ResetViewState()
        m_HasBeenSaved = True
        SetModified(False)
    End Sub

    Private Sub doExit()
        'Exit MapWindow
        'save the current configuration
        '---Cho 1/9/2009: MapWindowForm_Closing will take care of this. If we have the following code
        '---here, the user will see the closing dialog twice if he/she answers No.
        'ProjInfo.SaveConfig()
        'If Not m_HasBeenSaved Or ProjInfo.Modified Then
        '    If PromptToSaveProject() = MsgBoxResult.Cancel Then
        '        Exit Sub
        '    End If
        'End If
        Me.Close()
    End Sub

    Private Sub doEditPlugins()
        'Show the plugin manager form
        m_PluginManager.ShowPluginDialog()
    End Sub

    Friend Sub ResetViewState(Optional ByVal LeaveFloatingScalebar As Boolean = False)
        If Not LeaveFloatingScalebar And m_FloatingScalebar_Enabled Then
            m_FloatingScalebar_Enabled = False
            UpdateFloatingScalebar()
        End If

        If AppInfo.MeasuringCurrently Then MeasuringStop()
        If AppInfo.AreaMeasuringCurrently Then AreaMeasuringStop()

        frmMain.MapMain.UDCursorHandle = -1
        frmMain.MapMain.CursorMode = MapWinGIS.tkCursorMode.cmNone
        frmMain.MapMain.MapCursor = MapWinGIS.tkCursor.crsrArrow
        frmMain.UpdateZoomButtons()
    End Sub

    Private Sub doZoomIn()
        MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn
        UpdateZoomButtons()
    End Sub

    Private Sub doZoomOut()
        MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut
        UpdateZoomButtons()
    End Sub

    Private Sub doPreviousZoom()
        If AppInfo.MeasuringCurrently Then MeasuringStop()
        MapMain.ZoomToPrev()
        SetModified(True)
    End Sub

    Private Sub doNextZoom()
        If AppInfo.MeasuringCurrently Then MeasuringStop()
        'todo: add this
    End Sub

    Public Function PreviewMapExtentsValid() As Boolean
        Dim ext As MapWinGIS.Extents = MapPreview.Extents
        If ext.xMin = 0 And ext.xMax = 0 And ext.yMin = 0 And ext.yMax = 0 Then Return False
        Return True
    End Function

    Private Sub doZoomToPreview()
        Dim ext As MapWinGIS.Extents = MapPreview.Extents
        If Not PreviewMapExtentsValid() Then

            MapWinUtility.Logger.Msg("The preview map has not been set." + vbCrLf + vbCrLf + "A preview map may be set up by right-clicking in the Preview Map window and choosing one of the Update options.", MsgBoxStyle.Information, "No Preview Map Set")
        Else
            If AppInfo.MeasuringCurrently Then MeasuringStop()
            MapMain.Extents = MapPreview.Extents
            SetModified(True)
        End If
    End Sub

    Private Sub doZoomToFullExtents()
        MapMain.ZoomToMaxExtents()
        SetModified(True)
        If AppInfo.MeasuringCurrently Then MeasuringStop()
    End Sub

    Private Sub doClearPreview()
        'Clear the preview map
        ClearPreview()
        SetModified(True)
    End Sub

    Private Sub doUpdatePreview(Optional ByVal FullExtents As Boolean = False)
        'Updates the preview map
        m_PreviewMap.GetPictureFromMap(FullExtents)
        SetModified(True)
    End Sub

    Private Sub doProjectSettings()
        'Use the property grid instead of the old dialog to do project settings. 
        'Dim f As New frmProjSettings
        'f.ShowDialog()
        Dim dlg As ProjectSettings = New ProjectSettings
        dlg.ShowDialog()
    End Sub

    Private Sub doPluginNameClick(ByVal PluginKey As String)
        'This sub is called when the user clicks a menu item that was placed on the plugins menu during "SynchPluginMenu"
        '1/25/2005 - dpa
        '3/16/2005 - updated to work off a runtime created plugin parent menu

        If m_PluginManager.PluginIsLoaded(PluginKey) Then
            m_PluginManager.StopPlugin(PluginKey)
            m_Menu("plugin_" & PluginKey).Checked = False
            m_Menu("plugin_" & PluginKey).Picture = GlobalResource.imgPluginDisabled
        Else
            m_PluginManager.StartPlugin(PluginKey)
            m_Menu("plugin_" & PluginKey).Checked = True
            m_Menu("plugin_" & PluginKey).Picture = GlobalResource.imgPlugin
        End If

        'Bugzilla 380 -- Plugins are stored in the project, so a plugin change
        'should set the modified flag.
        SetModified(True)
    End Sub

    Private Sub doContents()
        'Show the help file 
        '1/25/2005 - dpa
        If (System.IO.File.Exists(AppInfo.HelpFilePath)) Then
            System.Diagnostics.Process.Start(AppInfo.HelpFilePath)
        Else
            '7/31/2006 PM
            'mapwinutility.logger.msg("Help file does not exist.", MsgBoxStyle.Exclamation, "Missing help file")
            MapWinUtility.Logger.Msg(resources.GetString("msgHelpfileDoesNotExist"), MsgBoxStyle.Exclamation, "Missing help file")
        End If
    End Sub

    Private Sub doAboutMapWindow()
        'Shows the "about" dialog 
        '1/25/2005 - dpa
        Dim about As New frmAbout
        about.ShowAbout(Me)
    End Sub

    ' Care of Sphextor, MapWindow Phorums: http://www.MapWindow.org/phorum/read.php?3,318,3320#msg-3320
    Private Function GetCurrentScale() As String
        Dim x As Double
        Dim y As Double

        Dim Px1 As Double
        Dim Px2 As Double
        Dim Py As Double

        Dim hDC As Long

        Const LOGPIXELSX As Long = 88
        hDC = GetWindowDC(0)

        ' Map Unit : meter ,
        ' Map Distance : km
        Dim PixPerInch As Double = GetDeviceCaps(hDC, LOGPIXELSX) / 0.0254 ' 96
        x = 1
        y = 1

        MapMain.PixelToProj(x, y, Px1, Py)
        MapMain.PixelToProj(x + PixPerInch, y, Px2, Py)

        Return (Px2 - Px1).ToString()
    End Function

    ' Care of Ted Dunsford of MW team, Shade1974 of MapWindow Phorums: http://www.MapWindow.org/phorum/read.php?3,318,3320#msg-3320
    Private Sub SetScale(ByVal NewScale As String)
        'Scale stored in tbScale
        Dim hDC As IntPtr ' In old VB6 use Long datatype
        Dim center As New MapWinGIS.Point
        Dim ext As MapWinGIS.Extents
        Dim kmHeight, PixelsPerInch, kmPerInch, kmPerPixel, kmWidth As Double
        If Not IsNumeric(NewScale) Then Exit Sub
        'Const LOGPIXELSX As Long ' Long from VBNet causes problems
        Const LOGPIXELSX As Integer = 88
        'Unverified calls to API from original code... no guarantees
        hDC = GetWindowDC(0)
        PixelsPerInch = GetDeviceCaps(hDC, LOGPIXELSX) / 0.0254 ' 96

        'Calculate the center from the current map extents
        ext = MapMain.Extents
        center.x = (ext.xMax + ext.xMin) / 2
        center.y = (ext.yMax + ext.yMin) / 2

        'Convert from our km/inch scale to our  
        kmPerInch = Val(NewScale)
        kmPerPixel = kmPerInch / PixelsPerInch
        'Note in vbNet width is pixel width, in VB6 you may have to set the
        'scale to use pixels instead of twips or other units
        kmWidth = MapMain.Width * kmPerPixel
        kmHeight = (ext.yMax - ext.yMin) * kmWidth / (ext.xMax - ext.xMin)
        '
        ' Wrong -- see below for correct -- described in forum posting http://www.mapwindow.org/phorum/read.php?3,318,7533#msg-7533
        'ext.SetBounds(center.x - kmWidth / 2, center.y - kmHeight / 2, 0, center.x + kmWidth / 2, center.y + Height / 2, 0)
        ext.SetBounds(center.x - kmWidth / 2, center.y - kmHeight / 2, 0, center.x + kmWidth / 2, center.y + kmHeight / 2, 0)

        'Note I wasn't clear whether we were working in meters or km, but the
        'code should work if the same conversion factors worked the other way
        MapMain.Extents = ext
    End Sub

    Private Sub doMapWindowDotCom()
        'Shows MapWindow.org
        '1/25/2005 (dpa)
        Try
            System.Diagnostics.Process.Start("http://www.MapWindow.org")
        Catch ex As System.Exception
            ShowError(ex)
        End Try
    End Sub

    Friend Sub SynchPluginMenu()
        'Clears the list of plug-ins from the plugins menu and then refreshes them.
        '1/25/2005 - dpa - updated
        '3/16/2005 - dpa - changed to work on run-time created plug-in parent menu.
        '10/04/2008 - Earljon Hidalgo - Added dynamic loading of plugin icons
        If Not g_SyncPluginMenuDefer Then
            MapWinUtility.Logger.Dbg("SyncStart")
            Dim ParentMenu As Windows.Forms.ToolStripMenuItem
            Dim ChildMenu As MapWindow.Interfaces.MenuItem
            Dim MenuKey As String
            Dim i As Integer = 0

            ParentMenu = CType(m_Menu.m_MenuTable("mnuPlugins"), Windows.Forms.ToolStripMenuItem)

            Dim alph_PluginList As Hashtable = m_PluginManager.PluginsList
            Dim Names() As String, Keys() As String
            i = 0
            ReDim Names(alph_PluginList.Count - 1)
            ReDim Keys(alph_PluginList.Count - 1)
            Dim ienum As IDictionaryEnumerator = alph_PluginList.GetEnumerator()
            While ienum.MoveNext
                Names(i) = ienum.Value.name
                Keys(i) = ienum.Value.key
                i += 1
            End While

            ' 2 - Sort using a custom IComparer
            MapWinUtility.Logger.Dbg("SyncSort")
            Names.Sort(Names, Keys)

            ' 3 - Now add the plugin menu items at the end of the menu, using the sorted arraylist
            MapWinUtility.Logger.Dbg("SyncAdd")
            For i = 0 To Names.Length - 1
                MenuKey = "plugin_" & Keys(i)

                ' Chris Michaelis June 30 2005 - allow a plug-in
                ' to specify that it belongs in a submenu of the plugins menu
                ' via the syntax "Subcategory::Plugin Name" as the plugin name string.
                ' Chris Michaelis May 2008 - allow multiple levels of menus

                ' Earljon Hidalgo Oct 04 2008 - Added dynamic icon menu loading
                ' based on the state of plugin (enabled, disabled and/or belongs to
                ' a submenu
                Try
                    Dim WorkingName As String = Names(i)
                    Dim subCat As String = ""
                    Dim LastMenu As String = "mnuPlugins"
                    Dim oPicture As New Object
                    Dim bPluginState As Boolean
                    While InStr(WorkingName, "::") > 0
                        subCat = "subcat_" + WorkingName.Substring(0, InStr(WorkingName, "::"))
                        oPicture = GlobalResource.imgPluginSub
                        If Not m_Menu.Contains(subCat) Then m_Menu.AddMenu(subCat, LastMenu, oPicture, WorkingName.Substring(0, InStr(WorkingName, "::") - 1))
                        LastMenu = subCat
                        'Move to next segment (or final segment wo/ ::)
                        WorkingName = WorkingName.Substring(InStr(WorkingName, "::") + 1)
                    End While

                    bPluginState = m_PluginManager.PluginIsLoaded(Keys(i))
                    oPicture = IIf(bPluginState = True, GlobalResource.imgPlugin, GlobalResource.imgPluginDisabled)
                    If Not subCat = "" Then
                        ChildMenu = m_Menu.AddMenu(MenuKey, subCat, oPicture, WorkingName)
                    Else
                        'There were no submenus requested
                        ChildMenu = m_Menu.AddMenu(MenuKey, "mnuPlugins", oPicture, Names(i))
                    End If

                    ChildMenu.Checked = bPluginState
                    ChildMenu.Picture = oPicture

                Catch ex As Exception
                    MapWinUtility.Logger.Msg(ex.ToString())
                End Try
            Next
            MapWinUtility.Logger.Dbg("SyncDone")

            MapWinUtility.Logger.Dbg("Ensuring Help menu is last...")
            m_Menu.EnsureHelpItemLast()
        End If
    End Sub

    Private Sub PreviewMapContextMenuStrip_UpdatePreview(ByVal sender As Object, ByVal e As System.EventArgs)
        doUpdatePreview()
    End Sub
    Private Sub PreviewMapContextMenuStrip_UpdatePreviewFull(ByVal sender As Object, ByVal e As System.EventArgs)
        doUpdatePreview(True)
    End Sub

    Private Sub PreviewMapContextMenuStrip_ClearPreview(ByVal sender As Object, ByVal e As System.EventArgs)
        doClearPreview()
    End Sub

    Friend Sub CustomMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'This sub is called when the user clicks a menu item that was placed on the 
        'main menu by a plugin
        '1/30/2005 - dpa - updated
        '3/16/2005 - dpa - using this event for regular menu clicks as well now (e.g. file/new)

        Dim item As ToolStripItem = CType(sender, ToolStripItem)
        HandleClickedMenu(item.Name)
    End Sub

    Public Sub HandleClickedMenu(ByVal MenuName As String)
        'First see if it is a plugin name menu
        If MenuName.StartsWith("plugin_") = True Then
            doPluginNameClick(MenuName.Substring(7))
            Exit Sub
        End If

        'send the click event to all the plugins
        If Not (m_PluginManager.ItemClicked(MenuName)) Then

            'If we get here, then the menu click event was not handled by a plug-in 
            'so we will try to handle it here.  For example in the case of File/New the
            'plugin could handle this click, if so then we don't get to this point.
            'If no plugin handles File/New, then we'll do it.

            Select Case MenuName
                'help menus - do these first so that the logic about keeping help at the
                'end of the menu list works.
                Case "mnuOnlineDocs"
                    System.Diagnostics.Process.Start("http://www.MapWindow.org/wiki")
                Case "mnuOfflineDocs"
                    System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\OfflineDocs\index.html")
                Case "mnuContents" : doContents()
                Case "mnuWelcomeScreen" : ShowWelcomeScreen()
                Case "mnuAboutMapWindow" : doAboutMapWindow()
                Case "mnuMapWindowDotCom" : doMapWindowDotCom()
                Case "mnuLegendVisible"
                    If m_Menu.Item("mnuLegendVisible").Checked Then
                        legendPanel.Close()
                        m_Menu.Item("mnuLegendVisible").Checked = False
                    Else
                        CreateLegendPanel()
                    End If
                Case "mnuPreviewVisible"
                    If m_Menu.Item("mnuPreviewVisible").Checked Then
                        previewPanel.Close()
                        m_Menu.Item("mnuPreviewVisible").Checked = False
                    Else
                        CreatePreviewPanel()
                    End If
                Case "mnuNew" : DoNew()
                Case "mnuOpen" : DoOpen()
                Case "mnuOpenProjectIntoGroup" : DoOpenIntoCurrent()
                Case "mnuSave" : DoSave()
                Case "mnuSaveAs" : DoSaveAs()
                Case "mnuPrint" : DoPrint()
                Case "mnuProjectSettings" : doProjectSettings()
                Case "mnuClose" : doClose()
                Case "mnuCheckForUpdates" : CheckForUpdates()
                Case "mnuExit" : doExit()

                    'edit menus
                Case "mnuCopyMap" : doCopyMap()
                Case "mnuCopyLegend" : doCopyLegend()
                Case "mnuSaveLegend" : doSaveLegend()

                Case "mnuCopyScaleBar" : doCopyScaleBar()
                Case "mnuCopyNorthArrow" : doCopyNorthArrow()
                Case "mnuSaveMapImage" : doSaveMapImage()
                Case "mnuSaveNorthArrow" : doSaveNorthArrow()
                Case "mnuSaveScaleBar" : doSaveScaleBarImage()

                Case "mnuSaveGeorefMapImage" : doSaveGeoreferenced()
                Case "mnuUpdatePreviewFull" : doUpdatePreview(True)
                Case "mnuUpdatePreviewCurr" : doUpdatePreview()
                Case "mnuClearPreview" : doClearPreview()

                    'view menus
                Case "mnuAddLayer" : DoAddLayer()
                Case "mnuRemoveLayer" : DoRemoveLayer()
                Case "mnuClearLayers" : DoClearLayers()
                Case "mnuClearSelectedShapes" : DoClearSelection()
                Case "mnuShowScaleBar" : DoToggleScalebar()
                Case "mnuSetScale" : doSetScale()

                    'CDM 4/7/2006 - Also catch the one on the View menu. It has been
                    'renamed to properly say "Clear LayerS", plural, that is, note the S on the end.
                Case "mnuClearLayer" : DoClearLayers()

                Case "mnuZoomToPreviewExtents" : doZoomToPreview()
                Case "mnuZoomPreviewMap" : doZoomToPreview()
                Case "mnuZoomIn" : doZoomIn()
                Case "mnuZoomOut" : doZoomOut()
                Case "mnuZoomToFullExtents" : doZoomToFullExtents()
                Case "mnuPreviousZoom" : doPreviousZoom()
                Case "mnuNextZoom" : doNextZoom()

                    'plugins menus
                Case "mnuEditPlugins" : doEditPlugins()

                Case "mnuBookmarkView"
                    'Chris Michaelis May 14 2007

                    'TODO These strings will need to be localized eventually by those
                    'who speak all of the localized languages.
                    Dim newName As String = InputBox("Please enter a new name for the bookmark:", "New Bookmark", "Bookmark " + (ProjInfo.BookmarkedViews.Count + 1).ToString())
                    If Not newName.Trim() = "" Then
                        ProjInfo.BookmarkedViews.Add(New XmlProjectFile.BookmarkedView(newName, MapMain.Extents))
                        modMain.frmMain.SetModified(True)
                        BuildBookmarkedViewsMenu()
                    End If
                Case "mnuBookmarkDelete"
                    'Chris Michaelis May 14 2007

                    'Note that project modified flag is set on actual deletion in the form.
                    If ProjInfo.BookmarkedViews.Count > 0 Then
                        Dim delform As New frmBookmarkedViewDelete()
                        delform.ShowDialog()
                        BuildBookmarkedViewsMenu()
                    Else
                        MapWinUtility.Logger.Msg("There are no bookmarked views to delete.", MsgBoxStyle.Information, "No Bookmarked Views")
                    End If
                Case "mnuBookmarkedViews"
                    'No action needed

                Case "mnuScript"
                    'Chris Michaelis Jan 1 2006 - Adapted from the script system written
                    'by Mark Gray of AquaTerra.
                    If Scripts Is Nothing Or Scripts.IsDisposed Then
                        Scripts = New frmScript
                    End If
                    Scripts.Show()

                Case "mnuShortcuts"
                    '7/31/2006 PM
                    'mapwinutility.logger.msg("The following keyboard shortcuts are available:" + vbCrLf + vbCrLf + _
                    '    "Del - Remove the currently selected layer." + vbCrLf + _
                    '    "Ins - Add a layer." + vbCrLf + vbCrLf + _
                    '    "Ctrl-S - Save the project." + vbCrLf + _
                    '    "Ctrl-O - Open a project." + vbCrLf + _
                    '    "Ctrl-C - Copy a map snapshot to the clipboard." + vbCrLf + _
                    '    "Ctrl-P - Open the Print Preview window." + vbCrLf + _
                    '    "Ctrl-F4 - Close the current project." + vbCrLf + vbCrLf + _
                    '    "Home - Zoom to Full Extents" + vbCrLf + _
                    '    "Ctrl-Home - Zoom to Selected Layer" + vbCrLf + _
                    '    "Plus - Zoom in on center of map, 25%" + vbCrLf + _
                    '    "Minus - Zoom out on center of map, 25%" + vbCrLf + vbCrLf + _
                    '    "Page-Up - Pan Up (50% of View)" + vbCrLf + _
                    '    "Page-Down - Pan Down (50% of View)" + vbCrLf + _
                    '    "Up Arrow - Pan Up (25% of View)" + vbCrLf + _
                    '    "Down Arrow - Pan Down (25% of View)" + vbCrLf + _
                    '    "Left Arrow - Pan Left (25% of View)" + vbCrLf + _
                    '    "Right Arrow - Pan Right (25% of View)", _
                    '    MsgBoxStyle.Information, AppInfo.Name)
                    Dim strMessage As String
                    strMessage = resources.GetString("msgShortcutsTitle.Text") + vbCrLf + vbCrLf + _
                                 resources.GetString("msgShortcutsDel.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsIns.Text") + vbCrLf + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlS.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlO.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlC.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlP.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlI.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlH.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlF4.Text") + vbCrLf + vbCrLf + _
                                 resources.GetString("msgShortcutsHome.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlHome.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsPlus.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsMinus.Text") + vbCrLf + vbCrLf + _
                                 resources.GetString("msgShortcutsPageUp.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsPageDown.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsArrowUp.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsArrowDown.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsArrowLeft.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsArrowRight.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlShiftI.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlShiftO.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlShiftP.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlSpace.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlArrows.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsCtrlEnter.Text") + vbCrLf + _
                                 resources.GetString("msgShortcutsBackspace.Text")

                    doNonModalMessageBox(strMessage, MsgBoxStyle.Information, "Keyboard Shortcuts")
                Case Else
                    If MenuName.StartsWith(BookmarkedViewPrefix) Then
                        'Zoom to this view
                        Dim sViewNumber As String = MenuName.Replace(BookmarkedViewPrefix, "")
                        Dim iViewNumber As Integer = -1
                        If Integer.TryParse(sViewNumber, iViewNumber) AndAlso Not iViewNumber = -1 Then
                            MapMain.Extents = ProjInfo.BookmarkedViews(iViewNumber).Exts
                            SetModified(True)
                        Else
                            MapWinUtility.Logger.Msg("The bookmarked view was not recognized.", MsgBoxStyle.Exclamation, "Unable to Find Bookmark")
                        End If

                    ElseIf MenuName.StartsWith(RecentProjectPrefix) Then
                        'Load a recent project

                        'Chris Michaelis, Bugzilla 319
                        If Not m_HasBeenSaved Or ProjInfo.Modified Then
                            If PromptToSaveProject() = MsgBoxResult.Cancel Then
                                Exit Sub
                            End If
                        End If

                        'Chris Michaelis June 30 2005, also see BuildRecentProjectsMenu
                        If Not Project.Load(MenuName.Substring(RecentProjectPrefix.Length).Replace("{32}", " ")) Then
                            MapWinUtility.Logger.Msg("Could not load " & MenuName.Substring(RecentProjectPrefix.Length), MsgBoxStyle.OkOnly, "Recent Project")
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub DoClearSelection()
        View.SelectedShapes.ClearSelectedShapes()
        frmMain.Menus("mnuClearSelectedShapes").Enabled = False
    End Sub

    Private Sub mnuBtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBtnAdd.Click
        mnuBtnAdd.Checked = True
        mnuBtnRemove.Checked = False
        mnuBtnClear.Checked = False
        tlbMain.Items(5).ImageIndex = 21 ' "add layer" picture
        DoAddLayer()
    End Sub

    Private Sub mnuBtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBtnRemove.Click
        mnuBtnAdd.Checked = False
        mnuBtnRemove.Checked = True
        mnuBtnClear.Checked = False
        'Used to change the picture on the dropdown to indicate the last used
        tlbMain.Items(5).ImageIndex = 23 ' "remove layer" picture
        DoRemoveLayer()
    End Sub

    Private Sub mnuBtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBtnClear.Click
        mnuBtnAdd.Checked = False
        mnuBtnRemove.Checked = False
        mnuBtnClear.Checked = True
        'Used to change the picture on the dropdown to indicate the last used
        tlbMain.Items(5).ImageIndex = 22 ' "clear layers" picture
        DoClearLayers()
    End Sub

#End Region

#Region "General Functions"

    Friend Sub ClearPreview()
        frmMain.MapPreview.ClearDrawings()
        frmMain.MapPreview.RemoveAllLayers()
        UpdateZoomButtons()
    End Sub

    Public Sub InitializeVars()
        'This used to be done as part of the frmMain "New" stuff.  However, this
        'helped MapWindow be very slow to load.  Instead, it is now (in version 4) 
        'in a separate function that can be called once, and partly obscurred by a 
        'splash screen.

        If frmMain.mapPanel Is Nothing Then frmMain.CreateMapPanel()
        If frmMain.previewPanel Is Nothing Then frmMain.CreatePreviewPanel()

        m_Project = New Project
        m_layers = New Layers
        m_View = New View
        m_Menu = New Menus
        m_PreviewMap = New PreviewMap
        m_Toolbar = New Toolbar
        m_PluginManager = New PluginTracker
        m_HasBeenSaved = True
        m_Extents = New ArrayList
        m_StatusBar = New MapWindow.StatusBar
        m_Reports = New MapWindow.Reports
        m_UIPanel = New MapWindow.clsUIPanel
        PreviewMap.LocatorBoxColor = System.Drawing.Color.Red
        m_Labels = New LabelClass
        m_AutoVis = New DynamicVisibilityClass
        g_PreviewMapProp = New BarsProperties
        g_LegendProp = New BarsProperties
        m_CurrentExtent = -1
        m_IsManualExtentsChange = False

        frmMain.SetUpMenus()    'Creates all of the menus

        ' Scan for plugins
        ' Extra call - this will be called when the config file loads - m_PluginManager.LoadApplicationPlugins(AppInfo.ApplicationPluginDir)
        m_PluginManager.LoadPlugins()

        'Initialize preview map settings - force redraw
        MapPreview.CursorMode = MapWinGIS.tkCursorMode.cmNone
        MapPreview.MapCursor = MapWinGIS.tkCursor.crsrArrow
        MapPreview.SendMouseDown = True
        MapPreview.SendMouseMove = True
        MapPreview.SendMouseUp = True
        MapPreview.SendSelectBoxDrag = False
        MapPreview.SendSelectBoxFinal = False

        'CDM 1/22/06 - The preview map depends on the old-style behavior
        MapPreview.MapResizeBehavior = MapWinGIS.tkResizeBehavior.rbClassic

        UpdateZoomButtons()

        'save all menus and toolbars
        XmlProjectFile.SaveMainToolbarButtons()

        MapMain.Focus()

        Me.KeyPreview = True

        'Default start mode:
        tbbZoomIn.Checked = True
    End Sub

    'Prints a simple layout
    'This is called by a menu click and a button click.
    Private Sub DoPrint()
        If MapMain.NumLayers = 0 Then
            MsgBox("Please add data to the map before printing.", MsgBoxStyle.Information, "Add Data First")
            Return
        End If

        Dim printForm As New frmPrintSidebarLayout
        printForm.ShowDialog()
    End Sub

    Private Sub DoNew()
        'Starts a new project                    
        If Not m_HasBeenSaved Or ProjInfo.Modified Then
            If PromptToSaveProject() = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        ProjInfo.m_MapUnits = "" 'reset map data units. 22/2/2008 by Jiri Kadlec for bug 680
        ProjInfo.ProjectFileName = ""
        m_FloatingScalebar_Enabled = False
        UpdateFloatingScalebar()
        frmMain.Layers.Clear()
        frmMain.Legend.Groups.Clear()
        ProjInfo.BookmarkedViews.Clear()
        frmMain.BuildBookmarkedViewsMenu()
        ClearPreview()
        m_PointImageSchemes.Clear()
        m_FillStippleSchemes.Clear()
        SetModified(False)

        ProjInfo.SaveConfig() 'Save any configuration-level changes before we reload the config. 3/23/2006 by CDM for bug 102

        ProjInfo.LoadConfig(True)

        ResetViewState()
    End Sub

    Public Sub DoOpenIntoCurrent(Optional ByVal Filename As String = "")
        If Filename = "" Then
            Dim cdlOpen As New OpenFileDialog
            cdlOpen.Filter = "MapWindow Project (*.mwprj)|*.mwprj"

            If (System.IO.Directory.Exists(AppInfo.DefaultDir)) Then
                cdlOpen.InitialDirectory = AppInfo.DefaultDir
            End If
            If Not cdlOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then Return
            Filename = cdlOpen.FileName
        End If

        If System.IO.File.Exists(Filename) Then
            AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(Filename)

            'Load the project into the current project (the first true)
            'with the group name matching the project filename sans .mwprj
            'Chris Michaelis, BugZilla 368
            ProjInfo.LoadProject(Filename, True, System.IO.Path.GetFileNameWithoutExtension(Filename))

            m_HasBeenSaved = False
            SetModified(False)
        End If
    End Sub

    Private Sub DoOpen()
        'Opens an existing project or opens a layer into the current project.

        'dpa 3/10/2008 - adding layer types to open dialog so that confused people can easily open a single layer.

        Dim cdlOpen As New OpenFileDialog

        Dim gr As New MapWinGIS.Grid
        Dim im As New MapWinGIS.Image
        Dim sf As New MapWinGIS.Shapefile
        Dim LayerFilters As String = gr.CdlgFilter & "|" & im.CdlgFilter & "|" & sf.CdlgFilter
        gr = Nothing : im = Nothing : sf = Nothing
        cdlOpen.Filter = "MapWindow Project (*.mwprj)|*.mwprj" & "|" & LayerFilters

        'check to see if they want to save the project
        If Not m_HasBeenSaved Or ProjInfo.Modified Then
            If PromptToSaveProject() = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        'open a new project
        If (System.IO.Directory.Exists(AppInfo.DefaultDir)) Then
            cdlOpen.InitialDirectory = AppInfo.DefaultDir
        End If
        cdlOpen.ShowDialog()

        If System.IO.File.Exists(cdlOpen.FileName) Then
            'save the location of the last open dir
            AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(cdlOpen.FileName)

            If System.IO.Path.GetExtension(cdlOpen.FileName) = ".mwprj" Then
                ProjInfo.ProjectFileName = cdlOpen.FileName
                ProjInfo.LoadProject(cdlOpen.FileName)

                m_HasBeenSaved = True
                ProjInfo.ProjectFileName = cdlOpen.FileName
                SetModified(False)
            Else
                'a layer was selected (not a project file)
                If Not m_layers.AddLayer(cdlOpen.FileName, System.IO.Path.GetFileNameWithoutExtension(cdlOpen.FileName), , MapWindow.Layers.GetDefaultLayerVis, , , , , , , , True) Is Nothing Then
                    'Set the modified flag if successful
                    SetModified(True)
                End If
            End If
        End If
    End Sub

    Private Sub DoSave()
        'Saves the current project
        Try
            ' this looks like a bunch of changes in a diff, but it's not (tws 6/27/07)
            Dim cdlSave As New SaveFileDialog
            cdlSave.Filter = "MapWindow Project (*.mwprj)|*.mwprj"
            If Not m_HasBeenSaved Or ProjInfo.ProjectFileName = String.Empty Then
                cdlSave.InitialDirectory = AppInfo.DefaultDir
                If (cdlSave.ShowDialog = DialogResult.Cancel) Then Exit Sub

                If (System.IO.Path.GetExtension(cdlSave.FileName) <> ".mwprj") Then
                    cdlSave.FileName &= ".mwprj"
                End If
                ProjInfo.ProjectFileName = cdlSave.FileName
                Me.Cursor = Cursors.WaitCursor
                If (ProjInfo.SaveProject()) Then
                    m_HasBeenSaved = True
                    ProjInfo.ProjectFileName = cdlSave.FileName
                    SetModified(False)
                End If
            Else
                Me.Cursor = Cursors.WaitCursor
                If (ProjInfo.SaveProject()) Then
                    m_HasBeenSaved = True
                    SetModified(False)
                End If
            End If
        Finally ' exceptions still propagate up, but we will NEVER leave the hourglass on
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DoSaveAs()
        'Saves the project under a new file name
        Dim cdlSave As New SaveFileDialog
        cdlSave.Filter = "MapWindow Project (*.mwprj)|*.mwprj"
        If (cdlSave.ShowDialog = DialogResult.Cancel) Then Exit Sub

        If (System.IO.Path.GetExtension(cdlSave.FileName) <> ".mwprj") Then
            cdlSave.FileName &= ".mwprj"
        End If

        ProjInfo.ProjectFileName = cdlSave.FileName
        If (ProjInfo.SaveProject()) Then
            m_HasBeenSaved = True
            ProjInfo.ProjectFileName = cdlSave.FileName
            SetModified(False)
        End If
    End Sub

    Private Sub DoAddLayer()
        'Adds a layer to the map
        If Not m_layers.AddLayer(, , , MapWindow.Layers.GetDefaultLayerVis, , , , , , , , True) Is Nothing Then
            'Set the modified flag if successful
            SetModified(True)
        End If
    End Sub

    Private Sub DoRemoveLayer()
        'Removes a layer from the map
        '1/25/2005 - dpa
        Dim curHandle As Integer = Legend.SelectedLayer
        If curHandle <> -1 Then
            m_layers.Remove(curHandle)
            Legend.Refresh()
            SetModified(True)
        End If
    End Sub

    Private Sub DoClearLayers()
        'Clear all layers from the map
        '1/25/2005 - dpa
        '13/10/2005 - PM
        'If mapwinutility.logger.msg("Are you sure you want to remove all layers?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm remove all layers") = MsgBoxResult.Yes Then
        If MapWinUtility.Logger.Msg(resources.GetString("msgClearLayers.Text"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, resources.GetString("titleClearLayers.Text")) = MsgBoxResult.Yes Then
            m_layers.Clear()
            Legend.Layers.Clear()

            'Prevent asking if you want to save an empty project. CDM 2/22/2006
            SetModified(False)
        End If
    End Sub

    Friend Function PromptToSaveProject() As MsgBoxResult
        '1/31/2005 Modified this to read like the equivalent MS Word dialog. 
        Dim cdlSave As New SaveFileDialog
        Dim Result As MsgBoxResult

        cdlSave.Filter = "MapWindow Project (*.mwprj)|*.mwprj"
        If System.IO.Path.GetFileNameWithoutExtension(ProjInfo.ProjectFileName) = "" Then
            '13/10/2005 - PM
            'Result = mapwinutility.logger.msg("Do you want to save the changes to this project?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Exclamation, AppInfo.Name)
            Result = MapWinUtility.Logger.Msg(resources.GetString("msgSaveProject1.Text") & resources.GetString("msgSaveProject2.Text"), MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Exclamation, AppInfo.Name)
        Else
            '13/10/2005 - PM
            'Result = mapwinutility.logger.msg("Do you want to save the changes to " & System.IO.Path.GetFileNameWithoutExtension(ProjInfo.ProjectFileName) & "?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Exclamation, AppInfo.Name)
            Result = MapWinUtility.Logger.Msg(resources.GetString("msgSaveProject1.Text") & System.IO.Path.GetFileNameWithoutExtension(ProjInfo.ProjectFileName) & "?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Exclamation, AppInfo.Name)
        End If

        Select Case Result
            Case MsgBoxResult.Yes
                If m_HasBeenSaved = True And MapWinUtility.Strings.IsEmpty(ProjInfo.ProjectFileName) = False Then
                    ProjInfo.SaveProject()
                    m_HasBeenSaved = True
                    SetModified(False)
                Else
                    cdlSave.InitialDirectory = AppInfo.DefaultDir
                    If cdlSave.ShowDialog() = DialogResult.Cancel Then Return MsgBoxResult.Cancel

                    If (System.IO.Path.GetExtension(cdlSave.FileName) <> ".mwprj") Then
                        cdlSave.FileName &= ".mwprj"
                    End If
                    ProjInfo.ProjectFileName = cdlSave.FileName
                    ProjInfo.SaveProject()
                    m_HasBeenSaved = True
                    ProjInfo.ProjectFileName = cdlSave.FileName
                    SetModified(False)
                End If
                Return MsgBoxResult.Yes
            Case MsgBoxResult.Cancel
                Return MsgBoxResult.Cancel
            Case MsgBoxResult.No
                Return MsgBoxResult.No
        End Select
    End Function

    Public Sub SetModified(ByVal Status As Boolean)
        'Sets the "modified" status of the current project, 
        'changing the ProjInfo object and the caption of the form.
        'Modified for version 4 to use the projinfo object.

        ' cdm 11/12/2006 - prevent setting modified if there are no layers and the filename is empty
        If Not ProjInfo Is Nothing AndAlso ((ProjInfo.ProjectFileName Is Nothing OrElse ProjInfo.ProjectFileName.Trim() = "") And frmMain.MapMain.NumLayers = 0) Then
            Status = False
        End If

        ProjInfo.Modified = Status

        ' cdm 7/11/05 - added custom window title option support
        If MapWinUtility.Strings.IsEmpty(ProjInfo.ProjectFileName) Then
            'Version Numbers: frmMain.Text = AppInfo.Name + " " + App.VersionString + CType(IIf(CustomWindowTitle = "", "", " - " + CustomWindowTitle), String) + CType(IIf(Status, "*", ""), String)
            frmMain.Text = AppInfo.Name + " " + CType(IIf(CustomWindowTitle = "", "", " - " + CustomWindowTitle), String) + CType(IIf(Status, "*", ""), String)
        Else
            'Version Numbers: frmMain.Text = AppInfo.Name + " " + App.VersionString + CType(IIf(CustomWindowTitle = "", "", " - " + CustomWindowTitle), String) + " - " + CType(IIf(frmMain.Title_ShowFullProjectPath, ProjInfo.ProjectFileName, System.IO.Path.GetFileNameWithoutExtension(ProjInfo.ProjectFileName)), String) + CType(IIf(Status, "*", ""), String)
            frmMain.Text = AppInfo.Name + " " + CType(IIf(CustomWindowTitle = "", "", " - " + CustomWindowTitle), String) + " - " + CType(IIf(frmMain.Title_ShowFullProjectPath, ProjInfo.ProjectFileName, System.IO.Path.GetFileNameWithoutExtension(ProjInfo.ProjectFileName)), String) + CType(IIf(Status, "*", ""), String)
        End If
    End Sub

    Private Function InBox(ByVal rect As Rectangle, ByVal x As Double, ByVal y As Double) As Boolean
        If x >= rect.Left AndAlso x <= rect.Right AndAlso y <= rect.Bottom AndAlso y >= rect.Top Then Return True
    End Function

    Private Function Dist(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double) As Double
        Return (Math.Sqrt((x2 - x1) ^ 2 + (y2 - y1) ^ 2))
    End Function

    Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)
        If MapMain.Focused = False Then Exit Sub

        If AppInfo.MouseWheelZoom = MouseWheelZoomDir.NoAction Then Exit Sub

        If e.Delta > 0 Then
            If AppInfo.MouseWheelZoom = MouseWheelZoomDir.WheelUpZoomsIn Then
                m_View.ZoomIn(m_View.ZoomPercent)
            Else
                m_View.ZoomOut(m_View.ZoomPercent)
            End If
            SetModified(True)
        ElseIf e.Delta < 0 Then
            If AppInfo.MouseWheelZoom = MouseWheelZoomDir.WheelUpZoomsIn Then
                m_View.ZoomOut(m_View.ZoomPercent)
            Else
                m_View.ZoomIn(m_View.ZoomPercent)
            End If
            SetModified(True)
        End If
    End Sub

    Public Sub ShowErrorDialog(ByVal ex As System.Exception) Implements MapWindow.Interfaces.IMapWin.ShowErrorDialog
        ShowError(ex, "root@mapwindow.org")
    End Sub

    Public Sub ShowErrorDialog(ByVal ex As System.Exception, ByVal sendToEmail As String) Implements MapWindow.Interfaces.IMapWin.ShowErrorDialog
        ShowError(ex, sendToEmail)
    End Sub

    Public Function GetProjectionFromUser(ByVal DialogCaption As String, ByVal DefaultProjection As String) As String Implements Interfaces.IMapWin.GetProjectionFromUser
        Dim projDialog As New frmProjectionDialog
        projDialog.SetCaptionText(DialogCaption)
        projDialog.SetProjection(DefaultProjection)

        projDialog.ShowDialog()

        Dim retval As String = ""
        If projDialog.DialogResult = DialogResult.OK Then
            retval = projDialog.GetProjection()
        End If

        projDialog.Close()
        projDialog.Dispose()
        Return retval
    End Function

    Public Sub RefreshMap() Implements Interfaces.IMapWin.Refresh
        For i As Integer = 0 To frmMain.m_layers.NumLayers - 1
            If Not frmMain.m_layers(frmMain.m_layers.GetHandle(i)).FillStippleScheme Is Nothing Then
                frmMain.m_layers(frmMain.m_layers.GetHandle(i)).HatchingRecalculate()
            End If
        Next
        frmMain.MapMain.Redraw()
    End Sub

    Private Sub FlushForwardHistory()
        Dim i As Integer
        If m_Extents.Count > 0 Then
            If m_CurrentExtent < m_Extents.Count - 1 Then
                'm_Extents.RemoveRange(m_CurrentExtent + 1, m_Extents.Count - m_CurrentExtent)
                For i = m_Extents.Count - 1 To m_CurrentExtent + 1 Step -1
                    m_Extents.RemoveAt(i)
                Next i
            Else
                m_CurrentExtent = m_Extents.Count - 1
            End If
        End If
    End Sub

#End Region

    Private Sub Legend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Legend.Load
    End Sub

    Public Function FindMaxVisibleExtents() As MapWinGIS.Extents
        Dim tExts As New MapWinGIS.Extents
        Dim bFoundVisibleLayer As Boolean
        Dim maxX, maxY, minX, minY As Double
        Dim i As Integer
        Dim dx, dy As Double

        For i = 0 To frmMain.MapMain.NumLayers - 1
            If frmMain.MapMain.get_LayerVisible(frmMain.MapMain.get_LayerHandle(i)) = True Then
                tExts = frmMain.Layers(frmMain.MapMain.get_LayerHandle(i)).Extents
                With tExts
                    If bFoundVisibleLayer = False Then
                        maxX = .xMax
                        minX = .xMin
                        maxY = .yMax
                        minY = .yMin
                        bFoundVisibleLayer = True
                    Else
                        If .xMax > maxX Then maxX = .xMax
                        If .yMax > maxY Then maxY = .yMax
                        If .xMin < minX Then minX = .xMin
                        If .yMin < minY Then minY = .yMin
                    End If
                End With
            End If
        Next i

        ' Pad extents now
        dx = maxX - minX
        dx = dx * frmMain.MapMain.ExtentPad
        maxX = maxX + dx
        minX = minX - dx

        dy = maxY - minY
        dy = dy * frmMain.MapMain.ExtentPad
        maxY = maxY + dy
        minY = minY - dy

        tExts = New MapWinGIS.Extents
        tExts.SetBounds(minX, minY, 0, maxX, maxY, 0)
        Return tExts
    End Function

    Public Sub BuildRecentProjectsMenu()
        '3/17/05 mg
        Dim i As Integer
        Dim filename As String
        Dim key As String
        Dim keysToRemove As New ArrayList

        'Find RecentProject menu items to remove
        'note: cannot remove within For Each, so we remove them next
        For Each key In m_Menu.m_MenuTable.Keys
            If key.StartsWith(RecentProjectPrefix) Then
                keysToRemove.Add(key)
            End If
        Next

        For Each key In keysToRemove
            m_Menu.Remove(key)
        Next

        'Add all current ProjInfo.RecentProjects to the menu
        For i = 0 To ProjInfo.RecentProjects.Count - 1
            filename = Trim(ProjInfo.RecentProjects(i).ToString)
            If Not filename = "" And Not filename = ".mwprj" Then
                ' Chris Michaelis June 30 2005 -- when a path with spaces gets put here, the spaces get cut out when it's turned into a key.
                ' Replacing the space with {32}, the ascii code for space. Also see CustomMenu_Click which does the reverse.
                key = RecentProjectPrefix & filename.Replace(" ", "{32}")
                m_Menu.AddMenu(key, "mnuRecentProjects", Nothing, System.IO.Path.GetFileNameWithoutExtension(filename))
            End If
        Next
    End Sub

    Public Function CreatePreviewPanel() As WeifenLuo.WinFormsUI.Docking.DockContent
        previewPanel = New clsMWDockPanel("Preview Map")
        previewPanel.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Float
        previewPanel.Controls.Add(MapPreview)
        '2/19/08 LCW: added icon to tab and added icon to resources
        previewPanel.Icon = New System.Drawing.Icon(Me.GetType, "MapPanel.ico")
        MapPreview.Dock = DockStyle.Fill

        ' Chris M -- Workaround for BugZilla 277:
        'Show -- cause a flicker. We want this flicker -f it creates a valid
        'activex state.

        previewPanel.Show(dckPanel, WeifenLuo.WinFormsUI.Docking.DockState.Float)

        If legendPanel Is Nothing OrElse legendPanel.DockPanel() Is Nothing Then
            previewPanel.Show(dckPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
        Else
            previewPanel.Show(legendPanel.DockPanel(), WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
            previewPanel.DockTo(legendPanel.Pane, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft, 0)
        End If

        If Not m_Menu Is Nothing Then m_Menu.Item("mnuPreviewVisible").Checked = True
        AddHandler previewPanel.FormClosing, AddressOf DockedPanelClosing
        Return previewPanel
    End Function

    Public Function CreateLegendPanel() As WeifenLuo.WinFormsUI.Docking.DockContent
        legendPanel = New clsMWDockPanel("Legend")
        legendPanel.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Float
        legendPanel.Controls.Add(Legend)
        '2/19/08 LCW: added icon to tab and added icon to resources (borrowed from MapWinInterfaces)
        legendPanel.Icon = New System.Drawing.Icon(Me.GetType, "MapWinLegend.ico")

        If previewPanel Is Nothing OrElse previewPanel.DockPanel() Is Nothing Then
            legendPanel.Show(dckPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
        Else
            legendPanel.Show(previewPanel.DockPanel(), WeifenLuo.WinFormsUI.Docking.DockState.DockLeft)
            previewPanel.DockTo(legendPanel.Pane, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft, 0)
        End If

        If Not m_Menu Is Nothing Then m_Menu.Item("mnuLegendVisible").Checked = True
        AddHandler legendPanel.FormClosing, AddressOf DockedPanelClosing
        Return legendPanel
    End Function

    Public Function CreateMapPanel() As WeifenLuo.WinFormsUI.Docking.DockContent
        mapPanel = New clsMWDockPanel("Map View")
        mapPanel.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Float
        mapPanel.Controls.Add(MapMain)
        mapPanel.Show(dckPanel, WeifenLuo.WinFormsUI.Docking.DockState.Float)
        mapPanel.DockState = WeifenLuo.WinFormsUI.Docking.DockState.Document
        AddHandler mapPanel.FormClosing, AddressOf DockedPanelClosing
        Return mapPanel
    End Function

    Private Sub DockedPanelClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        'TODO PM Are these text still available after localization?
        If sender.text = "Map View" Then
            e.Cancel = True
            'Disallow closing of this.
        End If

        If sender.text = "Legend" Or sender.text = "Preview Map" Then
            If TypeOf sender Is WeifenLuo.WinFormsUI.Docking.DockContent Then
                While CType(sender, WeifenLuo.WinFormsUI.Docking.DockContent).Controls.Count > 0
                    CType(sender, WeifenLuo.WinFormsUI.Docking.DockContent).Controls.RemoveAt(0)
                End While
            End If

            If sender.text = "Legend" Then
                m_Menu.Item("mnuLegendVisible").Checked = False
            ElseIf sender.text = "Preview Map" Then
                m_Menu.Item("mnuPreviewVisible").Checked = False
            End If
        End If
    End Sub

    'This function is added to fix the annoying bug that prevents you from using the form designer Aug 29 2005 --Lailin Chen
    'Altered for docking tool panels by Chris M June 12 2006
    Public Sub InitializeMapsAndLegends()
        Me.Legend = New LegendControl.Legend
        If Not MapMain Is Nothing Then
            Legend.Map = CType(MapMain.GetOcx, MapWinGIS.Map)
        End If
        Me.Legend.BackColor = System.Drawing.Color.White
        Me.Legend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Legend.Location = New System.Drawing.Point(0, 0)
        Me.Legend.Name = resources.GetString("LegendName.Text")
        'TODO PM Should't this be a setting:
        Me.Legend.SelectedColor = System.Drawing.Color.FromArgb(CType(240, Byte), CType(240, Byte), CType(240, Byte))
        Me.Legend.SelectedLayer = -1

        dckPanel = New WeifenLuo.WinFormsUI.Docking.DockPanel
        dckPanel.Parent = panel1
        dckPanel.Dock = DockStyle.Fill
        dckPanel.BringToFront()
        dckPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi


        '5/5/2008 jk - changed the default location of MapWindowDock.config
        Dim DockConfigFile As String = System.IO.Path.Combine(modMain.ProjInfo.GetApplicationDataDir(), "MapWindowDock.config")

        'Attempt to restore a default docking configuration if none is found.
        'If Not System.IO.File.Exists(DockConfigFile) Then
        '    Dim sr As New IO.BinaryReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(Me.GetType, "MapWindowDockTemplate.config"), System.Text.Encoding.GetEncoding("UTF-16"))
        '    Dim sw As New IO.BinaryWriter(New IO.FileStream(DockConfigFile, IO.FileMode.Create), System.Text.Encoding.GetEncoding("UTF-16"))
        '    Dim buf(1024) As Char
        '    Dim n As Long = 1
        '    While n > 0
        '        n = sr.Read(buf, 0, 512)
        '        sw.Write(buf, 0, n)
        '    End While
        '    sw.Close()
        '    sr.Close()
        'End If

        'Dim NeedDefaultConfig As Boolean = True

        'If the above code succeeded, the file will always exist -- but nonetheless,
        'test it, in case something went wrong writing the file.
        'If System.IO.File.Exists(DockConfigFile) Then
        '    'fix blink of window that occurs here during initial startup of MW
        '    'Jack -- I can't find a way to prevent this blink while simultaneously
        '    'creating a valid ActiveX state for the map objects.
        '    'Were it not for the Map objects the blink could be removed easily...
        '    'See comments on CreatePreviewPanel
        '    'I'm open to suggestions on how to fix this! Not having the flicker
        '    'causes MW to crash painfully when the preview map is autohidden.
        '    'Similar problems occur recreating the main map if the flicker isn't present.

        '    '5/5/2008 jk - changed location of MapWindowDock.config
        '    Try
        '        dckPanel.LoadFromXml(DockConfigFile, CType(AddressOf BuildDockContent, WeifenLuo.WinFormsUI.Docking.DeserializeDockContent))
        '        NeedDefaultConfig = False 'Succeeded in reading config, don't need to use defaults below
        '    Catch
        '        'corrupt config file, we will use defaults below and file should be fixed when MW exits normally
        '    End Try
        'End If

        'If NeedDefaultConfig Then
        CreateMapPanel()
        CreateLegendPanel()
        CreatePreviewPanel()
        'End If
        legendPanel.Hide()
        previewPanel.Hide()
    End Sub

    Private Sub DoZoomPrevious()
        If m_Extents.Count > 0 And m_CurrentExtent > 0 Then
            m_IsManualExtentsChange = True
            m_CurrentExtent -= 1
            MapMain.Extents = m_Extents(m_CurrentExtent)
        End If
        UpdateZoomButtons()
    End Sub

    Private Sub DoZoomNext()
        If m_CurrentExtent < m_Extents.Count - 1 Then
            m_CurrentExtent += 1
            m_IsManualExtentsChange = True
            MapMain.Extents = m_Extents(m_CurrentExtent)
        End If
        UpdateZoomButtons()
    End Sub

    Private Sub DoZoomMax()
        MapMain.ZoomToMaxVisibleExtents()
        UpdateZoomButtons()
    End Sub

    Private Sub DoZoomLayer()
        MapMain.ZoomToLayer(Legend.SelectedLayer)
        UpdateZoomButtons()
    End Sub

    Private Sub DoZoomSelected()
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not View.SelectedShapes Is Nothing AndAlso View.SelectedShapes.NumSelected > 0 Then
                ' This code borrowed from the MapWindow.  It should be included on the 
                ' MapWindow.View or MapWindow.View.SelectedShapes interfaces sometime
                ' becuase it is a very useful function, and will have to be duplicated
                ' many times if it is not added.

                Dim maxX, maxY, minX, minY As Double
                Dim dx, dy As Double
                Dim tExts As MapWinGIS.Extents

                Dim i As Integer

                With View.SelectedShapes(0)
                    maxX = .Extents.xMax
                    minX = .Extents.xMin
                    maxY = .Extents.yMax
                    minY = .Extents.yMin
                End With
                For i = 0 To View.SelectedShapes.NumSelected - 1
                    If m_layers(m_layers.CurrentLayer).Visible = False Then
                        m_layers(m_layers.CurrentLayer).Visible = True
                    End If
                    With View.SelectedShapes(i).Extents
                        If .xMax > maxX Then maxX = .xMax
                        If .yMax > maxY Then maxY = .yMax
                        If .xMin < minX Then minX = .xMin
                        If .yMin < minY Then minY = .yMin
                    End With
                Next i

                ' Pad extents now
                dx = maxX - minX
                dx = dx / 8
                If dx = 0 Then
                    dx = 1
                End If
                maxX = maxX + dx
                minX = minX - dx

                dy = maxY - minY
                dy = dy / 8
                If dy = 0 Then
                    dy = 1
                End If
                maxY = maxY + dy
                minY = minY - dy

                tExts = New MapWinGIS.Extents
                If View.SelectedShapes.NumSelected = 1 And m_layers(m_layers.CurrentLayer).LayerType = MapWindow.Interfaces.eLayerType.PointShapefile Then
                    Dim sf As MapWinGIS.Shapefile = CType(m_layers(m_layers.CurrentLayer).GetObject(), MapWinGIS.Shapefile)
                    'Use shape extents - best we can do
                    Dim xpad As Double = (1 / 100) * (sf.Extents.xMax - sf.Extents.xMin)
                    Dim ypad As Double = (1 / 100) * (sf.Extents.yMax - sf.Extents.yMin)
                    tExts.SetBounds(minX + xpad, minY - ypad, 0, maxX - xpad, maxY + ypad, 0)
                Else
                    tExts.SetBounds(minX, minY, 0, maxX, maxY, 0)
                End If
                View.Extents = tExts
                tExts = Nothing
            End If
        Catch e As Exception
            MapWinUtility.Logger.Dbg("Error: " + e.ToString())
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DoZoomShape()
        Dim maxX As Double, maxY As Double
        Dim minX As Double, minY As Double
        Dim dx As Double, dy As Double
        Dim i As Integer, tExts As MapWinGIS.Extents
        With m_View.SelectedShapes(0)
            maxX = .Extents.xMax
            minX = .Extents.xMin
            maxY = .Extents.yMax
            minY = .Extents.yMin
        End With
        For i = 0 To m_View.SelectedShapes.NumSelected - 1
            With m_View.SelectedShapes(i).Extents
                If .xMax > maxX Then maxX = .xMax
                If .yMax > maxY Then maxY = .yMax
                If .xMin < minX Then minX = .xMin
                If .yMin < minY Then minY = .yMin
            End With
        Next i

        ' Pad extents now
        dx = maxX - minX
        dx = dx * m_View.ExtentPad
        maxX = maxX + dx
        minX = minX - dx

        dy = maxY - minY
        dy = dy * m_View.ExtentPad
        maxY = maxY + dy
        minY = minY - dy

        tExts = New MapWinGIS.Extents
        tExts.SetBounds(minX, minY, 0, maxX, maxY, 0)
        MapMain.Extents = tExts
        tExts = Nothing
        UpdateZoomButtons()
    End Sub

    Public ReadOnly Property ApplicationInfo() As Interfaces.AppInfo Implements Interfaces.IMapWin.ApplicationInfo
        Get
            Return modMain.AppInfo
        End Get
    End Property

    Private Sub AreaMeasuringClearTempLines()
        If (AppInfo.AreaMeasuringEraseLast) Then
            System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringLastStartPtX, AppInfo.AreaMeasuringLastStartPtY), New System.Drawing.Point(AppInfo.AreaMeasuringLastEndX, AppInfo.AreaMeasuringLastEndY), AppInfo.AreaMeasuringmycolor)
            System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringStartPtX, AppInfo.AreaMeasuringStartPtY), New System.Drawing.Point(AppInfo.AreaMeasuringLastEndX, AppInfo.AreaMeasuringLastEndY), AppInfo.AreaMeasuringmycolor)
            AppInfo.AreaMeasuringLastStartPtX = -1
            AppInfo.AreaMeasuringLastStartPtY = -1
        End If
        For i As Integer = 0 To AppInfo.AreaMeasuringReversibleDrawn.Count - 1 Step 4
            System.Windows.Forms.ControlPaint.DrawReversibleLine(New System.Drawing.Point(AppInfo.AreaMeasuringReversibleDrawn(i), AppInfo.AreaMeasuringReversibleDrawn(i + 1)), New System.Drawing.Point(AppInfo.AreaMeasuringReversibleDrawn(i + 2), AppInfo.AreaMeasuringReversibleDrawn(i + 3)), AppInfo.AreaMeasuringmycolor)
        Next
        AppInfo.AreaMeasuringEraseLast = False
        AppInfo.AreaMeasuringReversibleDrawn.Clear()
        AppInfo.AreaMeasuringlstDrawPoints.Clear()
        View.Draw.ClearDrawings()
    End Sub

    Private Sub AreaMeasuringStop()
        MapMain.UDCursorHandle = -1
        MapMain.MapCursor = MapWinGIS.tkCursor.crsrArrow
        MapMain.CursorMode = MapWinGIS.tkCursorMode.cmNone
        tbbMeasureArea.Checked = False
        AppInfo.AreaMeasuringCurrently = False
        AppInfo.AreaMeasuringStartPtX = -1
        AppInfo.AreaMeasuringStartPtY = -1
        AppInfo.AreaMeasuringLastEndX = -1
        AppInfo.AreaMeasuringLastEndY = -1
        AppInfo.AreaMeasuringLastStartPtX = -1
        AppInfo.AreaMeasuringLastStartPtY = -1
        AreaMeasuringClearTempLines()
        '7/31/2006 PM
        'GetOrRemovePanel("Area:", True)
        GetOrRemovePanel(resources.GetString("msgPanelArea.Text"), True)
    End Sub

    Private Sub AreaMeasuringBegin()
        If tbbMeasure.Checked Then
            MeasuringStop()
        End If

        If MeasureCursor Is Nothing Then
            MeasureCursor = New Cursor(Me.GetType(), "measuring.ico")
        End If

        MapMain.UDCursorHandle = MeasureCursor.Handle
        MapMain.MapCursor = MapWinGIS.tkCursor.crsrUserDefined
        MapMain.CursorMode = MapWinGIS.tkCursorMode.cmNone
        tbbMeasureArea.Checked = True
        AppInfo.AreaMeasuringCurrently = True
        AppInfo.AreaMeasuringlstDrawPoints = New ArrayList
        AppInfo.AreaMeasuringReversibleDrawn = New ArrayList
        StatusBar.AddPanel(resources.GetString("msgPanelArea.Text"), 0, 100, Windows.Forms.StatusBarPanelAutoSize.Contents)
    End Sub

    Private Function AreaMeasuringCalculate() As String
        '1/23/2009 JK
        'calculate the area of drawn polygon for the 'measure area' tool
        'and return the result including name of units

        Dim tempPoly As New MapWinGIS.Shape
        tempPoly.Create(MapWinGIS.ShpfileType.SHP_POLYGON)
        ' Loop the points, inserting them into new poly
        Dim i As Integer
        For i = 0 To AppInfo.AreaMeasuringlstDrawPoints.Count - 1
            tempPoly.InsertPoint(AppInfo.AreaMeasuringlstDrawPoints(i), tempPoly.numPoints)
        Next
        'Add the first point again to complete the polygon
        tempPoly.InsertPoint(AppInfo.AreaMeasuringlstDrawPoints(0), tempPoly.numPoints)

        Dim DataUnit As UnitOfMeasure    'the unit specified in Project Settings..Map Data Units
        Dim MeasureUnit As UnitOfMeasure 'the unit specified in Project Settings..Show Additional Unit
        DataUnit = MapWinGeoProc.UnitConverter.StringToUOM(modMain.frmMain.Project.MapUnits)
        MeasureUnit = DataUnit
        If modMain.ProjInfo.ShowStatusBarCoords_Alternate.ToLower() <> "(none)" Then
            MeasureUnit = MapWinGeoProc.UnitConverter.StringToUOM(modMain.ProjInfo.ShowStatusBarCoords_Alternate)
        End If

        'Convert the total area from Map Data units to Alternate units
        Dim newArea As Double = MapWinGeoProc.Utils.Area(tempPoly, DataUnit)

        'if Map Data Units are DecimalDegrees, the area() function returns the result in kilometers
        If DataUnit = UnitOfMeasure.DecimalDegrees Then DataUnit = UnitOfMeasure.Kilometers
        If MeasureUnit = UnitOfMeasure.DecimalDegrees Then MeasureUnit = DataUnit

        newArea = MapWinGeoProc.UnitConverter.ConvertArea(DataUnit, MeasureUnit, newArea)

        Dim squared As String = (Convert.ToChar(178)).ToString() 'the exponent sign

        '1/23/2009 JK - internationalization - show area in the in status bar
        Dim msgArea As String = String.Format("{0} {1}{2}", _
        formatDistance(newArea), MeasureUnit.ToString, squared)

        Return msgArea
    End Function

    Private Sub MeasuringBegin()
        If tbbMeasureArea.Checked Then
            AreaMeasuringStop()
        End If

        If MeasureCursor Is Nothing Then
            MeasureCursor = New Cursor(Me.GetType(), "measuring.ico")
        End If

        MapMain.UDCursorHandle = MeasureCursor.Handle
        MapMain.MapCursor = MapWinGIS.tkCursor.crsrUserDefined
        MapMain.CursorMode = MapWinGIS.tkCursorMode.cmNone
        tbbMeasure.Checked = True
        AppInfo.MeasuringCurrently = True
        AppInfo.MeasuringDrawing = -1
        AppInfo.MeasuringPreviousSegments = New ArrayList
        ''7/31/2006 PM
        'StatusBar.AddPanel("Distance: Click first point", 0, 100, Windows.Forms.StatusBarPanelAutoSize.Contents)
        StatusBar.AddPanel(resources.GetString("msgPanelDistance.Text"), 0, 100, Windows.Forms.StatusBarPanelAutoSize.Contents)
    End Sub

    Private Sub MeasuringStop()
        MapMain.UDCursorHandle = -1
        MapMain.MapCursor = MapWinGIS.tkCursor.crsrArrow
        MapMain.CursorMode = MapWinGIS.tkCursorMode.cmNone
        tbbMeasure.Checked = False
        AppInfo.MeasuringCurrently = False
        AppInfo.MeasuringTotalDistance = 0
        AppInfo.MeasuringStartX = 0
        AppInfo.MeasuringStartY = 0
        AppInfo.MeasuringScreenPointStart = Nothing
        AppInfo.MeasuringScreenPointFinish = Nothing
        AppInfo.MeasuringPreviousSegments.Clear()
        AppInfo.MeasuringPreviousSegments = Nothing
        If (Not AppInfo.MeasuringDrawing = -1) Then
            MapMain.ClearDrawing(AppInfo.MeasuringDrawing)
            AppInfo.MeasuringDrawing = -1
        End If
        '7/31/2006 PM
        'GetOrRemovePanel("Distance:", True)
        GetOrRemovePanel(resources.GetString("msgPanelDistance.Text"), True)
    End Sub

    Private Sub MeasuringDrawPreviousSegments()
        For i As Integer = 0 To AppInfo.MeasuringPreviousSegments.Count - 1 Step 4
            MapMain.DrawLine(CType(AppInfo.MeasuringPreviousSegments(i), Double), CType(AppInfo.MeasuringPreviousSegments(i + 1), Double), CType(AppInfo.MeasuringPreviousSegments(i + 2), Double), CType(AppInfo.MeasuringPreviousSegments(i + 3), Double), 2, Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)))
        Next
    End Sub

    Private Function GetOrRemovePanel(ByVal psStartText As String, Optional ByVal pbRemove As Boolean = False) As Integer
        Dim i As Integer
        Dim l As Integer
        l = Len(psStartText)

        For i = StatusBar.NumPanels - 1 To 0 Step -1
            If Microsoft.VisualBasic.Left(StatusBar.Item(i).Text, l) = psStartText Then
                GetOrRemovePanel = i
                If pbRemove = True Then
                    StatusBar.RemovePanel(i)
                End If
            End If
        Next i
    End Function

    '3/21/2008 added by Jiri Kadlec - format the distance or area calculated by "Measure distance"
    'or "Measure Area" tools and shown in the status bar using the current project settings
    '(number of decimal places will be the same as specified in Status Bar Comma Separators
    'and Status Bar Decimal Places.
    Private Function formatDistance(ByVal dist As Double) As String
        Dim decimals As Integer = ProjInfo.StatusBarAlternateCoordsNumDecimals
        Dim useCommas As Integer = ProjInfo.StatusBarAlternateCoordsUseCommas

        Dim nf As String 'the number formatting string
        If useCommas = True Then
            nf = "N" + decimals.ToString
        Else
            nf = "F" + decimals.ToString
        End If

        Return dist.ToString(nf)

    End Function

    'calculate a distance between two points.
    'the result is in Project.MapUnits.
    'if the project map units are decimal degrees, the result is in kilometers.
    Private Function distance(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double) As Double
        If (Project.MapUnits.ToLower = "lat/long") Then
            'jiri kadlec 22/2/2008 corrected order of lat/long parameters in LLDistance
            Return LLDistance(y1, x1, y2, x2)
        Else
            Return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))
        End If
    End Function

    Private Function deg2rad(ByVal deg As Double) As Double
        Return (deg * Math.PI / 180.0)
    End Function

    Private Function rad2deg(ByVal rad As Double) As Double
        Return rad / Math.PI * 180.0
    End Function

    'Chris M 7/10/2006 for Buzilla 175
    'the input coordinates must be in decimal degrees.
    'output is always in kilometers
    Private Function LLDistance(ByVal p1lat As Double, ByVal p1lon As Double, ByVal p2lat As Double, ByVal p2lon As Double) As Double
        Dim FLATTENING As Double = 1 / 298.257223563

        Dim lat1 As Double = deg2rad(p1lat)
        Dim lon1 As Double = deg2rad(p1lon)
        Dim lat2 As Double = deg2rad(p2lat)
        Dim lon2 As Double = deg2rad(p2lon)

        Dim F As Double = (lat1 + lat2) / 2.0
        Dim G As Double = (lat1 - lat2) / 2.0
        Dim L As Double = (lon1 - lon2) / 2.0

        Dim sing As Double = Math.Sin(G)
        Dim cosl As Double = Math.Cos(L)
        Dim cosf As Double = Math.Cos(F)
        Dim sinl As Double = Math.Sin(L)
        Dim sinf As Double = Math.Sin(F)
        Dim cosg As Double = Math.Cos(G)

        Dim S As Double = sing * sing * cosl * cosl + cosf * cosf * sinl * sinl
        Dim C As Double = cosg * cosg * cosl * cosl + sinf * sinf * sinl * sinl
        Dim W As Double = Math.Atan2(Math.Sqrt(S), Math.Sqrt(C))
        Dim R As Double = Math.Sqrt((S * C)) / W
        Dim H1 As Double = (3 * R - 1.0) / (2.0 * C)
        Dim H2 As Double = (3 * R + 1.0) / (2.0 * S)
        Dim D As Double = 2 * W * 6378.135
        Return (D * (1 + FLATTENING * H1 * sinf * sinf * cosg * cosg - FLATTENING * H2 * cosf * cosf * sing * sing))
    End Function

    'Chris Michaelis for Bugzilla 155
    Public Shared Sub SaveCustomColors(ByRef dlg As ColorDialog)
        If dlg Is Nothing Then Exit Sub
        If dlg.CustomColors Is Nothing Then Exit Sub

        Dim c As Integer
        Dim i As Integer = 0
        For Each c In dlg.CustomColors
            SaveSetting("MapWindow", "CustomColors", "Color" + i.ToString(), c.ToString())
            i += 1
        Next
        SaveSetting("MapWindow", "CustomColors", "Count", (i + 1).ToString())
    End Sub

    'Chris Michaelis for Bugzilla 155
    Public Shared Sub LoadCustomColors(ByRef dlg As ColorDialog)
        If dlg Is Nothing Then Exit Sub

        Dim count As Integer = Integer.Parse(GetSetting("MapWindow", "CustomColors", "Count", 0))
        If count = 0 Then Exit Sub

        Dim newColors(count) As Integer

        For i As Integer = 0 To count - 1
            newColors(i) = Integer.Parse(GetSetting("MapWindow", "CustomColors", "Color" + i.ToString(), System.Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(Color.White))))
        Next

        dlg.CustomColors = newColors
    End Sub

    Private Sub MapPreview_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MapPreview.SizeChanged
        If Not m_PreviewMap Is Nothing Then m_PreviewMap.UpdateLocatorBox()
    End Sub

    'Christopher Michaelis, June 12, 2006
    Private Declare Function GetCursorPos Lib "user32" (ByRef lpPoint As POINTAPI) As Integer

    'Christopher Michaelis, June 12, 2006
    Public Structure POINTAPI
        Dim x As Integer
        Dim y As Integer
    End Structure

    'Christopher Michaelis, June 12, 2006
    Public Shared Function GetCursorLocation() As Point
        Dim pnt As POINTAPI
        GetCursorPos(pnt)
        Return New Point(pnt.x, pnt.y)
    End Function

    'Christopher Michaelis, June 12, 2006
    Private Function InMyFormBounds(ByVal pt As Point) As Boolean
        If pt.X < Me.Location.X + Me.Width And pt.X > Me.Location.X _
        And pt.Y < Me.Location.Y + Me.Height And pt.Y > Me.Location.Y Then
            Return True
        End If

        Return False
    End Function

    'Christopher Michaelis, June 12, 2006
    Private Sub FloatingBar_Move(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is Form Then
            If CType(sender, Form).Controls.Count > 0 Then
                If TypeOf (CType(sender, Form).Controls(0)) Is ToolStripContainer Then
                    If CType(CType(sender, Form).Controls(0), ToolStripContainer).TopToolStripPanel.Controls.Count > 0 Then
                        UndockableToolstrip_EndDrag(CType(CType(sender, Form).Controls(0), ToolStripContainer).TopToolStripPanel.Controls(0), e)
                    End If
                End If
            End If
        End If
    End Sub

    'Christopher Michaelis, June 12, 2006
    Public Sub UndockableToolstrip_EndDrag(ByVal sender As Object, ByVal e As System.EventArgs) Handles tlbMain.EndDrag
        Dim cPt As Point = GetCursorLocation()
        Dim ts As ToolStrip = CType(sender, ToolStrip)
        Dim myType As Type = Me.GetType()
        Dim InFrmBoundary As Boolean = InMyFormBounds(cPt)

        If ts.Tag = "" Then ts.Tag = "Docked" 'Assume docked; somebody forgot to set it!

        If InFrmBoundary And ts.Tag = "Docked" Then
            'Docking normally within my form; do nothing.
            Return
        ElseIf InFrmBoundary And ts.Tag = "Floating" Then
            'Redocking!
            Dim oldTS As ToolStripPanel = ts.Parent
            oldTS.Controls.Remove(ts)
            StripDocker.TopToolStripPanel.Controls.Add(ts)
            RemoveHandler oldTS.ParentForm.Move, AddressOf FloatingBar_Move
            oldTS.ParentForm.Close()
            ts.Tag = "Docked"
        ElseIf Not InFrmBoundary And ts.Tag = "Docked" Then
            'The user wants the toolstrip to undock and float
            'Make a floating toolbar:
            Dim FloatingToolbar As New frmFloatingToolbar
            If TypeOf ts.Parent Is ToolStripPanel Then
                CType(ts.Parent, ToolStripPanel).Controls.Remove(ts)
            Else
                MapWinUtility.Logger.Msg(ts.Parent.GetType().ToString())
            End If
            FloatingToolbar.tsc.TopToolStripPanel.Controls.Add(ts)
            FloatingToolbar.Width = ts.Width + 5
            FloatingToolbar.Height = ts.Height
            FloatingToolbar.MinimumSize = New Size(ts.Width + 5, 23)
            FloatingToolbar.SetDesktopLocation(cPt.X, cPt.Y)
            AddHandler FloatingToolbar.Move, AddressOf FloatingBar_Move

            FloatingToolbar.Show()
            ts.Tag = "Floating"
        ElseIf Not InFrmBoundary And ts.Tag = "Floating" Then
            'The bar is floating and they dragged it -- try to
            'detect new location.
            Try
                CType(ts.Parent.Parent.Parent, Form).Location = cPt
            Catch
            End Try
        End If
    End Sub

    'Chris Michaelis July 20 2006
    Private Sub CheckForUpdates()
        Dim myVersion As String = App.VersionString
        'The version needs to be numeric, i.e. only one decimal.
        While Not myVersion.LastIndexOf(".") = myVersion.IndexOf(".")
            myVersion = myVersion.Substring(0, myVersion.LastIndexOf(".")) & myVersion.Substring(myVersion.LastIndexOf(".") + 1)
        End While

        Dim updateCheckFilename As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\UpdateCheck.exe"

        If System.IO.File.Exists(updateCheckFilename) Then
            Dim prcs As New Diagnostics.ProcessStartInfo
            prcs.FileName = updateCheckFilename
            prcs.Arguments = "http://www.MapWindow.org/CheckForUpdates.php?p=MapWindowApp" & "&cv=" & myVersion.ToString() & " " & Diagnostics.Process.GetCurrentProcess().Id.ToString()
            Diagnostics.Process.Start(prcs)
        Else
            '7/31/2006 PM
            'If mapwinutility.logger.msg("The Update Check tool could not be located; all updates will need to be manually downloaded." & vbCrLf & vbCrLf & "Open the Downloads page now?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Update Check Tool Not Found") = MsgBoxResult.Yes Then
            Dim strMessage As String = String.Format(resources.GetString("msgUpdateToolNotFound.Text"), vbCrLf & vbCrLf)
            If MapWinUtility.Logger.Msg(strMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, AppInfo.Name) = MsgBoxResult.Yes Then
                Diagnostics.Process.Start("http://www.MapWindow.org/download.php?show_details=1")
            End If
        End If
    End Sub

    Private Sub mnuZoomButtons_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuZoomPrevious.Click, mnuZoomNext.Click, mnuZoomMax.Click, mnuZoomLayer.Click, mnuZoomSelected.Click, mnuZoomShape.Click, mnuZoomPreviewMap.Click
        Dim b As Windows.Forms.ToolStripMenuItem = CType(sender, Windows.Forms.ToolStripMenuItem)

        mnuZoomPrevious.Checked = IIf(b.Name = "mnuZoomPrevious", True, False)
        mnuZoomNext.Checked = IIf(b.Name = "mnuZoomNext", True, False)
        mnuZoomMax.Checked = IIf(b.Name = "mnuZoomMax", True, False)
        mnuZoomLayer.Checked = IIf(b.Name = "mnuZoomLayer", True, False)
        mnuZoomSelected.Checked = IIf(b.Name = "mnuZoomSelected", True, False)
        mnuZoomShape.Checked = IIf(b.Name = "mnuZoomShape", True, False)
        mnuZoomPreviewMap.Checked = IIf(b.Name = "mnuZoomPreviewMap", True, False)

        tbbZoom.Image = b.Image

        If mnuZoomPrevious.Checked Then
            DoZoomPrevious()
        ElseIf mnuZoomNext.Checked Then
            DoZoomNext()
        ElseIf mnuZoomMax.Checked Then
            DoZoomMax()
        ElseIf mnuZoomLayer.Checked Then
            DoZoomLayer()
        ElseIf mnuZoomSelected.Checked Then
            DoZoomSelected()
        ElseIf mnuZoomShape.Checked Then
            DoZoomShape()
        ElseIf mnuZoomPreviewMap.Checked Then
            doZoomToPreview()
        End If
    End Sub

    Private Sub DoToggleScalebar()
        SetModified(True)
        m_FloatingScalebar_Enabled = Not m_FloatingScalebar_Enabled
        UpdateFloatingScalebar()
    End Sub

    Private Sub UpdateFloatingScalebar()
        'If this menu doesn't exist, MW is initializing; skip for now.
        If Menus Is Nothing OrElse Menus("mnuShowScaleBar") Is Nothing Then Return

        'Every time we update the scale bar, verify
        'on the menu items' checked status as well as
        'destroy or create the picturebox if needed
        Menus("mnuShowScaleBar").Checked = m_FloatingScalebar_Enabled
        If Not m_FloatingScalebar_Enabled Then
            If Not m_FloatingScalebar_PictureBox Is Nothing AndAlso mapPanel.Contains(m_FloatingScalebar_PictureBox) Then
                mapPanel.Controls.Remove(m_FloatingScalebar_PictureBox)
                m_FloatingScalebar_PictureBox.Image.Dispose()
                m_FloatingScalebar_PictureBox.Image = Nothing
                m_FloatingScalebar_PictureBox.Dispose()
                m_FloatingScalebar_PictureBox = Nothing
            End If
        Else
            'First, test to ensure that the window is not minimized. Otherwise, when the scale bar tries
            'to generate itself, the distance per pixel will be infinite
            'and therefore the range will overflow
            If Me.WindowState = FormWindowState.Minimized Then Return

            If m_FloatingScalebar_PictureBox Is Nothing Then
                m_FloatingScalebar_PictureBox = New Windows.Forms.PictureBox
                AddHandler m_FloatingScalebar_PictureBox.Click, AddressOf FloatingScalebarClick
            End If

            If Not mapPanel Is Nothing AndAlso Not mapPanel.IsDisposed Then
                If Not mapPanel.Controls.Contains(m_FloatingScalebar_PictureBox) Then
                    mapPanel.Controls.Add(m_FloatingScalebar_PictureBox)
                End If
            End If

            'OK -- created and enabled, draw it

            m_FloatingScalebar_PictureBox.Visible = False

            Static sb As New ScaleBarUtility

            'Default -- overridden by project units if set
            Dim mapunit As UnitOfMeasure = UnitOfMeasure.Meters

            If (Not Project.MapUnits = "") Then
                mapunit = MapWinGeoProc.UnitConverter.StringToUOM(Project.MapUnits) '08/28/08 jk - new conversion function
            End If

            'Default - overridden by "Status Bar Alternate" units, then may be
            'further overridden by the context menu setting.
            Dim ScaleUnit As UnitOfMeasure = mapunit

            'Prefer alternate coordinate system
            ScaleUnit = MapWinGeoProc.UnitConverter.StringToUOM(modMain.ProjInfo.ShowStatusBarCoords_Alternate) '08/28/08 jk - new conversion function

            If Not m_FloatingScalebar_ContextMenu_SelectedUnit = "" Then
                ScaleUnit = MapWinGeoProc.UnitConverter.StringToUOM(m_FloatingScalebar_ContextMenu_SelectedUnit)
            End If

            'Disallow showing degrees as a measurement.
            If ScaleUnit = UnitOfMeasure.DecimalDegrees Then ScaleUnit = UnitOfMeasure.Kilometers

            m_FloatingScalebar_PictureBox.BorderStyle = BorderStyle.FixedSingle
            m_FloatingScalebar_PictureBox.Image = sb.GenerateScaleBar(CType(MapMain.Extents, MapWinGIS.Extents), mapunit, ScaleUnit, 300, m_FloatingScalebar_ContextMenu_BackColor, m_FloatingScalebar_ContextMenu_ForeColor)
            m_FloatingScalebar_PictureBox.SizeMode = PictureBoxSizeMode.AutoSize

            Select Case m_FloatingScalebar_ContextMenu_SelectedPosition
                Case "UpperLeft"
                    m_FloatingScalebar_PictureBox.Location = New Point(0, 0)
                Case "UpperRight"
                    m_FloatingScalebar_PictureBox.Location = New Point(MapMain.Width - m_FloatingScalebar_PictureBox.Width, 0)
                Case "LowerLeft"
                    m_FloatingScalebar_PictureBox.Location = New Point(0, MapMain.Height - m_FloatingScalebar_PictureBox.Height)
                Case "LowerRight"
                    m_FloatingScalebar_PictureBox.Location = New Point(MapMain.Width - m_FloatingScalebar_PictureBox.Width, MapMain.Height - m_FloatingScalebar_PictureBox.Height)
                Case Else
                    m_FloatingScalebar_PictureBox.Location = New Point(MapMain.Width - m_FloatingScalebar_PictureBox.Width, MapMain.Height - m_FloatingScalebar_PictureBox.Height)
            End Select

            m_FloatingScalebar_PictureBox.BringToFront()
            m_FloatingScalebar_PictureBox.Visible = True
        End If
    End Sub

    Private Sub FloatingScalebarClick(ByVal sender As Object, ByVal e As EventArgs)
        m_FloatingScalebar_ContextMenu.Show(Me, Me.PointToClient(Cursor.Position))
    End Sub

    Private Sub FloatingScalebar_UpperLeft_Click(ByVal sender As Object, ByVal e As EventArgs)
        m_FloatingScalebar_ContextMenu_SelectedPosition = "UpperLeft"
        m_FloatingScalebar_ContextMenu_UL.Checked = True
        m_FloatingScalebar_ContextMenu_UR.Checked = False
        m_FloatingScalebar_ContextMenu_LL.Checked = False
        m_FloatingScalebar_ContextMenu_LR.Checked = False

        SetModified(True)
        UpdateFloatingScalebar()
    End Sub

    Private Sub FloatingScalebar_UpperRight_Click(ByVal sender As Object, ByVal e As EventArgs)
        m_FloatingScalebar_ContextMenu_SelectedPosition = "UpperRight"
        m_FloatingScalebar_ContextMenu_UL.Checked = False
        m_FloatingScalebar_ContextMenu_UR.Checked = True
        m_FloatingScalebar_ContextMenu_LL.Checked = False
        m_FloatingScalebar_ContextMenu_LR.Checked = False

        SetModified(True)
        UpdateFloatingScalebar()
    End Sub

    Private Sub FloatingScalebar_LowerLeft_Click(ByVal sender As Object, ByVal e As EventArgs)
        m_FloatingScalebar_ContextMenu_SelectedPosition = "LowerLeft"
        m_FloatingScalebar_ContextMenu_UL.Checked = False
        m_FloatingScalebar_ContextMenu_UR.Checked = False
        m_FloatingScalebar_ContextMenu_LL.Checked = True
        m_FloatingScalebar_ContextMenu_LR.Checked = False

        SetModified(True)
        UpdateFloatingScalebar()
    End Sub

    Private Sub FloatingScalebar_LowerRight_Click(ByVal sender As Object, ByVal e As EventArgs)
        m_FloatingScalebar_ContextMenu_SelectedPosition = "LowerRight"
        m_FloatingScalebar_ContextMenu_UL.Checked = False
        m_FloatingScalebar_ContextMenu_UR.Checked = False
        m_FloatingScalebar_ContextMenu_LL.Checked = False
        m_FloatingScalebar_ContextMenu_LR.Checked = True

        SetModified(True)
        UpdateFloatingScalebar()
    End Sub

    Private Sub FloatingScalebar_ChooseForecolor_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim picker As New ColorPickerSingle
        If picker.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_FloatingScalebar_ContextMenu_ForeColor = picker.btnStartColor.BackColor
            SetModified(True)
            UpdateFloatingScalebar()
        End If
    End Sub

    Private Sub FloatingScalebar_ChooseBackcolor_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim picker As New ColorPickerSingle
        If picker.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_FloatingScalebar_ContextMenu_BackColor = picker.btnStartColor.BackColor
            SetModified(True)
            UpdateFloatingScalebar()
        End If
    End Sub

    Private Sub FloatingScalebar_ChangeUnits_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim slct As New frmChooseDisplayUnits
        If slct.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_FloatingScalebar_ContextMenu_SelectedUnit = slct.list.Items(slct.list.SelectedIndex)
            SetModified(True)
            UpdateFloatingScalebar()
        End If
    End Sub

    Public Sub BuildBookmarkedViewsMenu()
        Dim key As String
        Dim keysToRemove As New ArrayList

        'Find menu items to remove
        For Each key In m_Menu.m_MenuTable.Keys
            If key.StartsWith(BookmarkedViewPrefix) Then
                keysToRemove.Add(key)
            End If
        Next

        For Each key In keysToRemove
            m_Menu.Remove(key)
        Next

        'Add all current ProjInfo.BookmarkedViews to the menu
        For i As Integer = 0 To ProjInfo.BookmarkedViews.Count - 1
            key = BookmarkedViewPrefix & i
            If Not ProjInfo.BookmarkedViews(i).Name = "" Then m_Menu.AddMenu(key, "mnuBookmarkedViews", Nothing, ProjInfo.BookmarkedViews(i).Name.trim())
        Next
    End Sub

    Private Sub ToolStripMenuLabelSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuLabelSetup.Click
        DoLabelsEdit(Legend.SelectedLayer)
    End Sub

    Private Sub ToolStripMenuRelabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuRelabel.Click
        DoLabelsRelabel(Legend.SelectedLayer)
    End Sub

    Public Sub DoLabelsEdit(ByVal Handle As Integer)
        If Not Legend.SelectedLayer = -1 AndAlso (Legend.Layers(Legend.SelectedLayer).Type = eLayerType.LineShapefile Or Legend.Layers(Legend.SelectedLayer).Type = eLayerType.PointShapefile Or Legend.Layers(Legend.SelectedLayer).Type = eLayerType.PolygonShapefile) Then
            frmMain.Plugins.BroadcastMessage("LABEL_EDIT:" + Handle.ToString())
        Else
            MsgBox("Please ensure that a shapefile layer is selected before attempting to work with labels.", MsgBoxStyle.Information, "Select Shapefile Layer")
        End If
    End Sub

    Public Sub DoLabelsRelabel(ByVal handle As Integer)
        If Not Legend.SelectedLayer = -1 AndAlso (Legend.Layers(Legend.SelectedLayer).Type = eLayerType.LineShapefile Or Legend.Layers(Legend.SelectedLayer).Type = eLayerType.PointShapefile Or Legend.Layers(Legend.SelectedLayer).Type = eLayerType.PolygonShapefile) Then
            frmMain.Plugins.BroadcastMessage("LABEL_RELABEL:" + handle.ToString())
        Else
            MsgBox("Please ensure that a shapefile layer is selected before attempting to work with labels.", MsgBoxStyle.Information, "Select Shapefile Layer")
        End If
    End Sub
End Class

' Chris Michaelis August 20 2005 - to Sort the Plugins menu
Friend Class StringPairSorter
    Implements System.Collections.IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        If CType(x, String())(0) > CType(x, String())(1) Then Return 1
        If CType(x, String())(0) < CType(x, String())(1) Then Return -1
        If CType(x, String())(0) = CType(x, String())(1) Then Return 0
    End Function

End Class

Public Enum GeoTIFFAndImgBehavior
    LoadAsImage = 0
    LoadAsGrid = 1
    Automatic = 2
End Enum

Public Enum ESRIBehavior
    LoadAsImage = 0
    LoadAsGrid = 1
End Enum

Public Enum MouseWheelZoomDir
    WheelUpZoomsIn = 0
    WheelUpZoomsOut = 1
    NoAction = 2
End Enum
