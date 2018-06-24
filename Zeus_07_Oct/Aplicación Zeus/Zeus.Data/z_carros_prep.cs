using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Zeus.Data
{
    public class z_carros_prep
    {
        

        #region Miembros

        private System.Int32 id_carro;
        private System.String nombre;
        private System.Int32 id_compania;
        private System.Int32 estado;
        private System.Int32 id_conductor;
        private System.Int32 id_compania_orig;
        private System.String observacion2;
        private System.String op_observacion2;
       
        #endregion

        #region Propiedades

        public System.Int32 Id_carro
        {
            get
            {
                return id_carro;
            }
            set
            {
                id_carro = value;
            }
        }

        public System.String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public System.Int32 Id_compania
        {
            get
            {
                return id_compania;
            }
            set
            {
                id_compania = value;
            }
        }

        public System.Int32 Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public System.Int32 Id_conductor
        {
            get 
            {
                return id_conductor; 
            }
            set 
            {
                id_conductor = value;
            }
        }

        public System.Int32 Id_compania_orig
        {
            get
            {
                return id_compania_orig;
            }
            set
            {
                id_compania_orig = value;
            }
        }

        public System.String Observacion2
        {
            get
            {
                return observacion2;
            }
            set
            {
                observacion2 = value;
            }
        }

        public System.String Op_observacion2
        {
            get
            {
                return op_observacion2;
            }
            set
            {
                op_observacion2 = value;
            }
        }

        #endregion
        

        #region Constructor

        public z_carros_prep()
        {
        }


        /// <summary>
        /// z_carros_prep
        /// </summary>
        public z_carros_prep(System.Int32 id_carro, System.String nombre, System.Int32 id_compania, System.Int32 estado, System.Int32 id_conductor, System.Int32 id_compania_orig, System.String observacion2, System.String op_observacion2)
        {
            this.id_carro = id_carro;
            this.nombre = nombre;
            this.id_compania = id_compania;
            this.estado = estado;
            this.id_conductor = id_conductor;
            this.Id_compania_orig = id_compania_orig;
            this.observacion2 = observacion2;
            this.op_observacion2 = op_observacion2;
        }

        #endregion


        #region Metodos

        //# Insert Rec z_carros_prep
        public void insertZcarrosPrep(int idCarro, string strNombre, int idCompania, int idEstado, int idConductor, int idCompaniaOrig, string strObservacion, string strOpObserv)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO z_carros_prep (id_carro, nombre, id_compania, estado, id_conductor, id_compania_orig, observacion2, op_observacion2) VALUES (" + idCarro + ",'" + strNombre + "'," + idCompania + "," + idEstado + "," + idConductor + "," + idCompaniaOrig + ",'" + strObservacion + "','" + strOpObserv  + "')";
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

        //# Eliminar Carro Seleccionado en z_carros_prep
        public int EliminarCarroPrep(string strCarro)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "DELETE FROM z_carros_prep WHERE nombre='" + strCarro +"'";
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

        //# Eliminar Todos los Conductores en z_carros_prep
        public int EliminarTosLosConductores()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "DELETE FROM z_carros_prep";
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


        //# Obtiene Estado de Cada Carr0
        public DataSet Estado_Carro_Prep()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT z_carros_prep.nombre As nombre, z_estado_carros.descripcion As estado, z_conductores.codigo_conductor As codigo, z_conductores.id_conductor As id_conductor, z_conductores.id_tipo_conductor As tipo_conductor, z_carros_prep.observacion2 As observacion ";
            reqSQL += " FROM z_carros_prep left JOIN z_estado_carros ON (z_carros_prep.estado = z_estado_carros.id_estado) left JOIN z_conductores ON (z_carros_prep.id_conductor = z_conductores.id_conductor) ORDER BY z_carros_prep.id_compania, z_carros_prep.nombre";

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


        //# Obtener Carros Preparados
        public DataSet CarrosPreparados()
        {
            z_carros myz_carros = new z_carros();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_carro, nombre, estado, id_conductor, observacion2 ";
            reqSQL += " FROM z_carros_prep";

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


        //# Verificar si el carro ya está preparado
        public int CarroEstaPreparado(int id_carro)
        {
            int contador = 0;
            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();
            string reqSQL = "SELECT count(*) as contador FROM z_carros_prep WHERE id_carro = " + id_carro + "";
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


        //# Asignación Masiva de Conductores
        public int AsignacionMasivaDeConductores()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "";
            reqSQL += "UPDATE z_carros SET estado=z_carros_prep.estado, id_conductor=z_carros_prep.id_conductor, observacion2=z_carros_prep.observacion2 ";
            reqSQL += "FROM z_carros_prep ";
            reqSQL += "WHERE z_carros.id_carro = z_carros_prep.id_carro";
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


        #endregion

    }
}



#region Respaldo

//namespace Zeus.Data
//{
//    public class z_carros_prep
//    {


//        #region Miembros

//        private System.Int32 _id_carro;
//        private System.String _nombre;
//        private System.Int32 _id_tipo_carro;
//        private System.Int32 _id_compania;
//        private System.Int32 _estado;
//        private int _id_tipo_alternativo;
//        private System.Boolean _periferia;
//        private string _ubicacion_613;
//        //public string Evento { get; set; }
//        //public string Observacion2 { get; set; }
//        //public string OpObservacion2 { get; set; }

//        #endregion

//        #region Propiedades

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

//        public int id_tipo_alternativo
//        {
//            get
//            {
//                return _id_tipo_alternativo;
//            }
//            set
//            {
//                _id_tipo_alternativo = value;
//            }
//        }

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

//        public string ubicacion_613
//        {
//            get
//            {
//                return _ubicacion_613;
//            }
//            set
//            {
//                _ubicacion_613 = value;
//            }
//        }

//        #endregion


//        #region Constructor

//        public z_carros_prep()
//        {
//        }



//        /// <summary>
//        /// z_carros_prep
//        /// </summary>
//        public z_carros_prep(System.Int32 id_carro, System.String nombre, System.Int32 id_tipo_carro, System.Int32 id_compania, System.Int32 estado, int id_tipo_alternativo, System.Boolean periferia, System.String ubicacion_613)
//        {
//            this.id_carro = id_carro;
//            this.nombre = nombre;
//            this.id_tipo_carro = id_tipo_carro;
//            this.id_compania = id_compania;
//            this.estado = estado;
//            this.id_tipo_alternativo = id_tipo_alternativo;
//            this.periferia = periferia;
//            this.ubicacion_613 = ubicacion_613;
//        }

//        #endregion
//    }
//}


#endregion