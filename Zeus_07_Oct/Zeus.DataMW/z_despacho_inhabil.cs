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
    /// z_despacho_inhabil
    /// </summary>
    public class z_despacho_inhabil
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_despacho;
        public System.Int32 id_despacho
        {
            get
            {
                return _id_despacho;
            }
            set
            {
                _id_despacho = value;
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

        private System.Int32 _codigo_llamado;
        public System.Int32 codigo_llamado
        {
            get
            {
                return _codigo_llamado;
            }
            set
            {
                _codigo_llamado = value;
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
        private System.Int32 _despacho_mx;
        public System.Int32 despacho_mx
        {
            get
            {
                return _despacho_mx;
            }
            set
            {
                _despacho_mx = value;
            }
        }
        private System.Int32 _despacho_ut;
        public System.Int32 despacho_ut
        {
            get
            {
                return _despacho_ut;
            }
            set
            {
                _despacho_ut = value;
            }
        }
        private System.Boolean _dos_6;
        public System.Boolean dos_6
        {
            get
            {
                return _dos_6;
            }
            set
            {
                _dos_6 = value;
            }
        }

        #endregion

        /// <summary>
        /// z_despacho_inhabil
        /// </summary>
        public z_despacho_inhabil()
        {
        }


        /// <summary>
        /// z_despacho_inhabil
        /// </summary>
        public z_despacho_inhabil(System.Int32 id_despacho, System.Int32 id_area, System.Int32 codigo_llamado, System.Int32 despacho_b, System.Int32 despacho_bx, System.Int32 despacho_br, System.Int32 despacho_q, System.Int32 despacho_qr, System.Int32 despacho_m, System.Int32 despacho_r, System.Int32 despacho_rx, System.Int32 despacho_h, System.Int32 despacho_z, System.Int32 despacho_x, System.Int32 despacho_lt, System.Int32 despacho_s, System.Int32 despacho_k, System.Int32 despacho_j, System.Boolean dos_6)
        {
            this.id_despacho = id_despacho;
            this.id_area = id_area;
            this.codigo_llamado = codigo_llamado;
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
            this.dos_6 = dos_6;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_despacho_inhabil(z_despacho_inhabil myz_despacho_inhabil)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_despacho_inhabil (id_despacho,id_area,codigo_llamado,despacho_b,despacho_bx,despacho_br,despacho_q,despacho_qr,despacho_m,despacho_r,despacho_rx,despacho_h,despacho_z,despacho_x,despacho_lt,despacho_s,despacho_k,despacho_j,dos_6) VALUES (" + myz_despacho_inhabil.id_despacho + "," + myz_despacho_inhabil.id_area + "," + myz_despacho_inhabil.codigo_llamado + "," + myz_despacho_inhabil.despacho_b + "," + myz_despacho_inhabil.despacho_bx + "," + myz_despacho_inhabil.despacho_br + "," + myz_despacho_inhabil.despacho_q + "," + myz_despacho_inhabil.despacho_qr + "," + myz_despacho_inhabil.despacho_m + "," + myz_despacho_inhabil.despacho_r + "," + myz_despacho_inhabil.despacho_rx + "," + myz_despacho_inhabil.despacho_h + "," + myz_despacho_inhabil.despacho_z + "," + myz_despacho_inhabil.despacho_x + "," + myz_despacho_inhabil.despacho_lt + "," + myz_despacho_inhabil.despacho_s + "," + myz_despacho_inhabil.despacho_k + "," + myz_despacho_inhabil.despacho_j + "," + myz_despacho_inhabil.dos_6 + ")";
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
        public void deletez_despacho_inhabil(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_despacho_inhabil WHERE (id_despacho = " + myID + ")", myConn);
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
        public void modifyz_despacho_inhabil(z_despacho_inhabil myz_despacho_inhabil)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_despacho_inhabil SET id_despacho=" + myz_despacho_inhabil.id_despacho + ",id_area=" + myz_despacho_inhabil.id_area + ",codigo_llamado=" + myz_despacho_inhabil.codigo_llamado + ",despacho_b=" + myz_despacho_inhabil.despacho_b + ",despacho_bx=" + myz_despacho_inhabil.despacho_bx + ",despacho_br=" + myz_despacho_inhabil.despacho_br + ",despacho_q=" + myz_despacho_inhabil.despacho_q + ",despacho_qr=" + myz_despacho_inhabil.despacho_qr + ",despacho_m=" + myz_despacho_inhabil.despacho_m + ",despacho_r=" + myz_despacho_inhabil.despacho_r + ",despacho_rx=" + myz_despacho_inhabil.despacho_rx + ",despacho_h=" + myz_despacho_inhabil.despacho_h + ",despacho_z=" + myz_despacho_inhabil.despacho_z + ",despacho_x=" + myz_despacho_inhabil.despacho_x + ",despacho_lt=" + myz_despacho_inhabil.despacho_lt + ",despacho_s=" + myz_despacho_inhabil.despacho_s + ",despacho_k=" + myz_despacho_inhabil.despacho_k + ",despacho_j=" + myz_despacho_inhabil.despacho_j + ",dos_6=" + myz_despacho_inhabil.dos_6 + " WHERE (id_despacho=" + myz_despacho_inhabil.id_despacho + ")";
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
        public z_despacho_inhabil getObjectz_despacho_inhabil(System.Int32 id_despacho)
        {
            z_despacho_inhabil myz_despacho_inhabil = new z_despacho_inhabil();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_despacho,id_area,codigo_llamado,despacho_b,despacho_bx,despacho_br,despacho_q,despacho_qr,despacho_m,despacho_r,despacho_rx,despacho_h,despacho_z,despacho_x,despacho_lt,despacho_s,despacho_k,despacho_j,despacho_mx,despacho_ut,dos_6 FROM z_despacho_inhabil WHERE (id_despacho=" + id_despacho + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_despacho_inhabil.id_despacho = Convert.ToInt32(myReader[0]);
                    myz_despacho_inhabil.id_area = Convert.ToInt32(myReader[1]);
                    myz_despacho_inhabil.codigo_llamado = Convert.ToInt32(myReader[2]);
                    myz_despacho_inhabil.despacho_b = Convert.ToInt32(myReader[3]);
                    myz_despacho_inhabil.despacho_bx = Convert.ToInt32(myReader[4]);
                    myz_despacho_inhabil.despacho_br = Convert.ToInt32(myReader[5]);
                    myz_despacho_inhabil.despacho_q = Convert.ToInt32(myReader[6]);
                    myz_despacho_inhabil.despacho_qr = Convert.ToInt32(myReader[7]);
                    myz_despacho_inhabil.despacho_m = Convert.ToInt32(myReader[8]);
                    myz_despacho_inhabil.despacho_r = Convert.ToInt32(myReader[9]);
                    myz_despacho_inhabil.despacho_rx = Convert.ToInt32(myReader[10]);
                    myz_despacho_inhabil.despacho_h = Convert.ToInt32(myReader[11]);
                    myz_despacho_inhabil.despacho_z = Convert.ToInt32(myReader[12]);
                    myz_despacho_inhabil.despacho_x = Convert.ToInt32(myReader[13]);
                    myz_despacho_inhabil.despacho_lt = Convert.ToInt32(myReader[14]);
                    myz_despacho_inhabil.despacho_s = Convert.ToInt32(myReader[15]);
                    myz_despacho_inhabil.despacho_k = Convert.ToInt32(myReader[16]);
                    myz_despacho_inhabil.despacho_j = Convert.ToInt32(myReader[17]);
                    myz_despacho_inhabil.despacho_mx = Convert.ToInt32(myReader[18]);
                    myz_despacho_inhabil.despacho_ut = Convert.ToInt32(myReader[19]);
                    myz_despacho_inhabil.dos_6 = Convert.ToBoolean(myReader[20]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_despacho_inhabil;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_despacho_inhabil()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_despacho_inhabil";
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

        public DataSet Getz_despacho_inhabil(int id_area, int codigo_llamado)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_despacho_inhabil WHERE (id_area=" + id_area + " and codigo_llamado=" + codigo_llamado + ")";
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

        public DataSet Getz_despacho_inhabil(int id_despacho)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_despacho_inhabil WHERE (id_despacho=" + id_despacho + ")";
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

        public void modifyz_despacho_inhabil(int id_despacho, List<KeyValuePair<string, string>> columnas)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_despacho_inhabil SET ";
            // construir comando
            string cols = "";
            foreach (KeyValuePair<string, string> k in columnas)
            {
                cols += k.Key + "=" + k.Value + ",";
            }
            cols = cols.Trim(',');
            reqSQL += cols + " WHERE id_despacho=" + id_despacho;
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

        public void addz_despacho_inhabil(List<KeyValuePair<string, string>> columnas)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_despacho_inhabil ";
            // preparar
            string cols = "", vals = "";
            foreach (KeyValuePair<string, string> k in columnas)
            {
                cols += k.Key + ",";
                vals += k.Value + ",";
            }
            cols = "(" + cols.Trim(',') + ")";
            vals = "(" + vals.Trim(',') + ")";
            reqSQL += cols + " VALUES " + vals;
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
    }
}
