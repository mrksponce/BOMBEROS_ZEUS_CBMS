'********************************************************************************************************
'File Name: clsAppInfo.vb
'Description: Friend class stores variables associated with the current MapWindow configuration.  
'These variables provide customization for the MapWindow Application interface.   
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
'1/1/2005 - dpa - Updated 
'19/9/2005 - Lailin Chen - Changed the default path
'3/31/2008 - Jiri Kadlec - Added 'OverrideSystemLocale' and 'CustomLocale' properties
'5/10/2008 - Jiri kadlec - Added 'DefaultViewBackColor' property
'********************************************************************************************************

Friend Class cAppInfo

    Implements MapWindow.Interfaces.AppInfo

    Public Name As String
    Public Version As String
    Public BuildDate As String
    Public Developer As String
    Public Comments As String
    Public HelpFilePath As String
    Public WelcomePlugin As String
    Public SplashPicture As Image
    Public FormIcon As Icon
    Public SplashTime As Double
    Public DefaultDir As String
    Public URL As String
    Public ApplicationPluginDir As String
    Public ShowWelcomeScreen As Boolean
    Public NeverShowProjectionDialog As Boolean
    Public ProjectionDialog_PreviousNoProjAnswer As String
    Public ProjectionDialog_PreviousMismatchAnswer As String
    Public LoadTIFFandIMGasgrid As GeoTIFFAndImgBehavior = GeoTIFFAndImgBehavior.Automatic ' Default=auto
    Public LoadESRIAsGrid As ESRIBehavior = ESRIBehavior.LoadAsGrid
    Public MouseWheelZoom As MouseWheelZoomDir = MouseWheelZoomDir.WheelUpZoomsIn
    Public LogfilePath As String = ""
    Public LabelsUseProjectLevel As Boolean

    'Default map background color - added by jk 5/10/2008
    Public DefaultBackColor As Color = Color.FromArgb(0, 255, 255, 255)

    'User-defined Language Settings (added by jk 3/31/2008)
    Public OverrideSystemLocale As Boolean = False
    Public Locale As String = String.Empty

    'Distance Measuring Stuff:
    Public MeasuringCurrently As Boolean
    Public MeasuringStartX As Double
    Public MeasuringStartY As Double
    Public MeasuringScreenPointStart As System.Drawing.Point
    Public MeasuringScreenPointFinish As System.Drawing.Point
    Public MeasuringTotalDistance As Double
    Public MeasuringDrawing As Integer
    Public MeasuringPreviousSegments As ArrayList

    'Area Measuring Stuff:
    Public AreaMeasuringCurrently As Boolean
    Public AreaMeasuringlstDrawPoints As New ArrayList
    Public AreaMeasuringReversibleDrawn As New ArrayList
    Public AreaMeasuringLastStartPtX As Double = -1
    Public AreaMeasuringLastStartPtY As Double = -1
    Public AreaMeasuringStartPtX As Double = -1
    Public AreaMeasuringStartPtY As Double = -1
    Public AreaMeasuringLastEndX As Double = -1
    Public AreaMeasuringLastEndY As Double = -1
    Public AreaMeasuringEraseLast As Boolean = False
    Public AreaMeasuringmycolor As New System.Drawing.Color

    'Dynamic visibility application properties 12/10/2008 ARA
    Public ShowDynamicVisibilityWarnings As Boolean = True
    Public ShowLayerAfterDynamicVisibility As Boolean = True

    Public Sub New()
        'Initialization function to provide initital values to the 
        'key application variables
        Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(Me.GetType).Location)
        Name = "MapWindow GIS"
        Version = App.VersionString
        ApplicationPluginDir = App.Path + "\" + "ApplicationPlugins"
        Developer = "MapWindow GIS Team"
        SplashTime = 2
        URL = "http://www.MapWindow.org"
        ShowWelcomeScreen = True
        HelpFilePath = path & "\help\MapWindow.chm"
        DefaultDir = path 'Changed by Lailin Chen
        NeverShowProjectionDialog = False ' Default value
        ProjectionDialog_PreviousNoProjAnswer = ""
        ProjectionDialog_PreviousMismatchAnswer = ""

        OverrideSystemLocale = False
        Locale = String.Empty
    End Sub

    Public Property DefaultDir1() As String Implements Interfaces.AppInfo.DefaultDir
        Get
            Return DefaultDir
        End Get
        Set(ByVal Value As String)
            DefaultDir = Value
        End Set
    End Property

    Public Property FormIcon1() As System.Drawing.Icon Implements Interfaces.AppInfo.FormIcon
        Get
            Return FormIcon
        End Get
        Set(ByVal Value As System.Drawing.Icon)
            FormIcon = Value
        End Set
    End Property

    Public Property HelpFilePath1() As String Implements Interfaces.AppInfo.HelpFilePath
        Get
            Return HelpFilePath
        End Get
        Set(ByVal Value As String)
            HelpFilePath = Value
        End Set
    End Property

    Public Property ShowWelcomeScreen1() As Boolean Implements Interfaces.AppInfo.ShowWelcomeScreen
        Get
            Return ShowWelcomeScreen
        End Get
        Set(ByVal Value As Boolean)
            ShowWelcomeScreen = Value
        End Set
    End Property
    Public Property ShowWelcomeScreen2() As Boolean Implements Interfaces.AppInfo.UseSplashScreen
        Get
            Return ShowWelcomeScreen
        End Get
        Set(ByVal Value As Boolean)
            ShowWelcomeScreen = Value
        End Set
    End Property

    Public Property SplashPicture1() As System.Drawing.Image Implements Interfaces.AppInfo.SplashPicture
        Get
            Return SplashPicture
        End Get
        Set(ByVal Value As System.Drawing.Image)
            SplashPicture = Value
        End Set
    End Property

    Public Property SplashTime1() As Double Implements Interfaces.AppInfo.SplashTime
        Get
            Return SplashTime
        End Get
        Set(ByVal Value As Double)
            SplashTime = Value
        End Set
    End Property

    Public Property URL1() As String Implements Interfaces.AppInfo.URL
        Get
            Return URL
        End Get
        Set(ByVal Value As String)
            URL = Value
        End Set
    End Property

    Public Property WelcomePlugin1() As String Implements Interfaces.AppInfo.WelcomePlugin
        Get
            Return WelcomePlugin
        End Get
        Set(ByVal Value As String)
            WelcomePlugin = Value
        End Set
    End Property

    Public Property ApplicationName() As String Implements Interfaces.AppInfo.ApplicationName
        Get
            Return Name
        End Get
        Set(ByVal Value As String)
            Name = Value
        End Set
    End Property
End Class
