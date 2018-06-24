Public Class MWProgressStatus
    Implements MapWinUtility.IProgressStatus

    Private pOrigCursor As Windows.Forms.Cursor

    ''' <summary>
    ''' Log the progress of a long-running task
    ''' </summary>
    ''' <param name="CurrentPosition">Current position/item of task</param>
    ''' <param name="LastPosition">Final position/item of task</param>
    ''' <remarks>
    ''' A final call when the task is done with aCurrent = aLast 
    ''' indicates completion and should clear the progress display.
    ''' </remarks>
    Public Sub Progress(ByVal CurrentPosition As Integer, ByVal LastPosition As Integer) Implements MapWinUtility.IProgressStatus.Progress
        If Not frmMain.StatusBar.ShowProgressBar OrElse pOrigCursor = Nothing Then
            pOrigCursor = frmMain.Cursor
        End If
        If CurrentPosition = LastPosition Then 'Reached end, stop showing progress bar
            frmMain.StatusBar.ShowProgressBar = False
            frmMain.Cursor = pOrigCursor
        Else
            Try
                frmMain.StatusBar.ProgressBarValue = 100 * CDbl(CurrentPosition) / LastPosition
                frmMain.StatusBar.ShowProgressBar = True
                Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception 'Ignore exception if we can't set ProgressBarValue
            End Try
        End If
        'frmMain.Refresh()
    End Sub

    ''' <summary>
    ''' Update the current status message
    ''' </summary>
    ''' <param name="StatusMessage">Description of current processing status</param>
    Public Sub Status(ByVal StatusMessage As String) Implements MapWinUtility.IProgressStatus.Status
        frmMain.StatusBar(1).Text = StatusMessage
    End Sub
End Class
