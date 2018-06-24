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

namespace Zeus.Data
{
    /// <summary>
    /// z_voluntarios
    /// </summary>
    public class z_voluntarios
    {

        #region ***** Campos y propiedades *****

        private System.Int32 _id_voluntario;
        public System.Int32 id_voluntario
        {
            get
            {
                return _id_voluntario;
            }
            set
            {
                _id_voluntario = value;
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

        private System.String _nombres;
        public System.String nombres
        {
            get
            {
                return _nombres;
            }
            set
            {
                _nombres = value;
            }
        }

        private System.String _apellidos;
        public System.String apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
            }
        }

        private System.String _rut;
        public System.String rut
        {
            get
            {
                return _rut;
            }
            set
            {
                _rut = value;
            }
        }

        private System.String _direccion;
        public System.String direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        private System.DateTime _fecha_nacimiento;
        public System.DateTime fecha_nacimiento
        {
            get
            {
                return _fecha_nacimiento;
            }
            set
            {
                _fecha_nacimiento = value;
            }
        }

        private System.DateTime _ingreso;
        public System.DateTime ingreso
        {
            get
            {
                return _ingreso;
            }
            set
            {
                _ingreso = value;
            }
        }

        private System.Int32 _num_llamado;
        public System.Int32 num_llamado
        {
            get
            {
                return _num_llamado;
            }
            set
            {
                _num_llamado = value;
            }
        }

        private System.String _comuna;
        public System.String comuna
        {
            get
            {
                return _comuna;
            }
            set
            {
                _comuna = value;
            }
        }

        private System.String _telefono;
        public System.String telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        private System.String _celular;
        public System.String celular
        {
            get
            {
                return _celular;
            }
            set
            {
                _celular = value;
            }
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
        /// z_voluntarios
        /// </summary>
        public z_voluntarios()
        {
        }


        /// <summary>
        /// z_voluntarios
        /// </summary>
        public z_voluntarios(System.Int32 id_voluntario, System.Int32 id_compania, System.String nombres, System.String apellidos, System.String rut, System.String direccion, System.DateTime fecha_nacimiento, System.DateTime ingreso, System.Int32 num_llamado, System.String comuna, System.String telefono, System.String celular)
        {
            this.id_voluntario = id_voluntario;
            this.id_compania = id_compania;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.rut = rut;
            this.direccion = direccion;
            this.fecha_nacimiento = fecha_nacimiento;
            this.ingreso = ingreso;
            this.num_llamado = num_llamado;
            this.comuna = comuna;
            this.telefono = telefono;
            this.celular = celular;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void addz_voluntarios(z_voluntarios myz_voluntarios, string foto)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL;
            
            //#f
            //reqSQL = "INSERT INTO z_voluntarios (id_compania,nombres,apellidos,rut,direccion,fecha_nacimiento,ingreso,num_llamado,comuna,telefono,celular) VALUES (" + myz_voluntarios.id_compania + ",'" + myz_voluntarios.nombres + "','" + myz_voluntarios.apellidos + "','" + myz_voluntarios.rut + "','" + myz_voluntarios.direccion + "','" + myz_voluntarios.fecha_nacimiento + "','" + myz_voluntarios.ingreso + "'," + myz_voluntarios.num_llamado + ",'" + myz_voluntarios.comuna + "','" + myz_voluntarios.telefono + "','" + myz_voluntarios.celular + "')";
            reqSQL = "INSERT INTO z_voluntarios (id_compania,nombres,apellidos,rut,direccion,fecha_nacimiento,ingreso,num_llamado,comuna,telefono,celular,urlimagen) VALUES (" + myz_voluntarios.id_compania + ",'" + myz_voluntarios.nombres + "','" + myz_voluntarios.apellidos + "','" + myz_voluntarios.rut + "','" + myz_voluntarios.direccion + "','" + myz_voluntarios.fecha_nacimiento + "','" + myz_voluntarios.ingreso + "'," + myz_voluntarios.num_llamado + ",'" + myz_voluntarios.comuna + "','" + myz_voluntarios.telefono + "','" + myz_voluntarios.celular + "','" + myz_voluntarios.urlimagen + "')";

            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);

                //#f  Comentar este IF
                /*if (foto!=null)
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

                    reqSQL = "INSERT INTO z_voluntarios (id_compania,nombres,apellidos,rut,direccion,fecha_nacimiento,ingreso,num_llamado,comuna,telefono,celular, foto) VALUES (" + myz_voluntarios.id_compania + ",'" + myz_voluntarios.nombres + "','" + myz_voluntarios.apellidos + "','" + myz_voluntarios.rut + "','" + myz_voluntarios.direccion + "','" + myz_voluntarios.fecha_nacimiento + "','" + myz_voluntarios.ingreso + "'," + myz_voluntarios.num_llamado + ",'" + myz_voluntarios.comuna + "','" + myz_voluntarios.telefono + "','" + myz_voluntarios.celular + "', "+noid+")";

                }*/

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
        public void deletez_voluntarios(int myID)
        {
            CnxBase myBase = new CnxBase();
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_voluntarios WHERE (id_voluntario = " + myID + ")", myConn);
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
        public void modifyz_voluntarios(z_voluntarios myz_voluntarios, string foto)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL;
                
            //#f
            //reqSQL = "UPDATE z_voluntarios SET id_voluntario=" + myz_voluntarios.id_voluntario + ",id_compania=" + myz_voluntarios.id_compania + ",nombres='" + myz_voluntarios.nombres + "',apellidos='" + myz_voluntarios.apellidos + "',rut='" + myz_voluntarios.rut + "',direccion='" + myz_voluntarios.direccion + "',fecha_nacimiento='" + myz_voluntarios.fecha_nacimiento + "',ingreso='" + myz_voluntarios.ingreso + "',num_llamado=" + myz_voluntarios.num_llamado + ",comuna='" + myz_voluntarios.comuna + "',telefono='" + myz_voluntarios.telefono + "',celular='" + myz_voluntarios.celular + "' WHERE (id_voluntario=" + myz_voluntarios.id_voluntario + ")";
            reqSQL = "UPDATE z_voluntarios SET id_voluntario=" + myz_voluntarios.id_voluntario + ",id_compania=" + myz_voluntarios.id_compania + ",nombres='" + myz_voluntarios.nombres + "',apellidos='" + myz_voluntarios.apellidos + "',rut='" + myz_voluntarios.rut + "',direccion='" + myz_voluntarios.direccion + "',fecha_nacimiento='" + myz_voluntarios.fecha_nacimiento + "',ingreso='" + myz_voluntarios.ingreso + "',num_llamado=" + myz_voluntarios.num_llamado + ",comuna='" + myz_voluntarios.comuna + "',telefono='" + myz_voluntarios.telefono + "',celular='" + myz_voluntarios.celular + "', urlimagen='" + myz_voluntarios.urlimagen + "' WHERE (id_voluntario=" + myz_voluntarios.id_voluntario + ")";

            
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);

                /*if (foto != null)
                {
                    NpgsqlTransaction t = myConn.BeginTransaction();
                    LargeObjectManager lbm = new LargeObjectManager(myConn);

                    int noid = lbm.Create(LargeObjectManager.READWRITE);
                    LargeObject lo = lbm.Open(noid, LargeObjectManager.READWRITE);

                    // eliminar antiguo
                    NpgsqlCommand comm = new NpgsqlCommand("select foto from z_voluntarios where id_voluntario=" + myz_voluntarios.id_voluntario, myConn);
                    comm.ExecuteScalar();
                    
                    //lbm.Unlink(oid);

                    FileStream fs = File.OpenRead(foto);

                    byte[] buf = new byte[fs.Length];
                    fs.Read(buf, 0, (int)fs.Length);

                    lo.Write(buf);
                    lo.Close();
                    t.Commit();

                    reqSQL = "UPDATE z_voluntarios SET id_voluntario=" + myz_voluntarios.id_voluntario + ",id_compania=" + myz_voluntarios.id_compania + ",nombres='" + myz_voluntarios.nombres + "',apellidos='" + myz_voluntarios.apellidos + "',rut='" + myz_voluntarios.rut + "',direccion='" + myz_voluntarios.direccion + "',fecha_nacimiento='" + myz_voluntarios.fecha_nacimiento + "',ingreso='" + myz_voluntarios.ingreso + "',num_llamado=" + myz_voluntarios.num_llamado + ",comuna='" + myz_voluntarios.comuna + "',telefono='" + myz_voluntarios.telefono + "',celular='" + myz_voluntarios.celular + "', foto="+noid+" WHERE (id_voluntario=" + myz_voluntarios.id_voluntario + ")";
                }*/

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
        public z_voluntarios getObjectz_voluntarios(System.Int32 myID)
        {
            z_voluntarios myz_voluntarios = new z_voluntarios();
            CnxBase myBase = new CnxBase();
            //#f
            //string reqSQL = "SELECT id_voluntario,id_compania,nombres,apellidos,rut,direccion,fecha_nacimiento,ingreso,num_llamado,comuna,telefono,celular FROM z_voluntarios WHERE (id_voluntario=" + myID + ")";
            string reqSQL = "SELECT id_voluntario,id_compania,nombres,apellidos,rut,direccion,fecha_nacimiento,ingreso,num_llamado,comuna,telefono,celular, urlimagen FROM z_voluntarios WHERE (id_voluntario=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myz_voluntarios.id_voluntario = Convert.ToInt32(myReader[0]);
                    myz_voluntarios.id_compania = Convert.ToInt32(myReader[1]);
                    myz_voluntarios.nombres = myReader[2].ToString();
                    myz_voluntarios.apellidos = myReader[3].ToString();
                    myz_voluntarios.rut = myReader[4].ToString();
                    myz_voluntarios.direccion = myReader[5].ToString();
                    myz_voluntarios.fecha_nacimiento = Convert.ToDateTime(myReader[6]);
                    myz_voluntarios.ingreso = Convert.ToDateTime(myReader[7]);
                    myz_voluntarios.num_llamado = Convert.ToInt32(myReader[8]);
                    myz_voluntarios.comuna = myReader[9].ToString();
                    myz_voluntarios.telefono = myReader[10].ToString();
                    myz_voluntarios.celular = myReader[11].ToString();
                    //#f
                    myz_voluntarios.urlimagen = myReader[12].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return myz_voluntarios;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Getz_voluntarios()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM z_voluntarios order by apellidos";
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

        public DataSet Getz_voluntarios(int id_compania)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT *, apellidos||' '||nombres as nombre_completo FROM z_voluntarios WHERE id_compania=" + id_compania + " order by apellidos";
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
        public Image getImagen(int id_voluntario)
        {
            Image ret = null;
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT foto FROM z_voluntarios WHERE id_voluntario=" + id_voluntario;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read() && myReader[0] != DBNull.Value)
                {
                    NpgsqlTransaction t = myConn.BeginTransaction();
                    NpgsqlTypes.LargeObjectManager lbm = new NpgsqlTypes.LargeObjectManager(myConn);
                    NpgsqlTypes.LargeObject lo = lbm.Open(Convert.ToInt32(myReader[0]), NpgsqlTypes.LargeObjectManager.READ);
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

        public DataSet Getz_voluntariosLista()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT apellidos||' '||nombres as nombre_completo, id_voluntario FROM z_voluntarios order by apellidos";
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
