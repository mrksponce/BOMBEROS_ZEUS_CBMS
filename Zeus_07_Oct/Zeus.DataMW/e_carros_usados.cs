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
    /// e_carros_usados
    /// </summary>
    public class e_carros_usados
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_expediente;
        public System.Int32 id_expediente
        {
            get
            {
                return _id_expediente;
            }
            set
            {
                _id_expediente = value;
            }
        }

        private System.Int32 _id_carro;
        public System.Int32 id_carro
        {
            get
            {
                return _id_carro;
            }
            set
            {
                _id_carro = value;
            }
        }

        private System.Int32 _id_voluntario;
        public System.Int32 id_voluntario
        {
            get
            {
                return _id_voluntario;
            }
            set
            {
                _id_voluntario = value;
            }
        }

        private System.Int32 _num_voluntarios;
        public System.Int32 num_voluntarios
        {
            get
            {
                return _num_voluntarios;
            }
            set
            {
                _num_voluntarios = value;
            }
        }
        private string _seis;

        public string seis
        {
            get { return _seis; }
            set { _seis = value; }
        }

        private string _preinforme;

        public string preinforme
        {
            get { return _preinforme; }
            set { _preinforme = value; }
        }

        private bool _en_jurisdiccion;

        public bool en_jurisdiccion
        {
            get { return _en_jurisdiccion; }
            set { _en_jurisdiccion = value; }
        }


        #endregion

        /// <summary>
        /// e_carros_usados
        /// </summary>
        public e_carros_usados()
        {
        }


        /// <summary>
        /// e_carros_usados
        /// </summary>
        public e_carros_usados(System.Int32 id_expediente, System.Int32 id_carro, System.Int32 id_voluntario, System.Int32 num_voluntarios, string seis0)
        {
            this.id_expediente = id_expediente;
            this.id_carro = id_carro;
            this.id_voluntario = id_voluntario;
            this.num_voluntarios = num_voluntarios;
            this.seis = seis;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(e_carros_usados mye_carros_usados)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO e_carros_usados (id_expediente,id_carro,id_voluntario,num_voluntarios,seis) VALUES (" + mye_carros_usados.id_expediente + "," + mye_carros_usados.id_carro + "," + mye_carros_usados.id_voluntario + "," + mye_carros_usados.num_voluntarios + ",'"+mye_carros_usados.seis+"')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM e_carros_usados WHERE (id_expediente = " + myID + ")", myConn);
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
        public void Update(e_carros_usados mye_carros_usados)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE e_carros_usados SET id_expediente=" + mye_carros_usados.id_expediente + ",id_carro=" + mye_carros_usados.id_carro + ",id_voluntario=" + mye_carros_usados.id_voluntario + ",num_voluntarios=" + mye_carros_usados.num_voluntarios + ", seis='" + mye_carros_usados.seis + "', preinforme='" + mye_carros_usados.preinforme + "', en_jurisdiccion="+mye_carros_usados.en_jurisdiccion+" WHERE (id_carro=" + mye_carros_usados.id_carro + ")";
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
        public e_carros_usados getObjecte_carros_usados(System.Int32 myID)
        {
            e_carros_usados mye_carros_usados = new e_carros_usados();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente,id_carro,id_voluntario,num_voluntarios, seis, preinforme, en_jurisdiccion FROM e_carros_usados WHERE (id_carro=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mye_carros_usados.id_expediente = Convert.ToInt32(myReader[0]);
                    mye_carros_usados.id_carro = Convert.ToInt32(myReader[1]);
                    mye_carros_usados.id_voluntario = Convert.ToInt32(myReader[2]);
                    mye_carros_usados.num_voluntarios = Convert.ToInt32(myReader[3]);
                    mye_carros_usados.seis = Convert.ToString(myReader[4]);
                    mye_carros_usados.preinforme = myReader[5].ToString();
                    mye_carros_usados.en_jurisdiccion = Convert.ToBoolean(myReader[6]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mye_carros_usados;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Gete_carros_usados()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM e_carros_usados";
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

        // hibrido
        public DataSet Gete_carros_exp(int id_expediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros.id_carro, nombre, id_tipo_carro, seis, id_despachado FROM e_carros_usados, z_carros where z_carros.id_carro=e_carros_usados.id_carro and id_expediente=" + id_expediente;
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

        public int getCantidad(int id_expediente)
        {
            int cant = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT count(id_carro) from e_carros_usados where id_expediente=" + id_expediente;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    cant = (int)myReader.GetInt64(0);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return cant;
        }

        public void freee_carros_usados(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM e_carros_usados WHERE (id_carro = " + myID + ")", myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString()));
            }
        }

        //private void Notify()
        //{
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "notify carro;";
        //    try
        //    {
        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //        myCommand.ExecuteNonQuery();
        //        myBase.CloseConnection(myConn);
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //}
    }


}
