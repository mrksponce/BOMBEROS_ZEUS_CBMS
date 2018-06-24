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
    /// f_ferias
    /// </summary>
    public class f_ferias
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _gid;
        public System.Int32 gid
        {
            get
            {
                return _gid;
            }
            set
            {
                _gid = value;
            }
        }

        private System.Int32 _id;
        public System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private System.String _comuna;
        public System.String comuna
        {
            get
            {
                return _comuna;
            }
            set
            {
                _comuna = value;
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

        private System.String _desde;
        public System.String desde
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

        private System.String _hasta;
        public System.String hasta
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

        private System.String _dia_1;
        public System.String dia_1
        {
            get
            {
                return _dia_1;
            }
            set
            {
                _dia_1 = value;
            }
        }

        private System.String _dia_2;
        public System.String dia_2
        {
            get
            {
                return _dia_2;
            }
            set
            {
                _dia_2 = value;
            }
        }

        private System.String _the_geom;
        public System.String the_geom
        {
            get
            {
                return _the_geom;
            }
            set
            {
                _the_geom = value;
            }
        }

        private int _d1;

        public int d1
        {
            get { return _d1; }
            set { _d1 = value; }
        }

        private int _d2;

        public int d2
        {
            get { return _d2; }
            set { _d2 = value; }
        }

        private DateTime _hora_inicio, _hora_termino;

        public DateTime hora_termino
        {
            get { return _hora_termino; }
            set { _hora_termino = value; }
        }

        public DateTime hora_inicio
        {
            get { return _hora_inicio; }
            set { _hora_inicio = value; }
        }

        #endregion

        /// <summary>
        /// f_ferias
        /// </summary>
        public f_ferias()
        {
        }


        /// <summary>
        /// f_ferias
        /// </summary>
        public f_ferias(System.Int32 gid, System.Int32 id, System.String comuna, System.String nombre, System.String desde, System.String hasta, System.String dia_1, System.String dia_2, System.String the_geom, int d1, int d2)
        {
            this.gid = gid;
            this.id = id;
            this.comuna = comuna;
            this.nombre = nombre;
            this.desde = desde;
            this.hasta = hasta;
            this.dia_1 = dia_1;
            this.dia_2 = dia_2;
            this.the_geom = the_geom;
            this.d1 = d1;
            this.d2 = d2;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(f_ferias myf_ferias)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO f_ferias (gid,id,comuna,nombre,desde,hasta,dia_1,dia_2,geom) VALUES (" + myf_ferias.gid + "," + myf_ferias.id + ",'" + myf_ferias.comuna + "','" + myf_ferias.nombre + "','" + myf_ferias.desde + "','" + myf_ferias.hasta + "','" + myf_ferias.dia_1 + "','" + myf_ferias.dia_2 + "','" + myf_ferias.the_geom + "')";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM f_ferias WHERE (geom = " + myID + ")", myConn);
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
        public void Update(f_ferias myf_ferias)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE f_ferias SET gid=" + myf_ferias.gid + ",id=" + myf_ferias.id + ",comuna='" + myf_ferias.comuna + "',nombre='" + myf_ferias.nombre + "',desde='" + myf_ferias.desde + "',hasta='" + myf_ferias.hasta + "',dia_1='" + myf_ferias.dia_1 + "',dia_2='" + myf_ferias.dia_2 + "',geom='" + myf_ferias.the_geom + "' WHERE (geom=" + myf_ferias.the_geom + ")";
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
        public f_ferias getObjectf_ferias(System.String myID)
        {
            f_ferias myf_ferias = new f_ferias();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT gid,id,comuna,nombre,desde,hasta,dia_1,dia_2,geom FROM f_ferias WHERE (geom='" + myID + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myf_ferias.gid = Convert.ToInt32(myReader[0]);
                    myf_ferias.id = Convert.ToInt32(myReader[1]);
                    myf_ferias.comuna = myReader[2].ToString();
                    myf_ferias.nombre = myReader[3].ToString();
                    myf_ferias.desde = myReader[4].ToString();
                    myf_ferias.hasta = myReader[5].ToString();
                    myf_ferias.dia_1 = myReader[6].ToString();
                    myf_ferias.dia_2 = myReader[7].ToString();
                    myf_ferias.the_geom = myReader[8].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myf_ferias;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getf_ferias()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM f_ferias";
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

        public DataSet Getf_ferias_punto(PointD centro, int radio)
        {
            CnxBase myBase = new CnxBase();
            PointD x1 = new PointD(centro.X - radio, centro.Y - radio);
            PointD x2 = new PointD(centro.X + radio, centro.Y + radio);

            string reqSQL = "SELECT comuna, nombre, desde, hasta, d1, d2, hora_inicio, hora_termino, st_Distance(geom,st_GeometryFromText('POINT(" + centro.ToString() + ")',32719)) As radio, " +
                    "st_astext(geom) FROM f_ferias " +
                    "WHERE geom && st_setsrid('BOX3D(" + x1.ToString() + "," + x2.ToString() + ")'::box3d,32719) " +
                    "AND st_Distance(st_GeometryFromText('POINT(" + centro.ToString() + ")',32719),geom) < " + radio.ToString() + " ORDER BY radio";
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
