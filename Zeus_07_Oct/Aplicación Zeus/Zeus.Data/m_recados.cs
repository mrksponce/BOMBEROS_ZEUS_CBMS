using System;
using System.Collections.Generic;
using System.Text;
using Zeus.Data;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Text.RegularExpressions;

namespace Zeus.Data
{
    public class m_recados
    {
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public string Estado { get; set; }
        public string OperadoraCreador { get; set; }
        public string DetalleRecado { get; set; }
        public string Operadoras { get; set; }

        public m_recados()
        { 
            Tipo = "";
            Titulo = "";
            Estado = "";
            OperadoraCreador = "";
            DetalleRecado = "";
            Operadoras = "";
        }

        public int IngresarRecado()
        {
            CnxBase myBase = new CnxBase();
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            int ret = 0;
            string mes = Convert.ToInt32(System.DateTime.Now.Month.ToString()) < 10 ? "0" + System.DateTime.Now.Month.ToString() : System.DateTime.Now.Month.ToString();
            string reqSQL = "INSERT INTO m10_recado_cab (fecha, tipo, titulo, estado, operadora_creador) VALUES ('" + System.DateTime.Now.Day.ToString() + "/" + mes.ToString() + "/" + System.DateTime.Now.Year.ToString() + "', '" + Tipo + "', '" + Titulo + "', '" + Estado + "', '" + OperadoraCreador + "')";
            try
            {
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                string reqSQL2 = "INSERT INTO m10_recado_det (id_recado_cab, detalle_recado, operadoras) VALUES (" + RecuperaUltimoIDRecado() + ", '" + DetalleRecado + "', '" + Operadoras + "')";
                NpgsqlCommand myCommand2 = new NpgsqlCommand(reqSQL2, myConn);
                ret = myCommand2.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public int ActualizarRecado(int idRecado)
        {
            CnxBase myBase = new CnxBase();
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            int ret = 0;
            string reqSQL = "UPDATE m10_recado_cab SET tipo = '" + Tipo + "', titulo = '" + Titulo + "', estado = '" + Estado + "', operadora_creador = " + OperadoraCreador + " WHERE id_recado_cab = " + idRecado + "";
            try
            {
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                string reqSQL2 = "UPDATE m10_recado_det SET detalle_recado = '" + DetalleRecado + "', operadoras = '"+Operadoras+"' WHERE id_recado_cab = " + idRecado + "";
                NpgsqlCommand myCommand2 = new NpgsqlCommand(reqSQL2, myConn);
                ret = myCommand2.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public int RecuperaUltimoIDRecado()
        {
            CnxBase myBase = new CnxBase();
            int idUltimo = 0;
            string reqSQL = "SELECT max(id_recado_cab) as recado FROM m10_recado_cab";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r in myResult.Tables[0].Rows)
                {
                    if (r["recado"].ToString() == "")
                    {
                        idUltimo = 1;
                    }
                    else
                    {
                        idUltimo = Convert.ToInt32(r["recado"].ToString());
                    }
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return idUltimo;
        }

        // 

        public DataSet GetRecados()
        {
            CnxBase myBase = new CnxBase();
            DataSet myResult = new DataSet();
            string reqSQL = "select * from m10_recado_cab cab left join m10_recado_det det on cab.id_recado_cab = det.id_recado_cab";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                myResult = myD4MCnx.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myResult;
        }

        public DataSet GetRecadosProID(int IdRecado)
        {
            CnxBase myBase = new CnxBase();
            DataSet myResult = new DataSet();
            string reqSQL = "SELECT * FROM m10_recado_cab cab LEFT JOIN m10_recado_det det ON cab.id_recado_cab = det.id_recado_cab WHERE cab.id_recado_cab = " + IdRecado;
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                myResult = myD4MCnx.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myResult;
        }

        public DataSet GetResuladoFiltro(string fechaDesde, string fechaHasta, bool pendientes, bool recados, bool novedades, bool vigente, bool cerrado)
        {
            CnxBase myBase = new CnxBase();
            DataSet myResult = new DataSet();

            string filtroUno = "";

            string reqSQL = "select * from m10_recado_cab cab ";
            reqSQL += "left join m10_recado_det det on cab.id_recado_cab = det.id_recado_cab";
            reqSQL += " where ";

            if (pendientes)
            {
                filtroUno += "'Pendiente'" + ",";
            }

            if (recados)
            {
                filtroUno += "'Recado'" + ",";
            }

            if (novedades)
            {
                filtroUno += "'Novedad'" + ",";
            }

            filtroUno += "#";
            string filtroDos = "";
            if (vigente)
            {
                filtroDos += "'Vigente'" + ",";
            }

            if (cerrado)
            {
                filtroDos += "'Cerrado'" + ",";
            }
            filtroDos += "#";

            if (filtroUno != "#")
            {
                reqSQL += "cab.tipo in (" + Regex.Replace(filtroUno, ",#", "") + ")";
                reqSQL += " AND ";
            }
            if (filtroDos != "#")
            {
                reqSQL += "cab.estado in (" + Regex.Replace(filtroDos, ",#", "") + ")";
                reqSQL += " AND ";
            }
            reqSQL += "(cab.fecha::timestamp between '" + fechaDesde + "' and '" + fechaHasta + "')";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                myResult = myD4MCnx.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myResult;
        }
        
    }
}
