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
    /// s_sector
    /// </summary>
    public class s_sector
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_sector;
        public System.Int32 id_sector
        {
            get
            {
                return _id_sector;
            }
            set
            {
                _id_sector = value;
            }
        }

        private System.String _id_areas;
        public System.String id_areas
        {
            get
            {
                return _id_areas;
            }
            set
            {
                _id_areas = value;
            }
        }

        private System.String _descripcion;
        public System.String descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        #endregion

        /// <summary>
        /// s_sector
        /// </summary>
        public s_sector()
        {
        }


        /// <summary>
        /// s_sector
        /// </summary>
        public s_sector(System.Int32 id_sector, System.String id_areas, System.String descripcion)
        {
            this.id_sector = id_sector;
            this.id_areas = id_areas;
            this.descripcion = descripcion;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void adds_sector(s_sector mys_sector)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO s_sector (id_areas,descripcion) VALUES ('" + mys_sector.id_areas + "','" + mys_sector.descripcion + "')";
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
        public void deletes_sector(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM s_sector WHERE (id_sector = " + myID + ")", myConn);
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
        public void modifys_sector(s_sector mys_sector)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE s_sector SET id_sector=" + mys_sector.id_sector + ",id_areas='" + mys_sector.id_areas + "',descripcion='" + mys_sector.descripcion + "' WHERE (id_sector=" + mys_sector.id_sector + ")";
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
        public s_sector getObjects_sector(System.Int32 myID)
        {
            s_sector mys_sector = new s_sector();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_sector,id_areas,descripcion FROM s_sector WHERE (id_sector=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mys_sector.id_sector = Convert.ToInt32(myReader[0]);
                    mys_sector.id_areas = myReader[1].ToString();
                    mys_sector.descripcion = myReader[2].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mys_sector;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Gets_sector()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM s_sector";
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

        public s_sector getObjects_sector_comuna(string comuna)
        {
            s_sector mys_sector = new s_sector();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_sector,id_areas,descripcion FROM s_sector WHERE (descripcion='" + comuna + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mys_sector.id_sector = Convert.ToInt32(myReader[0]);
                    mys_sector.id_areas = myReader[1].ToString();
                    mys_sector.descripcion = myReader[2].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mys_sector;
        }

        public s_sector getObjects_sector_area(int id_area)
        {
            s_sector mys_sector = new s_sector();
            CnxBase myBase = new CnxBase();
            string reqSQL = string.Format("SELECT id_sector,id_areas,descripcion FROM s_sector WHERE trim(both ',' from substring(id_areas, '.?{0}.?'))='{0}'", id_area);
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mys_sector.id_sector = Convert.ToInt32(myReader[0]);
                    mys_sector.id_areas = myReader[1].ToString();
                    mys_sector.descripcion = myReader[2].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mys_sector;
        }
    }
}
