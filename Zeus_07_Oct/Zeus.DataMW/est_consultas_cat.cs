using System;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    public class est_consultas_cat
    {
        #region ***** Campos y propiedades *****

        private System.Int32 _id_categoria;
        public System.Int32 id_categoria
        {
            get
            {
                return _id_categoria;
            }
            set
            {
                _id_categoria = value;
            }
        }

        private System.String _nombre;
        public System.String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        #endregion

        /// <summary>
        /// est_consultas_cat
        /// </summary>
        public est_consultas_cat()
        {
        }


        /// <summary>
        /// est_consultas_cat
        /// </summary>
        public est_consultas_cat(System.Int32 id_cat, System.String nombre)
        {
            this.id_categoria = id_cat;
            this.nombre = nombre;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(est_consultas_cat myest_consultas_cat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO est_consultas_cat (nombre) VALUES ('" + myest_consultas_cat.nombre + "'" + ")";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM est_consultas_cat WHERE (id_categoria = " + myID + ")", myConn);
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
        public void Update(est_consultas_cat myest_consultas_cat)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE est_consultas_cat SET id_categoria=" + myest_consultas_cat.id_categoria + ",nombre='" + myest_consultas_cat.nombre + "' WHERE (id_categoria=" + myest_consultas_cat.id_categoria + ")";
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
        public est_consultas_cat getObjectest_consultas_cat(System.Int32 myID)
        {
            est_consultas_cat myest_consultas_cat = new est_consultas_cat();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_categoria,nombre FROM est_consultas_cat WHERE (id_categoria=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myest_consultas_cat.id_categoria = Convert.ToInt32(myReader[0]);
                    myest_consultas_cat.nombre = myReader[1].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myest_consultas_cat;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getest_consultas_cat()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM est_consultas_cat";
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
