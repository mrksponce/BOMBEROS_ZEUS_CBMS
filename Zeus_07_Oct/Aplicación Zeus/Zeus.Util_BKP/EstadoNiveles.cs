using System;

namespace Zeus.Util
{
    [Serializable]
    public class EstadoNiveles
    {
        public int Identificacion { get; set; }

        public int Agua { get; set; }

        public int Combustible { get; set; }

        public bool Pulsador { get; set; }

        public override string ToString()
        {
            return string.Format("Agua: {0}\r\nCombustible: {1}\r\nPulsador: {2}", Agua, Combustible, Pulsador);
        }

        public string ToString(bool legible)
        {
            if (legible)
            {
                return string.Format("Agua: {0}\r\nCombustible: {1}\r\nPulsador: {2}", Agua, Combustible, Pulsador);
            }
            return string.Format("{0};{1};{2}", Agua, Combustible, Pulsador);
        }

        public static EstadoNiveles FromString(string s)
        {
            var e = new EstadoNiveles();
            string[] arr = s.Split(';');
            e.Agua = int.Parse(arr[0]);
            e.Combustible = int.Parse(arr[1]);
            e.Pulsador = bool.Parse(arr[2]);
            return e;
        }
    }
}