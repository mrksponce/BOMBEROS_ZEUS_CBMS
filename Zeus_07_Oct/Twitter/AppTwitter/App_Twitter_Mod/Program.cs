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
            string strTw = "";

            int intCount = args.Length;
            //if (intCount == 3)
            //{
            //    //twitt.GenerarTwitt(Convert.ToInt32(args[0].ToString()), args[1].ToString(), args[2].ToString());
            //}
            //else
            //{
            //    //twitt.GenerarTwitt(args[0].ToString(), args[1].ToString());
            //}

            switch (Convert.ToInt32(args[0].ToString()))
            {
                case 1: //# Tw Texto Libre
                    for (int i=1; i < args.Length; i++)
                    {
                        strTw += args[i].ToString() + " ";
                    }
                    twitt.GenerarTwitt_Texto(strTw);
                    //MessageBox.Show(strTw, "GEObit");
                    break;

                case 2: //# Tw Despachos con Mapa
                    twitt.GenerarTwitt(Convert.ToInt32(args[1].ToString()), args[2].ToString(), args[3].ToString());
                    //MessageBox.Show("Despachos con Mapa... ", "GEObit");
                    break;

                case 3: //# Tw 0-8
                    strTw = "0-8  " + args[1].ToString() + " " + args[2].ToString() + " " + args[3].ToString();
                    //strTw = "0-8  " + args[1].ToString();
                    twitt.GenerarTwitt_Texto(strTw);
                    //MessageBox.Show(strTw, "GEObit");
                    break;

                case 4: //# Tw 0-9
                    strTw = "0-9  " + args[1].ToString() + " " + args[2].ToString() + " " + args[3].ToString();
                    twitt.GenerarTwitt_Texto(strTw);
                    //MessageBox.Show(strTw, "GEObit");
                    break;

                case 5: //# Tw Reporte del Material
                    twitt.GenerarTwitt_Reporte();
                    //MessageBox.Show("Tw Reporte del Material... ", "GEObit");
                    break;

                case 6: //# Operadora en Servicio
                    strTw = "En Servicio  " + args[1].ToString();
                    twitt.GenerarTwitt_Texto(strTw);
                    //MessageBox.Show(strTw, "GEObit");
                    break;
            }


        }
    }
}
