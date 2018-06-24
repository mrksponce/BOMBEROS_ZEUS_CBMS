using System;
using System.Windows.Forms;

namespace SerialPortTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //if (!esperando)
            // ENVIAR COMANDO 'K' PARA EMPEZAR
            // 9600,n,8,1
            //{
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                serialPort1.PortName = txtPuerto.Text;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
            
                 //serialPort1.BaudRate = int.Parse(txtVelocidad.Text);
                //serialPort1.Parity = (System.IO.Ports.Parity)comboBox1.SelectedIndex;
                //serialPort1.Encoding = new ASCIIEncoding();
                serialPort1.NewLine = "\r\n";
                serialPort1.Handshake = System.IO.Ports.Handshake.RequestToSend;
                serialPort1.Open();

                serialPort1.WriteLine(txtString.Text);
                txtRecibido.Text = "Esperando datos...";
                //btnEnviar.Text = "Cancelar";
            // dromri 5 s
                //System.Threading.Thread.Sleep(5000);
            //}
            //else
            //{
            //    serialPort1.Close();
            //    txtRecibido.Clear();
            //    btnEnviar.Text = "Enviar";
            //    esperando = false;
            //}
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //txtRecibido.Text = serialPort1.ReadLine();
            //serialPort1.Close();
            //btnEnviar.Text = "Enviar";

            string ans = serialPort1.ReadExisting().Split('<')[0];
            txtRecibido.Text = ans;
            try
            {
                textInfo.Text = GPSSerialPort.ParseRespuesta(ans).ToString();
            }
            catch (Exception ex)
            {
                textInfo.Text = ex.Message;
            }
            System.Threading.Thread.Sleep(1000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ans = serialPort1.ReadExisting();
            txtRecibido.Text = ans;
            try
            {
                textInfo.Text = GPSSerialPort.ParseRespuesta(ans).ToString();
            }
            catch (Exception ex)
            {
                textInfo.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textInfo.Text = GPSSerialPort.ParseRespuesta(textBox1.Text).ToString();
            }
            catch (Exception ex)
            {
                textInfo.Text = ex.Message;
            }
        }
    }
}