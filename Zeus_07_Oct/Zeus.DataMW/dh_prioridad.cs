using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    public class dh_prioridad
    {
        public DataSet GetDataSet(int id_area)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_prioridad WHERE id_area=" + id_area + " order by orden_prioridad";
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

        public DataSet GetDataSet()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM dh_prioridad order by orden_prioridad";
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

        public void Update(int id_area, int[] prioridades)
        {
            string sqlBase = "update dh_prioridad set despacho_herramienta={0} where id_area={1} and orden_prioridad={2};";
            string sql = "begin;";
            for (int i = 0; i < prioridades.Length; i++)
            {
                sql += string.Format(sqlBase, prioridades[i], id_area, i+1);
            }
            sql += "commit;";
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(sql, myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString()));
            }
        }
    }
}
