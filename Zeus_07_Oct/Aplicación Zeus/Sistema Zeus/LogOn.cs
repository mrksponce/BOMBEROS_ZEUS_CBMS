using System;
using System.Windows.Forms;
using Zeus.Application.Properties;
using Zeus.Data;
using Zeus.Interfaces;
//using log4net;

namespace Zeus.Application
{
    public partial class LogOn : Form
    {

        //private ILog log = LogManager.GetLogger(typeof(LogOn));

        public LogOn()
        {
            InitializeComponent();
        }

        public string Usuario { get; set; }

        public TipoOperadora TipoOperadora { get; set; }

        public int Id_operadora { get; set; }

        public int Id_aval { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            z_locutores operadora = new z_locutores();
            if (radioOperadora.Checked)
            {
                // Login de operadora
                operadora = operadora.Login(textLogin.Text, textPasswd.Text);
                if (operadora != null && operadora.admin != true)
                {
                    Usuario = operadora.login;
                    Id_operadora = operadora.id_locutor;
                    TipoOperadora = TipoOperadora.Operadora;
                    DatosLogin.LoginUsuario = operadora.id_locutor;
                    DatosLogin.NomUsuario = operadora.login;

                    //### Twitter En Servicio 39-...
                    z_carros carros = new z_carros();
                    if (carros.GetParametroPrioridad(1) == "TRUE" && carros.GetParametroPrioridad(5) == "TRUE")
                    {
                        System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                        proceso.StartInfo.FileName = @"C:\ZEUS_CBMS\New_App_Twitter\App_Twitter_Mod.exe";
                        proceso.StartInfo.Arguments = "6" + " " + DatosLogin.NomUsuario.ToString();
                        proceso.StartInfo.CreateNoWindow = true;
                        proceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        proceso.Start();

                        MessageBox.Show("Se ha publicado en Twitter:  En Servicio " + DatosLogin.NomUsuario.ToString(), "Sistema ZEUS");
                    }


                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("El usuario no existe, o la contraseña es incorrecta.",
                                    "Error al ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                // Login de Administrador
                // deben ser admins distintos
                if (textAdmin1.Text == textAdmin2.Text)
                {
                    MessageBox.Show("Deben ser 2 administradores diferentes.", "Error al ingresar al Sistema",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                z_locutores admin = operadora.Login(textAdmin1.Text, textPassAdmin1.Text);
                if (admin == null || admin.admin == false)
                {
                    MessageBox.Show("El administrador 1 no existe, o la contraseña es incorrecta.",
                                    "Error al ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Id_operadora = admin.id_locutor;
                Usuario = admin.login;
                DatosLogin.LoginUsuario = operadora.id_locutor;
                DatosLogin.NomUsuario = operadora.login;

                admin = operadora.Login(textAdmin2.Text, textPassAdmin2.Text);
                if (admin == null || admin.admin == false)
                {
                    MessageBox.Show("El administrador 2 no existe, o la contraseña es incorrecta.",
                                    "Error al ingresar al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                // todo bien
                Id_aval = admin.id_locutor;
                TipoOperadora = TipoOperadora.Administrador;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAdmin.Checked)
            {
                panelOperadora.Visible = false;
                panelAdmin.Visible = true;
                Height += (panelAdmin.Height - panelOperadora.Height);
                pictureBox1.Height = Height - 70;
                textAdmin1.Focus();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOperadora.Checked)
            {
                panelOperadora.Visible = true;
                panelAdmin.Visible = false;
                Height += (panelOperadora.Height - panelAdmin.Height);
                pictureBox1.Height = Height - 70;
                textLogin.Focus();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Height = Height - panelAdmin.Height;
            pictureBox1.Height = Height - 70;
#if CBQN
            pictureBox1.Image = Resources.Escudo_CBPA_v3;
             
#endif
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            textLogin.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}