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
using System.Collections;

namespace Zeus.Data
{
    /// <summary>
    /// z_orden
    /// </summary>
    public class z_orden
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_orden;
        public System.Int32 id_orden
        {
            get
            {
                return _id_orden;
            }
            set
            {
                _id_orden = value;
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

        private System.Int32 _orden_numero;
        public System.Int32 orden_numero
        {
            get
            {
                return _orden_numero;
            }
            set
            {
                _orden_numero = value;
            }
        }

        private System.Int32 _id_tipo_carro;
        public System.Int32 id_tipo_carro
        {
            get
            {
                return _id_tipo_carro;
            }
            set
            {
                _id_tipo_carro = value;
            }
        }

        #endregion

        /// <summary>
        /// z_orden
        /// </summary>
        public z_orden()
        {
        }


        /// <summary>
        /// z_orden
        /// </summary>
        public z_orden(System.Int32 id_orden, System.Int32 codigo_llamado, System.Int32 orden_numero, System.Int32 id_tipo_carro)
        {
            this.id_orden = id_orden;
            this.codigo_llamado = codigo_llamado;
            this.orden_numero = orden_numero;
            this.id_tipo_carro = id_tipo_carro;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_orden(z_orden myz_orden)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_orden (id_orden,codigo_llamado,orden_numero,id_tipo_carro) VALUES (" + myz_orden.id_orden + "," + myz_orden.codigo_llamado + "," + myz_orden.orden_numero + "," + myz_orden.id_tipo_carro + ")";
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
        public void deletez_orden(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_orden WHERE (id_orden = " + myID + ")", myConn);
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
        public void modifyz_orden(z_orden myz_orden)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_orden SET id_orden=" + myz_orden.id_orden + ",codigo_llamado=" + myz_orden.codigo_llamado + ",orden_numero=" + myz_orden.orden_numero + ",id_tipo_carro=" + myz_orden.id_tipo_carro + " WHERE (id_orden=" + myz_orden.id_orden + ")";
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
        public z_orden getObjectz_orden(System.Int32 myID)
        {
            z_orden myz_orden = new z_orden();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_orden,codigo_llamado,orden_numero,id_tipo_carro FROM z_orden WHERE (id_orden=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_orden.id_orden = Convert.ToInt32(myReader[0]);
                    myz_orden.codigo_llamado = Convert.ToInt32(myReader[1]);
                    myz_orden.orden_numero = Convert.ToInt32(myReader[2]);
                    myz_orden.id_tipo_carro = Convert.ToInt32(myReader[3]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_orden;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_orden(int codigo_llamado)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_orden where codigo_llamado=" + codigo_llamado + " order by id_tipo_carro asc";
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

        public DataSet Getz_orden_tipo(int codigo_llamado)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_tipo_carro.id_tipo_carro,tipo_carro_letra,id_orden FROM z_orden, z_tipo_carro where codigo_llamado=" + codigo_llamado + " and z_orden.id_tipo_carro=z_tipo_carro.id_tipo_carro order by orden_numero asc";
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

        ////### X_ORDEN_GRUPO
        //public ArrayList xOrdenGrupo(int codigo_llamado)
        //{
        //    CnxBase myBase = new CnxBase();
        //    ArrayList aOrden = new ArrayList();
        //    //SELECT * FROM x_orden_grupo WHERE id_llamado = 120 AND id_grupo IN (SELECT id_grupo FROM x_despacho_habil WHERE id_llamado = 120) ORDER BY orden_grupo
        //    string reqSQL = "SELECT id_grupo FROM x_orden_grupo WHERE id_llamado=" + codigo_llamado + " AND id_grupo IN (SELECT id_grupo FROM x_despacho_habil WHERE id_llamado =" + codigo_llamado + ") ORDER BY orden_grupo";
        //    try
        //    {
        //        CnxBase myD4MCnx = new CnxBase();
        //        DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
        //        foreach (DataRow rOrden in myResult.Tables[0].Rows)
        //        {
        //            aOrden.Add(rOrden["id_grupo"].ToString());
        //        }
        //        return aOrden;
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //}

        //### X_ORDEN_GRUPO
        public ArrayList xOrdenGrupo(int codigo_llamado, int distinto)
        {
            CnxBase myBase = new CnxBase();
            ArrayList aOrden = new ArrayList();

            string reqSQL = "SELECT id_grupo FROM x_orden_grupo WHERE id_distinto=" + distinto + " AND id_llamado=" + codigo_llamado + " AND id_grupo IN (SELECT id_grupo FROM x_despacho_habil WHERE id_llamado =" + codigo_llamado + ") ORDER BY orden_grupo";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow rOrden in myResult.Tables[0].Rows)
                {
                    aOrden.Add(rOrden["id_grupo"].ToString());
                }
                return aOrden;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        //### X_ORDEN_GRUPO_DISTINTO
        public int xOrdenGrupoDistinto(int codigoLlamado, int idArea)
        {
            CnxBase myD4MCnx = new CnxBase();
            int codigoRetorno = 0;
            string reqSQL = "SELECT id_area, id_llamado, id_distinto FROM x_orden_grupo_distinto WHERE id_area = " + idArea + " and id_llamado = " + codigoLlamado + "";
            try
            {

                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        if (codigoLlamado.ToString() == dr_row["id_llamado"].ToString() && idArea.ToString() == dr_row["id_area"].ToString())
                        {
                            codigoRetorno = Convert.ToInt32(dr_row["id_distinto"].ToString());
                        }
                        else
                        {
                            codigoRetorno = 0;
                        }
                    }
                }
                else
                {
                    codigoRetorno = 0;
                }
                return codigoRetorno;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }



        public ArrayList xGruposDespachoHabil(int codigo_llamado)
        {
            CnxBase myBase = new CnxBase();
            ArrayList aOrden = new ArrayList();
            string reqSQL = "SELECT id_grupo FROM x_despacho_habil WHERE id_llamado = " + codigo_llamado;
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow rOrden in myResult.Tables[0].Rows)
                {
                    aOrden.Add(rOrden["id_grupo"].ToString());
                }
                return aOrden;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public int[] recuperarTipoCarroOrdenTipo(int cod_llamado, string tc_usar, int grupo_area, bool Ev_Gp_Ar)
        {
            CnxBase myBase = new CnxBase();
            ArrayList aOrden = new ArrayList();
            int[] retornoTipoCarro = null;
            int i = 0;
            string reqSQL;
            //if (Ev_Gp_Ar)
            //{
                //reqSQL = "SELECT tipo_carro FROM x_orden_tipo WHERE tipo_carro IN(" + tc_usar + ") AND id_llamado = " + cod_llamado + " AND area_orden = " + grupo_area + " ORDER BY orden_tipo";
            //}
            //else
            //{
            //    reqSQL = "SELECT tipo_carro FROM x_orden_tipo WHERE tipo_carro IN(" + tc_usar + ") AND id_llamado = " + cod_llamado + " ORDER BY orden_tipo";
            //}

            if (grupo_area != 999)
            {
                reqSQL = "SELECT tipo_carro FROM x_orden_tipo WHERE tipo_carro IN(" + tc_usar + ") AND id_llamado = " + cod_llamado + " AND area_orden = 1 ORDER BY orden_tipo";
            }
            else
            {
                reqSQL = "SELECT tipo_carro FROM x_orden_tipo WHERE tipo_carro IN(" + tc_usar + ") AND id_llamado = " + cod_llamado + " AND area_orden = 999 ORDER BY orden_tipo";
            }



                
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                retornoTipoCarro = new int[myResult.Tables[0].Rows.Count];
                foreach (DataRow ot_carro in myResult.Tables[0].Rows)
                {
                    retornoTipoCarro[i] = Convert.ToInt32(ot_carro["tipo_carro"].ToString());
                    i++;
                }
                return retornoTipoCarro;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        
        public int ObtieneOrdenTipoDistinto(int cod_llamado, string IdCarros)
        {
            CnxBase myBase = new CnxBase();
            ArrayList aOrden = new ArrayList();
            int IdGrupoArea = 0;
            string reqSQL;

            reqSQL = "SELECT id_grupo_area FROM x_orden_tipo_distinto WHERE id_carro IN(" + IdCarros + ") AND id_llamado = " + cod_llamado + " LIMIT 1";

            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                //retornoTipoCarro = new int[myResult.Tables[0].Rows.Count];
                foreach (DataRow ot_carro in myResult.Tables[0].Rows)
                {
                    IdGrupoArea = Convert.ToInt32(ot_carro["id_grupo_area"].ToString());
                }
                return IdGrupoArea;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }



        public int despachoPorTipo(int id_tipo_carro, string id_carros)
        {
            CnxBase myBase = new CnxBase();
            ArrayList aOrden = new ArrayList();
            int idc_retorno = 0;
            string reqSQL = "SELECT id_carro FROM z_carros WHERE id_tipo_carro = " + id_tipo_carro + " AND id_carro IN(" + id_carros + ") AND (estado = 1 OR estado = 5)";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow idc_carro in myResult.Tables[0].Rows)
                {
                    idc_retorno = Convert.ToInt32(idc_carro["id_carro"].ToString());
                }
                return idc_retorno;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }
        #endregion
    }


}