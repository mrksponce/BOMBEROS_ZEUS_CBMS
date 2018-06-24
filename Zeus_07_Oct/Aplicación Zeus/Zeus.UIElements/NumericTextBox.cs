using System.Windows.Forms;

namespace Zeus.UIElements
{
    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            KeyPress += NumericTextBox_KeyPress;
        }

        private static void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }
    }
}