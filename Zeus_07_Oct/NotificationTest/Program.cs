using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NotificationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                // no args, enviar notificaciones
                StreamWriter f = File.CreateText("notifications.txt");
                Random r = new Random();
                while (true)
                {
                    
                }
            }
        }
    }
}
