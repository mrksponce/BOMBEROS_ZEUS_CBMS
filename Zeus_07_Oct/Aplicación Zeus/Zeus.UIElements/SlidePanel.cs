using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;



namespace Zeus.UIElements
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof (IDesigner))]
    public partial class SlidePanel : BaseControl
    {
        private bool arriba;
        private bool collapsed;
        private int id_operadora;
        private bool link;
        private int maxHeight;
        private int mult;

        public SlidePanel()
        {
            InitializeComponent();
        }

        [Category("Appearance"), Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int MaxHeight
        {
            get { return maxHeight; }
            set { maxHeight = value; }
        }

        public int Id_operadora
        {
            get { return id_operadora; }
            set { id_operadora = value; }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                return new Rectangle(base.DisplayRectangle.Location,
                                     new Size(base.DisplayRectangle.Size.Width,
                                              base.DisplayRectangle.Size.Height - button1.Height));
            }
        }

     
        
        public event EventHandler<DataEventArgs> OnAsignacion;

        public event EventHandler<SlidePanelEventArgs> StateChanged;
        public event EventHandler<SlidePanelEventArgs> StateChanging;

        //[Category("Appearance"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public override string Text
        //{
        //    get
        //    {
        //        return label1.Text;
        //    }
        //    set
        //    {
        //        label1.Text = value;
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            int num = MaxHeight/mult;
            mult *= 2;
            if (arriba)
            {
                if (Height - num <= mainbtn.Height)
                {
                    Height = button1.Height;
                    timer1.Stop();
                    collapsed = true;
                    OnStateChanged(true);
                    button1.ImageIndex = 0;
                }
                else
                {
                    Height -= num;
                }
            }
            else
            {
                if (Height + num >= maxHeight)
                {
                    Height = maxHeight;
                    timer1.Stop();
                    collapsed = false;
                    OnStateChanged(false);
                    button1.ImageIndex = 1;
                }
                else
                {
                    Height += num;
                }
            }
        }

        private void OnStateChanged(bool p)
        {
            if (StateChanged != null)
            {
                StateChanged(this, new SlidePanelEventArgs(p));
            }
        }

        private void SlidePanel_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                DBNotifyListeners.RegisterListener(OnExpedienteInsertHandler);
                Height = mainbtn.Height;
                collapsed = true;
                OnStateChanged(true);
                button1.ImageIndex = 0;
                // expedientes
                ContarExp();
                // carros cubriendo
                VerificarCubriendo();
            }
        }


        private void SlidePanel_SizeChanged(object sender, EventArgs e)
        {
            mainbtn.Location = new Point(0, Height - button1.Height);
            mainbtn.Width = Width;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            mult = 2;
            if (collapsed)
            {
                arriba = false;
                OnStateChanging(true);
                timer1.Start();
            }
            else
            {
                arriba = true;
                OnStateChanging(false);
                timer1.Start();
            }
        }

        private void OnStateChanging(bool isCollapsed)
        {
            if (StateChanging != null)
            {
                StateChanging(this, new SlidePanelEventArgs(isCollapsed));
            }
        }

        private void OnExpedienteInsertHandler(object sender, ListenerEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("onExpInsHandler");

            if (e.Event == "insertexpediente" || e.Event == "updateexpediente")
            {
                Invoke(new TContarExp(ContarExp));
            }
            if (e.Event == "z_carros")
            {
                Invoke(new TContarExp(VerificarCubriendo));
            }
        }

        private void VerificarCubriendo()
        {
            DataSet ds = new z_carros().GetCarrosCubriendo();
            lblInfo.Text = ds.Tables[0].Rows.Count != 0 ? "Hay carros Cubriendo Cuarteles" : "";
        }

        private void ContarExp()
        {
            int num = new e_expedientes().Gete_expedientes_operadora(0).Tables[0].Rows.Count;
            //btnExpedientes.Text = string.Format((string)btnExpedientes.Tag, num);
            switch (num)
            {
                case 0:
                    btnExpedientes.Text = "Sin Expedientes";
                    break;
                case 1:
                    btnExpedientes.Text = "1 Expediente";
                    break;
                default:
                    btnExpedientes.Text = string.Format("{0} Expedientes", num);
                    break;
            }
            if (num > 0)
            {
                timer2.Start();
            }
            else
            {
                timer2.Stop();
                btnExpedientes.BackColor = DefaultBackColor;
            }
        }


        private void onMenuClick(object sender, EventArgs e)
        {
            // asignar expediente a operadora
            if (id_operadora == 0)
            {
                MessageBox.Show("La operadora actual no es válida. No se puede asignar el expediente", "Mensaje de ZEUS");
                return;
            }

            e_expedientes exp = new e_expedientes().getObjecte_expedientes((int) ((ToolStripMenuItem) sender).Tag);
            if (exp.id_expediente == 0)
            {
                MessageBox.Show("El expediente seleccionado ya no es válido. No se puede asignar el expediente",
                                "Mensaje de ZEUS");
                return;
            }

            /*if (exp.id_operadora != 0)
            {
                MessageBox.Show(
                    "El expediente seleccionado ya ha sido asignado a otra operadora. No se puede asignar el expediente",
                    "Mensaje de ZEUS");
                return;
            }*/

            exp.id_operadora = id_operadora;
            exp.Update(exp);
            //ContarExp();

            // avisar
            if (OnAsignacion != null)
            {
                OnAsignacion(this, new DataEventArgs(exp.id_expediente));
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            btnExpedientes.BackColor = link ? Color.Red : DefaultBackColor;
            link = !link;
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            var gc = new GestionCarros {ZeusWin = ZeusWin};
            gc.ShowDialog();
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            var re = new AdministrarExpediente {IdOperadora = id_operadora};
            re.ShowDialog();
        }

        private void btnExpedientes_Click(object sender, EventArgs e)
        {
            // crear menú con expedientes
            var menu = new ContextMenuStrip();
            DataSet ds = new e_expedientes().Gete_expedientes_operadora(0);
            foreach (DataRow dr in ds.Tables[0].Select("", "fecha desc"))
            {
                var tm = new ToolStripMenuItem(dr["clave"] + " " + dr["seis2"] + " / " + dr["cero5"], null,
                                                             onMenuClick);
                tm.Tag = dr["id_expediente"];
                menu.Items.Add(tm);
            }
            menu.Show(btnExpedientes, 0, btnExpedientes.Height);
        }

        private void lblInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
#if CBQN
            //MessageBox.Show("Este módulo no se encuentra disponible en esta versión del Sistema Zeus",
            //                "Módulo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
            CubrirCuarteles cc = new CubrirCuarteles();
            cc.ZeusWin = this.ZeusWin;
            cc.ShowDialog();
#endif
        }

        #region Nested type: TContarExp

        private delegate void TContarExp();

        #endregion

        private void btnGps_Click(object sender, EventArgs e)
        {
            frmGps gps = new frmGps();
            gps.ShowDialog();

            //LiberarConductores LibCond = new LiberarConductores();
            //LibCond.ShowDialog();

            //EntregaDeTurno EntregaTur = new EntregaDeTurno();
            //EntregaTur.ShowDialog();

        }
    }
}