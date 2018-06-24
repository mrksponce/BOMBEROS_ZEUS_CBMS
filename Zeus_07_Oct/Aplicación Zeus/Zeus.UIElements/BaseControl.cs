using System;
using System.Windows.Forms;
using Zeus.Interfaces;

namespace Zeus.UIElements
{
    public partial class BaseControl : UserControl
    {
        protected IZeusWin _zeusWin;

        public BaseControl()
        {
            InitializeComponent();
        }

        public virtual IZeusWin ZeusWin
        {
            get
            {
                if (_zeusWin == null)
                {
                    if (DesignMode)
                        return null;
                    throw new InvalidOperationException("ZeusWin no puede ser null");
                }
                return _zeusWin;
            }
            set { _zeusWin = value; }
        }
    }
}