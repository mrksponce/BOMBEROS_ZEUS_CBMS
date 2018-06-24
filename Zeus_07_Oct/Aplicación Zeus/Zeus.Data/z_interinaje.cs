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
    /// z_interinaje
    /// </summary>
    public class z_interinaje
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_interinaje;
        public System.Int32 id_interinaje
        {
            get
            {
                return _id_interinaje;
            }
            set
            {
                _id_interinaje = value;
            }
        }

        private System.DateTime _desde;
        public System.DateTime desde
        {
            get
            {
                return _desde;
            }
            set
            {
                _desde = value;
            }
        }

        private System.DateTime _hasta;
        public System.DateTime hasta
        {
            get
            {
                return _hasta;
            }
            set
            {
                _hasta = value;
            }
        }

        private System.Int32 _id_cargo;
        public System.Int32 id_cargo
        {
            get
            {
                return _id_cargo;
            }
            set
            {
                _id_cargo = value;
            }
        }

        private System.Int32 _id_reemplaza_a;
        public System.Int32 id_reemplaza_a
        {
            get
            {
                return _id_reemplaza_a;
            }
            set
            {
                _id_reemplaza_a = value;
            }
        }

        private bool _iniciada;

        public bool iniciada
        {
            get { return _iniciada; }
            set { _iniciada = value; }
        }

        private bool _terminada;

        public bool terminada
        {
            get { return _terminada; }
            set { _terminada = value; }
        }

        #endregion

        /// <summary>
        /// z_interinaje
        /// </summary>
        public z_interinaje()
        {
        }


        /// <summary>
        /// z_interinaje
        /// </summary>
        public z_interinaje(System.Int32 id_interinaje, System.DateTime desde, System.DateTime hasta, System.Int32 id_cargo, System.Int32 id_reemplaza_a)
        {
            this.id_interinaje = id_interinaje;
            this.desde = desde;
            this.hasta = hasta;
            this.id_cargo = id_cargo;
            this.id_reemplaza_a = id_reemplaza_a;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_interinaje(z_interinaje myz_interinaje)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_interinaje (desde,hasta,id_cargo,id_reemplaza_a) VALUES ('" + myz_interinaje.desde + "','" + myz_interinaje.hasta + "'," + myz_interinaje.id_cargo + "," + myz_interinaje.id_reemplaza_a + ")";
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
        public void deletez_interinaje(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_interinaje WHERE (id_interinaje = " + myID + ")", myConn);
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
        public void modifyz_interinaje(z_interinaje myz_interinaje)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_interinaje SET id_interinaje=" + myz_interinaje.id_interinaje + ",desde='" + myz_interinaje.desde + "',hasta='" + myz_interinaje.hasta + "',id_cargo=" + myz_interinaje.id_cargo + ",id_reemplaza_a=" + myz_interinaje.id_reemplaza_a + ", iniciada=" + myz_interinaje.iniciada + ",terminada=" + myz_interinaje.terminada + " WHERE (id_interinaje=" + myz_interinaje.id_interinaje + ")";
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
        public z_interinaje getObjectz_interinaje(System.Int32 myID)
        {
            z_interinaje myz_interinaje = new z_interinaje();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_interinaje,desde,hasta,id_cargo,id_reemplaza_a,iniciada,terminada FROM z_interinaje WHERE (id_interinaje=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_interinaje.id_interinaje = Convert.ToInt32(myReader[0]);
                    myz_interinaje.desde = Convert.ToDateTime(myReader[1]);
                    myz_interinaje.hasta = Convert.ToDateTime(myReader[2]);
                    myz_interinaje.id_cargo = Convert.ToInt32(myReader[3]);
                    myz_interinaje.id_reemplaza_a = Convert.ToInt32(myReader[4]);
                    myz_interinaje.iniciada = Convert.ToBoolean(myReader[5]);
                    myz_interinaje.terminada = Convert.ToBoolean(myReader[6]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_interinaje;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_interinaje()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_interinaje";
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

        public DataSet Getz_interinajeParaIniciar()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_interinaje where iniciado=false";
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
