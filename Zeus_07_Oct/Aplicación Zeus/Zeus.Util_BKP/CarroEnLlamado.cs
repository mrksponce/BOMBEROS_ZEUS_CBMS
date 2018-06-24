using Zeus.Data;
using System.Data;
namespace Zeus.Util
{
    public class CarroEnLlamado
    {
        protected z_carros carro;
        private e_carros_usados carroUsado;

        /// <summary>
        /// Inicializa una instancia cargando el carro pasado
        /// </summary>
        /// <param name="id_carro"></param>
        public CarroEnLlamado(int id_carro)
        {
            carroUsado = new e_carros_usados().getObjecte_carros_usados(id_carro);
        }

        public e_carros_usados CarroUsado
        {
            get { return carroUsado; }
        }

        public void EstablecerEnJurisdiccion(bool enJurisdiccion)
        {
            carroUsado.en_jurisdiccion = enJurisdiccion;

            if (enJurisdiccion)
            {
                BitacoraLlamado.NuevoEvento(carroUsado.id_expediente, carroUsado.id_carro, "carro",
                                            "6-17: En la jurisdicción del Cuerpo");
                Carro.DisponibleEnActo(carroUsado.id_carro);
            }
            else
            {
                BitacoraLlamado.NuevoEvento(carroUsado.id_expediente, carroUsado.id_carro, "carro",
                                            "6-17: Fuera de la jurisdicción del Cuerpo");
                Carro.FueraServicio(carroUsado.id_carro, "Fuera de la jurisdicción");
            }

            carroUsado.Update(carroUsado);
        }

        public void Clave6_0(int idVolCargo, int cantVoluntarios, string nombreVol)
        {
            carroUsado.seis = "6-0V";
            carroUsado.id_voluntario = idVolCargo;
            carroUsado.num_voluntarios = cantVoluntarios;
            carroUsado.Update(carroUsado);
            BitacoraLlamado.NuevoEvento(carroUsado.id_expediente, carroUsado.id_carro,
                                                    BitacoraLlamado.Carro,
                                                    "6-0: " + nombreVol + ", " + cantVoluntarios);
        }

        public void Clave6_0(int idVolCargo, int cantVoluntarios, int cantEspecialistas, string nombreVol)
        {
            Clave6_0(idVolCargo, cantVoluntarios, nombreVol);
            // bitacora cant especialistas
            z_carros carro = new z_carros().getObjectz_carros(carroUsado.id_carro);
            DataSet ds = new z_tipo_carro().Getz_tipo_carro();
            string especialista =
                System.Convert.ToString(ds.Tables[0].Select("id_tipo_carro=" + carro.id_tipo_carro)[0]["especialista"]);
            if (!string.IsNullOrEmpty(especialista))
            {
                BitacoraLlamado.NuevoEvento(carroUsado.id_expediente, carroUsado.id_carro,
                                        BitacoraLlamado.Carro,
                                        cantEspecialistas  + " " + especialista);
            }
        }

        public void Clave6_1()
        {
            carroUsado.seis = "6-1";
            carroUsado.Update(carroUsado);
            BitacoraLlamado.NuevoEvento(carroUsado.id_expediente, carroUsado.id_carro, BitacoraLlamado.Carro,
                            "6-1");

        }

        public void Clave6_8()
        {
            carroUsado.seis = "6-8";
            carroUsado.Update(carroUsado);

            // poner en servicio
            Carro.DisponibleEnActo(carroUsado.id_carro);

            BitacoraLlamado.NuevoEvento(carroUsado.id_expediente, carroUsado.id_carro, BitacoraLlamado.Carro,
                                        "6-8");
        }

        // TODO: terminar de traspasar las claves
    }
}
