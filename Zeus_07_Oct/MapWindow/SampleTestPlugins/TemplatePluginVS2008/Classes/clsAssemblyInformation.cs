//********************************************************************************************************
//File Name: clsAsemblyInformation.cs
//Description: This class return Assembly info from the AssemblyInfo.cs
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
using System.Reflection;

namespace TemplatePluginVS2008.Classes
{
    class AssemblyInformation
    {
        public static string ProductDescription()
        {
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var currentAssembly = Assembly.GetExecutingAssembly();
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var attrType = typeof(AssemblyDescriptionAttribute);

            object[] attrs = currentAssembly.GetCustomAttributes(attrType, false);
            if (attrs.Length > 0)
            {
                //C#3.0: Implicitly Typed Local Variables and Arrays:
                var desc = (AssemblyDescriptionAttribute)attrs[0];
                return desc.Description;
            }
            else
                return "";
        }

        public static string ProductName()
        {
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var currentAssembly = Assembly.GetExecutingAssembly();
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var attrType = typeof(AssemblyProductAttribute);

            object[] attrs = currentAssembly.GetCustomAttributes(attrType, false);
            if (attrs.Length > 0)
            {
                //C#3.0: Implicitly Typed Local Variables and Arrays:
                var desc = (AssemblyProductAttribute)attrs[0];
                return desc.Product;
            }
            else
                return "";
        }

        public static string ProductTitle()
        {
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var currentAssembly = Assembly.GetExecutingAssembly();
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var attrType = typeof(AssemblyTitleAttribute);

            object[] attrs = currentAssembly.GetCustomAttributes(attrType, false);
            if (attrs.Length > 0)
            {
                //C#3.0: Implicitly Typed Local Variables and Arrays:
                var desc = (AssemblyTitleAttribute)attrs[0];
                return desc.Title;
            }
            else
                return "";
        }

        public static string ProductCompany()
        {
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var currentAssembly = Assembly.GetExecutingAssembly();
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var attrType = typeof(AssemblyCompanyAttribute);

            object[] attrs = currentAssembly.GetCustomAttributes(attrType, false);
            if (attrs.Length > 0)
            {
                //C#3.0: Implicitly Typed Local Variables and Arrays:
                var desc = (AssemblyCompanyAttribute)attrs[0];
                return desc.Company;
            }
            else
                return "";
        }

        public static string ProductCopyright()
        {
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var currentAssembly = Assembly.GetExecutingAssembly();
            //C#3.0: Implicitly Typed Local Variables and Arrays:
            var attrType = typeof(AssemblyCopyrightAttribute);

            object[] attrs = currentAssembly.GetCustomAttributes(attrType, false);
            if (attrs.Length > 0)
            {
                //C#3.0: Implicitly Typed Local Variables and Arrays:
                var desc = (AssemblyCopyrightAttribute)attrs[0];
                return desc.Copyright;
            }
            else
                return "";
        }
    }
}
