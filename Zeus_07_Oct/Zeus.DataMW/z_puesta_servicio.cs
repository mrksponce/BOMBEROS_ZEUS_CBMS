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
    /// z_puesta_servicio
    /// </summary>
    public class z_puesta_servicio
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_puesta_servicio;
        public System.Int32 id_puesta_servicio
        {
            get
            {
                return _id_puesta_servicio;
            }
            set
            {
                _id_puesta_servicio = value;
            }
        }

        private System.DateTime _fecha_hora;
        public System.DateTime fecha_hora
        {
            get
            {
                return _fecha_hora;
            }
            set
            {
                _fecha_hora = value;
            }
        }

        private System.Int32 _id_conductor;
        public System.Int32 id_conductor
        {
            get
            {
                return _id_conductor;
            }
            set
            {
                _id_conductor = value;
            }
        }

        private System.String _id_carros_ps;
        public System.String id_carros_ps
        {
            get
            {
                return _id_carros_ps;
            }
            set
            {
                _id_carros_ps = value;
            }
        }

        private string _id_carros_fs;

        public string id_carros_fs
        {
            get { return _id_carros_fs; }
            set { _id_carros_fs = value; }
        }

        private int _id_operadora;

        public int id_operadora
        {
            get { return _id_operadora; }
            set { _id_operadora = value; }
        }

        private int _id_aval;

        public int id_aval
        {
            get { return _id_aval; }
            set { _id_aval = value; }
        }
        #endregion

        /// <summary>
        /// z_puesta_servicio
        /// </summary>
        public z_puesta_servicio()
        {
            id_carros_fs = "";
            id_carros_ps = "";
        }


        /// <summary>
        /// z_puesta_servicio
        /// </summary>
        public z_puesta_servicio(System.Int32 id_puesta_servicio, System.DateTime fecha_hora, System.Int32 id_conductor, System.String id_carros_ps, string id_carros_fs)
        {
            this.id_puesta_servicio = id_puesta_servicio;
            this.fecha_hora = fecha_hora;
            this.id_conductor = id_conductor;
            this.id_carros_ps = id_carros_ps;
            this.id_carros_fs = id_carros_fs;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_puesta_servicio(z_puesta_servicio myz_puesta_servicio)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_puesta_servicio (fecha_hora,id_conductor,id_carros_ps, id_carros_fs, id_operadora, id_aval) VALUES ('" + myz_puesta_servicio.fecha_hora + "'," + myz_puesta_servicio.id_conductor + ",'" + myz_puesta_servicio.id_carros_ps + "','" + myz_puesta_servicio.id_carros_fs + "'," + myz_puesta_servicio.id_operadora + ","+myz_puesta_servicio.id_aval+")";
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
        public void deletez_puesta_servicio(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_puesta_servicio WHERE (id_puesta_servicio = " + myID + ")", myConn);
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
        public void modifyz_puesta_servicio(z_puesta_servicio myz_puesta_servicio)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_puesta_servicio SET id_puesta_servicio=" + myz_puesta_servicio.id_puesta_servicio + ",fecha_hora='" + myz_puesta_servicio.fecha_hora + "',id_conductor=" + myz_puesta_servicio.id_conductor + ",id_carros_ps='" + myz_puesta_servicio.id_carros_ps + "',id_carros_fs='" + myz_puesta_servicio.id_carros_fs + "',id_operadora=" + myz_puesta_servicio.id_operadora + " WHERE (id_puesta_servicio=" + myz_puesta_servicio.id_puesta_servicio + ")";
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
        public z_puesta_servicio getObjectz_puesta_servicio(System.Int32 myID)
        {
            z_puesta_servicio myz_puesta_servicio = new z_puesta_servicio();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_puesta_servicio,fecha_hora,id_conductor,id_carros_ps, id_carros_fs, id_operadora FROM z_puesta_servicio WHERE (id_puesta_servicio=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_puesta_servicio.id_puesta_servicio = Convert.ToInt32(myReader[0]);
                    myz_puesta_servicio.fecha_hora = Convert.ToDateTime(myReader[1]);
                    myz_puesta_servicio.id_conductor = Convert.ToInt32(myReader[2]);
                    try { myz_puesta_servicio.id_carros_ps = myReader[3].ToString(); }
                    catch { myz_puesta_servicio.id_carros_ps = ""; }
                    try { myz_puesta_servicio.id_carros_fs = myReader[4].ToString(); }
                    catch { myz_puesta_servicio.id_carros_fs = ""; }
                    myz_puesta_servicio.id_operadora = Convert.ToInt32(myReader[5]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_puesta_servicio;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_puesta_servicio()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_puesta_servicio";
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
