using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Zeus.Util
{
    public class USBKey
    {
        private string conexion = "";
        private EstadoConexion estadoConexion;
        private string hkestado = "";

        #region Claves

        private readonly byte[] sBox1 = {
                                            184, 61, 166, 125, 236, 29, 192, 227, 96, 181,
                                            50, 231, 28, 226, 242, 89, 88, 36, 70, 112,
                                            212, 58, 210, 13, 0, 64, 244, 154, 240, 8,
                                            200, 180, 216, 35, 198, 206, 252, 118, 37, 22,
                                            232, 69, 110, 95, 128, 243, 92, 33, 152, 134,
                                            82, 55, 224, 107, 49, 186, 40, 78, 39, 74,
                                            6, 30, 84, 189, 248, 31, 57, 208, 32, 153,
                                            10, 142, 104, 191, 21, 229, 204, 81, 98, 60,
                                            25, 9, 170, 249, 72, 38, 190, 79, 176, 178,
                                            1, 71, 80, 41, 54, 66, 24, 48, 26, 124,
                                            136, 194, 220, 121, 168, 146, 234, 16, 52, 218,
                                            42, 77, 62, 135, 188, 143, 12, 177, 94, 139,
                                            100, 138, 91, 214, 160, 238, 114, 120, 5, 51,
                                            2, 102, 126, 108, 230, 45, 144, 161, 47, 43,
                                            133, 109, 87, 205, 68, 199, 18, 175, 67, 207,
                                            65, 203, 56, 97, 131, 217, 116, 245, 148, 162,
                                            127, 182, 101, 209, 228, 237, 86, 169, 53, 17,
                                            141, 165, 167, 155, 172, 103, 99, 250, 158, 46,
                                            20, 15, 90, 129, 19, 159, 202, 150, 111, 151,
                                            117, 221, 179, 85, 122, 246, 156, 83, 147, 254,
                                            196, 233, 164, 3, 44, 145, 222, 255, 76, 137,
                                            27, 241, 187, 73, 14, 193, 185, 239, 59, 115,
                                            93, 201, 105, 4, 132, 11, 140, 123, 174, 157,
                                            215, 219, 23, 119, 63, 211, 163, 113, 130, 251,
                                            34, 195, 213, 173, 7, 253, 223, 75, 235, 106,
                                            225, 149, 183, 247, 197, 171
                                        };

        private readonly byte[] sBox2 = {
                                            56, 172, 2, 138, 168, 21, 60, 206, 224, 210,
                                            178, 226, 72, 179, 164, 201, 24, 113, 212, 39,
                                            32, 68, 8, 193, 0, 159, 146, 219, 240, 140,
                                            134, 203, 152, 165, 252, 122, 1, 28, 204, 20,
                                            192, 160, 244, 111, 232, 83, 150, 92, 104, 17,
                                            88, 242, 236, 169, 51, 221, 22, 158, 44, 45,
                                            34, 255, 198, 41, 184, 76, 196, 186, 128, 106,
                                            18, 170, 50, 95, 58, 181, 5, 215, 16, 233,
                                            248, 102, 120, 37, 63, 23, 182, 231, 78, 241,
                                            114, 149, 80, 195, 36, 161, 216, 11, 3, 175,
                                            96, 151, 57, 131, 40, 253, 30, 109, 148, 26,
                                            97, 91, 74, 54, 42, 243, 116, 117, 220, 86,
                                            48, 61, 65, 103, 66, 166, 110, 14, 64, 177,
                                            108, 229, 6, 47, 118, 133, 82, 190, 144, 71,
                                            70, 85, 107, 19, 143, 141, 250, 137, 38, 69,
                                            214, 155, 208, 145, 98, 13, 135, 167, 52, 156,
                                            25, 84, 218, 205, 94, 124, 73, 46, 176, 162,
                                            254, 251, 112, 187, 59, 12, 100, 93, 228, 213,
                                            125, 245, 35, 130, 154, 132, 136, 202, 180, 4,
                                            183, 194, 188, 15, 238, 62, 10, 235, 222, 90,
                                            127, 246, 33, 234, 29, 207, 119, 223, 200, 121,
                                            185, 126, 43, 67, 31, 249, 99, 189, 101, 27,
                                            9, 247, 129, 225, 53, 239, 174, 163, 147, 115,
                                            230, 153, 7, 139, 49, 142, 211, 191, 87, 55,
                                            217, 237, 81, 197, 199, 171, 79, 77, 157, 209,
                                            123, 89, 173, 105, 75, 227
                                        };

        private const string password = "thaFaXu#usWUz7+@";

        #endregion

        public string Estado
        {
            get { return hkestado; }
            set { hkestado = value; }
        }

        public EstadoConexion EstadoConexion
        {
            get { return estadoConexion; }
            set { estadoConexion = value; }
        }

        [DllImport("hkey-w32.dll")]
        private static extern long HARDkey(IntPtr buf);

        private void EncriptaString(ref byte[] buffer, string encPassword)
        {
            //Esta rutina encripta la cadena que se pasa como parámetro
            //a la función HARDkey().
            //todo:encPassword como ascii bytes

            int i;
            var bufEnc = new byte[buffer.Length];
            //char[] p = new char();

            byte cAnterior = 0;
            for (i = 0; i < buffer.Length; i++)
            {
                byte ctemp = buffer[i];
                //if ((ctemp < 0))
                //{
                //    ctemp = ctemp + (byte)256;
                //}
                ctemp ^= sBox1[cAnterior];
                int k;
                for (k = 0; k <= 15; k++)
                {
                    int pw = Convert.ToByte(encPassword[k]);
                    if (((k%2) == 1))
                    {
                        ctemp ^= sBox1[sBox2[pw]];
                        ctemp = sBox2[ctemp];
                    }
                    else
                    {
                        ctemp ^= sBox2[sBox1[pw]];
                        ctemp = sBox1[ctemp];
                    }
                }
                ctemp ^= sBox1[i];
                cAnterior = ctemp;
                bufEnc[i] = ctemp;
            }
            buffer = bufEnc;
        }


        private string DesencriptaString(ref byte[] buffer, string encPassword)
        {
            //Esta rutina desencripta la cadena que devuelve la
            //función HARDkey().

            int i;
            byte cAnterior = 0;
            var bufEnc = new byte[buffer.Length];
            for (i = 0; i < buffer.Length; i++)
            {
                byte ctemp = buffer[i];
                //if ((ctemp < 0))
                //{
                //    ctemp = ctemp + (char)256;
                //}
                ctemp ^= sBox1[cAnterior];
                int k;
                for (k = 0; k <= 15; k++)
                {
                    byte pw = Convert.ToByte(encPassword[k]);
                    if (((k%2) == 1))
                    {
                        ctemp ^= sBox1[sBox2[pw]];
                        ctemp = sBox2[ctemp];
                    }
                    else
                    {
                        ctemp ^= sBox2[sBox1[pw]];
                        ctemp = sBox1[ctemp];
                    }
                }
                ctemp ^= sBox1[i];
                cAnterior = buffer[i];
                bufEnc[i] = ctemp;
            }
            buffer = bufEnc;
            //buffer.Normalize();
            return new ASCIIEncoding().GetString(buffer);
        }

        /// <summary>
        /// Busca la llave USB en el sistema o inicializa módulos
        /// </summary>
        /// <param name="modulo">El módulo a inicializar, o "00" para búsqueda de llave.</param>
        /// <returns></returns>
        public bool IniciarConexion(string modulo)
        {
            var buf = new byte[200];
            bool resultado;
            var enc = new ASCIIEncoding();

            // cadena estandar, buscar sólo en puertos locales
            InitBuffer(buf);

            byte[] b = enc.GetBytes(" 00000000 25154 64932 0009 00001 00000 00000 00000 00000 00000 00000 00000");
            for (int i = 0; i < b.Length; i++)
            {
                buf[i + 10] = b[i];
            }
            EncriptaString(ref buf, password);

            IntPtr p = Marshal.AllocHGlobal(buf.Length);
            Marshal.Copy(buf, 0, p, buf.Length);
            HARDkey(p);
            Marshal.Copy(p, buf, 0, 200);
            Marshal.FreeHGlobal(p);

            // iniciar conexion
            byte[] rand = InitBuffer(buf);
            b = enc.GetBytes(" 00000000 25154 64932 0000 " + modulo + " 0");
            for (int i = 0; i < b.Length; i++)
            {
                buf[i + 10] = b[i];
            }
            EncriptaString(ref buf, password);

            p = Marshal.AllocHGlobal(buf.Length);
            Marshal.Copy(buf, 0, p, buf.Length);
            HARDkey(p);
            Marshal.Copy(p, buf, 0, 200);
            Marshal.FreeHGlobal(p);
            string buffer = DesencriptaString(ref buf, password);

            //Analizo la respuesta para determinar si está la llave
            if (ValidaString(buf, rand))
            {
                conexion = buffer.Substring(11, 8);
                resultado = true;
            }
            else
            {
                conexion = "00000000";
                resultado = false;
            }

            return resultado;
        }

        private static byte[] InitBuffer(byte[] buffer)
        {
            var ret = new byte[10];
            buffer.Initialize();
            for (int i = 0; i < 10; i++)
            {
                buffer[i] = ret[i] = 1;
            }
            return ret;
        }

        private bool ValidaString(byte[] buffer, byte[] random)
        {
            //Esta rutina analiza que la string devuelta por la
            //función HARDkey() sea consistente.
            var enc = new ASCIIEncoding();
            int i;
            byte[] buf = buffer;

            for (i = 0; i < 10; i++)
            {
                buf[i] = sBox2[buf[i]];
            }
            buf.CopyTo(buffer, 0);
            bool result = true;
            for (i = 0; i < 10; i++)
            {
                if (buffer[i] != random[i])
                {
                    result = false;
                }
            }
            if ((char) buffer[10] != ' ')
            {
                result = false;
            }
            if ((char) buffer[19] != ' ')
            {
                result = false;
            }
            if ((char) buffer[25] != ' ')
            {
                result = false;
            }
            if ((char) buffer[30] != '-')
            {
                result = false;
            }
            if ((char) buffer[20] != '0')
            {
                result = false;
            }

            string decode = enc.GetString(buffer);
            string st = decode.Substring(20, 5);
            if ((st == "00000"))
            {
                hkestado = "El comando se completó con exito";
                estadoConexion = EstadoConexion.Correcta;
            }
            if ((st == "00002"))
            {
                hkestado = "No se encontró llave USB";
                estadoConexion = EstadoConexion.NoHayLLave;
            }
            if ((st == "00004"))
            {
                hkestado = "Formato de cadena o parámetro incorrecto";
                estadoConexion = EstadoConexion.ParametroIncorrecto;
            }
            if ((st == "00010"))
            {
                hkestado = "Número de conexión no válida";
                estadoConexion = EstadoConexion.ConexionNoValida;
            }
            if ((st == "00011"))
            {
                hkestado = "Se superó límite de usuarios permitidos";
                estadoConexion = EstadoConexion.TopeUsuarios;
            }
            if ((st == "00012"))
            {
                hkestado = "Módulo ya en uso por la aplicación";
                estadoConexion = EstadoConexion.ModuloYaLevantado;
            }
            if ((st == "00013"))
            {
                hkestado = "Módulo no levantado por la aplicación";
                estadoConexion = EstadoConexion.LicenciaNoLevantada;
            }
            if ((st == "00020"))
            {
                hkestado = "No hay drivers HARDkey instalados";
                estadoConexion = EstadoConexion.NoHayDrivers;
            }
            if ((st == "00021"))
            {
                hkestado = "Versión de drivers obsoleta";
                estadoConexion = EstadoConexion.DriversObsoletos;
            }
            if ((st == "00022"))
            {
                hkestado = "No hay drivers SuperPro instalados";
                estadoConexion = EstadoConexion.NoHayDriversPRO;
            }
            return result;
        }

        /// <summary>
        /// Verifica que la conexión con la llave sea válida
        /// </summary>
        /// <returns></returns>
        public bool VerificarConexion()
        {
            var buf = new byte[200];
            var enc = new ASCIIEncoding();

            // verificar conexion
            byte[] rand = InitBuffer(buf);
            byte[] b = enc.GetBytes(" " + conexion + " 25154 64932 0001");
            for (int i = 0; i < b.Length; i++)
            {
                buf[i + 10] = b[i];
            }
            EncriptaString(ref buf, password);

            IntPtr p = Marshal.AllocHGlobal(buf.Length);
            Marshal.Copy(buf, 0, p, buf.Length);
            HARDkey(p);
            Marshal.Copy(p, buf, 0, 200);
            Marshal.FreeHGlobal(p);
            DesencriptaString(ref buf, password);

            //Analizo la respuesta para determinar si está la llave
            return (ValidaString(buf, rand));
        }

        /// <summary>
        /// Cierra la conexión con la llave USB
        /// </summary>
        /// <param name="modulo">el módulo a deshabilitar (formato:"XX" - "00" para deshabilitar todo)</param>
        public void CierraConexion(string modulo)
        {
            //Este botón cierra la conexión con la llave
            var buf = new byte[200];
            var enc = new ASCIIEncoding();


            byte[] b = enc.GetBytes(" " + conexion + " 25154 64932 0002 00");
            for (int i = 0; i < b.Length; i++)
            {
                buf[i + 10] = b[i];
            }
            EncriptaString(ref buf, password);

            IntPtr p = Marshal.AllocHGlobal(buf.Length);
            Marshal.Copy(buf, 0, p, buf.Length);
            HARDkey(p);
            Marshal.Copy(p, buf, 0, 200);
            Marshal.FreeHGlobal(p);

            //if ((ValidaString(buf, rand) == true))
            //{
            //    LMemoria.Enabled = false;
            //    FConexion.Enabled = false;
            //    m_campos.Text = "conexión  estado  lote-serie   LiGlo";
            //}
            //else
            //{
            //    m_campos.Text = "No se encontró protector";
            //}

            //buffer=InitBuffer(buffer);
            //string random = buffer;
            //long l;

            //buffer = buffer + " " + conexion + " 00000 00000 0002 00";
            //buffer = buffer.PadRight(200);
            ////m_envio.Text = Strings.Mid(buffer, 12);
            //EncriptaString(ref buffer, password);
            //p = Marshal.StringToHGlobalAnsi(buffer);
            //l = HARDkey(p);
            //buffer = Marshal.PtrToStringAnsi(p);
            //Marshal.FreeHGlobal(p);
            //DesencriptaString(ref buffer, password);

            //Analizo respuesta para ver si el comando fue completado
            //m_recibo.Text = Strings.Mid(buffer, 12);
        }

        public DialogResult MensajeFalloProteccion(string mensaje)
        {
            return
                MessageBox.Show(
                    "No se ha detectado la llave USB. Si la llave está conectada, presione \"Reintentar\".\n" +
                    "Si el problema persiste, contáctese con Soporte Técnico, indicando el error que aparece más abajo.\n" +
                    "Si presiona \"Cancelar\", la aplicación se cerrará.\n" +
                    "Debe disponer de una llave USB conectada para poder utilizar el sistema.\n\n" +
                    "(Error: " + mensaje + ")", "Fallo de Protección Anticopia", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
        }

        public bool VerificarLlaveUSB()
        {
            // a) intentar verificar
            bool ok = VerificarConexion();
            if (!ok)
            {
                // ver causa
                if (EstadoConexion == EstadoConexion.ConexionNoValida || EstadoConexion == EstadoConexion.NoHayLLave)
                {
                    // intentar reabrir conexion
                    if (IniciarConexion("00"))
                    {
                        return true;
                    }
                }

                // reintentar 2 veces
                ok = VerificarConexion();
                if (!ok)
                {
                    ok = VerificarConexion();
                    if (!ok)
                    {
                        // muerto, sin llave
                        return false;
                    }
                    return true;
                }
                return true;
            }
            return true;
        }
    }

    public enum EstadoConexion
    {
        Correcta = 0,
        NoHayLLave = 2,
        ParametroIncorrecto = 4,
        ConexionNoValida = 10,
        TopeUsuarios = 11,
        ModuloYaLevantado = 12,
        LicenciaNoLevantada = 13,
        NoHayDrivers = 20,
        DriversObsoletos = 21,
        NoHayDriversPRO = 22
    }
}