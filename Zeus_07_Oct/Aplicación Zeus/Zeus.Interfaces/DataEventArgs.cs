using System;

namespace Zeus.Interfaces
{
    // para los eventos
    public class DataEventArgs : EventArgs
    {
        public DataEventArgs()
        {
        }

        public DataEventArgs(int id)
        {
            Id = id;
        }

        public DataEventArgs(int id, TipoElemento nt)
        {
            Id = id;
            TipoElemento = nt;
        }

        public int Id { get; set; }

        public TipoElemento TipoElemento { get; set; }
    }

    public enum TipoElemento
    {
        Expediente,
        Carro,
        Servicio
    }
}