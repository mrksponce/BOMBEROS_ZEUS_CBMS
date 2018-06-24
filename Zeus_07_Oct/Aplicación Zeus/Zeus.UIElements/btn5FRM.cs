using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.UIElements;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class btn5FRM : Form
    {
        private int idArea;
        private int idExpediente;

        public int IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }

        public int IdExpediente
        {
            get { return idExpediente; }
            set { idExpediente = value; }
        }
        

        public btn5FRM()
        {
            InitializeComponent();
        }

        private void iforestalBtn1_Click(object sender, EventArgs e)
        {

            try
            {
                z_carros carros = new z_carros();
                switch (((Button)sender).Name)
                {
                    case "iebtn1":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaUno");
                        vEstatica.Variable = 3;
                        DatosLogin.InvokeTwitter = "FT3";
                        generarDespachoRanking(57);
                        break;
                    case "iebtn2":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaDos");
                        DatosLogin.InvokeTwitter = "FT4";
                        generarDespachoRanking(58);
                        break;
                    case "iebtn3":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaTres");

                        DatosLogin.InvokeTwitter = "FT5";
                        generarDespachoRanking(59);
                        break;
                    case "iebtn4":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaCuatro");
                        DatosLogin.InvokeTwitter = "FT6";
                        generarDespachoRanking(60);
                        break;
                    case "iebtn5":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaCinco");
                        DatosLogin.InvokeTwitter = "FT7";
                        generarDespachoRanking(61);
                        break;
                    case "iebtn6":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaSeis");
                        DatosLogin.InvokeTwitter = "FT8";
                        generarDespachoRanking(62);
                        break;
                    case "iebtn7":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaSiete");
                        DatosLogin.InvokeTwitter = "FT9";
                        generarDespachoRanking(63);
                        break;
                    case "iebtn8":
                        carros.InsertarDespachoAlarmas(RecursosEstaticos.IdExpediente, "AlarmaOcho");
                        DatosLogin.InvokeTwitter = "FT3";
                        generarDespachoRanking(90);
                        break;

                }
            }
            catch (Exception exe)
            {

            }
        }

        private void generarDespachoRanking(int codigoLlamado)
        {
            string sindesp = "";
            Zeus.Data.e_expedientes expediente = new Zeus.Data.e_expedientes();
            int bloque = expediente.recFechaExpediente(this.IdExpediente);

            List<int> id_carros = Zeus.Util.Despacho.rakingParaIncendio(this.IdExpediente, this.IdArea, bloque, codigoLlamado);

            var cd = new ConfirmarDespacho
            {
                IdCarros = id_carros,
                IdExpediente = this.IdExpediente,
                IdArea = this.IdArea
            };
            cd.lblSinDesp.Text += "\n" + sindesp;
            cd.Batallon = 1;
            cd.ShowDialog();
        }

        private void btn5FRM_Load(object sender, EventArgs e)
        {
            try
            {

                z_carros carros = new z_carros();
                foreach (DataRow row in carros.GetDespachoAlarmas(RecursosEstaticos.IdExpediente).Tables[0].Rows)
                {
                    if (row["alarma"].ToString() == "AlarmaUno")
                    {
                        iebtn1.BackColor = Color.Red;
                        continue;
                    }

                    if (row["alarma"].ToString() == "AlarmaDos")
                    {
                        iebtn2.BackColor = Color.Red;
                        continue;
                    }

                    if (row["alarma"].ToString() == "AlarmaTres")
                    {
                        iebtn3.BackColor = Color.Red;
                        continue;
                    }

                    if (row["alarma"].ToString() == "AlarmaCuatro")
                    {
                        iebtn4.BackColor = Color.Red;
                        continue;
                    }

                    if (row["alarma"].ToString() == "AlarmaCinco")
                    {
                        iebtn5.BackColor = Color.Red;
                        continue;
                    }

                    if (row["alarma"].ToString() == "AlarmaSeis")
                    {
                        iebtn6.BackColor = Color.Red;
                        continue;
                    }

                    if (row["alarma"].ToString() == "AlarmaSiete")
                    {
                        iebtn7.BackColor = Color.Red;
                        continue;
                    }

                    if (row["alarma"].ToString() == "AlarmaOcho")
                    {
                        iebtn8.BackColor = Color.Red;
                        continue;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
