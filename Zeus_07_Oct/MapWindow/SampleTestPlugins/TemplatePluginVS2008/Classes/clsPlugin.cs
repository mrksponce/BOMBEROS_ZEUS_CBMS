//********************************************************************************************************
//File Name: clsPlugin.cs
//Description: This class holds all code used in this plug-in
//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source MeemsTools Plug-in. 
//
//The Initial Developer of this version of the Original Code is Paul Meems.
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date          Changed By      Notes
// 13 April 2008  Paul Meems      Inital upload the MW SVN repository
//********************************************************************************************************

using System;
using System.Collections.Generic;
//C#3.0:
using System.Linq;
using MapWindow.Interfaces;

namespace TemplatePluginVS2008.Classes
{
    public class pluginCode
    {
        private MapWindow.Interfaces.IMapWin _mapWin;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public pluginCode(MapWindow.Interfaces.IMapWin MapWin)
        {
            _mapWin = MapWin;
        }

        public void fillVisibleLayers(TemplatePluginVS2008.Forms.frmLayers frm)
        {
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            //The layers need to be in a List or else LINQ doesn't work:
            var layersList = getLayers(_mapWin.Layers);
            
            int counter = 0;
            frm.cboLayers.Items.Clear();

            //C#3.0: LINQ to Entities: Language-Integrated Query:            
            var visibleLayers = from l in layersList
                                where l.Visible == true
                                select new MyLayersList { Name = l.Name
                                                        , LayerHandle = l.Handle
                                                        , LayerType = l.LayerType };

            foreach (var l in visibleLayers)
            {
                frm.cboLayers.Items.Add(l);
                if (_mapWin.Layers.CurrentLayer == l.LayerHandle)
                    frm.cboLayers.SelectedIndex = counter;
                counter++;                
            }
        }

        private List<MapWindow.Interfaces.Layer> getLayers(MapWindow.Interfaces.Layers layers)
        {
            //The layers need to be in a List or else LINQ doesn't work
            var layersList = new List<MapWindow.Interfaces.Layer>();

            for (int i = 0; i < layers.NumLayers; i++)
            {
                layersList.Add(layers[i]);
            }
            return layersList;
        }
    }

    /// <summary>
    /// Used to fill the layers combobox
    /// </summary>
    public class MyLayersList
    {
        //C#3.0: Auto-Implemented Properties
        public string Name { get; set; }
        public int LayerHandle { get; set; }
        public eLayerType LayerType { get; set; }

        // This is neccessary because the ListBox and ComboBox rely 
        // on this method when determining the text to display. 
        public override string ToString()
        {
            return Name;
        }

    }
}