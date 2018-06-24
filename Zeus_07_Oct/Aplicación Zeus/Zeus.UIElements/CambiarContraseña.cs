using System;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Interfaces;
using Zeus.Util;

namespace Zeus.UIElements
{
    public partial class CambiarContraseña : Form
    {
        private IZeusWin zeusWin;

        public CambiarContraseña()
        {
            InitializeComponent();
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // verificar actual
                z_locutores loc = new z_locutores().Login(zeusWin.Usuario, textActual.Text);
                if (loc == null)
                {
                    MessageBox.Show("La contraseña actual no es válida.", "Mensaje de Zeus");
                    return;
                }

                // verificar nuevas
                if (textNueva.Text != textNueva2.Text)
                {
                    MessageBox.Show("Las nuevas contraseñas no coinciden.", "Mensaje de Zeus");
                    return;
                }

                if (textNueva.Text == "" || textNueva2.Text == "")
                {
                    MessageBox.Show("Las nuevas contraseñas no pueden estar vacías.", "Mensaje de Zeus");
                    return;
                }


                // actualizar!!
                loc = loc.getObjectz_locutores(loc.id_locutor);
                loc.password = loc.GenerateHash(textNueva.Text);
                loc.modifyz_locutores(loc);
                MessageBox.Show("Operación realizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Log.ShowAndLog(ex);
            }
        }
    }
}