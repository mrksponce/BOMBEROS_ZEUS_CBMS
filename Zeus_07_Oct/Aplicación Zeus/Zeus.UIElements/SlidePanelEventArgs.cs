using System;

namespace Zeus.UIElements
{
    public class SlidePanelEventArgs:EventArgs
    {
        public bool Collapsed { get; set; }

        public SlidePanelEventArgs(bool collapsed)
        {
            Collapsed = collapsed;
        }
    }
}
