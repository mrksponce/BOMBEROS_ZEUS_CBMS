using System;
using System.Diagnostics;
using System.IO;
using Zeus.Util.Forms;

namespace Zeus.Util
{
    public static class Log
    {
        private static TextWriter tw;

        public static void Init(string file)
        {
            try
            {
                tw = !File.Exists(file) ? File.CreateText(file) : File.AppendText(file);
                Trace.Listeners.Add(new TextWriterTraceListener(tw));
            }
            catch (UnauthorizedAccessException e)
            {
                ShowAndLog(e);
            }
        }

        public static void Write(Exception e)
        {
            Trace.WriteLine("-----------------------------------");
            Trace.WriteLine(DateTime.Now);
            Trace.Write(e.Message);
            Trace.WriteLine("");
            Trace.WriteLine(e.StackTrace);
            //if (tw!=null)
            //{
            //    tw.Flush();
            //}
        }

        public static void Finish()
        {
            if (tw != null)
            {
                tw.Flush();
                tw.Close();
            }
            Trace.Listeners.Clear();
        }

        public static void ShowAndLog(Exception e)
        {
            Write(e);
            var em = new ErrorMsg(e);
            em.ShowDialog();
        }
    }
}