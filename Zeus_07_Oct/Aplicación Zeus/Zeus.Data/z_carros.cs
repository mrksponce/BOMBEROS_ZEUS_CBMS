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
using System.Drawing;
using System.IO;
using Npgsql;
using NpgsqlTypes;
using System.Collections;
using System.Collections.Generic;



namespace Zeus.Data
{
    /// <summary>
    /// z_carros
    /// </summary>
    public class z_carros
    {

        

        #region ***** Campos y propiedades *****

        public string Evento { get; set; }
        public string Observacion2 { get; set;}
        public string OpObservacion2 { get; set; }

        private string coordenadas_carro;

        public string Coordenadas_carro
        {
            get { return coordenadas_carro; }
            set { coordenadas_carro = value; }
        }

        public bool Carros_011 { get; set; }

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

        private System.String _nombre;
        public System.String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        private System.Int32 _id_tipo_carro;
        public System.Int32 id_tipo_carro
        {
            get
            {
                return _id_tipo_carro;
            }
            set
            {
                _id_tipo_carro = value;
            }
        }

        private System.Int32 _id_compania;
        public System.Int32 id_compania
        {
            get
            {
                return _id_compania;
            }
            set
            {
                _id_compania = value;
            }
        }

        private System.Int32 _estado;
        public System.Int32 estado
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
            }
        }

        private int _id_tipo_carro_alternativo;

        public int id_tipo_alternativo
        {
            get { return _id_tipo_carro_alternativo; }
            set { _id_tipo_carro_alternativo = value; }
        }

        private int _id_conductor;

        public int id_conductor
        {
            get { return _id_conductor; }
            set { _id_conductor = value; }
        }

        private int _foto;

        public int foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        private DateTime _fecha_fuera_servicio;

        public DateTime fecha_fuera_servicio
        {
            get { return _fecha_fuera_servicio; }
            set { _fecha_fuera_servicio = value; }
        }
        
        private string _motivo_fuera_servicio;
        public string motivo_fuera_servicio
        {
            get { return _motivo_fuera_servicio; }
            set { _motivo_fuera_servicio = value; }
        }

        private int _id_compania_orig;
        public int id_compania_orig
        {
            get { return _id_compania_orig; }
            set { _id_compania_orig = value; }
        }

        private System.Boolean _periferia;
        public System.Boolean periferia
        {
            get { return _periferia; }
            set { _periferia = value; }
        }


        private string _ubicacion_613;
        public string ubicacion_613
        {
            get { return _ubicacion_613; }
            set { _ubicacion_613 = value; }
        }


        //#f
        private System.String _urlimagen;
        public System.String urlimagen
        {
            get
            {
                return _urlimagen;
            }
            set
            {
                _urlimagen = value;
            }
        }



        #endregion

        /// <summary>
        /// z_carros
        /// </summary>
        public z_carros()
        {
        }


        /// <summary>
        /// z_carros
        /// </summary>
        public z_carros(System.Int32 id_carro, System.String nombre, System.Int32 id_tipo_carro, System.Int32 id_compania, System.Int32 estado, int id_tipo_carro_alternativo, System.Boolean periferia, System.String ubicacion_613)
        {
            this.id_carro = id_carro;
            this.nombre = nombre;
            this.id_tipo_carro = id_tipo_carro;
            this.id_compania = id_compania;
            this.estado = estado;
            this.id_tipo_alternativo = id_tipo_carro_alternativo;
            this.periferia = periferia;
            this.ubicacion_613 = ubicacion_613;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_carros(z_carros myz_carros, string foto)
        {
            CnxBase myBase = new CnxBase();
            //string reqSQL = "INSERT INTO z_carros (nombre,id_tipo_carro,id_compania,estado,id_compania_orig) VALUES ('" + myz_carros.nombre + "'," + myz_carros.id_tipo_carro + "," + myz_carros.id_compania_orig + "," + myz_carros.estado + "," + myz_carros.id_compania_orig + ")";
            //#f
            string reqSQL = "INSERT INTO z_carros (nombre,id_tipo_carro,id_compania,estado,id_compania_orig, urlimagen) VALUES ('" + myz_carros.nombre + "'," + myz_carros.id_tipo_carro + "," + myz_carros.id_compania_orig + "," + myz_carros.estado + "," + myz_carros.id_compania_orig + ", '" + myz_carros.urlimagen + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                if (foto != null)
                {
                    NpgsqlTransaction t = myConn.BeginTransaction();
                    LargeObjectManager lbm = new LargeObjectManager(myConn);

                    int noid = lbm.Create(LargeObjectManager.READWRITE);
                    LargeObject lo = lbm.Open(noid, LargeObjectManager.READWRITE);

                    FileStream fs = File.OpenRead(foto);

                    byte[] buf = new byte[fs.Length];
                    fs.Read(buf, 0, (int)fs.Length);

                    lo.Write(buf);
                    lo.Close();
                    t.Commit();

                    reqSQL = "INSERT INTO z_carros (nombre,id_tipo_carro,id_compania,estado, foto) VALUES ('" + myz_carros.nombre + "'," + myz_carros.id_tipo_carro + "," + myz_carros.id_compania + "," + myz_carros.estado + "," + noid + ")";

                }
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
        public void deletez_carros(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_carros WHERE (id_carro = " + myID + ")", myConn);
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
        public void modifyz_carros(z_carros myz_carros, string foto)
        {
            CnxBase myBase = new CnxBase();
            //string reqSQL = "UPDATE z_carros SET id_carro=" + myz_carros.id_carro + ",nombre='" + myz_carros.nombre + "',id_tipo_carro=" + myz_carros.id_tipo_carro + ",id_compania=" + myz_carros.id_compania + ",estado=" + myz_carros.estado + ", id_tipo_alternativo=" + myz_carros.id_tipo_alternativo + ", id_conductor=" + myz_carros.id_conductor + ", fecha_fuera_servicio='" + myz_carros.fecha_fuera_servicio.ToString() + "', observacion2='" + myz_carros.motivo_fuera_servicio + "',id_compania_orig=" + myz_carros.id_compania_orig + " WHERE (id_carro=" + myz_carros.id_carro + ")";
            //#f
            string reqSQL = "UPDATE z_carros SET id_carro=" + myz_carros.id_carro + ",nombre='" + myz_carros.nombre + "',id_tipo_carro=" + myz_carros.id_tipo_carro + ",id_compania=" + myz_carros.id_compania + ",estado=" + myz_carros.estado + ", id_tipo_alternativo=" + myz_carros.id_tipo_alternativo + ", id_conductor=" + myz_carros.id_conductor + ", fecha_fuera_servicio='" + myz_carros.fecha_fuera_servicio.ToString() + "',id_compania_orig=" + myz_carros.id_compania_orig + ",urlimagen='" + myz_carros.urlimagen + "' WHERE (id_carro=" + myz_carros.id_carro + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                if (foto != null)
                {
                    // agregar nuevo
                    NpgsqlTransaction t = myConn.BeginTransaction();
                    LargeObjectManager lbm = new LargeObjectManager(myConn);

                    int noid = lbm.Create(LargeObjectManager.READWRITE);
                    LargeObject lo = lbm.Open(noid, LargeObjectManager.READWRITE);
                    if (myz_carros.foto != 0)
                    {
                        lbm.Unlink(myz_carros.foto);
                    }
                    FileStream fs = File.OpenRead(foto);

                    byte[] buf = new byte[fs.Length];
                    fs.Read(buf, 0, (int)fs.Length);

                    lo.Write(buf);
                    lo.Close();
                    t.Commit();

                    //reqSQL = "UPDATE z_carros SET id_carro=" + myz_carros.id_carro + ",nombre='" + myz_carros.nombre + "',id_tipo_carro=" + myz_carros.id_tipo_carro + ",id_compania=" + myz_carros.id_compania + ",estado=" + myz_carros.estado + ", id_tipo_alternativo=" + myz_carros.id_tipo_alternativo + ", id_conductor=" + myz_carros.id_conductor + ",foto=" + noid + ",observacion2='" + myz_carros.motivo_fuera_servicio + "' WHERE (id_carro=" + myz_carros.id_carro + ")";
                    //#f
                    reqSQL = "UPDATE z_carros SET id_carro=" + myz_carros.id_carro + ",nombre='" + myz_carros.nombre + "',id_tipo_carro=" + myz_carros.id_tipo_carro + ",id_compania=" + myz_carros.id_compania + ",estado=" + myz_carros.estado + ", id_tipo_alternativo=" + myz_carros.id_tipo_alternativo + ", id_conductor=" + myz_carros.id_conductor + ",foto=" + noid + " WHERE (id_carro=" + myz_carros.id_carro + ")";
                }
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public void modifyz_carros(z_carros myz_carros)
        {
            CnxBase myBase = new CnxBase();
            //string reqSQL = "UPDATE z_carros SET id_carro=" + myz_carros.id_carro + ",nombre='" + myz_carros.nombre + "',id_tipo_carro=" + myz_carros.id_tipo_carro + ",id_compania=" + myz_carros.id_compania + ",estado=" + myz_carros.estado + ", id_tipo_alternativo=" + myz_carros.id_tipo_alternativo + ", id_conductor=" + myz_carros.id_conductor + ", fecha_fuera_servicio='" + myz_carros.fecha_fuera_servicio.ToString() + "', observacion2='" + myz_carros.motivo_fuera_servicio + "',id_compania_orig=" + myz_carros.id_compania_orig + " WHERE (id_carro=" + myz_carros.id_carro + ")";
              string reqSQL = "UPDATE z_carros SET id_carro=" + myz_carros.id_carro + ",nombre='" + myz_carros.nombre + "',id_tipo_carro=" + myz_carros.id_tipo_carro + ",id_compania=" + myz_carros.id_compania + ",estado=" + myz_carros.estado + ", id_tipo_alternativo=" + myz_carros.id_tipo_alternativo + ", id_conductor=" + myz_carros.id_conductor + ", fecha_fuera_servicio='" + myz_carros.fecha_fuera_servicio.ToString() + "', observacion2='" + myz_carros.motivo_fuera_servicio + "',id_compania_orig=" + myz_carros.id_compania_orig + " WHERE (id_carro=" + myz_carros.id_carro + ")";
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
        //public z_carros getObjectz_carros(System.Int32 myID)
        //{
        //    z_carros myz_carros = new z_carros();
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011 FROM z_carros WHERE (id_carro=" + myID + ")";
        //    try
        //    {
        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //        NpgsqlDataReader myReader = myCommand.ExecuteReader();
        //        if (myReader.Read())
        //        {
        //            myz_carros.id_carro = Convert.ToInt32(myReader[0]);
        //            myz_carros.nombre = myReader[1].ToString();
        //            myz_carros.id_tipo_carro = Convert.ToInt32(myReader[2]);
        //            myz_carros.id_compania = Convert.ToInt32(myReader[3]);
        //            myz_carros.estado = Convert.ToInt32(myReader[4]);
        //            myz_carros.id_tipo_alternativo = Convert.ToInt32(myReader[5]);
        //            myz_carros.id_conductor = Convert.ToInt32(myReader[6]);
        //            myz_carros.foto = myReader[7] == DBNull.Value ? 0 : Convert.ToInt32(myReader[7]);
        //            myz_carros.fecha_fuera_servicio = Convert.ToDateTime(myReader[8]);
        //            myz_carros.motivo_fuera_servicio = myReader[9].ToString();
        //            myz_carros.id_compania_orig = Convert.ToInt32(myReader[10]);
        //            myz_carros.periferia = Convert.ToBoolean(myReader[11]);
        //            myz_carros.Carros_011 = myReader[12] == null ? Convert.ToBoolean("false") : Convert.ToBoolean(myReader[12]);
        //        }
        //        myBase.CloseConnection(myConn);
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //    return myz_carros;
        //}

        public z_carros getObjectz_carros(System.Int32 myID)
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011, evento, observacion2, op_observacion2, ubicacion_613 FROM z_carros WHERE (id_carro=" + myID + ")";
            //#f
            string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011, evento, observacion2, op_observacion2, ubicacion_613, urlimagen FROM z_carros WHERE (id_carro=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_carros.id_carro = Convert.ToInt32(myReader[0]);
                    myz_carros.nombre = myReader[1].ToString();
                    myz_carros.id_tipo_carro = Convert.ToInt32(myReader[2]);
                    myz_carros.id_compania = Convert.ToInt32(myReader[3]);
                    myz_carros.estado = Convert.ToInt32(myReader[4]);
                    myz_carros.id_tipo_alternativo = Convert.ToInt32(myReader[5]);
                    myz_carros.id_conductor = Convert.ToInt32(myReader[6]);
                    myz_carros.foto = myReader[7] == DBNull.Value ? 0 : Convert.ToInt32(myReader[7]);
                    myz_carros.fecha_fuera_servicio = Convert.ToDateTime(myReader[8]);
                    myz_carros.motivo_fuera_servicio = myReader[9].ToString();
                    myz_carros.id_compania_orig = Convert.ToInt32(myReader[10]);
                    myz_carros.periferia = Convert.ToBoolean(myReader[11]);
                    myz_carros.Carros_011 = myReader[12] == null ? Convert.ToBoolean("false") : Convert.ToBoolean(myReader[12]);
                    myz_carros.Evento = myReader[13].ToString();
                    myz_carros.Observacion2 = myReader[14].ToString();
                    myz_carros.OpObservacion2 = myReader[15].ToString();
                    myz_carros.ubicacion_613 = myReader[16].ToString();
                    //#f
                    myz_carros.urlimagen = myReader[17].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_carros;
        }

        //### Obtiene las coordenadas de un Carro
        //public z_carroXY getObjectz_carros(System.Int32 myID)
        //{
        //    z_carros myz_carros = new z_carros();
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011, evento, observacion2, op_observacion2 FROM z_carros WHERE (id_carro=" + myID + ")";
        //    try
        //    {
        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //        NpgsqlDataReader myReader = myCommand.ExecuteReader();
        //        if (myReader.Read())
        //        {
        //            myz_carros.id_carro = Convert.ToInt32(myReader[0]);
        //            myz_carros.nombre = myReader[1].ToString();
        //            myz_carros.id_tipo_carro = Convert.ToInt32(myReader[2]);
        //            myz_carros.id_compania = Convert.ToInt32(myReader[3]);
        //            myz_carros.estado = Convert.ToInt32(myReader[4]);
        //            myz_carros.id_tipo_alternativo = Convert.ToInt32(myReader[5]);
        //            myz_carros.id_conductor = Convert.ToInt32(myReader[6]);
        //            myz_carros.foto = myReader[7] == DBNull.Value ? 0 : Convert.ToInt32(myReader[7]);
        //            myz_carros.fecha_fuera_servicio = Convert.ToDateTime(myReader[8]);
        //            myz_carros.motivo_fuera_servicio = myReader[9].ToString();
        //            myz_carros.id_compania_orig = Convert.ToInt32(myReader[10]);
        //            myz_carros.periferia = Convert.ToBoolean(myReader[11]);
        //            myz_carros.Carros_011 = myReader[12] == null ? Convert.ToBoolean("false") : Convert.ToBoolean(myReader[12]);
        //            myz_carros.Evento = myReader[13].ToString();
        //            myz_carros.Observacion2 = myReader[14].ToString();
        //            myz_carros.OpObservacion2 = myReader[15].ToString();
        //        }
        //        myBase.CloseConnection(myConn);
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //    return myz_carros;
        //}



        public DataSet GetCarrosCompania(int id_tipo_carro, int id_compania)
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig FROM z_carros WHERE (id_tipo_carro=" + id_tipo_carro + " and id_compania=" + id_compania + ")";
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

        public z_carros GetCarroAlternativo(int id_tipo_carro, int id_compania)
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado FROM z_carros WHERE (id_tipo_alternativo=" + id_tipo_carro + " and id_compania=" + id_compania + " and estado=1)";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_carros.id_carro = Convert.ToInt32(myReader[0]);
                    myz_carros.nombre = myReader[1].ToString();
                    myz_carros.id_tipo_carro = Convert.ToInt32(myReader[2]);
                    myz_carros.id_compania = Convert.ToInt32(myReader[3]);
                    myz_carros.estado = Convert.ToInt32(myReader[4]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_carros;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_carros()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_carros order by nombre";
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

        
        public DataSet Getz_carrosTodosDisponibles()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_carros where estado=1 or estado=5 order by id_compania_orig";
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

        // ### Clasificación de Carros para 2-6...
        public DataSet Getz_carrosSelGrupos()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM x_grupo ORDER BY orden";
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


        // ### Estado de Carros
        public DataSet Getz_EstadoCarro()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_estado_carros WHERE id_estado IN (1,2,3)";
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






        //### NUEVO
        public void SetEstadoCarros()
        {
            BorrarEstadoCarros();

            CnxBase myBase = new CnxBase();
            string reqSQL = "insert into zs_estado_carro(id_carro, id_estado) select id_carro, estado from z_carros";
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



        public void BorrarEstadoCarros()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "delete from zs_estado_carro";
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

        public int GetEstadoCarros(int idCarro)
        {
            CnxBase myBase = new CnxBase();
            int estado = 0;
            string reqSQL = "SELECT id_carro, id_estado FROM zs_estado_carro WHERE id_carro = " + idCarro;
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow row in myResult.Tables[0].Rows)
                {
                    estado = Convert.ToInt32(row["id_estado"].ToString());
                }
                return estado;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }





        public DataSet Getz_carrosTodosDisponiblesEnLlamado()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_carros where estado=1 or estado=5 or estado=4 order by id_compania_orig";
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

        public DataSet Getz_carrosNoDisponibles()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_carros where estado!=1 and estado!=4 order by id_compania_orig, id_tipo_carro";
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

        public string Getz_carrosFueraServicio()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select carros_fuera_servicio()";
            string ret;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = Convert.ToString(myCommand.ExecuteScalar());

                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public int GetMaxCarros()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            int max = 0;
            //string reqSQL = "select max(count) from (select count(id_tipo_carro) from z_carros group by id_tipo_carro) as count";
            string reqSQL = "select max(id_tipo_carro) from z_carros ";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                max = Convert.ToInt32(myCommand.ExecuteScalar());

                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return max;
        }

        public DataSet GetCarrosTipo(int id)
        {
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT * FROM z_carros where id_tipo_carro=" + id + " order by id_compania_orig";
            //string reqSQL = "SELECT * FROM z_carros WHERE (id_tipo_carro=" + id + " AND car_apoyo = 0) OR (id_tipo_carro =" + id + " AND car_apoyo > 0 AND habilitado = true)";
            //### Carros Ordenados por Compañia
            string reqSQL = "SELECT * FROM z_carros WHERE (id_tipo_carro=" + id + " AND car_apoyo = 0) OR (id_tipo_carro =" + id + " AND car_apoyo > 0 AND habilitado = true) ORDER BY id_compania_orig";
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

        public void SetFueraServicio(int id_compania)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET estado=3 WHERE (id_compania=" + id_compania + " and estado=1)";
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

        public void SetEnServicio(int id_compania)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET estado=1 WHERE (id_compania=" + id_compania + " and estado=3)";
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
        #endregion

        public Image getImagen(int id_carro)
        {
            Image ret = null;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT foto FROM z_carros WHERE id_carro=" + id_carro;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read() && myReader[0] != DBNull.Value)
                {
                    int id = Convert.ToInt32(myReader[0]);
                    // myReader.Close();
                    NpgsqlTransaction t = myConn.BeginTransaction();
                    NpgsqlTypes.LargeObjectManager lbm = new NpgsqlTypes.LargeObjectManager(myConn);
                    NpgsqlTypes.LargeObject lo = lbm.Open(id, NpgsqlTypes.LargeObjectManager.READ);
                    byte[] buf = new byte[lo.Size()];
                    buf = lo.Read(lo.Size());
                    MemoryStream ms = new MemoryStream();
                    ms.Write(buf, 0, lo.Size());
                    lo.Close();
                    t.Commit();
                    ret = Image.FromStream(ms);
                }
                myConn.Close();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public bool CheckAlternativo(int id_carro = 0)
        {
            bool ret = false;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT COUNT(id_tipo_alternativo) FROM z_carros WHERE id_tipo_alternativo=" + id_carro;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = !Convert.ToBoolean(myCommand.ExecuteScalar());
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public DataSet GetCarrosCubriendo()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_carro,nombre,id_compania FROM z_carros where id_compania!=id_compania_orig";
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

        public int asignarCoordenadasCarro(string compania, int id_carro)
        {
            CnxBase myBase = new CnxBase();
            int respuesta = 0;
            string Sql_Update = "";
            string reqSQL = "SELECT compania_x, compania_y, id_compania FROM z_companias WHERE nombre_compania = '" + compania + "'";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_comp in myResult.Tables[0].Rows)
                {
                    //Sql_Update = "UPDATE z_carros SET carro_x = " + Convert.ToInt32(r_comp["compania_x"].ToString()) + ", carro_y = " + Convert.ToInt32(r_comp["compania_y"].ToString()) + ", id_compania = " + Convert.ToInt32(r_comp["id_compania"].ToString()) + ", id_compania_orig = " + Convert.ToInt32(r_comp["id_compania"].ToString()) + " WHERE id_carro = " + id_carro;
                    Sql_Update = "UPDATE z_carros SET carro_x = " + Convert.ToInt32(r_comp["compania_x"].ToString()) + ", carro_y = " + Convert.ToInt32(r_comp["compania_y"].ToString()) + ", id_compania = " + Convert.ToInt32(r_comp["id_compania"].ToString()) + " WHERE id_carro = " + id_carro;
                    NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                    NpgsqlCommand myCommand = new NpgsqlCommand(Sql_Update, myConn);
                    respuesta = myCommand.ExecuteNonQuery();
                    myBase.CloseConnection(myConn);
                }
                return respuesta;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            
        }

        public DataSet cargarCombo()
        {
            var myBase = new CnxBase();
            string reqSQL = "select punto_x || '/' || punto_y as coordenada, calle_1 || ' CON ' || calle_2 as ubicacion from zs_trapasos";
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public DataSet cargarComboClave()
        {
            var myBase = new CnxBase();
            string reqSQL = "select descripcion_clave from zs_trapasos";
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public int asignarCoordenadasGestionDestino(string[] coor_carros, int id_carro)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            //string reqSQL = "UPDATE z_carros SET destino_x = " + Convert.ToInt32(coor_carros[0]) + ", destino_y = " + Convert.ToInt32(coor_carros[1]) + " WHERE id_carro = " + id_carro;
            string reqSQL = "UPDATE z_carros SET carro_x = " + Convert.ToInt32(coor_carros[0]) + ", carro_y = " + Convert.ToInt32(coor_carros[1]) + " WHERE id_carro = " + id_carro;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
                limpiarTablaTraspaso();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public int limpiarTablaTraspaso()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "DELETE FROM zs_trapasos";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public ArrayList[] obtenerCarrosIN(string carros)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            ArrayList list = new ArrayList();

            ArrayList list_id_carros = new ArrayList();
            ArrayList list_carro_x = new ArrayList();
            ArrayList list_carro_y = new ArrayList();
            ArrayList list_compania = new ArrayList();
            ArrayList list_ranking = new ArrayList();
            ArrayList[] array_list = new ArrayList[5];

            string reqSQL = "SELECT id_carro, carro_x, carro_y, id_compania, ranking FROM z_carros WHERE id_tipo_carro IN (" + carros + ")";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_ocarros in myResult.Tables[0].Rows)
                {
                    list_id_carros.Add(r_ocarros["id_carro"].ToString());
                    list_carro_x.Add(r_ocarros["carro_x"].ToString());
                    list_carro_y.Add(r_ocarros["carro_y"].ToString());
                    list_compania.Add(r_ocarros["id_compania"].ToString());
                    list_ranking.Add(r_ocarros["ranking"].ToString());
                }

                array_list[0] = list_id_carros;
                array_list[1] = list_carro_x;
                array_list[2] = list_carro_y;
                array_list[3] = list_compania;
                array_list[4] = list_ranking;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            //return list;
            return array_list;
        }


        public ArrayList[] obtenerCarrosVirtual(string IdGrupo, int IdArea, int IdAlias)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            ArrayList list = new ArrayList();

            ArrayList list_id_carros = new ArrayList();
            ArrayList list_carro_x = new ArrayList();
            ArrayList list_carro_y = new ArrayList();
            ArrayList list_compania = new ArrayList();
            ArrayList list_rkn = new ArrayList();
            ArrayList[] array_list = new ArrayList[5];

            string reqSQL = "SELECT a.id_carro, a.carro_x, a.carro_y, a.id_compania, b.rx_2_q, b.id_grupo, xp.ranking ";
            reqSQL += " FROM z_carros a ";
            reqSQL += " INNER JOIN z_carros_virtual b ON a.id_carro = b.id_carro ";
            reqSQL += " INNER JOIN x_prioridad xp ON a.id_compania = xp.id_cuartel AND xp.id_area = " + IdArea + " AND xp.id_grupo = " + IdAlias + " ";
            reqSQL += " WHERE a.id_carro ";
            reqSQL += " IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + IdGrupo + ") ";
            reqSQL += " AND b.id_grupo = " + IdGrupo + " ORDER BY a.id_carro";
            
            
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_ocarros in myResult.Tables[0].Rows)
                {
                    list_id_carros.Add(r_ocarros["id_carro"].ToString());
                    list_carro_x.Add(r_ocarros["carro_x"].ToString());
                    list_carro_y.Add(r_ocarros["carro_y"].ToString());
                    list_compania.Add(r_ocarros["id_compania"].ToString());
                    list_rkn.Add(r_ocarros["ranking"].ToString());
                }

                array_list[0] = list_id_carros;
                array_list[1] = list_carro_x;
                array_list[2] = list_carro_y;
                array_list[3] = list_compania;
                array_list[4] = list_rkn;


            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            //return list;
            return array_list;
        }


        public ArrayList[] obtenerCarrosVirtual_Incendio(string IdGrupo, int IdArea, int IdAlias)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            ArrayList list = new ArrayList();

            ArrayList list_id_carros = new ArrayList();
            ArrayList list_carro_x = new ArrayList();
            ArrayList list_carro_y = new ArrayList();
            ArrayList list_compania = new ArrayList();
            ArrayList list_rkn = new ArrayList();
            ArrayList[] array_list = new ArrayList[5];

            string reqSQL = "";
            if (IdGrupo == "8" || IdGrupo == "9" || IdGrupo == "7")
            {
                reqSQL = "SELECT a.id_carro, a.carro_x, a.carro_y, a.id_compania, b.rx_2_q, b.id_grupo ";
                reqSQL += " FROM z_carros a ";
                reqSQL += " INNER JOIN z_carros_virtual b ON a.id_carro = b.id_carro ";
                reqSQL += " WHERE a.id_carro ";
                reqSQL += " IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + IdGrupo + ") ";
                reqSQL += " AND b.id_grupo = " + IdGrupo + " ORDER BY a.id_carro";
            }
            else
            {
                reqSQL = "SELECT a.id_carro, a.carro_x, a.carro_y, a.id_compania, b.rx_2_q, b.id_grupo, xp.ranking ";
                reqSQL += " FROM z_carros a ";
                reqSQL += " INNER JOIN z_carros_virtual b ON a.id_carro = b.id_carro ";
                reqSQL += " INNER JOIN x_prioridad xp ON a.id_compania = xp.id_cuartel AND xp.id_area = " + IdArea + " AND xp.id_grupo = " + IdAlias + " ";
                reqSQL += " WHERE a.id_carro ";
                reqSQL += " IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + IdGrupo + ") ";
                reqSQL += " AND b.id_grupo = " + IdGrupo + " ORDER BY a.id_carro";
            }


            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_ocarros in myResult.Tables[0].Rows)
                {
                    list_id_carros.Add(r_ocarros["id_carro"].ToString());
                    list_carro_x.Add(r_ocarros["carro_x"].ToString());
                    list_carro_y.Add(r_ocarros["carro_y"].ToString());
                    list_compania.Add(r_ocarros["id_compania"].ToString());
                    if (IdGrupo == "8" || IdGrupo == "9" || IdGrupo == "7")
                    {
                        list_rkn.Add(1);
                    }
                    else
                    {
                        list_rkn.Add(r_ocarros["ranking"].ToString());
                    }
                }

                array_list[0] = list_id_carros;
                array_list[1] = list_carro_x;
                array_list[2] = list_carro_y;
                array_list[3] = list_compania;
                array_list[4] = list_rkn;


            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            //return list;
            return array_list;
        }



        public ArrayList[] obtenerCarrosVirtualPorClave(string IdGrupo, int IdArea, int IdAlias)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            ArrayList list = new ArrayList();

            ArrayList list_id_carros = new ArrayList();
            ArrayList list_carro_x = new ArrayList();
            ArrayList list_carro_y = new ArrayList();
            ArrayList list_compania = new ArrayList();
            ArrayList list_rkn = new ArrayList();
            ArrayList[] array_list = new ArrayList[5];

            //reqSQL = "SELECT a.id_carro, a.carro_x, a.carro_y, a.id_compania, a.ranking, b.rx_2_q, b.id_grupo FROM z_carros a inner join z_carros_virtual b on a.id_carro = b.id_carro WHERE a.id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + carros + ") and b.id_grupo = " + carros + " ORDER BY a.id_carro";

            string reqSQL = "SELECT a.id_carro, a.carro_x, a.carro_y, a.id_compania, b.rx_2_q, b.id_grupo, xp.ranking ";
            reqSQL += " FROM z_carros a ";
            reqSQL += " INNER JOIN z_carros_virtual b ON a.id_carro = b.id_carro ";
            reqSQL += " INNER JOIN x_prioridad xp ON a.id_compania = xp.id_cuartel AND xp.id_area = " + IdArea + " AND xp.id_grupo = " + IdAlias + " ";
            reqSQL += " WHERE a.id_carro ";
            reqSQL += " IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + IdGrupo + ") ";
            //reqSQL += " AND b.id_grupo = " + IdGrupo + " ORDER BY a.id_carro";
            //### Solo Carros Activados para omitir Apoyos
            reqSQL += " AND b.id_grupo = " + IdGrupo + " AND a.car_apoyo = 0 ORDER BY a.id_carro";

            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_ocarros in myResult.Tables[0].Rows)
                {
                    list_id_carros.Add(r_ocarros["id_carro"].ToString());
                    list_carro_x.Add(r_ocarros["carro_x"].ToString());
                    list_carro_y.Add(r_ocarros["carro_y"].ToString());
                    list_compania.Add(r_ocarros["id_compania"].ToString());
                    list_rkn.Add(r_ocarros["ranking"].ToString());
                }

                array_list[0] = list_id_carros;
                array_list[1] = list_carro_x;
                array_list[2] = list_carro_y;
                array_list[3] = list_compania;
                array_list[4] = list_rkn;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            //return list;
            return array_list;
        }




        public ArrayList obtenerRankingVirtual(string grupo)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            ArrayList list = new ArrayList();

            ArrayList list_ranking = new ArrayList();
            ArrayList[] array_list = new ArrayList[1];
            // string reqSQL = "SELECT id_carro, carro_x, carro_y, id_compania, ranking FROM z_carros WHERE id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + carros + ")";
            string reqSQL = "SELECT ranking, id_carro FROM z_carros_virtual WHERE id_grupo = " + grupo + "ORDER BY id_carro";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_ocarros in myResult.Tables[0].Rows)
                {
                    list_ranking.Add(r_ocarros["ranking"].ToString());
                }
                //array_list[0] = list_ranking;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            //return list;
            return list_ranking;
        }


        // ObtieneRankingDeCascada
        public ArrayList ObtieneRankingDeCascada(int idArea)
        {
            CnxBase myBase = new CnxBase();
            ArrayList list_ranking_cascada = new ArrayList();

            string reqSQL = "SELECT ranking FROM x_cascada_ranking WHERE id_area = " + idArea + " ORDER BY id_carro";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        list_ranking_cascada.Add(dr_row["ranking"].ToString());
                    }
                }

                return list_ranking_cascada;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        public ArrayList obtenerRankingUchile(string grupo, ArrayList CoordenadasGrupo)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            
            ArrayList list_ranking = new ArrayList();
            ArrayList[] array_list = new ArrayList[1];
            // string reqSQL = "SELECT id_carro, carro_x, carro_y, id_compania, ranking FROM z_carros WHERE id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + carros + ")";
            string reqSQL = "SELECT id_carro, carro_x, carro_y, id_compania FROM z_carros WHERE id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + grupo + " ORDER BY id_carro) ORDER BY id_carro";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_ocarros in myResult.Tables[0].Rows)
                {
                    string strLine = r_ocarros["carro_x"].ToString() + ";" + r_ocarros["carro_y"].ToString();
                    CoordenadasGrupo.Add(strLine);
                }
                //array_list[0] = list_ranking;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            //return list;
            //return list_ranking;
            return CoordenadasGrupo;
        }



        public ArrayList obtenerRankingUchilePorClave(string grupo, ArrayList CoordenadasGrupo)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "";

            //ArrayList list = new ArrayList();

            ArrayList list_ranking = new ArrayList();
            ArrayList[] array_list = new ArrayList[1];
            //string reqSQL = "SELECT id_carro, carro_x, carro_y, id_compania FROM z_carros WHERE id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + grupo + " ORDER BY id_carro) ORDER BY id_carro";
            //if (grupo == "1")
            //{
            //    reqSQL = "SELECT id_carro, carro_x, carro_y, id_compania FROM z_carros WHERE id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + grupo + " AND id_tipo_carro = 1 ORDER BY id_carro) ORDER BY id_carro";
            //}
            //else
            //{
                reqSQL = "SELECT id_carro, carro_x, carro_y, id_compania FROM z_carros WHERE id_carro IN (SELECT id_carro FROM z_carros_virtual WHERE id_grupo = " + grupo + " ORDER BY id_carro) ORDER BY id_carro";
            //}
            
            
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_ocarros in myResult.Tables[0].Rows)
                {
                    //list_id_carros.Add(r_ocarros["id_carro"].ToString());
                    //string strLine = grupo.ToString() + "#" + r_ocarros["carro_x"].ToString() + ";" + r_ocarros["carro_y"].ToString();
                    string strLine = r_ocarros["carro_x"].ToString() + ";" + r_ocarros["carro_y"].ToString();
                    //list_carro_y.Add(r_ocarros["carro_y"].ToString());
                    //list_compania.Add(r_ocarros["id_compania"].ToString());
                    CoordenadasGrupo.Add(strLine);
                }
                //array_list[0] = list_ranking;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            //return list;
            //return list_ranking;
            return CoordenadasGrupo;
        }


        public int recuperarValorTipoCarro(int id_carro)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            int tc = 0;
            string reqSQL = "SELECT id_tipo_carro FROM z_carros WHERE id_carro = " + id_carro;
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_tcarros in myResult.Tables[0].Rows)
                {
                    tc = Convert.ToInt32(r_tcarros["id_tipo_carro"].ToString());
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return tc;
        }


        public string recuperarTiposDeCarroDelGrupo(string id_grupo)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string tc = "";
            string reqSQL = "SELECT id_tipo_carro FROM z_carros_virtual WHERE id_grupo = " + id_grupo;
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_tcarros in myResult.Tables[0].Rows)
                {
                    tc += r_tcarros["id_tipo_carro"].ToString() + ",";
                }
                tc += "#";
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            tc += tc.Replace(",#","");
            return tc;
        }



        public int obtenerCodigoArea(int id_area)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            int tc = 0;
            string reqSQL = "SELECT grupo_area FROM x_grupo_area WHERE area = " + id_area;
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count == 0)
                {
                    tc = 1;
                }
                else
                {
                    foreach (DataRow r_tcarros in myResult.Tables[0].Rows)
                    {
                        tc = Convert.ToInt32(r_tcarros["grupo_area"].ToString());

                    }
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return tc;
        }


        public bool EvaluaGrupoArea(int id_area)
        {
            bool tf = false;
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT comp_ga_tipo FROM x_despacho_habil WHERE id_llamado = " + id_area + "LIMIT 1";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_tcarros in myResult.Tables[0].Rows)
                {
                   tf = Convert.ToBoolean(r_tcarros["comp_ga_tipo"]);
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return tf;
        }

        public void insertZcarrosLlamado(int idCarro, int idGrupo, int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO z_carros_llamado (id_carro, id_grupo, id_expediente, flag_estado) VALUES (" + idCarro + "," + idGrupo + "," + idExpediente + ", 'TEMPORAL')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public ArrayList retornarCarrosUsados(int idExpediente) 
        {
            ArrayList listaCarrosUsados = new ArrayList();
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT zc.id_compania FROM e_carros_usados ecu left join z_carros zc ON zc.id_carro = ecu.id_carro where ecu.id_expediente = "+idExpediente+"";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    listaCarrosUsados.Add(r_lcu["id_compania"].ToString());        
                }

            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return listaCarrosUsados;
        }

        public int existenciaZcarrosLlamado(int idCarro, int idExpediente) 
        {
            int contador = 0;
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT count(*) as contador FROM z_carros_llamado WHERE id_carro = "+idCarro+" and id_expediente = "+idExpediente+"";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    contador = Convert.ToInt32(r_lcu["contador"].ToString());
                }

            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return contador;
        }


        public int existenciaZcarrosParaEsteExpediente(int idExpediente)
        {
            int contador = 0;
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT count(*) as contador FROM z_carros_llamado WHERE id_expediente = " + idExpediente + "";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    contador = Convert.ToInt32(r_lcu["contador"].ToString());
                }

            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return contador;
        }


        public void eliminarZcarrosLlamadoEspecifico(int idCarro, int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM z_carros_llamado WHERE id_carro = "+idCarro+" and id_expediente = "+idExpediente+" and flag_estado = 'TEMPORAL'";
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

        public void actualizarZcarrosLlamadoEspecifico(int idCarro, int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros_llamado SET flag_estado = 'NOTEMPORAL' WHERE flag_estado = 'TEMPORAL' and id_carro = "+idCarro+" and id_expediente = "+idExpediente+"";
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


        //### NuevoMetodo Mas de Un Carro por Compañia
        public void actualizarZcarrosLlamado_Uno_X_Cia(int idCarro, int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros_llamado SET uno_x_cia = true WHERE id_carro = " + idCarro + " and id_expediente = " + idExpediente + "";
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

        //### retornarCarrosUsadosUno_X_Cia
        public ArrayList retornarCarrosUsados_Uno_X_Cia(int idExpediente)
        {
            ArrayList listaCarrosUsados = new ArrayList();
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT zc.id_compania FROM z_carros_llamado zcl left join z_carros zc ON zc.id_carro = zcl.id_carro WHERE zcl.uno_x_cia = true AND zcl.id_expediente = " + idExpediente + "";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_lcu in myResult.Tables[0].Rows)
                {
                    listaCarrosUsados.Add(r_lcu["id_compania"].ToString());
                }

            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return listaCarrosUsados;
        }



        public ArrayList CorrigeRanking(ArrayList BloqueList)
        {
            ArrayList Correlativo = new ArrayList();
            int UltimoValor = 0;
            int n = 1;
            foreach (int v in BloqueList)
            {
                if (Correlativo.Count == 0)
                {
                    Correlativo.Add(n);
                    UltimoValor = v;
                }
                else
                {
                    if (v == UltimoValor)
                    {
                        n = n - 1;
                        Correlativo.Add(n);
                    }
                    else 
                    {
                        Correlativo.Add(n);
                    }
                    UltimoValor = v;
                }
                n++;
            }
            return Correlativo; 
        }


        //### Asigna Ranking Correlativo
        public ArrayList CorrigeRanking2(ArrayList BloqueList)
        {
          
            ArrayList Correlativo = new ArrayList();
            //int UltimoValor = 0;
            string UltimoValor = "0";

            int n = 1;
            //foreach (int v in BloqueList)
            foreach (string v in BloqueList)
            {
                if (Correlativo.Count == 0)
                {
                    Correlativo.Add(n);
                    UltimoValor = v;
                }
                else
                {
                    if (v == UltimoValor)
                    {
                        n = n - 1;
                        Correlativo.Add(n);
                    }
                    else
                    {
                        Correlativo.Add(n);
                    }
                    UltimoValor = v;
                }
                n++;
            }
            return Correlativo;
        }


        /*
        public void GenerarActualizacionCasosEspeciales(string labelCarro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET carro_x = destino_x, carro_y = destino_y where nombre = '" + labelCarro + "'";
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
        */

        public void GenerarActualizacionCasosEspeciales(string labelCarro)
        {
            CnxBase myBase = new CnxBase();
            int affectedRow = 0;
            string[] coorxy = RecDestinoXY(labelCarro).Split(';');

            string reqSQL = "UPDATE z_carros SET carro_x = " + Convert.ToInt32(coorxy[0]) + ", carro_y = " + Convert.ToInt32(coorxy[1]) + ", destino_x = 0, destino_y = 0 where nombre = '" + labelCarro + "'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                affectedRow = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public string RecDestinoXY(string labelCarro)
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string coordenadas = "";
            string reqSQL = "select destino_x, destino_y from z_carros where nombre = '" + labelCarro + "'";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r in myResult.Tables[0].Rows)
                {
                    coordenadas = r["destino_x"].ToString() + ";" + r["destino_y"].ToString();
                }

            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return coordenadas;
        }






        public bool ValidacionUnoPorCompania(int id_llamado, int id_grupo)
        {
            bool UnoXcia = false;
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT * FROM x_despacho_habil WHERE id_llamado = "+id_llamado+" and id_grupo = "+id_grupo+"";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_vuxc in myResult.Tables[0].Rows)
                {
                    UnoXcia = Convert.ToBoolean(r_vuxc["uno_x_cia"]);
                }

            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return UnoXcia;
        }

        public object[] GenerarDiccionario(int id_llamado)
        {
            
            object[] objDiccionario = new object[5];
            Dictionary<int, string> DicGrupo = new Dictionary<int, string>();
            Dictionary<int, string> DicRecurso = new Dictionary<int, string>();
            Dictionary<int, bool> DicPauta = new Dictionary<int, bool>();
            Dictionary<int, bool> DicReemplazo = new Dictionary<int, bool>();
            Dictionary<int, string> DicGrupoReemplazo = new Dictionary<int, string>();
            bool UnoXcia = false;
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT * FROM x_despacho_habil WHERE id_llamado = " + id_llamado;
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow row in myResult.Tables[0].Rows)
                {
                    DicGrupo.Add(Convert.ToInt32(row["id_grupo"].ToString()), row["id_grupo"].ToString());
                    DicRecurso.Add(Convert.ToInt32(row["id_grupo"].ToString()), row["recurso"].ToString());
                    DicPauta.Add(Convert.ToInt32(row["id_grupo"].ToString()), Convert.ToBoolean(row["pauta"].ToString()));
                    DicReemplazo.Add(Convert.ToInt32(row["id_grupo"].ToString()), Convert.ToBoolean(row["reemplazo"].ToString()));
                    DicGrupoReemplazo.Add(Convert.ToInt32(row["id_grupo"].ToString()), row["grup_rem"].ToString());
                }

                objDiccionario[0] = DicGrupo;
                objDiccionario[1] = DicRecurso;
                objDiccionario[2] = DicPauta;
                objDiccionario[3] = DicReemplazo;
                objDiccionario[4] = DicGrupoReemplazo;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return objDiccionario;
        }

        public string ObtieneCamposDelGrupoN(int id_llamado, string grupo)
        {
            string strValores = "";
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT * FROM x_despacho_habil WHERE id_llamado = " + id_llamado + "AND id_grupo=" + grupo;
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow row in myResult.Tables[0].Rows)
                {
                    strValores = row["id_grupo"].ToString() + "_";
                    strValores += row["pauta"].ToString() + "_";
                    strValores += row["reemplazo"].ToString() + "_";
                    strValores += row["grup_rem"].ToString() + "_";
                }
                strValores += "#";
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            strValores += strValores.Replace("_#", "");

            return strValores;

        }

        public DataSet GetCarros()
        {
            string strValores = "";
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            DataSet myResult = new DataSet();
            string reqSQL = "SELECT id_carro, nombre FROM z_carros ORDER BY id_compania_orig, nombre";
            try
            {
                myResult = myD4MCnx.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myResult;
        }

        public DataSet Get_Compania_Seleccionada(int id_cia)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_carro, nombre FROM z_carros WHERE id_compania_orig=" + id_cia;
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

        public DataSet Get_Compania_SeleccionadaCarrosDisponible(int id_cia)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_carro, nombre FROM z_carros WHERE id_compania_orig=" + id_cia + " AND (estado = 1 OR estado = 5)";
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

        //# Carros de una Compañía Seleccionada
        public DataSet Get_Compania_SeleccionadaCarros(int id_cia)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_carro, nombre FROM z_carros WHERE id_compania_orig=" + id_cia;
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


        public DataSet GetCompanias()
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            DataSet myResult = new DataSet();
            string reqSQL = "SELECT nombre_compania, compania_x || '-' || compania_y as Coordenadas FROM z_companias ORDER BY orden asc";
            try
            {
                myResult = myD4MCnx.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myResult;
        }


        public DataSet GetCompaniasId()
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            DataSet myResult = new DataSet();
            string reqSQL = "SELECT nombre_compania, id_compania FROM z_companias ORDER BY orden asc";
            try
            {
                myResult = myD4MCnx.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myResult;
        }

        
        //public int ActualizarCoordenadasCubrirCuartel(int id_carro, int carro_x, int carro_y)
        //{
        //    int act = 0;
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "UPDATE z_carros SET carro_x = "+carro_x+", carro_y = "+carro_y+", estado = 2, carros_011 = true WHERE id_carro = "+id_carro;
        //    try
        //    {
        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //        act = myCommand.ExecuteNonQuery();
        //        myBase.CloseConnection(myConn);
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //    return act;
        //}

        public int ActualizarCoordenadasCubrirCuartel(int id_carro, int carro_x, int carro_y)
        {
            int act = 0;
            CnxBase myBase = new CnxBase();
            //string reqSQL = "UPDATE z_carros SET carro_x = " + carro_x + ", carro_y = " + carro_y + ", estado = 2, carros_011 = true, evento = 'IDA' WHERE id_carro = " + id_carro;
            string reqSQL = "UPDATE z_carros SET id_compania = " + carro_x + ", evento = 'IDA' WHERE id_carro = " + id_carro;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                act = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return act;
        }



        //public int Actualizar011_Campo(string nombre)
        //{
        //    int act = 0;
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "UPDATE z_carros SET estado = 1 WHERE nombre = '" + nombre + "'";
        //    try
        //    {
        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //        act = myCommand.ExecuteNonQuery();
        //        myBase.CloseConnection(myConn);
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //    return act;
        //}
        public int Actualizar011_Campo(string nombre)
        {
            int act = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET estado = 1 WHERE nombre = '" + nombre + "'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                act = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return act;
        }


        //public int Actualizar011_Retornar(int id_carro, int carro_x, int carro_y)
        //{
        //    int act = 0;
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "UPDATE z_carros SET carro_x = " + carro_x + ", carro_y = " + carro_y + ", estado = 2, carros_011 = false WHERE id_carro = " + id_carro;
        //    try
        //    {
        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //        act = myCommand.ExecuteNonQuery();
        //        myBase.CloseConnection(myConn);
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //    return act;
        //}
        public int Actualizar011_Retornar(int id_carro, int carro_x, int carro_y)
        {
            int act = 0;
            CnxBase myBase = new CnxBase();
            //string reqSQL = "UPDATE z_carros SET carro_x = " + carro_x + ", carro_y = " + carro_y + ", estado = 2, carros_011 = true, evento = 'RETORNO' WHERE id_carro = " + id_carro;
            string reqSQL = "UPDATE z_carros SET id_compania = " + carro_x + ", evento = 'RETORNO' WHERE id_carro = " + id_carro;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                act = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return act;
        }



        public DataSet GetCarrosReemplazo()
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            DataSet myResult = new DataSet();
            //string reqSQL = "SELECT id_virtual as virtual, id_carro as idcarro, nombre as nombrecarro, rx_2_q as boolreemplazo, reemplaza as carroreemplaza FROM z_carros_virtual WHERE id_grupo = 2 and id_tipo_carro = 14";
            //string reqSQL = "SELECT id_virtual as virtual, id_carro as idcarro, nombre as nombrecarro, rx_2_q as boolreemplazo, reemplaza as carroreemplaza FROM z_carros_virtual WHERE (id_grupo = 2 and id_tipo_carro = 14) OR (id_grupo = 1 and id_tipo_carro = 15)";
            string reqSQL = "SELECT id_virtual as virtual, id_carro as idcarro, nombre as nombrecarro, rx_2_q as boolreemplazo, reemplaza as carroreemplaza FROM z_carros_virtual WHERE (id_grupo = 1 and id_tipo_carro = 5) OR (id_grupo = 1 and id_tipo_carro = 6) OR (id_grupo = 4 and id_tipo_carro = 1)";
            try
            {
                myResult = myD4MCnx.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myResult;
        }

        //public int ActualizarReemplazoZcarrosVirtual(string codigoVirtual, string reemplazo)
        public int ActualizarReemplazoZcarrosVirtual(int codigoVirtual, string reemplazo)
        {
            int act = 0;

            // Invertir el Valor Booleano
            bool InBool = true;
            if (Convert.ToBoolean(reemplazo))
            {
                InBool = false;
            }
            else
            {
                InBool = true;
            }

            CnxBase myBase = new CnxBase();
            //string reqSQL = "UPDATE z_carros_virtual SET rx_2_q = " + Convert.ToBoolean(reemplazo) + " WHERE id_virtual = " + Convert.ToInt32(codigoVirtual);
            //string reqSQL = "UPDATE z_carros_virtual SET rx_2_q = " + InBool + " WHERE id_virtual = " + Convert.ToInt32(codigoVirtual);
            string reqSQL = "UPDATE z_carros_virtual SET rx_2_q = " + InBool + " WHERE id_virtual = " + codigoVirtual;
            
            
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                act = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return act;
        }

        public bool ObtenerBooleanReemplazo(int idCarro, int idGrupo)
        {
            CnxBase myBase = new CnxBase();
            bool reemplazo = false;

            string reqSQL = "SELECT b.rx_2_q FROM z_carros a left join z_carros_virtual b on a.id_carro = b.id_carro WHERE a.id_carro = " + idCarro + " and b.id_grupo = " + idGrupo + " ORDER BY a.id_carro";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        reemplazo = Convert.ToBoolean(dr_row["rx_2_q"].ToString());
                    }
                }

                return reemplazo;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        /*
            CnxBase myBase = new CnxBase();
            bool reemplazo = false;

            string reqSQL = "SELECT b.rx_2_q FROM z_carros a left join z_carros_virtual b on a.id_carro = b.id_carro WHERE a.id_carro = " + idCarro + " and b.id_grupo = " + idGrupo + " ORDER BY a.id_carro";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        reemplazo = Convert.ToBoolean(dr_row["rx_2_q"].ToString());
                    }
                }

                return reemplazo;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        */



        public List<int> ID_Reemplazo_Automatico(int idLlamado, int idGrupo, ArrayList list_id_carros)
        {
            List<int> Arr_ID = new List<int>();
            int IdCarro = 0;
            int IdReemplazo = 0;
            int IdCarroEnGrupo = 0;
            var ccarros = new z_carros();
            CnxBase myBase = new CnxBase();
             
            string reqSQL = "SELECT reemplazo, id_carro FROM x_reemplazo_automatico WHERE id_llamado = " + idLlamado + " AND id_grupo = " + idGrupo;
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {                
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        IdReemplazo = Convert.ToInt32(dr_row["reemplazo"].ToString());
                        IdCarro = Convert.ToInt32(dr_row["id_carro"].ToString());
                    }
                }

                if (IdReemplazo > 0)
                {
                    foreach (string v in list_id_carros)
                    {
                        if (IdReemplazo == Convert.ToInt32(v))
                        {
                            IdCarroEnGrupo = 1;
                        }
                    }
                }

                Arr_ID.Add(IdCarro);
                Arr_ID.Add(IdReemplazo);
                Arr_ID.Add(IdCarroEnGrupo);

                return Arr_ID;            
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        public int Update_Reemplazo_Automatico(int idGrupo, int idCarro, bool Estado)
        {
            int act = 0;

            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros_virtual SET rx_2_q = " + Estado + " WHERE id_grupo = " + idGrupo + " AND id_carro = " + idCarro;

            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                act = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return act;
        }



        //### Nuevo Código
        ////public bool ObtenerBooleanReemplazo(int idCarro, int idGrupo)
        ////{
        ////    CnxBase myBase = new CnxBase();
        ////    bool reemplazo = false;

        ////    string reqSQL = "SELECT b.rx_2_q FROM z_carros a left join z_carros_virtual b on a.id_carro = b.id_carro WHERE a.id_carro = " + idCarro + " and b.id_grupo = " + idGrupo + " ORDER BY a.id_carro";
        ////    try
        ////    {
        ////        DataSet myResult = myBase.GetDataSet(reqSQL);
        ////        if (myResult.Tables[0].Rows.Count > 0)
        ////        {
        ////            foreach (DataRow dr_row in myResult.Tables[0].Rows)
        ////            {
        ////                reemplazo = Convert.ToBoolean(dr_row["rx_2_q"].ToString());
        ////            }
        ////        }

        ////        return reemplazo;
        ////    }
        ////    catch (Exception myErr)
        ////    {
        ////        throw (new Exception(myErr.ToString() + reqSQL));
        ////    }
        ////}

        

        public string ObtenerIdCarro(string nombreCarro)
        {
            CnxBase myBase = new CnxBase();
            string idCarro = "";

            string reqSQL = "select id_carro from z_carros where nombre = '"+nombreCarro+"'";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        idCarro = dr_row["id_carro"].ToString();
                    }
                }

                return idCarro;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public DataSet ObtenerCarros011()
        {
            CnxBase myBase = new CnxBase();
            string idCarro = "";
            DataSet myResult = new DataSet();

            string reqSQL = "select nombre from z_carros where carros_011 = true";
            try
            {
               return myResult = myBase.GetDataSet(reqSQL);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public bool ObtenerCeroOnceCompania(int idCarro)
        {
            CnxBase myBase = new CnxBase();
            bool oo = true;
            string reqSQL = "select carros_011 from z_carros where id_carro = " + idCarro;
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        if (Convert.ToBoolean(dr_row["carros_011"]))
                        {
                            oo = true;
                        }
                        else
                        {
                            oo = false;
                        }
                    }
                }
                return oo;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public string ObtenerCoordenadasCarro(int idCarro)
        {
            CnxBase myBase = new CnxBase();
            string coordenadas = "";
            string reqSQL = "select carro_x, carro_y from z_carros where id_carro = " + idCarro;
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        coordenadas = dr_row["carro_x"].ToString() + "#" + dr_row["carro_y"];
                    }
                }
                return coordenadas;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public int Actualizar011_seisdies(string nombre)
        {
            int act = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET carros_011 = false, evento = '' WHERE nombre = '" + nombre + "'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                act = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return act;
        }

        //### Actualizar una Observación de Carro
        public int ActualizarObservacionesCarros(string observacion, string operadora, int id_carro)
        {
            int act = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET observacion2 = '" + observacion + "', op_observacion2 = '"+operadora+"' WHERE id_carro = " + id_carro + "";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                act = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return act;
        }
    

        //###

        public DataSet FiltroUbicacion614(string ubicacion)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select ubicacion from x_destinos_614 where ubicacion like '%" + ubicacion + "%'";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public DataSet ListadoUbicaciones614()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select ubicacion FROM x_destinos_614 ORDER BY ubicacion";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        //public int UpdateCarros614(string lblCarro, int idCarro, string evento, string ubicacion)
        //{
        //    int f_affected = 0;
        //    string reqSQL = "";
        //    CnxBase myBase = new CnxBase();
        //    try
        //    {
        //        string reqSQL2 = "select coordenada_x, coordenada_y from x_destinos_614 where ubicacion = '" + ubicacion + "'";
        //        DataSet myResult = myBase.GetDataSet(reqSQL2);

        //        foreach (DataRow row in myResult.Tables[0].Rows)
        //        {
        //            reqSQL = "UPDATE z_carros SET estado = 5, carro_x = " + Convert.ToInt32(row["coordenada_x"].ToString()) + ", carro_y = " + Convert.ToInt32(row["coordenada_y"].ToString()) + " WHERE nombre = '" + lblCarro + "'";

        //            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //            f_affected = myCommand.ExecuteNonQuery();
        //            myBase.CloseConnection(myConn);
        //        }
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //    return f_affected;
        //}


       

        public int UpdateCarros614(string lblCarro, int idCarro, string evento, string ubicacion)
        {
            int f_affected = 0;
            string reqSQL = "";
            CnxBase myBase = new CnxBase();
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);

            try
            {
                string reqSQL2 = "select coordenada_x, coordenada_y from x_destinos_614 where ubicacion = '" + ubicacion + "'";
                DataSet myResult = myBase.GetDataSet(reqSQL2);

                foreach (DataRow row in myResult.Tables[0].Rows)
                {
                    if (evento == "0-8")
                    {
                        reqSQL = "UPDATE z_carros SET estado = 2, carro_x = " + Convert.ToInt32(row["coordenada_x"].ToString()) + ", carro_y = " + Convert.ToInt32(row["coordenada_y"].ToString()) + " WHERE nombre = '" + lblCarro + "'";


                        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                        f_affected = myCommand.ExecuteNonQuery();
                    }
                    else if (evento == "0-9")
                    {
                        reqSQL = "UPDATE z_carros SET estado = 5, carro_x = " + Convert.ToInt32(row["coordenada_x"].ToString()) + ", carro_y = " + Convert.ToInt32(row["coordenada_y"].ToString()) + " WHERE nombre = '" + lblCarro + "'";


                        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                        f_affected = myCommand.ExecuteNonQuery();
                    }


                    /*string query_carrosu = "select * from e_carros_usados where id_carro = " + idCarro;
                    DataSet myResult2 = myBase.GetDataSet(query_carrosu);

                    if (myResult2.Tables[0].Rows.Count > 0)
                    {
                        string reqSQL3 = "update e_carros_usados set id_expediente = '-2', seis = '" + evento + "' where id_carro = " + idCarro;


                        NpgsqlCommand myCommand2 = new NpgsqlCommand(reqSQL3, myConn);
                        f_affected = myCommand2.ExecuteNonQuery();
                    }
                    else
                    {
                        string reqSQL3 = "insert into e_carros_usados values ('-2', " + idCarro + ", 0, 0, '" + evento + "', '', true, 9999)";


                        NpgsqlCommand myCommand2 = new NpgsqlCommand(reqSQL3, myConn);
                        f_affected = myCommand2.ExecuteNonQuery();
                    }*/


                    myBase.CloseConnection(myConn);
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return f_affected;
        }



        // 6-15 
        public DataSet FiltroUbicacion615(string ubicacion)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select ubicacion from x_destinos_615 where ubicacion like '%" + ubicacion + "%'";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public DataSet ListadoUbicaciones615()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select ubicacion from x_destinos_615";
            try
            {
                DataSet myResult = myBase.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        //public int UpdateCarros615(string lblCarro, int idCarro, string evento, string ubicacion)
        //{
        //    int f_affected = 0;
        //    string reqSQL = "";
        //    CnxBase myBase = new CnxBase();
        //    try
        //    {
        //        string reqSQL2 = "select coordenada_x, coordenada_y from x_destinos_615 where ubicacion = '" + ubicacion + "'";
        //        DataSet myResult = myBase.GetDataSet(reqSQL2);

        //        foreach (DataRow row in myResult.Tables[0].Rows)
        //        {
        //            reqSQL = "UPDATE z_carros SET estado = 5, carro_x = " + Convert.ToInt32(row["coordenada_x"].ToString()) + ", carro_y = " + Convert.ToInt32(row["coordenada_y"].ToString()) + " WHERE nombre = '" + lblCarro + "'";

        //            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //            f_affected = myCommand.ExecuteNonQuery();
        //            myBase.CloseConnection(myConn);
        //        }
        //    }
        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //    return f_affected;
        //}


        public int UpdateCarros615(string lblCarro, int idCarro, string evento, string ubicacion)
        {
            int f_affected = 0;
            string reqSQL = "";
            CnxBase myBase = new CnxBase();
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);

            try
            {
                string reqSQL2 = "select coordenada_x, coordenada_y from x_destinos_615 where ubicacion = '" + ubicacion + "'";
                DataSet myResult = myBase.GetDataSet(reqSQL2);

                foreach (DataRow row in myResult.Tables[0].Rows)
                {
                    if (evento == "0-8")
                    {
                        reqSQL = "UPDATE z_carros SET estado = 2, carro_x = " + Convert.ToInt32(row["coordenada_x"].ToString()) + ", carro_y = " + Convert.ToInt32(row["coordenada_y"].ToString()) + " WHERE nombre = '" + lblCarro + "'";


                        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                        f_affected = myCommand.ExecuteNonQuery();
                    }
                    else if (evento == "0-9")
                    {
                        reqSQL = "UPDATE z_carros SET estado = 5, carro_x = " + Convert.ToInt32(row["coordenada_x"].ToString()) + ", carro_y = " + Convert.ToInt32(row["coordenada_y"].ToString()) + " WHERE nombre = '" + lblCarro + "'";


                        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                        f_affected = myCommand.ExecuteNonQuery();
                    }


                    /*string query_carrosu = "select * from e_carros_usados where id_carro = " + idCarro;
                    DataSet myResult2 = myBase.GetDataSet(query_carrosu);

                    if (myResult2.Tables[0].Rows.Count > 0)
                    {
                        string reqSQL3 = "update e_carros_usados set id_expediente = '-3', seis = '" + evento + "' where id_carro = " + idCarro;


                        NpgsqlCommand myCommand2 = new NpgsqlCommand(reqSQL3, myConn);
                        f_affected = myCommand2.ExecuteNonQuery();
                    }
                    else
                    {
                        string reqSQL3 = "insert into e_carros_usados values ('-3', " + idCarro + ", 0, 0, '" + evento + "', '', true, 9999)";


                        NpgsqlCommand myCommand2 = new NpgsqlCommand(reqSQL3, myConn);
                        f_affected = myCommand2.ExecuteNonQuery();
                    }*/


                    myBase.CloseConnection(myConn);
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return f_affected;
        }


        public string ObtenerNombreCarro(int IdCarro)
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT z_carros.id_carro, z_carros.nombre,z_companias.id_compania FROM z_carros INNER JOIN z_companias ON z_carros.carro_x = z_companias.compania_x AND z_carros.carro_y = z_companias.compania_y AND z_carros.id_carro = " + IdCarro.ToString() + " ORDER BY z_companias.id_compania";
            string reqSQL = "SELECT nombre FROM z_carros WHERE id_carro = " + IdCarro;
            string nombreCarro = "";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow row in myResult.Tables[0].Rows)
                { 
                    nombreCarro = row["nombre"].ToString();
                }
                return nombreCarro;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        
        
        
        // ###########
        // ### GPS ###
        // ###########

        //# Asigna GPS = False a todos los Carros
        public void GPS_Update_False()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET gps = false";
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

        //# Asigna GPS = True según id_carro
        public void GPS_Update_True(string id_carro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET gps = true WHERE id_carro=" + id_carro;
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

        //# Obtiene carros con coordenadas de 6-10
        public DataSet GPS_610()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros.id_carro, z_carros.nombre,z_companias.id_compania FROM z_carros INNER JOIN z_companias ON z_carros.carro_x = z_companias.compania_x AND z_carros.carro_y = z_companias.compania_y ORDER BY z_carros.id_compania_orig";
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

        //# Obtiene carros con coordenadas de 6-14        
        public DataSet GPS_614()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros.id_carro, z_carros.nombre, x_destinos_614.id FROM z_carros INNER JOIN x_destinos_614 ON z_carros.carro_x = x_destinos_614.coordenada_x AND z_carros.carro_y = x_destinos_614.coordenada_y WHERE z_carros.gps = false";
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

        //# Obtiene carros con coordenadas de 6-15
        public DataSet GPS_615()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros.id_carro, z_carros.nombre,x_destinos_615.id FROM z_carros INNER JOIN x_destinos_615 ON z_carros.carro_x = x_destinos_615.coordenada_x AND z_carros.carro_y = x_destinos_615.coordenada_y WHERE z_carros.gps = false";
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

        //# Obtiene Expedientes Activos
        public DataSet GPS_Expedientes()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT z_carros.id_carro, z_carros.nombre,x_destinos_615.id FROM z_carros INNER JOIN x_destinos_615 ON z_carros.carro_x = x_destinos_615.coordenada_x AND z_carros.carro_y = x_destinos_615.coordenada_y WHERE z_carros.gps = false";
            string reqSQL = "SELECT ex.codigo_llamado As cod_llam, zll.clave As clave, \"puntoX\",\"puntoY\" FROM e_expedientes ex, z_llamados zll WHERE ex.activo = true AND ex.codigo_llamado = zll.codigo_llamado";
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

        //# Obtiene carros con coordenadas de 6-3
        public DataSet GPS_63(string coord_x, string coord_y)
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT z_carros.id_carro, z_carros.nombre,x_destinos_615.id FROM z_carros INNER JOIN x_destinos_615 ON z_carros.carro_x = x_destinos_615.coordenada_x AND z_carros.carro_y = x_destinos_615.coordenada_y WHERE z_carros.gps = false";
            string reqSQL = "SELECT id_carro, nombre, carro_x FROM z_carros WHERE carro_x = " + coord_x + " AND carro_y = " + coord_y + "";
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

        //# Obtiene carros con Localización Indeterminada ???
        public DataSet GPS_NoEncontrados()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros.id_carro, z_carros.nombre FROM z_carros WHERE gps = false";
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


        //### Nueva Interfaz de Material Mayor
        public z_carros getObjectz_carros(string nombre)
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011, evento, observacion2, op_observacion2, ubicacion_613 FROM z_carros WHERE (nombre='" + nombre + "')";
            //#f
            string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011, evento, observacion2, op_observacion2, ubicacion_613, urlimagen FROM z_carros WHERE (nombre='" + nombre + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_carros.id_carro = Convert.ToInt32(myReader[0]);
                    myz_carros.nombre = myReader[1].ToString();
                    myz_carros.id_tipo_carro = Convert.ToInt32(myReader[2]);
                    myz_carros.id_compania = Convert.ToInt32(myReader[3]);
                    myz_carros.estado = Convert.ToInt32(myReader[4]);
                    myz_carros.id_tipo_alternativo = Convert.ToInt32(myReader[5]);
                    myz_carros.id_conductor = Convert.ToInt32(myReader[6]);
                    myz_carros.foto = myReader[7] == DBNull.Value ? 0 : Convert.ToInt32(myReader[7]);
                    myz_carros.fecha_fuera_servicio = Convert.ToDateTime(myReader[8]);
                    myz_carros.motivo_fuera_servicio = myReader[9].ToString();
                    myz_carros.id_compania_orig = Convert.ToInt32(myReader[10]);
                    myz_carros.periferia = Convert.ToBoolean(myReader[11]);
                    myz_carros.Carros_011 = myReader[12] == null ? Convert.ToBoolean("false") : Convert.ToBoolean(myReader[12]);
                    myz_carros.Evento = myReader[13].ToString();
                    myz_carros.Observacion2 = myReader[14].ToString();
                    myz_carros.OpObservacion2 = myReader[15].ToString();
                    myz_carros.ubicacion_613 = myReader[16].ToString();
                    //#f
                    myz_carros.urlimagen = myReader[17].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_carros;
        }

        //### Nueva Interfaz de Material Mayor
        public Image getImagenByNombre(string nombre)
        {
            Image ret = null;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT foto FROM z_carros WHERE nombre= '" + nombre + "'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read() && myReader[0] != DBNull.Value)
                {
                    int id = Convert.ToInt32(myReader[0]);
                    // myReader.Close();
                    NpgsqlTransaction t = myConn.BeginTransaction();
                    NpgsqlTypes.LargeObjectManager lbm = new NpgsqlTypes.LargeObjectManager(myConn);
                    NpgsqlTypes.LargeObject lo = lbm.Open(id, NpgsqlTypes.LargeObjectManager.READ);
                    byte[] buf = new byte[lo.Size()];
                    buf = lo.Read(lo.Size());
                    MemoryStream ms = new MemoryStream();
                    ms.Write(buf, 0, lo.Size());
                    lo.Close();
                    t.Commit();
                    ret = Image.FromStream(ms);
                }
                myConn.Close();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }


        // ### Valida Coordenadas de Carro
        public string CarrosFueraDeRM()
        {
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string nom = "";
            string reqSQL = "SELECT nombre FROM z_carros WHERE (carro_x NOT BETWEEN 300000 AND 400000) OR (carro_y NOT BETWEEN 6200000 AND 6400000)";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_tcarros in myResult.Tables[0].Rows)
                {
                    nom += r_tcarros["nombre"].ToString() + ",";
                }
                nom += "#";
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            nom = nom.Replace(",#", "");
            return nom;
        }

        //### Obtiene Valor de Grupo Alias
        public bool EnIncendio()
        {
            bool ret = false;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente FROM e_expedientes WHERE (codigo_principal=51 or codigo_principal=52 or codigo_principal=53 or codigo_principal=54) and activo=true";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    ret = true;
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }





        //############################
        //###   Entrega de Turno   ###
        //############################

        //# Obtiene Estado de Cada Carr0
        public DataSet Estado_Carro()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros.nombre As nombre, z_estado_carros.descripcion As estado, z_conductores.codigo_conductor As codigo, z_conductores.id_conductor As id_conductor, z_conductores.id_tipo_conductor As tipo_conductor, z_carros.observacion2 As observacion ";
            reqSQL += " FROM z_carros left JOIN z_estado_carros ON (z_carros.estado = z_estado_carros.id_estado) left JOIN z_conductores ON (z_carros.id_conductor = z_conductores.id_conductor) ";
            //# Se agrega el WHERE para omitir los carros de Apoyo Deshabilitados
            reqSQL += " WHERE (car_apoyo = 0) OR (car_apoyo > 0 AND habilitado = true) ";
            reqSQL += " ORDER BY z_carros.id_compania, z_carros.nombre";
            
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




        //### Estado del Material para Twitter
        public DataSet GetEstadosTwitter()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT nombre, estado, id_compania_orig ";
            reqSQL += "FROM z_carros ";
            reqSQL += "WHERE nombre != 'CRf' AND nombre != 'CRm' AND nombre != 'CRn' AND (car_apoyo = 0) OR (car_apoyo > 0 AND habilitado = true) ";
            reqSQL += "ORDER BY estado, id_compania_orig, nombre ";
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

        //### Asigna Ubicación de 6-13, 6-14 o 6-15
        public void SetDestino613(int idCarro, string ubicacion)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET ubicacion_613='" + ubicacion + "' WHERE id_carro=" + idCarro;
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

        public string GetParametroPrioridad(int id)
        {
            var myBase = new CnxBase();
            string reqSQL = "SELECT DESCRIPCION, VALOR FROM Z_CONFIG WHERE ID = " + id;
            string aa = "";
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow valor in myResult.Tables[0].Rows)
                {
                    aa = valor["VALOR"].ToString();
                }

                return aa;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public int UpdateParametroPrioridad(string valor, int id)
        {
            var myBase = new CnxBase();
            string reqSQL = "UPDATE Z_CONFIG SET VALOR = '" + valor + "' WHERE ID = " + id;
            int ret = 0;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);

                return ret;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public int InsertarDespachoAlarmas(int idExpediente, string alarma)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            //string reqSQL = "UPDATE z_carros SET destino_x = " + Convert.ToInt32(coor_carros[0]) + ", destino_y = " + Convert.ToInt32(coor_carros[1]) + " WHERE id_carro = " + id_carro;
            string reqSQL = "INSERT INTO DESPACHO_ALARMAS (ID_EXPEDIENTE, ALARMA) VALUES (" + idExpediente + ",'" + alarma + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }

        public DataSet GetDespachoAlarmas(int id)
        {
            var myBase = new CnxBase();
            string reqSQL = "SELECT ID_EXPEDIENTE, ALARMA FROM DESPACHO_ALARMAS WHERE ID_EXPEDIENTE = " + id;
            try
            {
                var myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public int BorrarDespachoAlarmaPorExpediente(int idExpediente, string alarma)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            //string reqSQL = "UPDATE z_carros SET destino_x = " + Convert.ToInt32(coor_carros[0]) + ", destino_y = " + Convert.ToInt32(coor_carros[1]) + " WHERE id_carro = " + id_carro;
            string reqSQL = "DELETE FROM DESPACHO_ALARMAS WHERE ID_EXPEDIENTE = " + idExpediente + " AND ALARMA = '" + alarma + "'";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                ret = myCommand.ExecuteNonQuery();
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return ret;
        }



        public void ActualizarEstadosCarros(int estadoCarro, int carro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE zs_estado_carro SET id_estado = " + estadoCarro + " WHERE id_carro = " + carro;
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


        ////###
        //public void ActualizarEstadosCarros(int estadoCarro, int carro)
        //{
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "UPDATE zs_estado_carro SET id_estado = " + estadoCarro + " WHERE id_carro = " + carro;
        //    try
        //    {
        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
        //        myCommand.ExecuteNonQuery();
        //        myBase.CloseConnection(myConn);
        //    }


        //    catch (Exception myErr)
        //    {
        //        throw (new Exception(myErr.ToString() + reqSQL));
        //    }
        //}


        //### Gestion de Carros
        public DataSet Getz_carrosDisponibles()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_carros where estado=1 order by id_compania_orig, nombre";
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


        //### Gestion de Carros Clave 0-11
        public DataSet Getz_carrosDisponibles011()
        {
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT * FROM z_carros where estado=1 order by id_compania_orig, nombre";
            //# Clave 0-11 Solo Bombas
            string reqSQL = "SELECT * FROM z_carros a INNER JOIN z_carros_virtual b ON a.id_carro = b.id_carro WHERE a.estado=1 AND b.id_grupo = 1 ORDER BY a.id_compania_orig, a.nombre";

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








        //### Obtener Carros de Apoyo
        public DataSet GetCarrosApoyo()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_carros WHERE car_apoyo > 0 ORDER BY car_apoyo";
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

        //### Asignar Nombre a Carro de Apoyo
        public void SetNomCarroApoyo(int idCarro, string strNom)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET nombre = '" + strNom + "' WHERE (id_carro=" + idCarro + ")";
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

        //### Asignar Tipo a Carro de Apoyo
        public void SetTipoCarroApoyo(int idCarro, int intTipo)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET id_tipo_carro = " + intTipo + " WHERE (id_carro=" + idCarro + ")";
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


        //### Asignar Compañía al Carro de Apoyo
        public void SetCiaCarroApoyo(int idCarro, int intCia)
        {
            //CnxBase myBase = new CnxBase();
            //string reqSQL = "UPDATE z_carros SET id_compania = " + intCia + ", id_compania_orig = " + intCia + " WHERE (id_carro=" + idCarro + ")";
            //try
            //{
            //    NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            //    NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
            //    myCommand.ExecuteNonQuery();
            //    myBase.CloseConnection(myConn);
            //}
            //catch (Exception myErr)
            //{
            //    throw (new Exception(myErr.ToString() + reqSQL));
            //}
        }


        //### Habilitar Carro de Apoyo
        public void SetHabilitaCarroApoyo(int idCarro, string booHabilita)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET habilitado = " + booHabilita + " WHERE (id_carro=" + idCarro + ")";
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

        //### Set Estado Carro de Apoyo
        public void SetEstadoCarroApoyo(int idCarro, int inEstado)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET estado = " + inEstado + " WHERE (id_carro=" + idCarro + ")";
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


        //### Habilitar Carro de Apoyo en Carros Virtual
        public void SetHabilitaCarroApoyoMatMayor(int idCarro, string booHabilita)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros_virtual SET rx_2_q = " + booHabilita + " WHERE (id_carro=" + idCarro + ")";
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





        public void HabilitarCarroZcarrosVirtualApoyo(int idCarro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros_virtual SET rx_2_q = false WHERE (id_carro=" + idCarro + ")";
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

        public void DesactivarCarroZcarrosVirtualApoyo(int idCarro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros_virtual SET rx_2_q = true WHERE (id_carro=" + idCarro + ")";
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

        public void HabilitarCarroApoyo(int idCarro, string etiqueta, int idCompania, int cx, int cy)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_carros SET eshabilitado = 1, esprestado = 1, nombre = '" + etiqueta + "', id_compania = " + idCompania + ", id_compania_orig = " + idCompania + ", carro_x = " + cx + ", carro_y = " + cy + ", carros_011 = false, gps=true WHERE (id_carro=" + idCarro + ")";
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


        //#######################################
        //###      Entrega de Carros Web      ###
        //#######################################
        public DataSet Estado_Carro_Web()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros.id_carro, z_carros.estado, NombreConductor(z_carros.id_conductor) As conductor, z_estado_carros.descripcion As motivo, z_estado_carros.color_web As color ";
            reqSQL += " FROM z_carros left JOIN z_estado_carros ON (z_carros.estado = z_estado_carros.id_estado) ";
            //# Se agrega el WHERE para omitir los carros de Apoyo Deshabilitados
            reqSQL += " WHERE (car_apoyo = 0) OR (car_apoyo > 0 AND habilitado = true) ";
            reqSQL += " ORDER BY z_carros.id_compania, z_carros.nombre";

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