using System;
using System.Xml;

namespace mwLabeler.Classes
{
    /// <summary>
	/// Summary description for XMLLabelFile.
	/// </summary>
	public class XMLLabelFile
	{
		//member variables
		private MapWindow.Interfaces.IMapWin m_MapWin;
		private string m_MapWinVersion;
		private XmlDocument m_doc = new XmlDocument();

		public XMLLabelFile(MapWindow.Interfaces.IMapWin mapwin,string MapWinVersion)
		{
			m_MapWin = mapwin;
			m_MapWinVersion = MapWinVersion;
		}

		public void SaveLabelInfo(ref Forms.Label labels,string fileName)
		{	
			try
			{
				//m_doc = labels.lbl_XMLFile;
				//find out what mapwindow version is
				m_doc.LoadXml("<MapWindow version= '" + m_MapWinVersion + "'></MapWindow>");
				System.Xml.XmlElement root = m_doc.DocumentElement;

 				XmlElement Labels = m_doc.CreateElement("Labels");
				XmlAttribute Field = m_doc.CreateAttribute("Field");
                XmlAttribute Field2 = m_doc.CreateAttribute("Field2");
				XmlAttribute Font = m_doc.CreateAttribute("Font");
				XmlAttribute Size = m_doc.CreateAttribute("Size");
				XmlAttribute Color = m_doc.CreateAttribute("Color");
				XmlAttribute Justification = m_doc.CreateAttribute("Justification");
				XmlAttribute UseMinZoomLevel = m_doc.CreateAttribute("UseMinZoomLevel");
				//The following six attributes will only be written to the .lbl file if the version of MapWindow
				//  is new enough.
				XmlAttribute Scaled = m_doc.CreateAttribute("Scaled");
				XmlAttribute UseShadows = m_doc.CreateAttribute("UseShadows");
				XmlAttribute ShadowColor = m_doc.CreateAttribute("ShadowColor");
				XmlAttribute Offset = m_doc.CreateAttribute("Offset");
				XmlAttribute StandardViewWidth = m_doc.CreateAttribute("StandardViewWidth");
				XmlAttribute UseLabelCollision = m_doc.CreateAttribute("UseLabelCollision");
				XmlAttribute RemoveDuplicateLabels = m_doc.CreateAttribute("RemoveDuplicateLabels");
                XmlAttribute RotationField = m_doc.CreateAttribute("RotationField");

				XmlAttribute xMin = m_doc.CreateAttribute("xMin");
				XmlAttribute yMin = m_doc.CreateAttribute("yMin");
				XmlAttribute xMax = m_doc.CreateAttribute("xMax");
				XmlAttribute yMax = m_doc.CreateAttribute("yMax");

                XmlAttribute AppendLine1 = m_doc.CreateAttribute("AppendLine1");
                XmlAttribute AppendLine2 = m_doc.CreateAttribute("AppendLine2");
                XmlAttribute PrependLine1 = m_doc.CreateAttribute("PrependLine1");
                XmlAttribute PrependLine2 = m_doc.CreateAttribute("PrependLine2");
				
				//save the layer label properties
				Field.InnerText = labels.field.ToString();
                Field2.InnerText = labels.field2.ToString();
                Font.InnerText = labels.font.Name;
				Size.InnerText = labels.font.Size.ToString();
				Color.InnerText = labels.color.ToArgb().ToString();
				Justification.InnerText = ((int)labels.alignment).ToString();
				UseMinZoomLevel.InnerText = labels.UseMinExtents.ToString();
                RotationField.InnerText = labels.RotationField.ToString();

				Scaled.InnerText = labels.Scaled.ToString();
				UseShadows.InnerText = labels.UseShadows.ToString();
				ShadowColor.InnerText = labels.shadowColor.ToArgb().ToString();
				Offset.InnerText = labels.Offset.ToString();
				StandardViewWidth.InnerText = labels.StandardViewWidth.ToString();
				UseLabelCollision.InnerText = labels.UseLabelCollision.ToString();
				RemoveDuplicateLabels.InnerText = labels.RemoveDuplicates.ToString();

				if(labels.extents != null)
				{
					xMin.InnerText = labels.extents.xMin.ToString();
					yMin.InnerText = labels.extents.yMin.ToString();
					xMax.InnerText = labels.extents.xMax.ToString();
					yMax.InnerText = labels.extents.yMax.ToString();
				}
				else
				{
					xMin.InnerText = "0";
					yMin.InnerText = "0";
					xMax.InnerText = "0";
					yMax.InnerText = "0";
				}

                AppendLine1.InnerText = labels.AppendLine1;
                AppendLine2.InnerText = labels.AppendLine2;
                PrependLine1.InnerText = labels.PrependLine1;
                PrependLine2.InnerText = labels.PrependLine2;
                
				//add the attributes to the Labels node
                Labels.Attributes.Append(AppendLine1);
                Labels.Attributes.Append(AppendLine2);
                Labels.Attributes.Append(PrependLine1);
                Labels.Attributes.Append(PrependLine2);
				Labels.Attributes.Append(Field);
                Labels.Attributes.Append(Field2);
				Labels.Attributes.Append(Font);
				Labels.Attributes.Append(Size);
				Labels.Attributes.Append(Color);
				Labels.Attributes.Append(Justification);
				Labels.Attributes.Append(UseMinZoomLevel);

				Labels.Attributes.Append(Scaled);
				Labels.Attributes.Append(UseShadows);
				Labels.Attributes.Append(ShadowColor);
				Labels.Attributes.Append(Offset);
				Labels.Attributes.Append(StandardViewWidth);
				Labels.Attributes.Append(UseLabelCollision);
				Labels.Attributes.Append(RemoveDuplicateLabels);
                Labels.Attributes.Append(RotationField);

				Labels.Attributes.Append(xMin);
				Labels.Attributes.Append(yMin);
				Labels.Attributes.Append(xMax);
				Labels.Attributes.Append(yMax);
                
				MapWinGIS.Shapefile shpFile;
				shpFile = (MapWinGIS.Shapefile)m_MapWin.Layers[labels.handle].GetObject();

				string name;
				for(int i=0; i < shpFile.NumShapes ; i++)
				{
					if((int)labels.labelShape[i] == 1)
					{
                        name = labels.PrependLine1 + shpFile.get_CellValue(labels.field-1,i).ToString() + labels.AppendLine1;
                        if (labels.field2 != 0)
                        {
                            name += Environment.NewLine;
                            name += labels.PrependLine2;
                            name += shpFile.get_CellValue(labels.field2 - 1, i).ToString();
                            name += labels.AppendLine2;
                        }
						AddPointLabel((Forms.Point)labels.points[i],name,Labels, true);
					}
				}

				//add all of the labels to the root
				root.AppendChild(Labels);

				//save the label file
				m_doc.Save(fileName);
				//Save the xml of the .lbl file in the label struct (label struct passed as 'ref')
				labels.xml_LblFile = m_doc.InnerXml;
				
             }
			catch(System.Exception ex)
			{
				m_MapWin.ShowErrorDialog(ex);
			}
		}
        
		private void AddPointLabel(Forms.Point p,string labelName, XmlElement parent, bool newVersion)
		{
			try
			{
				XmlElement Label = m_doc.CreateElement("Label");
				XmlAttribute X = m_doc.CreateAttribute("X");
				XmlAttribute Y = m_doc.CreateAttribute("Y");
				XmlAttribute Rotation = m_doc.CreateAttribute("Rotation");
				XmlAttribute Name = m_doc.CreateAttribute("Name");

				X.InnerText = p.x.ToString();
				Y.InnerText = p.y.ToString();
				Rotation.InnerText = p.rotation.ToString();
				Name.InnerText = labelName;

				Label.Attributes.Append(X);
				Label.Attributes.Append(Y);
				if(newVersion == true)
				{
					Label.Attributes.Append(Rotation);
				}
				Label.Attributes.Append(Name);

				parent.AppendChild(Label);
			}
			catch(System.Exception ex)
			{
				m_MapWin.ShowErrorDialog(ex);
			}
		}

		public bool LoadLabelInfo(MapWindow.Interfaces.IMapWin m_MapWin, MapWindow.Interfaces.Layer layer, ref Forms.Label label, System.Windows.Forms.Form owner)
		{
            if (layer == null) return false;

			//make sure the file exists
            string filename = "";
            if (m_MapWin.View.LabelsUseProjectLevel)
            {
                if (m_MapWin.Project.FileName != null && m_MapWin.Project.FileName.Trim() != "")
                {
                    filename = System.IO.Path.GetFileNameWithoutExtension(m_MapWin.Project.FileName) + @"\" + System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(layer.FileName), ".lbl");
                }
            }
            if (filename == "" || !System.IO.File.Exists(filename))
            {
                filename = System.IO.Path.ChangeExtension(layer.FileName, ".lbl");
            }
			if(!System.IO.File.Exists(filename)) return false;

			try
			{
				//load the xml file
				m_doc.Load(filename);

				//get the root of the file
				System.Xml.XmlElement root = m_doc.DocumentElement;

				label.points = new System.Collections.ArrayList();
				label.labelShape = new System.Collections.ArrayList();

				XmlNodeList nodeList = root.GetElementsByTagName("Labels");
			
				//get the font
				int field = int.Parse(nodeList[0].Attributes.GetNamedItem("Field").InnerText);
                int field2 = 0;
                if (nodeList[0].Attributes.GetNamedItem("Field2") != null)
                    field2 = int.Parse(nodeList[0].Attributes.GetNamedItem("Field2").InnerText);
				string fontName = nodeList[0].Attributes.GetNamedItem("Font").InnerText;
				float size = float.Parse(nodeList[0].Attributes.GetNamedItem("Size").InnerText);
				System.Drawing.Color color = System.Drawing.Color.FromArgb(int.Parse(nodeList[0].Attributes.GetNamedItem("Color").InnerText));
				int justification = int.Parse(nodeList[0].Attributes.GetNamedItem("Justification").InnerText);
				bool UseMinZoom = bool.Parse(nodeList[0].Attributes.GetNamedItem("UseMinZoomLevel").InnerText);
				bool Scaled = false;
				bool UseShadows = false;
				System.Drawing.Color ShadowColor = System.Drawing.Color.White;
				int Offset = 0;
				double StandardViewWidth = 0.0;
				bool UseLabelCollision = false;
				bool RemoveDuplicateLabels = false;
                string RotationField = "";

                try
                {
                    if (nodeList[0].Attributes.GetNamedItem("Scaled") != null) Scaled = bool.Parse(nodeList[0].Attributes.GetNamedItem("Scaled").InnerText);
                    if (nodeList[0].Attributes.GetNamedItem("UseShadows") != null) UseShadows = bool.Parse(nodeList[0].Attributes.GetNamedItem("UseShadows").InnerText);
                    if (nodeList[0].Attributes.GetNamedItem("ShadowColor") != null) ShadowColor = System.Drawing.Color.FromArgb(int.Parse(nodeList[0].Attributes.GetNamedItem("ShadowColor").InnerText));
                    if (nodeList[0].Attributes.GetNamedItem("Offset") != null) Offset = int.Parse(nodeList[0].Attributes.GetNamedItem("Offset").InnerText);
                    if (nodeList[0].Attributes.GetNamedItem("StandardViewWidth") != null) StandardViewWidth = double.Parse(nodeList[0].Attributes.GetNamedItem("StandardViewWidth").InnerText);
                }
                catch
                {
                    Scaled = false;
                    UseShadows = false;
                    ShadowColor = System.Drawing.Color.White;
                    Offset = 0;
                    StandardViewWidth = 0.0;
                }
                
				if(nodeList[0].Attributes.GetNamedItem("UseLabelCollision") != null)
				{
					UseLabelCollision = bool.Parse(nodeList[0].Attributes.GetNamedItem("UseLabelCollision").InnerText);
				}
				if(nodeList[0].Attributes.GetNamedItem("RemoveDuplicateLabels") != null)
				{
					RemoveDuplicateLabels = bool.Parse(nodeList[0].Attributes.GetNamedItem("RemoveDuplicateLabels").InnerText);
				}
                if (nodeList[0].Attributes.GetNamedItem("RotationField") != null)
				{
                    RotationField = nodeList[0].Attributes.GetNamedItem("RotationField").InnerText;
				}

				double xMin = double.Parse(nodeList[0].Attributes.GetNamedItem("xMin").InnerText);
				double yMin = double.Parse(nodeList[0].Attributes.GetNamedItem("yMin").InnerText);
				double xMax = double.Parse(nodeList[0].Attributes.GetNamedItem("xMax").InnerText);
				double yMax = double.Parse(nodeList[0].Attributes.GetNamedItem("yMax").InnerText);

				//set all the properties of the label
				label.font = new System.Drawing.Font(fontName,size);
				label.color = color;
				label.field = field;
                label.field2 = field2;
				label.handle = layer.Handle;
				label.alignment = (MapWinGIS.tkHJustification)justification;
				label.UseMinExtents = UseMinZoom;

                label.Scaled = Scaled;
                label.UseShadows = UseShadows;
                label.shadowColor = ShadowColor;
                label.Offset = Offset;
                label.StandardViewWidth = StandardViewWidth;
                label.RotationField = RotationField;

				if(nodeList[0].Attributes.GetNamedItem("UseLabelCollision") != null)
				{
					label.UseLabelCollision = UseLabelCollision;
				}
				if(nodeList[0].Attributes.GetNamedItem("RemoveDuplicateLabels") != null)
				{
					label.RemoveDuplicates = RemoveDuplicateLabels;
				}

                if (nodeList[0].Attributes.GetNamedItem("AppendLine1") != null)
                {
                    label.AppendLine1 = nodeList[0].Attributes.GetNamedItem("AppendLine1").InnerText;
                }
                if (nodeList[0].Attributes.GetNamedItem("AppendLine2") != null)
                {
                    label.AppendLine2 = nodeList[0].Attributes.GetNamedItem("AppendLine2").InnerText;
                }
                if (nodeList[0].Attributes.GetNamedItem("PrependLine1") != null)
                {
                    label.PrependLine1 = nodeList[0].Attributes.GetNamedItem("PrependLine1").InnerText;
                }
                if (nodeList[0].Attributes.GetNamedItem("PrependLine2") != null)
                {
                    label.PrependLine2 = nodeList[0].Attributes.GetNamedItem("PrependLine2").InnerText;
                }

				label.extents = new MapWinGIS.ExtentsClass();
				label.extents.SetBounds(xMin,yMin,0,xMax,yMax,0);
				label.Modified = false;
				label.LabelExtentsChanged = false;
				label.updateHeaderOnly = true;
				
				//add all the points to this label
				Forms.Point p;
				XmlNode node;
				double x, y, rotation = 0;
				System.Collections.IEnumerator enumerator = nodeList[0].ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					node = (XmlNode)enumerator.Current;
					x = double.Parse(node.Attributes.GetNamedItem("X").InnerText);
					y = double.Parse(node.Attributes.GetNamedItem("Y").InnerText);

					if (nodeList[0].Attributes.GetNamedItem("Rotation") != null) rotation = double.Parse(node.Attributes.GetNamedItem("Rotation").InnerText);


					p = new Forms.Point();
					p.x = x;
					p.y = y;
                    p.rotation = rotation;

					label.points.Add(p);
				}
				label.xml_LblFile = m_doc.InnerXml;
			}
			catch
			{
				return false;
			}
			
			return true;	
		}

		public void ReplaceHeader(ref Forms.Label labels, string fileName)
		{
			m_doc.LoadXml(labels.xml_LblFile);

			XmlElement root = m_doc.DocumentElement;

			XmlNode node = root.FirstChild.Attributes.GetNamedItem("Field");
			node.InnerText = labels.field.ToString();
			node = root.FirstChild.Attributes.GetNamedItem("Font");
			node.InnerText = labels.font.Name;
			node = root.FirstChild.Attributes.GetNamedItem("Size");
			node.InnerText = labels.font.Size.ToString();
			node = root.FirstChild.Attributes.GetNamedItem("Color");
			node.InnerText = labels.color.ToArgb().ToString();
			node = root.FirstChild.Attributes.GetNamedItem("Justification");
			node.InnerText = ((int)labels.alignment).ToString();
			node = root.FirstChild.Attributes.GetNamedItem("UseMinZoomLevel");
			node.InnerText = labels.UseMinExtents.ToString();

			AddXMLNodeInnerText(root,"Scaled",labels.Scaled.ToString());
			AddXMLNodeInnerText(root,"UseShadows",labels.UseShadows.ToString());
			AddXMLNodeInnerText(root,"ShadowColor",labels.shadowColor.ToArgb().ToString());
			AddXMLNodeInnerText(root,"Offset",labels.Offset.ToString());
			AddXMLNodeInnerText(root,"StandardViewWidth",labels.StandardViewWidth.ToString());
			AddXMLNodeInnerText(root,"UseLabelCollision",labels.UseLabelCollision.ToString());
			AddXMLNodeInnerText(root,"RemoveDuplicateLabels",labels.RemoveDuplicates.ToString());
            AddXMLNodeInnerText(root, "RotationField", labels.RotationField);

			if(labels.extents != null)
			{
				node = root.FirstChild.Attributes.GetNamedItem("xMin");
				node.InnerText = labels.extents.xMin.ToString();
				node = root.FirstChild.Attributes.GetNamedItem("yMin");
				node.InnerText = labels.extents.yMin.ToString();
				node = root.FirstChild.Attributes.GetNamedItem("xMax");
				node.InnerText = labels.extents.xMax.ToString();
				node = root.FirstChild.Attributes.GetNamedItem("yMax");
				node.InnerText = labels.extents.yMax.ToString();
			}

			//Save .lbl file
			m_doc.Save(fileName);
			//Save the xml of the .lbl file in the label struct (label struct passed as 'ref')
			labels.xml_LblFile = m_doc.InnerXml;
		}

		void AddXMLNodeInnerText(XmlElement root, string localName, string new_value)
		{
			XmlNode node = root.FirstChild.Attributes.GetNamedItem(localName);
			if(node == null)
			{
				System.Xml.XmlAttribute newAttribute = m_doc.CreateAttribute(localName);
				newAttribute.InnerText = new_value;
				root.FirstChild.Attributes.Append(newAttribute);
			}
			else
			{
				node.InnerText = new_value;
			}
		}
	}
}
