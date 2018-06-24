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
    public class dh_subcategorias
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

        private System.Int32 _id_subcategoria;
        public System.Int32 id_subcategoria
        {
            get
            {
                return _id_subcategoria;
            }
            set
            {
                _id_subcategoria = value;
            }
        }

        private System.String _subcategoria;
        public System.String subcategoria
        {
            get
            {
                return _subcategoria;
            }
            set
            {
                _subcategoria = value;
            }
        }
        #endregion

        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_subcategorias()
        {
        }


        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_subcategorias(System.Int32 id_cat, int id_subcat, System.String nombre)
        {
            this.id_categoria = id_cat;
            this.subcategoria = nombre;
            this._id_subcategoria = id_subcat;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(dh_subcategorias mydh_subcat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO dh_subcategorias (id_categoria, subcategoria) VALUES ("+ mydh_subcat.id_categoria + ",'" + mydh_subcat.subcategoria + "')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM dh_subcategorias WHERE (id_subcategoria = " + myID + ")", myConn);
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
        public void Update(dh_subcategorias mydh_subcat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE dh_subcategorias SET id_subcategoria=" + mydh_subcat.id_subcategoria + ",id_categoria=" + mydh_subcat.id_categoria + ",subcategoria='" + mydh_subcat.subcategoria + "' WHERE (id_subcategoria=" + mydh_subcat.id_subcategoria + ")";
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
        public dh_subcategorias getObject(int id_subcategoria)
        {
            dh_subcategorias dh_subcat = new  dh_subcategorias();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_subcategoria,id_categoria,subcategoria FROM dh_subcategorias WHERE (id_subcategoria=" + id_subcategoria + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    dh_subcat.id_subcategoria = Convert.ToInt32(myReader[0]);
                    dh_subcat.id_categoria = Convert.ToInt32(myReader[1]);
                    dh_subcat.subcategoria = myReader[2].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return dh_subcat;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet GetDataSet()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_subcategorias";
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

        public DataSet GetDataSet(int id_categoria)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_subcategorias WHERE id_categoria=" + id_categoria;
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
