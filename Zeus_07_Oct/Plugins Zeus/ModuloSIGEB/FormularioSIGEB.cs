using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Zeus.Data;
using Zeus.Util;
using Zeus.UIElements;
using Zeus.Interfaces;

namespace ModuloSIGEB
{
    public partial class FormularioSIGEB : Form
    {
        private ILog log = LogManager.GetLogger(typeof(FormularioSIGEB));
        public FormularioSIGEB()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void of_delegado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.of_delegado.Checked)
            {
                this.pof_tipo.Visible = true;
                this.pof_nombre.Visible = true;
                this.pof_cuartel.Visible = true;
                this.pof_apepaterno.Visible = true;
                this.pof_apematerno.Visible = true;
            }
            else
            {
                this.pof_tipo.Visible = false;
                this.pof_nombre.Visible = false;
                this.pof_cuartel.Visible = false;
                this.pof_apepaterno.Visible = false;
                this.pof_apematerno.Visible = false;
            }
        }

        private void CargarCarros()
        {
            try
            {
                log.Debug("");
                log.Debug("");
                log.Debug("");
                log.Debug("***************** INICIO DEL LOG ****************");
                log.Debug("Entro al metodo de carga de carros");
                SuspendLayout();
                log.Debug("Se limpia el panel");
                tableLayoutPanel1.SuspendLayout();
                log.Debug("Se genera la suspensión del layoutpanel");
                tableLayoutPanel1.Controls.Clear();
                log.Debug("Se limpia el layout");
                var carro = new z_carros();
                log.Debug("Se instancia la clase Z_CARROS");
                var tipo = new z_tipo_carro();
                log.Debug("Se instancia la clase Z_TIPOCARRO");
                tableLayoutPanel1.ColumnCount = carro.GetMaxCarros() + 1;
                log.Debug("Se instancia la lista de columnas de carros el cual es " + tableLayoutPanel1.ColumnCount.ToString());
                tableLayoutPanel1.RowCount = tipo.getCantidad();

                // cargar tipos de carro y ponerlos

                DataSet ds = tipo.Getz_tipo_carro();
                DataRow[] dr = ds.Tables[0].Select("", "orden");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    log.Debug("ENTRO A LA INTERACION " + i + " DEL FOR");
                    DataSet dc = carro.GetCarrosTipo((int)dr[i]["id_tipo_carro"]);
                    log.Debug("Se recupera el tipo de carros en base al dato " + dr[i]["id_tipo_carro"].ToString() + "");
                    if (dc.Tables[0].Rows.Count > 0)
                    {
                        log.Debug("Se genera el label en base al dato " + (string)dr[i]["tipo_carro_letra"] + "");
                        var lbl = new Label
                        {
                            Text = ((string)dr[i]["tipo_carro_letra"]),
                            Font = new Font(new FontFamily("Arial"), 12),
                            Size = new Size(45, 40),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tableLayoutPanel1.Controls.Add(lbl, i, 0);
                        log.Debug("Se agrega el control al tablelayoutpanel");
                        // carros

                        for (int j = 0; j < dc.Tables[0].Rows.Count; j++)
                        {
                            log.Debug("Se genera el for en la posición " + j + " con los botones de carros");
                            /*var est = new BtnEstadoCarro
                            {
                                Id_carro = ((int)dc.Tables[0].Rows[j]["id_carro"]),
                                Estado = ((int)dc.Tables[0].Rows[j]["estado"]),
                                Text = ((string)dc.Tables[0].Rows[j]["nombre"])
                            };*/
                            CheckBox chk = new CheckBox();
                            chk.Text = ((string)dc.Tables[0].Rows[j]["nombre"]);
                            log.Debug("Se busca el control");
                            log.Debug("Se asigna al control button el boton recuperado del panel");
                            //btn_evento.Click += new EventHandler(btn_evento_Click);
                            log.Debug("Se asigna el evento OnClick al boton");
                            tableLayoutPanel1.Controls.Add(chk, i, j + 1);
                            log.Debug("Se agrega el boton en el tablelayoutpanel");
                        }
                    }
                    log.Debug("Se finaliza el FOR");
                }
                tableLayoutPanel1.ResumeLayout();
                ResumeLayout();
                log.Debug("************ FIN DEL PROCESO DE CREACIÓN DE CARROS PARA MATERIAL MAYOR *******************");
                log.Debug("");
                log.Debug("");
                log.Debug("");
            }
            catch (Exception exe)
            {
                log.Error("Se ha generado el siguiente error: " + exe.Message);
                log.Error("Se genera la traza del error" + exe.StackTrace);
            }
        }

        private void FormularioSIGEB_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCarros();
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }
    }
}
