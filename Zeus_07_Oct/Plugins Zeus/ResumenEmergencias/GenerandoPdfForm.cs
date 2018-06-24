using System;
using System.Threading;
using System.Windows.Forms;
using MigraDoc.Rendering;
using Zeus.Util;

namespace ResumenEmergencias
{
    public partial class GenerandoPdfForm : Form
    {
        private string nombre;
        private PdfDocumentRenderer renderer;

        public GenerandoPdfForm()
        {
            InitializeComponent();
        }

        public PdfDocumentRenderer Renderer
        {
            get { return renderer; }
            set { renderer = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        private void GenerandoPdfForm_Shown(object sender, EventArgs e)
        {
            renderer.DocumentRenderer.PrepareDocumentProgress += DocumentRenderer_PrepareDocumentProgress;
            new Thread(Render).Start();
        }

        private void Render()
        {
            try
            {
                renderer.RenderDocument();
                renderer.Save(nombre);
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
            Invoke(new ThreadStart(Close));
        }

        private void DocumentRenderer_PrepareDocumentProgress(object sender,
                                                              DocumentRenderer.PrepareDocumentProgressEventArgs e)
        {
            if (e.Value == e.Maximum)
            {
                //Invoke(new ThreadStart(Close));
            }
            else
            {
                Invoke(new ThreadStart(delegate
                                           {
                                               progressBar1.Maximum = e.Maximum;
                                               progressBar1.Value = e.Value;
                                           }));
            }
        }
    }
}