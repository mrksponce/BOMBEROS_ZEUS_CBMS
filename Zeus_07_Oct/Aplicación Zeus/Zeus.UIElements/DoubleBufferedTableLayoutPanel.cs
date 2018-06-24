using System.Windows.Forms;

namespace Zeus.UIElements
{
    /// <summary>
    /// Double Buffered layout panel - removes flicker during resize operations.
    /// </summary>
    public class DoubleBufferedTableLayoutPanel : TableLayoutPanel
    {
        public DoubleBufferedTableLayoutPanel()
        {
            base.DoubleBuffered = true;
        }
    }
}
