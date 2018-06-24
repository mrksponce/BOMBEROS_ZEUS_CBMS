using System;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    /// <summary>
    /// m001_config
    /// </summary>
    public class m001_config
    {
        
        #region ***** Campos y propiedades *****

        
        private System.Int32 _id_llamado;
        public System.Int32 id_llamado
        {
            get
            {
                return _id_llamado;
            }
            set
            {
                _id_llamado = value;
            }
        }

        private System.Int32 _radio;
        public System.Int32 radio
        {
            get
            {
                return _radio;
            }
            set
            {
                _radio = value;
            }
        }

        private System.Int32 _id_compania;
        public System.Int32 id_compania
        {
            get
            {
                return _id_compania;
            }
            set
            {
                _id_compania = value;
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

        private System.Int32 _x_cor;
        public System.Int32 x_cor
        {
            get
            {
                return _x_cor;
            }
            set
            {
                _x_cor = value;
            }
        }

        private System.Int32 _y_cor;
        public System.Int32 y_cor
        {
            get
            {
                return _y_cor;
            }
            set
            {
                _y_cor = value;
            }
        }
   
        #endregion



        /// <summary>
        /// m001_config
        /// </summary>
        public m001_config()
        {
        }


        /// <summary>
        /// m001_config
        /// </summary>
        public m001_config(System.Int32 id_llamado, System.Int32 radio, System.Int32 id_compania, System.Int32 id_carro)
        {
            this.id_llamado = id_llamado;
            this.radio = radio;
            this.id_compania = id_compania;
            this.id_carro = id_carro;
        }


        #region *****persistance managing methods



        /// <summary>
        /// get a DataSet from records
        /// </summary>

        public DataSet GetConfigM001(int IdLlamado)
        {
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT id_llamado, radio, id_compania, id_carro FROM m001_config WHERE id_llamado = " + IdLlamado + "";
            string reqSQL = "SELECT cnf.id_llamado, cnf.radio, cnf.id_compania, cnf.id_carro, round(st_x(cia.geom)) As pto_x, round(st_y(cia.geom)) As pto_y ";
            reqSQL += "FROM m001_config cnf, m001_companias cia ";
            reqSQL += "WHERE (cnf.id_llamado = " + IdLlamado + ") ";
            reqSQL += "AND cnf.id_compania = cia.id_compania";

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

        public m001_config ObjConfigM001(System.Int32 myID)
        {
            m001_config mym001_config = new m001_config();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT cnf.id_llamado, cnf.radio, cnf.id_compania, cnf.id_carro, round(st_x(cia.geom)) As pto_x, round(st_y(cia.geom)) As pto_y ";
            reqSQL += "FROM m001_config cnf, m001_companias cia ";
            reqSQL += "WHERE (cnf.id_llamado = " + myID + ") ";
            reqSQL += "AND cnf.id_compania = cia.id_compania";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mym001_config.id_llamado = Convert.ToInt32(myReader[0]);
                    mym001_config.radio = Convert.ToInt32(myReader[1]);
                    mym001_config.id_compania = Convert.ToInt32(myReader[2]);
                    mym001_config.id_carro = Convert.ToInt32(myReader[3]);
                    mym001_config.x_cor = Convert.ToInt32(myReader[4]);
                    mym001_config.y_cor = Convert.ToInt32(myReader[5]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mym001_config;
        }


        public int HayExpEnRadio(PointD centro, int radio, PointD pt_exp)
        {
            int intCarro = 0;
            PointD x1 = new PointD(centro.X - radio, centro.Y - radio);
            PointD x2 = new PointD(centro.X + radio, centro.Y + radio);
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT cnf.id_carro As carrosel FROM m001_companias cia, m001_config cnf ";
            reqSQL += "WHERE geom && st_setsrid('BOX3D(" + x1.ToString() + "," + x2.ToString() + ")'::box3d,32719) ";
            reqSQL += "AND st_Distance(st_GeometryFromText('POINT(" + centro.ToString() + ")',32719),st_GeometryFromText('POINT(" + pt_exp.ToString() + ")',32719)) < " + radio.ToString() +" ";
            reqSQL += "AND cia.id_compania = cnf.id_compania ";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow dr in myResult.Tables[0].Rows)
                {
                    intCarro = Convert.ToInt32(dr["carrosel"].ToString());
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return intCarro;
        }



        #endregion

    }
}
