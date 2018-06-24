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
    /// z_conductores
    /// </summary>
    public class z_conductores
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_conductor;
        public System.Int32 id_conductor
        {
            get
            {
                return _id_conductor;
            }
            set
            {
                _id_conductor = value;
            }
        }

        private System.Int32 _id_tipo_conductor;
        public System.Int32 id_tipo_conductor
        {
            get
            {
                return _id_tipo_conductor;
            }
            set
            {
                _id_tipo_conductor = value;
            }
        }

        private System.Int32 _id_cuart_vol;
        public System.Int32 id_cuart_vol
        {
            get
            {
                return _id_cuart_vol;
            }
            set
            {
                _id_cuart_vol = value;
            }
        }

        private System.String _tipo_licencia;
        public System.String tipo_licencia
        {
            get
            {
                return _tipo_licencia;
            }
            set
            {
                _tipo_licencia = value;
            }
        }

        private System.DateTime _licencia_vence;
        public System.DateTime licencia_vence
        {
            get
            {
                return _licencia_vence;
            }
            set
            {
                _licencia_vence = value;
            }
        }

        private System.String _codigo_conductor;
        public System.String codigo_conductor
        {
            get
            {
                return _codigo_conductor;
            }
            set
            {
                _codigo_conductor = value;
            }
        }

        private System.String _id_carros;
        public System.String id_carros
        {
            get
            {
                return _id_carros;
            }
            set
            {
                _id_carros = value;
            }
        }

        private System.Boolean _disponible;
        public System.Boolean disponible
        {
            get
            {
                return _disponible;
            }
            set
            {
                _disponible = value;
            }
        }

        private bool _temporal;

        public bool temporal
        {
            get { return _temporal; }
            set { _temporal = value; }
        }

        #endregion

        /// <summary>
        /// z_conductores
        /// </summary>
        public z_conductores()
        {
        }


        /// <summary>
        /// z_conductores
        /// </summary>
        public z_conductores(System.Int32 id_conductor, System.Int32 id_tipo_conductor, System.Int32 id_cuart_vol, System.String tipo_licencia, System.DateTime licencia_vence, System.String codigo_conductor, System.String id_carros, System.Boolean disponible, bool temporal)
        {
            this.id_conductor = id_conductor;
            this.id_tipo_conductor = id_tipo_conductor;
            this.id_cuart_vol = id_cuart_vol;
            this.tipo_licencia = tipo_licencia;
            this.licencia_vence = licencia_vence;
            this.codigo_conductor = codigo_conductor;
            this.id_carros = id_carros;
            this.disponible = disponible;
            this.temporal = temporal;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_conductores(z_conductores myz_conductores)
        {
            CnxBase myBase = new CnxBase();
            int id = 0;
            string reqSQL = "INSERT INTO z_conductores (id_tipo_conductor,id_cuart_vol,tipo_licencia,licencia_vence,codigo_conductor,id_carros,disponible, temporal) VALUES (" + myz_conductores.id_tipo_conductor + "," + myz_conductores.id_cuart_vol + ",'" + myz_conductores.tipo_licencia + "','" + myz_conductores.licencia_vence + "','" + myz_conductores.codigo_conductor + "','" + myz_conductores.id_carros + "'," + myz_conductores.disponible + "," + myz_conductores.temporal + ");select currval('z_conductores_id_conductor_seq');";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                id = Convert.ToInt32(myCommand.ExecuteScalar());
                myz_conductores.id_conductor = id;
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
        public void deletez_conductores(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_conductores WHERE (id_conductor = " + myID + ")", myConn);
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
        public void modifyz_conductores(z_conductores myz_conductores)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE z_conductores SET id_conductor=" + myz_conductores.id_conductor + ",id_tipo_conductor=" + myz_conductores.id_tipo_conductor + ",id_cuart_vol=" + myz_conductores.id_cuart_vol + ",tipo_licencia='" + myz_conductores.tipo_licencia + "',licencia_vence='" + myz_conductores.licencia_vence + "',codigo_conductor='" + myz_conductores.codigo_conductor + "',id_carros='" + myz_conductores.id_carros + "',disponible=" + myz_conductores.disponible + ", temporal=" + myz_conductores.temporal + " WHERE (id_conductor=" + myz_conductores.id_conductor + ")";
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
        public z_conductores getObjectz_conductores(System.Int32 myID)
        {
            z_conductores myz_conductores = new z_conductores();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_conductor,id_tipo_conductor,id_cuart_vol,tipo_licencia,licencia_vence,codigo_conductor,id_carros,disponible,temporal FROM z_conductores WHERE (id_conductor=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_conductores.id_conductor = Convert.ToInt32(myReader[0]);
                    myz_conductores.id_tipo_conductor = Convert.ToInt32(myReader[1]);
                    myz_conductores.id_cuart_vol = Convert.ToInt32(myReader[2]);
                    myz_conductores.tipo_licencia = myReader[3].ToString();
                    myz_conductores.licencia_vence = Convert.ToDateTime(myReader[4]);
                    myz_conductores.codigo_conductor = myReader[5].ToString();
                    myz_conductores.id_carros = myReader[6].ToString();
                    myz_conductores.disponible = Convert.ToBoolean(myReader[7]);
                    myz_conductores.temporal = Convert.ToBoolean(myReader[8]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_conductores;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_conductores()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_conductores where temporal=false";
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

        public DataSet GetListz_conductores()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_conductor, apellidos||' '||nombres as nombre_completo from z_voluntarios, z_conductores where id_tipo_conductor=2 and id_cuart_vol=id_voluntario UNION select id_conductor, apellidos||' '||nombres as nombre_completo from z_cuarteleros, z_conductores where id_tipo_conductor=1 and id_cuart_vol=id_cuartelero";
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

        //### Listado de Conductores Bloqueados
        public DataSet GetListz_conductoresBloqueados()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_conductor, apellidos||' '||nombres as nombre_completo, codigo_conductor FROM z_voluntarios, z_conductores WHERE id_tipo_conductor=2 AND id_cuart_vol=id_voluntario AND disponible=false UNION SELECT id_conductor, apellidos||' '||nombres as nombre_completo, codigo_conductor FROM z_cuarteleros, z_conductores WHERE id_tipo_conductor=1 AND id_cuart_vol=id_cuartelero AND disponible=false ORDER BY nombre_completo";
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


        public z_conductores getObjectz_conductores(string codigo)
        {
            z_conductores myz_conductores = new z_conductores();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_conductor,id_tipo_conductor,id_cuart_vol,tipo_licencia,licencia_vence,codigo_conductor,id_carros,disponible,temporal FROM z_conductores WHERE (codigo_conductor='" + codigo + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_conductores.id_conductor = Convert.ToInt32(myReader[0]);
                    myz_conductores.id_tipo_conductor = Convert.ToInt32(myReader[1]);
                    myz_conductores.id_cuart_vol = Convert.ToInt32(myReader[2]);
                    myz_conductores.tipo_licencia = myReader[3].ToString();
                    myz_conductores.licencia_vence = Convert.ToDateTime(myReader[4]);
                    myz_conductores.codigo_conductor = myReader[5].ToString();
                    myz_conductores.id_carros = myReader[6].ToString();
                    myz_conductores.disponible = Convert.ToBoolean(myReader[7]);
                    myz_conductores.temporal = Convert.ToBoolean(myReader[8]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_conductores;
        }

        public bool EstaRegistrado(int id_cuart_vol)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_cuart_vol FROM z_conductores WHERE (id_cuart_vol='" + id_cuart_vol + "')";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public DataSet Getz_conductoresCarro(int id_carro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_conductor, id_tipo_conductor, apellidos||' '||nombres as nombre_completo,disponible from z_voluntarios, z_conductores where en_lista(id_carros,"+ id_carro+/*trim(both ',' from substring(id_carros, '.?{0}.?'))='{0}'*/ ")=true and id_tipo_conductor=2 and id_cuart_vol=id_voluntario UNION select id_conductor, id_tipo_conductor, apellidos||' '||nombres as nombre_completo, disponible from z_cuarteleros, z_conductores where en_lista(id_carros,"+id_carro/* trim(both ',' from substring(id_carros, '.?{0}.?'))='{0}'*/+")=true and id_tipo_conductor=1 and id_cuart_vol=id_cuartelero order by nombre_completo";
            reqSQL = string.Format(reqSQL, id_carro.ToString());
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

        public DataSet GetListz_conductores(int id_compania)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_conductor, apellidos||' '||nombres as nombre_completo from z_voluntarios, z_conductores where id_tipo_conductor=2 and id_cuart_vol=id_voluntario and id_compania=" + id_compania + " UNION select id_conductor, apellidos||' '||nombres as nombre_completo from z_cuarteleros, z_conductores where id_tipo_conductor=1 and id_cuart_vol=id_cuartelero and id_compania=" + id_compania;
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
        //public DataSet GetNombreConductor(int id_conductor)
        //{
        //    CnxBase myBase = new CnxBase();
        //    string reqSQL = "select zv.apellidos || '' || zv.nombres as nombre_voluntario from z_conductores zc left join z_voluntarios zv on zv.id_voluntario = zc.id_cuart_vol where zc.id_conductor = " + id_conductor;
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

        public DataSet GetNombreConductor(int id_conductor, int id_tipo_conductor)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "";
            if (id_tipo_conductor == 1)
            {
                reqSQL = "select zv.apellidos || ' ' || zv.nombres as nombre_voluntario from z_conductores zc left join z_cuarteleros zv on zv.id_cuartelero = zc.id_cuart_vol where zc.id_conductor = " + id_conductor;
            }
            else
            {
                reqSQL = "select zv.apellidos || ' ' || zv.nombres as nombre_voluntario from z_conductores zc left join z_voluntarios zv on zv.id_voluntario = zc.id_cuart_vol where zc.id_conductor = " + id_conductor;
            }

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

        //### Obtiene Nombre de Conductorpor ID_CONDUCTOR 
        public string Getz_NombreConductor(int IdConductor)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT NombreConductor(" + IdConductor + ")";
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



    }
}
