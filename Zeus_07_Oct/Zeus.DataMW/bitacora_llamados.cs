/********************************
 *
 * Clases generadas por D4Modelizer
 * (c)2004 DORLAC S.T.
 * http://www.d4modelizer.com
 * Stephane Dorlac
 * support@d4modelizer.com
 *
 * ******************************/
using System;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    /// <summary>
    /// bitacora_llamados
    /// </summary>
    public class bitacora_llamados
    {

        #region ***** Campos y propiedades *****

        private decimal coordenadaX;

        public decimal CoordenadaX
        {
            get { return coordenadaX; }
            set { coordenadaX = value; }
        }
        private decimal coordenadaY;

        public decimal CoordenadaY
        {
            get { return coordenadaY; }
            set { coordenadaY = value; }
        }

        private System.Int32 _id_evento;
        public System.Int32 id_evento
        {
            get
            {
                return _id_evento;
            }
            set
            {
                _id_evento = value;
            }
        }

        private System.DateTime _fecha;
        public System.DateTime fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        private System.String _evento;
        public System.String evento
        {
            get
            {
                return _evento;
            }
            set
            {
                _evento = value;
            }
        }

        private System.Int32 _id_operadora;
        public System.Int32 id_operadora
        {
            get
            {
                return _id_operadora;
            }
            set
            {
                _id_operadora = value;
            }
        }

        private System.Int32 _id_carro;
        public System.Int32 id_carro
        {
            get
            {
                return _id_carro;
            }
            set
            {
                _id_carro = value;
            }
        }

        private int _id_expediente;

        public int id_expediente
        {
            get { return _id_expediente; }
            set { _id_expediente = value; }
        }

        private string _tipo;

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        #endregion

        /// <summary>
        /// bitacora_llamados
        /// </summary>
        public bitacora_llamados()
        {
        }


        /// <summary>
        /// bitacora_llamados
        /// </summary>
        public bitacora_llamados(System.Int32 id_evento, System.DateTime fecha, System.String evento, System.Int32 id_operadora, System.Int32 id_carro, int id_expediente, string tipo)
        {
            this.id_evento = id_evento;
            this.fecha = fecha;
            this.evento = evento;
            this.id_operadora = id_operadora;
            this.id_carro = id_carro;
            this.id_expediente = id_expediente;
            this.tipo = tipo;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(bitacora_llamados mybitacora_llamados, bool fecha_servidor)
        {
            CnxBase myBase = new CnxBase();
            if (mybitacora_llamados.id_expediente > 0)
            {
                /* MODIFICACIONES DE MARCOS PONCE --> DESDE ABAJO */
                
                if (mybitacora_llamados.evento == "6-3")
                {
                    // Consultar por el expediente
                    string SQL_coordenadas = "SELECT \"puntoX\",\"puntoY\" FROM e_expedientes WHERE id_expediente = " + mybitacora_llamados.id_expediente;
                    try
                    {
                        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                        DataSet ds_coor_emergencia = new DataSet();
                        NpgsqlDataAdapter da_coor_emergencia = new NpgsqlDataAdapter(SQL_coordenadas, myConn);
                        da_coor_emergencia.Fill(ds_coor_emergencia);
                        foreach (DataRow r_coor_emergencia in ds_coor_emergencia.Tables[0].Rows)
                        {
                            CoordenadaX = Convert.ToDecimal(r_coor_emergencia["puntoX"].ToString());
                            CoordenadaY = Convert.ToDecimal(r_coor_emergencia["puntoY"].ToString());
                        }

                        string SQL_update_coordenadas_carros = "UPDATE z_carros SET carro_x = " + Convert.ToInt32(CoordenadaX) + ", carro_y = " + Convert.ToInt32(CoordenadaY) + " WHERE id_carro = " + mybitacora_llamados.id_carro;
                        try
                        {
                            NpgsqlCommand myCommand = new NpgsqlCommand(SQL_update_coordenadas_carros, myConn);
                            myCommand.ExecuteNonQuery();
                            myBase.CloseConnection(myConn);
                        }
                        catch (Exception myErr)
                        {
                            throw (new Exception(myErr.ToString() + SQL_update_coordenadas_carros));
                        }
                    }
                    catch (Exception myErr)
                    {
                        throw (new Exception(myErr.ToString() + SQL_coordenadas));
                    }

                    // Insertar en la tabla carros las coordenadas de la emergencia del expediente.
                }
            }

            //CnxBase myBase = new CnxBase();

            /* MODIFICACIONES DE MARCOS PONCE --> DESDE ARRIBA */

            string reqSQL = "INSERT INTO bitacora_llamados (fecha,evento,id_operadora,id_carro, id_expediente, tipo) VALUES ('" + (fecha_servidor ? "now" : mybitacora_llamados.fecha.ToString()) + "','" + mybitacora_llamados.evento + "'," + mybitacora_llamados.id_operadora + "," + mybitacora_llamados.id_carro + "," + mybitacora_llamados.id_expediente + ",'" + mybitacora_llamados.tipo + "')";
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

        /// <summary>
        /// delete record from datasource
        /// </summary>
        /// <param name="myID"></param>
        public void Delete(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM bitacora_llamados WHERE (id_evento = " + myID + ")", myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString()));
            }
        }

        /// <summary>
        /// modify a record
        /// </summary>
        public void Update(bitacora_llamados mybitacora_llamados)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE bitacora_llamados SET id_evento=" + mybitacora_llamados.id_evento + ",fecha='" + mybitacora_llamados.fecha + "',evento='" + mybitacora_llamados.evento + "',id_operadora=" + mybitacora_llamados.id_operadora + ",id_carro=" + mybitacora_llamados.id_carro + ",tipo='" + mybitacora_llamados.tipo + "' WHERE (id_evento=" + mybitacora_llamados.id_evento + ")";
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

        /// <summary>
        /// get an instance of object
        /// </summary>
        /// <param name="myID"></param>
        public bitacora_llamados getObjectbitacora_llamados(System.Int32 myID)
        {
            bitacora_llamados mybitacora_llamados = new bitacora_llamados();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_evento,fecha,evento,id_operadora,id_carro, id_expediente, tipo FROM bitacora_llamados WHERE (id_evento=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mybitacora_llamados.id_evento = Convert.ToInt32(myReader[0]);
                    mybitacora_llamados.fecha = Convert.ToDateTime(myReader[1]);
                    mybitacora_llamados.evento = myReader[2].ToString();
                    mybitacora_llamados.id_operadora = Convert.ToInt32(myReader[3]);
                    mybitacora_llamados.id_carro = Convert.ToInt32(myReader[4]);
                    mybitacora_llamados.id_expediente = Convert.ToInt32(myReader[5]);
                    mybitacora_llamados.tipo = Convert.ToString(myReader[6]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mybitacora_llamados;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getbitacora_llamados()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM bitacora_llamados";
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

        #endregion

        public DataSet Getbitacora_llamados_expediente(int id_expediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT fecha, z_locutores.login, z_carros.nombre, bitacora_llamados.evento, bitacora_llamados.tipo, z_carros.id_carro FROM bitacora_llamados left join z_carros on bitacora_llamados.id_carro=z_carros.id_carro join z_locutores on bitacora_llamados.id_operadora=z_locutores.id_locutor where bitacora_llamados.id_expediente=" + id_expediente + " order by fecha desc";
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

        public DataSet Getbitacora_llamados_expediente_limit(int id_expediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT fecha, z_locutores.login, z_carros.nombre, bitacora_llamados.evento, tipo FROM bitacora_llamados left join z_carros on bitacora_llamados.id_carro=z_carros.id_carro join z_locutores on bitacora_llamados.id_operadora=z_locutores.id_locutor where bitacora_llamados.id_expediente=" + id_expediente + " order by fecha desc limit 100";
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

        public DataSet Getbitacora_llamados_carro(int id_carro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT fecha, z_locutores.login, z_carros.nombre, evento FROM bitacora_llamados, z_carros, z_locutores where bitacora_llamados.id_carro=" + id_carro + " and bitacora_llamados.id_operadora=z_locutores.id_locutor and bitacora_llamados.id_carro=z_carros.id_carro" + " order by fecha desc";
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

        public DataSet Getbitacora_llamados_carro_limit(int id_carro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT fecha, z_locutores.login, z_carros.nombre, bitacora_llamados.evento FROM bitacora_llamados, z_carros, z_locutores where bitacora_llamados.id_carro=" + id_carro + " and bitacora_llamados.id_operadora=z_locutores.id_locutor and bitacora_llamados.id_carro=z_carros.id_carro" + " order by fecha desc limit 100";
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

        public DataSet GetCarrosExpedientes24Horas(DateTime desde, DateTime hasta)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select distinct e_expedientes.id_expediente, nombre, c6_0, c6_3 from e_expedientes, z_carros," +
                "(select id_carro, fecha as c6_0 from bitacora_llamados where fecha>='" + desde.ToString() + "' and fecha<='" + hasta.ToString() + "' and evento like '6-0%') as t6_0," +
                "(select id_carro, fecha as c6_3 from bitacora_llamados where fecha>='" + desde.ToString() + "' and fecha<='" + hasta.ToString() + "' and evento = '6-3') as t6_3" +

                " where (z_carros.id_carro=t6_0.id_carro or z_carros.id_carro=t6_3.id_carro) " +
                                " and t6_0.id_carro=t6_3.id_carro";


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

        public void ActualizarClave(int idExpediente, int idCarro, string seis_cero, string seis_tres, string seis_siete, string seis_ocho, string seis_nueve, string seis_dies)
        {
                CnxBase myBase = new CnxBase();
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                bitacora_llamados bll = new bitacora_llamados();
                if (seis_cero != "")
                {
                    if (bll.ExistenciaCarroBitacoraLlamados(idCarro, idExpediente, "6-0"))
                    {
                        string reqSQL = "update bitacora_llamados set fecha = '" + seis_cero + "' where id_expediente = " + idExpediente + " and id_carro = " + idCarro + " and evento like '%6-0%'";
                        try
                        {
                            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                            myCommand.ExecuteNonQuery();

                        }
                        catch (Exception myErr)
                        {
                            throw (new Exception(myErr.ToString() + reqSQL));
                        }
                    }
                    else
                    {
                        InsertarEventoBLL(seis_cero, "6-0", DatosLogin.LoginUsuario, idCarro, idExpediente, "carro");
                    }
                }

                if (seis_tres != "")
                {
                    if (bll.ExistenciaCarroBitacoraLlamados(idCarro, idExpediente, "6-3"))
                    {
                        string reqSQL = "update bitacora_llamados set fecha = '" + seis_tres + "' where id_expediente = " + idExpediente + " and id_carro = " + idCarro + " and evento like '%6-3%'";
                        try
                        {

                            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception myErr)
                        {
                            throw (new Exception(myErr.ToString() + reqSQL));
                        }
                    }
                    else 
                    {
                        InsertarEventoBLL(seis_tres, "6-3", DatosLogin.LoginUsuario, idCarro, idExpediente, "carro");
                    }
                }

                if (seis_siete != "")
                {
                    if (bll.ExistenciaCarroBitacoraLlamados(idCarro, idExpediente, "6-7"))
                    {
                        string reqSQL = "update bitacora_llamados set fecha = '" + seis_siete + "' where id_expediente = " + idExpediente + " and id_carro = " + idCarro + " and evento like '%6-7%'";
                        try
                        {

                            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception myErr)
                        {
                            throw (new Exception(myErr.ToString() + reqSQL));
                        }
                    }
                    else
                    {
                        InsertarEventoBLL(seis_siete, "6-7", DatosLogin.LoginUsuario, idCarro, idExpediente, "carro");
                    }

                    
                }

                if (seis_ocho != "")
                {
                    if (bll.ExistenciaCarroBitacoraLlamados(idCarro, idExpediente, "6-8"))
                    {
                        string reqSQL = "update bitacora_llamados set fecha = '" + seis_ocho + "' where id_expediente = " + idExpediente + " and id_carro = " + idCarro + " and evento like '%6-8%'";
                        try
                        {

                            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception myErr)
                        {
                            throw (new Exception(myErr.ToString() + reqSQL));
                        }
                    }
                    else
                    {
                        InsertarEventoBLL(seis_ocho, "6-8", DatosLogin.LoginUsuario, idCarro, idExpediente, "carro");
                    }
                }

                if (seis_nueve != "")
                {
                    if (bll.ExistenciaCarroBitacoraLlamados(idCarro, idExpediente, "6-9"))
                    {
                        string reqSQL = "update bitacora_llamados set fecha = '" + seis_nueve + "' where id_expediente = " + idExpediente + " and id_carro = " + idCarro + " and evento like '%6-9%'";
                        try
                        {

                            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception myErr)
                        {
                            throw (new Exception(myErr.ToString() + reqSQL));
                        }
                    }
                    else
                    {
                        InsertarEventoBLL(seis_nueve, "6-9", DatosLogin.LoginUsuario, idCarro, idExpediente, "carro");
                    }
                    
                    
                }

                if (seis_dies != "")
                {
                    if (bll.ExistenciaCarroBitacoraLlamados(idCarro, idExpediente, "6-10"))
                    {
                        string reqSQL = "update bitacora_llamados set fecha = '" + seis_dies + "' where id_expediente = " + idExpediente + " and id_carro = " + idCarro + " and evento like '%6-10%'";
                        try
                        {

                            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                            myCommand.ExecuteNonQuery();
                        }
                        catch (Exception myErr)
                        {
                            throw (new Exception(myErr.ToString() + reqSQL));
                        }
                    }
                    else
                    {
                        InsertarEventoBLL(seis_dies, "6-10", DatosLogin.LoginUsuario, idCarro, idExpediente, "carro");
                    }

                    
                }

                myBase.CloseConnection(myConn);
        }

        public string RecuperarFechaExpediente(string idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string fecha = "";
            string reqSQL = "select fecha from e_expedientes where id_expediente = " + Convert.ToInt32(idExpediente);
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow row in myResult.Tables[0].Rows) 
                {
                    fecha = row["fecha"].ToString();
                }
                return fecha;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public bool ExistenciaCarroBitacoraLlamados(int id_carro, int id_expediente, string evento)
        {
            //
            CnxBase myBase = new CnxBase();
            bool existe = false;
            string reqSQL = "select fecha from bitacora_llamados where id_carro = "+id_carro+" and id_expediente = "+id_expediente+" and evento like '%"+evento+"%'";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                if(myResult.Tables[0].Rows.Count > 0)
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }                
                return existe;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public void InsertarEventoBLL(string fecha, string evento, int operadora, int carro, int expediente, string tipo)
        {
            //
            CnxBase myBase = new CnxBase();
            bool existe = false;
            string reqSQL = "INSERT INTO bitacora_llamados (fecha, evento, id_operadora, id_carro, id_expediente, tipo) VALUES ('"+fecha+"', '"+evento+"', "+Convert.ToInt32(operadora)+", "+Convert.ToInt32(carro)+", "+Convert.ToInt32(expediente)+", '"+tipo+"')";
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

        //public DataSet GetCarrosExpedientes24Horas(int id_expediente)
        //{
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "select distinct e_expedientes.id_expediente, nombre, c6_0, c6_3 from e_expedientes, z_carros," +
        //        "(select id_carro, fecha as c6_0 from bitacora_llamados where fecha>='" + desde.ToString() + "' and fecha<='" + hasta.ToString() + "' and evento like '6-0%') as t6_0," +
        //        "(select id_carro, fecha as c6_3 from bitacora_llamados where fecha>='" + desde.ToString() + "' and fecha<='" + hasta.ToString() + "' and evento = '6-3') as t6_3" +

        //        " where (z_carros.id_carro=t6_0.id_carro or z_carros.id_carro=t6_3.id_carro)"+
        //        " and t6_0.id_carro=t6_3.id_carro";

        //    try
        //    {
        //        CnxBase myD4MCnx = new CnxBase();
        //        DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
        //        return myResult;
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //}

    }


}
