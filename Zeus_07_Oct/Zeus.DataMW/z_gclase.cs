using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Zeus.Data
{
    public class z_gclase
    {
        public string GetClase(int id)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT clase FROM z_gclase WHERE id=" + id;
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
