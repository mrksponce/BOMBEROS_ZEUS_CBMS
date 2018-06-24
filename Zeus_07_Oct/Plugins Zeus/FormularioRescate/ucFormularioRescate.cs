using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;
using System.IO;
using OfficeOpenXml;

namespace FormularioRescate
{
    public partial class ucFormularioRescate : UserControl
    {
        public ucFormularioRescate()
        {
            InitializeComponent();
        }

        private void ucFormularioRescate_Load(object sender, EventArgs e)
        {
            try
            {
                e_expedientes expediente = new e_expedientes();
                ClaseFormularioRescate fRescate = new ClaseFormularioRescate();
                k_comuna comuna = new k_comuna();
                k_areas area = new k_areas();

                string primerCarroLlegada = fRescate.ObtenerPrimerCarroEnLlegar(RecursosEstaticos.IdExpediente);
                if (primerCarroLlegada != "")
                {
                    txtHoraLlegadaPrimerCarro.Text = Convert.ToDateTime(primerCarroLlegada).ToString("HH:mm");
                }

                string horaDeTermino = fRescate.ObtenerHoraDeTermino(RecursosEstaticos.IdExpediente);
                if (horaDeTermino != "")
                {
                    txtHoraTermino.Text = Convert.ToDateTime(horaDeTermino).ToString("HH:mm");
                }

                expediente = expediente.getObjecte_expedientes(RecursosEstaticos.IdExpediente);

                // Fecha formulario
                txtDia.Text = expediente.fecha.Day.ToString();        
                txtMes.Text = expediente.fecha.Month.ToString();
                txtAnio.Text = expediente.fecha.Year.ToString();

                // Antecedentes UBICACIÓN RELATIVA DEL LUGAR
                //ddlComunaEmergencia.DataSource = comuna.Getk_comuna().Tables[0];
                //ddlComunaEmergencia.DisplayMember = "comuna";
                //ddlComunaEmergencia.ValueMember = "gid";

                txtDireccionEmergencia.Text = expediente.cero5;
                txtEsquinaEmergencia.Text = expediente.seis2;
                ddlComunaEmergencia.Text = expediente.comuna;

                // Atecedentes MATERIAL MAYOR CONCURRENTE
                label175.Text = expediente.material_despachado;

                CargarFormulario();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void CargarFormulario()
        { 
            ClaseFormularioRescate fRescate = new ClaseFormularioRescate();
            DataSet dsfrEncabezado = fRescate.ObtenerFormularioRescateEncabezado(RecursosEstaticos.IdExpediente);
            DataSet dsfrVehiculosInvolucrados = fRescate.ObtenerFormularioRescateVehiculosInvolucrados(RecursosEstaticos.IdExpediente);
            DataSet dsfrLesionadosFallecidos = fRescate.ObtenerFormularioRescateLesionadosFallecidos(RecursosEstaticos.IdExpediente);
            DataSet dsfrServicioPolicial = fRescate.ObtenerFormularioRescateServicioPolicial(RecursosEstaticos.IdExpediente);
            DataSet dsfrServicioMedico = fRescate.ObtenerFormularioRescateServicioMedico(RecursosEstaticos.IdExpediente);
            DataSet dsfrDescripcion = fRescate.ObtenerFormularioRescateDescripcion(RecursosEstaticos.IdExpediente);

            #region Encabezado
            if (!dsfrEncabezado.Tables[0].Rows.Count.Equals(0))
            {
                foreach (DataRow row in dsfrEncabezado.Tables[0].Rows)
                {
                    txtNumeroEmergencia.Text = row["frente_numero"].ToString();
                    txtSectorEmergencia.Text = row["sector"].ToString();
                    txtEsquinaEmergencia.Text = row["esquina"].ToString();

                    ddlComunaEmergencia.Text = row["comuna"].ToString();

                    // Llenado de tipo de vía
                    if (row["tipo_de_via"].ToString().Equals(rbTVRecta.Text))
                    {
                        rbTVRecta.Checked = true;
                    }

                    if (row["tipo_de_via"].ToString().Equals(rbTVTunel.Text))
                    {
                        rbTVTunel.Checked = true;
                    }

                    if (row["tipo_de_via"].ToString().Equals(rbTVPuente.Text))
                    {
                        rbTVPuente.Checked = true;
                    }

                    if (row["tipo_de_via"].ToString().Equals(rbTVCurva.Text))
                    {
                        rbTVCurva.Checked = true;
                    }

                    if (row["tipo_de_via"].ToString().Equals(rbTVAceraBerma.Text))
                    {
                        rbTVAceraBerma.Checked = true;
                    }
                    // fin llenado de tipo de vía

                    // llenado de clasificación de accidente
                    if (row["clasificacion_accidente"].ToString().Equals(rbCaida.Text))
                    {
                        rbCaida.Checked = true;
                    }

                    if (row["clasificacion_accidente"].ToString().Equals(rbChoque.Text))
                    {
                        rbChoque.Checked = true;
                    }

                    if (row["clasificacion_accidente"].ToString().Equals(rbVolcamiento.Text))
                    {
                        rbVolcamiento.Checked = true;
                    }

                    if (row["clasificacion_accidente"].ToString().Equals(rbColision.Text))
                    {
                        rbColision.Checked = true;
                    }

                    if (row["clasificacion_accidente"].ToString().Equals(rbAtropello.Text))
                    {
                        rbAtropello.Checked = true;
                    }

                    // llenado de estado atmosférico
                    if (row["estado_atmosferico"].ToString().Equals(rbNublado.Text))
                    {
                        rbNublado.Checked = true;
                    }

                    if (row["estado_atmosferico"].ToString().Equals(rbDespejado.Text))
                    {
                        rbDespejado.Checked = true;
                    }

                    if (row["estado_atmosferico"].ToString().Equals(rbNeblina.Text))
                    {
                        rbNeblina.Checked = true;
                    }

                    if (row["estado_atmosferico"].ToString().Equals(rbLluvia.Text))
                    {
                        rbLluvia.Checked = true;
                    }

                    // Se llenan los correlativos
                    txtCorrelativoCompania.Text = row["correlativo_compania"].ToString();
                    txtCorrelativoCBPA.Text = row["correlativo_cbpa"].ToString();

                    txtHoraLlegadaPrimerCarro.Text = row["hora_llegada_primer_carro"].ToString();
                    txtHoraLlegadaCarroRescate.Text = row["hora_llegada_carro_rescate"].ToString();
                    txtHoraInicio.Text = row["hora_inicio"].ToString();
                    txtHoraTermino.Text = row["hora_termino"].ToString();
                }
            }
            else
            {
                e_expedientes exp = new e_expedientes().getObjecte_expedientes(RecursosEstaticos.IdExpediente);
                
                string fpc = fRescate.ObtenerPrimerCarroEnLlegar(RecursosEstaticos.IdExpediente);

                if (!fpc.Equals(""))
                {
                    txtHoraLlegadaPrimerCarro.Text = fRescate.ObtenerPrimerCarroEnLlegar(RecursosEstaticos.IdExpediente).Split(' ')[1];
                }
                
                txtHoraLlegadaCarroRescate.Text = "";
                txtHoraInicio.Text = exp.fecha.ToString().Split(' ')[1];
                txtHoraTermino.Text = "";
            }
            #endregion

            #region Vehículos Involucrados
            if (dsfrVehiculosInvolucrados.Tables[0].Rows.Count > 0)
            {
                int contador = 1;
                foreach (DataRow row in dsfrVehiculosInvolucrados.Tables[0].Rows)
                {
                    if (contador == 1)
                    {
                        txtTipoVehiculoA.Text = row["tipo"].ToString();
                        txtPatenteVehiculoA.Text = row["patente"].ToString();
                        txtMarcaVehiculoA.Text = row["marca"].ToString();
                        txtModeloVehiculoA.Text = row["modelo"].ToString();
                        txtConductorVehiculoA.Text = row["conductor"].ToString();
                        txtCiVehiculoA.Text = row["ci_conductor"].ToString();
                        txtAcompanante1VehiculoA.Text = row["acompanante_1"].ToString();
                        txtCiAcompanante1VehiculoA.Text = row["ci_acompanante_1"].ToString();
                        txtAcompanante2VehiculoA.Text = row["acompanante_2"].ToString();
                        txtCiAcompanante2VehiculoA.Text = row["ci_acompanante_2"].ToString();

                        contador++;
                        continue;
                    }

                    if (contador == 2)
                    {
                        txtTipoVehiculoB.Text = row["tipo"].ToString();
                        txtPatenteVehiculoB.Text = row["patente"].ToString();
                        txtMarcaVehiculoB.Text = row["marca"].ToString();
                        txtModeloVehiculoB.Text = row["modelo"].ToString();
                        txtConductorVehiculoB.Text = row["conductor"].ToString();
                        txtCiVehiculoB.Text = row["ci_conductor"].ToString();
                        txtAcompanante1VehiculoB.Text = row["acompanante_1"].ToString();
                        txtCiAcompanante1VehiculoB.Text = row["ci_acompanante_1"].ToString();
                        txtAcompanante2VehiculoB.Text = row["acompanante_2"].ToString();
                        txtCiAcompanante2VehiculoB.Text = row["ci_acompanante_2"].ToString();

                        contador++;
                        continue;
                    }

                    if (contador == 3)
                    {
                        txtTipoVehiculoC.Text = row["tipo"].ToString();
                        txtPatenteVehiculoC.Text = row["patente"].ToString();
                        txtMarcaVehiculoC.Text = row["marca"].ToString();
                        txtModeloVehiculoC.Text = row["modelo"].ToString();
                        txtConductorVehiculoC.Text = row["conductor"].ToString();
                        txtCiVehiculoC.Text = row["ci_conductor"].ToString();
                        txtAcompanante1VehiculoC.Text = row["acompanante_1"].ToString();
                        txtCiAcompanante1VehiculoC.Text = row["ci_acompanante_1"].ToString();
                        txtAcompanante2VehiculoC.Text = row["acompanante_2"].ToString();
                        txtCiAcompanante2VehiculoC.Text = row["ci_acompanante_2"].ToString();

                        contador++;
                        continue;
                    }

                    if (contador == 4)
                    {
                        txtTipoVehiculoD.Text = row["tipo"].ToString();
                        txtPatenteVehiculoD.Text = row["patente"].ToString();
                        txtMarcaVehiculoD.Text = row["marca"].ToString();
                        txtModeloVehiculoD.Text = row["modelo"].ToString();
                        txtConductorVehiculoD.Text = row["conductor"].ToString();
                        txtCiVehiculoD.Text = row["ci_conductor"].ToString();
                        txtAcompanante1VehiculoD.Text = row["acompanante_1"].ToString();
                        txtCiAcompanante1VehiculoD.Text = row["ci_acompanante_1"].ToString();
                        txtAcompanante2VehiculoD.Text = row["acompanante_2"].ToString();
                        txtCiAcompanante2VehiculoD.Text = row["ci_acompanante_2"].ToString();

                        contador++;
                        continue;
                    }
                }
            }
            #endregion

            #region Lesionados Fallecidos
            if (dsfrLesionadosFallecidos.Tables[0].Rows.Count > 0)
            {
                int contador = 1;
                foreach (DataRow row in dsfrLesionadosFallecidos.Tables[0].Rows)
                {
                    if (contador == 1)
                    {
                        txtNombreLesionadoUno.Text = row["nombre"].ToString();
                        txtCiLesionadoUno.Text = row["ci"].ToString();

                        if (row["estado_consiente"].ToString().Equals("Si"))
                        {
                            chConsienteUnoSi.Checked = true;
                        }
                        else
                        {
                            chConsienteUnoNo.Checked = true;
                        }

                        if (row["estado_lleso"].ToString().Equals("Si"))
                        {
                            chLlesoSiUno.Checked = true;
                        }
                        else
                        {
                            chLlesoNoUno.Checked = true;
                        }

                        if (row["estado_fracturas_visibles"].ToString().Equals("Si"))
                        {
                            chFracturasVisiblesSiUno.Checked = true;
                        }
                        else
                        {
                            chFracturasVisiblesNoUno.Checked = true;
                        }

                        if (row["estado_heridas_visibles"].ToString().Equals("Si"))
                        {
                            chHeridasVisiblesSiUno.Checked = true;
                        }
                        else
                        {
                            chHeridasVisiblesNoUno.Checked = true;
                        }

                        if (row["estado_maniobras_de_rcp"].ToString().Equals("Si"))
                        {
                            chManiobrasRCPSiUno.Checked = true;
                        }
                        else
                        {
                            chManiobrasRCPNoUno.Checked = true;
                        }

                        txtLugarEncuentroUno.Text = row["lugar_encuentro"].ToString();
                        txtAtrapadoReteniaUno.Text = row["atrapado_descripcion"].ToString();
                        txtDetalleFracturaUno.Text = row["detalle_fracturas"].ToString();
                        DetalleFracturasUno.Text = row["detalle_heridas"].ToString();
                        txtOtrasLesionesUno.Text = row["detalle_otras_lesiones"].ToString();
                        TrasladoAUno.Text = row["traslado_a"].ToString();
                        PorUno.Text = row["traslado_por"].ToString();
                        NumeroMovilUno.Text = row["movil_numero"].ToString();
                        txtVehiculoVeniaAUno_Uno.Text = row["vehiculoveniaauno"].ToString();
                        txtVehiculoVeniaAUno_Dos.Text = row["vehiculoveniaados"].ToString();
                        txtVehiculoVeniaBUno_Uno.Text = row["vehiculoveniabuno"].ToString();
                        txtVehiculoVeniaBUno_Dos.Text = row["vehiculoveniabdos"].ToString();

                        contador++;
                        continue;
                    }

                    if (contador == 2)
                    {
                        txtNombreLesionadoDos.Text = row["nombre"].ToString();
                        txtCiLesionadoDos.Text = row["ci"].ToString();

                        if (row["estado_consiente"].ToString().Equals("Si"))
                        {
                            chConsienteDosSi.Checked = true;
                        }
                        else
                        {
                            chConsienteDosNo.Checked = true;
                        }

                        if (row["estado_lleso"].ToString().Equals("Si"))
                        {
                            chLlesoSiDos.Checked = true;
                        }
                        else
                        {
                            chLlesoNoDos.Checked = true;
                        }

                        if (row["estado_fracturas_visibles"].ToString().Equals("Si"))
                        {
                            chFracturasVisiblesSiDos.Checked = true;
                        }
                        else
                        {
                            chFracturasVisiblesNoDos.Checked = true;
                        }

                        if (row["estado_heridas_visibles"].ToString().Equals("Si"))
                        {
                            chHeridasVisiblesSiDos.Checked = true;
                        }
                        else
                        {
                            chHeridasVisiblesNoDos.Checked = true;
                        }

                        if (row["estado_maniobras_de_rcp"].ToString().Equals("Si"))
                        {
                            chManiobrasRCPSiDos.Checked = true;
                        }
                        else
                        {
                            chManiobrasRCPNoDos.Checked = true;
                        }

                        txtLugarEncuentroDos.Text = row["lugar_encuentro"].ToString();
                        txtAtrapadoReteniaDos.Text = row["atrapado_descripcion"].ToString();
                        txtDetalleFracturaDos.Text = row["detalle_fracturas"].ToString();
                        DetalleFracturasDos.Text = row["detalle_heridas"].ToString();
                        txtOtrasLesionesDos.Text = row["detalle_otras_lesiones"].ToString();
                        TrasladoADos.Text = row["traslado_a"].ToString();
                        PorDos.Text = row["traslado_por"].ToString();
                        NumeroMovilDos.Text = row["movil_numero"].ToString();
                        txtVehiculoVeniaADos_Uno.Text = row["vehiculoveniaaDos"].ToString();
                        txtVehiculoVeniaADos_Dos.Text = row["vehiculoveniaados"].ToString();
                        txtVehiculoVeniaBDos_Uno.Text = row["vehiculoveniabuno"].ToString();
                        txtVehiculoVeniaBDos_Dos.Text = row["vehiculoveniabdos"].ToString();

                        contador++;
                        continue;
                    }

                    if (contador == 3)
                    {
                        txtNombreLesionadoTres.Text = row["nombre"].ToString();
                        txtCiLesionadoTres.Text = row["ci"].ToString();

                        if (row["estado_consiente"].ToString().Equals("Si"))
                        {
                            chConsienteTresSi.Checked = true;
                        }
                        else
                        {
                            chConsienteTresNo.Checked = true;
                        }

                        if (row["estado_lleso"].ToString().Equals("Si"))
                        {
                            chLlesoSiTres.Checked = true;
                        }
                        else
                        {
                            chLlesoNoTres.Checked = true;
                        }

                        if (row["estado_fracturas_visibles"].ToString().Equals("Si"))
                        {
                            chFracturasVisiblesSiTres.Checked = true;
                        }
                        else
                        {
                            chFracturasVisiblesNoTres.Checked = true;
                        }

                        if (row["estado_heridas_visibles"].ToString().Equals("Si"))
                        {
                            chHeridasVisiblesSiTres.Checked = true;
                        }
                        else
                        {
                            chHeridasVisiblesNoTres.Checked = true;
                        }

                        if (row["estado_maniobras_de_rcp"].ToString().Equals("Si"))
                        {
                            chManiobrasRCPSiTres.Checked = true;
                        }
                        else
                        {
                            chManiobrasRCPNoTres.Checked = true;
                        }

                        txtLugarEncuentroTres.Text = row["lugar_encuentro"].ToString();
                        txtAtrapadoReteniaTres.Text = row["atrapado_descripcion"].ToString();
                        txtDetalleFracturaTres.Text = row["detalle_fracturas"].ToString();
                        DetalleFracturasTres.Text = row["detalle_heridas"].ToString();
                        txtOtrasLesionesTres.Text = row["detalle_otras_lesiones"].ToString();
                        TrasladoATres.Text = row["traslado_a"].ToString();
                        PorTres.Text = row["traslado_por"].ToString();
                        NumeroMovilTres.Text = row["movil_numero"].ToString();
                        txtVehiculoVeniaATres_Uno.Text = row["vehiculoveniaaDos"].ToString();
                        txtVehiculoVeniaATres_Dos.Text = row["vehiculoveniaados"].ToString();
                        txtVehiculoVeniaBTres_Uno.Text = row["vehiculoveniabuno"].ToString();
                        txtVehiculoVeniaBTres_Dos.Text = row["vehiculoveniabdos"].ToString();

                        contador++;
                        continue;
                    }

                    if (contador == 4)
                    {
                        txtNombreLesionadoCuatro.Text = row["nombre"].ToString();
                        txtCiLesionadoCuatro.Text = row["ci"].ToString();

                        if (row["estado_consiente"].ToString().Equals("Si"))
                        {
                            chConsienteCuatroSi.Checked = true;
                        }
                        else
                        {
                            chConsienteCuatroNo.Checked = true;
                        }

                        if (row["estado_lleso"].ToString().Equals("Si"))
                        {
                            chLlesoSiCuatro.Checked = true;
                        }
                        else
                        {
                            chLlesoNoCuatro.Checked = true;
                        }

                        if (row["estado_fracturas_visibles"].ToString().Equals("Si"))
                        {
                            chFracturasVisiblesSiCuatro.Checked = true;
                        }
                        else
                        {
                            chFracturasVisiblesNoCuatro.Checked = true;
                        }

                        if (row["estado_heridas_visibles"].ToString().Equals("Si"))
                        {
                            chHeridasVisiblesSiCuatro.Checked = true;
                        }
                        else
                        {
                            chHeridasVisiblesNoCuatro.Checked = true;
                        }

                        if (row["estado_maniobras_de_rcp"].ToString().Equals("Si"))
                        {
                            chManiobrasRCPSiCuatro.Checked = true;
                        }
                        else
                        {
                            chManiobrasRCPNoCuatro.Checked = true;
                        }

                        txtLugarEncuentroCuatro.Text = row["lugar_encuentro"].ToString();
                        txtAtrapadoReteniaCuatro.Text = row["atrapado_descripcion"].ToString();
                        txtDetalleFracturaCuatro.Text = row["detalle_fracturas"].ToString();
                        DetalleFracturasCuatro.Text = row["detalle_heridas"].ToString();
                        txtOtrasLesionesCuatro.Text = row["detalle_otras_lesiones"].ToString();
                        TrasladoACuatro.Text = row["traslado_a"].ToString();
                        PorCuatro.Text = row["traslado_por"].ToString();
                        NumeroMovilCuatro.Text = row["movil_numero"].ToString();
                        txtVehiculoVeniaACuatro_Uno.Text = row["vehiculoveniaaDos"].ToString();
                        txtVehiculoVeniaACuatro_Dos.Text = row["vehiculoveniaados"].ToString();
                        txtVehiculoVeniaBCuatro_Uno.Text = row["vehiculoveniabuno"].ToString();
                        txtVehiculoVeniaBCuatro_Dos.Text = row["vehiculoveniabdos"].ToString();

                        contador++;
                        continue;
                    }

                    if (contador == 5)
                    {
                        txtNombreLesionadoCinco.Text = row["nombre"].ToString();
                        txtCiLesionadoCinco.Text = row["ci"].ToString();

                        if (row["estado_consiente"].ToString().Equals("Si"))
                        {
                            chConsienteCincoSi.Checked = true;
                        }
                        else
                        {
                            chConsienteCincoNo.Checked = true;
                        }

                        if (row["estado_lleso"].ToString().Equals("Si"))
                        {
                            chLlesoSiCinco.Checked = true;
                        }
                        else
                        {
                            chLlesoNoCinco.Checked = true;
                        }

                        if (row["estado_fracturas_visibles"].ToString().Equals("Si"))
                        {
                            chFracturasVisiblesSiCinco.Checked = true;
                        }
                        else
                        {
                            chFracturasVisiblesNoCinco.Checked = true;
                        }

                        if (row["estado_heridas_visibles"].ToString().Equals("Si"))
                        {
                            chHeridasVisiblesSiCinco.Checked = true;
                        }
                        else
                        {
                            chHeridasVisiblesNoCinco.Checked = true;
                        }

                        if (row["estado_maniobras_de_rcp"].ToString().Equals("Si"))
                        {
                            chManiobrasRCPSiCinco.Checked = true;
                        }
                        else
                        {
                            chManiobrasRCPNoCinco.Checked = true;
                        }

                        txtLugarEncuentroCinco.Text = row["lugar_encuentro"].ToString();
                        txtAtrapadoReteniaCinco.Text = row["atrapado_descripcion"].ToString();
                        txtDetalleFracturaCinco.Text = row["detalle_fracturas"].ToString();
                        DetalleFracturasCinco.Text = row["detalle_heridas"].ToString();
                        txtOtrasLesionesCinco.Text = row["detalle_otras_lesiones"].ToString();
                        TrasladoACinco.Text = row["traslado_a"].ToString();
                        PorCinco.Text = row["traslado_por"].ToString();
                        NumeroMovilCinco.Text = row["movil_numero"].ToString();
                        txtVehiculoVeniaACinco_Uno.Text = row["vehiculoveniaaDos"].ToString();
                        txtVehiculoVeniaACinco_Dos.Text = row["vehiculoveniaados"].ToString();
                        txtVehiculoVeniaBCinco_Uno.Text = row["vehiculoveniabuno"].ToString();
                        txtVehiculoVeniaBCinco_Dos.Text = row["vehiculoveniabdos"].ToString();

                        contador++;
                        continue;
                    }
                }
            }
            #endregion

            #region Servicio Policial
            if (dsfrServicioPolicial.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsfrServicioPolicial.Tables[0].Rows)
                {
                    if (row["concurrio"].ToString().Equals("Si"))
                    {
                        spConcurrioSi.Checked = true;
                    }
                    else
                    {
                        spConcurrioNo.Checked = true;
                    }

                    spAcargo.Text = row["acargo"].ToString();
                    spUnidad.Text = row["unidad"].ToString();
                    spRPNumero.Text = row["rp_numero"].ToString();
                    spZNumero.Text = row["z_numero"].ToString();
                }
            }
            #endregion

            #region Servicio Medico
            if (dsfrServicioMedico.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsfrServicioMedico.Tables[0].Rows)
                {
                    if (row["concurrio"].ToString().Equals("Si"))
                    {
                        smConcurrioSi.Checked = true;
                    }
                    else
                    {
                        smConcurrioNo.Checked = true;
                    }

                    smAcargo.Text = row["acargo"].ToString();

                    if (!row["unidad_samu"].ToString().Equals(""))
                    {
                        smUnidadSamu.Checked = true;
                    }

                    if (!row["unidad_sapu"].ToString().Equals(""))
                    {
                        smSapu.Checked = true;
                    }

                    if (!row["unidad_privado"].ToString().Equals(""))
                    {
                        smPrivado.Checked = true;
                    }

                    if (!row["unidad_otro"].ToString().Equals(""))
                    {
                        txtOtro.Text = row["unidad_otro"].ToString();
                    }
                }
            }
            #endregion

            #region Descripciones
            if (dsfrDescripcion.Tables[0].Rows.Count > 0)
             {
                foreach (DataRow row in dsfrDescripcion.Tables[0].Rows)
                {
                    ResumenActo.Text = row["resumen_acto"].ToString();
                    MaterialInmovilizacionUtilizado.Text = row["material_inmovilizacion_utilizado"].ToString();
                    apoyoOtrosCuerpos.Text = row["material_mayor_apollo_otros_cuerpos"].ToString();
                }
            }
            #endregion
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label187_Click(object sender, EventArgs e)
        {

        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            e_expedientes exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(RecursosEstaticos.IdExpediente);
            ClaseFormularioRescate formularioRescate = new ClaseFormularioRescate();

            // Se borran los registros antiguos
            formularioRescate.BorrarFormularioRescateDescripcion(RecursosEstaticos.IdExpediente);
            formularioRescate.BorrarFormularioRescateEncabezado(RecursosEstaticos.IdExpediente);
            formularioRescate.BorrarFormularioRescateLesionadosFallecidos(RecursosEstaticos.IdExpediente);
            formularioRescate.BorrarFormularioRescateServicioMedico(RecursosEstaticos.IdExpediente);
            formularioRescate.BorrarFormularioRescateServicioPolicial(RecursosEstaticos.IdExpediente);
            formularioRescate.BorrarFormularioRescateVehiculosInvolucrados(RecursosEstaticos.IdExpediente);

            // Se inserta el encabezado del formulario.
            formularioRescate.FormularioRescateEncabezado(RecursosEstaticos.IdExpediente,
                exp.fecha.ToString(),
                txtHoraInicio.Text,
                txtHoraLlegadaPrimerCarro.Text,
                txtHoraLlegadaCarroRescate.Text,
                txtHoraTermino.Text,
                txtCorrelativoCompania.Text.Equals("") ? 0 : int.Parse(txtCorrelativoCompania.Text),
                txtCorrelativoCBPA.Text.Equals("") ? 0 : int.Parse(txtCorrelativoCBPA.Text), 
                this.ObtenerClasificacionEmergencia(), 
                this.ObtenerClasificacionZona(),
                this.ObtenerTipoVia(),
                this.ObtenerClasificacionAtmosferica(),
                txtSectorEmergencia.Text,
                txtNumeroEmergencia.Text.Equals("") ? 0 : int.Parse(txtNumeroEmergencia.Text),
                txtEsquinaEmergencia.Text, 
                ddlComunaEmergencia.Text);

            // Se insertan los vehículos involucrados.
            if (!txtTipoVehiculoA.Text.Equals("")
                || !txtMarcaVehiculoA.Text.Equals("")
                || !txtModeloVehiculoA.Text.Equals("")
                || !txtPatenteVehiculoA.Text.Equals(""))
            {
                formularioRescate.FormularioRescateVehiculosInvolucrados(RecursosEstaticos.IdExpediente,
                    txtTipoVehiculoA.Text,
                    txtMarcaVehiculoA.Text,
                    txtModeloVehiculoA.Text,
                    txtPatenteVehiculoA.Text,
                    txtConductorVehiculoA.Text,
                    txtCiVehiculoA.Text,
                    txtAcompanante1VehiculoA.Text,
                    txtCiAcompanante1VehiculoA.Text,
                    txtAcompanante2VehiculoA.Text,
                    txtCiAcompanante2VehiculoA.Text);
            }

            if (!txtTipoVehiculoB.Text.Equals("")
                || !txtMarcaVehiculoB.Text.Equals("")
                || !txtModeloVehiculoB.Text.Equals("")
                || !txtPatenteVehiculoB.Text.Equals(""))
            {
                formularioRescate.FormularioRescateVehiculosInvolucrados(RecursosEstaticos.IdExpediente,
                    txtTipoVehiculoB.Text,
                    txtMarcaVehiculoB.Text,
                    txtModeloVehiculoB.Text,
                    txtPatenteVehiculoB.Text,
                    txtConductorVehiculoB.Text,
                    txtCiVehiculoB.Text,
                    txtAcompanante1VehiculoB.Text,
                    txtCiAcompanante1VehiculoB.Text,
                    txtAcompanante2VehiculoB.Text,
                    txtCiAcompanante2VehiculoB.Text);
            }

            if (!txtTipoVehiculoC.Text.Equals("")
                || !txtMarcaVehiculoC.Text.Equals("")
                || !txtModeloVehiculoC.Text.Equals("")
                || !txtPatenteVehiculoC.Text.Equals(""))
            {
                formularioRescate.FormularioRescateVehiculosInvolucrados(RecursosEstaticos.IdExpediente,
                    txtTipoVehiculoC.Text,
                    txtMarcaVehiculoC.Text,
                    txtModeloVehiculoC.Text,
                    txtPatenteVehiculoC.Text,
                    txtConductorVehiculoC.Text,
                    txtCiVehiculoC.Text,
                    txtAcompanante1VehiculoC.Text,
                    txtCiAcompanante1VehiculoC.Text,
                    txtAcompanante2VehiculoC.Text,
                    txtCiAcompanante2VehiculoC.Text);
            }

            if (!txtTipoVehiculoD.Text.Equals("")
                || !txtMarcaVehiculoD.Text.Equals("")
                || !txtModeloVehiculoD.Text.Equals("")
                || !txtPatenteVehiculoD.Text.Equals(""))
            {
                formularioRescate.FormularioRescateVehiculosInvolucrados(RecursosEstaticos.IdExpediente,
                    txtTipoVehiculoD.Text,
                    txtMarcaVehiculoD.Text,
                    txtModeloVehiculoD.Text,
                    txtPatenteVehiculoD.Text,
                    txtConductorVehiculoD.Text,
                    txtCiVehiculoD.Text,
                    txtAcompanante1VehiculoD.Text,
                    txtCiAcompanante1VehiculoD.Text,
                    txtAcompanante2VehiculoD.Text,
                    txtCiAcompanante2VehiculoD.Text);
            }
            // Fin se insertan vehículos involucrados

            // Insertar lesionados o fallecidos
            if (!txtNombreLesionadoUno.Text.Equals("") || !txtCiLesionadoUno.Text.Equals(""))
            {
                #region Validaciones de estados
                string estadoConsiente = string.Empty;
                if (chConsienteUnoSi.Checked)
                {
                    estadoConsiente = "Si";
                }
                else if (chConsienteUnoNo.Checked)
                {
                    estadoConsiente = "No";
                }

                string estadoLleso = string.Empty;
                if (chLlesoSiUno.Checked)
                {
                    estadoLleso = "Si";
                }
                else if (chLlesoNoUno.Checked)
                {
                    estadoLleso = "No";
                }

                string estadoFracturasVisibles = string.Empty;
                if (chFracturasVisiblesSiUno.Checked)
                {
                    estadoFracturasVisibles = "Si";
                }
                else if (chFracturasVisiblesNoUno.Checked)
                {
                    estadoFracturasVisibles = "No";
                }

                string estadoHeridasVisibles = string.Empty;
                if (chHeridasVisiblesSiUno.Checked)
                {
                    estadoHeridasVisibles = "Si";
                }
                else if (chHeridasVisiblesNoUno.Checked)
                {
                    estadoHeridasVisibles = "No";
                }

                string estadoManiobrasRCP = string.Empty;
                if (chManiobrasRCPSiUno.Checked)
                {
                    estadoManiobrasRCP = "Si";
                }
                else if (chManiobrasRCPNoUno.Checked)
                {
                    estadoManiobrasRCP = "No";
                }
                #endregion

                formularioRescate.FormularioRescateLesionadosFallecidos(RecursosEstaticos.IdExpediente,
                    txtNombreLesionadoUno.Text,
                    txtCiLesionadoUno.Text,
                    estadoConsiente,
                    estadoLleso,
                    estadoFracturasVisibles,
                    estadoHeridasVisibles,
                    estadoManiobrasRCP,
                    txtLugarEncuentroUno.Text,
                    txtAtrapadoReteniaUno.Text,
                    txtDetalleFracturaUno.Text,
                    DetalleFracturasUno.Text,
                    txtOtrasLesionesUno.Text,
                    TrasladoAUno.Text,
                    PorUno.Text,
                    NumeroMovilUno.Text,
                    txtVehiculoVeniaAUno_Uno.Text,
                    txtVehiculoVeniaAUno_Dos.Text,
                    txtVehiculoVeniaBUno_Uno.Text,
                    txtVehiculoVeniaBUno_Dos.Text);
            }

            if (!txtNombreLesionadoDos.Text.Equals("") || !txtCiLesionadoDos.Text.Equals(""))
            {
                #region Validaciones de estados
                string estadoConsiente = string.Empty;
                if (chConsienteDosSi.Checked)
                {
                    estadoConsiente = "Si";
                }
                else if (chConsienteDosNo.Checked)
                {
                    estadoConsiente = "No";
                }

                string estadoLleso = string.Empty;
                if (chLlesoSiDos.Checked)
                {
                    estadoLleso = "Si";
                }
                else if (chLlesoNoDos.Checked)
                {
                    estadoLleso = "No";
                }

                string estadoFracturasVisibles = string.Empty;
                if (chFracturasVisiblesSiDos.Checked)
                {
                    estadoFracturasVisibles = "Si";
                }
                else if (chFracturasVisiblesNoDos.Checked)
                {
                    estadoFracturasVisibles = "No";
                }

                string estadoHeridasVisibles = string.Empty;
                if (chHeridasVisiblesSiDos.Checked)
                {
                    estadoHeridasVisibles = "Si";
                }
                else if (chHeridasVisiblesNoDos.Checked)
                {
                    estadoHeridasVisibles = "No";
                }

                string estadoManiobrasRCP = string.Empty;
                if (chManiobrasRCPSiDos.Checked)
                {
                    estadoManiobrasRCP = "Si";
                }
                else if (chManiobrasRCPNoDos.Checked)
                {
                    estadoManiobrasRCP = "No";
                }
                #endregion

                formularioRescate.FormularioRescateLesionadosFallecidos(RecursosEstaticos.IdExpediente,
                    txtNombreLesionadoDos.Text,
                    txtCiLesionadoDos.Text,
                    estadoConsiente,
                    estadoLleso,
                    estadoFracturasVisibles,
                    estadoHeridasVisibles,
                    estadoManiobrasRCP,
                    txtLugarEncuentroDos.Text,
                    txtAtrapadoReteniaDos.Text,
                    txtDetalleFracturaDos.Text,
                    DetalleFracturasDos.Text,
                    txtOtrasLesionesDos.Text,
                    TrasladoADos.Text, 
                    PorDos.Text,
                    NumeroMovilDos.Text,
                    txtVehiculoVeniaADos_Uno.Text,
                    txtVehiculoVeniaADos_Dos.Text,
                    txtVehiculoVeniaBDos_Uno.Text,
                    txtVehiculoVeniaBDos_Dos.Text);
            }

            if (!txtNombreLesionadoTres.Text.Equals("") || !txtCiLesionadoTres.Text.Equals(""))
            {
                #region Validaciones de estados
                string estadoConsiente = string.Empty;
                if (chConsienteTresSi.Checked)
                {
                    estadoConsiente = "Si";
                }
                else if (chConsienteTresNo.Checked)
                {
                    estadoConsiente = "No";
                }

                string estadoLleso = string.Empty;
                if (chLlesoSiTres.Checked)
                {
                    estadoLleso = "Si";
                }
                else if (chLlesoNoTres.Checked)
                {
                    estadoLleso = "No";
                }

                string estadoFracturasVisibles = string.Empty;
                if (chFracturasVisiblesSiTres.Checked)
                {
                    estadoFracturasVisibles = "Si";
                }
                else if (chFracturasVisiblesNoTres.Checked)
                {
                    estadoFracturasVisibles = "No";
                }

                string estadoHeridasVisibles = string.Empty;
                if (chHeridasVisiblesSiTres.Checked)
                {
                    estadoHeridasVisibles = "Si";
                }
                else if (chHeridasVisiblesNoTres.Checked)
                {
                    estadoHeridasVisibles = "No";
                }

                string estadoManiobrasRCP = string.Empty;
                if (chManiobrasRCPSiTres.Checked)
                {
                    estadoManiobrasRCP = "Si";
                }
                else if (chManiobrasRCPNoTres.Checked)
                {
                    estadoManiobrasRCP = "No";
                }
                #endregion

                formularioRescate.FormularioRescateLesionadosFallecidos(RecursosEstaticos.IdExpediente,
                    txtNombreLesionadoTres.Text,
                    txtCiLesionadoTres.Text,
                    estadoConsiente,
                    estadoLleso,
                    estadoFracturasVisibles,
                    estadoHeridasVisibles,
                    estadoManiobrasRCP,
                    txtLugarEncuentroTres.Text,
                    txtAtrapadoReteniaTres.Text,
                    txtDetalleFracturaTres.Text,
                    DetalleFracturasTres.Text,
                    txtOtrasLesionesTres.Text,
                    TrasladoATres.Text,
                    PorTres.Text,
                    NumeroMovilTres.Text,
                    txtVehiculoVeniaATres_Uno.Text,
                    txtVehiculoVeniaATres_Dos.Text,
                    txtVehiculoVeniaBTres_Uno.Text,
                    txtVehiculoVeniaBTres_Dos.Text);
            }

            if (!txtNombreLesionadoCuatro.Text.Equals("") || !txtCiLesionadoCuatro.Text.Equals(""))
            {
                #region Validaciones de estados
                string estadoConsiente = string.Empty;
                if (chConsienteCuatroSi.Checked)
                {
                    estadoConsiente = "Si";
                }
                else if (chConsienteCuatroNo.Checked)
                {
                    estadoConsiente = "No";
                }

                string estadoLleso = string.Empty;
                if (chLlesoSiCuatro.Checked)
                {
                    estadoLleso = "Si";
                }
                else if (chLlesoNoCuatro.Checked)
                {
                    estadoLleso = "No";
                }

                string estadoFracturasVisibles = string.Empty;
                if (chFracturasVisiblesSiCuatro.Checked)
                {
                    estadoFracturasVisibles = "Si";
                }
                else if (chFracturasVisiblesNoCuatro.Checked)
                {
                    estadoFracturasVisibles = "No";
                }

                string estadoHeridasVisibles = string.Empty;
                if (chHeridasVisiblesSiCuatro.Checked)
                {
                    estadoHeridasVisibles = "Si";
                }
                else if (chHeridasVisiblesNoCuatro.Checked)
                {
                    estadoHeridasVisibles = "No";
                }

                string estadoManiobrasRCP = string.Empty;
                if (chManiobrasRCPSiCuatro.Checked)
                {
                    estadoManiobrasRCP = "Si";
                }
                else if (chManiobrasRCPNoCuatro.Checked)
                {
                    estadoManiobrasRCP = "No";
                }
                #endregion

                formularioRescate.FormularioRescateLesionadosFallecidos(RecursosEstaticos.IdExpediente,
                    txtNombreLesionadoCuatro.Text,
                    txtCiLesionadoCuatro.Text,
                    estadoConsiente,
                    estadoLleso,
                    estadoFracturasVisibles,
                    estadoHeridasVisibles,
                    estadoManiobrasRCP,
                    txtLugarEncuentroCuatro.Text,
                    txtAtrapadoReteniaCuatro.Text,
                    txtDetalleFracturaCuatro.Text,
                    DetalleFracturasCuatro.Text,
                    txtOtrasLesionesCuatro.Text,
                    TrasladoACuatro.Text,
                    PorCuatro.Text,
                    NumeroMovilCuatro.Text,
                    txtVehiculoVeniaACuatro_Uno.Text,
                    txtVehiculoVeniaACuatro_Dos.Text,
                    txtVehiculoVeniaBCuatro_Uno.Text,
                    txtVehiculoVeniaBCuatro_Dos.Text);
            }

            if (!txtNombreLesionadoCinco.Text.Equals("") || !txtCiLesionadoCinco.Text.Equals(""))
            {
                #region Validaciones de estados
                string estadoConsiente = string.Empty;
                if (chConsienteCincoSi.Checked)
                {
                    estadoConsiente = "Si";
                }
                else if (chConsienteCincoNo.Checked)
                {
                    estadoConsiente = "No";
                }

                string estadoLleso = string.Empty;
                if (chLlesoSiCinco.Checked)
                {
                    estadoLleso = "Si";
                }
                else if (chLlesoNoCinco.Checked)
                {
                    estadoLleso = "No";
                }

                string estadoFracturasVisibles = string.Empty;
                if (chFracturasVisiblesSiCinco.Checked)
                {
                    estadoFracturasVisibles = "Si";
                }
                else if (chFracturasVisiblesNoCinco.Checked)
                {
                    estadoFracturasVisibles = "No";
                }

                string estadoHeridasVisibles = string.Empty;
                if (chHeridasVisiblesSiCinco.Checked)
                {
                    estadoHeridasVisibles = "Si";
                }
                else if (chHeridasVisiblesNoCinco.Checked)
                {
                    estadoHeridasVisibles = "No";
                }

                string estadoManiobrasRCP = string.Empty;
                if (chManiobrasRCPSiCinco.Checked)
                {
                    estadoManiobrasRCP = "Si";
                }
                else if (chManiobrasRCPNoCinco.Checked)
                {
                    estadoManiobrasRCP = "No";
                }
                #endregion

                formularioRescate.FormularioRescateLesionadosFallecidos(RecursosEstaticos.IdExpediente,
                    txtNombreLesionadoCinco.Text,
                    txtCiLesionadoCinco.Text,
                    estadoConsiente,
                    estadoLleso,
                    estadoFracturasVisibles,
                    estadoHeridasVisibles,
                    estadoManiobrasRCP,
                    txtLugarEncuentroCinco.Text,
                    txtAtrapadoReteniaCinco.Text,
                    txtDetalleFracturaCinco.Text,
                    DetalleFracturasCinco.Text,
                    txtOtrasLesionesCinco.Text,
                    TrasladoACinco.Text,
                    PorCinco.Text,
                    NumeroMovilCinco.Text,
                    txtVehiculoVeniaACinco_Uno.Text,
                    txtVehiculoVeniaACinco_Dos.Text,
                    txtVehiculoVeniaBCinco_Uno.Text,
                    txtVehiculoVeniaBCinco_Dos.Text);
            }
            // Fin insertar lesionados o fallecidos

            // Se inserta el servicio policial
            string concurrio = string.Empty;
            if(spConcurrioSi.Checked)
            {
                concurrio = "Si";
            }
            else if(spConcurrioNo.Checked)
            {
                concurrio = "No";
            }

            formularioRescate.FormularioRescateServicioPolicial(RecursosEstaticos.IdExpediente,
                concurrio,
                spAcargo.Text,
                spUnidad.Text,
                spRPNumero.Text,
                spZNumero.Text);

            // Se inserta el servicio medico
            if(smConcurrioSi.Checked)
            {
                concurrio = "Si";
            }
            else if(smConcurrioSi.Checked)
            {
                concurrio = "No";
            }

            formularioRescate.FormularioRescateServicioMedico(RecursosEstaticos.IdExpediente,
                concurrio,
                smAcargo.Text,
                smUnidadSamu.Checked ? smUnidadSamu.Text : "", 
                smSapu.Checked ? smSapu.Text : "",
                smPrivado.Checked ? smPrivado.Text : "", 
                !txtOtro.Text.Equals("") ? txtOtro.Text : "");

            // Se insertan las descripciones, material mayor concurrente y apoyo de otros carros
            formularioRescate.FormularioRescateDescripciones(RecursosEstaticos.IdExpediente,
                ResumenActo.Text,
                MaterialInmovilizacionUtilizado.Text,
                label175.Text,
                apoyoOtrosCuerpos.Text);

            MessageBox.Show("Formulario ingresado de forma exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ObtenerClasificacionEmergencia()
        {
            string clasificacionAccidente = string.Empty;

            if(rbChoque.Checked)
            {
                clasificacionAccidente = "Choque";
            }

            if(rbColision.Checked)
            {
                clasificacionAccidente = "Colision";
            }

            if(rbAtropello.Checked)
            {
                clasificacionAccidente = "Atropello";
            }

            if(rbVolcamiento.Checked)
            {
                clasificacionAccidente = "Volcamiento";
            }

            if(rbCaida.Checked)
            {
                clasificacionAccidente = "Caida";
            }

            return clasificacionAccidente;
        }

        private string ObtenerClasificacionZona()
        {
            string clasificacionZona = string.Empty;

            if(rbZonaUrbana.Checked)
            {
                clasificacionZona = "Urbana";
            }

            if(rbZonaRural.Checked)
            {
                clasificacionZona = "Rural";
            }

            return clasificacionZona;
        }

        private string ObtenerTipoVia()
        {
            string clasificacionTipoDeVia = string.Empty;

            if (rbTVRecta.Checked)
            {
                clasificacionTipoDeVia = "Recta";
            }

            if (rbTVCurva.Checked)
            {
                clasificacionTipoDeVia = "Curva";
            }

            if (rbTVPuente.Checked)
            {
                clasificacionTipoDeVia = "Puente";
            }

            if (rbTVTunel.Checked)
            {
                clasificacionTipoDeVia = "Tunel";
            }

            if (rbTVAceraBerma.Checked)
            {
                clasificacionTipoDeVia = "AceraBerma";
            }

            return clasificacionTipoDeVia;
        }

        private string ObtenerClasificacionAtmosferica()
        {
            string clasificacionAtmosferica = string.Empty;

            if (rbDespejado.Checked)
            {
                clasificacionAtmosferica = "Despejado";
            }

            if (rbNublado.Checked)
            {
                clasificacionAtmosferica = "Nublado";
            }

            if(rbNeblina.Checked)
            {
                clasificacionAtmosferica = "Neblina";
            }

            if (rbLluvia.Checked)
            {
                clasificacionAtmosferica = "Lluvia";
            }

            if (!txtOtros.Text.Equals(""))
            {
                clasificacionAtmosferica = txtOtros.Text;
            }

            return clasificacionAtmosferica;
        }

        private void chConsienteUnoSi_CheckedChanged(object sender, EventArgs e)
        {
            chConsienteUnoNo.Checked = false;
        }

        private void chConsienteUnoNo_CheckedChanged(object sender, EventArgs e)
        {
            chConsienteUnoSi.Checked = false;
        }

        private void chLlesoSiUno_CheckedChanged(object sender, EventArgs e)
        {
            chLlesoNoUno.Checked = false;
        }

        private void chLlesoNoUno_CheckedChanged(object sender, EventArgs e)
        {
            chLlesoSiUno.Checked = false;
        }

        private void chFracturasVisiblesSiUno_CheckedChanged(object sender, EventArgs e)
        {
            chFracturasVisiblesNoUno.Checked = false;
        }

        private void chFracturasVisiblesNoUno_CheckedChanged(object sender, EventArgs e)
        {
            chFracturasVisiblesSiUno.Checked = false;
        }

        private void chHeridasVisiblesSiUno_CheckedChanged(object sender, EventArgs e)
        {
            chHeridasVisiblesNoUno.Checked = false;
        }

        private void chHeridasVisiblesNoUno_CheckedChanged(object sender, EventArgs e)
        {
            chHeridasVisiblesSiUno.Checked = false;
        }

        private void chManiobrasRCPSiUno_CheckedChanged(object sender, EventArgs e)
        {
            chManiobrasRCPNoUno.Checked = false;
        }

        private void chManiobrasRCPNoUno_CheckedChanged(object sender, EventArgs e)
        {
            chManiobrasRCPSiUno.Checked = false;
        }

        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            GenerarArchivoExcel();
        }

        private void txtOtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            smUnidadSamu.Checked = false;
            smSapu.Checked = false;
            smPrivado.Checked = false;
        }

        protected void GenerarArchivoExcel()
        {
            string nuevoArchivo = @"C:\ZEUS_CBMS\Partes\archivo_rescate_" + System.DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";
            FileInfo template = new FileInfo(@"C:\ZEUS_CBMS\Partes\plantilla_rescate.xlsx");
            FileInfo newFile = new FileInfo(nuevoArchivo);
            ExcelCell cell;

            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                foreach (ExcelWorksheet aworksheet in xlPackage.Workbook.Worksheets)
                {
                    aworksheet.Cell(1, 1).Value = aworksheet.Cell(1, 1).Value;
                }

                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["Hoja1"];

                // Dia
                cell = worksheet.Cell(6, 5);
                cell.Value = txtDia.Text;

                // Mes
                cell = worksheet.Cell(6, 9);
                cell.Value = txtMes.Text;

                // Ano
                cell = worksheet.Cell(6, 13);
                cell.Value = txtAnio.Text;

                // Hora de inicio
                cell = worksheet.Cell(6, 17);
                cell.Value = txtHoraInicio.Text;

                // Hora de llegada del primer carro
                cell = worksheet.Cell(6, 23);
                cell.Value = txtHoraLlegadaPrimerCarro.Text;

                // Hora de llegada del carro de rescate
                cell = worksheet.Cell(6, 31);
                cell.Value = txtHoraLlegadaCarroRescate.Text;

                // Hora de término
                cell = worksheet.Cell(6, 39);
                cell.Value = txtHoraTermino.Text;

                // Correlativo de la compañía
                cell = worksheet.Cell(6, 45);
                cell.Value = txtCorrelativoCompania.Text;

                // Correlativo CBPA
                cell = worksheet.Cell(6, 52);
                cell.Value = txtCorrelativoCBPA.Text;

                if (rbChoque.Checked)
                {
                    // Clasificación accidente: CHOQUE
                    cell = worksheet.Cell(12, 13);
                    cell.Value = "X";
                }

                if (rbColision.Checked)
                {
                    // Clasificación accidente: COLISIÓN
                    cell = worksheet.Cell(12, 23);
                    cell.Value = "X";
                }

                if (rbAtropello.Checked)
                {
                    // Clasificación accidente: ATROPELLO
                    cell = worksheet.Cell(12, 35);
                    cell.Value = "X";
                }

                if (rbVolcamiento.Checked)
                {
                    // Clasificación accidente: VOLCAMIENTO
                    cell = worksheet.Cell(12, 49);
                    cell.Value = "X";
                }

                if (rbCaida.Checked)
                {
                    // Clasificación accidente: CAÍDA
                    cell = worksheet.Cell(12, 58);
                    cell.Value = "X";
                }

                if (rbZonaUrbana.Checked)
                {
                    // Ubicación relativa del lugar: URBANA
                    cell = worksheet.Cell(16, 35);
                    cell.Value = "X";
                }

                if (rbZonaRural.Checked)
                {
                    // Ubicación relativa del lugar: RURAL
                    cell = worksheet.Cell(16, 49);
                    cell.Value = "X";
                }

                // Ubicación relativa del lugar: DIRECCIÓN
                cell = worksheet.Cell(20, 12);
                cell.Value = txtDireccionEmergencia.Text;
                
                // Ubicación relativa del lugar: FRENTE AL NÚMERO
                cell = worksheet.Cell(20, 55);
                cell.Value = txtNumeroEmergencia.Text;

                // Ubicación relativa del lugar: ESQUINA
                cell = worksheet.Cell(21, 11);
                cell.Value = txtEsquinaEmergencia.Text;

                // Ubicación relativa del lugar: SECTOR
                cell = worksheet.Cell(21, 31);
                cell.Value = txtSectorEmergencia.Text;

                // Ubicación relativa del lugar: COMUNA
                cell = worksheet.Cell(21, 51);
                cell.Value = ddlComunaEmergencia.Text;

                if (rbTVRecta.Checked)
                {
                    // Tipo de vía: RECTA
                    cell = worksheet.Cell(25, 19);
                    cell.Value = "X";
                }

                if (rbTVCurva.Checked)
                {
                    // Tipo de vía: CURVA
                    cell = worksheet.Cell(25, 28);
                    cell.Value = "X";
                }

                if (rbTVPuente.Checked)
                {
                    // Tipo de vía: PUENTE
                    cell = worksheet.Cell(25, 37);
                    cell.Value = "X";
                }

                if (rbTVTunel.Checked)
                {
                    // Tipo de vía: TÚNEL
                    cell = worksheet.Cell(25, 45);
                    cell.Value = "X";
                }

                if (rbTVAceraBerma.Checked)
                {
                    // Tipo de vía: ACERA O BERMA
                    cell = worksheet.Cell(25, 59);
                    cell.Value = "X";
                }

                if (rbDespejado.Checked)
                {
                    // Estado atmosférico: DESPEJADO
                    cell = worksheet.Cell(30, 13);
                    cell.Value = "X";
                }

                if (rbNublado.Checked)
                {
                    // Estado atmosférico: NUBLADO
                    cell = worksheet.Cell(30, 23);
                    cell.Value = "X";
                }

                if (rbNeblina.Checked)
                {
                    // Estado atmosférico: NEBLINA
                    cell = worksheet.Cell(30, 32);
                    cell.Value = "X";
                }

                if (rbLluvia.Checked)
                {
                    // Estado atmosférico: LLUVIA
                    cell = worksheet.Cell(30, 41);
                    cell.Value = "X";
                }

                if (!txtOtros.Text.Equals(""))
                {
                    // Estado atmosférico: OTRO
                    cell = worksheet.Cell(30, 49);
                    cell.Value = txtOtros.Text;
                }

                // ============== VEHICULOS INVOLUCRADOS (A) ==============

                // Vehículos involucrados: TIPO
                cell = worksheet.Cell(35, 11);
                cell.Value = txtTipoVehiculoA.Text;

                // Vehículos involucrados: MARCA
                cell = worksheet.Cell(35, 24);
                cell.Value = txtMarcaVehiculoA.Text;

                // Vehículos involucrados: MODELO
                cell = worksheet.Cell(35, 38);
                cell.Value = txtModeloVehiculoA.Text;

                if (txtPatenteVehiculoA.Text.Count() == 6)
                {

                    // Vehículos involucrados: PATENTE 54
                    cell = worksheet.Cell(35, 54);
                    cell.Value = txtPatenteVehiculoA.Text[0].ToString();

                    // Vehículos involucrados: PATENTE 55
                    cell = worksheet.Cell(35, 55);
                    cell.Value = txtPatenteVehiculoA.Text[1].ToString();

                    // Vehículos involucrados: PATENTE 57
                    cell = worksheet.Cell(35, 57);
                    cell.Value = txtPatenteVehiculoA.Text[2].ToString();

                    // Vehículos involucrados: PATENTE 58
                    cell = worksheet.Cell(35, 58);
                    cell.Value = txtPatenteVehiculoA.Text[3].ToString();

                    // Vehículos involucrados: PATENTE 59
                    cell = worksheet.Cell(35, 59);
                    cell.Value = txtPatenteVehiculoA.Text[4].ToString();

                    // Vehículos involucrados: PATENTE 60
                    cell = worksheet.Cell(35, 60);
                    cell.Value = txtPatenteVehiculoA.Text[5].ToString();
                }

                // Vehículos involucrados: CONDUCTOR
                cell = worksheet.Cell(37, 15);
                cell.Value = txtConductorVehiculoA.Text;

                if (txtCiVehiculoA.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(37, 49);
                    cell.Value = txtCiVehiculoA.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(37, 50);
                    cell.Value = txtCiVehiculoA.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(37, 52);
                    cell.Value = txtCiVehiculoA.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(37, 53);
                    cell.Value = txtCiVehiculoA.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(37, 54);
                    cell.Value = txtCiVehiculoA.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(37, 56);
                    cell.Value = txtCiVehiculoA.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(37, 57);
                    cell.Value = txtCiVehiculoA.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(37, 58);
                    cell.Value = txtCiVehiculoA.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(37, 60);
                    cell.Value = txtCiVehiculoA.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE UNO
                cell = worksheet.Cell(39, 15);
                cell.Value = txtAcompanante1VehiculoA.Text;

                if (txtCiAcompanante1VehiculoA.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(39, 49);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(39, 50);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(39, 52);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(39, 53);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(39, 54);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(39, 56);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(39, 57);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(39, 58);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(39, 60);
                    cell.Value = txtCiAcompanante1VehiculoA.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE DOS
                cell = worksheet.Cell(40, 15);
                cell.Value = txtAcompanante2VehiculoA.Text;

                if (txtCiAcompanante2VehiculoA.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(40, 49);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(40, 50);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(40, 52);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(40, 53);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(40, 54);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(40, 56);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(40, 57);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(40, 58);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(40, 60);
                    cell.Value = txtCiAcompanante2VehiculoA.Text[9].ToString();
                }

                // ============== FIN VEHICULOS INVOLUCRADOS (A) ==============

                // ============== VEHICULOS INVOLUCRADOS (B) ==============

                // Vehículos involucrados: TIPO
                cell = worksheet.Cell(43, 11);
                cell.Value = txtMarcaVehiculoB.Text;

                // Vehículos involucrados: MARCA
                cell = worksheet.Cell(43, 24);
                cell.Value = txtMarcaVehiculoB.Text;

                // Vehículos involucrados: MODELO
                cell = worksheet.Cell(43, 38);
                cell.Value = txtModeloVehiculoB.Text;

                if (txtPatenteVehiculoB.Text.Count() == 6)
                {
                    // Vehículos involucrados: PATENTE 54
                    cell = worksheet.Cell(43, 54);
                    cell.Value = txtPatenteVehiculoB.Text[0].ToString();

                    // Vehículos involucrados: PATENTE 55
                    cell = worksheet.Cell(43, 55);
                    cell.Value = txtPatenteVehiculoB.Text[1].ToString();

                    // Vehículos involucrados: PATENTE 57
                    cell = worksheet.Cell(43, 57);
                    cell.Value = txtPatenteVehiculoB.Text[2].ToString();

                    // Vehículos involucrados: PATENTE 58
                    cell = worksheet.Cell(43, 58);
                    cell.Value = txtPatenteVehiculoB.Text[3].ToString();

                    // Vehículos involucrados: PATENTE 59
                    cell = worksheet.Cell(43, 59);
                    cell.Value = txtPatenteVehiculoB.Text[4].ToString();

                    // Vehículos involucrados: PATENTE 60
                    cell = worksheet.Cell(43, 60);
                    cell.Value = txtPatenteVehiculoB.Text[5].ToString();
                }

                // Vehículos involucrados: CONDUCTOR
                cell = worksheet.Cell(45, 15);
                cell.Value = txtConductorVehiculoB.Text;

                if (txtCiVehiculoB.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(45, 49);
                    cell.Value = txtCiVehiculoB.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(45, 50);
                    cell.Value = txtCiVehiculoB.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(45, 52);
                    cell.Value = txtCiVehiculoB.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(45, 53);
                    cell.Value = txtCiVehiculoB.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(45, 54);
                    cell.Value = txtCiVehiculoB.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(45, 56);
                    cell.Value = txtCiVehiculoB.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(45, 57);
                    cell.Value = txtCiVehiculoB.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(45, 58);
                    cell.Value = txtCiVehiculoB.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(45, 60);
                    cell.Value = txtCiVehiculoB.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE UNO
                cell = worksheet.Cell(47, 15);
                cell.Value = txtAcompanante1VehiculoB.Text;

                if (txtCiAcompanante1VehiculoB.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(47, 49);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(47, 50);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(47, 52);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(47, 53);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(47, 54);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(47, 56);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(47, 57);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(47, 58);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(47, 60);
                    cell.Value = txtCiAcompanante1VehiculoB.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE DOS
                cell = worksheet.Cell(48, 15);
                cell.Value = txtAcompanante2VehiculoB.Text;

                if (txtCiAcompanante2VehiculoB.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(48, 49);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(48, 50);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(48, 52);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(48, 53);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(48, 54);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(48, 56);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(48, 57);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(48, 58);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(48, 60);
                    cell.Value = txtCiAcompanante2VehiculoB.Text[9].ToString();
                }

                // ============== FIN VEHICULOS INVOLUCRADOS (B) ==============

                // ============== VEHICULOS INVOLUCRADOS (C) ==============

                // Vehículos involucrados: TIPO
                cell = worksheet.Cell(51, 11);
                cell.Value = txtTipoVehiculoC.Text;

                // Vehículos involucrados: MARCA
                cell = worksheet.Cell(51, 24);
                cell.Value = txtMarcaVehiculoC.Text;

                // Vehículos involucrados: MODELO
                cell = worksheet.Cell(51, 38);
                cell.Value = txtModeloVehiculoC.Text;

                if (txtPatenteVehiculoC.Text.Count() == 6)
                {
                    // Vehículos involucrados: PATENTE 54
                    cell = worksheet.Cell(51, 54);
                    cell.Value = txtPatenteVehiculoC.Text[0].ToString();

                    // Vehículos involucrados: PATENTE 55
                    cell = worksheet.Cell(51, 55);
                    cell.Value = txtPatenteVehiculoC.Text[1].ToString();

                    // Vehículos involucrados: PATENTE 57
                    cell = worksheet.Cell(51, 57);
                    cell.Value = txtPatenteVehiculoC.Text[2].ToString();

                    // Vehículos involucrados: PATENTE 58
                    cell = worksheet.Cell(51, 58);
                    cell.Value = txtPatenteVehiculoC.Text[3].ToString();

                    // Vehículos involucrados: PATENTE 59
                    cell = worksheet.Cell(51, 59);
                    cell.Value = txtPatenteVehiculoC.Text[4].ToString();

                    // Vehículos involucrados: PATENTE 60
                    cell = worksheet.Cell(51, 60);
                    cell.Value = txtPatenteVehiculoC.Text[5].ToString();
                }

                // Vehículos involucrados: CONDUCTOR
                cell = worksheet.Cell(53, 15);
                cell.Value = txtConductorVehiculoC.Text;

                if (txtCiVehiculoC.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(53, 49);
                    cell.Value = txtCiVehiculoC.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(53, 50);
                    cell.Value = txtCiVehiculoC.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(53, 52);
                    cell.Value = txtCiVehiculoC.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(53, 53);
                    cell.Value = txtCiVehiculoC.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(53, 54);
                    cell.Value = txtCiVehiculoC.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(53, 56);
                    cell.Value = txtCiVehiculoC.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(53, 57);
                    cell.Value = txtCiVehiculoC.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(53, 58);
                    cell.Value = txtCiVehiculoC.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(53, 60);
                    cell.Value = txtCiVehiculoC.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE UNO
                cell = worksheet.Cell(55, 15);
                cell.Value = txtAcompanante1VehiculoC.Text;

                if (txtCiAcompanante1VehiculoC.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(55, 49);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(55, 50);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(55, 52);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(55, 53);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(55, 54);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(55, 56);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(55, 57);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(55, 58);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(55, 60);
                    cell.Value = txtCiAcompanante1VehiculoC.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE DOS
                cell = worksheet.Cell(56, 15);
                cell.Value = txtAcompanante2VehiculoC.Text;

                if (txtCiAcompanante2VehiculoC.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(56, 49);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(56, 50);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(56, 52);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(56, 53);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(56, 54);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(56, 56);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(56, 57);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(56, 58);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(56, 60);
                    cell.Value = txtCiAcompanante2VehiculoC.Text[9].ToString();
                }

                // ============== FIN VEHICULOS INVOLUCRADOS (C) ==============

                // ============== VEHICULOS INVOLUCRADOS (D) ==============

                // Vehículos involucrados: TIPO
                cell = worksheet.Cell(59, 11);
                cell.Value = txtTipoVehiculoD.Text;

                // Vehículos involucrados: MARCA
                cell = worksheet.Cell(59, 24);
                cell.Value = txtMarcaVehiculoD.Text;

                // Vehículos involucrados: MODELO
                cell = worksheet.Cell(59, 38);
                cell.Value = txtModeloVehiculoD.Text;

                if (txtPatenteVehiculoD.Text.Count() == 6)
                {
                    // Vehículos involucrados: PATENTE 54
                    cell = worksheet.Cell(59, 54);
                    cell.Value = txtPatenteVehiculoD.Text[0].ToString();

                    // Vehículos involucrados: PATENTE 55
                    cell = worksheet.Cell(59, 55);
                    cell.Value = txtPatenteVehiculoD.Text[1].ToString();

                    // Vehículos involucrados: PATENTE 57
                    cell = worksheet.Cell(59, 57);
                    cell.Value = txtPatenteVehiculoD.Text[2].ToString();

                    // Vehículos involucrados: PATENTE 58
                    cell = worksheet.Cell(59, 58);
                    cell.Value = txtPatenteVehiculoD.Text[3].ToString();

                    // Vehículos involucrados: PATENTE 59
                    cell = worksheet.Cell(59, 59);
                    cell.Value = txtPatenteVehiculoD.Text[4].ToString();

                    // Vehículos involucrados: PATENTE 60
                    cell = worksheet.Cell(59, 60);
                    cell.Value = txtPatenteVehiculoD.Text[5].ToString();
                }

                // Vehículos involucrados: CONDUCTOR
                cell = worksheet.Cell(61, 15);
                cell.Value = txtConductorVehiculoD.Text;

                if (txtCiVehiculoD.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(61, 49);
                    cell.Value = txtCiVehiculoD.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(61, 50);
                    cell.Value = txtCiVehiculoD.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(61, 52);
                    cell.Value = txtCiVehiculoD.Text[2].ToString();

                    // Vehículos involucrados: C.I 61
                    cell = worksheet.Cell(61, 53);
                    cell.Value = txtCiVehiculoD.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(61, 54);
                    cell.Value = txtCiVehiculoD.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(61, 56);
                    cell.Value = txtCiVehiculoD.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(61, 57);
                    cell.Value = txtCiVehiculoD.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(61, 58);
                    cell.Value = txtCiVehiculoD.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(61, 60);
                    cell.Value = txtCiVehiculoD.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE UNO
                cell = worksheet.Cell(63, 15);
                cell.Value = txtAcompanante1VehiculoD.Text;

                if (txtCiAcompanante1VehiculoD.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(63, 49);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(63, 50);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(63, 52);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(63, 53);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(63, 54);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[4].ToString();

                    // Vehículos involucrados: C.I 56
                    cell = worksheet.Cell(63, 56);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(63, 57);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(63, 58);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(63, 60);
                    cell.Value = txtCiAcompanante1VehiculoD.Text[9].ToString();
                }

                // Vehículos involucrados: COMPAÑANTE DOS
                cell = worksheet.Cell(64, 15);
                cell.Value = txtAcompanante2VehiculoD.Text;

                if (txtCiAcompanante2VehiculoD.Text.Count() == 10)
                {
                    // Vehículos involucrados: C.I 49
                    cell = worksheet.Cell(64, 49);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[0].ToString();

                    // Vehículos involucrados: C.I 50
                    cell = worksheet.Cell(64, 50);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[1].ToString();

                    // Vehículos involucrados: C.I 52
                    cell = worksheet.Cell(64, 52);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[2].ToString();

                    // Vehículos involucrados: C.I 53
                    cell = worksheet.Cell(64, 53);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[3].ToString();

                    // Vehículos involucrados: C.I 54
                    cell = worksheet.Cell(64, 54);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[4].ToString();

                    // Vehículos involucrados: C.I 64
                    cell = worksheet.Cell(64, 56);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[5].ToString();

                    // Vehículos involucrados: C.I 57
                    cell = worksheet.Cell(64, 57);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[6].ToString();

                    // Vehículos involucrados: C.I 58
                    cell = worksheet.Cell(64, 58);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[7].ToString();

                    // Vehículos involucrados: C.I 60
                    cell = worksheet.Cell(64, 60);
                    cell.Value = txtCiAcompanante2VehiculoD.Text[9].ToString();
                }

                // ============== FIN VEHICULOS INVOLUCRADOS (D) ==============

                // ============== LESIONADOS O FALLECIDOS (A) =================

                // Lesionados o Fallecidos: NOMBRE
                cell = worksheet.Cell(69, 13);
                cell.Value = txtNombreLesionadoUno.Text;

                if (txtCiLesionadoUno.Text.Count() == 10)
                {
                    // Lesionados o Fallecidos: C.I 49
                    cell = worksheet.Cell(69, 49);
                    cell.Value = txtCiLesionadoUno.Text[0].ToString();

                    // Lesionados o Fallecidos: C.I 50
                    cell = worksheet.Cell(69, 50);
                    cell.Value = txtCiLesionadoUno.Text[1].ToString();

                    // Lesionados o Fallecidos: C.I 52
                    cell = worksheet.Cell(69, 52);
                    cell.Value = txtCiLesionadoUno.Text[2].ToString();

                    // Lesionados o Fallecidos: C.I 53
                    cell = worksheet.Cell(69, 53);
                    cell.Value = txtCiLesionadoUno.Text[3].ToString();

                    // Lesionados o Fallecidos: C.I 54
                    cell = worksheet.Cell(69, 54);
                    cell.Value = txtCiLesionadoUno.Text[4].ToString();

                    // Lesionados o Fallecidos: C.I 64
                    cell = worksheet.Cell(69, 56);
                    cell.Value = txtCiLesionadoUno.Text[5].ToString();

                    // Lesionados o Fallecidos: C.I 57
                    cell = worksheet.Cell(69, 57);
                    cell.Value = txtCiLesionadoUno.Text[6].ToString();

                    // Lesionados o Fallecidos: C.I 58
                    cell = worksheet.Cell(69, 58);
                    cell.Value = txtCiLesionadoUno.Text[7].ToString();

                    // Lesionados o Fallecidos: C.I 60
                    cell = worksheet.Cell(69, 60);
                    cell.Value = txtCiLesionadoUno.Text[9].ToString();
                }

                // Lesionados o Fallecidos: VEHICULO A
                cell = worksheet.Cell(70, 49);
                cell.Value = txtVehiculoVeniaAUno_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO B
                cell = worksheet.Cell(70, 59);
                cell.Value = txtVehiculoVeniaBUno_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO C
                cell = worksheet.Cell(71, 49);
                cell.Value = txtVehiculoVeniaAUno_Dos.Text;

                // Lesionados o Fallecidos: VEHICULO D
                cell = worksheet.Cell(71, 59);
                cell.Value = txtVehiculoVeniaBUno_Dos.Text;

                if (chConsienteUnoSi.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE SI
                    cell = worksheet.Cell(72, 19);
                    cell.Value = "X";
                }
                else if (chConsienteUnoNo.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE NO
                    cell = worksheet.Cell(72, 22);
                    cell.Value = "X";
                }

                if (chLlesoSiUno.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(73, 19);
                    cell.Value = "X";
                }
                else if (chLlesoNoUno.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(73, 22);
                    cell.Value = "X";
                }

                if (chFracturasVisiblesSiUno.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(74, 19);
                    cell.Value = "X";
                }
                else if (chFracturasVisiblesNoUno.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(74, 22);
                    cell.Value = "X";
                }

                if (chHeridasVisiblesSiUno.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES SI
                    cell = worksheet.Cell(75, 19);
                    cell.Value = "X";
                }
                else if (chHeridasVisiblesNoUno.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES NO
                    cell = worksheet.Cell(75, 22);
                    cell.Value = "X";
                }

                if (chManiobrasRCPSiUno.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP SI
                    cell = worksheet.Cell(76, 19);
                    cell.Value = "X";
                }
                else if (chManiobrasRCPNoUno.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP NO
                    cell = worksheet.Cell(76, 22);
                    cell.Value = "X";
                }

                // Lesionados o Fallecidos: Lugar en que se le encontró.
                cell = worksheet.Cell(72, 42);
                cell.Value = txtLugarEncuentroUno.Text;

                // Lesionados o Fallecidos: Si se encontraba atrapada, que lo retenía
                cell = worksheet.Cell(73, 50);
                cell.Value = txtAtrapadoReteniaUno.Text;

                // Lesionados o Fallecidos: Detallar fracturas
                cell = worksheet.Cell(74, 36);
                cell.Value = txtDetalleFracturaUno.Text;

                // Lesionados o Fallecidos: Detallar heridas
                cell = worksheet.Cell(75, 35);
                cell.Value = DetalleFracturasUno.Text;

                // Lesionados o Fallecidos: Otras lesiones detallar
                cell = worksheet.Cell(77, 23);
                cell.Value = txtOtrasLesionesUno.Text;

                // Lesionados o Fallecidos: Traslado A
                cell = worksheet.Cell(78, 16);
                cell.Value = TrasladoAUno.Text;

                // Lesionados o Fallecidos: Por
                cell = worksheet.Cell(78, 37);
                cell.Value = PorUno.Text;

                // Lesionados o Fallecidos: Móvil Número
                cell = worksheet.Cell(78, 53);
                cell.Value = NumeroMovilUno.Text;

                // ============== FIN LESIONADOS O FALLECIDOS (A) =================

                // ============== LESIONADOS O FALLECIDOS (B) =================

                // Lesionados o Fallecidos: NOMBRE
                cell = worksheet.Cell(81, 13);
                cell.Value = txtNombreLesionadoDos.Text;

                if (txtCiLesionadoDos.Text.Count() == 10)
                {
                    // Lesionados o Fallecidos: C.I 49
                    cell = worksheet.Cell(81, 49);
                    cell.Value = txtCiLesionadoDos.Text[0].ToString();

                    // Lesionados o Fallecidos: C.I 50
                    cell = worksheet.Cell(81, 50);
                    cell.Value = txtCiLesionadoDos.Text[1].ToString();

                    // Lesionados o Fallecidos: C.I 52
                    cell = worksheet.Cell(81, 52);
                    cell.Value = txtCiLesionadoDos.Text[2].ToString();

                    // Lesionados o Fallecidos: C.I 53
                    cell = worksheet.Cell(81, 53);
                    cell.Value = txtCiLesionadoDos.Text[3].ToString();

                    // Lesionados o Fallecidos: C.I 54
                    cell = worksheet.Cell(81, 54);
                    cell.Value = txtCiLesionadoDos.Text[4].ToString();

                    // Lesionados o Fallecidos: C.I 64
                    cell = worksheet.Cell(81, 56);
                    cell.Value = txtCiLesionadoDos.Text[5].ToString();

                    // Lesionados o Fallecidos: C.I 57
                    cell = worksheet.Cell(81, 57);
                    cell.Value = txtCiLesionadoDos.Text[6].ToString();

                    // Lesionados o Fallecidos: C.I 58
                    cell = worksheet.Cell(81, 58);
                    cell.Value = txtCiLesionadoDos.Text[7].ToString();

                    // Lesionados o Fallecidos: C.I 60
                    cell = worksheet.Cell(81, 60);
                    cell.Value = txtCiLesionadoDos.Text[9].ToString();
                }

                // Lesionados o Fallecidos: VEHICULO A
                cell = worksheet.Cell(82, 49);
                cell.Value = txtVehiculoVeniaADos_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO B
                cell = worksheet.Cell(82, 59);
                cell.Value = txtVehiculoVeniaBDos_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO C
                cell = worksheet.Cell(83, 49);
                cell.Value = txtVehiculoVeniaADos_Dos.Text;

                // Lesionados o Fallecidos: VEHICULO D
                cell = worksheet.Cell(83, 59);
                cell.Value = txtVehiculoVeniaBDos_Dos.Text;

                if (chConsienteDosSi.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE SI
                    cell = worksheet.Cell(84, 19);
                    cell.Value = "X";
                }
                else if (chConsienteDosNo.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE NO
                    cell = worksheet.Cell(84, 22);
                    cell.Value = "X";
                }

                if (chLlesoSiDos.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(85, 19);
                    cell.Value = "X";
                }
                else if (chLlesoNoDos.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(85, 22);
                    cell.Value = "X";
                }

                if (chFracturasVisiblesSiDos.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(86, 19);
                    cell.Value = "X";
                }
                else if (chFracturasVisiblesNoDos.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(86, 22);
                    cell.Value = "X";
                }

                if (chHeridasVisiblesSiDos.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES SI
                    cell = worksheet.Cell(87, 19);
                    cell.Value = "X";
                }
                else if (chHeridasVisiblesNoDos.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES NO
                    cell = worksheet.Cell(87, 22);
                    cell.Value = "X";
                }

                if (chManiobrasRCPSiDos.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP SI
                    cell = worksheet.Cell(88, 19);
                    cell.Value = "X";
                }
                else if (chManiobrasRCPNoDos.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP NO
                    cell = worksheet.Cell(88, 22);
                    cell.Value = "X";
                }

                // Lesionados o Fallecidos: Lugar en que se le encontró.
                cell = worksheet.Cell(84, 42);
                cell.Value = txtLugarEncuentroDos.Text;

                // Lesionados o Fallecidos: Si se encontraba atrapada, que lo retenía
                cell = worksheet.Cell(85, 50);
                cell.Value = txtAtrapadoReteniaDos.Text;

                // Lesionados o Fallecidos: Detallar fracturas
                cell = worksheet.Cell(86, 36);
                cell.Value = txtDetalleFracturaDos.Text;

                // Lesionados o Fallecidos: Detallar heridas
                cell = worksheet.Cell(87, 35);
                cell.Value = DetalleFracturasDos.Text;

                // Lesionados o Fallecidos: Otras lesiones detallar
                cell = worksheet.Cell(89, 23);
                cell.Value = txtOtrasLesionesDos.Text;

                // Lesionados o Fallecidos: Traslado A
                cell = worksheet.Cell(90, 16);
                cell.Value = TrasladoADos.Text;

                // Lesionados o Fallecidos: Por
                cell = worksheet.Cell(90, 37);
                cell.Value = PorDos.Text;

                // Lesionados o Fallecidos: Móvil Número
                cell = worksheet.Cell(90, 53);
                cell.Value = NumeroMovilDos.Text;

                // ============== FIN LESIONADOS O FALLECIDOS (B) =================

                // ============== LESIONADOS O FALLECIDOS (C) =================

                // Lesionados o Fallecidos: NOMBRE
                cell = worksheet.Cell(93, 13);
                cell.Value = txtNombreLesionadoTres.Text;

                if (txtCiLesionadoTres.Text.Count() == 10)
                {
                    // Lesionados o Fallecidos: C.I 49
                    cell = worksheet.Cell(93, 49);
                    cell.Value = txtCiLesionadoTres.Text[0].ToString();

                    // Lesionados o Fallecidos: C.I 50
                    cell = worksheet.Cell(93, 50);
                    cell.Value = txtCiLesionadoTres.Text[1].ToString();

                    // Lesionados o Fallecidos: C.I 52
                    cell = worksheet.Cell(93, 52);
                    cell.Value = txtCiLesionadoTres.Text[2].ToString();

                    // Lesionados o Fallecidos: C.I 53
                    cell = worksheet.Cell(93, 53);
                    cell.Value = txtCiLesionadoTres.Text[3].ToString();

                    // Lesionados o Fallecidos: C.I 54
                    cell = worksheet.Cell(93, 54);
                    cell.Value = txtCiLesionadoTres.Text[4].ToString();

                    // Lesionados o Fallecidos: C.I 64
                    cell = worksheet.Cell(93, 56);
                    cell.Value = txtCiLesionadoTres.Text[5].ToString();

                    // Lesionados o Fallecidos: C.I 57
                    cell = worksheet.Cell(93, 57);
                    cell.Value = txtCiLesionadoTres.Text[6].ToString();

                    // Lesionados o Fallecidos: C.I 58
                    cell = worksheet.Cell(93, 58);
                    cell.Value = txtCiLesionadoTres.Text[7].ToString();

                    // Lesionados o Fallecidos: C.I 60
                    cell = worksheet.Cell(93, 60);
                    cell.Value = txtCiLesionadoTres.Text[9].ToString();
                }

                // Lesionados o Fallecidos: VEHICULO A
                cell = worksheet.Cell(94, 49);
                cell.Value = txtVehiculoVeniaATres_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO B
                cell = worksheet.Cell(94, 59);
                cell.Value = txtVehiculoVeniaBTres_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO C
                cell = worksheet.Cell(95, 49);
                cell.Value = txtVehiculoVeniaATres_Dos.Text;

                // Lesionados o Fallecidos: VEHICULO D
                cell = worksheet.Cell(95, 59);
                cell.Value = txtVehiculoVeniaBTres_Dos.Text;

                if (chConsienteTresSi.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE SI
                    cell = worksheet.Cell(96, 19);
                    cell.Value = "X";
                }
                else if (chConsienteTresNo.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE NO
                    cell = worksheet.Cell(96, 22);
                    cell.Value = "X";
                }

                if (chLlesoSiTres.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(97, 19);
                    cell.Value = "X";
                }
                else if (chLlesoNoTres.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(97, 22);
                    cell.Value = "X";
                }

                if (chFracturasVisiblesSiTres.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(98, 19);
                    cell.Value = "X";
                }
                else if (chFracturasVisiblesNoTres.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(98, 22);
                    cell.Value = "X";
                }

                if (chHeridasVisiblesSiTres.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES SI
                    cell = worksheet.Cell(99, 19);
                    cell.Value = "X";
                }
                else if (chHeridasVisiblesNoTres.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES NO
                    cell = worksheet.Cell(99, 22);
                    cell.Value = "X";
                }

                if (chManiobrasRCPSiTres.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP SI
                    cell = worksheet.Cell(100, 19);
                    cell.Value = "X";
                }
                else if (chManiobrasRCPNoTres.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP NO
                    cell = worksheet.Cell(100, 22);
                    cell.Value = "X";
                }

                // Lesionados o Fallecidos: Lugar en que se le encontró.
                cell = worksheet.Cell(96, 42);
                cell.Value = txtLugarEncuentroTres.Text;

                // Lesionados o Fallecidos: Si se encontraba atrapada, que lo retenía
                cell = worksheet.Cell(97, 50);
                cell.Value = txtAtrapadoReteniaTres.Text;

                // Lesionados o Fallecidos: Detallar fracturas
                cell = worksheet.Cell(98, 36);
                cell.Value = txtDetalleFracturaTres.Text;

                // Lesionados o Fallecidos: Detallar heridas
                cell = worksheet.Cell(99, 35);
                cell.Value = DetalleFracturasTres.Text;

                // Lesionados o Fallecidos: Otras lesiones detallar
                cell = worksheet.Cell(101, 23);
                cell.Value = txtOtrasLesionesTres.Text;

                // Lesionados o Fallecidos: Traslado A
                cell = worksheet.Cell(102, 16);
                cell.Value = TrasladoATres.Text;

                // Lesionados o Fallecidos: Por
                cell = worksheet.Cell(102, 37);
                cell.Value = PorTres.Text;

                // Lesionados o Fallecidos: Móvil Número
                cell = worksheet.Cell(102, 53);
                cell.Value = NumeroMovilTres.Text;

                // ============== FIN LESIONADOS O FALLECIDOS (C) =================

                // ============== LESIONADOS O FALLECIDOS (D) =================

                // Lesionados o Fallecidos: NOMBRE
                cell = worksheet.Cell(106, 13);
                cell.Value = txtNombreLesionadoCuatro.Text;

                if (txtCiLesionadoCuatro.Text.Count() == 10)
                {
                    // Lesionados o Fallecidos: C.I 49
                    cell = worksheet.Cell(106, 49);
                    cell.Value = txtCiLesionadoCuatro.Text[0].ToString();

                    // Lesionados o Fallecidos: C.I 50
                    cell = worksheet.Cell(106, 50);
                    cell.Value = txtCiLesionadoCuatro.Text[1].ToString();

                    // Lesionados o Fallecidos: C.I 52
                    cell = worksheet.Cell(106, 52);
                    cell.Value = txtCiLesionadoCuatro.Text[2].ToString();

                    // Lesionados o Fallecidos: C.I 53
                    cell = worksheet.Cell(106, 53);
                    cell.Value = txtCiLesionadoCuatro.Text[3].ToString();

                    // Lesionados o Fallecidos: C.I 54
                    cell = worksheet.Cell(106, 54);
                    cell.Value = txtCiLesionadoCuatro.Text[4].ToString();

                    // Lesionados o Fallecidos: C.I 64
                    cell = worksheet.Cell(106, 56);
                    cell.Value = txtCiLesionadoCuatro.Text[5].ToString();

                    // Lesionados o Fallecidos: C.I 57
                    cell = worksheet.Cell(106, 57);
                    cell.Value = txtCiLesionadoCuatro.Text[6].ToString();

                    // Lesionados o Fallecidos: C.I 58
                    cell = worksheet.Cell(106, 58);
                    cell.Value = txtCiLesionadoCuatro.Text[7].ToString();

                    // Lesionados o Fallecidos: C.I 60
                    cell = worksheet.Cell(106, 60);
                    cell.Value = txtCiLesionadoCuatro.Text[9].ToString();
                }

                // Lesionados o Fallecidos: VEHICULO A
                cell = worksheet.Cell(107, 49);
                cell.Value = txtVehiculoVeniaACuatro_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO B
                cell = worksheet.Cell(107, 59);
                cell.Value = txtVehiculoVeniaBCuatro_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO C
                cell = worksheet.Cell(108, 49);
                cell.Value = txtVehiculoVeniaACuatro_Dos.Text;

                // Lesionados o Fallecidos: VEHICULO D
                cell = worksheet.Cell(108, 59);
                cell.Value = txtVehiculoVeniaBCuatro_Dos.Text;

                if (chConsienteCuatroSi.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE SI
                    cell = worksheet.Cell(109, 19);
                    cell.Value = "X";
                }
                else if (chConsienteCuatroNo.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE NO
                    cell = worksheet.Cell(109, 22);
                    cell.Value = "X";
                }

                if (chLlesoSiCuatro.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(110, 19);
                    cell.Value = "X";
                }
                else if (chLlesoNoCuatro.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(110, 22);
                    cell.Value = "X";
                }

                if (chFracturasVisiblesSiCuatro.Checked)
                {
                    // Lesionados o Fallecidos: FRACTURA VISIBLE SI
                    cell = worksheet.Cell(111, 19);
                    cell.Value = "X";
                }
                else if (chFracturasVisiblesNoCuatro.Checked)
                {
                    // Lesionados o Fallecidos: FRACTURA VISIBLE NO
                    cell = worksheet.Cell(111, 22);
                    cell.Value = "X";
                }

                if (chHeridasVisiblesSiCuatro.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES SI
                    cell = worksheet.Cell(112, 19);
                    cell.Value = "X";
                }
                else if (chHeridasVisiblesNoCuatro.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES NO
                    cell = worksheet.Cell(112, 22);
                    cell.Value = "X";
                }

                if (chManiobrasRCPSiCuatro.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP SI
                    cell = worksheet.Cell(113, 19);
                    cell.Value = "X";
                }
                else if (chManiobrasRCPNoCuatro.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP NO
                    cell = worksheet.Cell(113, 22);
                    cell.Value = "X";
                }

                // Lesionados o Fallecidos: Lugar en que se le encontró.
                cell = worksheet.Cell(109, 42);
                cell.Value = txtLugarEncuentroCuatro.Text;

                // Lesionados o Fallecidos: Si se encontraba atrapada, que lo retenía
                cell = worksheet.Cell(110, 50);
                cell.Value = txtAtrapadoReteniaCuatro.Text;

                // Lesionados o Fallecidos: Detallar fracturas
                cell = worksheet.Cell(111, 36);
                cell.Value = txtDetalleFracturaCuatro.Text;

                // Lesionados o Fallecidos: Detallar heridas
                cell = worksheet.Cell(112, 35);
                cell.Value = DetalleFracturasCuatro.Text;

                // Lesionados o Fallecidos: Otras lesiones detallar
                cell = worksheet.Cell(114, 23);
                cell.Value = txtOtrasLesionesCuatro.Text;

                // Lesionados o Fallecidos: Traslado A
                cell = worksheet.Cell(115, 16);
                cell.Value = TrasladoACuatro.Text;

                // Lesionados o Fallecidos: Por
                cell = worksheet.Cell(115, 37);
                cell.Value = PorCuatro.Text;

                // Lesionados o Fallecidos: Móvil Número
                cell = worksheet.Cell(115, 53);
                cell.Value = NumeroMovilCuatro.Text;

                // ============== FIN LESIONADOS O FALLECIDOS (D) =================

                // ============== LESIONADOS O FALLECIDOS (E) =================

                // Lesionados o Fallecidos: NOMBRE
                cell = worksheet.Cell(118, 13);
                cell.Value = txtNombreLesionadoCinco.Text;

                if (txtCiLesionadoCinco.Text.Count() == 10)
                {
                    // Lesionados o Fallecidos: C.I 49
                    cell = worksheet.Cell(118, 49);
                    cell.Value = txtCiLesionadoCinco.Text[0].ToString();

                    // Lesionados o Fallecidos: C.I 50
                    cell = worksheet.Cell(118, 50);
                    cell.Value = txtCiLesionadoCinco.Text[1].ToString();

                    // Lesionados o Fallecidos: C.I 52
                    cell = worksheet.Cell(118, 52);
                    cell.Value = txtCiLesionadoCinco.Text[2].ToString();

                    // Lesionados o Fallecidos: C.I 53
                    cell = worksheet.Cell(118, 53);
                    cell.Value = txtCiLesionadoCinco.Text[3].ToString();

                    // Lesionados o Fallecidos: C.I 54
                    cell = worksheet.Cell(118, 54);
                    cell.Value = txtCiLesionadoCinco.Text[4].ToString();

                    // Lesionados o Fallecidos: C.I 64
                    cell = worksheet.Cell(118, 56);
                    cell.Value = txtCiLesionadoCinco.Text[5].ToString();

                    // Lesionados o Fallecidos: C.I 57
                    cell = worksheet.Cell(118, 57);
                    cell.Value = txtCiLesionadoCinco.Text[6].ToString();

                    // Lesionados o Fallecidos: C.I 58
                    cell = worksheet.Cell(118, 58);
                    cell.Value = txtCiLesionadoCinco.Text[7].ToString();

                    // Lesionados o Fallecidos: C.I 60
                    cell = worksheet.Cell(118, 60);
                    cell.Value = txtCiLesionadoCinco.Text[9].ToString();
                }

                // Lesionados o Fallecidos: VEHICULO A
                cell = worksheet.Cell(119, 49);
                cell.Value = txtVehiculoVeniaACinco_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO B
                cell = worksheet.Cell(119, 59);
                cell.Value = txtVehiculoVeniaBCinco_Uno.Text;

                // Lesionados o Fallecidos: VEHICULO C
                cell = worksheet.Cell(120, 49);
                cell.Value = txtVehiculoVeniaACinco_Dos.Text;

                // Lesionados o Fallecidos: VEHICULO D
                cell = worksheet.Cell(120, 59);
                cell.Value = txtVehiculoVeniaBCinco_Dos.Text;

                if (chConsienteCincoSi.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE SI
                    cell = worksheet.Cell(121, 19);
                    cell.Value = "X";
                }
                else if (chConsienteCincoNo.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO CONSIENTE NO
                    cell = worksheet.Cell(121, 22);
                    cell.Value = "X";
                }

                if (chLlesoSiCinco.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO SI
                    cell = worksheet.Cell(122, 19);
                    cell.Value = "X";
                }
                else if (chLlesoNoCinco.Checked)
                {
                    // Lesionados o Fallecidos: ESTADO LLESO NO
                    cell = worksheet.Cell(122, 22);
                    cell.Value = "X";
                }

                if (chFracturasVisiblesSiCinco.Checked)
                {
                    // Lesionados o Fallecidos: FRACTURA VISIBLE SI
                    cell = worksheet.Cell(123, 19);
                    cell.Value = "X";
                }
                else if (chFracturasVisiblesNoCinco.Checked)
                {
                    // Lesionados o Fallecidos: FRACTURA VISIBLE NO
                    cell = worksheet.Cell(123, 22);
                    cell.Value = "X";
                }

                if (chHeridasVisiblesSiCinco.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES SI
                    cell = worksheet.Cell(124, 19);
                    cell.Value = "X";
                }
                else if (chHeridasVisiblesNoCinco.Checked)
                {
                    // Lesionados o Fallecidos: HERIDAS VISIBLES NO
                    cell = worksheet.Cell(124, 22);
                    cell.Value = "X";
                }

                if (chManiobrasRCPSiCinco.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP SI
                    cell = worksheet.Cell(125, 19);
                    cell.Value = "X";
                }
                else if (chManiobrasRCPNoCinco.Checked)
                {
                    // Lesionados o Fallecidos: MANIOBRAS RCP NO
                    cell = worksheet.Cell(125, 22);
                    cell.Value = "X";
                }

                // Lesionados o Fallecidos: Lugar en que se le encontró.
                cell = worksheet.Cell(121, 42);
                cell.Value = txtLugarEncuentroCinco.Text;

                // Lesionados o Fallecidos: Si se encontraba atrapada, que lo retenía
                cell = worksheet.Cell(122, 50);
                cell.Value = txtAtrapadoReteniaCinco.Text;

                // Lesionados o Fallecidos: Detallar fracturas
                cell = worksheet.Cell(123, 36);
                cell.Value = txtDetalleFracturaCinco.Text;

                // Lesionados o Fallecidos: Detallar heridas
                cell = worksheet.Cell(124, 35);
                cell.Value = DetalleFracturasCinco.Text;

                // Lesionados o Fallecidos: Otras lesiones detallar
                cell = worksheet.Cell(126, 23);
                cell.Value = txtOtrasLesionesCinco.Text;

                // Lesionados o Fallecidos: Traslado A
                cell = worksheet.Cell(127, 16);
                cell.Value = TrasladoACinco.Text;

                // Lesionados o Fallecidos: Por
                cell = worksheet.Cell(127, 37);
                cell.Value = PorCinco.Text;

                // Lesionados o Fallecidos: Móvil Número
                cell = worksheet.Cell(127, 53);
                cell.Value = NumeroMovilCinco.Text;

                // ============== FIN LESIONADOS O FALLECIDOS (E) =================

                // ============== SERVICIO POLICIAL ===============================

                if (spConcurrioSi.Checked)
                {
                    cell = worksheet.Cell(132, 19);
                    cell.Value = "X";
                }

                if (spConcurrioNo.Checked)
                {
                    cell = worksheet.Cell(132, 25);
                    cell.Value = "X";
                }

                cell = worksheet.Cell(132, 36);
                cell.Value = spAcargo.Text;

                cell = worksheet.Cell(133, 13);
                cell.Value = spUnidad.Text;
                    
                cell = worksheet.Cell(133, 40);
                cell.Value = spRPNumero.Text;

                cell = worksheet.Cell(133, 46);
                cell.Value = spZNumero.Text;

                // ============= FIN SERVICIO POLICIAL =============================

                // ============= SERVICIO MEDICO ===================================
                if (smConcurrioSi.Checked)
                {
                    cell = worksheet.Cell(138, 18);
                    cell.Value = "X";
                }

                if (smConcurrioNo.Checked)
                {
                    cell = worksheet.Cell(138, 25);
                    cell.Value = "X";
                }

                cell = worksheet.Cell(138, 35);
                cell.Value = smAcargo.Text;

                if (smUnidadSamu.Checked)
                {
                    cell = worksheet.Cell(140, 15);
                    cell.Value = "X";
                }

                if (smSapu.Checked)
                {
                    cell = worksheet.Cell(140, 25);
                    cell.Value = "X";
                }

                if (smPrivado.Checked)
                {
                    cell = worksheet.Cell(140, 36);
                    cell.Value = "X";
                }

                cell = worksheet.Cell(140, 46);
                cell.Value = txtOtro.Text;

                // =============== FIN SERVICIO MEDICO ====================

                // =============== OTROS ==================================

                cell = worksheet.Cell(144, 17);
                cell.Value = ResumenActo.Text;

                cell = worksheet.Cell(153, 7);
                cell.Value = MaterialInmovilizacionUtilizado.Text;

                cell = worksheet.Cell(163, 7);
                cell.Value = label175.Text;

                cell = worksheet.Cell(163, 46);
                cell.Value = apoyoOtrosCuerpos.Text;

                // ========================================================

                xlPackage.Save();
            }

            System.Diagnostics.Process.Start(nuevoArchivo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void txtCorrelativoCompania_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCorrelativoCBPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void apoyoOtrosCuerpos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
