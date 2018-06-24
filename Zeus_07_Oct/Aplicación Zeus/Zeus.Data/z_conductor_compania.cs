using System;
using Npgsql;

namespace Zeus.Data
{
	public class z_conductor_compania
	{
        public z_conductor_compania()
        { }

        public int GetCountCompania(int id_compania)
        {
            int cant = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT count(id_conductor) from z_conductor_compania where id_compania="+id_compania;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    cant = (int)myReader.GetInt64(0);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return cant;
        }

	}
}
