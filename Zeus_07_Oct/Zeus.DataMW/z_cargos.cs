/********************************
 *
 * Clases generadas por D4Modelizer
 * (c)2004 DORLAC S.T.
 * http://www.d4modelizer.com
 * Stephane Dorlac
 * support@d4modelizer.com
 *
 * ******************************/
using System;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    /// <summary>
    /// z_cargos
    /// </summary>
    public class z_cargos
    {
        #region ***** Campos y propiedades *****

        public Int32 id_cargo { get; set; }

        public Int32 id_voluntario { get; set; }

        public Int32 grado { get; set; }

        public Int32 orden_antiguedad { get; set; }

        public Int32 cargo_antiguedad { get; set; }

        public int llamado_oficial { get; set; }

        //private int _grado_int;

        //public int grado_int
        //{
        //    get { return _grado_int; }
        //    set { _grado_int = value; }
        //}

        //private int _antiguedad_int;

        //public int antiguedad_int
        //{
        //    get { return _antiguedad_int; }
        //    set { _antiguedad_int = value; }
        //}

        public bool activo { get; set; }

        public int reemplaza_a { get; set; }

        public int id_oficial { get; set; }

        #endregion

        /// <summary>
        /// z_cargos
        /// </summary>
        public z_cargos()
        {
        }


        /// <summary>
        /// z_cargos
        /// </summary>
        public z_cargos(Int32 id_cargo, Int32 id_voluntario, Int32 grado, Int32 orden_antiguedad, Int32 cargo_antiguedad)
        {
            this.id_cargo = id_cargo;
            this.id_voluntario = id_voluntario;
            this.grado = grado;
            this.orden_antiguedad = orden_antiguedad;
            this.cargo_antiguedad = cargo_antiguedad;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        public int addz_cargos(z_cargos myz_cargos)
        {
            var myBase = new CnxBase();
            int id;
            string reqSQL =
                string.Format(
                    "INSERT INTO z_cargos (id_voluntario,grado,orden_antiguedad,cargo_antiguedad,llamado_oficial,id_oficial,activo) VALUES ({0},0,(select coalesce((select max(orden_antiguedad)  from z_cargos where id_oficial={1} group by id_oficial),0) +1 as orden),(select coalesce((select max(cargo_antiguedad)  from z_cargos where id_oficial={1} group by id_oficial),0) +1 as cargo),{2},{1},{3}); select currval('z_cargos_id_cargo_seq')",
                    myz_cargos.id_voluntario,  myz_cargos.id_oficial,myz_cargos.llamado_oficial,myz_cargos.activo);
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                id = Convert.ToInt32(myCommand.ExecuteScalar());
                myBase.CloseConnection(myConn);
                return id;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        /// <summary>
        /// delete record from datasource
        /// </summary>
        /// <param name="myID"></param>
        public void deletez_cargos(int myID)
        {
            var myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand("DELETE FROM z_cargos WHERE (id_cargo = " + myID + ")",
                                                  myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString()));
            }
        }

        /// <summary>
        /// modify a record
        /// </summary>
        public void modifyz_cargos(z_cargos myz_cargos)
        {
            var myBase = new CnxBase();
            string reqSQL = string.Format("UPDATE z_cargos SET id_voluntario={0},grado={1},orden_antiguedad={2},cargo_antiguedad={3},llamado_oficial={4},id_oficial={5},activo={6} WHERE (id_cargo={7})", myz_cargos.id_voluntario, myz_cargos.grado, myz_cargos.orden_antiguedad, myz_cargos.cargo_antiguedad, myz_cargos.llamado_oficial, myz_cargos.id_oficial,myz_cargos.activo,myz_cargos.id_cargo);
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        /// <summary>
        /// get an instance of object
        /// </summary>
        /// <param name="myID"></param>
        public z_cargos getObjectz_cargos(Int32 myID)
        {
            var myz_cargos = new z_cargos();
            var myBase = new CnxBase();
            string reqSQL =
                "SELECT id_cargo,id_voluntario,grado,orden_antiguedad,cargo_antiguedad,llamado_oficial,reemplaza_a,id_oficial,activo FROM z_cargos WHERE (id_cargo=" +
                myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_cargos.id_cargo = Convert.ToInt32(myReader[0]);
                    myz_cargos.id_voluntario = Convert.ToInt32(myReader[1]);
                    myz_cargos.grado = Convert.ToInt32(myReader[2]);
                    myz_cargos.orden_antiguedad = Convert.ToInt32(myReader[3]);
                    myz_cargos.cargo_antiguedad = Convert.ToInt32(myReader[4]);
                    myz_cargos.llamado_oficial = Convert.ToInt32(myReader[5]);
                    myz_cargos.reemplaza_a = Convert.ToInt32(myReader[6]);
                    myz_cargos.id_oficial = Convert.ToInt32(myReader[7]);
                    myz_cargos.activo = Convert.ToBoolean(myReader[8]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myz_cargos;
        }

        public z_cargos getObjectz_cargos_vol(Int32 myID)
        {
            var myz_cargos = new z_cargos();
            var myBase = new CnxBase();
            // se añade join con tabla z_oficiales
            string reqSQL =
                "SELECT id_cargo,id_voluntario,z_oficiales.grado,orden_antiguedad,cargo_antiguedad,llamado_oficial,reemplaza_a,z_cargos.id_oficial FROM z_cargos, z_oficiales WHERE (id_voluntario=" +
                myID + ") AND z_cargos.id_oficial = z_oficiales.id_oficial";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_cargos.id_cargo = Convert.ToInt32(myReader[0]);
                    myz_cargos.id_voluntario = Convert.ToInt32(myReader[1]);
                    myz_cargos.grado = Convert.ToInt32(myReader[2]);
                    myz_cargos.orden_antiguedad = Convert.ToInt32(myReader[3]);
                    myz_cargos.cargo_antiguedad = Convert.ToInt32(myReader[4]);
                    myz_cargos.llamado_oficial = Convert.ToInt32(myReader[5]);
                    myz_cargos.reemplaza_a = Convert.ToInt32(myReader[6]);
                    myz_cargos.id_oficial = Convert.ToInt32(myReader[7]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myz_cargos;
        }

        public z_cargos getObjectz_cargos_llam(Int32 myID)
        {
            var myz_cargos = new z_cargos();
            var myBase = new CnxBase();
            // se añade join con tabla z_oficiales
            string reqSQL =
                "SELECT id_cargo,id_voluntario,z_oficiales.grado,orden_antiguedad,cargo_antiguedad,llamado_oficial,reemplaza_a,z_cargos.id_oficial FROM z_cargos, z_oficiales WHERE (llamado_oficial=" +
                myID + ") AND z_cargos.id_oficial = z_oficiales.id_oficial";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_cargos.id_cargo = Convert.ToInt32(myReader[0]);
                    myz_cargos.id_voluntario = Convert.ToInt32(myReader[1]);
                    myz_cargos.grado = Convert.ToInt32(myReader[2]);
                    myz_cargos.orden_antiguedad = Convert.ToInt32(myReader[3]);
                    myz_cargos.cargo_antiguedad = Convert.ToInt32(myReader[4]);
                    myz_cargos.llamado_oficial = Convert.ToInt32(myReader[5]);
                    myz_cargos.reemplaza_a = Convert.ToInt32(myReader[6]);
                    myz_cargos.id_oficial = Convert.ToInt32(myReader[7]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myz_cargos;
        }


        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_cargos()
        {
            var myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_cargos";
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        #endregion

        public DataSet Getz_cargosLista()
        {
            var myBase = new CnxBase();
            string reqSQL =
                "SELECT id_cargo, z_cargos.id_voluntario, apellidos||' '||nombres as nombre_completo FROM z_cargos, z_voluntarios WHERE z_cargos.id_voluntario=z_voluntarios.id_voluntario";
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public DataSet Getz_cargosGrado(int grado)
        {
            var myBase = new CnxBase();
            string reqSQL =
                "SELECT id_cargo, z_cargos.id_voluntario, apellidos||' '||nombres as nombre_completo FROM z_cargos, z_voluntarios, z_oficiales WHERE z_cargos.id_voluntario=z_voluntarios.id_voluntario and z_cargos.id_oficial=z_oficiales.id_oficial and z_oficiales.grado=" +
                grado + " order by orden_antiguedad";
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public z_cargos getComandanteReemplazo(int orden)
        {
            var myz_cargos = new z_cargos();
            var myBase = new CnxBase();
            string reqSQL =
                "SELECT id_cargo,id_voluntario,grado,orden_antiguedad,cargo_antiguedad,llamado_oficial, reemplaza_a FROM z_cargos WHERE (grado=1 and orden_antiguedad>" +
                orden + " and reemplaza_a=0 and activo=true) order by orden_antiguedad limit 1";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_cargos.id_cargo = Convert.ToInt32(myReader[0]);
                    myz_cargos.id_voluntario = Convert.ToInt32(myReader[1]);
                    myz_cargos.grado = Convert.ToInt32(myReader[2]);
                    myz_cargos.orden_antiguedad = Convert.ToInt32(myReader[3]);
                    myz_cargos.cargo_antiguedad = Convert.ToInt32(myReader[4]);
                    myz_cargos.llamado_oficial = Convert.ToInt32(myReader[5]);
                    myz_cargos.reemplaza_a = Convert.ToInt32(myReader[6]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myz_cargos;
        }

        public z_cargos getCapitanAntiguo()
        {
            var myz_cargos = new z_cargos();
            var myBase = new CnxBase();
            string reqSQL =
                "SELECT id_cargo,id_voluntario,grado,orden_antiguedad,cargo_antiguedad,llamado_oficial, reemplaza_a FROM z_cargos WHERE (grado=40 and reemplaza_a=0 and activo=true) order by orden_antiguedad limit 1";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_cargos.id_cargo = Convert.ToInt32(myReader[0]);
                    myz_cargos.id_voluntario = Convert.ToInt32(myReader[1]);
                    myz_cargos.grado = Convert.ToInt32(myReader[2]);
                    myz_cargos.orden_antiguedad = Convert.ToInt32(myReader[3]);
                    myz_cargos.cargo_antiguedad = Convert.ToInt32(myReader[4]);
                    myz_cargos.llamado_oficial = Convert.ToInt32(myReader[5]);
                    myz_cargos.reemplaza_a = Convert.ToInt32(myReader[6]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myz_cargos;
        }

        public z_cargos getz_cargos(int grado, int id_compania)
        {
            var myz_cargos = new z_cargos();
            var myBase = new CnxBase();
            string reqSQL =
                "SELECT id_cargo,z_cargos.id_voluntario,grado,orden_antiguedad,cargo_antiguedad,llamado_oficial, reemplaza_a FROM z_cargos, z_voluntarios WHERE (grado=" +
                grado +
                " and reemplaza_a=0 and activo=true and z_cargos.id_voluntario=z_voluntarios.id_voluntario and z_voluntarios.id_compania=" +
                id_compania + ") order by orden_antiguedad";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_cargos.id_cargo = Convert.ToInt32(myReader[0]);
                    myz_cargos.id_voluntario = Convert.ToInt32(myReader[1]);
                    myz_cargos.grado = Convert.ToInt32(myReader[2]);
                    myz_cargos.orden_antiguedad = Convert.ToInt32(myReader[3]);
                    myz_cargos.cargo_antiguedad = Convert.ToInt32(myReader[4]);
                    myz_cargos.llamado_oficial = Convert.ToInt32(myReader[5]);
                    myz_cargos.reemplaza_a = Convert.ToInt32(myReader[6]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myz_cargos;
        }

        public DataSet getz_cargos_oficial(int id_compania)
        {
            var myBase = new CnxBase();
            string reqSQL =string.Format(
                "select z_oficiales.tipo, cargos.id_voluntario, cargos.llamado_oficial, z_oficiales.orden " +
                "from z_oficiales " +
                "left join " +
                "(select z_cargos.* from z_cargos, z_voluntarios where z_cargos.id_voluntario=z_voluntarios.id_voluntario and z_voluntarios.id_compania={0}) " +
                "as cargos " +
                "on z_oficiales.id_oficial =cargos.id_oficial " +
                "where z_oficiales.visible=true " +
                "order by z_oficiales.orden", id_compania);
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        

        //public DataSet getReemplazo(int grado, int orden)
        //{
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "SELECT id_cargo,id_voluntario,grado,orden_antiguedad,cargo_antiguedad,llamado_oficial, grado_int, antiguedad_int FROM z_cargos WHERE (grado=" + grado + " and orden_antiguedad>" + orden + " and grado_int=0 and antiguedad_int=0 and activo=true)";
        //    try
        //    {
        //        CnxBase myD4MCnx = new CnxBase();
        //        DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
        //        return myResult;
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //}
    }
}