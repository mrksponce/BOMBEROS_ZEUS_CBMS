using System;

namespace Zeus.Util
{
    [Serializable]
    public class Localizacion
    {
        public int Identificacion { get; set; }

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        public double Angulo { get; set; }

        public string ToString(bool legible)
        {
            if (legible)
            {
                return string.Format("Id: {0}\r\nLatitud:{1}\r\nLongitud: {2}\r\nAngulo:{3}", Identificacion, Latitud,
                                     Longitud, Angulo);
            }
            return string.Format("{0};{1};{2};{3}", Identificacion, Latitud, Longitud, Angulo);
        }

        public static Localizacion FromString(string s)
        {
            var l = new Localizacion();
            string[] arr = s.Split(';');
            l.Identificacion = int.Parse(arr[0]);
            l.Latitud = double.Parse(arr[1]);
            l.Longitud = double.Parse(arr[2]);
            l.Angulo = double.Parse(arr[3]);
            return l;
        }
    }
}