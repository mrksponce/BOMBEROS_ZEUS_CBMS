namespace PruebaEquipos
{
    internal class TipoCarro
    {
        private string nombre;

        public TipoCarro(string nombre, int id)
        {
            this.nombre = nombre;
            Id = id;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}