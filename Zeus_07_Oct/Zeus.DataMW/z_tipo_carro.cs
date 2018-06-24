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
    /// z_tipo_carro
    /// </summary>
    public class z_tipo_carro
    {
        #region ***** Campos y propiedades ***** 

        public Int32 id_tipo_carro { get; set; }

        public String tipo_carro_letra { get; set; }

        public String tipo_carro_descripcion { get; set; }

        #endregion

        /// <summary>
        /// z_tipo_carro
        /// </summary>
        public z_tipo_carro()
        {
        }


        /// <summary>
        /// z_tipo_carro
        /// </summary>
        public z_tipo_carro(Int32 id_tipo_carro, String tipo_carro_letra, String tipo_carro_descripcion)
        {
            this.id_tipo_carro = id_tipo_carro;
            this.tipo_carro_letra = tipo_carro_letra;
            this.tipo_carro_descripcion = tipo_carro_descripcion;
        }

        #region *****persistance managing methods

        //Not primary key detected on the corresponding table. Methods add/modify & remove could not be created. 

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_tipo_carro()
        {
            string reqSQL = "SELECT * FROM z_tipo_carro order by orden";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public DataSet Getz_tipo_carro_despacho()
        {
            string reqSQL = "SELECT * FROM z_tipo_carro order by id_tipo_carro";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                return myResult;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
        }

        public z_tipo_carro getObjectz_tipo_carro(Int32 myID)
        {
            z_tipo_carro myz_tipo_carro = new z_tipo_carro();
            CnxBase myBase = new CnxBase();
            string reqSQL =
                "SELECT id_tipo_carro,tipo_carro_letra,tipo_carro_descripcion FROM z_tipo_carro WHERE (id_tipo_carro=" +
                myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_tipo_carro.id_tipo_carro = Convert.ToInt32(myReader[0]);
                    myz_tipo_carro.tipo_carro_letra = Convert.ToString(myReader[1]);
                    myz_tipo_carro.tipo_carro_descripcion = Convert.ToString(myReader[2]);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return myz_tipo_carro;
        }

        #endregion

        public int getCantidad()
        {
            int cant = 0;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT count(id_tipo_carro) from z_tipo_carro";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    cant = (int) myReader.GetInt64(0);
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return cant;
        }
    }
}