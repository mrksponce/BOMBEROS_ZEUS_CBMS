using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    public class e171924r
    {
        public int GetRecno(string nombre_calle)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT Recno FROM e171924r WHERE nombre='" + nombre_calle + "'";
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
    }
}
