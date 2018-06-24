'********************************************************************************************************
'File Name: clsGroups.vb
'Description: Friend class used for groups.  
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
'1/31/2005 - No change from the public domain version - not sure if this is used as code was commented out in the pd version.  
'********************************************************************************************************
Friend Class Groups
    'commented out pre-2005
    'Implements Interfaces.Groups

    'Public Function Add(ByVal GroupName As String, ByVal Position As Integer) As Integer Implements MapWindow.Interfaces.Groups.Add
    '    Return frmMain.Legend.Groups.Add(GroupName, Position)
    'End Function

    'Public Sub Clear() Implements MapWindow.Interfaces.Groups.Clear
    '    frmMain.Legend.Groups.Clear()
    'End Sub

    'Public Function GetHandle(ByVal GroupPosition As Integer) As Integer Implements MapWindow.Interfaces.Groups.GetHandle
    '    Return frmMain.Legend.Groups(GroupPosition).Handle
    'End Function

    'Default Public ReadOnly Property Group(ByVal Handle As Integer) As MapWindow.Interfaces.Group Implements MapWindow.Interfaces.Groups.Group
    '    Get
    '        Dim i As Integer
    '        If frmMain.Legend.Groups.IsValidHandle(Handle) Then
    '            Return New Group(Handle)
    '        End If
    '        Throw New Exception("Group handle does not exist")
    '    End Get
    'End Property

    'Public Property Position(ByVal GroupHandle As Integer) As Integer Implements MapWindow.Interfaces.Groups.Position
    '    Get
    '        Return frmMain.Legend.Groups.PositionOf(GroupHandle)
    '    End Get
    '    Set(ByVal Value As Integer)
    '        frmMain.Legend.Groups.MoveGroup(GroupHandle, Value)
    '    End Set
    'End Property

    'Public Function RemoveGroup(ByVal GroupHandle As Integer) As Boolean Implements MapWindow.Interfaces.Groups.RemoveGroup
    '    Return frmMain.Legend.Groups.Remove(GroupHandle)
    'End Function
End Class
