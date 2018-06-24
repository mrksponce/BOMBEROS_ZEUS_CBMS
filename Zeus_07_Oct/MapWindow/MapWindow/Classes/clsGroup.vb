'********************************************************************************************************
'File Name: clsGroup.vb
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
'1/31/2005 - No change from the public domain version - not sure if this is used. 
'********************************************************************************************************
Friend Class Group
    'Implements Interfaces.Group

    Private m_GroupHandle As Integer

    'Public Property Expanded() As Boolean Implements MapWindow.Interfaces.Group.Expanded
    '    Get
    '        Return frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).Expanded
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).Expanded = Value
    '    End Set
    'End Property

    'Public Property Icon() As Object Implements MapWindow.Interfaces.Group.Icon
    '    Get
    '        Return frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).Icon
    '    End Get
    '    Set(ByVal Value As Object)
    '        frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).Icon = Value
    '    End Set
    'End Property

    'Public Property LayersVisible() As Boolean Implements MapWindow.Interfaces.Group.LayersVisible
    '    Get
    '        'Dim i, visible As Integer
    '        Return frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).LayersVisible
    '        'For i = 0 To frmMain.Legend.GroupSubItemCount(m_GroupHandle) - 1
    '        '    visible = frmMain.MapMain.get_LayerVisible(frmMain.Legend.GroupSubItemHandle(m_GroupHandle, i))
    '        '    If visible Then Return True
    '        'Next
    '        'Return False
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).LayersVisible = Value
    '    End Set
    'End Property

    'Public Property Name() As String Implements MapWindow.Interfaces.Group.Name
    '    Get
    '        Return frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).Text
    '    End Get
    '    Set(ByVal Value As String)
    '        frmMain.Legend.Groups.ItemByHandle(m_GroupHandle).Text = Value
    '    End Set
    'End Property

    'Public Property Position() As Integer Implements MapWindow.Interfaces.Group.Position
    '    Get
    '        Return frmMain.Legend.Groups.PositionOf(m_GroupHandle)
    '    End Get
    '    Set(ByVal Value As Integer)
    '        frmMain.Legend.Groups.MoveGroup(m_GroupHandle, Value)
    '    End Set
    'End Property

    Public Sub New(ByVal GroupHandle As Integer)
        m_GroupHandle = GroupHandle
    End Sub
End Class
