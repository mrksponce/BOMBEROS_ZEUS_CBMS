using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class InformacionExpediente : UserControl
    {
        private e_expedientes expediente;

        public InformacionExpediente()
        {
            InitializeComponent();
        }

        public e_expedientes Expediente
        {
            get { return expediente; }
            set
            {
                expediente = value;
                if (expediente != null)
                {
                    MostrarInfo(expediente);
                }
            }
        }

        public object ComunasDataSource
        {
            get { return textComuna.DataSource; }
            set { textComuna.DataSource = value; }
        }


        private void MostrarInfo(e_expedientes exp)
        {
            textArea.Text = exp.id_area.ToString();
            textBatallon.Text = exp.batallon.ToString();
            text62.Text = exp.seis2;
            text05.Text = exp.cero5;
            textComuna.SelectedValue = exp.comuna;
            textGeoz.Text = exp.geoz;
            textCasa.Text = exp.casa;
            textBlock.Text = exp.block;
            textVilla.Text = exp.poblacion_villa;
            textTelefono.Text = exp.telefono;
            textQuienLlama.Text = exp.quien_llama;
            textFechaHoraAlarma.Text = exp.fecha.ToString();
            textAsisten.Text = exp.asisiten.ToString();
            // correlativos
            textCorrelativo.Text = exp.correlativo.ToString();
            if (exp.correlativo_iioo != 0)
            {
                textCorrelativoIIOO.Text = exp.correlativo_iioo.ToString();
            }
            else
            {
                textCorrelativoIIOO.Text = "";
            }
            if (exp.correlativo_redtic != 0)
            {
                textCorrelativoRedTIC.Text = exp.correlativo_redtic.ToString();
            }
            else
            {
                textCorrelativoRedTIC.Text = "";
            }

            textFechaHoraRetirada.Text = exp.fecha_retirada != DateTime.MinValue ? exp.fecha_retirada.ToString() : "";

            textOrigen.Text = exp.origen;
            textCausa.Text = exp.causa;
            textObservaciones.Text = exp.observaciones;

            piso.Text = exp.Piso;
            asistenciaCompania.Text = exp.AsistenciaPorCompania;
            informeIngresado.Text = exp.InformeIngresado;
            volCompanias.Text = exp.AsistenciaVoluntariosOtrasCompanias;
            lesionadosActosServicio.Text = exp.LesionadosActoServicio;
            origenAlarma.Text = exp.OrigenAlamarma;


            // clave
            z_llamados llam = new z_llamados().getObjectz_llamados(exp.codigo_llamado);
            textClave.Text = llam.clave + " " + llam.descripcion;

            // oficial a cargo
            //if (exp.id_voluntario != 0)
            //{
            //    z_cargos cargo = new z_cargos().getObjectz_cargos(exp.id_voluntario);
            //    z_voluntarios vol = new z_voluntarios();
            //    vol = vol.getObjectz_voluntarios(cargo.id_voluntario);
            //    textACargo.Text = vol.apellidos + " " + vol.nombres;
            //}
            //else
            //{
            //    textACargo.Text = "Ninguno";
            //}
            textACargoLlamado.Text = exp.cargo_llamado;
            textACargoInforme.Text = exp.cargo_informe;
            textCiaCargoInf.Text = exp.cia_cargo_informe;
        }

        private void btnClave_Click(object sender, EventArgs e)
        {
            Claves c = new Claves();
            //e_expedientes exp = new e_expedientes().getObjecte_expedientes(id_expediente);
            c.CodigoPrincipal = expediente.codigo_principal;
            c.CodigoLlamado = expediente.codigo_llamado;
            if (c.ShowDialog() == DialogResult.OK)
            {
                string prevClave = textClave.Text;
                expediente.codigo_llamado = c.CodigoLlamado;
                expediente.codigo_principal = c.CodigoPrincipal;
                try
                {
                    expediente.Update(expediente);
                    MostrarInfo(expediente);
                    BitacoraLlamado.NuevoEvento(expediente.id_expediente, BitacoraLlamado.Llamado,
                                                string.Format(
                                                    "Por orden del Oficial a Cargo, se cambia la clave {0} a {1}",
                                                    prevClave, c.Clave));
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                // actualizar!
                if (textFechaHoraAlarma.Text != "")
                {
                    expediente.hora = DateTime.Parse(textFechaHoraAlarma.Text);
                    expediente.fecha = DateTime.Parse(textFechaHoraAlarma.Text);
                }

                if (textFechaHoraRetirada.Text != "")
                {
                    expediente.hora_retirada = expediente.fecha_retirada = DateTime.Parse(textFechaHoraRetirada.Text);
                }

                if (textCorrelativo.Text != "")
                {
                    expediente.correlativo = int.Parse(textCorrelativo.Text);
                }

                if (textCorrelativoIIOO.Text != "")
                {
                    expediente.correlativo_iioo = int.Parse(textCorrelativoIIOO.Text);
                }

                if (textCorrelativoRedTIC.Text != "")
                {
                    expediente.correlativo_redtic = int.Parse(textCorrelativoRedTIC.Text);
                }

                expediente.compania = textCompania.Text;
                expediente.casa = textCasa.Text;
                expediente.comuna = textComuna.Text;
                expediente.block = textBlock.Text;
                expediente.telefono = textTelefono.Text;
                expediente.poblacion_villa = textVilla.Text;
                expediente.quien_llama = textQuienLlama.Text;
                expediente.causa = textCausa.Text;
                expediente.origen = textOrigen.Text;
                expediente.observaciones = textObservaciones.Text;
                expediente.seis2 = text62.Text;
                expediente.cero5 = text05.Text;
                expediente.asisiten = int.Parse(textAsisten.Text);
                expediente.cargo_informe = textACargoInforme.Text;
                expediente.cia_cargo_informe = textCiaCargoInf.Text;
                expediente.fuente_calor = textFuenteCalor.Text;
                expediente.cargo_llamado = textACargoLlamado.Text;

                expediente.AsistenciaPorCompania = asistenciaCompania.Text;
                expediente.Piso = piso.Text;
                expediente.OrigenAlamarma = origenAlarma.Text;
                expediente.LesionadosActoServicio = lesionadosActosServicio.Text;
                expediente.InformeIngresado = informeIngresado.Text;
                expediente.AsistenciaVoluntariosOtrasCompanias = volCompanias.Text;

                try
                {
                    expediente.Update(expediente);
                    MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
            }
        }

        private bool Validar()
        {
            string msg = "La siguiente información falta o tiene formato incorrecto:\n";
            bool ok = true;
            DateTime d;
            int x;

            if (textFechaHoraAlarma.Text != "" && !DateTime.TryParse(textFechaHoraAlarma.Text, out d))
            {
                msg += "* Fecha/Hora Alarma" + "\n";
                ok = false;
            }

            if (textFechaHoraRetirada.Text != "" && !DateTime.TryParse(textFechaHoraRetirada.Text, out d))
            {
                msg += "* Fecha Retirada" + "\n";
                ok = false;
            }

            if (textCompania.Text != "" && !int.TryParse(textCompania.Text, out x))
            {
                msg += "* Compañía" + "\n";
                ok = false;
            }

            if (textAsisten.Text != "" && !int.TryParse(textAsisten.Text, out x))
            {
                msg += "* Cantidad de asistentes" + "\n";
                ok = false;
            }


            if (!int.TryParse(textCorrelativo.Text, out x))
            {
                msg += "* Correlativo" + "\n";
                ok = false;
            }

            if (textCorrelativoIIOO.Text != "" && !int.TryParse(textCorrelativoIIOO.Text, out x))
            {
                msg += "* Correlativo Incendio" + "\n";
                ok = false;
            }

            if (textCorrelativoRedTIC.Text != "" && !int.TryParse(textCorrelativoRedTIC.Text, out x))
            {
                msg += "* Correlativo RedTIC" + "\n";
                ok = false;
            }

            if (!ok)
            {
                MessageBox.Show(msg, "Error en validación");
            }
            return ok;
        }

        private void InformacionExpediente_Load(object sender, EventArgs e)
        {
            textComuna.DisplayMember = "comuna";
            textComuna.ValueMember = "comuna";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCorrelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textCorrelativo.Text != "")
                {
                    try
                    {
                        //var JsUpExp = new JsonUpdateExpedienteClave();
                        //JsUpExp.ApoloUpdateExpediente("241719","correla","123");
                        JsonUpdateExpedienteClave.ApoloUpdateExpediente("14733", "calle", textCorrelativo.Text);
                        MessageBox.Show("Se ha actualizado en ZEUS Web CALLE", "GEObit");
                    }
                    catch (Exception ex)
                    {
                        Log.ShowAndLog(ex);
                    }
                }
                else
                {
                    MessageBox.Show("No ha ingresado un número de expediente..");
                }
            }

        }
    }
}