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
    /// z_oficial_cia
    /// </summary>
    public class z_oficial_cia
    {

        #region ***** Campos y propiedades *****

        private int _id_oficial_cia;

        public int id_oficial_cia
        {
            get { return _id_oficial_cia; }
            set { _id_oficial_cia = value; }
        }
        private int _id_oficial;

        public int id_oficial
        {
            get { return _id_oficial; }
            set { _id_oficial = value; }
        }

      
        private int _id_voluntario;

        public int id_voluntario
        {
            get { return _id_voluntario; }
            set { _id_voluntario = value; }
        }
        private bool _general;

        public bool general
        {
            get { return _general; }
            set { _general = value; }
        }


        #endregion

        /// <summary>
        /// z_oficial_cia
        /// </summary>
        public z_oficial_cia()
        {
        }


        /// <summary>
        /// z_oficial_cia
        /// </summary>
        public z_oficial_cia(int id_oficial, int id_voluntario, bool general)
        {
            this.id_oficial = id_oficial;
            this.id_voluntario = id_voluntario;
            this.general = general;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_oficial_cia(z_oficial_cia myz_oficial_cia)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_oficial_cia (id_oficial, id_voluntario, general) VALUES (" + myz_oficial_cia.id_oficial + "," + myz_oficial_cia.id_voluntario + "," + myz_oficial_cia.general + ")";
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
        public void deletez_oficial_cia(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_oficial_cia WHERE (id_oficial_cia = " + myID + ")", myConn);
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
        public void modifyz_oficial_cia(z_oficial_cia myz_oficial_cia)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_oficial_cia SET id_oficial=" + myz_oficial_cia.id_oficial + ",id_voluntario=" + myz_oficial_cia.id_voluntario + ",general=" + myz_oficial_cia.general + " WHERE (id_oficial=" + myz_oficial_cia.id_oficial + ")";
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
        public z_oficial_cia getObjectz_oficial_cia(System.Int32 myID)
        {
            z_oficial_cia myz_oficial_cia = new z_oficial_cia();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_oficial, id_voluntario, general FROM z_oficial_cia WHERE (id_oficial_cia=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_oficial_cia.id_oficial_cia = Convert.ToInt32(myReader[0]);
                    myz_oficial_cia.id_oficial = Convert.ToInt32(myReader[1]);
                    myz_oficial_cia.id_voluntario = Convert.ToInt32(myReader[2]);
                    myz_oficial_cia.general = Convert.ToBoolean(myReader[3]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_oficial_cia;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_oficial_cia()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_oficial_cia";
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

        public DataSet Getz_oficial_cia(int id_compania)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_oficial_cia.id_voluntario, tipo, z_voluntarios.num_llamado, orden FROM z_oficial_cia,z_voluntarios,z_oficiales where z_voluntarios.id_voluntario=z_oficial_cia.id_voluntario and z_oficiales.id_oficial=z_oficial_cia.id_oficial and (general=true or z_voluntarios.id_compania=" + id_compania + ")";
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
