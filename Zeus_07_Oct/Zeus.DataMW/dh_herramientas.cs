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
    public class dh_herramientas
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_herramienta;
        public System.Int32 id_herramienta
        {
            get
            {
                return _id_herramienta;
            }
            set
            {
                _id_herramienta = value;
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

        private System.String _herramienta;
        public System.String herramienta
        {
            get
            {
                return _herramienta;
            }
            set
            {
                _herramienta = value;
            }
        }
        #endregion

        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_herramientas()
        {
        }


        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_herramientas(System.Int32 id_herramienta, int id_subcat, System.String herramienta)
        {
            this.id_herramienta = id_herramienta;
            this.herramienta = herramienta;
            this._id_subcategoria = id_subcat;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(dh_herramientas mydh_herram)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO dh_herramientas (id_subcategoria, herramienta) VALUES (" +mydh_herram.id_subcategoria+ ",'" + mydh_herram.herramienta + "')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM dh_herramientas WHERE (id_herramienta = " + myID + ")", myConn);
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
        public void Update(dh_herramientas mydh_herram)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE dh_herramientas SET id_herramienta=" + mydh_herram.id_herramienta + ",id_subcategoria=" + mydh_herram.id_subcategoria + ",herramienta='" + mydh_herram.herramienta + "' WHERE (id_herramienta=" + mydh_herram.id_herramienta + ")";
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
        public dh_herramientas getObject(System.Int32 myID)
        {
            dh_herramientas dh_herram = new dh_herramientas();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_herramienta,id_subcategoria,herramienta FROM dh_herramientas WHERE (id_herramienta=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    dh_herram.id_herramienta = Convert.ToInt32(myReader[0]);
                    dh_herram.id_subcategoria = Convert.ToInt32(myReader[1]);
                    dh_herram.herramienta = myReader[2].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return dh_herram;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet GetDataSet()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_herramientas";
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

        public DataSet GetDataSet(int id_subcategoria)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_herramientas WHERE id_subcategoria="+id_subcategoria;
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
