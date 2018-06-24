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
using System.Security.Cryptography;
using System.Text;
using Npgsql;

namespace Zeus.Data
{
    /// <summary>
    /// z_locutores
    /// </summary>
    public class z_locutores
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_locutor;
        public System.Int32 id_locutor
        {
            get
            {
                return _id_locutor;
            }
            set
            {
                _id_locutor = value;
            }
        }

        private System.String _login;
        public System.String login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        private System.String _password;
        public System.String password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        private System.Boolean _admin;
        public System.Boolean admin
        {
            get
            {
                return _admin;
            }
            set
            {
                _admin = value;
            }
        }

        private int _id_tipo_locutor;

        public int id_tipo_locutor
        {
            get { return _id_tipo_locutor; }
            set { _id_tipo_locutor = value; }
        }

        private int _id_op_vol;

        public int id_op_vol
        {
            get { return _id_op_vol; }
            set { _id_op_vol = value; }
        }

        #endregion

        /// <summary>
        /// z_locutores
        /// </summary>
        public z_locutores()
        {
        }


        /// <summary>
        /// z_locutores
        /// </summary>
        public z_locutores(System.Int32 id_operadora, System.String login, System.String password, System.Boolean admin)
        {
            this.id_locutor = id_operadora;
            this.login = login;
            this.password = password;
            this.admin = admin;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_locutores(z_locutores myz_locutores)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_locutores (login,password,admin, id_tipo_locutor, id_op_vol) VALUES ('" + myz_locutores.login + "','" + myz_locutores.password + "'," + myz_locutores.admin + ","+myz_locutores.id_tipo_locutor+","+myz_locutores.id_op_vol+")";
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
        public void deletez_locutores(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_locutores WHERE (id_locutor = " + myID + ")", myConn);
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
        public void modifyz_locutores(z_locutores myz_locutores)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_locutores SET id_locutor=" + myz_locutores.id_locutor + ",login='" + myz_locutores.login + "',password='" + myz_locutores.password + "',admin=" + myz_locutores.admin + ", id_tipo_locutor="+myz_locutores.id_tipo_locutor+", id_op_vol="+myz_locutores.id_op_vol+" WHERE (id_locutor=" + myz_locutores.id_locutor + ")";
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
        public z_locutores getObjectz_locutores(System.Int32 myID)
        {
            z_locutores myz_locutores = new z_locutores();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_locutor,login,password,admin,id_tipo_locutor, id_op_vol FROM z_locutores WHERE (id_locutor=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_locutores.id_locutor = Convert.ToInt32(myReader[0]);
                    myz_locutores.login = myReader[1].ToString();
                    myz_locutores.password = myReader[2].ToString();
                    myz_locutores.admin = Convert.ToBoolean(myReader[3]);
                    myz_locutores.id_tipo_locutor = Convert.ToInt32(myReader[4]);
                    myz_locutores.id_op_vol = Convert.ToInt32(myReader[5]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_locutores;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_locutores()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_locutores";
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

        public string GenerateHash(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] bstext = UE.GetBytes(text);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(bstext);
            return Convert.ToBase64String(hash);
        }

        public z_locutores Login(string user, string password)
        {
            z_locutores myz_locutores = null;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_locutor,login,password,admin FROM z_locutores WHERE (login='" + user + "' and password='" + GenerateHash(password) + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_locutores = new z_locutores();
                    myz_locutores.id_locutor = Convert.ToInt32(myReader[0]);
                    myz_locutores.login = myReader[1].ToString();
                    myz_locutores.password = myReader[2].ToString();
                    myz_locutores.admin = Convert.ToBoolean(myReader[3]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_locutores;

        }

        public DataSet Getz_locutoresLista()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_locutor, apellidos||' '||nombres as nombre_completo from z_voluntarios, z_locutores where id_tipo_locutor=2 and id_op_vol=id_voluntario UNION select id_locutor, apellidos||' '||nombres as nombre_completo from z_operadoras, z_locutores where id_tipo_locutor=1 and id_op_vol=z_operadoras.id_operadora";
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
