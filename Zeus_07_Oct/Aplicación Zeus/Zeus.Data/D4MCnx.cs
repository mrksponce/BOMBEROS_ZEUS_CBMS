/********************************
 *
 * Clase del motor de persistencia
 * (c)2004 DORLAC S.T.
 * http://www.d4modelizer.com
 *
 * ******************************/
using System;
using System.Data;
using Npgsql;
using System.Data.Odbc;

namespace Zeus.Data
{
    /// <summary>
    /// CnxBase 
    /// </summary>
    public class CnxBase
    {

        /// <summary>
        /// CnxBase
        /// </summary>

        private string _cnxString;
        private string mrksponce;
        public string cnxString
        {
            get
            {
                return _cnxString;
            }
            set
            {
                _cnxString = value;
            }
        }
        public CnxBase()
        {
#if CBMS
            cnxString = "User ID= cbms_zeus;Password= vaspAha3pEdreThe;Host=" + DataSettings.Default.Host + ";Port=5432;Database=" + DataSettings.Default.Database + ";Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
#elif CBQN
            // CAyAfrezahAYaph3
            //cnxString = "User ID=cbqn_zeus;Password=123;Host=192.168.0.92;Port=5432;Database=zeus-cbqn;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=LATIN1";
            //FIJO cnxString = "User ID=cbqn_zeus;Password=123;Host=192.168.0.92;Port=5432;Database=zeus_cbs_v15;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=LATIN1";
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=192.168.0.92;Port=5432;Database=zeus_cbs_v14;Pooling=true;Min Pool Size=0;MaxPoolSize=100;Connection Lifetime=0; Client Encoding=LATIN1; Timeout=30";
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=192.168.0.93;Port=5432;Database=zeus_cbs_v8999;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=LATIN1; Timeout=30";
            
            
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=192.168.0.7;Port=5432;Database=zeus_cbpa_v7;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=LATIN1; Timeout=30";
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=localhost;Port=5432;Database=zeus_cbms_v8;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=192.100.101.170;Port=5432;Database=zeus_cbms_x1_v1;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
            
                       
            
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=192.168.0.63;Port=5432;Database=zeus_cbms_home;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=172.16.101.170;Port=5432;Database=zeus_cbms_x1_v2;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=172.16.100.170;Port=5432;Database=zeus_cbms_v1;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";

            
            
            
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=172.16.101.127;Port=5432;Database=zeus_cbms_i7;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
            cnxString = "User ID= postgres;Password=123;Host=localhost;Port=5432;Database=zeus_cbms_i7a;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";

            //cnxString = "User ID= cbqn_zeus;Password=123;Host=172.16.100.127;Port=5432;Database=zeus_cbms_i7a;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
            //cnxString = "User ID= cbqn_zeus;Password=123;Host=localhost;Port=5432;Database=zeus_cbms_i7a;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0; Client Encoding=UTF8; Timeout=30";
            
            
            

#endif
        }

        public void setQueryCnx()
        {
#if CBMS
            cnxString = "User ID= cbms_query;Password= du8RUcratUC22Eqe;Host=" + DataSettings.Default.Host + ";Port=5432;Database=" + DataSettings.Default.Database + ";Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";
#elif CBQN


            //cnxString = "User ID=cbqn_query;Password=wruYE7tusWATr4du;Host=Host=192.100.101.170;Port=5432;Database=zeus_cbms_x1_v1;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";
            //cnxString = "User ID=cbqn_query;Password=wruYE7tusWATr4du;Host=Host=192.168.0.63;Port=5432;Database=zeus_cbms_home;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";
            //cnxString = "User ID=cbqn_query;Password=wruYE7tusWATr4du;Host=Host=172.16.101.170;Port=5432;Database=zeus_cbms_x1_v2;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";
            cnxString = "User ID=cbqn_query;Password=wruYE7tusWATr4du;Host=Host=localhost;Port=5432;Database=zeus_cbms_i7a;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";

            //cnxString = "User ID=cbqn_query;Password=wruYE7tusWATr4du;Host=Host=localhost;Port=5432;Database=zeus_cbms_i7a;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";
            //cnxString = "User ID=cbqn_query;Password=wruYE7tusWATr4du;Host=Host=172.16.101.127;Port=5432;Database=zeus_cbms_i7a;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";
            //cnxString = "User ID=cbqn_query;Password=wruYE7tusWATr4du;Host=Host=172.16.100.170;Port=5432;Database=zeus_cbms_v1;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0; Client Encoding=UTF8";

                        
#endif
        }

        #region Metodos de persistencia

        /// <summary>
        /// Obtener una conexión abierta.
        /// </summary>
        public NpgsqlConnection OpenConnection(string connectionString)
        {
            try
            {
                NpgsqlConnection myPostgreSQLConnection = new NpgsqlConnection(connectionString);
                myPostgreSQLConnection.Open();
                return myPostgreSQLConnection;
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }

        /// <summary>
        /// Cerrar conexión
        /// </summary>
        public void CloseConnection(NpgsqlConnection myPostgreSQLConnection)
        {
            try
            {
                if (myPostgreSQLConnection.State == ConnectionState.Open)
                {
                    myPostgreSQLConnection.Close();
                }
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message));
            }
        }

        /// <summary>
        /// Obtener DataSet dependiendo de la solicitud
        /// </summary>
        public DataSet GetDataSet(string strSQL)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlDataAdapter myDataAdapter = new NpgsqlDataAdapter(strSQL, myConn);
                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "MySrcTable");
                myBase.CloseConnection(myConn);
                return myDataSet;
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message + " => " + strSQL));
            }
        }

        public DataSet GetDataSet(string strSQL,CnxBase myBase)
        {
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlDataAdapter myDataAdapter = new NpgsqlDataAdapter(strSQL, myConn);
                DataSet myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "MySrcTable");
                myBase.CloseConnection(myConn);
                return myDataSet;
            }
            catch (Exception myException)
            {
                throw (new Exception(myException.Message + " => " + strSQL));
            }
        }

        #endregion



        public static bool tablaExiste(string tabla)
        {
            CnxBase myBase = new CnxBase();
            bool ret = false;
            string reqSQL = "select exists(select relname from pg_class where relname='" + tabla + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = (bool)myCommand.ExecuteScalar();
                myBase.CloseConnection(myConn);
            }
            catch
            {
                return false;
            }
            return ret;
        }
    }
}

