'********************************************************************************************************
'File Name: clsBarsProperties.vb
'Description: Friend class stores variables associated with docking bars.  Not currently used. 
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
'1/1/2005 - dpa - extracted from a different class file where it was sitting.  Not currently used. 
'********************************************************************************************************

Friend Class BarsProperties
    Friend CanUndock As Boolean
    Public CanDockRight As Boolean
    Public CanDockLeft As Boolean
    Public CanHide As Boolean
End Class
