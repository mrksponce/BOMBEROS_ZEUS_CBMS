namespace BoletinInformativo
{
    internal class TipoCarro
    {
        public TipoCarro(string nombre, int id)
        {
            Nombre = nombre;
            Id = id;
        }

        public string Nombre { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}