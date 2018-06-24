using System;
using System.Windows.Forms;
using Zeus.Util;

namespace Zeus.UIElements.AdminForms
{
    public partial class AdminModulos : Form
    {
        private readonly PluginStatus[] pList;
        private readonly PluginsManager plugins;
        private bool _llenando;

        public AdminModulos(PluginsManager pl)
        {
            InitializeComponent();
            pList = pl.GetPlugins();
            plugins = pl;
        }

        private void AdminModulos_Load(object sender, EventArgs e)
        {
            // rellenar lista
            _llenando = true;
            foreach (PluginStatus pl in pList)
            {
                clPlugins.Items.Add(pl.Plugin.Name, pl.Activado);
            }
            _llenando = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mostrar datos
            string rtf =
                @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 MS Sans Serif;}}\viewkind4\uc1\pard\f0\fs17\fi-1150\li1150\tx1150";
            rtf = rtf + @"\b " + "Nombre:" + @"\b0\tab " + pList[clPlugins.SelectedIndex].Plugin.Name + @"\par" +
                  Environment.NewLine;
            rtf = rtf + @"\b " + "Versión:" + @"\b0\tab " + pList[clPlugins.SelectedIndex].Plugin.Version + @"\par" +
                  Environment.NewLine;
            rtf = rtf + @"\b " + "Autor:" + @"\b0\tab " + pList[clPlugins.SelectedIndex].Plugin.Autor + @"\par" +
                  Environment.NewLine;
            rtf = rtf + @"\b " + "Fecha:" + @"\b0\tab " + pList[clPlugins.SelectedIndex].Plugin.BuildDate + @"\par" +
                  Environment.NewLine;
            //rtf = rtf + @"\b " + "Serial:" + @"\b0\tab " + pList[clPlugins.SelectedIndex].Plugin.SerialNumber + @"\par" + Environment.NewLine;
            rtf = rtf + @"\b " + "Licenciado:" + @"\b0\tab " + pList[clPlugins.SelectedIndex].Plugin.Licencia + @"\par" +
                  Environment.NewLine;
            rtf = rtf + @"\b " + "Descripción:" + @"\b0\tab " + pList[clPlugins.SelectedIndex].Plugin.Descripcion +
                  @"\par" + Environment.NewLine;
            rtf += "}";

            rtfDatosPlugin.Rtf = rtf;
        }

        private void clPlugins_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_llenando) return;
            switch (e.CurrentValue)
            {
                case CheckState.Checked:
                    // terminar y remover de la lista
                    plugins.DesactivarPlugin(pList[e.Index].Archivo);
                    plugins.PluginsActivos.Remove(pList[e.Index].Archivo);
                    plugins.PluginsVisibles.Remove(pList[e.Index].Archivo);
                    break;
                case CheckState.Indeterminate:
                    break;
                case CheckState.Unchecked:
                    plugins.ActivarPlugin(pList[e.Index].Archivo);
                    plugins.PluginsActivos.Add(pList[e.Index].Archivo);
                    plugins.PluginsVisibles.Add(pList[e.Index].Archivo);
                    break;
                default:
                    break;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clPlugins.Items.Count; i++)
            {
                if (clPlugins.GetItemChecked(i) != true)
                {
                    // iniciar
                    clPlugins.SetItemChecked(i, true);
                }
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clPlugins.Items.Count; i++)
            {
                if (clPlugins.GetItemChecked(i))
                {
                    // iniciar
                    clPlugins.SetItemChecked(i, false);
                }
            }
        }
    }
}