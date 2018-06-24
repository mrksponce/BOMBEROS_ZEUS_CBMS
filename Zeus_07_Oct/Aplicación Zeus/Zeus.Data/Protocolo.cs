using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Zeus.Data
{
    public class Protocolo
    {
        public Protocolo()
        { 
        
        }

        public int Update(string tipo, string descripcion, string activo)
        {
            CnxBase myBase = new CnxBase();
            int resultado = 0;
            string reqSQL = "UPDATE m0009_protocolos SET  tipo = '"+tipo+"', descripcion = '"+descripcion+"', activo = '"+activo+"' WHERE tipo = '"+tipo+"'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                resultado = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return resultado;
        }

        public DataSet GetProtocolo()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT tipo, descripcion, activo FROM m0009_protocolos";
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

        public DataSet GetProtocoloPorTipo(string tipo)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT tipo, descripcion, activo FROM m0009_protocolos WHERE tipo = '"+tipo+"'";
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

        public DataSet GetProtocolos()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT tipo, descripcion FROM m0009_protocolos";
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
