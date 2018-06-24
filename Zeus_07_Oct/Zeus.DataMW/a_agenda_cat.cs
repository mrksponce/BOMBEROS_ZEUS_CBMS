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
    /// a_agenda_cat
    /// </summary>
    public class a_agenda_cat
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_cat;
        public System.Int32 id_cat
        {
            get
            {
                return _id_cat;
            }
            set
            {
                _id_cat = value;
            }
        }

        private System.String _nombre;
        public System.String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        private System.Boolean _ref_espacial;
        public System.Boolean ref_espacial
        {
            get
            {
                return _ref_espacial;
            }
            set
            {
                _ref_espacial = value;
            }
        }

        private System.String _tabla;
        public System.String tabla
        {
            get
            {
                return _tabla;
            }
            set
            {
                _tabla = value;
            }
        }

        private System.Int32 _orden;
        public System.Int32 orden
        {
            get
            {
                return _orden;
            }
            set
            {
                _orden = value;
            }
        }

        #endregion

        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public a_agenda_cat()
        {
        }


        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public a_agenda_cat(System.Int32 id_cat, System.String nombre, System.Boolean ref_espacial, System.String tabla, System.Int32 orden)
        {
            this.id_cat = id_cat;
            this.nombre = nombre;
            this.ref_espacial = ref_espacial;
            this.tabla = tabla;
            this.orden = orden;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(a_agenda_cat mya_agenda_cat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO a_agenda_cat (nombre,ref_espacial,tabla,orden) VALUES ('" + mya_agenda_cat.nombre + "'," + mya_agenda_cat.ref_espacial + ",'" + mya_agenda_cat.tabla + "'," + mya_agenda_cat.orden + ")";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM a_agenda_cat WHERE (id_cat = " + myID + ")", myConn);
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
        public void Update(a_agenda_cat mya_agenda_cat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE a_agenda_cat SET id_cat=" + mya_agenda_cat.id_cat + ",nombre='" + mya_agenda_cat.nombre + "',ref_espacial=" + mya_agenda_cat.ref_espacial + ",tabla='" + mya_agenda_cat.tabla + "',orden=" + mya_agenda_cat.orden + " WHERE (id_cat=" + mya_agenda_cat.id_cat + ")";
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
        public a_agenda_cat getObjecta_agenda_cat(System.Int32 myID)
        {
            a_agenda_cat mya_agenda_cat = new a_agenda_cat();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_cat,nombre,ref_espacial,tabla,orden FROM a_agenda_cat WHERE (id_cat=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mya_agenda_cat.id_cat = Convert.ToInt32(myReader[0]);
                    mya_agenda_cat.nombre = myReader[1].ToString();
                    mya_agenda_cat.ref_espacial = Convert.ToBoolean(myReader[2]);
                    mya_agenda_cat.tabla = myReader[3].ToString();
                    mya_agenda_cat.orden = Convert.ToInt32(myReader[4]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mya_agenda_cat;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Geta_agenda_cat()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM a_agenda_cat order by orden";
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
