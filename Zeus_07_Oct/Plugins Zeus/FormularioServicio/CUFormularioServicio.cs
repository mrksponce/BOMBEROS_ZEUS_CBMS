using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zeus.Data;

namespace FormularioServicio
{
    public partial class CUFormularioServicio : UserControl
    {
        public CUFormularioServicio()
        {
            InitializeComponent();
        }

        private void CUFormularioServicio_Load(object sender, EventArgs e)
        {
            LlenarCamposIniciales();

            gvDatosGrilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gvDatosGrilla.ColumnHeadersHeight = 90;
            // Here we attach an event handler to the cell painting event
            gvDatosGrilla.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);

            DataSet DatosEncabezado = ClaseFormularioServicio.GetFormularioServicioEncabezado(Zeus.Util.RecursosEstaticos.IdExpediente);
            foreach (DataRow row in DatosEncabezado.Tables[0].Rows)
            {
                if (txtDia.Text.Equals("") && txtMes.Text.Equals("") && txtAnio.Text.Equals(""))
                {
                    txtDia.Text = row["dia"].ToString();
                    txtMes.Text = row["mes"].ToString();
                    txtAnio.Text = row["anio"].ToString();
                }

                txtHoraInicio.Text = row["horaInicio"].ToString();
                txtHoraTermino.Text = row["horaTermino"].ToString();
                CBMotivoAlarma.Text = row["motivoAlarma"].ToString();
                txtCorrelativoCBPA.Text = row["correlativoCBPA"].ToString();
                txtCorrelativoCompania.Text = row["correlativoCompania"].ToString();
                CBClaveDespacho.Text = row["claveDespacho"].ToString();
                TxtEnviadoAl.Text = row["enviadoAL"].ToString();
                txtJuzgadoDe.Text = row["juzgadoDe"].ToString();
                txtOficioNumero.Text = row["oficioNumero"].ToString();
                txtRol.Text = row["rolNumero"].ToString();

                if (txtDireccionServicio.Text.Equals(""))
                {
                    txtDireccionServicio.Text = row["direccion"].ToString();
                }
                
                txtNumeroServicio.Text = row["numero"].ToString();
                txtBlockServicio.Text = row["block"].ToString();
                txtDeptoServicio.Text = row["departamento"].ToString();
                txtEsquinaServicio.Text = row["esquina"].ToString();
                txtSectorServicio.Text = row["sector"].ToString();
                ddlComunaEmergencia.Text = row["comuna"].ToString();
                txtOcupadoPorServicio.Text = row["ocupadoPor"].ToString();
                txtRutServicio.Text = row["rut"].ToString();

                if (row["propietario"].ToString().Equals("Propietario"))
                { 
                    rbPropietario.Checked = true;
                }
                else if (row["propietario"].ToString().Equals("Arrendatario"))
                {
                    rbArrendatario.Checked = true;
                }
                else if (row["propietario"].ToString().Equals("Allegado"))
                {
                    rbAllegado.Checked = true;
                }

                txtNumeroAdultosServicio.Text = row["numeroAdultos"].ToString();
                txtNumeroNinosServicio.Text = row["numeroNinos"].ToString();
            }

            DataSet Ds2 = ClaseFormularioServicio.GetFormularioServicioNaturalezaLugar(Zeus.Util.RecursosEstaticos.IdExpediente);
            foreach (DataRow row in Ds2.Tables[0].Rows)
            {
                if (!row["vivienda"].ToString().Equals(""))
                {
                    cbVivienda.Checked = true;
                }

                if (!row["departamento"].ToString().Equals(""))
                {
                    cbDepartamento.Checked = true;
                }

                if (!row["negocio"].ToString().Equals(""))
                {
                    cbNegocio.Checked = true;
                }

                if (!row["edificiopublico"].ToString().Equals(""))
                {
                    cbEdifPublico.Checked = true;
                }

                if (!row["industria"].ToString().Equals(""))
                {
                    cbIndustria.Checked = true;
                }

                if (!row["sitioeriazo"].ToString().Equals(""))
                {
                    cbSitioEriazo.Checked = true;
                }

                if (!row["esteducacional"].ToString().Equals(""))
                {
                    cbEstEducacional.Checked = true;
                }

                if (!row["viapublica"].ToString().Equals(""))
                {
                    cbViaPublica.Checked = true;
                }

                if (!row["mejora"].ToString().Equals(""))
                {
                    cbMejora.Checked = true;
                }

                if (!row["otro"].ToString().Equals(""))
                {
                    cbOtroNaturalezaLugar.Checked = true;
                }

                if (!row["descripcionotro"].ToString().Equals(""))
                {
                    txtOtroNaturalezaLugar.Text = row["descripcionotro"].ToString();
                }

                if (!row["vehiculotipomarca"].ToString().Equals(""))
                {
                    cbVehiculoTipoMarca.Checked = true;
                }

                if (!row["descripciontipomarcauno"].ToString().Equals(""))
                {
                    txtDatosVehiculoUno.Text = row["descripciontipomarcauno"].ToString();
                }

                if (!row["patentetipomarcauno"].ToString().Equals(""))
                {
                    txtPatenteVehiculoUno.Text = row["patentetipomarcauno"].ToString();
                }

                if (!row["descripciontipomarcados"].ToString().Equals(""))
                {
                    txtDatosVehiculoDos.Text = row["descripciontipomarcados"].ToString();
                }

                if (!row["patentetipomarcados"].ToString().Equals(""))
                {
                    txtPatenteVehiculoDos.Text = row["patentetipomarcados"].ToString();
                }
            }
        }

        private void LlenarCamposIniciales()
        {
            e_expedientes exp = new e_expedientes();
            exp = exp.getObjecte_expedientes(Zeus.Util.RecursosEstaticos.IdExpediente);

            txtDia.Text = exp.fecha.ToString("dd");
            txtMes.Text = exp.fecha.ToString("MM");
            txtAnio.Text = exp.fecha.ToString("yyyy");

            txtHoraInicio.Text = exp.fecha.ToString("hh:MM");

            txtDireccionServicio.Text = exp.cero5;
            txtEsquinaServicio.Text = exp.seis2;

            ddlComunaEmergencia.Text = exp.comuna;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // check that we are in a header cell!
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                string texto = gvDatosGrilla.Columns[e.ColumnIndex].HeaderText;

                if (texto.Equals("Propietario") 
                    || texto.Equals("Arrendatario") 
                    || texto.Equals("Allegado") 
                    || texto.Equals("Otro")
                    || texto.Equals("Adultos")
                    || texto.Equals("Menores")
                    || texto.Equals("Vivienda")
                    || texto.Equals("Enseres")
                    || texto.Equals("Vehículo"))
                {
                    e.PaintBackground(e.ClipBounds, true);
                    Rectangle rect = this.gvDatosGrilla.GetColumnDisplayRectangle(e.ColumnIndex, true);
                    Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
                    if (this.gvDatosGrilla.ColumnHeadersHeight < titleSize.Width)
                    {
                        this.gvDatosGrilla.ColumnHeadersHeight = titleSize.Width;
                    }

                    e.Graphics.TranslateTransform(0, titleSize.Width);
                    e.Graphics.RotateTransform(-90.0F);

                    // This is the key line for bottom alignment - we adjust the PointF based on the 
                    // ColumnHeadersHeight minus the current text width. ColumnHeadersHeight is the
                    // maximum of all the columns since we paint cells twice - though this fact
                    // may not be true in all usages!   
                    e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y - (gvDatosGrilla.ColumnHeadersHeight - titleSize.Width), rect.X));

                    // The old line for comparison
                    //e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));


                    e.Graphics.RotateTransform(90.0F);
                    e.Graphics.TranslateTransform(0, -titleSize.Width);
                    e.Handled = true;
                }
            }
        }

        private void label95_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabarInformacion_Click(object sender, EventArgs e)
        {
            ClaseFormularioServicio.DeleteFormuarioServicioExistian(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioCompaniasConcurrentes(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioConcurrieron(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioConstanciaVoluntariosLesionados(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioDatosGrilla(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioDetalleDanos(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioEncabezado(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioEspecificacionPersonal(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioLugarInicioFuego(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioNaturalezaLugar(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioOrigenCausaFuego(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioPresenciaGas(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioSegurosMaterialApoyo(Zeus.Util.RecursosEstaticos.IdExpediente);
            ClaseFormularioServicio.DeleteFormularioServicioTipoConstruccion(Zeus.Util.RecursosEstaticos.IdExpediente);

            string propietario = "";

            if(rbPropietario.Checked)
            {
                propietario = "Propietario";
            }

            if(rbArrendatario.Checked)
            {
                propietario = "Arrendatario";
            }

            if(rbAllegado.Checked)
            {
                propietario = "Allegado";
            }

            ClaseFormularioServicio.FormularioServicioEncabezado(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , txtDia.Text
                , txtMes.Text
                , txtMes.Text
                , txtHoraInicio.Text
                , txtHoraTermino.Text
                , CBMotivoAlarma.Text
                , txtCorrelativoCompania.Text
                , txtCorrelativoCBPA.Text
                , CBClaveDespacho.Text
                , TxtEnviadoAl.Text
                , txtJuzgadoDe.Text
                , txtOficioNumero.Text
                , txtRol.Text
                , txtDireccionServicio.Text
                , txtNumeroServicio.Text
                , txtBlockServicio.Text
                , txtDeptoServicio.Text
                , txtEsquinaServicio.Text
                , txtSectorServicio.Text
                , ddlComunaEmergencia.Text
                , txtOcupadoPorServicio.Text
                , txtRutServicio.Text
                , propietario
                , ""
                , ""
                , txtNumeroAdultosServicio.Text
                , txtNumeroNinosServicio.Text);

            ClaseFormularioServicio.FormularioServicioNaturalezaLugar(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , cbVivienda.Checked ? "Vivienda" : ""
                , cbDepartamento.Checked ? "Departamento" : ""
                , cbNegocio.Checked ? "Negocio" : ""
                , cbEdifPublico.Checked ? "EdifPublico" : ""
                , cbIndustria.Checked ? "Industria" : ""
                , cbSitioEriazo.Checked ? "SitioEriazo" : ""
                , cbEstEducacional.Checked ? "Educacional" : ""
                , cbViaPublica.Checked ? "ViaPublica" : ""
                , cbMejora.Checked ? "Mejora" : ""
                , cbOtroNaturalezaLugar.Checked ? "Otro" : ""
                , txtOtroNaturalezaLugar.Text
                , cbVehiculoTipoMarca.Checked ? "VehiculoTipoMarca" : ""
                ,txtDatosVehiculoUno.Text
                , txtPatenteVehiculoUno.Text
                , txtDatosVehiculoDos.Text
                , txtPatenteVehiculoDos.Text);

            ClaseFormularioServicio.FormularioServicioTipoConstruccion(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , txtNumeroPisosTipoConstruccion.Text
                , cbHormigon.Checked ? "Hormigon" : ""
                , cbAdobe.Checked ? "Adobe" : ""
                , cbAcero.Checked ? "Acero" : ""
                , cbMixta.Checked ? "Mixta" : ""
                , cbMadera.Checked ? "Madera" : ""
                , cbPreFabricado.Checked ? "Prefabricado" : ""
                , cbAlvanileria.Checked ? "Albanileria" : ""
                , cbOtroTipoConstruccion.Checked ? "Otro" : ""
                , txtOtroTipoConstruccion.Text);

            ClaseFormularioServicio.FormularioServicioLugarInicioFuego(
                Zeus.Util.RecursosEstaticos.IdExpediente
                ,txtPisoLugarInicioFuego.Text
                ,cbLiving.Checked ? "Living" : ""
                ,cbBano.Checked ? "Bano" : ""
                ,cbComedor.Checked ? "Comedor" : ""
                ,cbBodega.Checked ? "Bodega" : ""
                ,cbCocina.Checked ? "Cocina" : ""
                ,cbPatio.Checked ? "Patio" : ""
                ,cbDormitorio.Checked ? "Dormitorio" : ""
                ,cbOtroLugarInicioFuego.Checked ? "Otro" : ""
                ,txtOtroLugarInicioFuego.Text);

            string salvamiento = "";

            if (rbSiRescateSalvamentoEfectuado.Checked)
            {
                salvamiento = "Si";
            }

            if (rbNoRescateSalvamentoEfectuado.Checked)
            {
                salvamiento = "No";
            }

            ClaseFormularioServicio.FormularioServicioOrigenCausaFuego(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , txtOrigenDelFuego.Text
                , txtCausaDelFuego.Text
                , salvamiento
                , txtLesionadosMuertos.Text);

            ClaseFormularioServicio.FormularioServicioDetalleDanos(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , txtPorcentajeDanoVivienda.Text
                , txtPorcentajeDanoEnseres.Text
                , txtPorcentajeVehiculo.Text
                , txtPorcentajeLibreUno.Text
                , txtTextoPorcentajeLibreUno.Text
                , txtPorcentajeLibreDos.Text
                , txtTextoPorcentajeLibreDos.Text);

            ClaseFormularioServicio.FormularioServicioPresenciaGas(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , cbCilindro.Checked ? "Cilindro" : ""
                , txtKilogramoCilindro.Text
                , cbEstanque.Checked ? "Estanque" : ""
                , txtKilogramoEstanque.Text
                , cbCaneria.Checked ? "Caneria" : ""
                , cbCiudad.Checked ? "Ciudad" : ""
                , cbLicuado.Checked ? "Licuado" : ""
                , cbNatural.Checked ? "Natural" : ""
                , cbOtroPresenciaDeGas.Checked ? "Otro" : ""
                , txtOtroPresenciaDeGas.Text
                , txtCompaniaDistribuidora.Text);

            ClaseFormularioServicio.FormularioServicioConcurrieron(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , cbApolloDeOtrosCuerpos.Checked ? "ApoyoOtrosCuerpos" : ""
                , txtApoyoOtrosCuerposAcargo.Text
                , txtApoyoOtrosCuerposProcedencia.Text
                , txtApoyoOtrosCuerposMotivo.Text
                , cbAmbulancias.Checked ? "Ambulancia" : ""
                , txtAmbulanciasLugarUno.Text
                , txtAmbulanciasLugarDos.Text
                , txtAmbulanciasLugarTres.Text
                , cbCarabineros.Checked ? "Carabineros" : ""
                , txtCarabinerosAcargo.Text
                , txtCarabinerosNumeroDePatrulla.Text
                , cbOficinaDeEmergencia.Checked ? "OficinaEmergencia" : ""
                , txtOficinaDeEmergenciaAsistenteSocial.Text
                , cbOtrosApoyos.Checked ? "Otros" : "");

            ClaseFormularioServicio.FormuarioServicioExistian(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , cbExplosivos.Checked ? "Explosivos" : ""
                , cbGases.Checked ? "Gases" : ""
                , cbLiquidos.Checked ? "Liquidos" : ""
                , cbSolidos.Checked ? "Solidos" : ""
                , cbVeneno.Checked ? "Veneno" : ""
                , cbRadioactivos.Checked ? "Radioactivos" : ""
                , cbCorrosivos.Checked ? "Corrosivos" : ""
                , cbOxidantes.Checked ? "Oxidantes" : ""
                , cbVarios.Checked ? "Varios" : ""
                , cbNoClasificados.Checked ? "NoClasificados" : ""
                , txtNombreDeLosProductos.Text);

            ClaseFormularioServicio.FormularioServicioEspecificacionPersonal(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , txtOficialVoluntarioAcargoGrado.Text
                , txtOficialVoluntarioAcargoCompania.Text
                , txtOficialVoluntarioAcargoNombre.Text
                , txtTomoEstadisticasGrado.Text
                , txtTomoEstadisticasCompania.Text
                , txtTomoEstadisticasNombre.Text
                , txtVBCapitanCompaniaNombre.Text);

            if (gvDatosGrilla.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in gvDatosGrilla.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        ClaseFormularioServicio.FormularioServicioDatosGrilla(
                            Zeus.Util.RecursosEstaticos.IdExpediente
                            , row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[1].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[2].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[3].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[4].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[5].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[6].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[7].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[8].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[9].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[10].Value != null ? row.Cells[0].Value.ToString() : ""
                            , row.Cells[11].Value != null ? row.Cells[0].Value.ToString() : "");
                    }
                }
            }

            ClaseFormularioServicio.FormularioServicioCompaniasConcurrentes(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , txtMaterialMayorPrimeraCompaniaUno.Text
                , txtMaterialMayorPrimeraCompaniaDos.Text
                , txtMaterialMayorPrimeraCompaniaTres.Text
                , txtMaterialMayorPrimeraCompaniaCuatro.Text
                , txtMaterialMayorSegundaCompaniaUno.Text
                , txtMaterialMayorSegundaCompaniaDos.Text
                , txtMaterialMayorSegundaCompaniaTres.Text
                , txtMaterialMayorSegundaCompaniaCuatro.Text
                , txtMaterialMayorTerceraCompaniaUno.Text
                , txtMaterialMayorTerceraCompaniaDos.Text
                , txtMaterialMayorTerceraCompaniaTres.Text
                , txtMaterialMayorTerceraCompaniaCuatro.Text
                , txtMaterialMayorCuartaCompaniaUno.Text
                , txtMaterialMayorCuartaCompaniaDos.Text
                , txtMaterialMayorCuartaCompaniaTres.Text
                , txtMaterialMayorCuartaCompaniaCuatro.Text
                , txtMaterialMayorQuintaCompaniaUno.Text
                , txtMaterialMayorQuintaCompaniaDos.Text
                , txtMaterialMayorQuintaCompaniaTres.Text
                , txtMaterialMayorQuintaCompaniaCuatro.Text
                , txtMaterialMayorSextaCompaniaUno.Text
                , txtMaterialMayorSextaCompaniaDos.Text
                , txtMaterialMayorSextaCompaniaTres.Text
                , txtMaterialMayorSextaCompaniaCuatro.Text
                , txtMaterialMayorComandanciaUno.Text
                , txtMaterialMayorComandanciaDos.Text
                , txtMaterialMayorComandanciaTres.Text
                , txtMaterialMayorComandanciaCuatro.Text
                , txtPrimeraCompaniaVoluntarios.Text
                , txtSegundaCompaniaVoluntarios.Text
                , txtTerceraCompaniaVoluntarios.Text
                , txtCuartaCompaniaVoluntarios.Text
                , txtQuintaCompaniaVoluntarios.Text
                , txtSextaCompaniaVoluntarios.Text
                , txtComandanciaVoluntarios.Text);

            string seguros = "";

            if(rbSegurosSi.Checked)
            {
                seguros = "Si";
            }

            if(rbSegurosNo.Checked)
            {
                seguros = "No";
            }

            ClaseFormularioServicio.FormularioServicioSegurosMaterialApoyo(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , seguros
                , txtSegurosCompania.Text
                , txtSegurosEspecieAseg.Text
                , cbFotos.Checked ? "Fotos" : ""
                , cbMuestras.Checked ? "Muestras" : ""
                , cbVideos.Checked ? "Videos" : ""
                , cbOtros.Checked ? "Otros" : ""
                , txtSegurosDetalles.Text);
                
            ClaseFormularioServicio.FormularioServicioConstanciaVoluntariosLesionados(
                Zeus.Util.RecursosEstaticos.IdExpediente
                , txtCVLNombreUno.Text
                , txtCVLCiaUno.Text
                , txtCVLNumeroRegistroUno.Text
                , txtCVLNombreDos.Text
                , txtCVLCiaDos.Text
                , txtCVLNumeroRegistroDos.Text
                , txtCVLNombreTres.Text
                , txtCVLCiaTres.Text
                , txtCVLNumeroRegistroTres.Text
                , txtCVLNombreCuatro.Text
                , txtCVLCiaCuatro.Text
                , txtCVLNumeroRegistroCuatro.Text
                , txtCVLComisaria.Text
                , txtCVLNumeroLibro.Text
                , txtCVLNumeroHoja.Text
                , txtCVLParrafo.Text
                , txtCVLConstanciaDejadaPor.Text
                , txtCVLCargo.Text
                , dtCVLFecha.Text
                , txtResumenActo.Text);

            MessageBox.Show("Formulario ingresado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtNumeroServicio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBlockServicio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDeptoServicio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumeroAdultosServicio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroAdultosServicio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumeroNinosServicio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNumeroPisosTipoConstruccion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPisoLugarInicioFuego_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPorcentajeDanoVivienda_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPorcentajeDanoEnseres_KeyPress(object sender, KeyPressEventArgs e)
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

        private void keypress_numerico(object sender, KeyPressEventArgs e)
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

        private void groupBox14_Enter(object sender, EventArgs e)
        {

        }
    }
}
