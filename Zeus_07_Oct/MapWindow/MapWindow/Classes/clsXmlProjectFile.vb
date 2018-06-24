'********************************************************************************************************
'Filename:      clsXMLProjectFile.vb
'Description:   Friend class that contains functions for reading and wrting project and config files.
'This class has been updated to manage project files and to provide a globally available instance of the 
'class that is used to hold all global project related variables.  In prior versions of MapWindow (3.x) 
'this the global variables were stored in a variety of disparate places including the main MapWindow form.  
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
'Last Update:   1/12/2005, dpa
'3/23/2005 fixed Recent Projects menu, mgray
'6/9/2005 fixed grid loading to not rebuild the image every time - dpa
'7/21/2005 Added functionality to warn the user if a layer is missing when a project is being loaded, asking them if they'd like to locate said file. - Chris Michaelis 
'9/19/2005 Added functionality to overwrite the default "DefaultDir"
'4/29/2007 Tom Shanley (tws) added save/restore of shape-level formatting; and setting to control that
'3/31/2008 Jiri Kadlec (jk) Added option to specify language (overrides default Windows Regional and Language settings)
'5/8/2008 (jk) changed the default location of default.mwcfg, mapwindowdock.config and mwLanguage.config files
'5/26/2008 Jiri Kadlec (jk) Prevented LoadPreviewMap() from displaying an error message when a project doesn't
'                           have a preview map image specified, corrected handling of .mwcfg configuration files.
'5/27/2008 Jiri Kadlec (jk) When an existing project is loaded, try to find a project-specific .mwcfg file. If it's
'                           not found, recreate it from default.mwcfg.
'8/6/2008  Brian Marchionni When deploying custom made applications using the core MapWindow application the mapwindow.mwcfg file
'                           would be save to Documents and Settings\[User name]\Application Data\MapWindow\mapwindow.mwcfg this has been
'                           changed to save to Documents and Settings\[User name]\Application Data\[executables filename -.exe]\mapwindow.mwcfg
'9/6/2008 Jiri Kadlec (jk) Prevented infinite loop in CreateConfigFileFromDefault() when default.mwcfg was missing
'********************************************************************************************************

Imports System.Xml
Imports System.Runtime.Serialization.Formatters.Binary

Friend Class XmlProjectFile
    'Private Variables
    Private p_Doc As New XmlDocument
    Private m_ErrorOccured As Boolean
    Private m_ErrorMsg As String = "The following errors occured:" + Chr(13) + Chr(13)
    Private m_panel As System.Windows.Forms.StatusBarPanel
    Private m_CancelledPromptToBrowse As Double = 0

    'Public Variables 
    Public ProjectFileName As String
    Public ConfigFileName As String
    Public ConfigLoaded As Boolean
    Public Modified As Boolean
    Public RecentProjects As New Collections.ArrayList
    Public Shared m_MainToolbarButtons As New Hashtable
    Public ProjectProjection As String 'PROJ4 string
    Public m_MapUnits As String 'Meters, Feet, etc
    Public ShowStatusBarCoords_Projected As Boolean = True 'Default to true
    Public ShowStatusBarCoords_Alternate As String = "(None)" 'Default to true
    Public StatusBarCoordsNumDecimals As Integer = 3
    Public StatusBarAlternateCoordsNumDecimals As Integer = 3
    Public StatusBarCoordsUseCommas As Boolean = True
    Public StatusBarAlternateCoordsUseCommas As Boolean = True
    Public NoPromptToSendErrors As Boolean = False
    Public SaveShapeSettings As Boolean = False ' default false >> no surprises for other plugin developers doing shape-level formatting
    Public BookmarkedViews As New ArrayList
    Public TransparentSelection As Boolean = True
    Public ProjectBackColor As Color = Color.White 'map background color of MapWindow project (jk 5/10/2008)
    Public UseDefaultBackColor As Boolean = True 'true if the default (application-level) background color is used
    'Public AppMapBackColor As Color = Color.White 'map background color of MapWindow application (apply to new projects)

    Public Class BookmarkedView
        Public Name As String
        Public Exts As MapWinGIS.Extents

        Public Sub New(ByVal _Name As String, ByVal _Exts As MapWinGIS.Extents)
            Name = _Name
            Exts = _Exts
        End Sub
    End Class

#Region "Properties"
    Public ReadOnly Property DefaultConfigFile() As String
        Get
            Return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), _
            "default.mwcfg")
        End Get
    End Property

    Public ReadOnly Property UserConfigFile() As String
        Get
            Return System.IO.Path.Combine(GetApplicationDataDir(), "mapwindow.mwcfg")
        End Get
    End Property
#End Region

#Region "Application Data Directory"

    '5/4/2008 jk - save the configuration files to "Application Data" Special folder.
    '              The folder which contains MapWindow binaries in "Program Files" may be read-only on some shared
    '              Windows systems (#bug 691). This function tries to create a directory "Application Data\MapWindow"
    '              (usually located in "Documents and Settings\[User name]\Application Data"). If it fails, the folder
    '              of MW executable file is used for storing the configuration files.
    '8/6/2008 BM - the mapwindow.mwcfg file now saves to "Documents and Settings\[User name]\Application Data\[executables name - .exe]\mapwindow.mwcfg"

    Public Shared Function GetApplicationDataDir() As String
        Dim AppDataDir As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
        Dim ExecutableName As String = Left(System.Windows.Forms.Application.ExecutablePath, System.Windows.Forms.Application.ExecutablePath.Length - 4).Remove(0, System.Windows.Forms.Application.StartupPath.Length + 1)
        Try
            AppDataDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ExecutableName)
            If Not System.IO.Directory.Exists(AppDataDir) Then
                MapWinUtility.Logger.Dbg("Creating MapWindow Application Data Directory: " + AppDataDir)
                System.IO.Directory.CreateDirectory(AppDataDir)
            End If
        Catch e As System.IO.IOException
            MapWinUtility.Logger.Dbg("Save Configuration - MapWindow Application Data Directory: Exception: " + e.ToString())
        Catch
        End Try
        Return AppDataDir
    End Function
#End Region

#Region "Save Config File"
    'This region includes functions that are part of saving the config file.

    Public Function SaveConfig() As Boolean

        Dim AppDataDir As String = GetApplicationDataDir() '8/5/2008 jk - find the default directory for config files

        'save dock panel configuration
        Try
            MapWinUtility.Logger.Dbg("Saving Dock Panel Configuration: " + _
            System.IO.Path.Combine(AppDataDir, "MapWindowDock.config"))
            frmMain.dckPanel.SaveAsXml(System.IO.Path.Combine(AppDataDir, "MapWindowDock.config"))
        Catch e As System.IO.IOException
            MapWinUtility.Logger.Dbg("Saving Dock Panel Configuration: Exception: " + e.ToString())
        End Try

        '8/5/2008 jk - save the language settings
        SaveCulture()

        'This function saves the config file. In prior versions, filename was 
        'a parameter.  Now it is a local variable. 
        'Also, version 3 used the DotNetBar which had an export function
        'that would export the current layout of the bars. This has been removed.
        Dim Root As XmlElement
        Dim Ver As String

        Try
            Ver = App.VersionString()
            p_Doc.LoadXml("<Mapwin type='configurationfile' version='" + Ver + "'></Mapwin>")
            Root = p_Doc.DocumentElement

            'Add the AppInfo
            AddAppInfo(p_Doc, Root)

            'Add the recent projects
            AddRecentProjects(p_Doc, Root)

            'Add the properties of the view to the project file
            AddViewElement(p_Doc, Root)

            'Add the list of the plugins to the project file
            AddPluginsElement(p_Doc, Root, True)

            'Add the application plugins - these are plugins that are 
            'required by a particular application - e.g. BASINS specific 
            'plugins.
            AddApplicationPluginsElement(p_Doc, Root, True)

            'add the ColorPalettes to the config file
            AddColorPalettes(p_Doc, Root)

            MapWinUtility.Logger.Dbg("Saving Configuration: " + ConfigFileName)
            p_Doc.Save(ConfigFileName)

            Return True
        Catch ex As System.Exception
            ShowError(ex)
            Return False
        End Try
    End Function

    Private Sub SaveCulture()
        'This sub saves the custom culture (language) settings. If OverrideSystemLocale is true,
        'MapWindow will use the language specified by "Locale" instead of the Windows Regional and 
        'Language settings.
        'This information is saved in a separate file, because the culture must be loaded very soon
        'after MapWindow startup, before the initialization of the UI.
        'added by Jiri Kadlec 8.May 2008

        Try
            Dim cultureFileName As String = System.IO.Path.Combine(GetApplicationDataDir(), "mwLanguage.config")
            Dim doc As New XmlDocument

            ' Use the XmlDeclaration class to place the
            ' <?xml version="1.0"?> declaration at the top of our XML file
            Dim dec As XmlDeclaration = doc.CreateXmlDeclaration("1.0", Nothing, Nothing)
            doc.AppendChild(dec)

            Dim Root As XmlElement = doc.CreateElement("mwLanguageSettings")
            doc.AppendChild(Root)
            Dim CultureXML As XmlElement = doc.CreateElement("Culture")

            Dim OverrideXML As XmlAttribute = doc.CreateAttribute("OverrideSystemLocale")
            OverrideXML.InnerText = AppInfo.OverrideSystemLocale
            CultureXML.Attributes.Append(OverrideXML)

            Dim LanguageXML As XmlAttribute = doc.CreateAttribute("Locale")
            LanguageXML.InnerText = AppInfo.Locale
            CultureXML.Attributes.Append(LanguageXML)
            Root.AppendChild(CultureXML)

            doc.Save(cultureFileName)

        Catch ex As System.Exception
            MapWinUtility.Logger.Dbg("Saving Language Configuration: Exception: " + ex.ToString())
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AddAppInfo(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement)
        'This sub writes the customizable application info to the configuration file.
        'This info is now pulled from the global AppInfo object as of version 4.
        '1/16/2005
        Dim AppInfoXML As XmlElement = m_Doc.CreateElement("AppInfo")
        Dim SplashImage As XmlElement = m_Doc.CreateElement("SplashPicture")
        Dim WindowIcon As XmlElement = m_Doc.CreateElement("WindowIcon")
        Dim Name As XmlAttribute = m_Doc.CreateAttribute("Name")
        Dim Version As XmlAttribute = m_Doc.CreateAttribute("Version")
        Dim BuildDate As XmlAttribute = m_Doc.CreateAttribute("BuildDate")
        Dim Developer As XmlAttribute = m_Doc.CreateAttribute("Developer")
        Dim Comments As XmlAttribute = m_Doc.CreateAttribute("Comments")
        Dim HelpFilePath As XmlAttribute = m_Doc.CreateAttribute("HelpFilePath")
        Dim UseSplashScreen As XmlAttribute = m_Doc.CreateAttribute("UseSplashScreen")
        Dim SplashPicture As XmlAttribute = m_Doc.CreateAttribute("SplashPicture")
        Dim SplashTime As XmlAttribute = m_Doc.CreateAttribute("SplashTime")
        Dim DefaultDir As XmlAttribute = m_Doc.CreateAttribute("DefaultDir")
        Dim URL As XmlAttribute = m_Doc.CreateAttribute("URL")
        Dim ShowWelcomeScreen As XmlAttribute = m_Doc.CreateAttribute("ShowWelcomeScreen")
        Dim WelcomePlugin As XmlAttribute = m_Doc.CreateAttribute("WelcomePlugin")
        Dim NeverShowProjectionDialog As XmlAttribute = m_Doc.CreateAttribute("NeverShowProjectionDialog")
        Dim NoPromptToSendErrorsXml As XmlAttribute = m_Doc.CreateAttribute("NoPromptToSendErrors")
        Dim LogfilePathXml As XmlAttribute = m_Doc.CreateAttribute("LogfilePath")
        Dim ShowDynVisWarningsXml As XmlAttribute = m_Doc.CreateAttribute("ShowDynVisWarnings")
        Dim ShowLayerAfterDynVisXml As XmlAttribute = m_Doc.CreateAttribute("ShowLayerAfterDynVis")


        'Set the attributes
        ShowLayerAfterDynVisXml.InnerText = AppInfo.ShowLayerAfterDynamicVisibility
        ShowDynVisWarningsXml.InnerText = AppInfo.ShowDynamicVisibilityWarnings
        LogfilePathXml.InnerText = AppInfo.LogfilePath
        Name.InnerText = AppInfo.Name
        Version.InnerText = AppInfo.Version
        BuildDate.InnerText = AppInfo.BuildDate
        Developer.InnerText = AppInfo.Developer
        Comments.InnerText = AppInfo.Comments
        HelpFilePath.InnerText = GetRelativePath(AppInfo.HelpFilePath, System.Reflection.Assembly.GetAssembly(Me.GetType).Location)
        HelpFilePath.InnerText = GetRelativePath(AppInfo.HelpFilePath, ConfigFileName) 'changed by Jiri Kadlec May-30-2008
        SplashTime.InnerText = AppInfo.SplashTime.ToString()
        DefaultDir.InnerText = GetRelativePath(AppInfo.DefaultDir, System.Reflection.Assembly.GetAssembly(Me.GetType).Location)
        URL.InnerText = AppInfo.URL
        ShowWelcomeScreen.InnerText = AppInfo.ShowWelcomeScreen.ToString()
        WelcomePlugin.InnerText = AppInfo.WelcomePlugin
        NeverShowProjectionDialog.InnerText = AppInfo.NeverShowProjectionDialog.ToString
        NoPromptToSendErrorsXml.InnerText = NoPromptToSendErrors.ToString()

        'Add the attributes to the appInfo element
        With AppInfoXML.Attributes
            .Append(Name)
            .Append(Version)
            .Append(BuildDate)
            .Append(Developer)
            .Append(Comments)
            .Append(HelpFilePath)
            .Append(UseSplashScreen)
            .Append(SplashTime)
            .Append(DefaultDir)
            .Append(URL)
            .Append(ShowWelcomeScreen)
            .Append(WelcomePlugin)
            .Append(NeverShowProjectionDialog)
            .Append(NoPromptToSendErrorsXml)
            .Append(LogfilePathXml)
            .Append(ShowDynVisWarningsXml)
            .Append(ShowLayerAfterDynVisXml)
        End With

        SaveImage(m_Doc, AppInfo.SplashPicture, SplashImage)
        SaveImage(m_Doc, frmMain.Icon, WindowIcon)

        AppInfoXML.AppendChild(WindowIcon)
        AppInfoXML.AppendChild(SplashImage)

        Parent.AppendChild(AppInfoXML)
    End Sub

    Private Sub AddRecentProjects(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement)
        'Adds information about the recent projects to the XML document
        'Changed in v.4. to pull recent projects from projinfo object.
        '1/16/2005
        Try
            Dim i As Integer
            Dim RecentFiles As XmlElement = m_Doc.CreateElement("RecentProjects")
            Dim FileXML As XmlElement

            If ProjInfo.RecentProjects.Count <> 0 Then
                For i = 0 To ProjInfo.RecentProjects.Count - 1
                    FileXML = m_Doc.CreateElement("Project")
                    FileXML.InnerText = Me.GetRelativePath(ProjInfo.RecentProjects(i).ToString, ConfigFileName)
                    RecentFiles.AppendChild(FileXML)
                Next
            End If

            Parent.AppendChild(RecentFiles)
        Catch ex As System.Exception
            ShowError(ex)
        End Try
    End Sub

    Private Sub AddBookmarks(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement)
        Dim bookmarksElem As XmlElement = m_Doc.CreateElement("Bookmarks")

        For i As Integer = 0 To BookmarkedViews.Count - 1
            Dim bm As XmlElement = m_Doc.CreateElement("Bookmark")
            Dim attr As XmlAttribute = m_Doc.CreateAttribute("Name")
            attr.InnerText = BookmarkedViews(i).name
            bm.Attributes.Append(attr)
            AddExtentsElement(m_Doc, bm, BookmarkedViews(i).exts)

            bookmarksElem.AppendChild(bm)
        Next

        Parent.AppendChild(bookmarksElem)
    End Sub

    Private Sub AddViewElement(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement)
        'Adds information about the current view to the config file. 
        'At this point, frmMain must exist or this function will die.
        Dim View As XmlElement = m_Doc.CreateElement("View")
        Dim WindowWidth As XmlAttribute = m_Doc.CreateAttribute("WindowWidth")
        Dim WindowHeight As XmlAttribute = m_Doc.CreateAttribute("WindowHeight")
        Dim LocationX As XmlAttribute = m_Doc.CreateAttribute("LocationX")
        Dim LocationY As XmlAttribute = m_Doc.CreateAttribute("LocationY")
        Dim WindowState As XmlAttribute = m_Doc.CreateAttribute("WindowState")
        Dim ViewColor As XmlAttribute = m_Doc.CreateAttribute("ViewBackColor")
        Dim CanUndockPreviewMap As XmlAttribute = m_Doc.CreateAttribute("CanUndockPreviewMap")
        Dim CanUndockLegend As XmlAttribute = m_Doc.CreateAttribute("CanUndockLegend")
        Dim CanHidePreviewMap As XmlAttribute = m_Doc.CreateAttribute("CanHidePreviewMap")
        Dim CanHideLegend As XmlAttribute = m_Doc.CreateAttribute("CanHideLegend")
        Dim ShowCustomizeContextMenuStrip As XmlAttribute = m_Doc.CreateAttribute("ShowCustomizeContextMenuStrip")
        Dim CanPreviewMapDockLeft As XmlAttribute = m_Doc.CreateAttribute("CanPreviewMapDockLeft")
        Dim CanLegendDockLeft As XmlAttribute = m_Doc.CreateAttribute("CanLegendDockLeft")
        Dim CanPreviewMapDockRight As XmlAttribute = m_Doc.CreateAttribute("CanPreviewMapDockRight")
        Dim CanLegendDockRight As XmlAttribute = m_Doc.CreateAttribute("CanLegendDockRight")
        Dim LoadTIFFandIMGasgridAttr As Xml.XmlAttribute = m_Doc.CreateAttribute("LoadTIFFandIMGasgrid")
        Dim LoadESRIAsGridAttr As Xml.XmlAttribute = m_Doc.CreateAttribute("LoadESRIAsGrid")
        Dim MouseWheelBehavior As Xml.XmlAttribute = m_Doc.CreateAttribute("MouseWheelBehavior")
        Dim TransparentSelectionAttr As Xml.XmlAttribute = m_Doc.CreateAttribute("TransparentSelection")
        Dim LabelsUseProjectLevel As Xml.XmlAttribute = m_Doc.CreateAttribute("LabelsUseProjectLevel")

        'set the properties
        With frmMain
            If .WindowState = FormWindowState.Maximized Then
                WindowState.InnerText = CInt(.WindowState.Maximized).ToString
                LocationX.InnerText = "692"
                LocationY.InnerText = "531"
                WindowWidth.InnerText = "163"
                WindowHeight.InnerText = "68"
            ElseIf .WindowState = FormWindowState.Normal Then
                WindowState.InnerText = CInt(FormWindowState.Normal).ToString
                LocationX.InnerText = .Location.X.ToString()
                LocationY.InnerText = .Location.Y.ToString()
                WindowWidth.InnerText = .Width.ToString()
                WindowHeight.InnerText = .Height.ToString()
            ElseIf .WindowState = FormWindowState.Minimized Then
                WindowState.InnerText = CInt(FormWindowState.Minimized).ToString
                LocationX.InnerText = "692"
                LocationY.InnerText = "531"
                WindowWidth.InnerText = "163"
                WindowHeight.InnerText = "68"
            End If

            LoadTIFFandIMGasgridAttr.InnerText = AppInfo.LoadTIFFandIMGasgrid.ToString()
            LoadESRIAsGridAttr.InnerText = AppInfo.LoadESRIAsGrid.ToString()
            MouseWheelBehavior.InnerText = AppInfo.MouseWheelZoom.ToString()
            LabelsUseProjectLevel.InnerText = AppInfo.LabelsUseProjectLevel.ToString()

            'Save the preview map and legend prop
            CanUndockPreviewMap.InnerText = frmMain.g_PreviewMapProp.CanUndock.ToString 'frmMain.dockMan.Bars("dwPreviewMap").CanUndock.ToString
            CanPreviewMapDockRight.InnerText = frmMain.g_PreviewMapProp.CanDockRight.ToString 'frmMain.dockMan.Bars("dwPreviewMap").CanDockRight.ToString
            CanPreviewMapDockLeft.InnerText = frmMain.g_PreviewMapProp.CanDockLeft.ToString 'frmMain.dockMan.Bars("dwPreviewMap").CanDockLeft.ToString
            CanHidePreviewMap.InnerText = frmMain.g_PreviewMapProp.CanHide.ToString 'frmMain.dockMan.Bars("dwPreviewMap").CanHide.ToString

            CanUndockLegend.InnerText = frmMain.g_LegendProp.CanUndock.ToString 'frmMain.dockMan.Bars("dwLegend").CanUndock.ToString
            CanHideLegend.InnerText = frmMain.g_LegendProp.CanHide.ToString 'frmMain.dockMan.Bars("dwLegend").CanHide.ToString
            CanLegendDockLeft.InnerText = frmMain.g_LegendProp.CanDockLeft.ToString 'frmMain.dockMan.Bars("dwLegend").CanDockLeft.ToString
            CanLegendDockRight.InnerText = frmMain.g_LegendProp.CanDockRight.ToString 'frmMain.dockMan.Bars("dwLegend").CanDockRight.ToString

            'save the view back color
            ViewColor.InnerText = MapWinUtility.Colors.ColorToInteger(AppInfo.DefaultBackColor).ToString
            TransparentSelectionAttr.InnerText = TransparentSelection.ToString()
        End With

        'add attributes to the view
        View.Attributes.Append(LabelsUseProjectLevel)
        View.Attributes.Append(TransparentSelectionAttr)
        View.Attributes.Append(WindowWidth)
        View.Attributes.Append(WindowHeight)
        View.Attributes.Append(LocationX)
        View.Attributes.Append(LocationY)
        View.Attributes.Append(WindowState)
        View.Attributes.Append(ViewColor)
        View.Attributes.Append(CanUndockPreviewMap)
        View.Attributes.Append(CanUndockLegend)
        View.Attributes.Append(CanHidePreviewMap)
        View.Attributes.Append(CanHideLegend)
        View.Attributes.Append(ShowCustomizeContextMenuStrip)
        View.Attributes.Append(CanPreviewMapDockLeft)
        View.Attributes.Append(CanLegendDockLeft)
        View.Attributes.Append(CanPreviewMapDockRight)
        View.Attributes.Append(CanLegendDockRight)
        View.Attributes.Append(LoadTIFFandIMGasgridAttr)
        View.Attributes.Append(LoadESRIAsGridAttr)
        View.Attributes.Append(MouseWheelBehavior)

        Parent.AppendChild(View)
    End Sub

    Private Sub AddPluginsElement(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement, ByVal LoadingConfig As Boolean)
        'Adds the plugins to the configuration file.
        Dim Plugins As XmlElement = m_Doc.CreateElement("Plugins")
        Dim Plugin As Interfaces.PluginInfo

        Dim ar As Collection = frmMain.m_PluginManager.LoadedPlugins
        'Note that collections start at 1 for some bizarre reason
        For i As Integer = 1 To ar.Count
            Plugin = CType(frmMain.m_PluginManager.PluginsList(MapWinUtility.PluginManagementTools.GenerateKey(ar(i).GetType())), Interfaces.PluginInfo)
            AddPluginElement(m_Doc, ar(i), Plugin.Key, Plugins, LoadingConfig)
        Next

        Parent.AppendChild(Plugins)
    End Sub

    Private Sub AddPluginElement(ByRef m_Doc As Xml.XmlDocument, ByVal Plugin As Object, ByVal PluginKey As String, ByVal Parent As XmlElement, ByVal LoadingConfig As Boolean)
        'Adds information for a single plugin to the configuration file.
        Dim NewPlugin As XmlElement = m_Doc.CreateElement("Plugin")
        Dim SettingsString As XmlAttribute = m_Doc.CreateAttribute("SettingsString")
        Dim KeyXML As XmlAttribute = m_Doc.CreateAttribute("Key")
        Dim SetString As String = ""

        'Plugin properties
        If LoadingConfig = False Then
            'Saving project
            If TypeOf Plugin Is MapWindow.Interfaces.IPlugin Or TypeOf Plugin Is MapWindow.PluginInterfaces.IProjectEvents Then
                Plugin.ProjectSaving(ProjectFileName, SetString)
            Else
                SetString = ""
            End If
        End If

        SettingsString.InnerText = SetString
        KeyXML.InnerText = PluginKey

        NewPlugin.Attributes.Append(SettingsString)
        NewPlugin.Attributes.Append(KeyXML)

        Parent.AppendChild(NewPlugin)
    End Sub

    Private Sub AddApplicationPluginsElement(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement, ByVal LoadingConfig As Boolean)
        'Adds information about application required plugins to the config file XML
        Dim Plugins As XmlElement = m_Doc.CreateElement("ApplicationPlugins")
        Dim Dir As XmlAttribute = m_Doc.CreateAttribute("PluginDir")
        Dim Plugin As Interfaces.IPlugin
        Dim Item As DictionaryEntry
        'Dim PluginInfo As PluginInfo - unused

        'save the application dir
        Dir.InnerText = Me.GetRelativePath(AppInfo.ApplicationPluginDir, ConfigFileName)

        'save all of the application plugins
        For Each Item In frmMain.m_PluginManager.m_ApplicationPlugins
            If Not Item.Value Is Nothing Then
                If TypeOf Item.Value Is Interfaces.IPlugin Then
                    Plugin = CType(Item.Value, Interfaces.IPlugin)
                    AddPluginElement(m_Doc, Plugin, Item.Key.ToString(), Plugins, LoadingConfig)
                Else
                    Plugin = CType(Item.Value, PluginInterfaces.IBasePlugin)
                    AddPluginElement(m_Doc, Plugin, Item.Key.ToString(), Plugins, LoadingConfig)
                End If
            End If
        Next

        Plugins.Attributes.Append(Dir)
        Parent.AppendChild(Plugins)
    End Sub

    Private Sub AddColorPalettes(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement)
        'Adds info about the color pallettes to the config xml
        Try
            Dim ColorPalettes As XmlElement = m_Doc.CreateElement("ColorPalettes")

            If Not frmMain.g_ColorPalettes Is Nothing Then
                Dim docFragment As Xml.XmlDocumentFragment = m_Doc.CreateDocumentFragment
                docFragment.InnerXml = frmMain.g_ColorPalettes.InnerXml

                ColorPalettes.AppendChild(docFragment)
            End If

            Parent.AppendChild(ColorPalettes)
        Catch ex As System.Exception
            ShowError(ex)
        End Try
    End Sub

#End Region

#Region "Save Project File"
    'this region includes functions that are part of saving the project file

    Public Function SaveProject() As Boolean
        'This function saves XML project files. As with the "SaveConfig" function,
        'this expects a current frmMain object from which to grab some info.
        Dim Root As XmlElement
        Dim Ver As String
        Dim ConfigPath As XmlAttribute

        If Len(ProjectFileName) = 0 Then
            Return False
            Exit Function
        End If

        Try
            Ver = App.VersionString()

            '**** add the following elements to "mwprj" ****
            p_Doc = New XmlDocument
            Dim prjName As String = frmMain.Text.Replace("'", "")
            p_Doc.LoadXml("<Mapwin name='" + System.Web.HttpUtility.UrlEncode(prjName) + "' type='projectfile' version='" + System.Web.HttpUtility.UrlEncode(Ver) + "'></Mapwin>")
            Root = p_Doc.DocumentElement

            'Add the configuration path
            ConfigPath = p_Doc.CreateAttribute("ConfigurationPath")
            ConfigPath.InnerText = GetRelativePath(ConfigFileName, ProjectFileName)
            Root.Attributes.Append(ConfigPath)

            'Add the projection
            Dim proj As Xml.XmlAttribute = p_Doc.CreateAttribute("ProjectProjection")
            proj.InnerText = ProjectProjection
            Root.Attributes.Append(proj)

            'Add the map units
            Dim mapunit As Xml.XmlAttribute = p_Doc.CreateAttribute("MapUnits")
            mapunit.InnerText = modMain.frmMain.Project.MapUnits
            Root.Attributes.Append(mapunit)

            'Add the status bar coord customizations
            Dim xStatusBarAlternateCoordsNumDecimals As Xml.XmlAttribute = p_Doc.CreateAttribute("StatusBarAlternateCoordsNumDecimals")
            xStatusBarAlternateCoordsNumDecimals.InnerText = StatusBarAlternateCoordsNumDecimals.ToString()
            Root.Attributes.Append(xStatusBarAlternateCoordsNumDecimals)
            Dim xStatusBarCoordsNumDecimals As Xml.XmlAttribute = p_Doc.CreateAttribute("StatusBarCoordsNumDecimals")
            xStatusBarCoordsNumDecimals.InnerText = StatusBarCoordsNumDecimals.ToString()
            Root.Attributes.Append(xStatusBarCoordsNumDecimals)
            Dim xStatusBarAlternateCoordsUseCommas As Xml.XmlAttribute = p_Doc.CreateAttribute("StatusBarAlternateCoordsUseCommas")
            xStatusBarAlternateCoordsUseCommas.InnerText = StatusBarAlternateCoordsUseCommas.ToString()
            Root.Attributes.Append(xStatusBarAlternateCoordsUseCommas)
            Dim xStatusBarCoordsUseCommas As Xml.XmlAttribute = p_Doc.CreateAttribute("StatusBarCoordsUseCommas")
            xStatusBarCoordsUseCommas.InnerText = StatusBarCoordsUseCommas.ToString()
            Root.Attributes.Append(xStatusBarCoordsUseCommas)

            Dim ShowFloatingScaleBar As Xml.XmlAttribute = p_Doc.CreateAttribute("ShowFloatingScaleBar")
            ShowFloatingScaleBar.InnerText = frmMain.m_FloatingScalebar_Enabled.ToString()
            Root.Attributes.Append(ShowFloatingScaleBar)

            Dim FloatingScaleBarPosition As Xml.XmlAttribute = p_Doc.CreateAttribute("FloatingScaleBarPosition")
            FloatingScaleBarPosition.InnerText = frmMain.m_FloatingScalebar_ContextMenu_SelectedPosition
            Root.Attributes.Append(FloatingScaleBarPosition)

            Dim FloatingScaleBarUnit As Xml.XmlAttribute = p_Doc.CreateAttribute("FloatingScaleBarUnit")
            FloatingScaleBarUnit.InnerText = frmMain.m_FloatingScalebar_ContextMenu_SelectedUnit
            Root.Attributes.Append(FloatingScaleBarUnit)

            Dim FloatingScaleBarForecolor As Xml.XmlAttribute = p_Doc.CreateAttribute("FloatingScaleBarForecolor")
            FloatingScaleBarForecolor.InnerText = frmMain.m_FloatingScalebar_ContextMenu_ForeColor.ToArgb().ToString()
            Root.Attributes.Append(FloatingScaleBarForecolor)

            Dim FloatingScaleBarBackcolor As Xml.XmlAttribute = p_Doc.CreateAttribute("FloatingScaleBarBackcolor")
            FloatingScaleBarBackcolor.InnerText = frmMain.m_FloatingScalebar_ContextMenu_BackColor.ToArgb().ToString()
            Root.Attributes.Append(FloatingScaleBarBackcolor)

            'Add the map resize behavior
            Dim resizebehavior As Xml.XmlAttribute = p_Doc.CreateAttribute("MapResizeBehavior")
            resizebehavior.InnerText = CType(modMain.frmMain.MapMain.MapResizeBehavior, Short).ToString()
            Root.Attributes.Append(resizebehavior)

            'Add whether to display various coordinate systems in the status bar
            Dim coord_projected As Xml.XmlAttribute = p_Doc.CreateAttribute("ShowStatusBarCoords_Projected")
            coord_projected.InnerText = ShowStatusBarCoords_Projected.ToString()
            Root.Attributes.Append(coord_projected)
            Dim coord_alternate As Xml.XmlAttribute = p_Doc.CreateAttribute("ShowStatusBarCoords_Alternate")
            coord_alternate.InnerText = ShowStatusBarCoords_Alternate
            Root.Attributes.Append(coord_alternate)

            'Add the save shape settings behavior
            Dim saveshapesettinfgsbehavior As Xml.XmlAttribute = p_Doc.CreateAttribute("SaveShapeSettings")
            saveshapesettinfgsbehavior.InnerText = Me.SaveShapeSettings.ToString()
            Root.Attributes.Append(saveshapesettinfgsbehavior)

            'Add the project-level map background color settings (5/4/2008 added by JK)
            Dim backColor_useDefault As Xml.XmlAttribute = p_Doc.CreateAttribute("ViewBackColor_UseDefault")
            backColor_useDefault.InnerText = UseDefaultBackColor.ToString
            Root.Attributes.Append(backColor_useDefault)
            Dim backColor As Xml.XmlAttribute = p_Doc.CreateAttribute("ViewBackColor")
            backColor.InnerText = (MapWinUtility.Colors.ColorToInteger(ProjectBackColor)).ToString
            Root.Attributes.Append(backColor)

            'Add this project to the list of recent projects
            AddToRecentProjects(ProjectFileName)

            'Add the list of the plugins to the project file
            AddPluginsElement(p_Doc, Root, False)

            'Add the application plugins
            AddApplicationPluginsElement(p_Doc, Root, False)

            'Add extents of map
            AddExtentsElement(p_Doc, Root, frmMain.MapMain.Extents)

            'Add the layers
            AddLayers(p_Doc, Root)

            'Add view bookmarks
            AddBookmarks(p_Doc, Root)

            'Add the properies fo the preview Map to the project file
            AddPreViewMapElement(p_Doc, Root)

            'Save the project file.
            MapWinUtility.Logger.Dbg("Saving Project: " + ProjectFileName)
            Try
                p_Doc.Save(ProjectFileName)
                frmMain.SetModified(False)
                Return True
            Catch e As System.UnauthorizedAccessException
                Dim ro As Boolean = False
                If System.IO.File.Exists(ProjectFileName) Then
                    Dim fi As New System.IO.FileInfo(ProjectFileName)
                    If fi.IsReadOnly Then ro = True
                End If
                If ro Then
                    MapWinUtility.Logger.Msg("The project file could not be saved because it is read-only." + Environment.NewLine + Environment.NewLine + "Please have your system administrator grant write access to the file:" + Environment.NewLine + ProjectFileName, MsgBoxStyle.Exclamation, "Read-Only File")
                Else
                    MapWinUtility.Logger.Msg("The project file could not be saved due to insufficient access." + Environment.NewLine + Environment.NewLine + "Please have your system administrator grant access to the file:" + Environment.NewLine + ProjectFileName, MsgBoxStyle.Exclamation, "Insufficient Access")
                End If
                Return False
            End Try
        Catch ex As System.Exception
            ShowError(ex)
            Return False
        End Try
    End Function

    Private Sub AddExtentsElement(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement, ByVal Exts As MapWinGIS.Extents)
        'Adds extents information to the project XML
        Dim Extents As XmlElement = m_Doc.CreateElement("Extents")
        Dim xMax As XmlAttribute = m_Doc.CreateAttribute("xMax")
        Dim yMax As XmlAttribute = m_Doc.CreateAttribute("yMax")
        Dim xMin As XmlAttribute = m_Doc.CreateAttribute("xMin")
        Dim yMin As XmlAttribute = m_Doc.CreateAttribute("yMin")

        With Exts
            xMax.InnerText = .xMax.ToString()
            yMax.InnerText = .yMax.ToString()
            xMin.InnerText = .xMin.ToString()
            yMin.InnerText = .yMin.ToString()
        End With

        Extents.Attributes.Append(xMax)
        Extents.Attributes.Append(yMax)
        Extents.Attributes.Append(xMin)
        Extents.Attributes.Append(yMin)

        Parent.AppendChild(Extents)
    End Sub

    Private Sub AddPreViewMapElement(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement)
        'Adds preview map information to the project xml
        Dim prevMap As XmlElement = m_Doc.CreateElement("PreviewMap")
        Dim visible As XmlAttribute = m_Doc.CreateAttribute("Visible")
        Dim dx As XmlAttribute = m_Doc.CreateAttribute("dx")
        Dim dy As XmlAttribute = m_Doc.CreateAttribute("dy")
        Dim xllcenter As XmlAttribute = m_Doc.CreateAttribute("xllcenter")
        Dim yllcenter As XmlAttribute = m_Doc.CreateAttribute("yllcenter")

        If (frmMain.MapPreview.NumLayers > 0) Then
            Dim img As MapWinGIS.Image = CType(frmMain.MapPreview.get_GetObject(0), MapWinGIS.Image)
            With img
                dx.InnerText = .dX.ToString
                dy.InnerText = .dY.ToString
                xllcenter.InnerText = .XllCenter.ToString
                yllcenter.InnerText = .YllCenter.ToString
            End With
        Else
            dx.InnerText = "0"
            dy.InnerText = "0"
            xllcenter.InnerText = "0"
            yllcenter.InnerText = "0"
        End If

        prevMap.Attributes.Append(dx)
        prevMap.Attributes.Append(dy)
        prevMap.Attributes.Append(xllcenter)
        prevMap.Attributes.Append(yllcenter)

        'set the properties'
        SaveImage(m_Doc, frmMain.PreviewMap.Picture, prevMap)

        'add the elements to the prevMap
        Parent.AppendChild(prevMap)
    End Sub

    Private Sub AddLayers(ByRef m_Doc As Xml.XmlDocument, ByVal Parent As XmlElement)
        'Add info about the current layers to the XML project file
        Dim Groups As XmlElement = m_Doc.CreateElement("Groups")
        Dim Layers As XmlElement
        Dim Group As XmlElement
        Dim Name As XmlAttribute
        Dim Expanded As XmlAttribute
        Dim Position As XmlAttribute
        Dim LayerPos As XmlAttribute = m_Doc.CreateAttribute("Position")
        Dim NumGroups, numLayers As Integer
        Dim LHandle As Integer
        Dim g, l As Integer

        'Add all groups and their layers
        NumGroups = frmMain.Legend.Groups.Count
        For g = 0 To NumGroups - 1
            Group = m_Doc.CreateElement("Group")
            Name = m_Doc.CreateAttribute("Name")
            Expanded = m_Doc.CreateAttribute("Expanded")
            Position = m_Doc.CreateAttribute("Position")

            'Add the properties of the element
            Name.InnerText = frmMain.Legend.Groups(g).Text
            Expanded.InnerText = frmMain.Legend.Groups(g).Expanded.ToString
            Position.InnerText = g.ToString
            Group.Attributes.Append(Name)
            Group.Attributes.Append(Expanded)
            Group.Attributes.Append(Position)
            SaveImage(m_Doc, frmMain.Legend.Groups(g).Icon, Group)

            'Add all the layers under this group
            numLayers = frmMain.Legend.Groups(g).LayerCount
            If (numLayers > 0) Then
                Layers = m_Doc.CreateElement("Layers")
                For l = 0 To numLayers - 1
                    If Not frmMain.Legend.Groups(g)(l).SkipOverDuringSave Then
                        LHandle = frmMain.Legend.Groups(g)(l).Handle
                        AddLayerElement(m_Doc, frmMain.Layers(LHandle), Layers)
                    End If
                Next
                Group.AppendChild(Layers)
            End If
            Groups.AppendChild(Group)
        Next
        Parent.AppendChild(Groups)
    End Sub

    Friend Sub AddLayerElement(ByRef m_doc As Xml.XmlDocument, ByVal mapWinLayer As Interfaces.Layer, ByVal parent As Xml.XmlNode)
        Dim layer As XmlElement = m_doc.CreateElement("Layer")
        Dim name As XmlAttribute = m_doc.CreateAttribute("Name")
        Dim groupname As XmlAttribute = m_doc.CreateAttribute("GroupName")
        Dim type As XmlAttribute = m_doc.CreateAttribute("Type")
        Dim path As XmlAttribute = m_doc.CreateAttribute("Path")
        Dim tag As XmlAttribute = m_doc.CreateAttribute("Tag")
        Dim legPic As XmlAttribute = m_doc.CreateAttribute("LegendPicture")
        Dim visible As XmlAttribute = m_doc.CreateAttribute("Visible")
        Dim labelsVisible As XmlAttribute = m_doc.CreateAttribute("LabelsVisible")
        Dim expanded As XmlAttribute = m_doc.CreateAttribute("Expanded")

        'set the properties of the elements
        With mapWinLayer
            name.InnerText = .Name()
            groupname.InnerText = frmMain.Layers.Groups.ItemByHandle(.GroupHandle).Text
            type.InnerText = CInt(.LayerType).ToString
            tag.InnerText = .Tag()
            visible.InnerText = .Visible().ToString
            labelsVisible.InnerText = .LabelsVisible().ToString
            expanded.InnerText = .Expanded.ToString
            SaveImage(m_doc, .Icon, layer)
            'SaveMapImage(.UserPointType.Picture, layer)

            'check to see if there is a grid associated with this layer
            Dim fileName As String

            fileName = .FileName
            'check to see if this layers is in memeory if so prompt to save
            Dim results As Microsoft.VisualBasic.MsgBoxResult
            Dim nameF As String
            If (System.IO.File.Exists(.FileName) = False) Then
                results = MapWinUtility.Logger.Msg(.Name + " file is in memory do you want to save it", MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Save Layer")
                If (results = MsgBoxResult.Yes) Then
                    nameF = Me.SaveLayer(mapWinLayer, .Handle, mapWinLayer.LayerType)
                    If (nameF <> "") Then
                        fileName = nameF
                    End If
                End If
            End If

            If Len(fileName) <> 0 Then
                path.InnerText = GetRelativePath(fileName, ProjectFileName)
            Else
                path.InnerText = GetRelativePath(.FileName, ProjectFileName)
            End If

        End With

        'add the elements to the layer node
        layer.Attributes.Append(name)
        layer.Attributes.Append(groupname)
        layer.Attributes.Append(type)
        layer.Attributes.Append(path)
        layer.Attributes.Append(tag)
        layer.Attributes.Append(legPic)
        layer.Attributes.Append(visible)
        layer.Attributes.Append(labelsVisible)
        layer.Attributes.Append(expanded)

        'if it is a shapfile then add the shape properties to the layer
        If TypeOf (mapWinLayer.GetObject) Is MapWinGIS.IShapefile Then
            AddShapeFileElement(m_doc, mapWinLayer, layer)
            'add the grid file properties
        ElseIf TypeOf (mapWinLayer.GetObject) Is MapWinGIS.IImage Or TypeOf (mapWinLayer.GetObject) Is MapWinGIS.Grid Then
            AddGridElement(m_doc, mapWinLayer, layer)
        End If

        'add DynamicVisibility options
        AddDynamicVisibility(m_doc, mapWinLayer, layer)

        'add the layer to the parent
        parent.AppendChild(layer)

    End Sub

    ''save the map background color as a project-level setting
    'Private Sub AddMapView(ByRef m_Doc As Xml.XmlDocument, ByVal parent As Xml.XmlNode, ByVal mapBackColor As Color)
    '    Dim mapView As XmlElement = m_Doc.CreateElement("MapView")
    '    Dim backColor As XmlElement = m_Doc.CreateElement("BackColor")
    '    backColor.InnerText = MapWinUtility.Colors.ColorToInteger(mapBackColor).ToString
    'End Sub

    Private Sub AddDynamicVisibility(ByRef m_Doc As Xml.XmlDocument, ByVal mapWinLayer As MapWindow.Interfaces.Layer, ByVal parent As Xml.XmlNode)

        'add DynamicVisibility options
        Dim dynamicVisibility As XmlElement = m_Doc.CreateElement("DynamicVisibility")
        Dim useDynamicVisibility As XmlAttribute = m_Doc.CreateAttribute("UseDynamicVisibility")
        Dim xMin As XmlAttribute = m_Doc.CreateAttribute("xMin")
        Dim yMin As XmlAttribute = m_Doc.CreateAttribute("yMin")
        Dim xMax As XmlAttribute = m_Doc.CreateAttribute("xMax")
        Dim yMax As XmlAttribute = m_Doc.CreateAttribute("yMax")

        'DynamicVisibility prop
        With mapWinLayer
            If (Not frmMain.m_AutoVis(.Handle) Is Nothing) Then
                useDynamicVisibility.InnerText = frmMain.m_AutoVis(.Handle).UseDynamicExtents.ToString

                xMin.InnerText = frmMain.m_AutoVis(.Handle).DynamicExtents.xMin.ToString
                yMin.InnerText = frmMain.m_AutoVis(.Handle).DynamicExtents.yMin.ToString
                xMax.InnerText = frmMain.m_AutoVis(.Handle).DynamicExtents.xMax.ToString
                yMax.InnerText = frmMain.m_AutoVis(.Handle).DynamicExtents.yMax.ToString

            Else
                useDynamicVisibility.InnerText = CStr(False)
                xMin.InnerText = "0"
                yMin.InnerText = "0"
                xMax.InnerText = "0"
                yMax.InnerText = "0"
            End If
        End With

        'add DynamicVisibility
        dynamicVisibility.Attributes.Append(useDynamicVisibility)
        dynamicVisibility.Attributes.Append(xMin)
        dynamicVisibility.Attributes.Append(yMin)
        dynamicVisibility.Attributes.Append(xMax)
        dynamicVisibility.Attributes.Append(yMax)

        'add the layer to the parent
        parent.AppendChild(dynamicVisibility)
    End Sub

    Private Sub AddShapeFileElement(ByRef m_Doc As Xml.XmlDocument, ByVal shpFileLayer As Interfaces.Layer, ByVal parent As Xml.XmlNode)
        Dim shpFileProp As XmlElement = m_Doc.CreateElement("ShapeFileProperties")
        Dim color As XmlAttribute = m_Doc.CreateAttribute("Color")
        Dim drawFill As XmlAttribute = m_Doc.CreateAttribute("DrawFill")
        Dim transPercent As XmlAttribute = m_Doc.CreateAttribute("TransparencyPercent")
        Dim fillStipple As XmlAttribute = m_Doc.CreateAttribute("FillStipple")
        Dim lineOrPointSize As XmlAttribute = m_Doc.CreateAttribute("LineOrPointSize")
        Dim lineStipple As XmlAttribute = m_Doc.CreateAttribute("LineStipple")
        Dim outLineColor As XmlAttribute = m_Doc.CreateAttribute("OutLineColor")
        Dim pointType As XmlAttribute = m_Doc.CreateAttribute("PointType")
        Dim customFillStipple As XmlAttribute = m_Doc.CreateAttribute("CustomFillStipple")
        Dim customLineStipple As XmlAttribute = m_Doc.CreateAttribute("CustomLineStipple")
        Dim customPointType As XmlElement = m_Doc.CreateElement("CustomPointType")
        Dim useTransparency As XmlAttribute = m_Doc.CreateAttribute("UseTransparency")
        Dim transparencyColor As XmlAttribute = m_Doc.CreateAttribute("TransparencyColor")
        Dim MapTooltipField As XmlAttribute = m_Doc.CreateAttribute("MapTooltipField")
        Dim MapTooltipsEnabled As XmlAttribute = m_Doc.CreateAttribute("MapTooltipsEnabled")
        Dim VertVisible As XmlAttribute = m_Doc.CreateAttribute("VerticesVisible")
        Dim LabelsVisible As XmlAttribute = m_Doc.CreateAttribute("LabelsVisible")
        Dim FillStippleTransparent As XmlAttribute = m_Doc.CreateAttribute("FillStippleTransparent")
        Dim FillStippleLineColor As XmlAttribute = m_Doc.CreateAttribute("FillStippleLineColor")

        'set the properties of the shpfile
        With shpFileLayer
            If .LayerType = Interfaces.eLayerType.PointShapefile Then
                'Vertices are always visible - layer visibility is used to
                'toggle overall visibility here.
                VertVisible.InnerText = "True"
            Else
                VertVisible.InnerText = .VerticesVisible.ToString()
            End If
            LabelsVisible.InnerText = .LabelsVisible.ToString()
            color.InnerText = RGB(.Color.R, .Color.G, .Color.B).ToString
            drawFill.InnerText = .DrawFill.ToString
            fillStipple.InnerText = CInt(.FillStipple).ToString
            lineOrPointSize.InnerText = .LineOrPointSize.ToString
            lineStipple.InnerText = CInt(.LineStipple).ToString
            outLineColor.InnerText = RGB(.OutlineColor.R, .OutlineColor.G, .OutlineColor.B).ToString
            pointType.InnerText = CInt(.PointType).ToString
            ' customFillStipple.InnerText = "".UserFillStipple
            customLineStipple.InnerText = .UserLineStipple.ToString
            transPercent.InnerText = .ShapeLayerFillTransparency.ToString()
            FillStippleTransparent.InnerText = .FillStippleTransparency.ToString()
            FillStippleLineColor.InnerText = .FillStippleLineColor.ToArgb().ToString()

            If .PointType = MapWinGIS.tkPointType.ptUserDefined Then
                SaveImage(m_Doc, .UserPointType.Picture, customPointType)
                useTransparency.InnerText = .UserPointType.UseTransparencyColor.ToString
                transparencyColor.InnerText = .UserPointType.TransparencyColor.ToString()
            Else
                SaveImage(m_Doc, Nothing, customPointType)
                useTransparency.InnerText = "False"
                transparencyColor.InnerText = "0"
            End If
        End With

        Try
            MapTooltipField.InnerText = frmMain.Legend.Layers.ItemByHandle(shpFileLayer.Handle).MapTooltipFieldIndex.ToString()
            MapTooltipsEnabled.InnerText = frmMain.Legend.Layers.ItemByHandle(shpFileLayer.Handle).MapTooltipsEnabled.ToString()
        Catch
        End Try

        'add the attributes
        shpFileProp.Attributes.Append(LabelsVisible)
        shpFileProp.Attributes.Append(MapTooltipField)
        shpFileProp.Attributes.Append(MapTooltipsEnabled)
        shpFileProp.Attributes.Append(VertVisible)
        shpFileProp.Attributes.Append(color)
        shpFileProp.Attributes.Append(drawFill)
        shpFileProp.Attributes.Append(transPercent)
        shpFileProp.Attributes.Append(fillStipple)
        shpFileProp.Attributes.Append(lineOrPointSize)
        shpFileProp.Attributes.Append(lineStipple)
        shpFileProp.Attributes.Append(outLineColor)
        shpFileProp.Attributes.Append(pointType)
        ' shpFileProp.Attributes.Append(customFillStipple)
        shpFileProp.Attributes.Append(customLineStipple)
        shpFileProp.Attributes.Append(useTransparency)
        shpFileProp.Attributes.Append(transparencyColor)
        shpFileProp.Attributes.Append(FillStippleTransparent)
        shpFileProp.Attributes.Append(FillStippleLineColor)

        shpFileProp.AppendChild(customPointType)

        'add the legend properties
        If Not shpFileLayer.ColoringScheme Is Nothing Then
            AddLegendElement(m_Doc, CType(shpFileLayer.ColoringScheme, MapWinGIS.ShapefileColorScheme), shpFileProp, shpFileLayer.Handle)
        End If

        If shpFileLayer.LayerType = Interfaces.eLayerType.PointShapefile AndAlso frmMain.m_PointImageSchemes.Contains(shpFileLayer.Handle) Then
            SerializePointImageScheme(frmMain.m_PointImageSchemes(shpFileLayer.Handle), m_Doc, shpFileProp)
        End If

        If shpFileLayer.LayerType = Interfaces.eLayerType.PolygonShapefile AndAlso frmMain.m_FillStippleSchemes.Contains(shpFileLayer.Handle) Then
            SerializeFillStippleScheme(frmMain.m_FillStippleSchemes(shpFileLayer.Handle), m_Doc, shpFileProp)
        End If

        ' tws 04/29/2007
        AddShapeListElement(m_Doc, shpFileLayer, shpFileProp)

        parent.AppendChild(shpFileProp)
    End Sub

    ' tws 04/29/2007
    ' direct reference to the map here breaks the nesting of these routines
    ' but the per-shape formatting is only visible there, AFAIK... "sorry"
    ' anyway this is not the first ref in this stack to frmMain.MapMain.
    Private Sub AddShapeListElement(ByRef m_Doc As Xml.XmlDocument, ByVal sfl As Interfaces.Layer, ByVal parent As Xml.XmlNode)
        If Not Me.SaveShapeSettings Then Return
        Dim shpPropList As XmlElement = m_Doc.CreateElement("ShapePropertiesList")
        Dim axmap As AxMapWinGIS.AxMap = frmMain.MapMain
        Try
            Dim ccv As New System.Drawing.ColorConverter
            For i As Integer = 0 To sfl.Shapes.NumShapes - 1
                ' add any per-shape settings that differ from the layer
                Dim sProps As XmlElement = m_Doc.CreateElement("ShapeProperties")
                Dim shapeIndex As XmlAttribute = m_Doc.CreateAttribute("ShapeIndex")
                shapeIndex.InnerText = i
                sProps.Attributes.Append(shapeIndex)
                Dim xmla As XmlAttribute = Nothing

                ' we can't(?) get the ShapeInfo directly, 
                ' so we have to query the map for each of the shape properties
                ' that may need to save, if they differ from the layer-level settings
                If sfl.LayerType = Interfaces.eLayerType.LineShapefile _
                Or sfl.LayerType = Interfaces.eLayerType.PolygonShapefile Then
                    ' line and polygon share all the line properties
                    Dim sLD As Boolean = axmap.get_ShapeDrawLine(sfl.Handle, i)
                    Dim sLC As Color = axmap.get_ShapeLineColor(sfl.Handle, i)
                    Dim sLW = axmap.get_ShapeLineWidth(sfl.Handle, i)
                    Dim sLS = axmap.get_ShapeLineStipple(sfl.Handle, i)
                    If (Not sLD) Then ' layer does not have equivalent boolean, one sets linewidth to 0 or > 0
                        xmla = m_Doc.CreateAttribute("DrawLine")
                        xmla.InnerText = sLD
                        sProps.Attributes.Append(xmla)
                    End If
                    If (sLC <> sfl.Color) Then
                        xmla = m_Doc.CreateAttribute("LineColor")
                        xmla.InnerText = sLC.ToArgb
                        sProps.Attributes.Append(xmla)
                    End If
                    If (sLW <> sfl.LineOrPointSize) Then
                        xmla = m_Doc.CreateAttribute("LineWidth")
                        xmla.InnerText = sLW
                        sProps.Attributes.Append(xmla)
                    End If
                    If (sLS <> sfl.LineStipple) Then
                        xmla = m_Doc.CreateAttribute("LineStyle")
                        xmla.InnerText = sLS
                        sProps.Attributes.Append(xmla)
                    End If
                    If sfl.LayerType = Interfaces.eLayerType.PolygonShapefile Then
                        ' but polygons have fill props too
                        Dim sFD As Boolean = axmap.get_ShapeDrawFill(sfl.Handle, i)
                        Dim sFT = axmap.get_ShapeFillTransparency(sfl.Handle, i)
                        Dim sFC As Color = axmap.get_ShapeFillColor(sfl.Handle, i)
                        Dim sFS = axmap.get_ShapeFillStipple(sfl.Handle, i)
                        If (sFD <> sfl.DrawFill) Then
                            xmla = m_Doc.CreateAttribute("DrawFill")
                            xmla.InnerText = sFD
                            sProps.Attributes.Append(xmla)
                        End If
                        If (sFC <> sfl.Color) Then
                            xmla = m_Doc.CreateAttribute("FillColor")
                            xmla.InnerText = sFC.ToArgb
                            sProps.Attributes.Append(xmla)
                        End If
                        If (sFT <> sfl.ShapeLayerFillTransparency) Then
                            xmla = m_Doc.CreateAttribute("FillTransparency")
                            xmla.InnerText = sFT
                            sProps.Attributes.Append(xmla)
                        End If
                        If (sFS <> sfl.FillStipple) Then
                            xmla = m_Doc.CreateAttribute("FillStyle")
                            xmla.InnerText = sFS
                            sProps.Attributes.Append(xmla)
                        End If
                    End If
                ElseIf sfl.LayerType = Interfaces.eLayerType.PointShapefile Then
                    Dim sPD As Boolean = axmap.get_ShapeDrawPoint(sfl.Handle, i)
                    Dim sPC As Color = axmap.get_ShapePointColor(sfl.Handle, i)
                    Dim sPW = axmap.get_ShapePointSize(sfl.Handle, i)
                    If (Not sPD) Then ' layer does not have equivalent boolean, one sets linewidth to 0 or > 0
                        xmla = m_Doc.CreateAttribute("DrawPoint")
                        xmla.InnerText = sPD
                        sProps.Attributes.Append(xmla)
                    End If
                    If (sPC <> sfl.Color) Then
                        xmla = m_Doc.CreateAttribute("PointColor")
                        xmla.InnerText = sPC.ToArgb
                        sProps.Attributes.Append(xmla)
                    End If
                    If (sPW <> sfl.LineOrPointSize) Then
                        xmla = m_Doc.CreateAttribute("PointSize")
                        xmla.InnerText = sPW
                        sProps.Attributes.Append(xmla)
                    End If
                End If

                ' if we added any, include this shape in the list
                If sProps.Attributes.Count > 1 Then
                    shpPropList.AppendChild(sProps)
                End If
            Next
            parent.AppendChild(shpPropList)
        Catch e As Exception
            m_ErrorMsg += "Error in AddShapeListElement(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
        End Try
    End Sub

    Private Sub AddLegendElement(ByRef m_Doc As Xml.XmlDocument, ByVal legend As MapWinGIS.ShapefileColorScheme, ByVal parent As XmlElement, ByVal handle As Integer)
        Dim leg As XmlElement = m_Doc.CreateElement("Legend")
        Dim colorBreaks As XmlElement = m_Doc.CreateElement("ColorBreaks")
        Dim fieldIndex As XmlAttribute = m_Doc.CreateAttribute("FieldIndex")
        Dim SchemeCaption As XmlAttribute = m_Doc.CreateAttribute("SchemeCaption")
        Dim key As XmlAttribute = m_Doc.CreateAttribute("Key")
        Dim numBreaks As XmlAttribute = m_Doc.CreateAttribute("NumberOfBreaks")
        Dim i As Integer

        'set the properties of the legend
        If Not legend Is Nothing Then
            With legend
                fieldIndex.InnerText = .FieldIndex.ToString
                key.InnerText = .Key
                numBreaks.InnerText = .NumBreaks.ToString
            End With
        End If

        Try
            'Note - don't use handle on legend object here - tends to be incorrect(?)
            SchemeCaption.InnerText = frmMain.Legend.Layers.ItemByHandle(handle).ColorSchemeFieldCaption
        Catch
            SchemeCaption.InnerText = ""
        End Try

        'add the elements to the legend
        leg.Attributes.Append(fieldIndex)
        leg.Attributes.Append(key)
        leg.Attributes.Append(numBreaks)

        If Not legend Is Nothing Then
            'add the elements to the colorBreaks
            For i = 0 To legend.NumBreaks - 1
                AddColorBreaksElement(m_Doc, legend.ColorBreak(i), colorBreaks)
            Next
        End If
        leg.AppendChild(colorBreaks)
        leg.Attributes.Append(SchemeCaption)

        parent.AppendChild(leg)

    End Sub

    Private Sub AddColorBreaksElement(ByRef m_Doc As Xml.XmlDocument, ByVal colorBreak As MapWinGIS.ShapefileColorBreak, ByVal parent As XmlElement)
        Dim break As XmlElement = m_Doc.CreateElement("Break")
        Dim endColor As XmlAttribute = m_Doc.CreateAttribute("EndColor")
        Dim endValue As XmlAttribute = m_Doc.CreateAttribute("EndValue")
        Dim startColor As XmlAttribute = m_Doc.CreateAttribute("StartColor")
        Dim StartValue As XmlAttribute = m_Doc.CreateAttribute("StartValue")
        Dim caption As XmlAttribute = m_Doc.CreateAttribute("Caption")
        Dim Visible As XmlAttribute = m_Doc.CreateAttribute("Visible")

        'set the properties
        With colorBreak
            endColor.InnerText = .EndColor.ToString
            If .EndValue Is Nothing Then
                endValue.InnerText = "(null)"
            Else
                endValue.InnerText = .EndValue.ToString
            End If
            startColor.InnerText = .StartColor.ToString
            If .StartValue Is Nothing Then
                StartValue.InnerText = "(null)"
            Else
                StartValue.InnerText = .StartValue.ToString
            End If
            caption.InnerText = .Caption
            Visible.InnerText = .Visible.ToString()
        End With

        'add the elements to the break
        break.Attributes.Append(startColor)
        break.Attributes.Append(endColor)
        break.Attributes.Append(StartValue)
        break.Attributes.Append(endValue)
        break.Attributes.Append(caption)
        break.Attributes.Append(Visible)

        parent.AppendChild(break)

    End Sub

    Private Sub AddGridElement(ByRef m_Doc As Xml.XmlDocument, ByVal gridFileLayer As Interfaces.Layer, ByVal parent As Xml.XmlNode)
        Dim grid As XmlElement = m_Doc.CreateElement("GridProperty")
        Dim transparentColor As XmlAttribute = m_Doc.CreateAttribute("TransparentColor")
        Dim useTransparency As XmlAttribute = m_Doc.CreateAttribute("UseTransparency")

        'set the properties of the grid
        With gridFileLayer
            transparentColor.InnerText = RGB(.ImageTransparentColor.R, .ImageTransparentColor.G, .ImageTransparentColor.B).ToString
            useTransparency.InnerText = .UseTransparentColor.ToString
        End With

        'add the elements
        grid.Attributes.Append(transparentColor)
        grid.Attributes.Append(useTransparency)

        'add the legend element
        If Not gridFileLayer.ColoringScheme Is Nothing Then
            AddLegendElement(m_Doc, CType(gridFileLayer.ColoringScheme, MapWinGIS.GridColorScheme), grid)
        End If

        parent.AppendChild(grid)
    End Sub

    Private Sub AddLegendElement(ByRef m_Doc As Xml.XmlDocument, ByVal legend As MapWinGIS.GridColorScheme, ByVal parent As XmlElement)
        Dim leg As XmlElement = m_Doc.CreateElement("Legend")
        Dim colorBreaks As XmlElement = m_Doc.CreateElement("ColorBreaks")
        Dim key As XmlAttribute = m_Doc.CreateAttribute("Key")
        Dim noDataColor As XmlAttribute = m_Doc.CreateAttribute("NoDataColor")
        Dim i As Integer

        'set the properties of the legend
        If Not legend Is Nothing Then
            With legend
                key.InnerText = .Key()
                noDataColor.InnerText = .NoDataColor.ToString
            End With
        End If

        'add the elements to the legend
        leg.Attributes.Append(key)
        leg.Attributes.Append(noDataColor)

        'add the elements to the colorBreaks
        If Not legend Is Nothing Then
            For i = 0 To legend.NumBreaks - 1
                AddColorBreaksElement(m_Doc, legend.Break(i), colorBreaks)
            Next
        End If
        leg.AppendChild(colorBreaks)

        parent.AppendChild(leg)
    End Sub

    Private Sub AddColorBreaksElement(ByRef m_Doc As Xml.XmlDocument, ByVal colorBreak As MapWinGIS.GridColorBreak, ByVal parent As XmlElement)
        Dim break As XmlElement = m_Doc.CreateElement("Break")
        Dim highColor As XmlAttribute = m_Doc.CreateAttribute("HighColor")
        Dim highValue As XmlAttribute = m_Doc.CreateAttribute("HighValue")
        Dim lowColor As XmlAttribute = m_Doc.CreateAttribute("LowColor")
        Dim lowValue As XmlAttribute = m_Doc.CreateAttribute("LowValue")
        Dim gradientModel As XmlAttribute = m_Doc.CreateAttribute("GradientModel")
        Dim colorType As XmlAttribute = m_Doc.CreateAttribute("ColoringType")
        Dim caption As XmlAttribute = m_Doc.CreateAttribute("Caption")

        'set the properties
        With colorBreak
            highColor.InnerText = .HighColor.ToString
            highValue.InnerText = .HighValue.ToString
            lowColor.InnerText = .LowColor.ToString
            lowValue.InnerText = .LowValue.ToString
            gradientModel.InnerText = CInt(.GradientModel).ToString
            colorType.InnerText = CInt(.ColoringType).ToString
            caption.InnerText = .Caption
        End With

        'add the elements to the break
        break.Attributes.Append(highColor)
        break.Attributes.Append(lowColor)
        break.Attributes.Append(highValue)
        break.Attributes.Append(lowValue)
        break.Attributes.Append(gradientModel)
        break.Attributes.Append(colorType)
        break.Attributes.Append(caption)

        parent.AppendChild(break)

    End Sub

    Private Sub SaveImage(ByRef m_Doc As Xml.XmlDocument, ByVal img As Object, ByVal parent As XmlElement)
        Dim image As XmlElement = m_Doc.CreateElement("Image")
        Dim type As XmlAttribute = m_Doc.CreateAttribute("Type")

        Dim typ As String = ""

        'set the properies of the image
        image.InnerText = ConvertImageToString(img, typ)
        type.InnerText = typ

        'add the properties to the images
        image.Attributes.Append(type)

        parent.AppendChild(image)
    End Sub

    Public Sub SerializeFillStippleScheme(ByRef FillStippleScheme As MapWindow.Interfaces.ShapefileFillStippleScheme, ByRef doc As Xml.XmlDocument, ByRef root As Xml.XmlElement)
        If FillStippleScheme Is Nothing Then Return

        Dim outer As Xml.XmlElement = doc.CreateElement("FillStippleScheme")

        Dim fldIndexAttr As Xml.XmlAttribute = doc.CreateAttribute("FieldIndex")
        fldIndexAttr.InnerText = FillStippleScheme.FieldHandle
        outer.Attributes.Append(fldIndexAttr)

        Try
            Dim caption As Xml.XmlAttribute = doc.CreateAttribute("StippleCaption")
            caption.InnerText = frmMain.Legend.Layers.ItemByHandle(FillStippleScheme.LayerHandle).StippleSchemeFieldCaption
            outer.Attributes.Append(caption)
        Catch
        End Try

        'Breaks for each shape:
        Dim i As IEnumerator = FillStippleScheme.GetHatchesEnumerator()
        Dim brk As MapWindow.Interfaces.ShapefileFillStippleBreak
        While i.MoveNext()
            Dim inner2 As Xml.XmlElement = doc.CreateElement("StippleBreak")
            brk = i.Current.value

            Dim attr1 As Xml.XmlAttribute = doc.CreateAttribute("Value")
            attr1.InnerText = brk.Value

            Dim attr2 As Xml.XmlAttribute = doc.CreateAttribute("Transparent")
            attr2.InnerText = brk.Transparent.ToString()

            Dim attr3 As Xml.XmlAttribute = doc.CreateAttribute("LineColor")
            attr3.InnerText = brk.LineColor.ToArgb().ToString()

            Dim attr4 As Xml.XmlAttribute = doc.CreateAttribute("Hatch")
            attr4.InnerText = StippleToString(brk.Hatch)

            inner2.Attributes.Append(attr1)
            inner2.Attributes.Append(attr2)
            inner2.Attributes.Append(attr3)
            inner2.Attributes.Append(attr4)
            outer.AppendChild(inner2)
        End While

        root.AppendChild(outer)
    End Sub

    Public Sub DeserializeFillStippleScheme(ByVal newHandle As Long, ByRef root As Xml.XmlElement)
        frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
        Try
            Dim csh As New MapWindow.Interfaces.ShapefileFillStippleScheme
            csh.FieldHandle = -1

            For Each xe As Xml.XmlElement In root
                If xe.Name = "FillStippleScheme" Then
                    csh.FieldHandle = Long.Parse(xe.Attributes("FieldIndex").InnerText)

                    Try
                        frmMain.Legend.Layers.ItemByHandle(newHandle).StippleSchemeFieldCaption = xe.Attributes("StippleCaption").InnerText
                    Catch
                    End Try
                    
                    For Each xe2 As Xml.XmlElement In xe.ChildNodes
                        If xe2.Name = "StippleBreak" Then
                            If xe2.Attributes("Value") IsNot Nothing And xe2.Attributes("Transparent") IsNot Nothing And xe2.Attributes("LineColor") IsNot Nothing And xe2.Attributes("Hatch") IsNot Nothing Then
                                Try
                                    csh.AddHatch(xe2.Attributes("Value").InnerText, Boolean.Parse(xe2.Attributes("Transparent").InnerText), System.Drawing.Color.FromArgb(Integer.Parse(xe2.Attributes("LineColor").InnerText)), StringToStipple(xe2.Attributes("Hatch").InnerText))
                                Catch
                                End Try
                            End If
                        End If
                    Next
                End If
            Next

            If csh.FieldHandle > -1 Then
                frmMain.m_layers(newHandle).FillStippleScheme = csh
                frmMain.m_layers(newHandle).HatchingRecalculate()
            End If
        Catch ex As Exception
            MapWinUtility.Logger.Dbg("DEBUG: " + ex.ToString())
        Finally
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
        End Try
    End Sub


    Public Sub SerializePointImageScheme(ByRef PointImgScheme As PointImageScheme, ByRef doc As Xml.XmlDocument, ByRef root As Xml.XmlElement)
        If PointImgScheme Is Nothing Then Return

        Dim outer As Xml.XmlElement = doc.CreateElement("PointImageScheme")

        Dim fldIndexAttr As Xml.XmlAttribute = doc.CreateAttribute("FieldIndex")
        fldIndexAttr.InnerText = PointImgScheme.FieldIndex

        outer.Attributes.Append(fldIndexAttr)

        'Images:
        Dim imgdat As Xml.XmlElement = doc.CreateElement("ImageData")
        Dim imgcvter As New MapWinUtility.ImageUtils
        For k As Integer = 0 To frmMain.MapMain.get_UDPointImageListCount(PointImgScheme.LastKnownLayerHandle) - 1
            Dim imgItem As Xml.XmlElement = doc.CreateElement("Image")

            Dim imgIDAttr As Xml.XmlAttribute = doc.CreateAttribute("ID")
            imgIDAttr.InnerText = k.ToString()

            imgItem.Attributes.Append(imgIDAttr)

            Dim g As MapWinGIS.Image = frmMain.MapMain.get_UDPointImageListItem(PointImgScheme.LastKnownLayerHandle, k)
            Dim img As System.Drawing.Image = imgcvter.IPictureDispToImage(g.Picture)
            SaveImage(doc, img, imgItem)
            'Note: Don't close G, or you'll get access violations later on.
            'The OCX is returning a reference to the image list item, not a copy
            imgdat.AppendChild(imgItem)
        Next
        outer.AppendChild(imgdat)

        'Image Indexes assigned to shapes:
        Dim inner As Xml.XmlElement = doc.CreateElement("ItemData")
        Dim i As IDictionaryEnumerator = PointImgScheme.m_Items.Keys.GetEnumerator()
        While i.MoveNext()
            Dim item As Xml.XmlElement = doc.CreateElement("Item")

            Dim attr2 As Xml.XmlAttribute = doc.CreateAttribute("MatchValue")
            attr2.InnerText = i.Key.ToString()

            Dim attr3 As Xml.XmlAttribute = doc.CreateAttribute("ImgIndex")
            attr3.InnerText = i.Value.ToString()

            item.Attributes.Append(attr2)
            item.Attributes.Append(attr3)

            inner.AppendChild(item)
        End While
        outer.AppendChild(inner)

        'Visibilities assigned to shapes:
        Dim inner2 As Xml.XmlElement = doc.CreateElement("ItemVisibility")
        Dim i2 As IDictionaryEnumerator = PointImgScheme.m_ItemVisibility.Keys.GetEnumerator()
        While i2.MoveNext()
            Dim item As Xml.XmlElement = doc.CreateElement("Item")

            Dim attr2 As Xml.XmlAttribute = doc.CreateAttribute("MatchValue")
            attr2.InnerText = i2.Key.ToString()

            Dim attr3 As Xml.XmlAttribute = doc.CreateAttribute("Visible")
            attr3.InnerText = i2.Value.ToString()

            item.Attributes.Append(attr2)
            item.Attributes.Append(attr3)

            inner2.AppendChild(item)
        End While
        outer.AppendChild(inner2)

        root.AppendChild(outer)
    End Sub

    Public Sub DeserializePointImageScheme(ByVal newHandle As Long, ByRef root As Xml.XmlElement)
        frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)
        Try
            Dim imgUtil As New MapWinUtility.ImageUtils
            Dim xe, xe2, xe3 As Xml.XmlElement
            Dim found As Boolean = False
            Dim csh As New PointImageScheme(newHandle)

            Dim TranslationTable As New Hashtable

            For Each xe In root
                If xe.Name = "PointImageScheme" Then
                    found = True
                    csh.FieldIndex = Long.Parse(xe.Attributes("FieldIndex").InnerText)

                    For Each xe2 In xe.ChildNodes
                        If xe2.Name = "ImageData" Then
                            For Each xe3 In xe2.ChildNodes
                                Dim origIndex As Long = Long.Parse(xe3.Attributes("ID").InnerText)

                                Dim Type As String
                                Type = xe3.Item("Image").Attributes("Type").InnerText
                                Dim img As System.Drawing.Image = CType(ConvertStringToImage(xe3.Item("Image").InnerText, Type), Image)

                                Dim ico As New MapWinGIS.Image
                                ico.Picture = imgUtil.ImageToIPictureDisp(CType(img, System.Drawing.Image))
                                If Not ico Is Nothing Then ico.TransparencyColor = ico.Value(0, 0)
                                'Pull from first pixel rather than assuming bluish ico.TransparencyColor = Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 211)))

                                Dim newidx As Integer = frmMain.MapMain.set_UDPointImageListAdd(newHandle, ico)
                                TranslationTable.Add(origIndex, newidx)
                                img = Nothing
                            Next
                        ElseIf xe2.Name = "ItemData" Then
                            For Each xe3 In xe2.ChildNodes
                                If xe3.Name = "Item" Then
                                    Dim tag As String = xe3.Attributes("MatchValue").InnerText
                                    Dim imgIndex As Long = Long.Parse(xe3.Attributes("ImgIndex").InnerText)
                                    Dim actualIndex As Long = -1
                                    If TranslationTable.Contains(imgIndex) Then
                                        actualIndex = TranslationTable(imgIndex)
                                    Else
                                        'Hope it's right
                                        actualIndex = imgIndex
                                    End If

                                    If Not actualIndex = -1 And Not tag = "" Then csh.m_Items.Add(tag, actualIndex)

                                    Dim sf As MapWinGIS.Shapefile

                                    sf = CType(frmMain.m_layers(newHandle).GetObject, MapWinGIS.Shapefile)
                                    If sf Is Nothing Then
                                        g_error = "Failed to get Shapefile object"
                                        Return
                                    End If

                                    If Not actualIndex = -1 Then
                                        For j As Integer = 0 To sf.NumShapes - 1
                                            If sf.CellValue(csh.FieldIndex, j) = tag Then
                                                frmMain.MapMain.set_ShapePointImageListID(newHandle, j, actualIndex)
                                                If Not frmMain.MapMain.get_ShapePointType(newHandle, j) = MapWinGIS.tkPointType.ptImageList Then
                                                    frmMain.MapMain.set_ShapePointType(newHandle, j, MapWinGIS.tkPointType.ptImageList)
                                                End If
                                                frmMain.MapMain.set_ShapePointSize(newHandle, j, 1)
                                            End If
                                        Next j
                                    End If

                                    sf = Nothing
                                End If
                            Next
                        ElseIf xe2.Name = "ItemVisibility" Then
                            For Each xe3 In xe2.ChildNodes
                                If xe3.Name = "Item" Then
                                    Dim tag As String = xe3.Attributes("MatchValue").InnerText
                                    Dim vis As Boolean = Boolean.Parse(xe3.Attributes("Visible").InnerText)
                                    csh.m_ItemVisibility.Add(tag, vis)

                                    Dim sf As MapWinGIS.Shapefile

                                    sf = CType(frmMain.m_layers(newHandle).GetObject, MapWinGIS.Shapefile)
                                    If sf Is Nothing Then
                                        g_error = "Failed to get Shapefile object"
                                        Return
                                    End If

                                    For j As Integer = 0 To sf.NumShapes - 1
                                        If sf.CellValue(csh.FieldIndex, j) = tag Then
                                            frmMain.MapMain.set_ShapeVisible(newHandle, j, vis)
                                        End If
                                    Next j

                                    sf = Nothing
                                End If
                            Next
                        End If
                    Next
                    Exit For
                End If
            Next

            If found Then
                frmMain.m_layers(newHandle).PointImageScheme = csh
            End If

            TranslationTable.Clear()
            GC.Collect()
        Catch ex As Exception
            MapWinUtility.Logger.Dbg("DEBUG: " + ex.ToString())
        Finally
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
        End Try
    End Sub

    Private Sub SaveMapImage(ByRef m_Doc As Xml.XmlDocument, ByVal img As Object, ByVal parent As XmlElement)
        Dim image As XmlElement = m_Doc.CreateElement("MapImage")
        Dim type As XmlAttribute = m_Doc.CreateAttribute("Type")

        Dim typ As String = ""

        'set the properies of the image
        image.InnerText = ConvertImageToString(img, typ)
        type.InnerText = typ

        'add the properties to the images
        image.Attributes.Append(type)

        parent.AppendChild(image)
    End Sub
#End Region

#Region "Load Config"
    'This region includes functions that are part of loading config files.
    'It is assumed that the frmmain may or may not have been created yet.

    Public Function LoadConfig(ByVal Load_Plugins As Boolean) As Boolean
        'This function loads a config file and returns success or failure.
        'Updated in version 4 to use the configfilename stored in this class and to
        'not use the dotnetbar stuff.
        Dim odir As String = System.IO.Directory.GetCurrentDirectory()

        Try
            Dim Doc As New XmlDocument  'The xmldocument config file
            Dim Root As XmlElement      'An xml element
            ' Try
            'change the cursor to the wait cursor
            If Not frmMain Is Nothing Then
                'if frmmain exists then show a waitcursor
                frmMain.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Windows.Forms.Application.DoEvents()
                'Unload all of the plugins
                frmMain.m_PluginManager.UnloadAll()
                frmMain.m_PluginManager.UnloadApplicationPlugins()
            End If

            ' May/29/2008 Jiri Kadlec
            ' check if the directory of ConfigFileName exists before changing it
            ' if it does not exist, use the standard location of ConfigFileName
            Dim ConfigDir As String = System.IO.Path.GetDirectoryName(ConfigFileName)
            If Not System.IO.Directory.Exists(ConfigDir) Then
                ConfigDir = GetApplicationDataDir()
                ConfigFileName = Me.UserConfigFile 'set config file to "Documents and Settings\(user name)\Application Data\user.mwcfg
            End If

            'the paths of any files saved in the configuration are relative paths. This is why the
            'current directory must be changed when reading or writing from the config file.
            ChDir(ConfigDir)

            '**** add the following elements to "mwcfg" ****
            Doc = New XmlDocument

            'Chris M 3/13/2006 - if the config doesn't exist, save -- this will safe a new
            'default.
            'Jiri Kadlec May/29/2008 - if the config doesn't exist, try creating it from
            'default.mwcfg.

            'TODO: always check the version of default config file. If current MW version is higher
            'than config file version, overwrite it using default compiled settings.

            If Not System.IO.File.Exists(ConfigFileName) Then
                MapWinUtility.Logger.Dbg("Loading Configuration: Creating configuration file from default")
                CreateConfigFileFromDefault(ConfigFileName)
                'Prepare the default application plugin location first:
                'AppInfo.ApplicationPluginDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\ApplicationPlugins"
                'frmMain.m_PluginManager.LoadApplicationPlugins(AppInfo.ApplicationPluginDir)
                'SaveConfig()
            End If

            MapWinUtility.Logger.Dbg("Loading Configuration: " + ConfigFileName)
            Doc.Load(ConfigFileName)
            Root = Doc.DocumentElement

            'load the View
            LoadView(Root.Item("View"))

            'force the mapwindow to show
            'frmMain.Show()
            System.Windows.Forms.Application.DoEvents()

            'load Appinfo
            LoadAppInfo(Root.Item("AppInfo"))

            'load recent files
            LoadRecentProjects(Root.Item("RecentProjects"))

            'load the color Palettes
            If (Not Root.Item("ColorPalettes") Is Nothing) Then
                LoadColorPalettes(Root.Item("ColorPalettes"))
            Else
                frmMain.g_ColorPalettes = p_Doc.CreateElement("ColorPalettes")
            End If

            'load the Plugins
            If Load_Plugins = True Then
                LoadPlugins(Root.Item("Plugins"), True)
            End If

            'load the application plugins
            LoadApplicationPlugins(Root.Item("ApplicationPlugins"), True)

            frmMain.Update()

            '            ConfigFileName = System.IO.Path.GetFullPath(fileName)
            ConfigLoaded = True

            'Catch e As System.Exception
            '    m_ErrorMsg += "Error in LoadConfig(), Message: " + e.Message & Chr(13)
            '    m_ErrorOccured = True
            'End Try

            'change the cursor back to the default
            frmMain.Cursor = System.Windows.Forms.Cursors.Default

            'Dim pluginEnumerator As IDictionaryEnumerator
            'pluginEnumerator = frmMain.m_PluginManager.PluginsList.GetEnumerator()
            'Dim handled As Boolean = False
            'Dim plugin As MapWindow.Interfaces.IPlugin
            'Dim pluginfo As PluginInfo
            'While pluginEnumerator.MoveNext
            '    pluginfo = CType(pluginEnumerator.Value, PluginInfo)
            '    plugin = pluginfo.CreatePluginObject()
            '    Try
            '        plugin.Message("SPLASH_SCREEN", handled)
            '    Catch ex As Exception
            '        TODO()
            '    End Try
            '    If handled Then
            '        Exit While
            '    End If
            'End While

        Catch ex As Exception
            m_ErrorOccured = True
            m_ErrorMsg = ex.ToString
        Finally
            System.IO.Directory.SetCurrentDirectory(odir)
        End Try

        If m_ErrorOccured Then
            MapWinUtility.Logger.Msg(m_ErrorMsg, MsgBoxStyle.Exclamation, "Configuration File Error Report")
            m_ErrorOccured = False
        End If
    End Function

    '5/27/2008 added by Jiri Kadlec - This function will create a
    'new MapWindow configuration file using the settings from the
    'default configuration file "default.mwcfg" from the MW executable directory
    'in case default.mwcfg does not exist, it creates a new configuration file using default
    'compiled-in settings
    Public Sub CreateConfigFileFromDefault(ByVal NewConfigFile As String)

        'this is the read-only default configuration file (default.mwcfg) provided by MapWindow installation
        Dim DefaultConfigFileName As String = Me.DefaultConfigFile '..\MapWindow\default.mwcfg

        'Always make sure we are in the MW executable directory to make relative paths work
        Dim odir As String = CurDir()
        Dim MapWindowDir As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        If odir <> MapWindowDir Then
            ChDir(MapWindowDir)
        End If


        If Not System.IO.File.Exists(DefaultConfigFileName) Then
            'Jiri Kadlec May/29/2008 this is the only place where MapWindow
            'WRITES to default.mwcfg. this code is executed only in case default.mwcfg
            'in the MW executable folder does not exist.
            Dim originalCfgFile = ConfigFileName
            ConfigFileName = DefaultConfigFileName
            'LoadConfig(True) 9/8/2008 removed by Jiri Kadlec - this caused infinite recursion
            SaveConfig()
            ConfigFileName = originalCfgFile
        End If

        Try

            'NewConfigFile is usually located in Documents and Settings\[user name]\Application Data\MapWindow.
            'it can also have a custom location specified by the project file.
            System.IO.File.Copy(DefaultConfigFileName, NewConfigFile, True)

            'make sure "ApplicationPlugins" , "helpFilePath" and "DefaultDir" paths are correct. 
            'these paths should be a relative paths to the location of NewConfigFile. Also correct 
            'helpFilePath and DefaultDir.

            Dim doc As New XmlDocument
            doc.Load(DefaultConfigFileName)
            Dim Root As XmlElement = doc.DocumentElement

            'correct helpFilePath and defaultDir
            Dim AppInfoElement As XmlElement = Root.Item("AppInfo")
            Dim HelpFilePath As String = ""
            Dim NewHelpFilePath As String = ""
            If AppInfoElement.HasAttribute("HelpFilePath") Then
                Try
                    HelpFilePath = System.IO.Path.GetFullPath(AppInfoElement.Attributes("HelpFilePath").Value)
                Catch
                    HelpFilePath = MapWindowDir
                End Try
                NewHelpFilePath = Me.GetRelativePath(HelpFilePath, NewConfigFile)
            End If

            Dim DefaultDir As String = ""
            Dim NewDefaultDir As String = ""
            If AppInfoElement.HasAttribute("DefaultDir") Then
                Try
                    DefaultDir = System.IO.Path.GetFullPath(AppInfoElement.Attributes("DefaultDir").Value)
                Catch
                    DefaultDir = System.IO.Path.GetFullPath("Sample Projects")
                End Try
                NewDefaultDir = Me.GetRelativePath(DefaultDir, NewConfigFile)
            End If

            Dim ApplicationPluginElement As XmlElement = Root.Item("ApplicationPlugins")
            Dim AppPluginDir As String = ApplicationPluginElement.Attributes("PluginDir").Value
            Dim AppPluginPath As String = ""

            Try
                AppPluginPath = System.IO.Path.GetFullPath(AppPluginDir)
            Catch ex As Exception
                'the Application plugin path specified by default.mwcfg is not valid - try to use
                'the default \ApplicationPlugins subfolder in MW executable directory instead.
                AppPluginPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                AppPluginPath = System.IO.Path.Combine(AppPluginPath, "ApplicationPlugins")
            End Try

            AppPluginDir = Me.GetRelativePath(AppPluginPath, NewConfigFile)

            doc.Load(NewConfigFile)
            Root = doc.DocumentElement
            AppInfoElement = Root.Item("AppInfo")
            AppInfoElement.Attributes("HelpFilePath").Value = NewHelpFilePath
            AppInfoElement.Attributes("DefaultDir").Value = NewDefaultDir
            ApplicationPluginElement = Root.Item("ApplicationPlugins")
            ApplicationPluginElement.Attributes("PluginDir").Value = AppPluginDir
            doc.Save(NewConfigFile)

            MapWinUtility.Logger.Dbg("Copied configuration file from " + _
            DefaultConfigFileName + " to " + NewConfigFile)
        Catch ex As Exception
            MapWinUtility.Logger.Dbg("Creating config from default - Error - unable to copy " + _
            "configuration file from " + DefaultConfigFileName + " to " + NewConfigFile)
            NewConfigFile = DefaultConfigFileName
        Finally
            If MapWindowDir <> odir Then
                ChDir(odir)
            End If
        End Try

    End Sub


    Public Function LoadProject(ByVal Filename As String, Optional ByVal LayersOnly As Boolean = False, Optional ByVal LayersIntoGroup As String = "") As Boolean
        'This loads a project XML file.

        g_SyncPluginMenuDefer = True

        Dim configFileFound = False
        Dim Doc As New XmlDocument
        Dim Root As XmlElement

        If Not System.IO.File.Exists(Filename) Then
            Return False
            Exit Function
        End If

        MapWinUtility.Logger.Dbg("Loading Project: " + Filename)

        If Not TranslateLegacyVWR(Filename) Then
            Return False
        End If

        Dim odir As String = System.IO.Directory.GetCurrentDirectory()

        'added by Jiri kadlec
        Dim DefaultConfigFileName As String = Me.DefaultConfigFile
        Dim oldConfigPath As String = ConfigFileName

        Try
            BookmarkedViews.Clear()
            frmMain.BuildBookmarkedViewsMenu()

            ChDir(System.IO.Path.GetDirectoryName(Filename))
            'Set default directory to folder containing current project
            AppInfo.DefaultDir = CurDir()

            'add the project to the most recent projects
            AddToRecentProjects(Filename)

            '**** load the following elements from "mwprj" ****
            If Not LayersOnly Then
                frmMain.Layers.Clear()
                frmMain.Legend.Groups.Clear()
                frmMain.ClearPreview()
                frmMain.m_AutoVis = New DynamicVisibilityClass()
            End If

            Doc.Load(Filename)

            Root = Doc.DocumentElement

            If Not LayersOnly Then

                '**** Load the config file if it exists ********
                Dim NewConfigFile As String = Root.Attributes("ConfigurationPath").InnerText
                Dim NewConfigPath As String = ""

                Try
                    NewConfigPath = System.IO.Path.GetFullPath(NewConfigFile)
                Catch ex As Exception
                    ' May-29-2008 Jiri Kadlec
                    'if the path specified in the project file is not a valid path - use the default
                    'read/write config file location
                    MapWinUtility.Logger.Dbg("Loading configuration file " + NewConfigFile + " is not a valid path.")
                    NewConfigPath = Me.UserConfigFile
                    MapWinUtility.Logger.Dbg("Changed configuration file used by the project to " + NewConfigPath)
                End Try

                ' May-29-2008 Jiri Kadlec
                ' Check if the directory of the .mwcfg file specified by the project exists - if it doesn't exist, use the user
                ' .mwcfg file location in "Documents and Settings" instead.
                Dim NewConfigDir As String = System.IO.Path.GetDirectoryName(NewConfigPath)
                If Not System.IO.Directory.Exists(NewConfigDir) Then
                    MapWinUtility.Logger.Dbg("Loading configuration - the directory" + NewConfigDir + " - does not exist.")
                    NewConfigPath = Me.UserConfigFile
                    MapWinUtility.Logger.Dbg("Changed configuration file used by the project to " + NewConfigPath)
                End If

                Try
                    'If the location of NewConfigFile is in MW executable directory or if it's called 
                    '"default.mwcfg" or "mapwindow.mwcfg", create and use a new file in
                    '"Documents and Settings\User\ApplicationData\user.mwcfg" (Jiri Kadlec 5/26/2008)
                    If NewConfigPath.ToLower() = DefaultConfigFileName.ToLower() Or _
                            NewConfigPath.ToLower().IndexOf("default.mwcfg") >= 0 Then
                        NewConfigPath = Me.UserConfigFile
                        CreateConfigFileFromDefault(NewConfigPath)
                    End If

                    If System.IO.File.Exists(NewConfigPath) Then

                        '5/26/2008 Jiri Kadlec
                        'check if the file "default.mwcfg" in MW executable directory has been modified 
                        '(for example, by a new MapWindow installation. 
                        'in that case, update the Configuration file with the content of default.mwcfg.
                        'for projects with a custom configuration file which doesn't contain a string
                        'default.mwcfg, mapwindow.mwcfg or user.mwcfg, don't do any modification.
                        If CompareFilesByTime(DefaultConfigFileName, NewConfigPath) > 0 And _
                        System.IO.Path.GetDirectoryName(NewConfigPath) = GetApplicationDataDir() Then
                            CreateConfigFileFromDefault(NewConfigPath)
                            ConfigFileName = NewConfigPath
                        End If

                        If oldConfigPath.ToLower <> NewConfigPath.ToLower Then
                            'The project has a different configuration file than the previous project - 
                            'save the old configFile before loading the new one
                            If Not ConfigFileName Is Nothing Then
                                MapWinUtility.Logger.Dbg("Configuration file name changed from " + oldConfigPath + _
                                " to " + NewConfigPath + " - running SaveConfig()") '5/26/2008 Jiri Kadlec
                                SaveConfig()
                            End If
                            ConfigFileName = NewConfigPath
                            LoadConfig(True)
                        End If
                    Else
                        'the configuration file specified in the project settings does not exist -
                        'recreate it from the default configuration file .default.mwcfg
                        CreateConfigFileFromDefault(NewConfigFile)
                        MapWinUtility.Logger.Dbg("Configuration file " + NewConfigFile + _
                                " does not exist. Recreating " + ConfigFileName + " from default.") '5/26/2008 Jiri Kadlec
                        ConfigFileName = System.IO.Path.GetFullPath(NewConfigFile)
                        LoadConfig(True)
                    End If
                Catch ex As Exception
                    MapWinUtility.Logger.Msg("ERROR - no configuration path or error loading it" & ex.Message & " " & ex.StackTrace)
                End Try

                'Load the projection if it exists
                Try
                    ProjectProjection = Root.Attributes("ProjectProjection").InnerText
                Catch ex As Exception
                    ProjectProjection = ""
                End Try

                'Load the map units if the setting exists
                Try
                    m_MapUnits = Root.Attributes("MapUnits").InnerText
                Catch ex As Exception
                    m_MapUnits = ""
                End Try

                'Load the map background color if it exists
                Try
                    If Root.HasAttribute("ViewBackColor_UseDefault") AndAlso Root.HasAttribute("ViewBackColor") Then
                        Dim useDefault As Boolean = Convert.ToBoolean(Root.Attributes("ViewBackColor_UseDefault").InnerText)
                        If useDefault = False Then
                            UseDefaultBackColor = False
                            Dim backColorId As String = Root.Attributes("ViewBackColor").InnerText
                            If backColorId <> "" Then
                                ProjectBackColor = MapWinUtility.Colors.IntegerToColor(Convert.ToInt32(backColorId))
                            End If
                        Else
                            ProjectBackColor = AppInfo.DefaultBackColor
                        End If
                    Else
                        ProjectBackColor = AppInfo.DefaultBackColor
                    End If
                    frmMain.View.BackColor = Color.FromArgb(ProjectBackColor.A, ProjectBackColor.R, ProjectBackColor.G, ProjectBackColor.B)
                Catch
                    ProjectBackColor = AppInfo.DefaultBackColor
                    frmMain.View.BackColor = Color.FromArgb(ProjectBackColor.A, ProjectBackColor.R, ProjectBackColor.G, ProjectBackColor.B)
                End Try

                'Load the status bar coord customizations
                Try
                    StatusBarAlternateCoordsNumDecimals = Integer.Parse(Root.Attributes("StatusBarAlternateCoordsNumDecimals").InnerText)
                    StatusBarCoordsNumDecimals = Integer.Parse(Root.Attributes("StatusBarCoordsNumDecimals").InnerText)
                    StatusBarAlternateCoordsUseCommas = Boolean.Parse(Root.Attributes("StatusBarAlternateCoordsUseCommas").InnerText)
                    StatusBarCoordsUseCommas = Boolean.Parse(Root.Attributes("StatusBarCoordsUseCommas").InnerText)
                Catch ex As Exception
                    StatusBarAlternateCoordsNumDecimals = 3
                    StatusBarCoordsNumDecimals = 3
                    StatusBarAlternateCoordsUseCommas = True
                    StatusBarCoordsUseCommas = True
                End Try

                Try
                    frmMain.m_FloatingScalebar_Enabled = Boolean.Parse(Root.Attributes("ShowFloatingScaleBar").InnerText)
                    frmMain.Menus("mnuShowScaleBar").Checked = frmMain.m_FloatingScalebar_Enabled
                Catch ex As Exception
                    frmMain.m_FloatingScalebar_Enabled = False
                End Try

                Try
                    frmMain.m_FloatingScalebar_ContextMenu_SelectedPosition = Root.Attributes("FloatingScaleBarPosition").InnerText
                Catch ex As Exception
                    frmMain.m_FloatingScalebar_ContextMenu_SelectedPosition = "LowerRight"
                Finally
                    frmMain.m_FloatingScalebar_ContextMenu_UL.Checked = IIf(frmMain.m_FloatingScalebar_ContextMenu_SelectedPosition = "UpperLeft", True, False)
                    frmMain.m_FloatingScalebar_ContextMenu_UR.Checked = IIf(frmMain.m_FloatingScalebar_ContextMenu_SelectedPosition = "UpperRight", True, False)
                    frmMain.m_FloatingScalebar_ContextMenu_LL.Checked = IIf(frmMain.m_FloatingScalebar_ContextMenu_SelectedPosition = "LowerLeft", True, False)
                    frmMain.m_FloatingScalebar_ContextMenu_LR.Checked = IIf(frmMain.m_FloatingScalebar_ContextMenu_SelectedPosition = "LowerRight", True, False)
                End Try

                Try
                    frmMain.m_FloatingScalebar_ContextMenu_SelectedUnit = Root.Attributes("FloatingScaleBarUnit").InnerText
                Catch ex As Exception
                    frmMain.m_FloatingScalebar_ContextMenu_SelectedUnit = "" 'No Override
                End Try

                Try
                    frmMain.m_FloatingScalebar_ContextMenu_ForeColor = System.Drawing.Color.FromArgb(Integer.Parse(Root.Attributes("FloatingScaleBarForecolor").InnerText))
                Catch ex As Exception
                    frmMain.m_FloatingScalebar_ContextMenu_ForeColor = Color.Black
                End Try

                Try
                    frmMain.m_FloatingScalebar_ContextMenu_BackColor = System.Drawing.Color.FromArgb(Integer.Parse(Root.Attributes("FloatingScaleBarBackcolor").InnerText))
                Catch ex As Exception
                    frmMain.m_FloatingScalebar_ContextMenu_BackColor = Color.White
                End Try

                'Load the map resize behavior if it exists
                Try
                    modMain.frmMain.MapMain.MapResizeBehavior = CType(Short.Parse(Root.Attributes("MapResizeBehavior").InnerText), MapWinGIS.tkResizeBehavior)
                Catch ex As Exception
                    'Leave it at the default defined in CMap's constructor
                End Try

                'Load whether to display various coordinate systems in the status bar.
                'Default to true while doing this.
                Try
                    ShowStatusBarCoords_Projected = Boolean.Parse(Root.Attributes("ShowStatusBarCoords_Projected").InnerText)
                Catch ex As Exception
                    ShowStatusBarCoords_Projected = True
                End Try
                Try
                    ShowStatusBarCoords_Alternate = Root.Attributes("ShowStatusBarCoords_Alternate").InnerText
                Catch ex As Exception
                    ShowStatusBarCoords_Alternate = MapWindow.Interfaces.UnitOfMeasure.Kilometers.ToString()
                End Try
            End If

            ' load the SaveShapeSettings behavior
            Try
                Me.SaveShapeSettings = Boolean.Parse(Root.Attributes("SaveShapeSettings").InnerText)
            Catch ex As Exception
                Me.SaveShapeSettings = False
            End Try

            frmMain.Legend.Lock()
            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmLock)

            'clear all of the Dynamic visibility layer
            If Not LayersOnly Then frmMain.m_AutoVis.Clear()

            'make sure we are in the proper directory so relative paths work
            ChDir(System.IO.Path.GetDirectoryName(Filename))

            'load the Groups and all of its layers
            LoadGroups(Root.Item("Groups"), LayersOnly, LayersIntoGroup)

            frmMain.MapMain.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
            frmMain.Legend.Unlock()

            If Not LayersOnly Then
                'load the extents
                LoadExtents(Root.Item("Extents"))

                'load the Preview Map
                LoadPreviewMap(Root.Item("PreviewMap"))

                'load the Plugins causes it to call project loading
                LoadPlugins(Root.Item("Plugins"), False)

                'load the application plugins causes it to call project loading
                LoadApplicationPlugins(Root.Item("ApplicationPlugins"), False)

                'Load bookmarks
                LoadBookmarks(Root)
            End If

            'BugZilla 315: Default directory should start set to project location
            AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(Filename)

            If Not LayersOnly Then
                frmMain.ResetViewState(frmMain.m_FloatingScalebar_Enabled)
                frmMain.MapMain.CursorMode = MapWinGIS.tkCursorMode.cmNone
                frmMain.MapMain.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn
            End If

            frmMain.UpdateZoomButtons()

            frmMain.SetModified(False)
            g_SyncPluginMenuDefer = False
            frmMain.SynchPluginMenu()
            System.IO.Directory.SetCurrentDirectory(odir)
            Return True

        Catch e As System.Exception
            m_ErrorMsg += "Error in LoadProject(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
        Finally
            System.IO.Directory.SetCurrentDirectory(odir)
        End Try

        If m_ErrorOccured Then
            MapWinUtility.Logger.Msg(m_ErrorMsg, MsgBoxStyle.Exclamation, "Project File Error Report")
            m_ErrorOccured = False
        End If

    End Function

#Region "Load Recent Projects"

    Private Sub LoadRecentProjects(ByVal RecentFiles As XmlElement)
        Try
            If (RecentFiles Is Nothing) Then Exit Sub

            Dim iChild As Integer
            Dim iRecentProject As Integer
            Dim path As String
            Dim pathLower As String
            Dim file As Xml.XmlNode
            Dim numChildNodes As Integer = RecentFiles.ChildNodes.Count

            'clear all previous files
            ProjInfo.RecentProjects.Clear()

            For iChild = 0 To numChildNodes - 1
                file = RecentFiles.ChildNodes(iChild)

                'get the full path of the file
                path = System.IO.Path.GetFullPath(file.InnerText)

                'Make sure we don't already have this project in the list.
                'Find a duplicate even if it has different capitalization.
                pathLower = path.ToLower
                iRecentProject = 0
                While iRecentProject < ProjInfo.RecentProjects.Count() AndAlso _
                    ProjInfo.RecentProjects.Item(iRecentProject).ToString.ToLower <> pathLower
                    iRecentProject += 1
                End While
                'iRecentProject = Count means we did not find a duplicate
                'Also, don't add recent projects that no longer exist
                If iRecentProject = ProjInfo.RecentProjects.Count() AndAlso _
                   System.IO.File.Exists(path) Then
                    ProjInfo.RecentProjects.Add(path)
                End If
            Next

            frmMain.BuildRecentProjectsMenu()

        Catch ex As System.Exception
            m_ErrorMsg += "Error: Loading the LoadRecentProjects" + Chr(13)
            m_ErrorOccured = True
            Exit Sub
        End Try
    End Sub

#End Region

#Region "Load ColorPalettes"

    Private Sub LoadColorPalettes(ByVal colorPalettes As XmlElement)
        Try
            frmMain.g_ColorPalettes = colorPalettes
        Catch ex As System.Exception
            m_ErrorMsg += "Error: Loading the ColorPalettes" + Chr(13)
            m_ErrorOccured = True
            Exit Sub
        End Try
    End Sub

#End Region

    'Public Sub LoadSplashInfo()
    '    'Only used by sub main to determine whether or not to be showing a splash screen
    '    'if there is already a project file then check it for the config file to use

    'End Sub

    Private Sub LoadAppInfo(ByVal AppInfoXML As XmlElement)
        'Reads the custom application info from the config file.
        'this can be called before frmMain is loaded to determine
        'whether or not to show a splash screen and for how long.
        'Modified 1/16/2005
        Dim Type As String

        Try
            AppInfo.Name = AppInfoXML.Attributes("Name").InnerText
            AppInfo.Version = AppInfoXML.Attributes("Version").InnerText
            AppInfo.BuildDate = AppInfoXML.Attributes("BuildDate").InnerText
            AppInfo.Developer = AppInfoXML.Attributes("Developer").InnerText
            AppInfo.Comments = AppInfoXML.Attributes("Comments").InnerText
            AppInfo.SplashTime = CInt(AppInfoXML.Attributes("SplashTime").InnerText)

            Try
                AppInfo.LogfilePath = AppInfoXML.Attributes("LogfilePath").InnerText
                'Enable logging:
                MapWinUtility.Logger.StartToFile(AppInfo.LogfilePath, False, True, False)
            Catch
                AppInfo.LogfilePath = ""
            End Try

            Try
                NoPromptToSendErrors = CBool(AppInfoXML.Attributes("NoPromptToSendErrors").InnerText)
            Catch
                NoPromptToSendErrors = False
            End Try

            Dim NeverShowProjectionDialog As Boolean = False
            Try
                NeverShowProjectionDialog = CBool(AppInfoXML.Attributes("NeverShowProjectionDialog").InnerText)
            Catch ex As Exception
            End Try
            AppInfo.NeverShowProjectionDialog = NeverShowProjectionDialog

            If AppInfoXML.Attributes("WelcomePlugin") Is Nothing Then
                AppInfo.WelcomePlugin = Nothing
            Else
                AppInfo.WelcomePlugin = AppInfoXML.Attributes("WelcomePlugin").InnerText
            End If


            Try
                Dim strPath As String = System.IO.Path.GetFullPath(AppInfoXML.Attributes("DefaultDir").InnerText)
                If strPath <> Nothing Then
                    AppInfo.DefaultDir = strPath
                End If
            Catch
                'Should do some kind of logging here if the dir is invalid
            End Try

            If (AppInfoXML.HasAttribute("URL")) Then
                AppInfo.URL = AppInfoXML.Attributes("URL").InnerText
            End If

            If (AppInfoXML.HasAttribute("ShowWelcomeScreen")) Then
                AppInfo.ShowWelcomeScreen = Boolean.Parse(AppInfoXML.Attributes("ShowWelcomeScreen").InnerText)
            End If

            If (AppInfoXML.Attributes("HelpFilePath").InnerText <> "") Then
                AppInfo.HelpFilePath = System.IO.Path.GetFullPath(AppInfoXML.Attributes("HelpFilePath").InnerText)
            Else
                AppInfo.HelpFilePath = ""
            End If

            If (AppInfo.SplashTime < 0) Then
                AppInfo.SplashTime = 0
            End If

            If (AppInfoXML.HasAttribute("ShowDynVisWarnings")) Then
                AppInfo.ShowDynamicVisibilityWarnings = Boolean.Parse(AppInfoXML.Attributes("ShowDynVisWarnings").InnerText)
            End If

            If (AppInfoXML.HasAttribute("ShowLayerAfterDynVis")) Then
                AppInfo.ShowLayerAfterDynamicVisibility = Boolean.Parse(AppInfoXML.Attributes("ShowLayerAfterDynVis").InnerText)
            End If

            'load the window title
            'Version Numbers: frmMain.Text = AppInfo.Name + " " + App.VersionString ' for now, will be rewritten later
            frmMain.Text = AppInfo.Name + " " ' for now, will be rewritten later

            'load the help munu text
            frmMain.m_Menu.AddMenu("mnuAboutMapWindow", "mnuHelp", Nothing, "&About " & AppInfo.Name)

            'load the Splash image
            With AppInfoXML.Item("SplashPicture").Item("Image")
                Type = .Attributes("Type").InnerText
                AppInfo.SplashPicture = CType(ConvertStringToImage(.InnerText, Type), Image)
            End With

            'load the Application icon
            With AppInfoXML.Item("WindowIcon").Item("Image")
                Type = .Attributes("Type").InnerText
                AppInfo.FormIcon = CType(ConvertStringToImage(.InnerText, Type), Icon)
                If .InnerText = "" Then
                ElseIf .InnerText = "AAABAAEAICAAAAEAGACoDAAAFgAAACgAAAAgAAAAQAAAAAEAGAAAAAAAgAwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD79/Pz6t3+/f0AAAD+/v/y6OL27+sAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD9/PjbwZDdxJv07d359eT48+D59OT17eHYuqjJn4n48u8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADt3762ghvQrm/8+/D48tn179T279X279T38tf+/u/Mo46SORfYua4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADl0p6tcgDKo1T///307c307c/17dD17dD17dD17dD07Mz///nAjHl6EADFl4oAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADq3LG0fQC4hBD48uP179Dz6sjz68rz68rz68rz68rz68rz68n07sv8+e+ZRy15DgDMopsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD59ujAkw+yeQDYu3b8++7w5r7y6MTy6MTy6MTy6MTy6MTy6MTy6MTx58D+/+XOp5x+FgCCHAzp19UAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADdx2y6iQC7iQPz6s728M3x573x5r7w5r3x5r7x5r3x5r3x5r7x5r7x5r7068Ly6N2NMhx7EACmXVcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD17e3q2drjzMqzexKsbgO3gSLr287p2a3x5rn28MD49cT49MP28MDz6rzw5rnv5Lfv5Lju4rL+/emmX1F/FwZ/Fw/s3NsAAAAAAAAAAAAAAAAAAAAAAADjzc22e32TOj6RODyZRkyWQjSMMQ2LLxCQNyiWQEGRNzGSOjSYRD2iWEuzd2PHm37cwZns37D28Lz38r7y6bP9/d+9iYB+FAJ3CQDGmJcAAAAAAAAAAAAAAAAAAAAAAAB2BgtmAADDkpT////////m1oS/lQC7iwDcw3b48tnl0pzcwpXPqoS+i22saVWaST2OMy+MLyyXQzuxc13Qq4T38svOp599EwF5DAStaWkAAAAAAAAAAAAAAAAAAAAAAADbvr+YREh7ExW8hojy5+zeyGq8jgC4hQDex4j28M/s36Tu46rw5qry6q707bDz7K/s36bdwpLElXKeT0CJLCThyafavLJ+FgR7DwegUlEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADNpaeXR0jUsLriz3K8jgC4hQDexofz68bl0orp2p3s36vs3qfr3KPq26Dq25/t4KLx56jx6ans4KD28b7VtKx/FgR7DwegUlIAAADdx2nMqSTl1JD+/vsAAAAAAAAAAAAAAAAAAAAAAADfynq7jgC4hQDbwHvw5bbJpRfKphTTtTzbw2Djzn/n1pTq25/r3KTr3KPq26Hp2Zv38sPPqKR8EgF5CgStamsAAAD8+fDn2JnHoRDQsDHv5LYAAAAAAAAAAAAAAAAAAADs4LC8jwC5hgDSsFr17s7hzXrdxWbVuUXPryrMqRrLqRnNrSPRszTWuknbwlzdxmfx56fBkHmCHQJ6DgHHmpb9/PX7+Oz38tzYvlO+kgDStDYAAAAAAAAAAAAAAAAAAAD7+e/Dmw26iADEmSf69+v07dDv47bm1JDn1pPm1I7izn3dxmjYvVLTtj3PrifNrCHStDC/khG4hQK1gADOrS3StDXRsjPStDbZv1nt4a39/PcAAAAAAAAAAAAAAAAAAAAAAADbwm23hAC4hADz6tYAAAAAAAD17dHjz4Lizn7l0ojl04vl0onk0ITy6cb9+/P38OyROCF+FQCqZVT8+u38+vH+/fsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD69uvAlBGyeQDZvnsAAAAAAAAAAAD69+ro15bgyXHgynTl04v17dEAAAAAAADTsKd9FQCCHA7p19gAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADs3rW0fQC6hhP8+fMAAAAAAAAAAAD9+/Xv47Xz68r+/fkAAAAAAAAAAACcTTN5DgDOpp8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADm06GucgDPrGMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADHmod7EQDIm48AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADt4cG4hR3ZvYgAAAAAAAAAAAAAAAAAAAAAAAAAAADVsqGWQRzZu7EAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD9+/jdxJbm07T7+PQAAAAAAAAAAAD8+/njzsHPqZX48/AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD7+PP79/IAAAAAAAAAAAD8+fj59fIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD////////////////////////////xH///wAf//4AD//8AAf/+AAD//AAAf/wAAH/gAAA/AAAAPwAAAD8AAAA/wAAAIfgAACD4AAAA+AAAAPwwAA/8OBh//hw4//8f8f//j+P//8OH///zn////////////////////////////w==" Then
                    'This is an old icon - let's just force them to upgrade, shall we?
                    '(e.g., don't change the icon - use what the form designer currently has for it)
                Else
                    frmMain.Icon = CType(ConvertStringToImage(.InnerText, Type), Icon)
                End If
            End With

        Catch e As System.Exception
            m_ErrorMsg += "Error: Loading the appinfoxml" + Chr(13)
            m_ErrorOccured = True
            Exit Sub
        End Try
    End Sub


#Region "Load Extents"

    Private Sub LoadExtents(ByVal ext As XmlElement)
        Dim extents As New MapWinGIS.Extents
        Dim xMax As Double
        Dim yMax As Double
        Dim xMin As Double
        Dim yMin As Double

        Try
            'set the extents of the map
            xMax = CDbl(ext.Attributes("xMax").InnerText)
            yMax = CDbl(ext.Attributes("yMax").InnerText)
            xMin = CDbl(ext.Attributes("xMin").InnerText)
            yMin = CDbl(ext.Attributes("yMin").InnerText)

            extents.SetBounds(xMin, yMin, 0, xMax, yMax, 0)

            frmMain.m_View.Extents = extents

        Catch e As System.Exception
            m_ErrorMsg += "Error: Loading the extents" + Chr(13)
            m_ErrorOccured = True
        End Try

    End Sub

#End Region

#Region "Load Preview Map Functions"

    Private Function LoadPreviewMap(ByVal previewMap As XmlElement) As Boolean
        Dim type As String
        Dim dx As Double
        Dim dy As Double
        Dim xllcenter As Double
        Dim yllcenter As Double

        Try
            'verify that all fields are valid
            With previewMap
                If (.Attributes("dx").InnerText = String.Empty _
                    Or .Attributes("dy").InnerText = String.Empty _
                    Or .Attributes("xllcenter").InnerText = String.Empty _
                    Or .Attributes("yllcenter").InnerText = String.Empty) Then Exit Function
            End With

            'get the extents of the preview Map

            dx = CDbl(previewMap.Attributes("dx").InnerText)
            dy = CDbl(previewMap.Attributes("dy").InnerText)
            xllcenter = CDbl(previewMap.Attributes("xllcenter").InnerText)
            yllcenter = CDbl(previewMap.Attributes("yllcenter").InnerText)


            'load the image
            With previewMap.Item("Image")
                type = .Attributes("Type").InnerText
                Dim img As New System.Drawing.Bitmap(CType(ConvertStringToImage(.InnerText, type), System.Drawing.Image))
                If (Not img Is Nothing) Then
                    Dim Image As New MapWinGIS.Image
                    Image.dX = dx
                    Image.dY = dy
                    Image.XllCenter = xllcenter
                    Image.YllCenter = yllcenter

                    Dim cvter As New MapWinUtility.ImageUtils
                    Image.Picture = CType(cvter.ImageToIPictureDisp(CType(img, Image)), stdole.IPictureDisp)
                    RestorePreviewMap(Image)
                    'Prevent GC
                    Image = Nothing
                End If
            End With
        Catch e As System.Exception
            '5/26/2008 Jiri Kadlec - don't show the error message, save it in the log
            'file instead.
            MapWinUtility.Logger.Dbg("Error in LoadPreviewMap(), Message: " + e.Message + Chr(13))
            'm_ErrorMsg += "Error in LoadPreviewMap(), Message: " + e.Message + Chr(13)
            'm_ErrorOccured = True
            Return False
        End Try
        Return True
    End Function

#End Region

#Region "Load View Functions"

    Private Function LoadView(ByVal view As XmlElement) As Boolean
        Try
            frmMain.WindowState = CType(view.Attributes("WindowState").InnerText, Windows.Forms.FormWindowState)

            If (Len(view.Attributes("ViewBackColor").InnerText) <> 0) Then
                frmMain.g_ViewBackColor = CInt(view.Attributes("ViewBackColor").InnerText)
                Dim backColor As System.Drawing.Color
                backColor = MapWinUtility.Colors.IntegerToColor(frmMain.g_ViewBackColor)
                AppInfo.DefaultBackColor = backColor '4/5/2008 added by JK
                frmMain.View.BackColor = backColor
            End If

            If frmMain.WindowState = FormWindowState.Normal Then
                Dim w As Integer = CInt(view.Attributes("WindowWidth").InnerText)
                Dim h As Integer = CInt(view.Attributes("WindowHeight").InnerText)
                Dim drawPoint As New System.Drawing.Point(CInt(view.Attributes("LocationX").InnerText), CInt(view.Attributes("LocationY").InnerText))
                FindSafeWindowLocation(w, h, drawPoint)
                frmMain.Width = w
                frmMain.Height = h
                frmMain.Location = drawPoint
            End If

            Try
                Select Case view.Attributes("LoadTIFFandIMGasgrid").InnerText
                    Case GeoTIFFAndImgBehavior.Automatic.ToString()
                        AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.Automatic
                    Case GeoTIFFAndImgBehavior.LoadAsImage.ToString()
                        AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.LoadAsImage
                    Case GeoTIFFAndImgBehavior.LoadAsGrid.ToString()
                        AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.LoadAsGrid
                    Case Else
                        'Default
                        AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.Automatic
                End Select
            Catch ex As Exception
                AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.Automatic
            End Try

            Try
                Select Case view.Attributes("MouseWheelBehavior").InnerText
                    Case MouseWheelZoomDir.NoAction.ToString()
                        AppInfo.MouseWheelZoom = MouseWheelZoomDir.NoAction
                    Case MouseWheelZoomDir.WheelUpZoomsOut.ToString()
                        AppInfo.MouseWheelZoom = MouseWheelZoomDir.WheelUpZoomsOut
                    Case MouseWheelZoomDir.WheelUpZoomsIn.ToString()
                        AppInfo.MouseWheelZoom = MouseWheelZoomDir.WheelUpZoomsIn
                End Select
            Catch ex As Exception
                AppInfo.MouseWheelZoom = MouseWheelZoomDir.WheelUpZoomsIn
            End Try

            Try
                Select Case view.Attributes("LoadESRIAsGrid").InnerText
                    Case ESRIBehavior.LoadAsImage.ToString()
                        AppInfo.LoadESRIAsGrid = ESRIBehavior.LoadAsImage
                    Case ESRIBehavior.LoadAsGrid.ToString()
                        AppInfo.LoadESRIAsGrid = ESRIBehavior.LoadAsGrid
                    Case Else
                        AppInfo.LoadESRIAsGrid = ESRIBehavior.LoadAsGrid
                End Select
            Catch ex As Exception
                AppInfo.LoadTIFFandIMGasgrid = GeoTIFFAndImgBehavior.LoadAsGrid ' ESRIBehavior.LoadAsGrid
            End Try

            Try
                AppInfo.LabelsUseProjectLevel = Boolean.Parse(view.Attributes("LabelsUseProjectLevel").InnerText)
            Catch ex As Exception
                AppInfo.LabelsUseProjectLevel = False
            End Try

            If frmMain.WindowState = FormWindowState.Minimized Then
                frmMain.WindowState = FormWindowState.Normal
            End If

            Try
                Boolean.TryParse(view.Attributes("TransparentSelection").InnerText, TransparentSelection)
            Catch
                TransparentSelection = True
            End Try

        Catch e As System.Exception
            m_ErrorMsg += "Error in LoadView(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
            LoadView = False
            Exit Function
        End Try

        LoadView = True
    End Function

    Private Sub LoadBookmarks(ByVal view As XmlElement)
        Dim nl As XmlNodeList = view.GetElementsByTagName("Bookmark")
        For Each x As XmlNode In nl
            Try
                If x.ChildNodes.Count > 0 Then
                    Dim exts As New MapWinGIS.Extents
                    Dim xMax As Double = CDbl(x.ChildNodes(0).Attributes("xMax").InnerText)
                    Dim yMax As Double = CDbl(x.ChildNodes(0).Attributes("yMax").InnerText)
                    Dim xMin As Double = CDbl(x.ChildNodes(0).Attributes("xMin").InnerText)
                    Dim yMin As Double = CDbl(x.ChildNodes(0).Attributes("yMin").InnerText)
                    exts.SetBounds(xMin, yMin, 0, xMax, yMax, 0)
                    Dim bm As New BookmarkedView(x.Attributes("Name").InnerText, exts)
                    BookmarkedViews.Add(bm)
                End If
            Catch
            End Try
        Next

        If BookmarkedViews.Count > 0 Then frmMain.BuildBookmarkedViewsMenu()
    End Sub

#End Region

#Region "Load Layers Functions"

    Private Sub LoadGroups(ByVal groups As XmlElement, Optional ByVal LayersOnly As Boolean = False, Optional ByVal LayersIntoGroup As String = "")
        Dim count As Integer
        Dim i As Integer
        Dim hGroup As Integer

        'load a panel
        m_panel = frmMain.StatusBar.AddPanel("", frmMain.StatusBar.NumPanels - 1, 200, StatusBarPanelAutoSize.None)

        'set the loading project so i can control the progress bar
        frmMain.m_LoadingProject = True
        frmMain.m_StatusBar.ShowProgressBar = True
        frmMain.ProgressBar1.Value = 0
        Windows.Forms.Application.DoEvents()

        'find the total number of layers to be loaded
        Dim totalNumLayers As Integer, group As XmlElement, index As Integer = 1
        For Each group In groups
            If (Not group.Item("Layers") Is Nothing) Then
                totalNumLayers += group.Item("Layers").ChildNodes.Count
            End If
        Next

        'load all of the groups
        count = groups.ChildNodes.Count

        If Not LayersIntoGroup = "" Then
            hGroup = frmMain.Legend.Groups.Add(LayersIntoGroup, frmMain.Legend.Groups.Count)
            frmMain.Legend.Groups.ItemByHandle(hGroup).Expanded = True
        End If

        For i = 0 To count - 1
            Try
                With groups
                    If Not LayersOnly Then
                        'set the group properties
                        hGroup = frmMain.Legend.Groups.Add(.ChildNodes(i).Attributes("Name").InnerText, CInt(.ChildNodes(i).Attributes("Position").InnerText))
                        frmMain.Legend.Groups.ItemByHandle(hGroup).Expanded = CBool(.ChildNodes(i).Attributes("Expanded").InnerText)

                        'set the group icon
                        If (Len(.ChildNodes(i).Item("Image").InnerText) > 0) Then
                            frmMain.Legend.Groups.ItemByHandle(hGroup).Icon = ConvertStringToImage(.ChildNodes(i).Item("Image").InnerText, .ChildNodes(i).Item("Image").Attributes("Type").InnerText)
                        End If
                    End If

                    If Not .ChildNodes(i).Item("Layers") Is Nothing Then
                        If .ChildNodes(i).Item("Layers").ChildNodes.Count > 0 Then
                            LoadLayers(.ChildNodes(i).Item("Layers"), totalNumLayers, index)
                        End If
                    End If
                End With
            Catch e As System.Exception
                m_ErrorMsg += "Error in LoadGroups(), Message: " + e.Message + Chr(13)
                m_ErrorOccured = True
            End Try
        Next

        'done loading layers 
        frmMain.m_LoadingProject = False
        frmMain.ProgressBar1.Value = 0
        frmMain.m_StatusBar.ShowProgressBar = False
        frmMain.StatusBar.RemovePanel(m_panel)
    End Sub

    Private Sub LoadLayers(ByVal layers As XmlElement, ByVal totNumLayers As Integer, ByRef index As Integer)
        Dim count As Integer
        Dim i As Integer

        count = layers.ChildNodes.Count
        For i = 0 To count - 1
            Try
                LoadLayerProperties(layers.ChildNodes(i))

                frmMain.ProgressBar1.Value = CInt((index / totNumLayers) * 100)
                frmMain.ProgressBar1.Refresh()
                Windows.Forms.Application.DoEvents()
                index += 1
            Catch e As System.Exception
                m_ErrorMsg += "Error in LoadLayers(), Message: " + e.Message + Chr(13)
                m_ErrorOccured = True
            End Try
        Next

        'test the AutoVis
        frmMain.m_AutoVis.TestLayerZoomExtents()

    End Sub

    Friend Sub LoadLayerProperties(ByVal layer As XmlNode, Optional ByVal ExistingLayerHandle As Integer = -1, Optional ByVal PluginCall As Boolean = False)
        Static LoopPrevention As Boolean = False
        If (LoopPrevention) Then Return

        Try
            Dim filePath As String = layer.Attributes("Path").InnerText
            Dim name As String = layer.Attributes("Name").InnerText
            Dim groupname As String = "" 'New element as of 8/2/2007
            Try
                If Not layer.Attributes("GroupName") Is Nothing Then
                    groupname = layer.Attributes("GroupName").InnerText
                End If
            Catch
            End Try
            Dim layerVisible As Boolean = CBool(layer.Attributes("Visible").InnerText)
            Dim type As Integer = CInt(layer.Attributes("Type").InnerText)
            Dim expanded As Boolean = CBool(layer.Attributes("Expanded").InnerText)
            Dim tag As String = layer.Attributes("Tag").InnerText
            Dim labelsVisible As Boolean = CBool(layer.Attributes("LabelsVisible").InnerText)
            Dim handle As Integer
            Dim imageType As String
            Dim gridScheme As MapWinGIS.GridColorScheme = Nothing

            'set the panel text for the progress bar
            If Not m_panel Is Nothing Then m_panel.Text = "Loading " & name & "..."

            If type = MapWindow.Interfaces.eLayerType.LineShapefile Or type = MapWindow.Interfaces.eLayerType.PointShapefile Or type = MapWindow.Interfaces.eLayerType.PolygonShapefile Then
                'add shapefile layer
                With layer.Item("ShapeFileProperties")
                    Dim color As Integer = CInt(.Attributes("Color").InnerText)
                    Dim outlineColor As Integer = CInt(.Attributes("OutLineColor").InnerText)
                    Dim drawFill As Boolean = CBool(.Attributes("DrawFill").InnerText)
                    Dim lineOrPointSize As Single = CSng(.Attributes("LineOrPointSize").InnerText)
                    Dim pointType As MapWinGIS.tkPointType = CType(.Attributes("PointType").InnerText, MapWinGIS.tkPointType)
                    Dim lineStipple As MapWinGIS.tkLineStipple = CType(.Attributes("LineStipple").InnerText, MapWinGIS.tkLineStipple)
                    Dim fillStipple As MapWinGIS.tkFillStipple = CType(.Attributes("FillStipple").InnerText, MapWinGIS.tkFillStipple)

                    Dim fillStippleLineColor As Color = Drawing.Color.Black
                    If .Attributes("FillStippleLineColor") IsNot Nothing Then fillStippleLineColor = System.Drawing.Color.FromArgb(Integer.Parse(.Attributes("FillStippleLineColor").InnerText))

                    Dim fillStippleTransparent As Boolean = True
                    If .Attributes("FillStippleTransparent") IsNot Nothing Then fillStippleTransparent = Boolean.Parse(.Attributes("FillStippleTransparent").InnerText)

                    Dim transPercent As Single = 1
                    Try
                        transPercent = CSng(.Attributes("TransparencyPercent").InnerText)
                    Catch
                    End Try
                    Dim userPointType As New MapWinGIS.Image
                    userPointType.Picture = CType(ConvertStringToImage(.Item("CustomPointType").Item("Image").InnerText, .Item("CustomPointType").Item("Image").Attributes("Type").InnerText), stdole.IPictureDisp)

                    If (Not userPointType Is Nothing) Then
                        If (.Attributes("UseTransparency").InnerText = "") Then
                            userPointType.UseTransparencyColor = False
                        Else
                            userPointType.UseTransparencyColor = CBool(.Attributes("UseTransparency").InnerText)
                        End If

                        If (.Attributes("TransparencyColor").InnerText = "") Then
                            userPointType.TransparencyColor = Convert.ToUInt32(0)
                        Else
                            userPointType.TransparencyColor = Convert.ToUInt32(.Attributes("TransparencyColor").InnerText)
                        End If
                    End If

                    'Need to move the layer?
                    Try
                        LoopPrevention = True
                        If ExistingLayerHandle = -1 Then
                            'We are adding this layer from within a project file.
                            'Don't change the ordering because the project file
                            'specifies this; but still add the layer
                            'Debugging: MsgBox("No move")

                            'make sure the file exists
                            'Chris Michaelis July 26 05 - changed to warn the user and ask if they'd like to find it.
                            ' Old: If (System.IO.File.Exists(filePath) = False) Then Exit Sub

                            If (System.IO.File.Exists(filePath) = False) Then
                                ' This operation will have changed the current working directory.
                                ' Preserve it and set it back, or all subsequent layers will not be found either.
                                Dim cwd As String = CurDir()

                                ' PromptBrowse will set the file path by reference and return true,
                                ' or return false if the user cancels.
                                If Not PromptToBrowse(filePath, name) Then Exit Sub

                                'add layer
                                handle = frmMain.m_layers.AddLayer(System.IO.Path.GetFullPath(filePath), name, , layerVisible, color, outlineColor, drawFill, lineOrPointSize, pointType)(0).Handle

                                'Restore CWD
                                ChDir(cwd)
                            Else
                                'add layer
                                handle = frmMain.m_layers.AddLayer(System.IO.Path.GetFullPath(filePath), name, , layerVisible, color, outlineColor, drawFill, lineOrPointSize, pointType)(0).Handle
                            End If
                        Else
                            'Debugging: MsgBox("move")
                            'Added...!
                            handle = ExistingLayerHandle

                            'Determine if we need to move it
                            Dim destGroup As Integer = -1
                            'Is the saved group in the list of groups?
                            For iz As Integer = 0 To frmMain.Layers.Groups.Count - 1
                                If frmMain.Layers.Groups(iz).Text.ToLower().Trim() = groupname.ToLower.Trim() And Not groupname.Trim() = "" Then
                                    destGroup = frmMain.Layers.Groups(iz).Handle
                                    Exit For
                                End If
                            Next

                            'We don't try to do this if the layer was added via a plug-in.
                            'We trust plug-ins to handle positioning layers appropriately,
                            'esp. as most have specific requirements there.
                            If Not PluginCall Then
                                If destGroup = -1 Then
                                    'Create the group -- see BugZilla 529, requested by ATC
                                    destGroup = frmMain.Layers.Groups.Add(groupname.Trim(), 0)
                                End If

                                frmMain.Layers.MoveLayer(handle, 0, destGroup)
                            End If
                        End If
                    Catch
                    Finally
                        LoopPrevention = False
                    End Try

                    frmMain.Layers(handle).Name = name
                    frmMain.Layers(handle).LineStipple = lineStipple
                    frmMain.Layers(handle).FillStipple = fillStipple
                    frmMain.Layers(handle).FillStippleLineColor = fillStippleLineColor
                    frmMain.Layers(handle).FillStippleTransparency = fillStippleTransparent
                    frmMain.Layers(handle).ShapeLayerFillTransparency = transPercent
                    frmMain.Layers(handle).LineOrPointSize = lineOrPointSize
                    frmMain.Layers(handle).DrawFill = drawFill
                    If type = MapWindow.Interfaces.eLayerType.PointShapefile Then
                        'Vertices are always visible - layer visibility is used to
                        'toggle overall visibility here.
                        frmMain.Layers(handle).VerticesVisible = True
                    Else
                        frmMain.Layers(handle).VerticesVisible = False
                        Try
                            frmMain.Layers(handle).VerticesVisible = Boolean.Parse(.Attributes("VerticesVisible").InnerText)
                        Catch
                        End Try
                    End If

                    Try
                        frmMain.Layers(handle).LabelsVisible = Boolean.Parse(.Attributes("LabelsVisible").InnerText)
                    Catch
                        frmMain.Layers(handle).LabelsVisible = True
                    End Try

                    Try
                        Integer.TryParse(.Attributes("MapTooltipField").InnerText, frmMain.Legend.Layers.ItemByHandle(handle).MapTooltipFieldIndex)
                        Boolean.TryParse(.Attributes("MapTooltipsEnabled").InnerText, frmMain.Legend.Layers.ItemByHandle(handle).MapTooltipsEnabled)
                        frmMain.UpdateMapToolTipsAtLeastOneLayer()
                    Catch
                    End Try

                    Try
                        'NOTE: These must go above coloring scheme or they will
                        'override the coloring scheme!
                        frmMain.Layers(handle).OutlineColor = System.Drawing.ColorTranslator.FromOle(outlineColor)
                        frmMain.Layers(handle).Color = System.Drawing.ColorTranslator.FromOle(color)
                        'frmMain.MapMain.set_ShapeLayerFillColor(handle, color)
                        'frmMain.MapMain.set_ShapeLayerLineColor(handle, outlineColor)
                    Catch
                    End Try

                    'load the coloring scheme
                    If Not .Item("Legend") Is Nothing Then
                        LoadShpFileColoringScheme(.Item("Legend"), handle)
                    End If

                    'add the userpointtype image
                    If (Not userPointType Is Nothing) Then
                        frmMain.Layers(handle).UserPointType = userPointType
                    End If

                    frmMain.Layers(handle).PointType = pointType

                    DeserializePointImageScheme(handle, layer.Item("ShapeFileProperties"))

                    DeserializeFillStippleScheme(handle, layer.Item("ShapeFileProperties"))

                    ' tws 04/29/2007
                    'load the shape-level formatting scheme
                    If Not .Item("ShapePropertiesList") Is Nothing Then
                        LoadShapePropertiesList(.Item("ShapePropertiesList"), handle)
                    End If
                End With

                'We just loaded a layer -- update/create the mwsr file
                'and if we weren't loading the mwsr file to begin with, i.e. ExistingLayerHandle = -1
                '(http://bugs.mapwindow.org/show_bug.cgi?id=340)
                If ExistingLayerHandle = -1 Then
                    frmMain.SaveShapeLayerProps(handle)
                End If

            ElseIf type = MapWindow.Interfaces.eLayerType.Image Or type = MapWindow.Interfaces.eLayerType.Grid Then
                'add image or grid layer
                Dim transparentColor As Integer = 0
                Dim useTransparency As Boolean = False
                Dim GridProperty As XmlNode = layer.Item("GridProperty")
                If GridProperty IsNot Nothing Then
                    With GridProperty
                        Try
                            transparentColor = CInt(.Attributes("TransparentColor").InnerText)
                        Catch
                        End Try
                        Try
                            useTransparency = CBool(.Attributes("UseTransparency").InnerText)
                        Catch
                        End Try

                        'load the coloring scheme if it is a grid
                        If .HasChildNodes Then
                            gridScheme = LoadGridFileColoringScheme(.Item("Legend"))
                        End If
                    End With
                End If
                'make sure the file exists
                'Chris Michaelis July 26 05 - changed to warn the user and ask if they'd like to find it.
                ' Old: If (System.IO.File.Exists(filePath) = False) Then Exit Sub

                If (System.IO.File.Exists(filePath) = False) Then
                    ' This operation will have changed the current working directory.
                    ' Preserve it and set it back, or all subsequent layers will not be found either.
                    Dim cwd As String = CurDir()

                    ' PromptBrowse will set the file path by reference and return true,
                    ' or return false if the user cancels.
                    If Not PromptToBrowse(filePath, name) Then Exit Sub

                    'add layer -- add explicitly as an image or a grid.
                    'Chris Michaelis 2/1/2006 -- Changed this to explicitly
                    'load it as an image or a grid, depending on what was
                    'saved in the project file.
                    'This corrects the bug of explicitly adding an image-class GeoTIFF
                    'as a grid (e.g. to read the first band of 0-255 image values, or
                    'if the IsTIFFGrid call failed, etc), then saving it to a project file,
                    'then improperly loading it as an image when loading the
                    'project file -- improperly trusting the output of IsTIFFGrid. This 
                    'won't have a noticeable effect most of the time, but when it does 
                    'matter this will be a beneficial change.
                    If (type = MapWindow.Interfaces.eLayerType.Image) Then
                        Dim tImg As New MapWinGIS.Image
                        tImg.Open(System.IO.Path.GetFullPath(filePath))
                        handle = frmMain.m_layers.AddLayer(tImg, name, , layerVisible, , , , , , gridScheme)(0).Handle
                        tImg = Nothing
                        'Don't delete or close tImg or it will close the underlying
                        'object that was just added to the map.
                    ElseIf (type = MapWindow.Interfaces.eLayerType.Grid) Then
                        Dim tGrd As New MapWinGIS.Grid
                        tGrd.Open(System.IO.Path.GetFullPath(filePath))
                        handle = frmMain.m_layers.AddLayer(tGrd, name, , layerVisible, , , , , , gridScheme)(0).Handle
                        tGrd = Nothing
                        'Don't delete or close tImg or it will close the underlying
                        'object that was just added to the map.
                    End If

                    'Old code that didn't distinguish between image
                    'or grid explicitly (thus relying on IsTiffGrid()):
                    'handle = frmMain.m_layers.AddLayer(System.IO.Path.GetFullPath(filePath), name, , layerVisible, , , , , , gridScheme)(0).Handle

                    'Restore CWD
                    ChDir(cwd)
                Else
                    'add layer 
                    'Note - This will automatically pick up the coloring scheme for the legend.
                    'before, we were setting the coloringscheme property on the layer.  This 
                    'forced a rebuild of the grid image each time and was much slower.  
                    'dpa 6/9/2005

                    'add layer -- add explicitly as an image or a grid.
                    'Chris Michaelis 2/1/2006 -- Changed this to explicitly
                    'load it as an image or a grid, depending on what was
                    'saved in the project file.
                    'This corrects the bug of explicitly adding an image-class GeoTIFF
                    'as a grid (e.g. to read the first band of 0-255 image values, or
                    'if the IsTIFFGrid call failed, etc), then saving it to a project file,
                    'then improperly loading it as an image when loading the
                    'project file -- improperly trusting the output of IsTIFFGrid. This 
                    'won't have a noticeable effect most of the time, but when it does 
                    'matter this will be a beneficial change.
                    If (type = MapWindow.Interfaces.eLayerType.Image) Then
                        Dim tImg As New MapWinGIS.Image
                        tImg.Open(System.IO.Path.GetFullPath(filePath))
                        handle = frmMain.m_layers.AddLayer(tImg, name, , layerVisible, , , , , , gridScheme)(0).Handle
                        tImg = Nothing
                        'Don't delete or close tImg or it will close the underlying
                        'object that was just added to the map.
                    ElseIf (type = MapWindow.Interfaces.eLayerType.Grid) Then

                        Dim tGrd As New MapWinGIS.Grid

                        tGrd.Open(System.IO.Path.GetFullPath(filePath))

                        'MsgBox(String.Format("starting m_layers.AddLayer(tGrd,{0},,{1},,,,,,{2})", name, layerVisible, "gridScheme")) 'DEBUG JK
                        handle = frmMain.m_layers.AddLayer(tGrd, name, , layerVisible, , , , , , gridScheme)(0).Handle
                        tGrd = Nothing
                        'Don't delete or close tImg or it will close the underlying
                        'object that was just added to the map.
                    End If

                    'Old code that didn't distinguish between image
                    'or grid explicitly (thus relying on IsTiffGrid()):
                    'handle = frmMain.m_layers.AddLayer(System.IO.Path.GetFullPath(filePath), name, , layerVisible, , , , , , gridScheme)(0).Handle
                End If

                'add image properties
                frmMain.Layers(handle).ImageTransparentColor = MapWinUtility.Colors.IntegerToColor(transparentColor)
                frmMain.Layers(handle).UseTransparentColor = useTransparency

                If type = MapWindow.Interfaces.eLayerType.Grid Then
                    ' 10/17/2007 - SaveShapeLayerProps == misnomer - can also be used for saving grid coloring scheme.
                    ' Can't change name now without breaking interface
                    frmMain.SaveShapeLayerProps(handle)
                End If
            Else
                'make sure the file exists
                'Chris Michaelis July 26 05 - changed to warn the user and ask if they'd like to find it.
                ' Old: If (System.IO.File.Exists(filePath) = False) Then Exit Sub
                If (System.IO.File.Exists(filePath) = False) Then
                    ' This operation will have changed the current working directory.
                    ' Preserve it and set it back, or all subsequent layers will not be found either.
                    Dim cwd As String = CurDir()

                    ' PromptBrowse will set the file path by reference and return true,
                    ' or return false if the user cancels.
                    If Not PromptToBrowse(filePath, name) Then Exit Sub

                    handle = frmMain.m_layers.AddLayer(filePath, name, , layerVisible)(0).Handle

                    'Restore CWD
                    ChDir(cwd)
                Else
                    'add some other layer
                    handle = frmMain.m_layers.AddLayer(filePath, name, , layerVisible)(0).Handle
                End If
            End If

            'properties of all layers
            With frmMain.Layers(handle)
                .Expanded = expanded
                .Tag = tag
                .LabelsVisible = labelsVisible
            End With

            'add the layer image
            Dim layerImage As XmlNode = layer.Item("Image")
            imageType = ""
            If layerImage IsNot Nothing Then
                Try
                    imageType = layerImage.Attributes("Type").InnerText
                    If Len(imageType) > 0 Then
                        frmMain.Layers(handle).Icon = ConvertStringToImage(layerImage.InnerText, imageType)
                    End If
                Catch
                End Try
            End If
            frmMain.Layers(handle).Expanded = expanded

            'load the Dynamic Visibility options
            LoadDynamicVisibility(frmMain.Layers(handle), layer.Item("DynamicVisibility"))
        Catch e As System.Exception
            m_ErrorMsg += "Error in LoadLayerProperties(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
        End Try
    End Sub

    Private Sub LoadDynamicVisibility(ByVal mapWinLayer As MapWindow.Interfaces.Layer, ByVal node As Xml.XmlNode)
        Try
            'add DynamicVisibility options
            Dim useDynamicVisibility As Boolean = False
            Dim xMin As Double = 0
            Dim yMin As Double = 0
            Dim xMax As Double = 0
            Dim yMax As Double = 0

            If node IsNot Nothing Then
                useDynamicVisibility = CBool(node.Attributes("UseDynamicVisibility").InnerText)
                xMin = CDbl(node.Attributes("xMin").InnerText)
                yMin = CDbl(node.Attributes("yMin").InnerText)
                xMax = CDbl(node.Attributes("xMax").InnerText)
                yMax = CDbl(node.Attributes("yMax").InnerText)
            End If
            Dim ex As MapWinGIS.Extents = New MapWinGIS.Extents
            ex.SetBounds(xMin, yMin, 0, xMax, yMax, 0)

            'DynamicVisibility prop
            With mapWinLayer

                'set the extents
                If Not (xMin = 0 And yMin = 0 And xMax = 0 And yMax = 0) Then
                    'CDM 1/2/2007 Remove the auto-vis item if the handle is already
                    'loaded -- should only be on a fluke, since it's emptied
                    'on close now too.
                    If frmMain.m_AutoVis.Contains(.Handle) Then frmMain.m_AutoVis.Remove(.Handle)

                    frmMain.m_AutoVis.Add(.Handle, ex, useDynamicVisibility)
                End If

            End With
        Catch e As System.Exception
            m_ErrorMsg += "Error in LoadDynamicVisibility(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
        End Try
    End Sub

    Private Sub LoadShpFileColoringScheme(ByVal legend As XmlElement, ByVal handle As Integer)
        Dim shpscheme As New MapWinGIS.ShapefileColorScheme
        Dim numOfBreaks As Integer
        Dim break As MapWinGIS.ShapefileColorBreak
        Dim i As Integer

        Try
            'set the shape file color scheme properties
            shpscheme.FieldIndex = CInt(legend.Attributes("FieldIndex").InnerText)
            shpscheme.LayerHandle = handle
            shpscheme.Key = legend.Attributes("Key").InnerText

            Try
                frmMain.Legend.Layers.ItemByHandle(handle).ColorSchemeFieldCaption = legend.Attributes("SchemeCaption").InnerText
            Catch
            End Try

            'set all of the breaks
            numOfBreaks = legend.Item("ColorBreaks").ChildNodes.Count
            For i = 0 To numOfBreaks - 1
                With legend.Item("ColorBreaks").ChildNodes(i)
                    break = New MapWinGIS.ShapefileColorBreak
                    break.Caption = .Attributes("Caption").InnerText
                    break.StartColor = System.Convert.ToUInt32(.Attributes("StartColor").InnerText)
                    break.EndColor = System.Convert.ToUInt32(.Attributes("EndColor").InnerText)
                    If .Attributes("StartValue").InnerText = "(null)" Then
                        break.StartValue = Nothing
                    Else
                        break.StartValue = .Attributes("StartValue").InnerText
                    End If
                    If .Attributes("EndValue").InnerText = "(null)" Then
                        break.EndValue = Nothing
                    Else
                        break.EndValue = .Attributes("EndValue").InnerText
                    End If
                    If Not .Attributes("Visible") Is Nothing AndAlso Not .Attributes("Visible").InnerText = "" Then
                        break.Visible = Boolean.Parse(.Attributes("Visible").InnerText)
                    End If

                    shpscheme.Add(break)
                End With
            Next

            If (numOfBreaks > 0) Then
                'set that layers scheme and redraw the legend
                frmMain.Layers(handle).ColoringScheme = shpscheme
                frmMain.Legend.Refresh()
            End If

        Catch e As System.Exception
            m_ErrorMsg += "Error in LoadShpFileColoringScheme(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
        End Try

    End Sub

    ' tws 04/29/2007
    Private Sub LoadShapePropertiesList(ByVal propList As XmlElement, ByVal handle As Integer)
        Try
            For Each sProp As XmlElement In propList.ChildNodes
                Dim ix As Integer = Integer.Parse(sProp.GetAttribute("ShapeIndex"))
                'Dim sC As UInt32 = System.Convert.ToUInt32(sProp.GetAttribute("LineColor"))
                For Each xmla As XmlAttribute In sProp.Attributes
                    ' count on the output logic to get them right for the type:
                    ' just process whatever we get
                    Select Case xmla.Name
                        Case "ShapeIndex"
                            ' we already did this one

                        Case "DrawLine"
                            Dim b As Boolean = Boolean.Parse(sProp.GetAttribute("DrawLine"))
                            frmMain.MapMain.set_ShapeDrawLine(handle, ix, b)
                        Case "LineColor"
                            Dim sc As Color = Color.FromArgb(Integer.Parse(sProp.GetAttribute("LineColor")))
                            frmMain.MapMain.set_ShapeLineColor(handle, ix, ColorTranslator.ToOle(sc))
                        Case "LineWidth"
                            Dim sL As Integer = Integer.Parse(sProp.GetAttribute("LineWidth"))
                            frmMain.MapMain.set_ShapeLineWidth(handle, ix, sL)
                        Case "LineStyle"
                            Dim i As Integer = Integer.Parse(sProp.GetAttribute("LineStyle"))
                            frmMain.MapMain.set_ShapeLineStipple(handle, ix, i)

                        Case "DrawPoint"
                            Dim b As Boolean = Boolean.Parse(sProp.GetAttribute("DrawPoint"))
                            frmMain.MapMain.set_ShapeDrawPoint(handle, ix, b)
                        Case "PointColor"
                            Dim sc As Color = Color.FromArgb(Integer.Parse(sProp.GetAttribute("PointColor")))
                            frmMain.MapMain.set_ShapePointColor(handle, ix, ColorTranslator.ToOle(sc))
                        Case "PointSize"
                            Dim sP As Integer = Integer.Parse(sProp.GetAttribute("PointSize"))
                            frmMain.MapMain.set_ShapePointSize(handle, ix, sP)

                        Case "DrawFill"
                            Dim b As Boolean = Boolean.Parse(sProp.GetAttribute("DrawFill"))
                            frmMain.MapMain.set_ShapeDrawFill(handle, ix, b)
                        Case "FillColor"
                            Dim sc As Color = Color.FromArgb(Integer.Parse(sProp.GetAttribute("FillColor")))
                            frmMain.MapMain.set_ShapeFillColor(handle, ix, ColorTranslator.ToOle(sc))
                        Case "FillTransparency"
                            Dim s As Single = Single.Parse(sProp.GetAttribute("FillTransparency"))
                            frmMain.MapMain.set_ShapeFillTransparency(handle, ix, s)
                        Case "FillStyle"
                            Dim i As Integer = Integer.Parse(sProp.GetAttribute("FillStyle"))
                            frmMain.MapMain.set_ShapeFillStipple(handle, ix, i)
                        Case Else
                            ' maybe we should complain here, this case must be a coding error
                    End Select
                Next
            Next
        Catch e As System.Exception
            m_ErrorMsg += "Error in LoadShapePropertiesList(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
        End Try
    End Sub

    Private Function LoadGridFileColoringScheme(ByVal legend As XmlElement) As MapWinGIS.GridColorScheme
        Dim gridScheme As New MapWinGIS.GridColorScheme
        Dim numOfBreaks As Integer
        Dim break As MapWinGIS.GridColorBreak
        Dim i As Integer

        Try
            'set the grid file color scheme properties
            gridScheme.NoDataColor = System.Convert.ToUInt32(legend.Attributes("NoDataColor").InnerText)
            gridScheme.Key = legend.Attributes("Key").InnerText

            'set all of the breaks
            numOfBreaks = legend.Item("ColorBreaks").ChildNodes.Count
            For i = 0 To numOfBreaks - 1
                With legend.Item("ColorBreaks").ChildNodes(i)
                    break = New MapWinGIS.GridColorBreak
                    break.Caption = .Attributes("Caption").InnerText
                    break.HighColor = System.Convert.ToUInt32(.Attributes("HighColor").InnerText)
                    break.LowColor = System.Convert.ToUInt32(.Attributes("LowColor").InnerText)
                    break.HighValue = CDbl(.Attributes("HighValue").InnerText)
                    break.LowValue = CDbl(.Attributes("LowValue").InnerText)
                    break.GradientModel = CType(.Attributes("GradientModel").InnerText, MapWinGIS.GradientModel)
                    break.ColoringType = CType(.Attributes("ColoringType").InnerText, MapWinGIS.ColoringType)
                    gridScheme.InsertBreak(break)
                End With
            Next

            If numOfBreaks > 0 Then
                Return gridScheme
            Else
                Return Nothing
            End If

        Catch e As System.Exception
            m_ErrorMsg += "Error in LoadGridFileColoringScheme(), Message: " + e.Message + Chr(13)
            m_ErrorOccured = True
            Return Nothing
        End Try

    End Function

#End Region

#Region "Load Plugins"

    Private Sub LoadApplicationPlugins(ByVal plugins As XmlElement, ByVal loadingConfig As Boolean)
        Dim count As Integer
        Dim i As Integer

        'exit if this element does not exists
        If (plugins Is Nothing) Then Exit Sub

        If (loadingConfig) Then
            'get the application plugin dir
            If (plugins.Attributes("PluginDir").InnerText <> "") Then
                AppInfo.ApplicationPluginDir = System.IO.Path.GetFullPath(plugins.Attributes("PluginDir").InnerText)
            End If

            frmMain.m_PluginManager.LoadApplicationPlugins(AppInfo.ApplicationPluginDir)
        End If

        count = plugins.ChildNodes.Count
        For i = 0 To count - 1
            Try
                LoadPlugin(plugins.ChildNodes(i), loadingConfig, True)
            Catch e As System.Exception
                m_ErrorMsg += "Error in LoadApplicationPlugins(), Message: " + e.Message + Chr(13)
                m_ErrorOccured = True
            End Try
        Next
    End Sub

    Private Sub LoadPlugins(ByVal plugins As XmlElement, ByVal loadingConfig As Boolean)
        Dim count As Integer
        Dim i As Integer

        count = plugins.ChildNodes.Count
        For i = 0 To count - 1
            '       Try
            LoadPlugin(plugins.ChildNodes(i), loadingConfig, False)
            'Catch e As System.Exception
            '    m_ErrorMsg += "Error in LoadPlugins(), Message: " + e.Message + Chr(13)
            '    m_ErrorOccured = True
            'End Try
        Next

    End Sub

    Private Sub LoadPlugin(ByVal plugin As XmlNode, ByVal loadingConfig As Boolean, ByVal loadingApplictionPlugins As Boolean)
        Dim settingsString As String = plugin.Attributes("SettingsString").InnerText
        Dim key As String = plugin.Attributes("Key").InnerText

        'load the plugin if needed
        If Not frmMain.m_PluginManager.PluginIsLoaded(key) Then
            MapWinUtility.Logger.Dbg("LoadPlugIn:" & key)
            frmMain.m_PluginManager.StartPlugin(key)
        End If

        'send the loading event
        frmMain.m_PluginManager.ProjectLoading(key, ProjectFileName, settingsString)
        MapWinUtility.Logger.Dbg("Loaded:" & key)
    End Sub

#End Region

#Region "Translate Legacy VWR file"
    Private Function TranslateLegacyVWR(ByVal projectPath As String) As Boolean
        Dim oldDoc As New XmlDocument
        Dim newDoc As New XmlDocument
        Dim oldRoot, newRoot As XmlElement

        If Not System.IO.File.Exists(projectPath) Then
            Return False
        Else
            ChDir(System.IO.Path.GetDirectoryName(projectPath))
            Try
                oldDoc.Load(projectPath)

                If oldDoc.InnerXml.StartsWith("<Mapwin") Then
                    Return True
                ElseIf oldDoc.InnerXml.StartsWith("<DFViewer") Then
                    'save the old vwr to .bak and overwrite the vwr with new format
                    If IO.File.Exists(projectPath + ".bak") Then
                        IO.File.Delete(projectPath + ".bak")
                    End If
                    oldDoc.Save(projectPath + ".bak")
                    IO.File.Delete(projectPath)
                    oldRoot = oldDoc.DocumentElement

                    Dim Ver As String = App.VersionString()
                    Dim ConfigPath As XmlAttribute

                    Dim prjName As String = frmMain.Text.Replace("'", "")
                    newDoc.LoadXml("<Mapwin name='" + System.Web.HttpUtility.UrlEncode(prjName) + "' type='projectfile' version='" + System.Web.HttpUtility.UrlEncode(Ver) + "'></Mapwin>")
                    newRoot = newDoc.DocumentElement


                    'Add the configuration path
                    ConfigPath = newDoc.CreateAttribute("ConfigurationPath")
                    ConfigPath.InnerText = GetRelativePath(ConfigFileName, ProjectFileName)
                    newRoot.Attributes.Append(ConfigPath)


                    'Add the projection
                    Dim proj As Xml.XmlAttribute = newDoc.CreateAttribute("ProjectProjection")
                    Try
                        proj.InnerText = oldRoot.Attributes("ProjectProjection").InnerText
                    Catch ex As Exception
                        proj.InnerText = ""
                    End Try
                    newRoot.Attributes.Append(proj)


                    'Add the map units
                    Dim mapunit As Xml.XmlAttribute = newDoc.CreateAttribute("MapUnits")
                    Try
                        mapunit.InnerText = oldRoot.Attributes("MapUnits").InnerText
                    Catch ex As Exception
                        mapunit.InnerText = MapWindow.Interfaces.UnitOfMeasure.Inches.ToString() 'Will default back later
                    End Try
                    newRoot.Attributes.Append(mapunit)


                    'Add the status bar coord customizations
                    Dim xStatusBarAlternateCoordsNumDecimals As Xml.XmlAttribute = newDoc.CreateAttribute("StatusBarAlternateCoordsNumDecimals")
                    xStatusBarAlternateCoordsNumDecimals.InnerText = 3.ToString
                    newRoot.Attributes.Append(xStatusBarAlternateCoordsNumDecimals)
                    Dim xStatusBarCoordsNumDecimals As Xml.XmlAttribute = newDoc.CreateAttribute("StatusBarCoordsNumDecimals")
                    xStatusBarCoordsNumDecimals.InnerText = 3.ToString
                    newRoot.Attributes.Append(xStatusBarCoordsNumDecimals)
                    Dim xStatusBarAlternateCoordsUseCommas As Xml.XmlAttribute = newDoc.CreateAttribute("StatusBarAlternateCoordsUseCommas")
                    xStatusBarAlternateCoordsUseCommas.InnerText = True.ToString
                    newRoot.Attributes.Append(xStatusBarAlternateCoordsUseCommas)
                    Dim xStatusBarCoordsUseCommas As Xml.XmlAttribute = newDoc.CreateAttribute("StatusBarCoordsUseCommas")
                    xStatusBarCoordsUseCommas.InnerText = True.ToString
                    newRoot.Attributes.Append(xStatusBarCoordsUseCommas)

                    Dim ShowFloatingScaleBar As Xml.XmlAttribute = newDoc.CreateAttribute("ShowFloatingScaleBar")
                    ShowFloatingScaleBar.InnerText = False.ToString
                    newRoot.Attributes.Append(ShowFloatingScaleBar)

                    Dim FloatingScaleBarPosition As Xml.XmlAttribute = newDoc.CreateAttribute("FloatingScaleBarPosition")
                    FloatingScaleBarPosition.InnerText = "Lower Right"
                    newRoot.Attributes.Append(FloatingScaleBarPosition)

                    Dim FloatingScaleBarUnit As Xml.XmlAttribute = newDoc.CreateAttribute("FloatingScaleBarUnit")
                    FloatingScaleBarUnit.InnerText = ""
                    newRoot.Attributes.Append(FloatingScaleBarUnit)

                    Dim FloatingScaleBarForecolor As Xml.XmlAttribute = newDoc.CreateAttribute("FloatingScaleBarForecolor")
                    FloatingScaleBarForecolor.InnerText = System.Drawing.Color.Black.ToString
                    newRoot.Attributes.Append(FloatingScaleBarForecolor)

                    Dim FloatingScaleBarBackcolor As Xml.XmlAttribute = newDoc.CreateAttribute("FloatingScaleBarBackcolor")
                    FloatingScaleBarBackcolor.InnerText = System.Drawing.Color.White.ToString
                    newRoot.Attributes.Append(FloatingScaleBarBackcolor)


                    'Add the map resize behavior
                    Dim resizebehavior As Xml.XmlAttribute = newDoc.CreateAttribute("MapResizeBehavior")
                    resizebehavior.InnerText = "0"
                    newRoot.Attributes.Append(resizebehavior)


                    'Add whether to display various coordinate systems in the status bar
                    Dim coord_projected As Xml.XmlAttribute = newDoc.CreateAttribute("ShowStatusBarCoords_Projected")
                    coord_projected.InnerText = True.ToString
                    newRoot.Attributes.Append(coord_projected)
                    Dim coord_alternate As Xml.XmlAttribute = newDoc.CreateAttribute("ShowStatusBarCoords_Alternate")
                    coord_alternate.InnerText = "Kilometers"
                    newRoot.Attributes.Append(coord_alternate)


                    'Add the save shape settings behavior
                    Dim saveshapesettinfgsbehavior As Xml.XmlAttribute = newDoc.CreateAttribute("SaveShapeSettings")
                    saveshapesettinfgsbehavior.InnerText = False.ToString
                    newRoot.Attributes.Append(saveshapesettinfgsbehavior)


                    'Add the project-level map background color settings (5/4/2008 added by JK)
                    Dim backColor_useDefault As Xml.XmlAttribute = newDoc.CreateAttribute("ViewBackColor_UseDefault")
                    backColor_useDefault.InnerText = True.ToString
                    newRoot.Attributes.Append(backColor_useDefault)
                    Dim backColor As Xml.XmlAttribute = newDoc.CreateAttribute("ViewBackColor")
                    backColor.InnerText = (MapWinUtility.Colors.ColorToInteger(System.Drawing.Color.White)).ToString
                    newRoot.Attributes.Append(backColor)


                    'Add the list of the plugins to the project file
                    Dim Plugins As XmlElement = newDoc.CreateElement("Plugins")
                    newRoot.AppendChild(Plugins)


                    'Add the application plugins
                    Dim AppPlugins As XmlElement = newDoc.CreateElement("ApplicationPlugins")
                    Dim Dir As XmlAttribute = newDoc.CreateAttribute("PluginDir")
                    Dir.InnerText = ""
                    AppPlugins.Attributes.Append(Dir)


                    Try
                        Dim AppPlugin As XmlElement = newDoc.CreateElement("Plugin")
                        Dim settingstring As XmlAttribute = newDoc.CreateAttribute("SettingsString")
                        Dim SSKey As XmlAttribute = newDoc.CreateAttribute("Key")
                        'format of <Plugin SettingsString="4{}c:\temp\dfirm_database" Key="RasterCatalog_clsRasterCatalog" />
                        settingstring.InnerText = oldRoot.Attributes("noOfAutho").InnerText + "{}" + oldRoot.Attributes("OrthoLocation").InnerText
                        SSKey.InnerText = "RasterCatalog_clsRasterCatalog"
                        AppPlugin.Attributes.Append(settingstring)
                        AppPlugin.Attributes.Append(SSKey)
                        AppPlugins.AppendChild(AppPlugin)
                    Catch ex As Exception
                    End Try

                    newRoot.AppendChild(AppPlugins)

                    'Add extents of map
                    Dim Extents As XmlElement = newDoc.CreateElement("Extents")
                    Dim xMax As XmlAttribute = newDoc.CreateAttribute("xMax")
                    Dim yMax As XmlAttribute = newDoc.CreateAttribute("yMax")
                    Dim xMin As XmlAttribute = newDoc.CreateAttribute("xMin")
                    Dim yMin As XmlAttribute = newDoc.CreateAttribute("yMin")
                    Try
                        xMax.InnerText = oldRoot.Item("Extents").Attributes("xMax").InnerText
                    Catch ex As Exception
                        xMax.InnerText = "0"
                    End Try
                    Try
                        yMax.InnerText = oldRoot.Item("Extents").Attributes("yMax").InnerText
                    Catch ex As Exception
                        yMax.InnerText = "0"
                    End Try
                    Try
                        xMin.InnerText = oldRoot.Item("Extents").Attributes("xMin").InnerText
                    Catch ex As Exception
                        xMin.InnerText = "0"
                    End Try
                    Try
                        yMin.InnerText = oldRoot.Item("Extents").Attributes("yMax").InnerText
                    Catch ex As Exception
                        yMin.InnerText = "0"
                    End Try

                    Dim ext As New MapWinGIS.Extents
                    ext.SetBounds(xMin.InnerText, yMin.InnerText, 0, xMax.InnerText, yMax.InnerText, 0)

                    Extents.Attributes.Append(xMax)
                    Extents.Attributes.Append(yMax)
                    Extents.Attributes.Append(xMin)
                    Extents.Attributes.Append(yMin)
                    newRoot.AppendChild(Extents)

                    'Add the layers
                    TranslateLegacyVWRLayers(oldDoc, oldRoot, newDoc, newRoot, projectPath, proj.InnerText, ext)

                    ''Add view bookmarks
                    Dim bookmarksElem As XmlElement = newDoc.CreateElement("Bookmarks")
                    newRoot.AppendChild(bookmarksElem)

                    'Add the properies fo the preview Map to the project file
                    Dim prevMap As XmlElement = newDoc.CreateElement("PreviewMap")
                    Dim visible As XmlAttribute = newDoc.CreateAttribute("Visible")
                    Dim dx As XmlAttribute = newDoc.CreateAttribute("dx")
                    Dim dy As XmlAttribute = newDoc.CreateAttribute("dy")
                    Dim xllcenter As XmlAttribute = newDoc.CreateAttribute("xllcenter")
                    Dim yllcenter As XmlAttribute = newDoc.CreateAttribute("yllcenter")
                    dx.InnerText = "0"
                    dy.InnerText = "0"
                    xllcenter.InnerText = "0"
                    yllcenter.InnerText = "0"
                    prevMap.Attributes.Append(dx)
                    prevMap.Attributes.Append(dy)
                    prevMap.Attributes.Append(xllcenter)
                    prevMap.Attributes.Append(yllcenter)
                    Dim image As XmlElement = newDoc.CreateElement("Image")
                    Dim type As XmlAttribute = newDoc.CreateAttribute("Type")
                    image.InnerText = ""
                    type.InnerText = ""
                    image.Attributes.Append(type)
                    prevMap.AppendChild(image)
                    'add the elements to the prevMap
                    newRoot.AppendChild(prevMap)


                    'Save the project file.
                    MapWinUtility.Logger.Dbg("Saving Project: " + projectPath)
                    Try
                        newDoc.Save(projectPath)
                        Return True
                    Catch e As System.UnauthorizedAccessException
                        Dim ro As Boolean = False
                        If System.IO.File.Exists(projectPath) Then
                            Dim fi As New System.IO.FileInfo(projectPath)
                            If fi.IsReadOnly Then ro = True
                        End If
                        If ro Then
                            MapWinUtility.Logger.Msg("The project file could not be saved because it is read-only." + Environment.NewLine + Environment.NewLine + "Please have your system administrator grant write access to the file:" + Environment.NewLine + projectPath, MsgBoxStyle.Exclamation, "Read-Only File")
                        Else
                            MapWinUtility.Logger.Msg("The project file could not be saved due to insufficient access." + Environment.NewLine + Environment.NewLine + "Please have your system administrator grant access to the file:" + Environment.NewLine + projectPath, MsgBoxStyle.Exclamation, "Insufficient Access")
                        End If
                        Return False
                    End Try

                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End If

        Return True
    End Function

    Private Sub TranslateLegacyVWRLayers(ByRef oldDoc As XmlDocument, ByRef oldRoot As XmlElement, ByRef newDoc As XmlDocument, ByRef newRoot As XmlElement, ByVal projectPath As String, ByVal projection As String, ByVal extents As MapWinGIS.Extents)
        Dim newGroups As XmlElement = newDoc.CreateElement("Groups")

        If Not oldRoot.Item("Groups") Is Nothing Then
            Dim oldGroups As XmlElement = oldRoot.Item("Groups")
            For Each oldgroup As XmlElement In oldGroups
                Dim newGroup As XmlElement = newDoc.CreateElement("Group")
                Dim gName As XmlAttribute = newDoc.CreateAttribute("Name")
                Dim gExpanded As XmlAttribute = newDoc.CreateAttribute("Expanded")
                Dim Position As XmlAttribute = newDoc.CreateAttribute("Position")

                Try
                    gName.InnerText = oldgroup.Attributes("Name").InnerText
                Catch ex As Exception
                End Try
                Try
                    gExpanded.InnerText = oldgroup.Attributes("Expanded").InnerText
                Catch ex As Exception
                End Try
                Try
                    Position.InnerText = oldgroup.Attributes("Position").InnerText
                Catch ex As Exception
                End Try

                newGroup.Attributes.Append(gName)
                newGroup.Attributes.Append(gExpanded)
                newGroup.Attributes.Append(Position)
                Dim image As XmlElement = newDoc.CreateElement("Image")
                Dim itype As XmlAttribute = newDoc.CreateAttribute("Type")
                image.Attributes.Append(itype)
                newGroup.AppendChild(image)

                If (Not oldgroup.Item("Layers") Is Nothing) Then
                    Dim newLayers As XmlElement = newDoc.CreateElement("Layers")
                    For Each oldLayer As XmlElement In oldgroup.Item("Layers")
                        Dim newlayer As XmlElement = newDoc.CreateElement("Layer")
                        Dim name As XmlAttribute = newDoc.CreateAttribute("Name")
                        Dim groupname As XmlAttribute = newDoc.CreateAttribute("GroupName")
                        Dim type As XmlAttribute = newDoc.CreateAttribute("Type")
                        Dim path As XmlAttribute = newDoc.CreateAttribute("Path")
                        Dim tag As XmlAttribute = newDoc.CreateAttribute("Tag")
                        Dim legPic As XmlAttribute = newDoc.CreateAttribute("LegendPicture")
                        Dim visible As XmlAttribute = newDoc.CreateAttribute("Visible")
                        Dim labelsVisible As XmlAttribute = newDoc.CreateAttribute("LabelsVisible")
                        Dim expanded As XmlAttribute = newDoc.CreateAttribute("Expanded")

                        Try
                            '---Cho 3/3/2009: shapefileAlias has the layer name displayed in TOC.
                            If Not oldLayer.Item("ShapeFileProperties") Is Nothing AndAlso oldLayer.Item("ShapeFileProperties").Attributes("shapefileAlias").InnerText <> "0" Then
                                name.InnerText = oldLayer.Item("ShapeFileProperties").Attributes("shapefileAlias").InnerText
                            Else
                                name.InnerText = oldLayer.Attributes("Name").InnerText
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            groupname.InnerText = gName.InnerText
                        Catch ex As Exception
                        End Try
                        Try
                            type.InnerText = oldLayer.Attributes("Type").InnerText
                        Catch ex As Exception
                        End Try
                        Try
                            path.InnerText = oldLayer.Attributes("Path").InnerText
                        Catch ex As Exception
                        End Try
                        Try
                            tag.InnerText = oldLayer.Attributes("Tag").InnerText
                        Catch ex As Exception
                        End Try
                        Try
                            visible.InnerText = oldLayer.Attributes("Visible").InnerText
                        Catch ex As Exception
                        End Try
                        Try
                            labelsVisible.InnerText = oldLayer.Attributes("LabelsVisible").InnerText
                        Catch ex As Exception
                            labelsVisible.InnerText = False.ToString
                        End Try
                        Try
                            expanded.InnerText = oldLayer.Attributes("Expanded").InnerText
                            If expanded.InnerText = "" Then
                                expanded.InnerText = False.ToString
                            End If
                        Catch ex As Exception
                            expanded.InnerText = False.ToString
                        End Try

                        newlayer.Attributes.Append(name)
                        newlayer.Attributes.Append(groupname)
                        newlayer.Attributes.Append(type)
                        newlayer.Attributes.Append(path)
                        newlayer.Attributes.Append(tag)
                        newlayer.Attributes.Append(legPic)
                        newlayer.Attributes.Append(visible)
                        newlayer.Attributes.Append(labelsVisible)
                        newlayer.Attributes.Append(expanded)

                        If labelsVisible.InnerText = "True" Then
                            TranslateLegacyVWRLabelElements(path.InnerText, oldLayer, projection, extents)
                        End If

                        'ARA 2/17/2009 It turns out the type isn't a layer type, but instead a shapefile type
                        ' and grids are never read by the legacy vwr, so only way to tell type is by extension.
                        'Dim typenum As MapWindow.Interfaces.eLayerType = type.InnerText
                        'If typenum = MapWindow.Interfaces.eLayerType.LineShapefile Or typenum = MapWindow.Interfaces.eLayerType.PointShapefile Or typenum = MapWindow.Interfaces.eLayerType.PolygonShapefile Then
                        Dim typenum As MapWinGIS.ShpfileType = type.InnerText
                        Dim lyrNum As Integer
                        If IO.Path.GetExtension(path.InnerText) = ".shp" Then
                            'if it is a shapfile then add the shape properties to the layer
                            TranslateLegacyVWRShapeFileElement(newDoc, newlayer, oldLayer, projectPath)
                            If typenum = MapWinGIS.ShpfileType.SHP_POINT Or typenum = MapWinGIS.ShpfileType.SHP_POINTM Or typenum = MapWinGIS.ShpfileType.SHP_POINTZ Or typenum = MapWinGIS.ShpfileType.SHP_MULTIPOINT Or typenum = MapWinGIS.ShpfileType.SHP_MULTIPOINTM Or typenum = MapWinGIS.ShpfileType.SHP_MULTIPOINTZ Then
                                lyrNum = Interfaces.eLayerType.PointShapefile
                                type.InnerText = lyrNum.ToString
                            ElseIf typenum = MapWinGIS.ShpfileType.SHP_POLYGON Or typenum = MapWinGIS.ShpfileType.SHP_POLYGONM Or typenum = MapWinGIS.ShpfileType.SHP_POLYGONZ Or typenum = MapWinGIS.ShpfileType.SHP_MULTIPATCH Then
                                lyrNum = Interfaces.eLayerType.PolygonShapefile
                                type.InnerText = lyrNum.ToString
                            ElseIf typenum = MapWinGIS.ShpfileType.SHP_POLYLINE Or typenum = MapWinGIS.ShpfileType.SHP_POLYLINEM Or typenum = MapWinGIS.ShpfileType.SHP_POLYLINEZ Then
                                lyrNum = Interfaces.eLayerType.LineShapefile
                                type.InnerText = lyrNum.ToString
                            End If
                        Else 'If typenum = MapWindow.Interfaces.eLayerType.Grid Or typenum = MapWindow.Interfaces.eLayerType.Image Then
                            'add the grid file properties
                            TranslateLegacyVWRGridElement(newDoc, newlayer, oldLayer)
                            lyrNum = Interfaces.eLayerType.Grid
                            type.InnerText = lyrNum.ToString
                        End If

                        'add DynamicVisibility options
                        Dim dynamicVisibility As XmlElement = newDoc.CreateElement("DynamicVisibility")
                        Dim useDynamicVisibility As XmlAttribute = newDoc.CreateAttribute("UseDynamicVisibility")
                        Dim xMin As XmlAttribute = newDoc.CreateAttribute("xMin")
                        Dim yMin As XmlAttribute = newDoc.CreateAttribute("yMin")
                        Dim xMax As XmlAttribute = newDoc.CreateAttribute("xMax")
                        Dim yMax As XmlAttribute = newDoc.CreateAttribute("yMax")
                        useDynamicVisibility.InnerText = False.ToString

                        xMin.InnerText = "0"
                        yMin.InnerText = "0"
                        xMax.InnerText = "0"
                        yMax.InnerText = "0"

                        dynamicVisibility.Attributes.Append(useDynamicVisibility)
                        dynamicVisibility.Attributes.Append(xMin)
                        dynamicVisibility.Attributes.Append(yMin)
                        dynamicVisibility.Attributes.Append(xMax)
                        dynamicVisibility.Attributes.Append(yMax)

                        newlayer.AppendChild(dynamicVisibility)

                        newLayers.AppendChild(newlayer)
                    Next
                    newGroup.AppendChild(newLayers)
                End If
                newGroups.AppendChild(newGroup)
            Next
        End If

        newRoot.AppendChild(newGroups)
    End Sub

    Private Sub TranslateLegacyVWRLabelElements(ByVal LayerFileName As String, ByRef oldLayer As XmlNode, ByVal projection As String, ByVal extents As MapWinGIS.Extents)
        Dim lblFileName = IO.Path.ChangeExtension(LayerFileName, ".lbl")

        If IO.File.Exists(lblFileName) Then
            IO.File.Move(lblFileName, lblFileName + ".bak")
            IO.File.Delete(lblFileName)
        End If

        Dim doc As New XmlDocument
        Dim root As XmlElement
        doc.LoadXml("<Mapwin version='" + System.Web.HttpUtility.UrlEncode(App.VersionString()) + "'></Mapwin>")
        root = doc.DocumentElement

        Dim Labels As XmlElement = doc.CreateElement("Labels")

        Dim AppendLine1 As XmlAttribute = doc.CreateAttribute("AppendLine1")
        Dim AppendLine2 As XmlAttribute = doc.CreateAttribute("AppendLine2")
        Dim PrependLine1 As XmlAttribute = doc.CreateAttribute("PrependLine1")
        Dim PrependLine2 As XmlAttribute = doc.CreateAttribute("PrependLine2")
        Dim Field As XmlAttribute = doc.CreateAttribute("Field")
        Dim Font As XmlAttribute = doc.CreateAttribute("Font")
        Dim Size As XmlAttribute = doc.CreateAttribute("Size")
        Dim Color As XmlAttribute = doc.CreateAttribute("Color")
        Dim Justification As XmlAttribute = doc.CreateAttribute("Justification")
        Dim UseMinZoomLevel As XmlAttribute = doc.CreateAttribute("UseMinZoomLevel")
        Dim Scaled As XmlAttribute = doc.CreateAttribute("Scaled")
        Dim UseShadows As XmlAttribute = doc.CreateAttribute("UseShadows")
        Dim ShadowColor As XmlAttribute = doc.CreateAttribute("ShadowColor")
        Dim Offset As XmlAttribute = doc.CreateAttribute("Offset")
        Dim StandardViewWidth As XmlAttribute = doc.CreateAttribute("StandardViewWidth")
        Dim UseLabelCollision As XmlAttribute = doc.CreateAttribute("UseLabelCollision")
        Dim RemoveDuplicateLabels As XmlAttribute = doc.CreateAttribute("RemoveDuplicateLabels")
        Dim xMin As XmlAttribute = doc.CreateAttribute("xMin")
        Dim yMin As XmlAttribute = doc.CreateAttribute("yMin")
        Dim xMax As XmlAttribute = doc.CreateAttribute("xMax")
        Dim yMax As XmlAttribute = doc.CreateAttribute("yMax")
        Dim rotationField As XmlAttribute = doc.CreateAttribute("RotationField")

        AppendLine1.InnerText = ""
        AppendLine2.InnerText = ""
        PrependLine1.InnerText = ""
        PrependLine2.InnerText = ""

        Font.InnerText = "Microsoft Sans Serif"
        Size.InnerText = "8.25"
        UseLabelCollision.InnerText = "True"
        StandardViewWidth.InnerText = "0"
        Scaled.InnerText = "False"

        Dim lScale, lblRotation, lblShadowR, lblShadowB, lblShadowG, lblColorR, lblColorG, lblColorB As Integer
        Dim lblFieldName As String
        Try
            lblFieldName = oldLayer.Attributes("fieldName").InnerText
        Catch ex As Exception
            lblFieldName = ""
        End Try

        Dim sf As New MapWinGIS.Shapefile
        sf.Open(LayerFileName)
        For i As Integer = 0 To sf.NumFields - 1
            If sf.Field(i).Name = lblFieldName Then
                Field.InnerText = (i + 1).ToString
                Exit For
            End If
        Next
        If Field.InnerText = "" Then
            Field.InnerText = "0"
        End If
        sf.Close()
        Try
            lblColorR = oldLayer.Attributes("colorRed").InnerText
        Catch ex As Exception
            lblColorR = 0
        End Try
        Try
            lblColorG = oldLayer.Attributes("colorGreen").InnerText
        Catch ex As Exception
            lblColorG = 0
        End Try
        Try
            lblColorB = oldLayer.Attributes("colorBlue").InnerText
        Catch ex As Exception
            lblColorB = 0
        End Try
        Color.InnerText = Convert.ToUInt32(RGB(lblColorR, lblColorG, lblColorB)).ToString

        Try
            Justification.InnerText = oldLayer.Attributes("tkhJustification").InnerText
        Catch ex As Exception
            Justification.InnerText = "0"
        End Try

        Try
            RemoveDuplicateLabels.InnerText = oldLayer.Attributes("uniqueValues").InnerText
        Catch ex As Exception
            RemoveDuplicateLabels.InnerText = "False"
        End Try

        Try
            UseShadows.InnerText = oldLayer.Attributes("UseShadows").InnerText
        Catch ex As Exception
            UseShadows.InnerText = "False"
        End Try

        Try
            lblShadowR = oldLayer.Attributes("ShadowR").InnerText
        Catch ex As Exception
            lblShadowR = 0
        End Try
        Try
            lblShadowG = oldLayer.Attributes("ShadowG").InnerText
        Catch ex As Exception
            lblShadowG = 0
        End Try
        Try
            lblShadowB = oldLayer.Attributes("ShadowB").InnerText
        Catch ex As Exception
            lblShadowB = 0
        End Try
        ShadowColor.InnerText = Convert.ToUInt32(RGB(lblShadowR, lblShadowG, lblShadowB)).ToString

        Try
            UseMinZoomLevel.InnerText = oldLayer.Attributes("addDynamicVisiblity").InnerText
        Catch ex As Exception
            UseMinZoomLevel.InnerText = "False"
        End Try

        Try
            xMin.InnerText = oldLayer.Attributes("lXMin").InnerText
        Catch ex As Exception
            xMin.InnerText = "0"
        End Try
        Try
            xMax.InnerText = oldLayer.Attributes("lXMax").InnerText
        Catch ex As Exception
            xMax.InnerText = "0"
        End Try
        Try
            yMin.InnerText = oldLayer.Attributes("lYMin").InnerText
        Catch ex As Exception
            yMin.InnerText = "0"
        End Try
        Try
            yMax.InnerText = oldLayer.Attributes("lYMax").InnerText
        Catch ex As Exception
            yMax.InnerText = "0"
        End Try

        Try
            lScale = oldLayer.Attributes("lScale").InnerText
        Catch ex As Exception
            lScale = 0
        End Try
        If lScale > 0 Then
            Dim centerPoint As New MapWinGIS.Point
            centerPoint.x = extents.xMin + ((extents.xMax - extents.xMin) / 2)
            centerPoint.y = extents.yMin + ((extents.yMax - extents.yMin) / 2)
            Dim MapWidth As Integer = frmMain.MapMain.Width
            Dim MapHeight As Integer = frmMain.MapMain.Height

            Dim mapUnits As String = ""
            'taken from clsProject.vb
            If Not projection = "" Then
                If InStr(projection.ToLower, "+proj=longlat") > 0 Or InStr(projection.ToLower, "+proj=latlong") > 0 Then
                    mapUnits = "Lat/Long"
                ElseIf InStr(projection.ToLower, "+units=m") > 0 Then
                    mapUnits = "Meters"
                ElseIf InStr(projection.ToLower, "+units=ft") > 0 Then
                    mapUnits = "Feet"
                ElseIf InStr(projection.ToLower, "+to_meter=") > 0 Then
                    '---Cho 1/20/2009: Support for feet.
                    Dim toMeter As Double
                    toMeter = Convert.ToDouble(System.Text.RegularExpressions.Regex.Replace(projection.ToLower, "^.*to_meter=([.0-9]+).*$", "$1"))
                    If toMeter > 0.3047 And toMeter < 0.3049 Then
                        mapUnits = "Feet"
                    End If
                End If
            End If

            Dim tmpExt As MapWinGIS.Extents
            tmpExt = MapWinGeoProc.ScaleTools.ExtentFromScale(lScale, centerPoint, mapUnits, MapWidth, MapHeight)

            If tmpExt.xMax <> 0 Then
                xMin.InnerText = tmpExt.xMin.ToString
                xMax.InnerText = tmpExt.xMax.ToString
                yMin.InnerText = tmpExt.yMin.ToString
                yMax.InnerText = tmpExt.yMax.ToString
            End If
        End If

        If xMin.InnerText = "" Then
            xMin.InnerText = "0"
        End If
        If xMax.InnerText = "" Then
            xMax.InnerText = "0"
        End If
        If yMin.InnerText = "" Then
            yMin.InnerText = "0"
        End If
        If yMax.InnerText = "" Then
            yMax.InnerText = "0"
        End If
        'TODO: Do something with rotation info
        Try
            rotationField.InnerText = oldLayer.Attributes("labelRotationFieldName").InnerText
        Catch ex As Exception
            rotationField.InnerText = "None"
        End Try
        Try
            lblRotation = oldLayer.Attributes("rotation").InnerText
        Catch ex As Exception
            lblRotation = 0
        End Try

        Labels.Attributes.Append(AppendLine1)
        Labels.Attributes.Append(AppendLine2)
        Labels.Attributes.Append(PrependLine1)
        Labels.Attributes.Append(PrependLine2)
        Labels.Attributes.Append(Field)
        Labels.Attributes.Append(Font)
        Labels.Attributes.Append(Size)
        Labels.Attributes.Append(Color)
        Labels.Attributes.Append(Justification)
        Labels.Attributes.Append(UseMinZoomLevel)
        Labels.Attributes.Append(Scaled)
        Labels.Attributes.Append(UseShadows)
        Labels.Attributes.Append(ShadowColor)
        Labels.Attributes.Append(Offset)
        Labels.Attributes.Append(StandardViewWidth)
        Labels.Attributes.Append(UseLabelCollision)
        Labels.Attributes.Append(RemoveDuplicateLabels)
        Labels.Attributes.Append(rotationField)
        Labels.Attributes.Append(xMin)
        Labels.Attributes.Append(yMin)
        Labels.Attributes.Append(xMax)
        Labels.Attributes.Append(yMax)

        root.AppendChild(Labels)
        doc.Save(lblFileName)
    End Sub

    Private Sub TranslateLegacyVWRShapeFileElement(ByRef newDoc As Xml.XmlDocument, ByRef newLayer As Xml.XmlNode, ByRef oldLayer As Xml.XmlNode, ByVal projectPath As String)
        Dim shpFileProp As XmlElement = newDoc.CreateElement("ShapeFileProperties")
        Dim color As XmlAttribute = newDoc.CreateAttribute("Color")
        Dim drawFill As XmlAttribute = newDoc.CreateAttribute("DrawFill")
        Dim transPercent As XmlAttribute = newDoc.CreateAttribute("TransparencyPercent")
        Dim fillStipple As XmlAttribute = newDoc.CreateAttribute("FillStipple")
        Dim lineOrPointSize As XmlAttribute = newDoc.CreateAttribute("LineOrPointSize")
        Dim lineStipple As XmlAttribute = newDoc.CreateAttribute("LineStipple")
        Dim outLineColor As XmlAttribute = newDoc.CreateAttribute("OutLineColor")
        Dim pointType As XmlAttribute = newDoc.CreateAttribute("PointType")
        Dim customFillStipple As XmlAttribute = newDoc.CreateAttribute("CustomFillStipple")
        Dim customLineStipple As XmlAttribute = newDoc.CreateAttribute("CustomLineStipple")
        Dim useTransparency As XmlAttribute = newDoc.CreateAttribute("UseTransparency")
        Dim transparencyColor As XmlAttribute = newDoc.CreateAttribute("TransparencyColor")
        Dim MapTooltipField As XmlAttribute = newDoc.CreateAttribute("MapTooltipField")
        Dim MapTooltipsEnabled As XmlAttribute = newDoc.CreateAttribute("MapTooltipsEnabled")
        Dim VertVisible As XmlAttribute = newDoc.CreateAttribute("VerticesVisible")
        Dim LabelsVisible As XmlAttribute = newDoc.CreateAttribute("LabelsVisible")
        Dim customPointType As XmlElement = newDoc.CreateElement("CustomPointType")

        If Not oldLayer.Item("ShapeFileProperties") Is Nothing Then
            With oldLayer.Item("ShapeFileProperties")
                Try
                    LabelsVisible.InnerText = oldLayer.Attributes("LabelsVisible").InnerText
                Catch ex As Exception
                End Try
                Try
                    Dim colorR, colorG, colorB As Integer
                    Try
                        colorR = .Attributes("ColorR").InnerText
                    Catch ex As Exception
                        colorR = 0
                    End Try
                    Try
                        colorG = .Attributes("ColorG").InnerText
                    Catch ex As Exception
                        colorG = 0
                    End Try
                    Try
                        colorB = .Attributes("ColorB").InnerText
                    Catch ex As Exception
                        colorB = 0
                    End Try
                    color.InnerText = Convert.ToUInt32(RGB(colorR, colorG, colorB)).ToString
                    outLineColor.InnerText = Convert.ToUInt32(RGB(colorR, colorG, colorB)).ToString
                Catch ex As Exception
                    color.InnerText = "0"
                    outLineColor.InnerText = "0"
                End Try


                Try
                    fillStipple.InnerText = .Attributes("FillStipple").InnerText
                Catch ex As Exception
                    fillStipple.InnerText = "0"
                End Try
                Try
                    lineOrPointSize.InnerText = .Attributes("LineOrPointSize").InnerText
                Catch ex As Exception
                    lineOrPointSize.InnerText = "1"
                End Try
                Try
                    lineStipple.InnerText = .Attributes("LineStipple").InnerText
                Catch ex As Exception
                    lineStipple.InnerText = "0"
                End Try
                Try
                    pointType.InnerText = .Attributes("PointType").InnerText
                Catch ex As Exception
                    pointType.InnerText = "0"
                End Try
                Try
                    transPercent.InnerText = .Attributes("TransparencyPercent").InnerText
                Catch ex As Exception
                    transPercent.InnerText = "0"
                End Try
                If transPercent.InnerText = "" Then
                    transPercent.InnerText = "0"
                End If
                Try
                    Dim numtype As MapWindow.Interfaces.eLayerType = oldLayer.Attributes("Type").InnerText
                    If numtype = MapWindow.Interfaces.eLayerType.PointShapefile Then
                        VertVisible.InnerText = True.ToString
                    Else
                        VertVisible.InnerText = False.ToString
                    End If

                    If numtype = MapWindow.Interfaces.eLayerType.PolygonShapefile Then
                        drawFill.InnerText = True.ToString
                    Else
                        drawFill.InnerText = False.ToString
                    End If
                Catch ex As Exception
                    VertVisible.InnerText = False.ToString
                    drawFill.InnerText = False.ToString
                End Try
                customLineStipple.InnerText = ""
                useTransparency.InnerText = False.ToString
                transparencyColor.InnerText = ""
                MapTooltipField.InnerText = ""
                MapTooltipsEnabled.InnerText = False.ToString
            End With
        End If

        shpFileProp.Attributes.Append(LabelsVisible)
        shpFileProp.Attributes.Append(MapTooltipField)
        shpFileProp.Attributes.Append(MapTooltipsEnabled)
        shpFileProp.Attributes.Append(VertVisible)
        shpFileProp.Attributes.Append(color)
        shpFileProp.Attributes.Append(drawFill)
        shpFileProp.Attributes.Append(transPercent)
        shpFileProp.Attributes.Append(fillStipple)
        shpFileProp.Attributes.Append(lineOrPointSize)
        shpFileProp.Attributes.Append(lineStipple)
        shpFileProp.Attributes.Append(outLineColor)
        shpFileProp.Attributes.Append(pointType)
        shpFileProp.Attributes.Append(customLineStipple)
        shpFileProp.Attributes.Append(useTransparency)
        shpFileProp.Attributes.Append(transparencyColor)

        Dim image As XmlElement = newDoc.CreateElement("Image")
        Dim itype As XmlAttribute = newDoc.CreateAttribute("Type")
        image.Attributes.Append(itype)
        customPointType.AppendChild(image)
        shpFileProp.AppendChild(customPointType)


        Dim leg As XmlElement = newDoc.CreateElement("Legend")
        Dim colorBreaks As XmlElement = newDoc.CreateElement("ColorBreaks")
        Dim fieldIndex As XmlAttribute = newDoc.CreateAttribute("FieldIndex")
        Dim key As XmlAttribute = newDoc.CreateAttribute("Key")
        Dim numBreaks As XmlAttribute = newDoc.CreateAttribute("NumberOfBreaks")

        If Not oldLayer.Item("ShapeFileColorProperties") Is Nothing Then
            With oldLayer.Item("ShapeFileColorProperties")
                'TODO: save shpColorProMarker
                Dim sfpath As String
                Try
                    sfpath = IO.Path.GetDirectoryName(projectPath) + IO.Path.DirectorySeparatorChar + IO.Path.GetFileName(oldLayer.Attributes("Path").InnerText)
                    Dim sf As New MapWinGIS.Shapefile
                    If sf.Open(sfpath) Then
                        Try
                            Dim fieldName As String = .Attributes("cFieldName").InnerText
                            For i As Integer = 0 To sf.NumFields - 1
                                If sf.Field(i).Name = fieldName Then
                                    fieldIndex.InnerText = i
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                        Finally
                            sf.Close()
                        End Try
                    End If
                Catch ex As Exception
                End Try


                key.InnerText = ""
                numBreaks.InnerText = .ChildNodes.Count.ToString

                For i As Integer = 0 To .ChildNodes.Count - 1
                    Dim break As XmlElement = newDoc.CreateElement("Break")
                    Dim endColor As XmlAttribute = newDoc.CreateAttribute("EndColor")
                    Dim endValue As XmlAttribute = newDoc.CreateAttribute("EndValue")
                    Dim startColor As XmlAttribute = newDoc.CreateAttribute("StartColor")
                    Dim StartValue As XmlAttribute = newDoc.CreateAttribute("StartValue")
                    Dim caption As XmlAttribute = newDoc.CreateAttribute("Caption")
                    Dim Visible As XmlAttribute = newDoc.CreateAttribute("Visible")

                    Try
                        startColor.InnerText = .ChildNodes(i).Attributes("colorVal").InnerText
                    Catch ex As Exception
                    End Try
                    Try
                        endColor.InnerText = .ChildNodes(i).Attributes("colorVal").InnerText
                    Catch ex As Exception
                    End Try
                    Try
                        StartValue.InnerText = .ChildNodes(i).Attributes("Value").InnerText
                    Catch ex As Exception
                    End Try
                    Try
                        endValue.InnerText = .ChildNodes(i).Attributes("Value").InnerText
                    Catch ex As Exception
                    End Try
                    Try
                        caption.InnerText = .ChildNodes(i).Attributes("TextVal").InnerText
                    Catch ex As Exception
                    End Try
                    If StartValue.InnerText = "(Blank / Empty)" Then
                        StartValue.InnerText = ""
                        endValue.InnerText = ""
                    End If

                    Dim breakTrans As String
                    Try
                        breaktrans = .ChildNodes(i).Attributes("TransPercent").InnerText
                    Catch ex As Exception
                        breakTrans = "0"
                    End Try
                    If breakTrans = "100" Then
                        Visible.InnerText = False.ToString
                    Else
                        Visible.InnerText = True.ToString
                    End If

                    break.Attributes.Append(startColor)
                    break.Attributes.Append(endColor)
                    break.Attributes.Append(StartValue)
                    break.Attributes.Append(endValue)
                    break.Attributes.Append(caption)
                    break.Attributes.Append(Visible)

                    colorBreaks.AppendChild(break)
                Next

                If .ChildNodes.Count > 0 Then
                    leg.Attributes.Append(fieldIndex)
                    leg.Attributes.Append(key)
                    leg.Attributes.Append(numBreaks)
                    leg.AppendChild(colorBreaks)

                    shpFileProp.AppendChild(leg)
                End If
            End With
        End If

        newLayer.AppendChild(shpFileProp)
    End Sub

    Private Sub TranslateLegacyVWRGridElement(ByRef newDoc As Xml.XmlDocument, ByRef newLayer As Xml.XmlNode, ByRef oldLayer As Xml.XmlNode)
        Dim grid As XmlElement = newDoc.CreateElement("GridProperty")
        Dim transparentColor As XmlAttribute = newDoc.CreateAttribute("TransparentColor")
        Dim useTransparency As XmlAttribute = newDoc.CreateAttribute("UseTransparency")

        Try
            transparentColor.InnerText = oldLayer.Item("GridProperty").Attributes("TransparentColor").InnerText
        Catch ex As Exception
        End Try

        Try
            useTransparency.InnerText = oldLayer.Item("GridProperty").Attributes("TransparentColor").InnerText
        Catch ex As Exception
        End Try

        grid.Attributes.Append(transparentColor)
        grid.Attributes.Append(useTransparency)

        newLayer.AppendChild(grid)
    End Sub
#End Region

#End Region

#Region "Utilities"

    Shared Sub SaveMainToolbarButtons()

        'Try
        'store the mapwindow default button items
        Dim item As Collections.DictionaryEntry
        Dim enumerator As Collections.IEnumerator = frmMain.m_Toolbar.m_Buttons.GetEnumerator
        While (enumerator.MoveNext)
            item = CType(enumerator.Current, Collections.DictionaryEntry)
            If (Not m_MainToolbarButtons.ContainsKey(item.Key)) Then
                m_MainToolbarButtons.Add(item.Key, item.Value)
            End If
        End While

        'store the mapwindow default bars items
        enumerator = frmMain.m_Toolbar.tbars.GetEnumerator
        While (enumerator.MoveNext)
            item = CType(enumerator.Current, Collections.DictionaryEntry)
            If (Not m_MainToolbarButtons.ContainsKey(item.Key)) Then
                m_MainToolbarButtons.Add(item.Key, item.Value)
            End If
        End While

        'store the mapwindow default menus items
        enumerator = frmMain.m_Menu.m_MenuTable.GetEnumerator
        While (enumerator.MoveNext)
            item = CType(enumerator.Current, Collections.DictionaryEntry)
            If (Not m_MainToolbarButtons.ContainsKey(item.Key)) Then
                m_MainToolbarButtons.Add(item.Key, item.Value)
            End If
        End While
        'Catch ex As Exception
        '  ShowError(ex)
        'End Try
    End Sub

    Private Function ConvertImageToString(ByVal img As Object, ByRef type As String) As String
        Dim s As String = ""
        Dim path As String = GetMWTempFile

        If Not img Is Nothing Then
            Try
                'find the type of image it is
                If TypeOf img Is Icon Then
                    type = "Icon"
                    Dim image As Icon = CType(img, Icon)

                    'write the image to a temp file
                    Dim outStream As IO.Stream = IO.File.OpenWrite(path)
                    image.Save(outStream)
                    outStream.Close()
                ElseIf TypeOf img Is stdole.IPictureDisp Then
                    type = "IPictureDisp"
                    Dim cvter As New MapWinUtility.ImageUtils
                    Dim image As Image = New Bitmap(cvter.IPictureDispToImage(img))

                    'save bitmap
                    image.Save(path)
                ElseIf TypeOf img Is Bitmap Then
                    type = "Bitmap"
                    Dim image As Image = CType(img, Bitmap)

                    'save bitmap
                    image.Save(path)
                Else
                    type = "Unknown"
                    Return ""
                End If

                'initialize the reader to read binary
                Dim inStream As IO.Stream = IO.File.OpenRead(path)
                Dim reader As New System.IO.BinaryReader(inStream)

                'read in each byte and convert it to a char
                Dim numbytes As Long = reader.BaseStream.Length
                s = System.Convert.ToBase64String(reader.ReadBytes(CInt(numbytes)))

                reader.Close()

                'delete the temp file
                System.IO.File.Delete(path)

                Return s
            Catch e As System.Exception
                m_ErrorMsg += "Error in ConvertImageToString(), Message: " + e.Message + Chr(13)
                m_ErrorOccured = True
                Return s
            End Try
        End If

        If (System.IO.File.Exists(path)) Then
            System.IO.File.Delete(path)
        End If

        Return s
    End Function

    Private Function ConvertStringToImage(ByVal image As String, ByVal type As String) As Object
        Dim icon As Icon
        Dim bmp As Bitmap
        Dim mybyte() As Byte
        Dim path As String
        Dim outStream As IO.Stream

        If Len(image) > 0 Then
            Try
                path = GetMWTempFile
                g_KillList.Add(path)

                outStream = IO.File.OpenWrite(path)

                mybyte = System.Convert.FromBase64String(image)
                'write the image to a temp file
                ' cdm - modernize: size = UBound(mybyte)
                ' cdm - modernize: For i = 0 To size
                outStream.Write(mybyte, 0, mybyte.Length)
                ' cdm - modernize: Next
                outStream.Close()

                'open the image
                Select Case type
                    Case "Icon"
                        icon = New Icon(path)
                        Return icon
                    Case "Bitmap"
                        bmp = New Bitmap(path)
                        Return bmp
                    Case "IPictureDisp"
                        bmp = New Bitmap(path)
                        Dim cvter As New MapWinUtility.ImageUtils
                        Return cvter.ImageToIPictureDisp(bmp)
                End Select

            Catch ex As System.Exception
                frmMain.ShowErrorDialog(ex)
            End Try
        End If

        Return Nothing
    End Function

    Public Function GetRelativePath(ByVal Filename As String, ByVal ProjectFile As String) As String
        GetRelativePath = ""
        Dim a() As String, b() As String
        Dim i As Integer, j As Integer, k As Integer, Offset As Integer

        If Len(Filename) = 0 Or Len(ProjectFile) = 0 Then
            Return ""
        End If

        Try
            'If the drive is different then use the full path
            If System.IO.Path.GetPathRoot(Filename).ToLower() <> System.IO.Path.GetPathRoot(ProjectFile).ToLower() Then
                GetRelativePath = Filename
                Exit Function
            End If
            Dim dirinfo As System.IO.DirectoryInfo ' use to tell when GetParent() fails
            '
            'load a()
            ReDim a(0)
            a(0) = Filename
            i = 0
            Do
                i = i + 1
                ReDim Preserve a(i)
                Try
                    dirinfo = System.IO.Directory.GetParent(a(i - 1))
                    If (dirinfo Is Nothing) Then
                        a(i) = ""
                    Else
                        a(i) = dirinfo.FullName.ToLower()
                    End If
                Catch ex As Exception
                    a(i) = ""
                End Try
            Loop Until a(i) = ""
            '
            'load b()
            ReDim b(0)
            b(0) = ProjectFile
            i = 0
            Do
                i = i + 1
                ReDim Preserve b(i)
                Try
                    dirinfo = System.IO.Directory.GetParent(b(i - 1))
                    If (dirinfo Is Nothing) Then
                        b(i) = ""
                    Else
                        b(i) = dirinfo.FullName.ToLower()
                    End If
                    ' b(i) = System.IO.Directory.GetParent(b(i - 1)).FullName.ToLower()
                Catch ex As Exception
                    b(i) = ""
                End Try
            Loop Until b(i) = ""
            '
            'look for match
            For i = 0 To UBound(a)
                For j = 0 To UBound(b)
                    If a(i) = b(j) Then
                        'found match
                        GoTo [CONTINUE]
                    End If
                Next j
            Next i
[CONTINUE]:
            ' j is num steps to get from BasePath to common path
            ' so I need this many of "..\"
            For k = 1 To j - 1
                GetRelativePath = GetRelativePath & "..\"
            Next k

            'everything past a(i) needs to be appended now.
            If a(i).EndsWith("\") Then
                Offset = 0
            Else
                Offset = 1
            End If
            GetRelativePath = GetRelativePath & Filename.Substring(Len(a(i)) + Offset)
        Catch e As System.Exception
            Return ""
        End Try
    End Function

    'Jiri Kadlec May/29/2008 this function compares the last time of creation or modification
    'of the two files. If file1 was changed more recently than file2, it returns 1.
    'If file2 was changed more recently than file1, it returns 2.
    'in other cases (one of files does not exist of time of modification is the same), return zero.
    Public Function CompareFilesByTime(ByVal file1 As String, ByVal file2 As String) As Integer
        If System.IO.File.Exists(file1) And System.IO.File.Exists(file2) Then
            Dim fi1 As New System.IO.FileInfo(file1)
            Dim fi2 As New System.IO.FileInfo(file2)

            Dim fi1Changed As DateTime = fi1.LastWriteTime
            If fi1.CreationTime > fi1Changed Then
                fi1Changed = fi1.CreationTime
            End If

            Dim fi2Changed As DateTime = fi2.LastWriteTime
            If fi2.CreationTime > fi2Changed Then
                fi2Changed = fi2.CreationTime
            End If

            If fi1Changed > fi2Changed Then
                Return 1
            Else
                Return -1
            End If
        End If
        'return zero if we cannot find out 
        Return 0
    End Function

    Private Function SaveLayer(ByVal layer As Object, ByVal handle As Integer, ByVal layerType As MapWindow.Interfaces.eLayerType) As String
        Dim cdlSave As New SaveFileDialog
        Dim fileName As String = ""

        Try

            'check to see if it is a shapefile
            If (layerType = Interfaces.eLayerType.LineShapefile _
             Or layerType = Interfaces.eLayerType.PointShapefile _
             Or layerType = Interfaces.eLayerType.PolygonShapefile) Then

                cdlSave.Filter = "Shapefile (*.shp)|*.shp"
                cdlSave.ShowDialog()
                fileName = Trim(cdlSave.FileName)

                If (fileName <> "") Then
                    DeleteShapeFile(fileName)
                    If (CType(layer, MapWinGIS.Shapefile).SaveAs(fileName) = False) Then
                        MapWinUtility.Logger.Msg("Failed to save Layer", MsgBoxStyle.Exclamation)
                    End If
                End If
                'check to see if it is a image
            ElseIf (layerType = Interfaces.eLayerType.Image) Then
                cdlSave.Filter = "Bitmap (*.bmp)| *.bmp| GIF (*.gif)| *.gif"
                cdlSave.ShowDialog()
                fileName = Trim(cdlSave.FileName)

                If (fileName <> "") Then
                    If (CType(layer, MapWinGIS.Image).Save(fileName) = False) Then
                        MapWinUtility.Logger.Msg("Failed to save Layer", MsgBoxStyle.Exclamation)
                    End If
                End If
                'check to see if it is a grid
            ElseIf (layerType = Interfaces.eLayerType.Grid) Then
                Dim grid As MapWinGIS.Grid
                cdlSave.Filter = "Binary (*.bgd)| *.bgd|Ascii (*.asc)|*.asc"
                cdlSave.ShowDialog()
                fileName = Trim(cdlSave.FileName)

                If (fileName <> "") Then
                    grid = frmMain.Layers(handle).GetGridObject()
                    If (grid.Save(fileName) = False) Then
                        MapWinUtility.Logger.Msg("Failed to save Layer, Message: " + grid.ErrorMsg(grid.LastErrorCode), MsgBoxStyle.Exclamation)
                    End If
                End If

            End If
        Catch ex As System.Exception
            ShowError(ex)
        End Try

        Return fileName
    End Function

    Public Sub DeleteShapeFile(ByVal fileName As String)
        'Function for deleting a shapefile with its three pieces.
        Dim f1, f2, f3 As String

        f1 = System.IO.Path.ChangeExtension(fileName, ".shp")
        f2 = System.IO.Path.ChangeExtension(fileName, ".shx")
        f3 = System.IO.Path.ChangeExtension(fileName, ".dbf")

        If System.IO.File.Exists(f1) Then System.IO.File.Delete(f1)
        If System.IO.File.Exists(f2) Then System.IO.File.Delete(f2)
        If System.IO.File.Exists(f3) Then System.IO.File.Delete(f3)
    End Sub

    Public Sub RestorePreviewMap(ByRef image As MapWinGIS.Image)
        Try
            'lock the preview map 
            frmMain.MapPreview.LockWindow(MapWinGIS.tkLockMode.lmLock)

            frmMain.MapPreview.RemoveAllLayers()
            frmMain.MapPreview.AddLayer(image, True)
            frmMain.MapPreview.ExtentPad = 0
            frmMain.MapPreview.ZoomToMaxExtents()
            frmMain.m_PreviewMap.m_ShowLocatorBox = True
            frmMain.m_PreviewMap.UpdateLocatorBox()

            'unlock the preview map
            frmMain.MapPreview.LockWindow(MapWinGIS.tkLockMode.lmUnlock)

        Catch ex As Exception
            frmMain.MapPreview.LockWindow(MapWinGIS.tkLockMode.lmUnlock)
            g_error = ex.Message
            ShowError(ex)
        End Try
    End Sub

    Private Sub AddToRecentProjects(ByVal ProjectName As String)
        Try
            'Remove any recent project names that match this one
            Dim NewNameLower As String = ProjectName.ToLower
            Dim iRecent As Integer = ProjInfo.RecentProjects.Count - 1
            While iRecent >= 0
                If CStr(ProjInfo.RecentProjects.Item(iRecent)).ToLower = NewNameLower Then
                    ProjInfo.RecentProjects.RemoveAt(iRecent)
                End If
                iRecent -= 1
            End While

            'Add this name to the start of the list
            ProjInfo.RecentProjects.Insert(0, ProjectName)

            'Make sure the list doesn't get longer than 10 items
            If (ProjInfo.RecentProjects.Count > 10) Then
                ProjInfo.RecentProjects.RemoveAt(ProjInfo.RecentProjects.Count - 1)
            End If
            frmMain.BuildRecentProjectsMenu()
        Catch ex As System.Exception
            ShowError(ex)
        End Try
    End Sub

#End Region

    Public Function GetSplashInfo() As Boolean
        'This is a new function in version 4.  It loads just enough of the project and config
        'file info to determine what to do about the splash screen.
        Dim Doc As XmlDocument
        Dim Root As XmlElement
        Dim TempPath As String

        If ProjectFileName.Length > 0 Then
            If System.IO.File.Exists(ProjectFileName) Then
                Doc = New XmlDocument
                Doc.Load(ProjectFileName)
                Root = Doc.DocumentElement
                ConfigFileName = Root.Attributes("ConfigurationPath").InnerText
            Else
                ProjectFileName = ""
            End If
        End If
        If ConfigFileName = "" Then
            'ConfigFileName = App.Path & "\default.mwcfg"
            ConfigFileName = Me.UserConfigFile '5/10/2008 changed by jk
        End If
        'convert from relative path to full path
        TempPath = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(ProjectFileName) & "\" & ConfigFileName)
        If System.IO.File.Exists(TempPath) Then
            'it exists so load just the needed appinfo stuff
            ConfigFileName = TempPath
            Doc = New XmlDocument
            Doc.Load(ConfigFileName)
            Root = Doc.DocumentElement
            LoadAppInfo(Root.Item("AppInfo"))
        Else
            Return False    'this is the worst case scenario in which we can't find the default.mwcfg file
        End If
        If AppInfo.SplashPicture Is Nothing Then
            Dim img As New Drawing.Bitmap(Me.GetType, "splash screen.bmp")
            AppInfo.SplashPicture = img
        End If
    End Function

    ' Chris Michaelis July 21 2005 - Used to let the user browse for a missing layer when loading a project.
    Private Function PromptToBrowse(ByRef filePath As String, ByVal displayName As String) As Boolean
        'If user cancelled one of these prompts less than a minute ago, skip prompting for this layer
        'Avoids asking user about every layer when several layer files are missing and all should be dropped
        If (Now.ToOADate - m_CancelledPromptToBrowse) * 1440 < 1 Then ' 1440 minutes per day
            Return False
        End If

        Dim rslt As MsgBoxResult = MapWinUtility.Logger.Msg("One of the layers in the project was not found. The file that couldn't be located is:" _
            + vbCrLf + vbCrLf + filePath + CType(IIf(displayName = "", "", " (" + displayName + ")"), String) _
            + vbCrLf + vbCrLf + "Would you like to locate this file?" _
            + vbCrLf + "No will simply drop the layer from the project, Cancel will drop all missing layers.", _
            MsgBoxStyle.YesNoCancel, "Missing Layer" + CType(IIf(displayName = "", "", " - " + displayName), String))

        Select Case rslt
            Case MsgBoxResult.No
                Return False
            Case MsgBoxResult.Cancel
                m_CancelledPromptToBrowse = Now.ToOADate
                Return False
            Case MsgBoxResult.Yes
                Dim cdlOpen As New OpenFileDialog

                'set the default dir
                If (System.IO.Directory.Exists(AppInfo.DefaultDir)) Then
                    cdlOpen.InitialDirectory = AppInfo.DefaultDir
                End If

                cdlOpen.FileName = ""
                cdlOpen.Title = "Locate Map Layer"
                cdlOpen.Filter = (New Layers).GetSupportedFormats()

                cdlOpen.CheckFileExists = True
                cdlOpen.CheckPathExists = True
                cdlOpen.Multiselect = False
                cdlOpen.ShowReadOnly = False

                ' Default to the missing filename
                cdlOpen.FileName = System.IO.Path.GetFileName(filePath)

                If Not cdlOpen.ShowDialog() = DialogResult.Cancel Then
                    filePath = cdlOpen.FileName
                Else
                    Return False 'Cancelled
                End If
        End Select
        Return True
    End Function
End Class
