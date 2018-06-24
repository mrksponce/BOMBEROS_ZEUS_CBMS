using System;
using System.Collections.Generic;
using Zeus.Data;

namespace Zeus.Util
{
    public static class Interinaje
    {
        //public static void InterinajeComandante(int id_cargo, int id_teniente3)
        //{
        //    // obtener reemplazo comandante
        //    // investigar como actualizar dataset
        //    // ojo: mover TODOS hacia arriba
        //    // oficiales inactivos en algun lado
        //    z_cargos cargo = new z_cargos().getObjectz_cargos(id_cargo);
        //    // desactivar
        //    cargo.activo = false;
        //    cargo.modifyz_cargos(cargo);

        //    DataSet ds = cargo.getReemplazo(cargo.grado, cargo.orden_antiguedad);
        //    z_cargos ultimo;
        //    //if (reemp.id_cargo!=0)
        //    //{
        //    //    // se obtuvo reemplazo, mover hacia arriba en su escalafon

        //    //}
        //    if (ds.Tables[0].Rows.Count==0)
        //    {
        //        // ultimo
        //        ultimo = cargo;
        //    }
        //    else
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            dr["grado_int"] = cargo.grado;
        //            dr["antiguedad_int"] = ++cargo.cargo_antiguedad;
        //            ultimo = cargo.getObjectz_cargos((int)dr["id_cargo"]);
        //            // todo: commit changes
        //        }
        //    }


        //    // obtener capitan


        //    // teniente primero

        //    // teniente segundo

        //    // teniente 3º elegido

        //}

        public static List<Interino> ObtenerInterinaje(z_cargos cargo)
        {
            List<Interino> ints = new List<Interino>();
            z_cargos c;
            switch (cargo.grado)
            {
                case 1:
                    // comandante de reemplazo
                    do
                    {
                        c = cargo.getComandanteReemplazo(cargo.orden_antiguedad);
                        if (c.id_cargo == 0)
                        {
                            // no hay, buscar y agregar capitan
                            z_cargos cap = cargo.getCapitanAntiguo();
                            // se asume que hay de todo!!!
                            ints.Add(new Interino(cargo.id_cargo, cap.id_cargo));
                            cargo = cap;
                        }
                        else
                        {
                            // hay, agregar
                            ints.Add(new Interino(cargo.id_cargo, c.id_cargo));
                            cargo = c;
                        }
                    } while (c.id_cargo != 0);
                    // recursiva
                    ints.AddRange(ObtenerInterinaje(cargo));
                    break;

                case 40:
                    // se reemplaza capitan
                    z_voluntarios vol = new z_voluntarios().getObjectz_voluntarios(cargo.id_voluntario);
                    c = cargo.getz_cargos(100, vol.id_compania);
                    // agregar
                    ints.Add(new Interino(cargo.id_cargo, c.id_cargo));
                    // recursiva
                    ints.AddRange(ObtenerInterinaje(c));
                    break;

                case 100:
                    // se reemplaza 1° tte
                    z_voluntarios vol2 = new z_voluntarios().getObjectz_voluntarios(cargo.id_voluntario);
                    c = cargo.getz_cargos(200, vol2.id_compania);
                    // agregar
                    ints.Add(new Interino(cargo.id_cargo, c.id_cargo));
                    // recursiva
                    ints.AddRange(ObtenerInterinaje(c));
                    break;
                case 200:
                    // se reemplaza 2° tte
                    z_voluntarios vol3 = new z_voluntarios().getObjectz_voluntarios(cargo.id_voluntario);
                    c = cargo.getz_cargos(300, vol3.id_compania);
                    // agregar
                    ints.Add(new Interino(cargo.id_cargo, c.id_cargo));
                    // recursiva
                    ints.AddRange(ObtenerInterinaje(c));
                    break;
                case 300:
                    z_voluntarios vol4 = new z_voluntarios().getObjectz_voluntarios(cargo.id_voluntario);
                    // -id_compania, para que no muestre nada
                    ints.Add(new Interino(cargo.id_cargo, -vol4.id_compania));
                    break;
                default:
                    break;
            }
            return ints;
        }

        public static void ConfirmarInterinaje(List<Interino> list, DateTime desde, DateTime hasta)
        {
            // ingresar
            z_interinaje inter = new z_interinaje();

            // nuevo oficial temp
            z_cargos cargo = new z_cargos();
            cargo.grado = 1000;
            cargo.id_voluntario = list[list.Count - 1].Reemplazo;
            cargo.activo = true;
            int id = cargo.addz_cargos(cargo);
            list[list.Count - 1] = new Interino(list[list.Count - 1].Oficial, id);


            foreach (Interino i in list)
            {
                inter.desde = desde;
                inter.hasta = hasta;
                inter.id_cargo = i.Reemplazo;
                inter.id_reemplaza_a = i.Oficial;
                inter.addz_interinaje(inter);
            }


            // desactivar oficial (cuando se hace)
            //cargo = cargo.getObjectz_cargos(list[0].Oficial);
        }

        #region Nested type: Interino

        public struct Interino
        {
            public int Oficial;
            public int Reemplazo;

            public Interino(int oficial, int reemplazo)
            {
                Oficial = oficial;
                Reemplazo = reemplazo;
            }
        }

        #endregion
    }
}