using System;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
	public class est_consultas_detalle
	{
        
        #region ***** Campos y propiedades *****

        private System.Int32 _id_consulta;
        public System.Int32 id_consulta
        {
            get
            {
                return _id_consulta;
            }
            set
            {
                _id_consulta = value;
            }
        }

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

        private System.String _autor;
        public System.String autor
        {
            get
            {
                return _autor;
            }
            set
            {
                _autor = value;
            }
        }

        private System.String _titulo;
        public System.String titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                _titulo = value;
            }
        }

        private System.String _descripcion;
        public System.String descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        private System.String _consulta;
        public System.String consulta
        {
            get
            {
                return _consulta;
            }
            set
            {
                _consulta = value;
            }
        }
        #endregion

        /// <summary>
        /// est_consultas_detalle
        /// </summary>
        public est_consultas_detalle()
        {
        }


        /// <summary>
        /// est_consultas_detalle
        /// </summary>
        public est_consultas_detalle(int id_categoria, System.String autor, System.String titulo, string descripcion, string consulta)
        {
            this.id_categoria = id_categoria;
            this.autor = autor;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.consulta = consulta;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(est_consultas_detalle myest_consultas_detalle)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO est_consultas_detalle (id_categoria, autor, titulo, descripcion, consulta) VALUES (" + myest_consultas_detalle.id_categoria + ",'" + myest_consultas_detalle.autor + "','" + myest_consultas_detalle.titulo + "','"+myest_consultas_detalle.descripcion+ "','"+myest_consultas_detalle.consulta+"')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM est_consultas_detalle WHERE (id_consulta = " + myID + ")", myConn);
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
        public void Update(est_consultas_detalle myest_consultas_detalle)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE est_consultas_detalle SET id_categoria=" + myest_consultas_detalle.id_categoria + ",autor='" + myest_consultas_detalle.autor + "',titulo='" + myest_consultas_detalle.titulo + "',descripcion='" + myest_consultas_detalle.descripcion + "',consulta='"+myest_consultas_detalle.consulta+"' WHERE (id_consulta=" + myest_consultas_detalle.id_consulta + ")";
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
        public est_consultas_detalle getObjectest_consultas_detalle(System.Int32 myID)
        {
            est_consultas_detalle myest_consultas_detalle = new est_consultas_detalle();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_consulta,id_categoria,autor,titulo,descripcion,consulta FROM est_consultas_detalle WHERE (id_consulta=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myest_consultas_detalle.id_consulta = Convert.ToInt32(myReader[0]);
                    myest_consultas_detalle.id_categoria = Convert.ToInt32(myReader[1]);
                    myest_consultas_detalle.autor = myReader[2].ToString();
                    myest_consultas_detalle.titulo = myReader[3].ToString();
                    myest_consultas_detalle.descripcion = myReader[4].ToString();
                    myest_consultas_detalle.consulta = myReader[5].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myest_consultas_detalle;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getest_consultas_detalle()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM est_consultas_detalle";
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
        public DataSet Getest_consultas_detalle(int id)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM est_consultas_detalle where id_categoria=" + id;
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
