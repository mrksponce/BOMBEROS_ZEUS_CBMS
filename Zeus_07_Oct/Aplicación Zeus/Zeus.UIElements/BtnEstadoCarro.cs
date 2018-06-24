using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class BtnEstadoCarro : BaseControl
    {
        private int estado;
        private int id_carro;

        public BtnEstadoCarro()
        {
            InitializeComponent();
            label3.Visible = false;
        }


        [Category("Appearance"), Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return button1.Text; }
            set { button1.Text = value; }
        }

        public int Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                var ec = new z_estado_carros();
                z_companias comp = new z_companias();
                ec = ec.getObjectz_estado_carros(estado);
                z_carros carro = new z_carros().getObjectz_carros(id_carro);
                button1.Name = "c_" + carro.nombre;
                if (carro.Carros_011 = true && carro.Evento == "IDA")
                {
                    string[] split_coordenadas = carro.ObtenerCoordenadasCarro(carro.id_carro).Split('#');
                    string nombreCompania = comp.ObtenerCompaniaPorCoordenada(Convert.ToInt32(split_coordenadas[0]), Convert.ToInt32(split_coordenadas[1]));
                    label3.Visible = true;
                    label1.Text = ec.descripcion;
                    label3.Text = "0-11 en " + nombreCompania;
                }
                else
                {
                    label3.Visible = false;
                    label1.Text = ec.descripcion;
                    label3.Text = "";
                }

                if (carro.Carros_011 = true && carro.Evento == "RETORNO")
                {
                    string[] split_coordenadas = carro.ObtenerCoordenadasCarro(carro.id_carro).Split('#');
                    string nombreCompania = comp.ObtenerCompaniaPorCoordenada(Convert.ToInt32(split_coordenadas[0]), Convert.ToInt32(split_coordenadas[1]));
                    label3.Visible = true;
                    label3.Text = "0-11 En retorno a " + nombreCompania;
                }
                
                switch (estado)
                {
                    case 1:
                        button1.BackColor = Color.PaleGreen;
                        break;
                    case 2:
                        button1.BackColor = Color.Tomato;
                        label1.Text += ": " + carro.motivo_fuera_servicio;
                        break;
                    case 3:
                        button1.BackColor = Color.Yellow;
                        break;
                    case 4:
                    case 5:
                        button1.BackColor = Color.LightBlue;
                        break;
                    default:
                        break;
                }
                
                
            }
        }

        public int Id_carro
        {
            get { return id_carro; }
            set { id_carro = value; }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            var carro = new z_carros();
            carro = carro.getObjectz_carros(id_carro);
            switch (((ToolStripMenuItem) sender).Name)
            {
                case "CS_C":
                    Estado = 3;
                    Carro.SinConductor(carro.id_carro);
                    BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                "Carro: " + carro.nombre + " " + label1.Text);
                    break;
                default:
                    break;
            }
        }

        private void MenuEstadoCarros_Opening(object sender, CancelEventArgs e)
        {
            /*z_carros carro = new z_carros().getObjectz_carros(id_carro);
            // Conductor actual
            
            if (carro.Observacion2 != "" && carro.OpObservacion2 != "")
            {
                tsmObservacion.Text = "Observación: " + carro.Observacion2;
                tsmUsuario.Text = "Ingresado por : " + carro.OpObservacion2;
                tsmIngresoObs.Text = carro.Observacion2;

            }  

            if (carro.id_conductor != 0)
            {
                // poner codigo y nombre del cond.
                z_conductores cond = new z_conductores().getObjectz_conductores(carro.id_conductor);
                string nombre;
                if (cond.id_tipo_conductor == 1)
                {
                    z_cuarteleros cuart = new z_cuarteleros().getObjectz_cuarteleros(cond.id_cuart_vol);
                    nombre = cuart.apellidos + " " + cuart.nombres;
                }
                else
                {
                    z_voluntarios vol = new z_voluntarios().getObjectz_voluntarios(cond.id_cuart_vol);
                    nombre = vol.apellidos + " " + vol.nombres;
                }

                info.Text = "(" + cond.codigo_conductor + ") " + nombre;


            }
            else
            {
                info.Text = "Sin Conductor";
            }

            // Rellenar conductores posibles
            DataSet ds = new z_conductores().Getz_conductoresCarro(id_carro);
            enServicioToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var m = new ToolStripMenuItem((string) dr["nombre_completo"], null, Conductor_click);
                // no disponible
                if ((bool) dr["disponible"] == false)
                {
                    m.Enabled = false;
                }

                m.Tag = dr["id_conductor"];
                if (carro.id_conductor == (int) dr["id_conductor"])
                {
                    m.Checked = true;
                }
                m.ForeColor = (int) dr["id_tipo_conductor"] == 1 ? Color.ForestGreen : Color.Goldenrod;

                enServicioToolStripMenuItem.DropDownItems.Add(m);
            }*/
        }

        private void Conductor_click(object sender, EventArgs e)
        {
            // poner en servicio
            var id_conductor = (int) ((ToolStripMenuItem) sender).Tag;
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            var carros = new List<int> {carro.id_carro};

            if (carro.estado == 1 && carro.id_conductor != 0)
            {
                // fuera de servicio con cond. actual
                Conductor.FueraServicio(carro.id_conductor, carros);
            }

            Conductor.PuestaEnServicio(id_conductor, carros, null);
            Estado = 1;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (toolStripTextBox1.Text != "")
                {
                    Carro.FueraServicio(id_carro, toolStripTextBox1.Text);
                    Estado = 2;
                    BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                                "Carro: " + Text + " Fuera de Servicio (" + toolStripTextBox1.Text + ")");
                    menuEstadoCarros.Close();
                }
            }
        }

        private void FueraServicioMenuItem_Click(object sender, EventArgs e)
        {
            Carro.FueraServicio(id_carro, ((ToolStripMenuItem) sender).Text);
            Estado = 2;
            BitacoraGestion.NuevoEvento(ZeusWin.IdOperadora, ZeusWin.IdAval,
                                        "Carro: " + Text + " Fuera de Servicio (" + ((ToolStripMenuItem) sender).Text +
                                        ")");
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left && Estado != 4 && Estado != 5)
            {
                menuEstadoCarros.Show(this, 0, button1.Size.Height);
            }*/
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Right && (Estado == 4 || Estado == 5))
            {
                menuLiberarCarro.Show(this, 0, button1.Size.Height);
            }*/
        }

        private void liberarCarroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Preguntar antes de liberar
            if (
                MessageBox.Show(
                    "'Liberar Carro' debe ser utilizado sólo como medida de emergencia, ¿Está seguro que desea liberar este carro?",
                    "Liberar Carro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    // liberar carro
                    Carro.Liberar(id_carro);
                    var cu = new e_carros_usados();
                    cu = cu.getObjecte_carros_usados(id_carro);
                    cu.freee_carros_usados(cu.id_carro);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void menuLiberarCarro_Opening(object sender, CancelEventArgs e)
        {
            /*z_carros carro = new z_carros().getObjectz_carros(id_carro);
            // Conductor actual
            if (carro.id_conductor != 0)
            {
                // poner codigo y nombre del cond.
                z_conductores cond = new z_conductores().getObjectz_conductores(carro.id_conductor);
                string nombre;
                if (cond.id_tipo_conductor == 1)
                {
                    z_cuarteleros cuart = new z_cuarteleros().getObjectz_cuarteleros(cond.id_cuart_vol);
                    nombre = cuart.apellidos + " " + cuart.nombres;
                }
                else
                {
                    z_voluntarios vol = new z_voluntarios().getObjectz_voluntarios(cond.id_cuart_vol);
                    nombre = vol.apellidos + " " + vol.nombres;
                }
                toolStripMenuItem1.Text = "(" + cond.codigo_conductor + ") " + nombre;

               
            }
            else
            {
                toolStripMenuItem1.Text = "Sin Conductor";
            }*/
        }

        private void toolStripTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                z_carros carro = new z_carros();
                carro.ActualizarObservacionesCarros(tsmIngresoObs.Text, ZeusWin.Usuario, id_carro);
                menuEstadoCarros.Close();
            }
        }
    }
}