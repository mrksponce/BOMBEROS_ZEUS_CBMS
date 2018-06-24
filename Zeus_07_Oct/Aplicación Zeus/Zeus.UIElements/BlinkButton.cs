using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeus.UIElements
{
    public class BlinkButton : Button
    {
        //protected override void OnPaint(PaintEventArgs pevent)
        //{
        //    base.OnPaint(pevent);
        //    if (blinkState)
        //    {
        //        //Rectangle r = new Rectangle(this.ClientRectangle.Location, new Size(this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1));
        //        //Pen p = new Pen(Brushes.Orange, 3);
        //        //pevent.Graphics.DrawRectangle(p, r);
        //    }
        //}


        private readonly Timer timer;
        private bool blink;
        private bool blinkState;

        public BlinkButton()
        {
            timer = new Timer {Interval = 1000};
            timer.Tick += timer_Tick;
            blinkState = false;
        }

        public bool Blink
        {
            get { return blink; }
            set
            {
                blink = value;
                if (Created)
                {
                    if (value)
                    {
                        timer.Start();
                    }
                    else
                    {
                        timer.Stop();
                        //blinkState = false;
                        BackColor = DefaultBackColor;
                        Invalidate();
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            BackColor = blinkState ? Color.OrangeRed : DefaultBackColor;
            blinkState = !blinkState;
            Invalidate();
        }
    }
}