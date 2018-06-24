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
    /// z_bloque_horario
    /// </summary>
    public class z_bloque_horario
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_bloque_horario;
        public System.Int32 id_bloque_horario
        {
            get
            {
                return _id_bloque_horario;
            }
            set
            {
                _id_bloque_horario = value;
            }
        }

        private System.DateTime _hora_inicio;
        public System.DateTime hora_inicio
        {
            get
            {
                return _hora_inicio;
            }
            set
            {
                _hora_inicio = value;
            }
        }

        private System.DateTime _hora_termino;
        public System.DateTime hora_termino
        {
            get
            {
                return _hora_termino;
            }
            set
            {
                _hora_termino = value;
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

        #endregion

        /// <summary>
        /// z_bloque_horario
        /// </summary>
        public z_bloque_horario()
        {
        }


        /// <summary>
        /// z_bloque_horario
        /// </summary>
        public z_bloque_horario(System.Int32 id_bloque_horario, System.DateTime hora_inicio, System.DateTime hora_termino, System.String descripcion)
        {
            this.id_bloque_horario = id_bloque_horario;
            this.hora_inicio = hora_inicio;
            this.hora_termino = hora_termino;
            this.descripcion = descripcion;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_bloque_horario(z_bloque_horario myz_bloque_horario)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_bloque_horario (id_bloque_horario,hora_inicio,hora_termino,descripcion) VALUES (" + myz_bloque_horario.id_bloque_horario + ",'" + myz_bloque_horario.hora_inicio + "','" + myz_bloque_horario.hora_termino + "','" + myz_bloque_horario.descripcion + "')";
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
        public void deletez_bloque_horario(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_bloque_horario WHERE (id_bloque_horario = " + myID + ")", myConn);
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
        public void modifyz_bloque_horario(z_bloque_horario myz_bloque_horario)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_bloque_horario SET id_bloque_horario=" + myz_bloque_horario.id_bloque_horario + ",hora_inicio='" + myz_bloque_horario.hora_inicio + "',hora_termino='" + myz_bloque_horario.hora_termino + "',descripcion='" + myz_bloque_horario.descripcion + "' WHERE (id_bloque_horario=" + myz_bloque_horario.id_bloque_horario + ")";
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
        public z_bloque_horario getObjectz_bloque_horario(System.Int32 myID)
        {
            z_bloque_horario myz_bloque_horario = new z_bloque_horario();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_bloque_horario,hora_inicio,hora_termino,descripcion FROM z_bloque_horario WHERE (id_bloque_horario=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_bloque_horario.id_bloque_horario = Convert.ToInt32(myReader[0]);
                    myz_bloque_horario.hora_inicio = Convert.ToDateTime(myReader[1]);
                    myz_bloque_horario.hora_termino = Convert.ToDateTime(myReader[2]);
                    myz_bloque_horario.descripcion = myReader[3].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_bloque_horario;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_bloque_horario()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_bloque_horario order by id_bloque_horario";
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

        public int GetBloqueActual()
        {
            int bloque = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_bloque_horario from z_bloque_horario where hora_inicio<='"+DateTime.Now.ToShortTimeString()+"' and hora_termino>='"+DateTime.Now.ToShortTimeString()+"'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    bloque = Convert.ToInt32(myReader[0]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return bloque;
        }

        #endregion


    }


}
