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
    /// z_oficiales
    /// </summary>
    public class z_oficiales
    {
        #region ***** Campos y propiedades ***** 

        private Int32 _grado;
        private Int32 _id_oficial;

        private String _tipo;

        public Int32 id_oficial
        {
            get { return _id_oficial; }
            set { _id_oficial = value; }
        }

        public String tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public Int32 grado
        {
            get { return _grado; }
            set { _grado = value; }
        }

        #endregion

        /// <summary>
        /// z_oficiales
        /// </summary>
        public z_oficiales()
        {
        }


        /// <summary>
        /// z_oficiales
        /// </summary>
        public z_oficiales(Int32 id_oficial, String tipo, Int32 grado)
        {
            this.id_oficial = id_oficial;
            this.tipo = tipo;
            this.grado = grado;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_oficiales(z_oficiales myz_oficiales)
        {
            var myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_oficiales (id_oficial,tipo,grado) VALUES (" + myz_oficiales.id_oficial + ",'" +
                            myz_oficiales.tipo + "'," + myz_oficiales.grado + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
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
        public void deletez_oficiales(int myID)
        {
            var myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand("DELETE FROM z_oficiales WHERE (id_oficial = " + myID + ")", myConn);
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
        public void modifyz_oficiales(z_oficiales myz_oficiales)
        {
            var myBase = new CnxBase();
            string reqSQL = "UPDATE z_oficiales SET id_oficial=" + myz_oficiales.id_oficial + ",tipo='" +
                            myz_oficiales.tipo + "',grado=" + myz_oficiales.grado + " WHERE (id_oficial=" +
                            myz_oficiales.id_oficial + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
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
        public z_oficiales getObjectz_oficiales(Int32 myID)
        {
            var myz_oficiales = new z_oficiales();
            var myBase = new CnxBase();
            string reqSQL = "SELECT id_oficial,tipo,grado FROM z_oficiales WHERE (id_oficial=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                var myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_oficiales.id_oficial = Convert.ToInt32(myReader[0]);
                    myz_oficiales.tipo = myReader[1].ToString();
                    myz_oficiales.grado = Convert.ToInt32(myReader[2]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_oficiales;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_oficiales()
        {
            var myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_oficiales";
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        #endregion

        public DataSet Getz_oficialesVisibles()
        {
            var myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_oficiales where visible=true";
            try
            {
                var myD4MCnx = new CnxBase();
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