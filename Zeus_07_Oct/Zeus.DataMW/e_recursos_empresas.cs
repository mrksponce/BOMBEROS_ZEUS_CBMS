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
    /// e_recursos_empresas
    /// </summary>
    public class e_recursos_empresas
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_expediente;
        public System.Int32 id_expediente
        {
            get
            {
                return _id_expediente;
            }
            set
            {
                _id_expediente = value;
            }
        }

        private System.Int32 _id_empresa;
        public System.Int32 id_empresa
        {
            get
            {
                return _id_empresa;
            }
            set
            {
                _id_empresa = value;
            }
        }

        private System.Boolean _estado;
        public System.Boolean estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
            }
        }

        #endregion

        /// <summary>
        /// e_recursos_empresas
        /// </summary>
        public e_recursos_empresas()
        {
        }


        /// <summary>
        /// e_recursos_empresas
        /// </summary>
        public e_recursos_empresas(System.Int32 id_expediente, System.Int32 id_empresa, System.Boolean estado)
        {
            this.id_expediente = id_expediente;
            this.id_empresa = id_empresa;
            this.estado = estado;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(e_recursos_empresas mye_recursos_empresas)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO e_recursos_empresas (id_expediente,id_empresa,estado) VALUES (" + mye_recursos_empresas.id_expediente + "," + mye_recursos_empresas.id_empresa + "," + mye_recursos_empresas.estado + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        /// <summary>
        /// delete record from datasource
        /// </summary>
        /// <param name="myID"></param>
        public void Delete(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM e_recursos_empresas WHERE (id_empresa = " + myID + ")", myConn);
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
        public void Update(e_recursos_empresas mye_recursos_empresas)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE e_recursos_empresas SET id_expediente=" + mye_recursos_empresas.id_expediente + ",id_empresa=" + mye_recursos_empresas.id_empresa + ",estado=" + mye_recursos_empresas.estado + " WHERE (id_empresa=" + mye_recursos_empresas.id_empresa + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        /// <summary>
        /// get an instance of object
        /// </summary>
        /// <param name="myID"></param>
        public e_recursos_empresas getObjecte_recursos_empresas(System.Int32 myID)
        {
            e_recursos_empresas mye_recursos_empresas = new e_recursos_empresas();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente,id_empresa,estado FROM e_recursos_empresas WHERE (id_empresa=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mye_recursos_empresas.id_expediente = Convert.ToInt32(myReader[0]);
                    mye_recursos_empresas.id_empresa = Convert.ToInt32(myReader[1]);
                    mye_recursos_empresas.estado = Convert.ToBoolean(myReader[2]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mye_recursos_empresas;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Gete_recursos_empresas()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM e_recursos_empresas";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        #endregion

        public void freee_recursos_empresas(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM e_recursos_empresas WHERE (id_expediente = " + myID + ")", myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString()));
            }
        }

        public e_recursos_empresas getObjecte_recursos_empresas(System.Int32 id_expediente, int id_empresa)
        {
            e_recursos_empresas mye_recursos_empresas = new e_recursos_empresas();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente,id_empresa,estado FROM e_recursos_empresas WHERE (id_empresa=" + id_empresa + " and id_expediente="+id_expediente+")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mye_recursos_empresas.id_expediente = Convert.ToInt32(myReader[0]);
                    mye_recursos_empresas.id_empresa = Convert.ToInt32(myReader[1]);
                    mye_recursos_empresas.estado = Convert.ToBoolean(myReader[2]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mye_recursos_empresas;
        }

        public DataSet Gete_recursos_empresas_expediente(int id_expediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT e_recursos_empresas.id_empresa, nombre, estado  FROM e_recursos_empresas, a_agenda_detalle where e_recursos_empresas.id_empresa=a_agenda_detalle.id_empresa and id_expediente="+id_expediente;
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }
    }




}
