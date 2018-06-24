
namespace SerialPortTest
{
    public class EstadoNiveles
    {
        int identificacion;

        public int Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }
        int agua;

        public int Agua
        {
            get { return agua; }
            set { agua = value; }
        }
        int combustible;

        public int Combustible
        {
            get { return combustible; }
            set { combustible = value; }
        }
        bool pulsador;

        public bool Pulsador
        {
            get { return pulsador; }
            set { pulsador = value; }
        }

        public override string ToString()
        {
            return string.Format("Agua: {0}\r\nCombustible: {1}\r\nPulsador: {2}", agua, combustible, pulsador);
        }
    }
}
