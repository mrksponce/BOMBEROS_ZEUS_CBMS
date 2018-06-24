using System;
using Zeus.Data;

namespace Zeus.Util
{
    public class Carro
    {
        public static void PonerEnServicio(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            PonerEnServicio(carro);
        }

        public static void PonerEnServicio(z_carros carro)
        {
            carro.estado = 1;
            carro.modifyz_carros(carro);
            var servicio = new z_servicio(carro.id_carro, DateTime.Now, carro.estado, carro.id_conductor, "");
            servicio.Insert(servicio);
        }

        public static void DisponibleEnActo(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            DisponibleEnActo(carro);
        }

        public static void DisponibleEnActo(z_carros carro)
        {
            carro.estado = 5;
            carro.modifyz_carros(carro);
            //BitacoraGestion.NuevoEvento(0, 0, string.Format("debug:disponible en acto:{0}", carro.nombre));
        }

        public static z_carros FueraServicio(int id_carro, string motivo)
        {
            // modificar estado
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            FueraServicio(carro, motivo);
            return carro;
        }

        public static void FueraServicio(z_carros carro, string motivo)
        {
            carro.estado = 2;
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = motivo;
            carro.modifyz_carros(carro);
            var servicio = new z_servicio(carro.id_carro, DateTime.Now, carro.estado, carro.id_conductor, motivo);
            servicio.Insert(servicio);
        }

        public static void SinConductor(z_carros carro)
        {
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = "Sin Conductor";
            carro.estado = 3;
            carro.id_conductor = 0;
            carro.modifyz_carros(carro);
            //z_servicio servicio = new z_servicio(carro.id_carro, DateTime.Now, carro.estado, carro.id_conductor, "Sin Conductor");
            //servicio.Insert(servicio);
        }

        public static z_carros SinConductor(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            SinConductor(carro);
            return carro;
        }

        public static void ConductorNoDisponible(z_carros carro)
        {
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = "Sin Conductor";
            carro.estado = 3;
            carro.modifyz_carros(carro);
        }

        public static z_carros ConductorNoDisponible(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            ConductorNoDisponible(carro);
            return carro;
        }

        public static z_carros EnServicioConductor(int id_carro, int id_conductor)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            EnServicioConductor(carro, id_conductor);
            return carro;
        }

        public static void EnServicioConductor(z_carros carro, int id_conductor)
        {
            carro.id_conductor = id_conductor;
            PonerEnServicio(carro);
        }


        private static void MarcarDespachado(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            MarcarDespachado(carro);
        }

        private static void MarcarDespachado(z_carros carro)
        {
            carro.estado = 4;
            carro.modifyz_carros(carro);
        }

        public static void Despachar(z_carros carro)
        {
            MarcarDespachado(carro.id_carro);
            Conductor.FueraServicio(carro.id_conductor, carro.id_carro);
        }

        public static void Despachar(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            Despachar(carro); 
        }

        public static void Liberar(int id_carro)
        {
            var carro = new z_carros();
            carro = carro.getObjectz_carros(id_carro);
            carro.estado = 1;
            Conductor.LiberarConductor(carro.id_conductor);
            //carro.id_conductor = 0;
            carro.modifyz_carros(carro);
        }

        public static void CubrirCuartel(int id_carro, int id_compania)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            CubrirCuartel(carro, id_compania);
        }

        public static void CubrirCuartel(z_carros carro, int id_compania)
        {
            carro.id_compania = id_compania;
            carro.modifyz_carros(carro);
        }

        public static void EliminarCubrirCuartel(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            carro.id_compania = carro.id_compania_orig;
            carro.modifyz_carros(carro);
        }

        public static bool EstaDisponible(z_carros carro)
        {
            return carro.estado == 1 || carro.estado == 5;
        }
    }
}