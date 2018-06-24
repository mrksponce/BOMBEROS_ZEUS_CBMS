using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminVoluntarioFichaMedica : Form
    {
        private int id_voluntario;

        public AdminVoluntarioFichaMedica()
        {
            InitializeComponent();
        }

        public int Id_voluntario
        {
            get { return id_voluntario; }
            set { id_voluntario = value; }
        }

        private void AdminVoluntarioFichaMedica_Load(object sender, EventArgs e)
        {
            try
            {
                z_ficha_medica fm = new z_ficha_medica().getObjectz_ficha_medica(id_voluntario);
                if (fm.id_voluntario != 0)
                {
                    textGrupo.Text = fm.grupo_sanguineo;
                    textRH.Text = fm.factor_rh;

                    checkRubeola.Checked = fm.rubeola;
                    checkBronquitis.Checked = fm.bronquitis;
                    checkEpilepsia.Checked = fm.epilepsia;
                    checkEpistaxis.Checked = fm.epistaxis;
                    checkAnginas.Checked = fm.anginas;
                    checkPoliomielitis.Checked = fm.poliomielitis;
                    checkConvulsiones.Checked = fm.convulsiones;
                    checkUrinaria.Checked = fm.urinarias;
                    checkAsma.Checked = fm.asma;
                    checkVaricela.Checked = fm.varicela;
                    checkOtitis.Checked = fm.otitis;
                    checkColecistitis.Checked = fm.colecistitis;
                    checkSarampion.Checked = fm.sarampion;
                    checkDiabetes.Checked = fm.diabetes;
                    checkHepatitis.Checked = fm.hepatitis;

                    checkAmigdalas.Checked = fm.amigadalas;
                    textAmigdalas.Text = checkAmigdalas.Checked ? fm.fecha_amigdalas.ToShortDateString() : "";
                    checkHernias.Checked = fm.hernias;
                    textHernias.Text = checkHernias.Checked ? fm.fecha_hernias.ToShortDateString() : "";
                    checkApendicitis.Checked = fm.apendicitis;
                    textApendicitis.Text = checkApendicitis.Checked ? fm.fecha_apendicitis.ToShortDateString() : "";
                    checkOtras.Checked = fm.otras;
                    textOtras.Text = checkOtras.Checked ? fm.fecha_otras.ToShortDateString() : "";

                    textDiagnostico.Text = fm.diagnostico;
                    textTratamiento.Text = fm.tratamiento;
                    textMedicamentos.Text = fm.medicamentos;
                    textDosis.Text = fm.dosis;

                    textAlergiaMed.Text = fm.alergia_medicamentos;
                    textAlimentos.Text = fm.alergia_alimentos;
                    checkPenicilina.Checked = fm.alergia_penicilina;
                    checkPicaduras.Checked = fm.alergia_picadura;
                }
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                try
                {
                    z_ficha_medica fm = new z_ficha_medica().getObjectz_ficha_medica(id_voluntario);

                    fm.grupo_sanguineo = textGrupo.Text;
                    fm.factor_rh = textRH.Text;

                    fm.rubeola = checkRubeola.Checked;
                    fm.bronquitis = checkBronquitis.Checked;
                    fm.epilepsia = checkEpilepsia.Checked;
                    fm.epistaxis = checkEpistaxis.Checked;
                    fm.anginas = checkAnginas.Checked;
                    fm.poliomielitis = checkPoliomielitis.Checked;
                    fm.convulsiones = checkConvulsiones.Checked;
                    fm.urinarias = checkUrinaria.Checked;
                    fm.asma = checkAsma.Checked;
                    fm.varicela = checkVaricela.Checked;
                    fm.otitis = checkOtitis.Checked;
                    fm.colecistitis = checkColecistitis.Checked;
                    fm.sarampion = checkSarampion.Checked;
                    fm.diabetes = checkDiabetes.Checked;
                    fm.hepatitis = checkHepatitis.Checked;

                    fm.amigadalas = checkAmigdalas.Checked;
                    fm.fecha_amigdalas = checkAmigdalas.Checked ? DateTime.Parse(textAmigdalas.Text) : DateTime.MinValue;
                    fm.hernias = checkHernias.Checked;
                    fm.fecha_hernias = checkHernias.Checked ? DateTime.Parse(textHernias.Text) : DateTime.MinValue;
                    fm.apendicitis = checkApendicitis.Checked;
                    fm.fecha_apendicitis = checkApendicitis.Checked
                                               ? DateTime.Parse(textApendicitis.Text)
                                               : DateTime.MinValue;
                    fm.otras = checkOtras.Checked;
                    fm.fecha_otras = checkOtras.Checked ? DateTime.Parse(textOtras.Text) : DateTime.MinValue;

                    fm.diagnostico = textDiagnostico.Text;
                    fm.tratamiento = textTratamiento.Text;
                    fm.medicamentos = textMedicamentos.Text;
                    fm.dosis = textDosis.Text;

                    fm.alergia_medicamentos = textAlergiaMed.Text;
                    fm.alergia_alimentos = textAlimentos.Text;
                    fm.alergia_penicilina = checkPenicilina.Checked;
                    fm.alergia_picadura = checkPicaduras.Checked;

                    if (fm.id_voluntario != 0)
                    {
                        fm.modifyz_ficha_medica(fm);
                    }
                    else
                    {
                        fm.id_voluntario = id_voluntario;
                        fm.addz_ficha_medica(fm);
                    }
                    Close();
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

            if (checkAmigdalas.Checked && !DateTime.TryParse(textAmigdalas.Text, out d))
            {
                msg += "* Fecha Operación Amígdalas" + "\n";
                ok = false;
            }
            if (checkApendicitis.Checked && !DateTime.TryParse(textApendicitis.Text, out d))
            {
                msg += "* Fecha Operación Apendicitis" + "\n";
                ok = false;
            }
            if (checkHernias.Checked && !DateTime.TryParse(textHernias.Text, out d))
            {
                msg += "* Fecha Operación Hernias" + "\n";
                ok = false;
            }
            if (checkOtras.Checked && !DateTime.TryParse(textOtras.Text, out d))
            {
                msg += "* Fecha Operación Otras" + "\n";
                ok = false;
            }


            if (!ok)
            {
                MessageBox.Show(msg, "Error en validación");
            }
            return ok;
        }
    }
}