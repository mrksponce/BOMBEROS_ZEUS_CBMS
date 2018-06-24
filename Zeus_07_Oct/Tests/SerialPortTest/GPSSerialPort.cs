using System;
using System.Text;

namespace SerialPortTest
{
    public class GPSSerialPort
    {
        public static bool CheckSum(string text)
        {
            ASCIIEncoding encoder=new ASCIIEncoding();
            byte[] chars = encoder.GetBytes(text.Substring(7));

            try
            {
                // calcular checksum
                byte checksum = 0;
                foreach (byte b in chars)
                {
                    if (b == encoder.GetBytes("*")[0]) //'*'
                    {
                        checksum ^= b;
                        break;
                    }
                    checksum ^= b;
                }

                // convertir checksum qdel mensaje a byte
                byte gotchecksum = byte.Parse(encoder.GetString(chars, chars.Length - 3, 2), System.Globalization.NumberStyles.HexNumber);

                // comparar!
                return (gotchecksum == checksum);
            }
            catch
            {
                return false;
            }
        }

        public static Localizacion ParseLocalizacion(string text)
        {
            Localizacion l = new Localizacion();

            // obtener id
            string[] split = text.Split('>');
            l.Identificacion = int.Parse(split[0]);

            // resto de datos
            split = split[2].Split(',');

            // latitud
            l.Latitud = double.Parse(split[2].Substring(0, 2));
            l.Latitud += double.Parse(split[2].Substring(2).Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)) / 60;

            // longitud
            l.Longitud = double.Parse(split[3].Substring(0, 3));
            l.Longitud += double.Parse(split[3].Substring(3).Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)) / 60;

            // angulo
            l.Angulo=double.Parse(split[4].Split(';')[0].Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator));
            return l;
        }

        public static EstadoNiveles ParseEstadoNiveles(string text)
        {
            EstadoNiveles en = new EstadoNiveles();

            // obtener id
            string[] split = text.Split('>');
            en.Identificacion = int.Parse(split[0]);

            // obtener numerito
            byte valor = byte.Parse(split[2].Substring(3,2), System.Globalization.NumberStyles.HexNumber);
            
            // agua
            en.Agua = valor >> 5;

            // combustible
            en.Combustible = (valor & 31) >> 1;

            // pulsador
            en.Pulsador = ((valor & 1) != 0) ? true : false;

            return en;
        }

        public static object ParseRespuesta(string text)
        {
            // verificar checksum
            if (!CheckSum(text))
            {
                throw new Exception("Error en la respuesta");
            }

            // parsear según tipo
            string tipo = text.Split('>')[2].Substring(0, 3);
            switch (tipo)
            {
                case "RAG":
                    return ParseLocalizacion(text);
                case "RIX":
                    return ParseEstadoNiveles(text);
                default:
                    return null;
            }
        }
    }
}
