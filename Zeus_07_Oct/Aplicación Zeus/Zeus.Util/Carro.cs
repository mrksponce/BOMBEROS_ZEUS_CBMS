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
            carro.Observacion2 = "";
            carro.motivo_fuera_servicio = "";
            carro.modifyz_carros(carro);
            var servicio = new z_servicio(carro.id_carro, DateTime.Now, carro.estado, carro.id_conductor, "");
            servicio.Insert(servicio);
            carro.ActualizarEstadosCarros(1, carro.id_carro);
        }

        public static void PonerEnServicio_MM(z_carros carro)
        {
            carro.estado = 1;
            carro.Observacion2 = "";
            carro.motivo_fuera_servicio = "";
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
            carro.motivo_fuera_servicio = "";
            carro.modifyz_carros(carro);
            carro.ActualizarEstadosCarros(5, carro.id_carro);
            //BitacoraGestion.NuevoEvento(0, 0, string.Format("debug:disponible en acto:{0}", carro.nombre));
        }


        public static void AunEnActo(z_carros carro)
        {
            carro.estado = 4;
            carro.modifyz_carros(carro);
            //BitacoraGestion.NuevoEvento(0, 0, string.Format("debug:disponible en acto:{0}", carro.nombre));
        }



        //###
        public static void NoDisponibleEnActo(z_carros carro)
        {
            carro.estado = 4;
            carro.modifyz_carros(carro);
            carro.ActualizarEstadosCarros(4, carro.id_carro);
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
            var servicio = new z_servicio(carro.id_carro, DateTime.Now, 2, carro.id_conductor, motivo);
            servicio.Insert(servicio);
            carro.estado = 2;
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = motivo;
            carro.Observacion2 = motivo;
            carro.id_conductor = 0;
            carro.modifyz_carros(carro);
            carro.ActualizarEstadosCarros(2, carro.id_carro);
        }


        //### Fuera de Servicio por 6-2
        public static z_carros FueraServicio62(int id_carro, string motivo)
        {
            // modificar estado
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            FueraServicio62(carro, motivo);
            return carro;
        }

        //### Fuera de Servicio por 6-2
        public static void FueraServicio62(z_carros carro, string motivo)
        {
            var servicio = new z_servicio(carro.id_carro, DateTime.Now, 2, carro.id_conductor, motivo);
            servicio.Insert(servicio);
            carro.estado = 2;
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = motivo;
            carro.Observacion2 = motivo;
            //carro.id_conductor = 0;
            carro.modifyz_carros(carro);
            carro.ActualizarEstadosCarros(2, carro.id_carro);
        }

        public static z_carros FueraServicio_MM(int id_carro, string motivo)
        {
            // modificar estado
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            FueraServicio_MM(carro, motivo);
            return carro;
        }

        //###
        public static void FueraServicio_MM(z_carros carro, string motivo)
        {
            var servicio = new z_servicio(carro.id_carro, DateTime.Now, 2, carro.id_conductor, motivo);
            servicio.Insert(servicio);
            carro.estado = 2;
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = motivo;
            carro.Observacion2 = motivo;
            carro.id_conductor = 0;
            carro.modifyz_carros(carro);
        }

        public static void SinConductor(z_carros carro, string motivo)
        {
            z_servicio servicio = new z_servicio(carro.id_carro, DateTime.Now, 3, carro.id_conductor, motivo);
            servicio.Insert(servicio);
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = motivo;
            carro.Observacion2 = motivo;
            carro.estado = 3;
            carro.id_conductor = 0;
            carro.modifyz_carros(carro);
        }

        public static z_carros SinConductor(int id_carro, string motivo)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            SinConductor(carro, motivo);
            return carro;
        }

        public static void SinConductor(z_carros carro)
        {
            z_servicio servicio = new z_servicio(carro.id_carro, DateTime.Now, 3, carro.id_conductor, "Sin Conductor");
            servicio.Insert(servicio);
            carro.fecha_fuera_servicio = DateTime.Now;
            //carro.motivo_fuera_servicio = "Sin Conductor";
            carro.motivo_fuera_servicio = "";
            carro.Observacion2 = "";
            carro.estado = 3;
            carro.id_conductor = 0;
            carro.modifyz_carros(carro);
            carro.ActualizarEstadosCarros(3, carro.id_carro);
        }

        public static void SinConductor_MM(z_carros carro)
        {
            z_servicio servicio = new z_servicio(carro.id_carro, DateTime.Now, 3, carro.id_conductor, "Sin Conductor");
            servicio.Insert(servicio);
            carro.fecha_fuera_servicio = DateTime.Now;
            //carro.motivo_fuera_servicio = "Sin Conductor";
            carro.motivo_fuera_servicio = "";
            carro.Observacion2 = "";
            carro.estado = 3;
            carro.id_conductor = 0;
            carro.modifyz_carros(carro);
        }

        public static z_carros SinConductor(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            SinConductor(carro);
            return carro;
        }

        public static z_carros SinConductor_MM(int id_carro)
        {
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            SinConductor_MM(carro);
            return carro;
        }

        public static void ConductorNoDisponible(z_carros carro)
        {
            var servicio = new z_servicio(carro.id_carro, DateTime.Now, 3, carro.id_conductor, "Temporalmente Sin Conductor");
            servicio.Insert(servicio);
            carro.fecha_fuera_servicio = DateTime.Now;
            carro.motivo_fuera_servicio = "Temporalmente Sin Conductor";
            carro.estado = 3;
            carro.modifyz_carros(carro);
        }

        public static z_carros ConductorNoDisponible(int id_carro)
        {
            // Crea Objeto Carro Según ID
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            // Asigna al carro el estado No Disponible = 3
            ConductorNoDisponible(carro);
            return carro;
        }

        public static z_carros EnServicioConductor(int id_carro, int id_conductor)
        {
            // Crea Objeto Carro Según ID
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            // Asigna conductor al Carro
            EnServicioConductor(carro, id_conductor);
            return carro;
        }

        public static void EnServicioConductor(z_carros carro, int id_conductor)
        {
            // Asigna Conductor al Objeto Carro
            carro.id_conductor = id_conductor;
            carro.Observacion2 = "";  //Ok
            carro.motivo_fuera_servicio = "";
            // Pone en Servicio el Carro
            PonerEnServicio(carro);
        }

        public static void EnServicioConductor_MM(z_carros carro, int id_conductor)
        {
            // Asigna Conductor al Objeto Carro
            carro.id_conductor = id_conductor;
            carro.Observacion2 = ""; //Ok
            carro.motivo_fuera_servicio = "";
            // Pone en Servicio el Carro
            PonerEnServicio_MM(carro);
        }


        private static void MarcarDespachado(int id_carro)
        {
            // Crea Objeto Carro Según ID
            z_carros carro = new z_carros().getObjectz_carros(id_carro);
            MarcarDespachado(carro);
        }

        private static void MarcarDespachado(z_carros carro)
        {
            // Establece: Carro en Acto
            carro.estado = 4;
            // Modifica los Estados del Carro
            carro.modifyz_carros(carro);
        }

        public static void Despachar(z_carros carro)
        {
            MarcarDespachado(carro.id_carro);
            // Colocar carros Fuera de Servicio que tienen le mismo Conductor
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
            carro.Observacion2 = ""; //Ok
            carro.modifyz_carros(carro);
            carro.ActualizarEstadosCarros(1, id_carro);
        }

        //### Liberar Despues de Cancelar
        public static void LiberarCancelar(int id_carro)
        {
            var carros = new e_carros_usados();
            carros = carros.getObjecte_carros_usados(id_carro);
            if (carros.id_expediente == -1 || carros.id_expediente == -2 || carros.id_expediente == -3)
            {
                //### No Pone en Servicio Carros Sin Conductor
            }
            else
            {
                var carro = new z_carros();
                carro = carro.getObjectz_carros(id_carro);
                carro.estado = 1;
                Conductor.LiberarConductor(carro.id_conductor);
                //carro.id_conductor = 0;
                carro.modifyz_carros(carro);
                carro.ActualizarEstadosCarros(1, id_carro);
            }
        }


        public static void Liberar_MM(int id_carro)
        {
            var carro = new z_carros();
            carro = carro.getObjectz_carros(id_carro);
            carro.estado = 1;
            carro.Observacion2 = "";  //OK
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

        public static bool Esta08(z_carros carro)
        {
            return carro.estado == 2 || carro.estado == 3;
        }

        public static bool EstaSolo08(z_carros carro)
        {
            return carro.estado == 2;
        }

        //### Asigna Refrencia de 6-13, 6-14 o 6-15
        //public static void SetUbicacion613(int IdCarro, string RefLugar)
        //{
        //    z_carros carro = new z_carros();
        //    carro.SetDestino613(IdCarro, RefLugar);
        //}

        public static void SetUbicacion613(int IdCarro, string RefLugar)
        {
            var bg = new z_carros();
            try
            {
                bg.SetDestino613(IdCarro, RefLugar);
            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
        }




    }
}