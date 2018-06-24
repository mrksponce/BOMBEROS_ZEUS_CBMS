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
    /// dh_categorias
    /// </summary>
    public class dh_herramientas_carros
    {

        #region ***** Campos y propiedades *****

        private int _id_herramienta;
        public int id_herramienta
        {
            get
            {
                return _id_herramienta;
            }
            set
            {
                _id_herramienta = value;
            }
        }

        private int _id_carro;
        public int id_carro
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

        private int _cantidad;
        public int cantidad
        {
            get
            {
                return _cantidad;
            }
            set
            {
                _cantidad = value;
            }
        }

        private int _id_herramienta_carro;
        public int id_herramienta_carro
        {
            get
            {
                return _id_herramienta_carro;
            }
            set
            {
                _id_herramienta_carro = value;
            }
        }
        #endregion

        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_herramientas_carros()
        {
        }


        /// <summary>
        /// a_agenda_cat
        /// </summary>
        public dh_herramientas_carros(int id_herramienta, int id_carro, int cantidad)
        {
            this.id_herramienta = id_herramienta;
            this.id_carro = id_carro;
            this.cantidad = cantidad;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(dh_herramientas_carros mydh_herramcarro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO dh_herramientas_carros (id_herramienta, id_carro, cantidad) VALUES (" + mydh_herramcarro.id_herramienta + "," + mydh_herramcarro.id_carro + "," + mydh_herramcarro.cantidad + ")";
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
        public void Delete(int id_herramienta_carro)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM dh_herramientas_carros WHERE (id_herramienta_carro = " + id_herramienta_carro+")", myConn);
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
        public void Update(dh_herramientas_carros mydh_herramcarro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE dh_herramientas_carros SET id_carro=" + mydh_herramcarro.id_carro + ",cantidad=" + mydh_herramcarro.cantidad + " WHERE (id_herramienta_carro=" + mydh_herramcarro.id_herramienta_carro + ")";
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
        public dh_herramientas_carros getObject(int id_herramienta_carro)
        {
            dh_herramientas_carros dh_herramcarro = new dh_herramientas_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_herramienta_carro, id_herramienta,id_carro,cantidad FROM dh_herramientas_carros WHERE (id_herramienta_carro=" + id_herramienta_carro + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    dh_herramcarro.id_herramienta_carro = Convert.ToInt32(myReader[0]);
                    dh_herramcarro.id_herramienta = Convert.ToInt32(myReader[1]);
                    dh_herramcarro.id_carro = Convert.ToInt32(myReader[2]);
                    dh_herramcarro.cantidad = Convert.ToInt32(myReader[3]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return dh_herramcarro;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet GetDataSet()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_herramientas_carros";
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

        public DataSet GetDataSet(int id_herramienta)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_herramientas_carros where id_herramienta="+id_herramienta;
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

        public DataSet GetCarrosCantidad(int id_herramienta)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT dh_herramientas_carros.id_carro, nombre, cantidad FROM dh_herramientas_carros, z_carros where z_carros.estado=1 and z_carros.id_carro=dh_herramientas_carros.id_carro and id_herramienta=" + id_herramienta;
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
