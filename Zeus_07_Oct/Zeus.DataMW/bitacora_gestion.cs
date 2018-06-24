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
    /// bitacora_gestion
    /// </summary>
    public class bitacora_gestion
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_evento;
        public System.Int32 id_evento
        {
            get
            {
                return _id_evento;
            }
            set
            {
                _id_evento = value;
            }
        }

        private System.DateTime _fecha;
        public System.DateTime fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        private System.Int32 _id_operadora1;
        public System.Int32 id_operadora1
        {
            get
            {
                return _id_operadora1;
            }
            set
            {
                _id_operadora1 = value;
            }
        }

        private System.Int32 _id_operadora2;
        public System.Int32 id_operadora2
        {
            get
            {
                return _id_operadora2;
            }
            set
            {
                _id_operadora2 = value;
            }
        }

        private System.String _evento;
        public System.String evento
        {
            get
            {
                return _evento;
            }
            set
            {
                _evento = value;
            }
        }

        #endregion

        /// <summary>
        /// bitacora_gestion
        /// </summary>
        public bitacora_gestion()
        {
        }


        /// <summary>
        /// bitacora_gestion
        /// </summary>
        public bitacora_gestion(System.Int32 id_evento, System.DateTime fecha, System.Int32 id_operadora1, System.Int32 id_operadora2, System.String evento)
        {
            this.id_evento = id_evento;
            this.fecha = fecha;
            this.id_operadora1 = id_operadora1;
            this.id_operadora2 = id_operadora2;
            this.evento = evento;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(bitacora_gestion mybitacora_gestion,bool fecha_servidor)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO bitacora_gestion (fecha,id_operadora1,id_operadora2,evento) VALUES ('" + (fecha_servidor ? "now" : mybitacora_gestion.fecha.ToString()) + "'," + mybitacora_gestion.id_operadora1 + "," + mybitacora_gestion.id_operadora2 + ",'" + mybitacora_gestion.evento + "')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM bitacora_gestion WHERE (id_evento = " + myID + ")", myConn);
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
        public void Update(bitacora_gestion mybitacora_gestion)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE bitacora_gestion SET id_evento=" + mybitacora_gestion.id_evento + ",fecha='" + mybitacora_gestion.fecha + "',id_operadora1=" + mybitacora_gestion.id_operadora1 + ",id_operadora2=" + mybitacora_gestion.id_operadora2 + ",evento='" + mybitacora_gestion.evento + "' WHERE (id_evento=" + mybitacora_gestion.id_evento + ")";
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
        public bitacora_gestion getObjectbitacora_gestion(System.Int32 myID)
        {
            bitacora_gestion mybitacora_gestion = new bitacora_gestion();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_evento,fecha,id_operadora1,id_operadora2,evento FROM bitacora_gestion WHERE (id_evento=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mybitacora_gestion.id_evento = Convert.ToInt32(myReader[0]);
                    mybitacora_gestion.fecha = Convert.ToDateTime(myReader[1]);
                    mybitacora_gestion.id_operadora1 = Convert.ToInt32(myReader[2]);
                    mybitacora_gestion.id_operadora2 = Convert.ToInt32(myReader[3]);
                    mybitacora_gestion.evento = myReader[4].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mybitacora_gestion;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getbitacora_gestion()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select fecha, op.login as realiza, av.login as autoriza, evento from bitacora_gestion  join z_locutores op on id_operadora1=op.id_locutor join z_locutores av on id_operadora2=av.id_locutor order by fecha desc";
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

        public DataSet Getbitacora_gestion_limit()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select fecha, op.login as realiza, av.login as autoriza, evento from bitacora_gestion  join z_locutores op on id_operadora1=op.id_locutor join z_locutores av on id_operadora2=av.id_locutor order by fecha desc limit 500";
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

        public DataSet Getbitacora_gestion_limit_specific(string carro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select fecha, op.login as realiza, av.login as autoriza, evento from bitacora_gestion  join z_locutores op on id_operadora1=op.id_locutor join z_locutores av on id_operadora2=av.id_locutor where evento like '%" + carro + "%' order by fecha desc limit 500";
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

        public DataSet GetBitacorasCombinadas()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select fecha, login as realiza, '' as autoriza, evento  from bitacora_llamados, z_locutores where id_operadora=id_locutor " +
                "union select fecha, op.login as realiza, av.login as autoriza, evento from bitacora_gestion join z_locutores op on id_operadora1=op.id_locutor join z_locutores av on id_operadora2=av.id_locutor order by fecha limit 1000";
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

        public DataSet GetBitacorasCombinadas(DateTime fecha)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select fecha, login as realiza, '' as autoriza, evento  from bitacora_llamados, z_locutores where id_operadora=id_locutor and fecha<'"+fecha.ToString()+"'" +
                "union select fecha, op.login as realiza, av.login as autoriza, evento from bitacora_gestion join z_locutores op on id_operadora1=op.id_locutor join z_locutores av on id_operadora2=av.id_locutor where fecha<'"+fecha.ToString()+"' order by fecha";
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
