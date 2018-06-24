Imports System.Windows.Forms.Design

Friend Class DynamicVisibilityControl
    Inherits System.Windows.Forms.UserControl

    Private m_Provider As IWindowsFormsEditorService
    Private m_handle As Integer

    Public retval As Boolean

    Public Sub New(ByVal DialogProvider As IWindowsFormsEditorService, ByVal LayerHandle As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_Provider = DialogProvider
        m_handle = LayerHandle
        If Not frmMain.m_AutoVis(m_handle) Is Nothing Then
            retval = frmMain.m_AutoVis(m_handle).UseDynamicExtents
        Else
            chkUseDynamicVisibility.Enabled = False
            btnGrabExtents.Text = "Set New Dynamic Extents"
        End If
        chkUseDynamicVisibility.Checked = retval
    End Sub

#Region " Windows Form Designer generated code "


    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents chkUseDynamicVisibility As System.Windows.Forms.CheckBox
    Friend WithEvents btnGrabExtents As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DynamicVisibilityControl))
        Me.chkUseDynamicVisibility = New System.Windows.Forms.CheckBox
        Me.btnGrabExtents = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkUseDynamicVisibility
        '
        Me.chkUseDynamicVisibility.AccessibleDescription = Nothing
        Me.chkUseDynamicVisibility.AccessibleName = Nothing
        resources.ApplyResources(Me.chkUseDynamicVisibility, "chkUseDynamicVisibility")
        Me.chkUseDynamicVisibility.BackgroundImage = Nothing
        Me.chkUseDynamicVisibility.Font = Nothing
        Me.chkUseDynamicVisibility.Name = "chkUseDynamicVisibility"
        '
        'btnGrabExtents
        '
        Me.btnGrabExtents.AccessibleDescription = Nothing
        Me.btnGrabExtents.AccessibleName = Nothing
        resources.ApplyResources(Me.btnGrabExtents, "btnGrabExtents")
        Me.btnGrabExtents.BackColor = System.Drawing.SystemColors.Control
        Me.btnGrabExtents.BackgroundImage = Nothing
        Me.btnGrabExtents.Font = Nothing
        Me.btnGrabExtents.Name = "btnGrabExtents"
        Me.btnGrabExtents.UseVisualStyleBackColor = False
        '
        'DynamicVisibilityControl
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.btnGrabExtents)
        Me.Controls.Add(Me.chkUseDynamicVisibility)
        Me.Font = Nothing
        Me.Name = "DynamicVisibilityControl"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub chkUseDynamicVisibility_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseDynamicVisibility.CheckedChanged
        If frmMain.m_AutoVis(m_handle) Is Nothing Then
            frmMain.m_AutoVis.Add(m_handle, CType(frmMain.MapMain.Extents, MapWinGIS.Extents), chkUseDynamicVisibility.Checked)
        Else
            frmMain.m_AutoVis(m_handle).UseDynamicExtents = chkUseDynamicVisibility.Checked
        End If
        retval = chkUseDynamicVisibility.Checked
        Me.Hide()
        m_Provider.CloseDropDown()
    End Sub

    Private Sub btnGrabExtents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabExtents.Click
        If frmMain.m_AutoVis(m_handle) Is Nothing Then
            frmMain.m_AutoVis.Add(m_handle, CType(frmMain.MapMain.Extents, MapWinGIS.Extents), True)
        Else
            frmMain.m_AutoVis(m_handle).DynamicExtents = CType(frmMain.MapMain.Extents, MapWinGIS.Extents)
        End If
        chkUseDynamicVisibility.Checked = True
        retval = True
        Me.Hide()
        m_Provider.CloseDropDown()
    End Sub
End Class
