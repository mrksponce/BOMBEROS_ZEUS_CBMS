using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;

namespace ResumenEmergencias
{
    public partial class FrmActualizarHora : Form
    {
        private static int Correlativo { get; set; }
        private static string Hora { get; set; }
        private static string IdExpediente { get; set; }
        private static string LblCarro { get; set; }
        private static string Fecha { get; set; }

        public FrmActualizarHora(int correlativo, string hora, string idExpediente, string lblCarro, string fecha, string seis_cero, string seis_siete, string seis_ocho, string seis_nueve, string seis_dies)
        {
            InitializeComponent();
            LblCarro = lblCarro;
            IdExpediente = idExpediente;
            textBox1.Text = LblCarro;
            textBox2.Text = seis_cero;
            textBox3.Text = hora;
            textBox4.Text = seis_siete;
            textBox5.Text = seis_ocho;
            textBox6.Text = seis_nueve;
            textBox7.Text = seis_dies;

            

            
        }

        private void FrmActualizarHora_Load(object sender, EventArgs e)
        {

        }


        protected bool ValidarNumeros(string cadena)
        {
            bool esNumero;
            string[] cadena_split = cadena.Split(':');
            try
            {
                Convert.ToInt32(cadena_split[0]);
                Convert.ToInt32(cadena_split[1]);

                esNumero = true;
            }
            catch (Exception exe)
            {
                esNumero = false;
            }
            return esNumero;
        }

        protected bool ValidarFecha(string cadena)
        {
            bool FechaOK;

            int NumeroDeCaracteres = cadena.Length;
            if (NumeroDeCaracteres == 5 || NumeroDeCaracteres == 4 || cadena == "-")
            {
                if (cadena.IndexOf(":") == 2 || cadena == "-")
                {
                    if (ValidarNumeros(cadena) || cadena == "-")
                    {
                        FechaOK = true;
                    }
                    else
                    {
                        FechaOK = false;
                    }
                }
                else
                {
                    FechaOK = false;
                }
            }
            else
            {
                FechaOK = false;
            }

            return FechaOK;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bitacora_llamados bllamados = new bitacora_llamados();
            z_carros carros = new z_carros();

            string seis_cero_final = "";
            string seis_tres_final ="";
            string seis_siete_final = "";
            string seis_ocho_final = "";
            string seis_nueve_final = "";
            string seis_dies_final = "";

            string fecha = bllamados.RecuperarFechaExpediente(IdExpediente);
            string[] fecha_split = fecha.Split(' ');

            //MessageBox.Show("GEObit   Ok... ", "GEObit  :)  ");


            if (ValidarFecha(textBox2.Text) && ValidarFecha(textBox3.Text) && ValidarFecha(textBox4.Text) && ValidarFecha(textBox5.Text) && ValidarFecha(textBox6.Text) && ValidarFecha(textBox7.Text) && LblCarro != "")
            {
                //MessageBox.Show("Todas estan Ok... ", "Alerta!!");


                if (textBox2.Text != "-")
                {
                    seis_cero_final = fecha_split[0] + " " + textBox2.Text + ":00";
                }

                if (textBox3.Text != "-")
                {
                    seis_tres_final = fecha_split[0] + " " + textBox3.Text + ":00";
                }

                if (textBox4.Text != "-")
                {
                    seis_siete_final = fecha_split[0] + " " + textBox4.Text + ":00";
                }

                if (textBox5.Text != "-")
                {
                    seis_ocho_final = fecha_split[0] + " " + textBox5.Text + ":00";
                }

                if (textBox6.Text != "-")
                {
                    seis_nueve_final = fecha_split[0] + " " + textBox6.Text + ":00";
                }

                if (textBox7.Text != "-")
                {
                    seis_dies_final = fecha_split[0] + " " + textBox7.Text + ":00";
                }

                int idCarro = Convert.ToInt32(carros.ObtenerIdCarro(LblCarro));

                if ((textBox2.Text.Split(':').Length == 2 || textBox2.Text == "-") && (textBox3.Text.Split(':').Length == 2 || textBox3.Text == "-") && (textBox4.Text.Split(':').Length == 2 || textBox4.Text == "-") && (textBox5.Text.Split(':').Length == 2 || textBox5.Text == "-") && (textBox6.Text.Split(':').Length == 2 || textBox6.Text == "-") && (textBox7.Text.Split(':').Length == 2 || textBox7.Text == "-"))
                {
                    //if ((Convert.ToInt32(textBox2.Text.Split(':')[0]) >= 0 && Convert.ToInt32(textBox2.Text.Split(':')[0]) <= 23 && Convert.ToInt32(textBox2.Text.Split(':')[1]) >= 0 && Convert.ToInt32(textBox2.Text.Split(':')[1]) <= 59))
                    //{
                    bllamados.ActualizarClave(Convert.ToInt32(IdExpediente), idCarro, seis_cero_final, seis_tres_final, seis_siete_final, seis_ocho_final, seis_nueve_final, seis_dies_final);
                    DialogResult = DialogResult.OK;
                    //}
                }
                else
                {
                    MessageBox.Show("Se esta ingresando una hora con formato incorrecto, por favor intentelo nuevamente.", "Alerta!!");
                    DialogResult = DialogResult.Cancel;
                }



            }
            else
            {
                MessageBox.Show("Alguna hora esta mal ingresada...   ", "Alerta!!");
            }


        }
    }
}
