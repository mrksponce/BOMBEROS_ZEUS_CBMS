using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using Npgsql;
using NpgsqlTypes;
using System.Collections;
using System.Collections.Generic;
using Zeus.Data;

//namespace Zeus.Data
namespace PreparaMaterialMayor
{
    public class z_carros_config
    {
       
        
        
//        #region ***** Campos y propiedades *****

//        public string Evento { get; set; }
//        public string Observacion2 { get; set; }
//        public string OpObservacion2 { get; set; }

//        //private string coordenadas_carro;

//        //public string Coordenadas_carro
//        //{
//        //    get { return coordenadas_carro; }
//        //    set { coordenadas_carro = value; }
//        //}

//        //public bool Carros_011 { get; set; }

//        private System.Int32 _id_carro;
//        public System.Int32 id_carro
//        {
//            get
//            {
//                return _id_carro;
//            }
//            set
//            {
//                _id_carro = value;
//            }
//        }

//        private System.String _nombre;
//        public System.String nombre
//        {
//            get
//            {
//                return _nombre;
//            }
//            set
//            {
//                _nombre = value;
//            }
//        }

//        private System.Int32 _id_tipo_carro;
//        public System.Int32 id_tipo_carro
//        {
//            get
//            {
//                return _id_tipo_carro;
//            }
//            set
//            {
//                _id_tipo_carro = value;
//            }
//        }

//        private System.Int32 _id_compania;
//        public System.Int32 id_compania
//        {
//            get
//            {
//                return _id_compania;
//            }
//            set
//            {
//                _id_compania = value;
//            }
//        }

//        private System.Int32 _estado;
//        public System.Int32 estado
//        {
//            get
//            {
//                return _estado;
//            }
//            set
//            {
//                _estado = value;
//            }
//        }

//        private int _id_tipo_carro_alternativo;
//        public int id_tipo_alternativo
//        {
//            get { return _id_tipo_carro_alternativo; }
//            set { _id_tipo_carro_alternativo = value; }
//        }

//        //private int _id_conductor;
//        //public int id_conductor
//        //{
//        //    get { return _id_conductor; }
//        //    set { _id_conductor = value; }
//        //}

//        //private int _foto;

//        //public int foto
//        //{
//        //    get { return _foto; }
//        //    set { _foto = value; }
//        //}

//        //private DateTime _fecha_fuera_servicio;
//        //public DateTime fecha_fuera_servicio
//        //{
//        //    get { return _fecha_fuera_servicio; }
//        //    set { _fecha_fuera_servicio = value; }
//        //}
        
//        //private string _motivo_fuera_servicio;
//        //public string motivo_fuera_servicio
//        //{
//        //    get { return _motivo_fuera_servicio; }
//        //    set { _motivo_fuera_servicio = value; }
//        //}

//        //private int _id_compania_orig;
//        //public int id_compania_orig
//        //{
//        //    get { return _id_compania_orig; }
//        //    set { _id_compania_orig = value; }
//        //}

//        private System.Boolean _periferia;
//        public System.Boolean periferia
//        {
//            get
//            {
//                return _periferia;
//            }
//            set
//            {
//                _periferia = value;
//            }
//        }

//        private string _ubicacion_613;
//        public string ubicacion_613
//        {
//            get { return _ubicacion_613; }
//            set { _ubicacion_613 = value; }
//        }

//        #endregion

//        /// <summary>
//        /// z_carros_config
//        /// </summary>
        
//        public z_carros_config()
//        {
//        }


//        /// <summary>
//        /// z_carros_config
//        /// </summary>
//        public z_carros_config(System.Int32 id_carro, System.String nombre, System.Int32 id_tipo_carro, System.Int32 id_compania, System.Int32 estado, int id_tipo_carro_alternativo, System.Boolean periferia, System.String ubicacion_613)
//        {
//            this.id_carro = id_carro;
//            this.nombre = nombre;
//            this.id_tipo_carro = id_tipo_carro;
//            this.id_compania = id_compania;
//            this.estado = estado;
//            this.id_tipo_alternativo = id_tipo_carro_alternativo;
//            this.periferia = periferia;
//            this.ubicacion_613 = ubicacion_613;
//        }





//        //##########################################################
//        //###   Prepara Material Mayor para Puesta en servicio   ###
//        //##########################################################

//        //# Obtiene Estado de Cada Carr0
//        public DataSet Estado_Carro_Config()
//        {
//            z_carros_config myz_carros = new z_carros_config();
//            CnxBase myBase = new CnxBase();
//            string reqSQL = "SELECT z_carros.nombre As nombre, z_estado_carros.descripcion As estado, z_conductores.codigo_conductor As codigo, z_conductores.id_conductor As id_conductor, z_conductores.id_tipo_conductor As tipo_conductor, z_carros.observacion2 As observacion ";
//            reqSQL += " FROM z_carros_config left JOIN z_estado_carros ON (z_carros.estado = z_estado_carros.id_estado) left JOIN z_conductores ON (z_carros.id_conductor = z_conductores.id_conductor) ORDER BY z_carros.id_compania, z_carros.nombre";

//            try
//            {
//                CnxBase myD4MCnx = new CnxBase();
//                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
//                return myResult;
//            }
//            catch (Exception myErr)
//            {
//                throw (new Exception(myErr.ToString() + reqSQL));
//            }
//        }













//        public z_carros_config getObjectz_carrosConfig(System.Int32 myID)
//        {
//            z_carros myz_carros = new z_carros();
//            CnxBase myBase = new CnxBase();
//            string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011, evento, observacion2, op_observacion2 FROM z_carros_config WHERE (id_carro=" + myID + ")";
//            try
//            {
//                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
//                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
//                NpgsqlDataReader myReader = myCommand.ExecuteReader();
//                if (myReader.Read())
//                {
//                    myz_carros.id_carro = Convert.ToInt32(myReader[0]);
//                    myz_carros.nombre = myReader[1].ToString();
//                    myz_carros.id_tipo_carro = Convert.ToInt32(myReader[2]);
//                    myz_carros.id_compania = Convert.ToInt32(myReader[3]);
//                    myz_carros.estado = Convert.ToInt32(myReader[4]);
//                    myz_carros.id_tipo_alternativo = Convert.ToInt32(myReader[5]);
//                    myz_carros.id_conductor = Convert.ToInt32(myReader[6]);
//                    myz_carros.foto = myReader[7] == DBNull.Value ? 0 : Convert.ToInt32(myReader[7]);
//                    myz_carros.fecha_fuera_servicio = Convert.ToDateTime(myReader[8]);
//                    myz_carros.motivo_fuera_servicio = myReader[9].ToString();
//                    myz_carros.id_compania_orig = Convert.ToInt32(myReader[10]);
//                    myz_carros.periferia = Convert.ToBoolean(myReader[11]);
//                    myz_carros.Carros_011 = myReader[12] == null ? Convert.ToBoolean("false") : Convert.ToBoolean(myReader[12]);
//                    myz_carros.Evento = myReader[13].ToString();
//                    myz_carros.Observacion2 = myReader[14].ToString();
//                    myz_carros.OpObservacion2 = myReader[15].ToString();
//                }
//                myBase.CloseConnection(myConn);
//            }
//            catch (Exception myErr)
//            {
//                throw (new Exception(myErr.ToString() + reqSQL));
//            }
//            return myz_carros;
//        }


//        //public z_carros getObjectz_carrosConfig(string myID)
//        //{
//        //    z_carros myz_carros = new z_carros();
//        //    CnxBase myBase = new CnxBase();
//        //    string reqSQL = "SELECT id_carro,nombre,id_tipo_carro,id_compania,estado, id_tipo_alternativo, id_conductor,foto,fecha_fuera_servicio,motivo_fuera_servicio,id_compania_orig,periferia, carros_011, evento, observacion2, op_observacion2 FROM z_carros_config WHERE (nombre='" + myID + "')";
//        //    try
//        //    {
//        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
//        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
//        //        NpgsqlDataReader myReader = myCommand.ExecuteReader();
//        //        if (myReader.Read())
//        //        {
//        //            myz_carros.id_carro = Convert.ToInt32(myReader[0]);
//        //            myz_carros.nombre = myReader[1].ToString();
//        //            myz_carros.id_tipo_carro = Convert.ToInt32(myReader[2]);
//        //            myz_carros.id_compania = Convert.ToInt32(myReader[3]);
//        //            myz_carros.estado = Convert.ToInt32(myReader[4]);
//        //            myz_carros.id_tipo_alternativo = Convert.ToInt32(myReader[5]);
//        //            myz_carros.id_conductor = Convert.ToInt32(myReader[6]);
//        //            myz_carros.foto = myReader[7] == DBNull.Value ? 0 : Convert.ToInt32(myReader[7]);
//        //            myz_carros.fecha_fuera_servicio = Convert.ToDateTime(myReader[8]);
//        //            myz_carros.motivo_fuera_servicio = myReader[9].ToString();
//        //            myz_carros.id_compania_orig = Convert.ToInt32(myReader[10]);
//        //            myz_carros.periferia = Convert.ToBoolean(myReader[11]);
//        //            myz_carros.Carros_011 = myReader[12] == null ? Convert.ToBoolean("false") : Convert.ToBoolean(myReader[12]);
//        //            myz_carros.Evento = myReader[13].ToString();
//        //            myz_carros.Observacion2 = myReader[14].ToString();
//        //            myz_carros.OpObservacion2 = myReader[15].ToString();
//        //        }
//        //        myBase.CloseConnection(myConn);
//        //    }
//        //    catch (Exception myErr)
//        //    {
//        //        throw (new Exception(myErr.ToString() + reqSQL));
//        //    }
//        //    return myz_carros;
//        //}


//        public DataSet Getz_carros_Config()
//        {
//            CnxBase myBase = new CnxBase();
//            string reqSQL = "SELECT * FROM z_carros_config order by nombre";
//            try
//            {
//                CnxBase myD4MCnx = new CnxBase();
//                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
//                return myResult;
//            }
//            catch (Exception myErr)
//            {
//                throw (new Exception(myErr.ToString() + reqSQL));
//            }
//        }


//        public int ActualizarObservacionesCarros_Config(string observacion, string operadora, int id_carro)
//        {
//            int act = 0;
//            CnxBase myBase = new CnxBase();
//            string reqSQL = "UPDATE z_carros_config SET observacion2 = '" + observacion + "', op_observacion2 = '" + operadora + "' WHERE id_carro = " + id_carro + "";
//            try
//            {
//                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
//                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
//                act = myCommand.ExecuteNonQuery();
//                myBase.CloseConnection(myConn);
//            }
//            catch (Exception myErr)
//            {
//                throw (new Exception(myErr.ToString() + reqSQL));
//            }
//            return act;
//        }


//        //public void modifyz_carros_config(z_carros myz_carros)
//        //{
//        //    CnxBase myBase = new CnxBase();
//        //    string reqSQL = "UPDATE z_carros_config SET id_carro=" + myz_carros.id_carro + ",nombre='" + myz_carros.nombre + "',id_tipo_carro=" + myz_carros.id_tipo_carro + ",id_compania=" + myz_carros.id_compania + ",estado=" + myz_carros.estado + ", id_tipo_alternativo=" + myz_carros.id_tipo_alternativo + ", id_conductor=" + myz_carros.id_conductor + ", fecha_fuera_servicio='" + myz_carros.fecha_fuera_servicio.ToString() + "', motivo_fuera_servicio='" + myz_carros.motivo_fuera_servicio + "',id_compania_orig=" + myz_carros.id_compania_orig + " WHERE (id_carro=" + myz_carros.id_carro + ")";
//        //    try
//        //    {
//        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
//        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
//        //        myCommand.ExecuteNonQuery();
//        //        myBase.CloseConnection(myConn);
//        //    }
//        //    catch (Exception myErr)
//        //    {
//        //        throw (new Exception(myErr.ToString() + reqSQL));
//        //    }
//        //}


//        public DataSet GetCarrosTipo_Config(int id)
//        {
//            CnxBase myBase = new CnxBase();
//            string reqSQL = "SELECT * FROM z_carros_config where id_tipo_carro=" + id + " order by id_compania_orig";
//            try
//            {
//                CnxBase myD4MCnx = new CnxBase();
//                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
//                return myResult;
//            }
//            catch (Exception myErr)
//            {
//                throw (new Exception(myErr.ToString() + reqSQL));
//            }
//        }

//        //public int GetMaxCarros_Config()
//        //{
//        //    z_carros myz_carros = new z_carros();
//        //    CnxBase myBase = new CnxBase();
//        //    int max = 0;
//        //    string reqSQL = "SELECT max(count) FROM (select count(id_tipo_carro) FROM z_carros_config GROUP BY id_tipo_carro) as count";
//        //    try
//        //    {
//        //        NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
//        //        NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
//        //        max = Convert.ToInt32(myCommand.ExecuteScalar());

//        //        myBase.CloseConnection(myConn);
//        //    }
//        //    catch (Exception myErr)
//        //    {
//        //        throw (new Exception(myErr.ToString() + reqSQL));
//        //    }
//        //    return max;
//        //}


    }
}
