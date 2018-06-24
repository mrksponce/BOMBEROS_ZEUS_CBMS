using System;
using System.Data;

namespace Zeus.Data
{
    public class est_tablas
    {
        public DataSet GetTablas()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select nombre, obj_description((select oid from pg_class where relname=nombre), 'pg_class') as descripcion from est_tablas";
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

        public DataSet GetColumnas(string relname)
        {
            string reqSQL = "SELECT c.oid, a.attname as nombre, col_description(c.oid, a.attnum) as descripcion FROM pg_class c, pg_attribute a, pg_type t WHERE c.relname ='" + relname + "'  AND a.attnum > 0 AND a.attrelid = c.oid AND a.atttypid = t.oid";
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

        public DataSet GetDistincts(string tabla, string columna)
        {
            string reqSQL = "SELECT DISTINCT " + columna + " as distintos FROM " + tabla;
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
    }
}
