
namespace SerialPortTest
{
    public class Localizacion
    {
        int identificacion;

        public int Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }
        double latitud;

        public double Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }
        double longitud;

        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        double angulo;

        public double Angulo
        {
            get { return angulo; }
            set { angulo = value; }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}\r\nLatitud:{1}\r\nLongitud: {2}\r\nAngulo:{3}", identificacion, latitud, longitud, angulo);
        }

    }
}
