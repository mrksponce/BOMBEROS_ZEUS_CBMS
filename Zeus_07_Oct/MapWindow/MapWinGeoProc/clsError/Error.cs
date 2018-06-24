//********************************************************************************************************
//File name: Error.cs
//Description: Public class, provides methods for recording and retrieving errors.
//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
//you may not use this file except in compliance with the License. You may obtain a copy of the License at 
//http://www.mozilla.org/MPL/ 
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
//ANY KIND, either express or implied. See the License for the specific language governing rights and 
//limitations under the License. 
//
//The Original Code is MapWindow Open Source. 
//
//Contributor(s): (Open source contributors should list themselves and their modifications here). 
//9-1-05 ah - Angela Hillier - Created error class and basic functions. 							
//********************************************************************************************************
using System;
using System.IO;
using System.Diagnostics;

namespace MapWinGeoProc
{
	/// <summary>
	/// Class for recording and retrieving error messages.
	/// </summary>
	public class Error
	{
		private static string fileName = "ErrorLog.txt";

		/// <summary>
		/// Deletes all previous error messages.
		/// </summary>
		public static void ClearErrorLog()
		{
			if(File.Exists(fileName))
			{
				File.Delete(fileName);
			}
		}
		
		/// <summary>
		/// Provides access to the last error message recieved through 
		/// the MapWinGeoProc library.
		/// </summary>
		/// <returns>A description of the problem encountered. 
		/// </returns>
		public static string GetLastErrorMsg()
		{
			StreamReader sr;
			string sLine = "";
			string errorMsg = "";
			if (File.Exists(fileName)) 
			{
				try
				{
					sr = new StreamReader(fileName);
					while((sLine = sr.ReadLine())!= null)
					{
						errorMsg = sLine;
					}
					sr.Close();
				}
				catch(IOException)
				{
					return("Error Reading File!!");
				}
			} 
			if(errorMsg.Equals(""))
			{
				errorMsg = "No errors were recorded.";
			}
			return errorMsg;
		}

		/// <summary>
		/// Sets the last error message recieved through
		/// the MapWinGeoProc library.
		/// </summary>
		/// <param name="errorMsg">A string describing the problem encountered.</param>
		public static void SetErrorMsg(string errorMsg)
		{
			StreamWriter sw;
			if (!File.Exists(fileName)) 
			{
				try
				{
					sw = File.CreateText(fileName);
					sw.WriteLine(errorMsg);
					sw.Close();
				}
				catch(IOException)
				{
					Debug.WriteLine("Error writing to file!!");
				}
			}
			else
			{
				try
				{
					sw = File.AppendText(fileName);
					sw.WriteLine(errorMsg);
					sw.Close();
				}
				catch(IOException)
				{
					Debug.WriteLine("Error writing to file!!!");
				}
			}
		}

	}
}
