using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeus.Util
{
    public class FormHelper
    {
        // Declare external functions.
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static bool IsActive(Form form)
        {
            // Obtain the handle of the active window.
            IntPtr handle = GetForegroundWindow();

            return (form.Handle == handle);
        }

        public static bool IsDesignMode(Control c)
        {
            if (c == null)
            {
                return false;
            }
            if (c.Created)
            {
                MessageBox.Show(c.Site.DesignMode.ToString());
                if (c.Site != null && c.Site.DesignMode)
                {
                    return true;
                }
                if (Assembly.GetEntryAssembly() == null)
                {
                    return true;
                }
            }
            return IsDesignMode(c.Parent);
        }
    }
}