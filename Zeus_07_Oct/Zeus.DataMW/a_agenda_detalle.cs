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
    /// a_agenda_detalle
    /// </summary>
    public class a_agenda_detalle
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_subcat;
        public System.Int32 id_subcat
        {
            get
            {
                return _id_subcat;
            }
            set
            {
                _id_subcat = value;
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

        private System.String _telefono;
        public System.String telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
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

        #endregion

        /// <summary>
        /// a_agenda_detalle
        /// </summary>
        public a_agenda_detalle()
        {
        }


        /// <summary>
        /// a_agenda_detalle
        /// </summary>
        public a_agenda_detalle(System.Int32 id_subcat, System.String nombre, System.String telefono, System.Int32 id_empresa)
        {
            this.id_subcat = id_subcat;
            this.nombre = nombre;
            this.telefono = telefono;
            this.id_empresa = id_empresa;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(a_agenda_detalle mya_agenda_detalle)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO a_agenda_detalle (id_subcat,nombre,telefono) VALUES (" + mya_agenda_detalle.id_subcat + ",'" + mya_agenda_detalle.nombre + "','" + mya_agenda_detalle.telefono + "')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM a_agenda_detalle WHERE (id_empresa = " + myID + ")", myConn);
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
        public void Update(a_agenda_detalle mya_agenda_detalle)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE a_agenda_detalle SET id_subcat=" + mya_agenda_detalle.id_subcat + ",nombre='" + mya_agenda_detalle.nombre + "',telefono='" + mya_agenda_detalle.telefono + "',id_empresa=" + mya_agenda_detalle.id_empresa + " WHERE (id_empresa=" + mya_agenda_detalle.id_empresa + ")";
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
        public a_agenda_detalle getObjecta_agenda_detalle(System.Int32 myID)
        {
            a_agenda_detalle mya_agenda_detalle = new a_agenda_detalle();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_subcat,nombre,telefono,id_empresa FROM a_agenda_detalle WHERE (id_empresa=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mya_agenda_detalle.id_subcat = Convert.ToInt32(myReader[0]);
                    mya_agenda_detalle.nombre = myReader[1].ToString();
                    mya_agenda_detalle.telefono = myReader[2].ToString();
                    mya_agenda_detalle.id_empresa = Convert.ToInt32(myReader[3]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mya_agenda_detalle;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Geta_agenda_detalle()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM a_agenda_detalle";
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
        public DataSet Geta_agenda_detalle(int id)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM a_agenda_detalle where id_subcat=" + id+" order by id_empresa";
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

        public int GetEmpresa(PointD ubicacion, string tabla)
        {
            int id = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_empresa from " + tabla + " WHERE intersects(geometryfromtext('POINT(" + ubicacion.ToString() + ")',-1),the_geom)";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    id = Convert.ToInt32(myReader[0]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return id;
        }

    }


}
