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
    /// dh_categorias
    /// </summary>
    public class dh_categorias
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_categoria;
        public System.Int32 id_categoria
        {
            get
            {
                return _id_categoria;
            }
            set
            {
                _id_categoria = value;
            }
        }

        private System.String _categoria;
        public System.String categoria
        {
            get
            {
                return _categoria;
            }
            set
            {
                _categoria = value;
            }
        }
        #endregion

        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_categorias()
        {
        }


        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_categorias(System.Int32 id_cat, System.String nombre)
        {
            this.id_categoria = id_cat;
            this.categoria = nombre;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(dh_categorias mydh_cat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO dh_categorias (categoria) VALUES ('" + mydh_cat.categoria + "')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM dh_categorias WHERE (id_categoria = " + myID + ")", myConn);
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
        public void Update(dh_categorias mydh_cat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE dh_categorias SET id_categoria=" + mydh_cat.id_categoria + ",categoria='" + mydh_cat.categoria + "' WHERE (id_categoria=" + mydh_cat.id_categoria + ")";
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
        public dh_categorias getObject(System.Int32 myID)
        {
            dh_categorias dh_cat = new  dh_categorias();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_categoria,categoria FROM dh_categorias WHERE (id_categoria=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    dh_cat.id_categoria = Convert.ToInt32(myReader[0]);
                    dh_cat.categoria = myReader[1].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return dh_cat;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet GetDataSet()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_categorias";
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
    }
}
