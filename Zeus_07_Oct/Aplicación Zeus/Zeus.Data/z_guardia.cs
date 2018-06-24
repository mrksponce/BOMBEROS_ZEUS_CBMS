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
    /// z_guardia
    /// </summary>
    public class z_guardia
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_guardia;
        public System.Int32 id_guardia
        {
            get
            {
                return _id_guardia;
            }
            set
            {
                _id_guardia = value;
            }
        }

        private string _tipo_oficial;
        public string tipo_oficial
        {
            get
            {
                return _tipo_oficial;
            }
            set
            {
                _tipo_oficial = value;
            }
        }

        private string _oficial;
        public string oficial
        {
            get
            {
                return _oficial;
            }
            set
            {
                _oficial = value;
            }
        }

        private string _responsabilidades;
        public string responsabilidades
        {
            get
            {
                return _responsabilidades;
            }
            set
            {
                _responsabilidades = value;
            }
        }

        private bool _mostrar;
        public bool mostrar
        {
            get
            {
                return _mostrar;
            }
            set
            {
                _mostrar = value;
            }
        }

        #endregion

        /// <summary>
        /// z_guardia
        /// </summary>
        public z_guardia()
        {
        }


        /// <summary>
        /// z_guardia
        /// </summary>
        public z_guardia(System.Int32 id_guardia, string tipo_oficial, string oficial, string responsabilidades, bool mostrar)
        {
            this.id_guardia = id_guardia;
            this.tipo_oficial = tipo_oficial;
            this.oficial = oficial;
            this.responsabilidades = responsabilidades;
            this.mostrar = mostrar;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_guardia(z_guardia myz_guardia)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_guardia (tipo_oficial,oficial,responsabilidades,mostrar) VALUES ('"+myz_guardia.tipo_oficial+"','" + myz_guardia.oficial + "','" + myz_guardia.responsabilidades + "','" + myz_guardia.mostrar + "')";
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
        public void deletez_guardia(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_guardia WHERE (id_guardia = " + myID + ")", myConn);
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
        public void modifyz_guardia(z_guardia myz_guardia)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_guardia SET id_guardia=" + myz_guardia.id_guardia + ",tipo_oficial='" + myz_guardia.tipo_oficial + "',oficial='" + myz_guardia.oficial + "',responsabilidades='" + myz_guardia.responsabilidades + "',mostrar=" + myz_guardia.mostrar + " WHERE (id_guardia=" + myz_guardia.id_guardia + ")";
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
        public z_guardia getObjectz_guardia(System.Int32 myID)
        {
            z_guardia myz_guardia = new z_guardia();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_guardia,tipo_oficial,oficial,responsabilidades,mostrar FROM z_guardia WHERE (id_guardia=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_guardia.id_guardia = Convert.ToInt32(myReader[0]);
                    myz_guardia.tipo_oficial = myReader[1].ToString();
                    myz_guardia.oficial = myReader[2].ToString();
                    myz_guardia.responsabilidades = myReader[3].ToString();
                    myz_guardia.mostrar = Convert.ToBoolean(myReader[4]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_guardia;
        }

        public z_guardia getObjectz_guardia(string myID)
        {
            z_guardia myz_guardia = new z_guardia();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_guardia,tipo_oficial,oficial,responsabilidades,mostrar FROM z_guardia WHERE (tipo_oficial='" + myID + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_guardia.id_guardia = Convert.ToInt32(myReader[0]);
                    myz_guardia.tipo_oficial = myReader[1].ToString();
                    myz_guardia.oficial = myReader[2].ToString();
                    myz_guardia.responsabilidades = myReader[3].ToString();
                    myz_guardia.mostrar = Convert.ToBoolean(myReader[4]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_guardia;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_guardia()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_guardia";
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
