using System;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    public class Util
    {
        public static PointD TransformCoord(PointD p)
        {
            CnxBase myBase = new CnxBase();
            p.X *= -1;
            p.Y *= -1;
            string reqSQL = "SELECT st_astext(st_transform(st_setsrid(st_GeometryFromText('POINT(" + p.ToString() + ")', 4326),4326),32719)) As UTM;";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                string s = (string)myCommand.ExecuteScalar();
                myBase.CloseConnection(myConn);
                p = PointD.FromSQLPoint(s);
            }
            catch
            {
                return new PointD();
            }
            return p;
        }

        public static DataSet Query(string sql)
        {
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                myD4MCnx.setQueryCnx();
                DataSet myResult = myD4MCnx.GetDataSet(sql,myD4MCnx);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString()));
            }
        }
#if DEBUG
        public static void Notify(string str)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "notify "+str;
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
#endif
    }
}
