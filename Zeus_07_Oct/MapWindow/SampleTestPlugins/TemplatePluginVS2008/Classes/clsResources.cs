//********************************************************************************************************
//File Name: clsReources.cs
//Description: This class gets the images from the resource file
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
// 13 April 2008  Paul Meems     Inital upload the MW SVN repository
//********************************************************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using MapWinUtility;

namespace TemplatePluginVS2008.Classes
{
    public class clsResources
    {
        private System.Reflection.Assembly _assembly;
        private string _namespace;

        /// <summary>
        /// Constructor
        /// </summary>
        public clsResources()
        {
            _assembly = System.Reflection.Assembly.GetExecutingAssembly();
            getNamespace();
        }
        
        public clsResources(bool useEntryAssembly)
        {
            _assembly = System.Reflection.Assembly.GetEntryAssembly();
            getNamespace();
        }
        
        /// <summary>
        /// Destructor
        /// </summary>
        ~clsResources()
        {
            _assembly = null;
        }
        
        private void getNamespace()
        {
            _namespace = _assembly.GetName().Name.ToString() + ".Resources";
        }

        public Bitmap GetEmbeddedBitmap(string name, bool transparant)
        {
            try
            {
                Bitmap bm = null;
                string resourceName = _namespace + "." + name;
                //C#3.0: Implicitly Typed Local Variables and Arrays:
                var picture_stream = _assembly.GetManifestResourceStream(resourceName);
                if (picture_stream != null)
                {
                    bm = new Bitmap(picture_stream);
                    if (transparant) bm.MakeTransparent();
                    picture_stream.Close();
                }
                else
                {                    
                    GetListOfEmbeddedResources();
                    throw new Exception("GetEmbeddedBitmap has no stream: " + resourceName);
                }
                return bm;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR in GetEmbeddedBitmap: " + ex.ToString());
                throw (ex);
            }
        }

        public Icon GetEmbeddedIcon(string name)
        {
            try
            {
                Icon ic = null;
                string resourceName = _namespace + "." + name;
                //C#3.0: Implicitly Typed Local Variables and Arrays:
                var picture_stream = _assembly.GetManifestResourceStream(resourceName);
                if (picture_stream != null)
                {
                    ic = new Icon(picture_stream);
                    picture_stream.Close();
                }
                else
                {                    
                    GetListOfEmbeddedResources();
                    throw new Exception("GetEmbeddedIcon has no stream: " + resourceName);
                }
                return ic;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR in GetEmbeddedIcon: " + ex.ToString());
                throw (ex);
            }

        }

        public void GetListOfEmbeddedResources()
        {
            string logfilename = @"c:\resourcesOf" + _namespace.Replace(" ", "-") + ".log";
            Logger.StartToFile(logfilename,false, false,false);
            Logger.Dbg("In GetListOfEmbeddedResources");
            Logger.Dbg("Resources of " + _namespace);
            string[] names = _assembly.GetManifestResourceNames();
            MessageBox.Show("Found " + names.Length + " resources");
            foreach(string name in names)
                Logger.Dbg(name);

            MessageBox.Show(logfilename + " created.");
            Logger.Flush();
        }        
    }
}
