using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class OficialCargo : Form
    {
        private int id_expediente;

        private int num_llamado;

        public OficialCargo()
        {
            InitializeComponent();
        }

        public int IdExpediente
        {
            get { return id_expediente; }
            set { id_expediente = value; }
        }

        public int NumLlamado
        {
            get { return num_llamado; }
            set { num_llamado = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
            //exp.id_voluntario = (int) dr[0]["id_voluntario"];
            exp.cargo_llamado = textNumero.Text;
            exp.Update(exp);
            //num_llamado = d;
            DialogResult = DialogResult.OK;
            Close();

            /*
            int d;
            if (int.TryParse(textNumero.Text, out d))
            {
                try
                {
                    DataRow[] dr = new z_cargos().Getz_cargos().Tables[0].Select("llamado_oficial=" + d);
                    if (dr.Length > 0)
                    {
                        e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
                        exp.id_voluntario = (int) dr[0]["id_voluntario"];
                        exp.Update(exp);
                        num_llamado = d;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("El número introducido no corresponde a un oficial válido", "Mensaje de Zeus");
                    }
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
            else
            {
                MessageBox.Show("Debe introducir un número válido", "Mensaje de Zeus");
            }
            */
        }
    }
}