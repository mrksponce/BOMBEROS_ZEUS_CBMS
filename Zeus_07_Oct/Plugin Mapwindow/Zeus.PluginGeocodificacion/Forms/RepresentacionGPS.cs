using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Zeus.Data;
using Zeus.Util;

namespace Zeus.PluginGeocodificacion.Forms
{
    public partial class RepresentacionGPS : Form
    {
        //TcpClientChannel channel;

        public RepresentacionGPS()
        {
            InitializeComponent();
        }

        private void RepresentacionGPS_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(Owner.Location.X + 50, 200);

            try
            {
                // llenar lista
                listCarros.DataSource = new z_carros().Getz_carros().Tables[0];
                // registrar canal tcp
                //channel = new TcpClientChannel("cliente", new BinaryClientFormatterSinkProvider());

                //ChannelServices.RegisterChannel(channel, true);

            }
            catch (Exception Ex)
            {
                Log.ShowAndLog(Ex);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //####################################
        //### Código para Localización GPS ###
        //####################################
        //private void btnLocalizar_Click(object sender, EventArgs e)
        //{
        //    if (listCarros.SelectedItems.Count!=0)
        //    {
        //        //### Barra de Estado
        //        this.Cursor = Cursors.WaitCursor;
        //        toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
        //        toolStripStatusLabel1.Text = "Localizando...";

        //        //### Obtiene Coordenadas y Label de Cada Carro
        //        try
        //        {
        //            LocalizacionGPS lgps = LocalizacionGPS.StartClient();
        //            Localizacion l1=Localizacion.FromString(lgps.Localizar_s(1));

        //            List<PointD> points = new List<PointD>();
        //            List<string> labels = new List<string>();
        //            for (int i = 0; i < listCarros.SelectedItems.Count; i++)
        //            {
        //                Localizacion l = Localizacion.FromString(lgps.Localizar_s((int)((DataRowView)listCarros.SelectedItems[i])["id_carro"]));
        //                PointD p = new PointD(l.Longitud, l.Latitud);
        //                p = Data.Util.TransformCoord(p);//new PointD(346145.539, 6288689.478); 
        //                points.Add(p);
        //                labels.Add((string)((DataRowView)listCarros.SelectedItems[i])["nombre"]);
        //            }

        //            //### Dibujar Cada Carro
        //            PlugData.ZoomToPointsPaint(points.ToArray(), labels.ToArray());
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.ShowAndLog(ex);
        //        }
        //        //### Terminar la Barra de Estado
        //        this.Cursor = Cursors.Default;
        //        toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
        //        toolStripStatusLabel1.Text = "";
        //    }
        //    else
        //    {
        //        MessageBox.Show("Debe seleccionar carros para localizarlos.", "Sistema ZEUS");
        //    }
        //}



        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (listCarros.SelectedItems.Count != 0)
            {
                //### Barra de Estado
                this.Cursor = Cursors.WaitCursor;
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripStatusLabel1.Text = "Localizando...";

                //### Obtiene Coordenadas y Label de Cada Carro
                try
                {
                    LocalizacionGPS lgps = LocalizacionGPS.StartClient();
                    Localizacion l1 = Localizacion.FromString(lgps.Localizar_s(1));

                    List<PointD> points = new List<PointD>();
                    List<string> labels = new List<string>();
                    for (int i = 0; i < listCarros.SelectedItems.Count; i++)
                    {
                        Localizacion l = Localizacion.FromString(lgps.Localizar_s((int)((DataRowView)listCarros.SelectedItems[i])["id_carro"]));
                        PointD p = new PointD(l.Longitud, l.Latitud);
                        
                        //### LatLong 2 UTM
                        //p = Data.Util.TransformCoord(p);//new PointD(346145.539, 6288689.478); 

                        points.Add(p);
                        labels.Add((string)((DataRowView)listCarros.SelectedItems[i])["nombre"]);
                    }

                    //### Dibujar Cada Carro
                    PlugData.ZoomToPointsPaint(points.ToArray(), labels.ToArray());
                }
                catch (Exception ex)
                {
                    Log.ShowAndLog(ex);
                }
                //### Terminar la Barra de Estado
                this.Cursor = Cursors.Default;
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                toolStripStatusLabel1.Text = "";
            }
            else
            {
                MessageBox.Show("Debe seleccionar carros para localizarlos.", "Sistema ZEUS");
            }
        }



    }
}