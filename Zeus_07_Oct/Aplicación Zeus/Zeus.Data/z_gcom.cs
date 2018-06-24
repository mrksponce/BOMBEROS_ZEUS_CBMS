using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Zeus.Data
{
    public class z_gcom
    {
        public int GetID(string nombre_comuna)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT ID FROM z_gcom WHERE comuna='" + nombre_comuna + "'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    return Convert.ToInt32(myReader[0]);
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return 0;
        }

        public string GetComuna(int id)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT comuna FROM z_gcom WHERE id=" + id;
            NpgsqlConnection myConn=null;
            try
            {
                myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    return myReader[0].ToString();
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            finally
            {
                myConn.Close();
            }
            return "";

        }
    }
}
