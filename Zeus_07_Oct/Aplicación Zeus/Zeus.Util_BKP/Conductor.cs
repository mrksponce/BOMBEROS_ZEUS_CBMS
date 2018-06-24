using System;
using System.Collections.Generic;
using System.Data;
using Zeus.Data;

namespace Zeus.Util
{
    public static class Conductor
    {
        public static void LiberarConductor(int id_cond)
        {
            var cond = new z_conductores();
            var carro = new z_carros();
            cond = cond.getObjectz_conductores(id_cond);
            if (cond.id_conductor == 0)
            {
                return;
            }
            // poner en servicio los carros de este conductor

            DataSet ds = carro.Getz_carros();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((int) dr["id_conductor"] == cond.id_conductor && (int) dr["estado"] == 3)
                {
                    Carro.PonerEnServicio((int) dr["id_carro"]);
                }
            }

            cond.disponible = true;
            cond.modifyz_conductores(cond);
        }

        public static void VerificarTemporal(z_conductores cond)
        {
            DataSet ds = new z_carros().Getz_carros();
            bool tiene = false;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((int) dr["id_conductor"] == cond.id_conductor)
                {
                    tiene = true;
                    break;
                }
            }
            // si no tiene más carros en servicio, eliminar conductor
            if (!tiene)
            {
                cond.deletez_conductores(cond.id_conductor);
            }
        }

        public static int CrearConductorTemporal(int id_cuart_vol, List<int> carros)
        {
            // generar temporal
            var nuevo = new z_conductores
                            {
                                id_tipo_conductor = 2,
                                id_cuart_vol = id_cuart_vol,
                                licencia_vence = DateTime.Now.AddYears(10),
                                tipo_licencia = "F",
                                codigo_conductor = "TEMP",
                                temporal = true,
                                disponible = true
                            };
            foreach (int i in carros)
            {
                nuevo.id_carros += "," + i;
            }
            nuevo.id_carros = nuevo.id_carros.Trim(',');

            nuevo.addz_conductores(nuevo);
            int id_conductor = nuevo.id_conductor;
            return id_conductor;
        }

        public static void PuestaEnServicio(int id_conductor, List<int> carrosCheck, string autoriza)
        {
            z_conductores cond = new z_conductores().getObjectz_conductores(id_conductor);
            string enserv = "";
            foreach (int i in carrosCheck)
            {
                z_carros carro = new z_carros().getObjectz_carros(i);
                int id_cond_anterior = carro.id_conductor;
                // modificar conductor
                Carro.EnServicioConductor(carro, id_conductor);
                enserv += "," + carro.nombre;
                // verificar temporal
                z_conductores anterior = new z_conductores().getObjectz_conductores(id_cond_anterior);
                if (anterior.temporal)
                {
                    VerificarTemporal(anterior);
                }
            }
            // temporal??
            string auth = "";
            if (cond.temporal)
            {
                auth = ", Autorizado por: " + autoriza;
            }
            if (enserv != "")
            {
                BitacoraGestion.NuevoEvento(BitacoraLlamado.IdOperadora, 0,
                                            string.Format(
                                                "Puesta en servicio de carros. Fecha: {0}, Conductor: {1}, Carros: {2}" +
                                                auth, DateTime.Now, cond.codigo_conductor, enserv.Trim(',')));
            }
        }

        public static void FueraServicio(int id_conductor, List<int> carrosUncheck)
        {
            // poner fuera de servicio
            z_conductores cond = new z_conductores().getObjectz_conductores(id_conductor);
            string noserv = "";
            foreach (int i in carrosUncheck)
            {
                z_carros carro = new z_carros().getObjectz_carros(i);
                Carro.SinConductor(carro);
                noserv += "," + carro.nombre;
            }
            if (noserv != "")
            {
                BitacoraGestion.NuevoEvento(BitacoraLlamado.IdOperadora, 0,
                                            string.Format(
                                                "Fuera de servicio de carros. Fecha: {0}, Conductor: {1}, Carros: {2}",
                                                DateTime.Now, cond.codigo_conductor, noserv.Trim(',')));
            }
            if (cond.temporal)
            {
                VerificarTemporal(cond);
            }
        }

        /// <summary>
        /// Pone fuera de servicio los carros de un conductor, y pone al conductor no disponible
        /// </summary>
        /// <param name="id_conductor"></param>
        /// <param name="id_carro"></param>
        public static void FueraServicio(int id_conductor, int id_carro)
        {
            z_conductores cond = new z_conductores().getObjectz_conductores(id_conductor);
            cond.disponible = false;
            cond.modifyz_conductores(cond);
            // fuera serv

            DataSet ds = new z_carros().Getz_carrosDisponibles();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((int) dr["id_conductor"] == id_conductor && (int) dr["id_carro"] != id_carro)
                {
                    // fuera serv
                    Carro.ConductorNoDisponible((int) dr["id_carro"]);
                }
            }
        }
    }
}