'********************************************************************************************************
'File Name: modMain.vb
'Description: Entry point for MapWindow
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
'1/12/2005 - new entry point for MapWindow (dpa)
'1/31/2005 - minor modifications. (dpa)
'2/2/2005  - commented out redundant call to frmMain.InitializeVars() in LoadMainForm (jlk)
'2/3/2005  - moved display of WelcomeScreen (jlk)
'7/29/2005 - added a exception handler class(Lailin Chen)
'7/29/2005 - added a event handler to the Application object to handle uncaught exceptions(Lailin Chen)
'9/22/2005 - added function to send welcome screen message to a configured plug-in
'12/21/2005 - Added ability to load a layer from the command line. (cdm)
'2/18/2008 - minor modifications (lcw)
'2/18/08 - referenced newest version of library (2.2.x); global changes to method references required (lcw)
'3/31/2008 - added ability to load language settings from the configuration file (Jiri kadlec)
'08/5/2008 - changed the default location of configuration files, moved language settings to a separate
'             file, moved initialization of the Script form after the LoadCulture() function (jk)
'26/5/2008 - Fixed configuration file reading behavior (jk)
'********************************************************************************************************

Imports System.Threading

Module modMain
    'Global friend variables go here...
    Friend frmMain As MapWindowForm
    Friend ProjInfo As New XmlProjectFile   'stores info about the current MapWindow project
    Friend AppInfo As New cAppInfo          'stores info about the current MapWindow configuration 
    Friend Scripts As frmScript             'the Scripts form is initialized after executing LoadCulture()
    Public g_error As String 'Last error message
    Public g_ShowDetailedErrors As Boolean = True
    Public g_KillList As New ArrayList()
    Friend g_SyncPluginMenuDefer As Boolean = False

    '1/12/2005 dpa - New entry point for MapWindow
    Public Sub Main()
        ' Creates an instance of the methods that will handle the exception.
        Dim eh As CustomExceptionHandler = New CustomExceptionHandler
        '7/29/2005 - added a event handler to the Application object to handle uncaught exceptions(Lailin Chen)
        ' Adds the event handler to the event.
        AddHandler Application.ThreadException, AddressOf eh.OnThreadException
        'Chris M 11/11/2006 - Please leave thread exception handler at very
        'beginning, so users won't get "Send to Microsoft" ugli crashes when
        'missing DLLs etc

        'moved by LCW 2/18/08--according to MS must be at beginning of Main--fixes problems with appearance of main form until resized
        Try
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
        Catch
        End Try

        'Support a /resettodefaults command line for a start menu item that the 4.3 (and up)
        'installer will create, useful if things get corrupt or if upgrading from a prior config version that's acting funny.
        'Note that just deleting them is fine - they'll be rewritten with defaults on the next run.
        If Microsoft.VisualBasic.Command().ToLower().Contains("/resettodefaults") Then
            Try
                If System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\default.mwcfg") Then
                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\default.mwcfg")
                End If
            Catch
            End Try
            Try
                If System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\MapWindowDock.config") Then
                    System.IO.File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\MapWindowDock.config")
                End If
            Catch
            End Try
            '5/7/2008 jk -- new location of default configuration file is in the "Application Data" directory
            Try
                Dim configFilePath As String = System.IO.Path.Combine(XmlProjectFile.GetApplicationDataDir(), "default.mwcfg")
                If System.IO.File.Exists(configFilePath) Then
                    System.IO.File.Delete(configFilePath)
                End If
            Catch
            End Try
            Try
                Dim dockFilePath As String = System.IO.Path.Combine(XmlProjectFile.GetApplicationDataDir(), "MapWindowDock.config")
                If System.IO.File.Exists(dockFilePath) Then
                    System.IO.File.Delete(dockFilePath)
                End If
            Catch
            End Try

            MapWinUtility.Logger.Msg("MapWindow defaults have been restored.", MsgBoxStyle.Information, "Defaults Restored")
            End
        End If

        MapWinUtility.Logger.ProgressStatus = New MWProgressStatus

        '08/09/2006 Chris Michaelis -- Fire off a thread to ensure that the
        'proj datum shift files are present and set as an environment variable.
        Try
            Dim projnadCheck As New Thread(AddressOf CheckPROJNAD)
            projnadCheck.Start()
        Catch
        End Try

        '3/30/2008 added by Jiri Kadlec
        'load regional and language settings
        'use the Language settings (Culture) specified in the configuration file if specified by the user
        LoadCulture()

        '5/08/2008 jk: frmScript must be initialized after loading the language settings in order
        'to display the translated version
        Scripts = New frmScript

        Dim broadcastCmdLine As Boolean = False
        'Run any config command line
        RunConfigCommandLine(broadcastCmdLine)

        '2/18/08 lcw: following appears to be unreferenced throughout solution--delete it???
        '5/10/08 jk: deleted the reference to frmSplash
        'Dim frmSplash As New SplashScreenForm

        'Note that with version 4, no initialization happens yet.
        'There used to be a bunch of stuff in the constructor which made
        'it take several seconds just to get to the splash screen.
        frmMain = New MapWindowForm

        LoadMainForm()

        LoadConfig()

        'Determine whether or not to show the welcome screen
        'if the app was started with a project then don't show the welcome screen.
        If (AppInfo.ShowWelcomeScreen And Not broadcastCmdLine) Then
            ShowWelcomeScreen()
        End If

        'If there was a project file, extract it into the projinfo object.
        'This will also handle loading of shapefiles.
        Dim broadcastCmdLine_2 As Boolean = False
        RunProjectCommandLine(Microsoft.VisualBasic.Command(), broadcastCmdLine_2)

        If broadcastCmdLine Or broadcastCmdLine_2 Then
            frmMain.Plugins.BroadcastMessage("COMMAND_LINE:" & Microsoft.VisualBasic.Command())
        End If

        'All is ready and done... so if a script is waiting to run, do it now.
        If Not Scripts.pFileName = "" Then
            Scripts.RunSavedScript()
        End If

        'following commented out by LCW 1/18/08 and moved to beginning of method per MS docs
        'this fixes bug reports about the form having to be resized before the visual styles apply correctly

        'Try
        '    Application.EnableVisualStyles()
        '    Application.SetCompatibleTextRenderingDefault(False)
        'Catch
        'End Try

        Try
            Application.Run(frmMain)
        Catch e As System.ObjectDisposedException
            'ignore, occurs when application.exit called 
        End Try

        RemoveHandler Application.ThreadException, AddressOf eh.OnThreadException

        'ANY CODE below this point will be executed when the application terminates.
        For Each s As String In g_KillList
            Try
                System.IO.File.Delete(s)
            Catch e As Exception
                Debug.WriteLine("Failed to delete temp file: " & s & " " & e.Message)
            End Try
        Next
        g_KillList.Clear()

        'Show a survey on the first run if the user has elected to take it.
        Try
            Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\MapWindow", True)
            If regKey.GetValue("ShowSurvey", "False") = "True" Then
                System.Diagnostics.Process.Start("http://www.MapWindow.org/EndFirstRunSurvey.php")
                regKey.DeleteValue("ShowSurvey")
            End If
        Catch e As Exception
            MapWinUtility.Logger.Dbg("DEBUG: " + e.ToString())
        End Try
    End Sub

    Public Sub ShowWelcomeScreen()
        'Chris M Jan 2 06 -- Also test to see if it's "".
        If Not AppInfo.WelcomePlugin Is Nothing AndAlso Not AppInfo.WelcomePlugin = "" And Not AppInfo.WelcomePlugin = "WelcomeScreen" Then
            frmMain.Plugins.BroadcastMessage("WELCOME_SCREEN")
        Else
            Dim welcomeScreen As New frmWelcomeScreen
            welcomeScreen.ShowDialog(frmMain)
        End If
    End Sub

    Public Function GetMWTempFile() As String
        'Ensure we have this in our kill list!
        Dim ret As String = System.IO.Path.GetTempFileName
        Try
            System.IO.File.Delete(ret) 'Frequently, GetMWTempFile() + ".jpg" etc - resulting in zero byte temp files
        Catch
        End Try
        g_KillList.Add(ret)
        Return ret
    End Function

    '08/09/2006 Chris Michaelis for the AquaTerra "striped" reprojection problem where
    'the proj_nad environment variable was missing. This ensures it will be set.
    Private Sub CheckPROJNAD()
        Dim basepath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

        If System.IO.File.Exists(basepath & "\setenv.exe") AndAlso System.IO.Directory.Exists(basepath & "\PROJ_NAD") Then
            Try
                Dim psi As New ProcessStartInfo
                psi.FileName = basepath & "\setenv.exe"
                psi.Arguments = "-a PROJ_LIB " & basepath & "\PROJ_NAD"
                psi.CreateNoWindow = True
                psi.WindowStyle = ProcessWindowStyle.Hidden
                Diagnostics.Process.Start(psi)
            Catch e As Exception
                MapWinUtility.Logger.Dbg("DEBUG: " + e.ToString())
            End Try

            ' Chris Michaelis 1/25/2007
            ' The SetEnv trick doesn't always work. Fall back on System.Environment also
            ' (System.Environment doesn't work sometimes; but the combo of the two seem to catch all cases)
            Try
                Environment.SetEnvironmentVariable("PROJ_LIB", basepath & "\PROJ_NAD", EnvironmentVariableTarget.Machine)
                Environment.SetEnvironmentVariable("PROJ_LIB", basepath & "\PROJ_NAD", EnvironmentVariableTarget.User)
                Environment.SetEnvironmentVariable("PROJ_LIB", basepath & "\PROJ_NAD", EnvironmentVariableTarget.Process)
            Catch e As Exception
                MapWinUtility.Logger.Dbg("DEBUG: " + e.ToString())
            End Try
        End If
    End Sub

    Public Sub ShowError(ByVal ex As System.Exception, Optional ByVal email As String = "")
        MapWinUtility.Logger.Dbg(ex.ToString())
        modMain.CustomExceptionHandler.SendNextToEmail = email
        modMain.CustomExceptionHandler.OnThreadException(ex)
    End Sub

    Public Sub RunProjectCommandLine(ByVal CommandLine As String, ByRef broadcastCmdLine As Boolean)
        'These two objects are used to get the list of supported formats in case the
        'parameter is a layer to add. cdm 12-21-2005
        Dim grd As New MapWinGIS.Grid
        Dim sf As New MapWinGIS.Shapefile
        Dim img As New MapWinGIS.Image

        'Used to get command line project or config file names.

        If Len(CommandLine) <> 0 Then
            'remove the quotes(") on both sides of the string if they exist
            CommandLine = CommandLine.Replace("""", "")

            'if it is a MapWindow file then open it
            Dim ext As String = System.IO.Path.GetExtension(CommandLine).ToLower()

            If ext = ".mwprj" Or ext = ".vwr" Then
                'First, however, ensure the current project has been saved if the
                'thing dragged was a project file.
                If Not frmMain.m_HasBeenSaved Or ProjInfo.Modified Then
                    If frmMain.PromptToSaveProject() = MsgBoxResult.Cancel Then
                        Exit Sub
                    End If
                End If

                AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(CommandLine)
                ProjInfo.ProjectFileName = CommandLine
                ProjInfo.LoadProject(CommandLine)
            ElseIf Not ext = "" And Not grd.CdlgFilter().IndexOf(ext) = -1 Then
                'This is a layer that's supported by our Grid object. cdm 12-21-2005
                AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(CommandLine)
                frmMain.SetModified(True)
                frmMain.m_layers.AddLayer(CommandLine, , , Layers.GetDefaultLayerVis())
            ElseIf Not ext = "" And Not sf.CdlgFilter().IndexOf(ext) = -1 Then
                'This is a layer that's supported by our Shapefile object. cdm 12-21-2005
                AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(CommandLine)
                frmMain.SetModified(True)
                frmMain.m_layers.AddLayer(CommandLine, , , Layers.GetDefaultLayerVis())
            ElseIf Not ext = "" And Not img.CdlgFilter().IndexOf(ext) = -1 Then
                'This is a layer that's supported by our Image object. cdm 4-19-2006
                AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(CommandLine)
                frmMain.SetModified(True)
                frmMain.m_layers.AddLayer(CommandLine, , , Layers.GetDefaultLayerVis())
            ElseIf ext = ".cs" Or ext = ".vb" Then
                'It's probably a script - run it. Do it later, though, so just set filename for now.
                AppInfo.DefaultDir = System.IO.Path.GetDirectoryName(CommandLine)
                Scripts.pFileName = CommandLine
            ElseIf ext = ".grd" Then
                'Warn the user.
                MapWinUtility.Logger.Msg("The file you've attempted to open, " + System.IO.Path.GetFileName(CommandLine) + ", could be either a surfer grid or an ESRI grid image." _
                + vbCrLf + vbCrLf + "If the former, please use the GIS Tools plug-in to convert the grid to a compatible format." + vbCrLf + "If the latter, please open the sta.adf file instead.", MsgBoxStyle.Information, "Grid Conversion Required")
            Else
                'Broadcast this cmdline message to all the plugins
                'But can not do it now because the frmMain still haven't initialized
                broadcastCmdLine = True
            End If
        End If

        'Set to nothing so that GC will do it's magic
        grd = Nothing
        sf = Nothing
    End Sub

    Private Sub RunConfigCommandLine(ByRef broadcastCmdLine As Boolean)
        'Used to get command line project or config file names.
        Dim S As String = Microsoft.VisualBasic.Command()
        If Len(S) <> 0 Then
            'remove the quotes(") on both sides of the string if they exist
            S = S.Replace("""", "")

            'if it is a MapWindow file then open it
            Dim ext As String = System.IO.Path.GetExtension(S).ToLower()

            If ext = ".mwcfg" Then
                ProjInfo.ConfigFileName = S
            Else
                'Broadcast this cmdline message to all the plugins
                'But can not do it now because the frmMain still haven't initialized
                broadcastCmdLine = True
            End If
        End If
    End Sub

    Private Sub LoadConfig()
        '26/5/2008 Jiri Kadlec -- The new search order for a configuration file is:
        ' 1) search for a configuration file path in the project file. If it exists, set ConfigFileName to 
        '    the path specified in the project file. This option is used when opening existing projects.
        '
        ' 2) if ConfigFileName is "default.mwcfg" in the MW executable directory, copy the content of 
        '    "default.mwcfg" to a new file "MapWindow.mwcfg" in "Documents and Settings\user\Application Data" 
        '    special folder And change ConfigFileName to "MapWindow.mwcfg".
        '
        ' 3) if a project file doesn't exist or if there is no configuration file path specified in the project
        '    file, search for a file "MapWindow.mwcfg" in "Documents and Settings\[user name]\Application Data" special folder.
        '    if "MapWindow.mwcfg" exists, set ConfigFileName to "MapWindow.mwcfg". This option is used when
        '    starting a new project.
        ' 4) if "MapWindow.mwcfg" doesn't exist, search for a file "default.mwcfg" in the MW executable directory
        '    and copy the content of "default.mwcfg" to "MapWindow.mwcfg".
        ' 5) Finally, compare the date of last modification of ConfigFileName and "default.mwcfg". If "default.mwcfg" is
        '    newer than ConfigFileName, overwrite ConfigFileName by the content of default.mwcfg. This option is used after
        '    a reinstallation of MapWindow.
        
        Dim DefaultConfigFileName As String = ProjInfo.DefaultConfigFile

        'Load the project file if there is one
        'The project file will indicate which config file to use.
        'the application config file will be automatically loaded when loading the project file.
        g_SyncPluginMenuDefer = True
        If Len(ProjInfo.ProjectFileName) > 0 Then
            'ProjInfo.LoadProject() function will automatically set the value of ConfigFileName.
            ProjInfo.LoadProject(ProjInfo.ProjectFileName)
        End If

        If Len(ProjInfo.ConfigFileName) = 0 Then
            ' A config file is not specified in the project - try to find or create a file "user.mwcfg" in
            ' "~\Application Data\MapWindow" special folder. This option is used when the user clicks 
            ' on MapWindow or when a new project is created (Jiri Kadlec 5/26/2008)

            ProjInfo.ConfigFileName = ProjInfo.UserConfigFile()

            'Create a new config file from the default configuration file
            If Not System.IO.File.Exists(ProjInfo.ConfigFileName) Then
                ProjInfo.CreateConfigFileFromDefault(ProjInfo.ConfigFileName)
            End If
        End If

        '5/26/2008 Jiri Kadlec
        'check if the file "default.mwcfg" in MW executable directory has been modified (by a new MapWindow installation). 
        'in that case, update the Configuration file with the content of default.mwcfg.
        If ProjInfo.CompareFilesByTime(DefaultConfigFileName, ProjInfo.ConfigFileName) > 0 Then        
            ProjInfo.CreateConfigFileFromDefault(ProjInfo.ConfigFileName)
        End If

        'ProjInfo.ConfigFileName has been set up - load the project configuration now
        If ProjInfo.ConfigLoaded = False Then
            ProjInfo.LoadConfig(True)
        End If

        g_SyncPluginMenuDefer = False
        frmMain.SynchPluginMenu()
    End Sub

    Public Sub LoadCulture()
        ' 30/3/2008 - added by Jiri Kadlec - load the locale (language and culture settings) 
        ' from the configuration file.
        Dim OverrideSystemLocale As Boolean = False
        Dim Locale As String = String.Empty

        Try
            'try loading the locale from the configuration file
            'this will work if there is a file mwLanguage.config in the application directory
            'if the file doesn't exist, the regional language settings is used.
            Dim configFileName As String = System.IO.Path.Combine(ProjInfo.GetApplicationDataDir(), "mwLanguage.config")
            If System.IO.File.Exists(configFileName) Then
                Dim doc As New Xml.XmlDocument()
                doc.Load(configFileName)
                Dim root As Xml.XmlElement = doc.DocumentElement
                Dim cultureXml As Xml.XmlElement = root.Item("Culture")
                If cultureXml.HasAttribute("OverrideSystemLocale") Then
                    Dim OverrideXml As Xml.XmlElement = root.Item("OverrideSystemLocale")
                    If cultureXml.HasAttribute("OverrideSystemLocale") Then
                        OverrideSystemLocale = Boolean.Parse(cultureXml.Attributes("OverrideSystemLocale").InnerText)
                        If (cultureXml.HasAttribute("Locale") And OverrideSystemLocale = True) Then
                            Locale = cultureXml.Attributes("Locale").InnerText
                        End If
                    End If
                End If
            End If
        Catch
            'non-critical, the default system locale will be used
        End Try

        Try
            If Locale <> String.Empty Then
                Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Locale)
                AppInfo.OverrideSystemLocale = True
                AppInfo.Locale = Locale
            Else
                'language not specified, use the system regional language settings
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture
                AppInfo.OverrideSystemLocale = False
                AppInfo.Locale = Thread.CurrentThread.CurrentUICulture.Name
            End If
        Catch ex As Exception
            MapWinUtility.Logger.Dbg("error setting user-specified culture: " & ex.Message)

            'in case of any exception, use the default windows regional and language settings
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture
        End Try
    End Sub

    Private Sub LoadMainForm()
        '3/16/2005 - dpa - modified so all menus are created dynamically at run-time.
        Dim loadPlugins As Boolean = True
        'Dim SplashScreen As New SplashScreenForm

        frmMain.Show()

        frmMain.Legend.Map = CType(frmMain.MapMain.GetOcx, MapWinGIS.Map)
        frmMain.MapPreview.DoubleBuffer = True
        frmMain.MapMain.SendMouseDown = True
        frmMain.MapMain.SendMouseMove = True
        frmMain.MapMain.SendMouseUp = True
        frmMain.MapMain.SendSelectBoxDrag = False
        frmMain.MapMain.SendSelectBoxFinal = True
        frmMain.m_View.SelectMethod = MapWinGIS.SelectMode.INTERSECTION

        'Put together the help menu item(s).
        'Chris Michaelis 12/22/2005
        'First: If the appinfo help file exists, display the "Contents" help item. This is to be
        'a custom help file defined in the configuration file.
        If (System.IO.File.Exists(AppInfo.HelpFilePath)) Then
            frmMain.m_Menu("mnuContents").Visible = True
        Else
            frmMain.m_Menu("mnuContents").Visible = False
        End If

        'Second: Add the menu item for the online documentation 
        'Checking for web connection can slow down startup, so just go ahead and show the menu item
        frmMain.m_Menu("mnuOnlineDocs").Visible = True

        ' If the offline documentation exists, add a menu item for that
        If (System.IO.File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) & "\OfflineDocs\index.html")) Then
            frmMain.m_Menu("mnuOfflineDocs").Visible = True
        Else
            frmMain.m_Menu("mnuOfflineDocs").Visible = False
        End If

        frmMain.Update()

        frmMain.SetModified(False)
        frmMain.m_HasBeenSaved = True

        'make sure all plugins are loaded in the plugin menu
        frmMain.SynchPluginMenu()
    End Sub

    'Chris Michaelis, Feb 22 2008 for bugzilla 778
    Public Sub SaveFormPosition(ByVal Fo As Form)
        Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\MapWindow4")
        If (Fo.Visible And Not Fo.WindowState = System.Windows.Forms.FormWindowState.Minimized And Fo.Location.X > -1 And Fo.Location.Y > -1 And Fo.Size.Width > 1 And Fo.Size.Height > 1) Then
            rk.SetValue(Fo.Name + "_x", Fo.Location.X)
            rk.SetValue(Fo.Name + "_y", Fo.Location.Y)
            rk.SetValue(Fo.Name + "_w", Fo.Size.Width)
            rk.SetValue(Fo.Name + "_h", Fo.Size.Height)
        End If
    End Sub
    'Chris Michaelis, Feb 22 2008 for bugzilla 778
    Public Sub LoadFormPosition(ByVal Fo As Form)
        Try
            Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\MapWindow4", False)
            If Not rk.GetValue(Fo.Name + "_x").ToString() = "" And Not rk.GetValue(Fo.Name + "_y").ToString() = "" And Not rk.GetValue(Fo.Name + "_w").ToString() = "" And Not rk.GetValue(Fo.Name + "_h").ToString() = "" Then
                Fo.Location = New System.Drawing.Point(Double.Parse(rk.GetValue(Fo.Name + "_x").ToString()), Double.Parse(rk.GetValue(Fo.Name + "_y").ToString()))
                Fo.Size = New System.Drawing.Size(Double.Parse(rk.GetValue(Fo.Name + "_w").ToString()), Double.Parse(rk.GetValue(Fo.Name + "_h").ToString()))
            End If
        Catch
            ' No key created yet -- will be created when the form is moved or resized
        End Try
    End Sub

    '7/29/2005 - added a exception handler class(Lailin Chen)
    'To handle all the uncaught exceptions.
    Public Class CustomExceptionHandler
        ' Used for the very next exception, then cleared (and returned to default)
        Public Shared SendNextToEmail As String = ""

        ' Handles the exception event.
        Public Shared Sub OnThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
            OnThreadException(t.Exception)
        End Sub

        Public Shared Sub OnThreadException(ByVal e As Exception)
            If e.Message.Contains("UnauthorizedAccessException") Then
                MapWinUtility.Logger.Msg("An Unauthorized Access error was generated. Please ensure you have access to all files you're trying to work with, and that the files aren't in use by other applications.", MsgBoxStyle.Exclamation, "Unauthorized Access Exception")
                SendNextToEmail = ""
                Exit Sub
            End If

            Try
                If Not ProjInfo.NoPromptToSendErrors Then
                    Dim errorBox As New ErrorDialog(e, SendNextToEmail)
                    errorBox.ShowDialog()
                Else
                    Dim errorBox As New ErrorDialogNoSend(e)
                    errorBox.ShowDialog()
                End If
            Catch ex As Exception
                Dim errorBox As New ErrorDialog(e, SendNextToEmail)
                errorBox.ShowDialog()
            Finally
                SendNextToEmail = ""
            End Try
        End Sub
    End Class

    Public Function StippleToString(ByVal stipple As MapWinGIS.tkFillStipple) As String
        Select Case stipple
            Case MapWinGIS.tkFillStipple.fsDiagonalDownLeft
                Return "Diagonal Down-Left"
            Case MapWinGIS.tkFillStipple.fsDiagonalDownRight
                Return "Dialgonal Down-Right"
            Case MapWinGIS.tkFillStipple.fsVerticalBars
                Return "Vertical"
            Case MapWinGIS.tkFillStipple.fsHorizontalBars
                Return "Horizontal"
            Case MapWinGIS.tkFillStipple.fsPolkaDot
                Return "Cross/Dot"
            Case Else 'MapWinGIS.tkFillStipple.fsNone, MapWinGIS.tkFillStipple.fsCustom
                Return "None"
        End Select
    End Function

    Public Function StringToStipple(ByVal str As String) As MapWinGIS.tkFillStipple
        Select Case str
            Case "Diagonal Down-Left"
                Return MapWinGIS.tkFillStipple.fsDiagonalDownLeft
            Case "Dialgonal Down-Right"
                Return MapWinGIS.tkFillStipple.fsDiagonalDownRight
            Case "Vertical"
                Return MapWinGIS.tkFillStipple.fsVerticalBars
            Case "Horizontal"
                Return MapWinGIS.tkFillStipple.fsHorizontalBars
            Case "Cross/Dot"
                Return MapWinGIS.tkFillStipple.fsPolkaDot
            Case Else
                Return MapWinGIS.tkFillStipple.fsNone
        End Select
    End Function

    Public Sub FindSafeWindowLocation(ByRef W As Integer, ByRef H As Integer, ByRef Location As Point)
        Dim Index, UpperBound As Int16
        Dim maxw, maxh As Int16

        'Gets an array of all the screens connected to the system.
        Dim Screens() As System.Windows.Forms.Screen = System.Windows.Forms.Screen.AllScreens
        UpperBound = Screens.GetUpperBound(0)

        For Index = 0 To UpperBound
            With Screens(Index).WorkingArea
                maxw = Math.Max(maxw, .Right)
                maxh = Math.Max(maxh, .Bottom)
            End With
        Next

        If Location.X + W > maxw Then Location.X = maxw - W
        Location.X = Math.Max(0, Location.X)
        If Location.Y + H > maxh Then Location.Y = maxh - H
        Location.Y = Math.Max(0, Location.Y)
    End Sub
End Module
