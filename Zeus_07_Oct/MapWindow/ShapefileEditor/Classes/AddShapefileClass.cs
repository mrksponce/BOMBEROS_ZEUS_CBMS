//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source. 
//
//The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by 
//Utah State University and the Idaho National Engineering and Environmental Lab that were released as 
//public domain in March 2004.  
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//1/29/2005 - Code is identical to public domain version.
//********************************************************************************************************
using System;

namespace ShapefileEditor
{
	/// <summary>
	/// Summary description for AddShapefileClass.
	/// </summary>
	public class AddShapefileClass
	{
		private GlobalFunctions m_globals;

		public AddShapefileClass(GlobalFunctions g)
		{
			//
			// TODO: Add constructor logic here
			//
			m_globals = g;
			m_globals.Events.AddHandler(new MapWindow.Events.ItemClickedEvent(ItemClicked));
		}

		private void ItemClicked(string name, ref bool handled)
		{
			if(name == GlobalFunctions.c_NewButton)
				AddNewShapefile();
		}

		/// <summary>
		/// Prompts the user for information needed to create a new shapefile, then creates it.
		/// </summary>
		public void AddNewShapefile()
		{
			AddShapefileForm dlg = new AddShapefileForm();
			if (dlg.ShowDialog(m_globals.MapWindowForm) == System.Windows.Forms.DialogResult.OK)
			{
				MapWinGIS.Shapefile sf = new MapWinGIS.ShapefileClass();
				switch(dlg.cmbType.Text)
				{
					case "Point":
						sf.CreateNewWithShapeID(dlg.txtFilename.Text,MapWinGIS.ShpfileType.SHP_POINT);
						break;
					case "Line":
                        sf.CreateNewWithShapeID(dlg.txtFilename.Text, MapWinGIS.ShpfileType.SHP_POLYLINE);
						break;
					case "Polygon":
                        sf.CreateNewWithShapeID(dlg.txtFilename.Text, MapWinGIS.ShpfileType.SHP_POLYGON);
						break;
					default:
						return;
				}
				
				sf.SaveAs(dlg.txtFilename.Text, null);
				sf.Close();
				m_globals.MapWin.Layers.Add(dlg.txtFilename.Text);
                MapWinUtility.Logger.Message("An empty shapefile has been created. Before adding shapes, make sure that your extents are set properly. To make sure extents are correct load an image, grid or shapefile that is located in the same area.", "Important Information!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.DialogResult.OK);
			}
		}
	}
}
