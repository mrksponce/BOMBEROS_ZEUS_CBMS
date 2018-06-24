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
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    /// <summary>
    /// z_prioridad
    /// </summary>
    public class z_prioridad
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_prioridad;
        public System.Int32 id_prioridad
        {
            get
            {
                return _id_prioridad;
            }
            set
            {
                _id_prioridad = value;
            }
        }

        private System.Int32 _id_area;
        public System.Int32 id_area
        {
            get
            {
                return _id_area;
            }
            set
            {
                _id_area = value;
            }
        }

        private System.Int32 _orden_prioridad;
        public System.Int32 orden_prioridad
        {
            get
            {
                return _orden_prioridad;
            }
            set
            {
                _orden_prioridad = value;
            }
        }

        private System.Int32 _despacho_b;
        public System.Int32 despacho_b
        {
            get
            {
                return _despacho_b;
            }
            set
            {
                _despacho_b = value;
            }
        }

        private System.Int32 _despacho_bx;
        public System.Int32 despacho_bx
        {
            get
            {
                return _despacho_bx;
            }
            set
            {
                _despacho_bx = value;
            }
        }

        private System.Int32 _despacho_br;
        public System.Int32 despacho_br
        {
            get
            {
                return _despacho_br;
            }
            set
            {
                _despacho_br = value;
            }
        }

        private System.Int32 _despacho_q;
        public System.Int32 despacho_q
        {
            get
            {
                return _despacho_q;
            }
            set
            {
                _despacho_q = value;
            }
        }

        private System.Int32 _despacho_qr;
        public System.Int32 despacho_qr
        {
            get
            {
                return _despacho_qr;
            }
            set
            {
                _despacho_qr = value;
            }
        }

        private System.Int32 _despacho_m;
        public System.Int32 despacho_m
        {
            get
            {
                return _despacho_m;
            }
            set
            {
                _despacho_m = value;
            }
        }

        private System.Int32 _despacho_r;
        public System.Int32 despacho_r
        {
            get
            {
                return _despacho_r;
            }
            set
            {
                _despacho_r = value;
            }
        }

        private System.Int32 _despacho_rx;
        public System.Int32 despacho_rx
        {
            get
            {
                return _despacho_rx;
            }
            set
            {
                _despacho_rx = value;
            }
        }

        private System.Int32 _despacho_h;
        public System.Int32 despacho_h
        {
            get
            {
                return _despacho_h;
            }
            set
            {
                _despacho_h = value;
            }
        }

        private System.Int32 _despacho_z;
        public System.Int32 despacho_z
        {
            get
            {
                return _despacho_z;
            }
            set
            {
                _despacho_z = value;
            }
        }

        private System.Int32 _despacho_x;
        public System.Int32 despacho_x
        {
            get
            {
                return _despacho_x;
            }
            set
            {
                _despacho_x = value;
            }
        }

        private System.Int32 _despacho_lt;
        public System.Int32 despacho_lt
        {
            get
            {
                return _despacho_lt;
            }
            set
            {
                _despacho_lt = value;
            }
        }

        private System.Int32 _despacho_s;
        public System.Int32 despacho_s
        {
            get
            {
                return _despacho_s;
            }
            set
            {
                _despacho_s = value;
            }
        }

        private System.Int32 _despacho_k;
        public System.Int32 despacho_k
        {
            get
            {
                return _despacho_k;
            }
            set
            {
                _despacho_k = value;
            }
        }

        private System.Int32 _despacho_j;
        public System.Int32 despacho_j
        {
            get
            {
                return _despacho_j;
            }
            set
            {
                _despacho_j = value;
            }
        }

        #endregion

        /// <summary>
        /// z_prioridad
        /// </summary>
        public z_prioridad()
        {
        }


        /// <summary>
        /// z_prioridad
        /// </summary>
        public z_prioridad(System.Int32 id_prioridad, System.Int32 id_area, System.Int32 orden_prioridad, System.Int32 despacho_b, System.Int32 despacho_bx, System.Int32 despacho_br, System.Int32 despacho_q, System.Int32 despacho_qr, System.Int32 despacho_m, System.Int32 despacho_r, System.Int32 despacho_rx, System.Int32 despacho_h, System.Int32 despacho_z, System.Int32 despacho_x, System.Int32 despacho_lt, System.Int32 despacho_s, System.Int32 despacho_k, System.Int32 despacho_j)
        {
            this.id_prioridad = id_prioridad;
            this.id_area = id_area;
            this.orden_prioridad = orden_prioridad;
            this.despacho_b = despacho_b;
            this.despacho_bx = despacho_bx;
            this.despacho_br = despacho_br;
            this.despacho_q = despacho_q;
            this.despacho_qr = despacho_qr;
            this.despacho_m = despacho_m;
            this.despacho_r = despacho_r;
            this.despacho_rx = despacho_rx;
            this.despacho_h = despacho_h;
            this.despacho_z = despacho_z;
            this.despacho_x = despacho_x;
            this.despacho_lt = despacho_lt;
            this.despacho_s = despacho_s;
            this.despacho_k = despacho_k;
            this.despacho_j = despacho_j;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_prioridad(z_prioridad myz_prioridad)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_prioridad (id_prioridad,id_area,orden_prioridad,despacho_b,despacho_bx,despacho_br,despacho_q,despacho_qr,despacho_m,despacho_r,despacho_rx,despacho_h,despacho_z,despacho_x,despacho_lt,despacho_s,despacho_k,despacho_j) VALUES (" + myz_prioridad.id_prioridad + "," + myz_prioridad.id_area + "," + myz_prioridad.orden_prioridad + "," + myz_prioridad.despacho_b + "," + myz_prioridad.despacho_bx + "," + myz_prioridad.despacho_br + "," + myz_prioridad.despacho_q + "," + myz_prioridad.despacho_qr + "," + myz_prioridad.despacho_m + "," + myz_prioridad.despacho_r + "," + myz_prioridad.despacho_rx + "," + myz_prioridad.despacho_h + "," + myz_prioridad.despacho_z + "," + myz_prioridad.despacho_x + "," + myz_prioridad.despacho_lt + "," + myz_prioridad.despacho_s + "," + myz_prioridad.despacho_k + "," + myz_prioridad.despacho_j + ")";
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
        public void deletez_prioridad(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_prioridad WHERE (id_prioridad = " + myID + ")", myConn);
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
        public void modifyz_prioridad(z_prioridad myz_prioridad)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_prioridad SET id_prioridad=" + myz_prioridad.id_prioridad + ",id_area=" + myz_prioridad.id_area + ",orden_prioridad=" + myz_prioridad.orden_prioridad + ",despacho_b=" + myz_prioridad.despacho_b + ",despacho_bx=" + myz_prioridad.despacho_bx + ",despacho_br=" + myz_prioridad.despacho_br + ",despacho_q=" + myz_prioridad.despacho_q + ",despacho_qr=" + myz_prioridad.despacho_qr + ",despacho_m=" + myz_prioridad.despacho_m + ",despacho_r=" + myz_prioridad.despacho_r + ",despacho_rx=" + myz_prioridad.despacho_rx + ",despacho_h=" + myz_prioridad.despacho_h + ",despacho_z=" + myz_prioridad.despacho_z + ",despacho_x=" + myz_prioridad.despacho_x + ",despacho_lt=" + myz_prioridad.despacho_lt + ",despacho_s=" + myz_prioridad.despacho_s + ",despacho_k=" + myz_prioridad.despacho_k + ",despacho_j=" + myz_prioridad.despacho_j + " WHERE (id_prioridad=" + myz_prioridad.id_prioridad + ")";
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

        public void modifyz_prioridad(int id_prioridad, List<KeyValuePair<string, int>> columnas)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE x_prioridad SET ";
            // construir comando
            string cols = "";
            foreach (KeyValuePair<string, int> k in columnas)
            {
                cols += k.Key + "=" + k.Value + ",";
            }
            cols = cols.Trim(',');
            reqSQL += cols + " WHERE id_prioridad=" + id_prioridad;
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
        public z_prioridad getObjectz_prioridad(System.Int32 myID)
        {
            z_prioridad myz_prioridad = new z_prioridad();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_prioridad,id_area,orden_prioridad,despacho_b,despacho_bx,despacho_br,despacho_q,despacho_qr,despacho_m,despacho_r,despacho_rx,despacho_h,despacho_z,despacho_x,despacho_lt,despacho_s,despacho_k,despacho_j FROM z_prioridad WHERE (id_prioridad=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_prioridad.id_prioridad = Convert.ToInt32(myReader[0]);
                    myz_prioridad.id_area = Convert.ToInt32(myReader[1]);
                    myz_prioridad.orden_prioridad = Convert.ToInt32(myReader[2]);
                    myz_prioridad.despacho_b = Convert.ToInt32(myReader[3]);
                    myz_prioridad.despacho_bx = Convert.ToInt32(myReader[4]);
                    myz_prioridad.despacho_br = Convert.ToInt32(myReader[5]);
                    myz_prioridad.despacho_q = Convert.ToInt32(myReader[6]);
                    myz_prioridad.despacho_qr = Convert.ToInt32(myReader[7]);
                    myz_prioridad.despacho_m = Convert.ToInt32(myReader[8]);
                    myz_prioridad.despacho_r = Convert.ToInt32(myReader[9]);
                    myz_prioridad.despacho_rx = Convert.ToInt32(myReader[10]);
                    myz_prioridad.despacho_h = Convert.ToInt32(myReader[11]);
                    myz_prioridad.despacho_z = Convert.ToInt32(myReader[12]);
                    myz_prioridad.despacho_x = Convert.ToInt32(myReader[13]);
                    myz_prioridad.despacho_lt = Convert.ToInt32(myReader[14]);
                    myz_prioridad.despacho_s = Convert.ToInt32(myReader[15]);
                    myz_prioridad.despacho_k = Convert.ToInt32(myReader[16]);
                    myz_prioridad.despacho_j = Convert.ToInt32(myReader[17]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_prioridad;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_prioridad()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_prioridad";
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

        /* DONDE SE DEBE MODIFICAR EL REGISTRO POR LA FUNCION QUE GENERARÁ LA PRIORIDAD */
        public DataSet Getz_prioridad(int id_area)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_prioridad where id_area=" + id_area + " order by orden_prioridad asc";
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

        /* ACTUALIZACION DE PRIORIDADES */
        public DataSet Getz_prioridad(int id_area, int grupo)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM x_prioridad where id_area=" + id_area + " and id_grupo = " + grupo;
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

        public DataSet Getx_orden_tipo(int codigo_llamado)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT ot.*, tc.* FROM x_orden_tipo ot, x_tipo_carro tc WHERE ot.id_llamado = "+codigo_llamado+" AND ot.orden_tipo = tc.tipo_carro ORDER BY ot.orden_tipo";
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
        /* **************************************************************************** */
    }


}
