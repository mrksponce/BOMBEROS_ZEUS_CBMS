using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App_Twitter_Mod
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            Twitter twitt = new Twitter();
            twitt.GenerarTwitt(Convert.ToInt32(args[0].ToString()));
        }
    }
}
