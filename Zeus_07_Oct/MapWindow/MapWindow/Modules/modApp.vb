Module App
    Friend ReadOnly Property Path() As String
        Get
            Dim tStr As String = System.Windows.Forms.Application.ExecutablePath
            Return Left(tStr, tStr.LastIndexOf("\"))
        End Get
    End Property

    Friend ReadOnly Property Major() As Integer
        Get
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart
        End Get
    End Property

    Friend ReadOnly Property Minor() As Integer
        Get
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart
        End Get
    End Property

    Friend ReadOnly Property Revision() As Integer
        Get
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
        End Get
    End Property

    Friend ReadOnly Property VersionString() As String
        Get
            Dim vi As System.Diagnostics.FileVersionInfo
            vi = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location)
            Return vi.FileMajorPart & "." & vi.FileMinorPart & "." & vi.FileBuildPart

        End Get
    End Property

End Module
