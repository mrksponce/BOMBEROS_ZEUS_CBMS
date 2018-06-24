using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Zeus.Data
{
    public class z_gsl
    {
        public DataSet Get_gsl(int id1, int id2)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_gsl where GSL_2="+id1+" and GSL_3="+id2;
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

        public DataSet Get_gsl(int id1, int id2, List<int> comunas)
        {
            string l_comunas = string.Join(",", comunas.ConvertAll<string>(delegate(int x) { return x.ToString(); }).ToArray());
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_gsl where GSL_2=" + id1 + " and GSL_3=" + id2 + " and GSL_5 in (" + l_comunas + ")";
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
