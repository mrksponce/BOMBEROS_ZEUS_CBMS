using System;
using System.Data;
using System.Windows.Forms;
using Zeus.Interfaces;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminBase : Form
    {
        protected bool enNuevo;
        private object source;

        protected IZeusWin zeusWin;

        public AdminBase()
        {
            InitializeComponent();
        }

        protected object Source
        {
            get { return source; }
            set
            {
                source = value;
                listActuales.DataSource = value;
            }
        }

        public IZeusWin ZeusWin
        {
            get { return zeusWin; }
            set { zeusWin = value; }
        }

        protected virtual void Limpiar()
        {
        }

        protected virtual void Insertar()
        {
        }

        protected virtual void Actualizar()
        {
        }

        protected virtual void Eliminar()
        {
        }

        protected virtual bool Validar()
        {
            return true;
        }

        protected virtual void Mostrar(int id)
        {
        }

        protected virtual void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!enNuevo)
            {
                listActuales.Enabled = false;
                btnNuevo.Text = "Insertar";
                btnActualizar.Text = "Cancelar";
                btnEliminar.Enabled = false;

                Limpiar();
                enNuevo = true;
            }
            else
            {
                if (Validar())
                {
                    Insertar();
                    listActuales.Enabled = true;
                    btnNuevo.Text = "Nuevo";
                    btnActualizar.Text = "Actualizar";
                    btnEliminar.Enabled = true;
                    enNuevo = false;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!enNuevo)
            {
                if (Validar())
                {
                    Actualizar();
                }
            }
            else
            {
                Limpiar();
                listActuales.Enabled = true;
                btnNuevo.Text = "Nuevo";
                btnActualizar.Text = "Actualizar";
                btnEliminar.Enabled = true;
                enNuevo = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("¿Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar();
            }
        }

        private void listActuales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listActuales.SelectedIndex != -1)
            {
                Mostrar((int) listActuales.SelectedValue);
            }
        }

        protected void textBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (source != null)
            {
                // buscar y asignar
                listActuales.DataSource =
                    ArrayToDataTable(
                        ((DataTable) source).Select(listActuales.DisplayMember + " like '%" + textBusqueda.Text + "%'"));
            }
        }

        protected DataTable ArrayToDataTable(DataRow[] drs)
        {
            DataTable t = ((DataTable) source).Clone();
            foreach (DataRow dr in drs)
            {
                t.ImportRow(dr);
            }
            return t;
        }
    }
}