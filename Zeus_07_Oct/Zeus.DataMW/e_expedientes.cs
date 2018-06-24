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
using System.Text;
using System.Collections;

namespace Zeus.Data
{
    /// <summary>
    /// e_expedientes
    /// </summary>
    public class e_expedientes
    {

        #region ***** Campos y propiedades *****

        private static ArrayList listado_grupos_habil = new ArrayList();

        public System.String AsistenciaPorCompania { get; set; }
        public System.String AsistenciaVoluntariosOtrasCompanias { get; set; }
        public System.String LesionadosActoServicio { get; set; }
        public System.String Piso { get; set; }
        public System.String OrigenAlamarma { get; set; }
        public System.String InformeIngresado { get; set; }


        public static ArrayList Listado_grupos_habil
        {
            get { return listado_grupos_habil; }
            set { listado_grupos_habil = value; }
        }

        private System.Int32 _id_expediente;
        public System.Int32 id_expediente
        {
            get
            {
                return _id_expediente;
            }
            set
            {
                _id_expediente = value;
            }
        }

        private System.String _cero5;
        public System.String cero5
        {
            get
            {
                return _cero5;
            }
            set
            {
                _cero5 = value;
            }
        }

        private System.String _seis2;
        public System.String seis2
        {
            get
            {
                return _seis2;
            }
            set
            {
                _seis2 = value;
            }
        }

        private System.Double _puntoX;
        public System.Double puntoX
        {
            get
            {
                return _puntoX;
            }
            set
            {
                _puntoX = value;
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

        private System.String _geoz;
        public System.String geoz
        {
            get
            {
                return _geoz;
            }
            set
            {
                _geoz = value;
            }
        }

        private System.Boolean _activo;
        public System.Boolean activo
        {
            get
            {
                return _activo;
            }
            set
            {
                _activo = value;
            }
        }

        private System.Double _puntoY;
        public System.Double puntoY
        {
            get
            {
                return _puntoY;
            }
            set
            {
                _puntoY = value;
            }
        }

        private System.DateTime _hora;
        public System.DateTime hora
        {
            get
            {
                return _hora;
            }
            set
            {
                _hora = value;
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

        private System.String _poblacion_villa;
        public System.String poblacion_villa
        {
            get
            {
                return _poblacion_villa;
            }
            set
            {
                _poblacion_villa = value;
            }
        }

        private System.String _block;
        public System.String block
        {
            get
            {
                return _block;
            }
            set
            {
                _block = value;
            }
        }

        private System.String _casa;
        public System.String casa
        {
            get
            {
                return _casa;
            }
            set
            {
                _casa = value;
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

        private System.String _quien_llama;
        public System.String quien_llama
        {
            get
            {
                return _quien_llama;
            }
            set
            {
                _quien_llama = value;
            }
        }

        private System.String _compania;
        public System.String compania
        {
            get
            {
                return _compania;
            }
            set
            {
                _compania = value;
            }
        }

        private System.String _descripcion;
        public System.String descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        private System.Int32 _codigo_llamado;
        public System.Int32 codigo_llamado
        {
            get
            {
                return _codigo_llamado;
            }
            set
            {
                _codigo_llamado = value;
            }
        }

        private System.Int32 _codigo_principal;
        public System.Int32 codigo_principal
        {
            get
            {
                return _codigo_principal;
            }
            set
            {
                _codigo_principal = value;
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

        private bool _enviado_redtic;

        public bool enviado_redtic
        {
            get { return _enviado_redtic; }
            set { _enviado_redtic = value; }
        }

        private int _id_voluntario;

        public int id_voluntario
        {
            get { return _id_voluntario; }
            set { _id_voluntario = value; }
        }

        private int _id_area;

        public int id_area
        {
            get { return _id_area; }
            set { _id_area = value; }
        }

        private bool _sit_controlada;

        public bool sit_controlada
        {
            get { return _sit_controlada; }
            set { _sit_controlada = value; }
        }

        private bool _tono_incendio;

        public bool tono_incendio
        {
            get { return _tono_incendio; }
            set { _tono_incendio = value; }
        }

        private int _id_frecuencia;

        public int id_frecuencia
        {
            get { return _id_frecuencia; }
            set { _id_frecuencia = value; }
        }

        private int _batallon;

        public int batallon
        {
            get { return _batallon; }
            set { _batallon = value; }
        }
        private int _correlativo;

        public int correlativo
        {
            get { return _correlativo; }
            set { _correlativo = value; }
        }
        private int _correlativo_iioo;

        public int correlativo_iioo
        {
            get { return _correlativo_iioo; }
            set { _correlativo_iioo = value; }
        }
        private DateTime _hora_retirada;

        public DateTime hora_retirada
        {
            get { return _hora_retirada; }
            set { _hora_retirada = value; }
        }
        private DateTime _fecha_retirada;

        public DateTime fecha_retirada
        {
            get { return _fecha_retirada; }
            set { _fecha_retirada = value; }
        }
        private string _origen;

        public string origen
        {
            get { return _origen; }
            set { _origen = value; }
        }
        private string _causa;

        public string causa
        {
            get { return _causa; }
            set { _causa = value; }
        }
        private string _observaciones;

        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        private string _material_despachado;

        public string material_despachado
        {
            get { return _material_despachado; }
            set { _material_despachado = value; }
        }

        private int _correlativo_redtic;

        public int correlativo_redtic
        {
            get { return _correlativo_redtic; }
            set { _correlativo_redtic = value; }
        }

        private System.Int32 _asisten;
        public System.Int32 asisiten
        {
            get
            {
                return _asisten;
            }
            set
            {
                _asisten = value;
            }
        }

        private string _fuente_calor;
        public string fuente_calor
        {
            get { return _fuente_calor; }
            set { _fuente_calor = value; }
        }

        private string _cargo_informe;
        public string cargo_informe
        {
            get { return _cargo_informe; }
            set { _cargo_informe = value; }
        }

        private string _cia_cargo_informe;
        public string cia_cargo_informe
        {
            get { return _cia_cargo_informe; }
            set { _cia_cargo_informe = value; }
        }

        private string _cargo_llamado;
        public string cargo_llamado
        {
            get { return _cargo_llamado; }
            set { _cargo_llamado = value; }
        }

        #endregion

        /// <summary>
        /// e_expedientes
        /// </summary>
        public e_expedientes()
        {
        }


        /// <summary>
        /// e_expedientes
        /// </summary>
        public e_expedientes(System.Int32 id_expediente, System.String cero5, System.String seis2, System.Double puntoX, System.String comuna, System.String geoz, System.Boolean activo, System.Double puntoY, System.DateTime hora, System.DateTime fecha, System.String poblacion_villa, System.String block, System.String casa, System.String telefono, System.String quien_llama, System.String compania, System.String descripcion, System.Int32 codigo_llamado, System.Int32 codigo_principal, System.Int32 id_operadora, bool enviado_redtic, int id_voluntario, int id_area)
        {
            this.id_expediente = id_expediente;
            this.cero5 = cero5;
            this.seis2 = seis2;
            this.puntoX = puntoX;
            this.comuna = comuna;
            this.geoz = geoz;
            this.activo = activo;
            this.puntoY = puntoY;
            this.hora = hora;
            this.fecha = fecha;
            this.poblacion_villa = poblacion_villa;
            this.block = block;
            this.casa = casa;
            this.telefono = telefono;
            this.quien_llama = quien_llama;
            this.compania = compania;
            this.descripcion = descripcion;
            this.codigo_llamado = codigo_llamado;
            this.codigo_principal = codigo_principal;
            this.id_operadora = id_operadora;
            this.enviado_redtic = enviado_redtic;
            this.id_voluntario = id_voluntario;
            this.id_area = id_area;
        }

        #region *****persistance managing methods

        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="myID"></param>
        public void Insert(e_expedientes mye_expedientes)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO e_expedientes (cero5,seis2,\"puntoX\",comuna,geoz,activo,\"puntoY\",hora,fecha,poblacion_villa,block,casa,telefono,quien_llama,compania,descripcion,codigo_llamado,codigo_principal,id_operadora, enviado_redtic, id_voluntario, id_area) VALUES ('" + mye_expedientes.cero5 + "','" + mye_expedientes.seis2 + "'," + PointD.ToPgString(mye_expedientes.puntoX) + ",'" + mye_expedientes.comuna + "','" + mye_expedientes.geoz + "'," + mye_expedientes.activo + "," + PointD.ToPgString(mye_expedientes.puntoY) + ",'" + mye_expedientes.hora + "','" + mye_expedientes.fecha + "','" + mye_expedientes.poblacion_villa + "','" + mye_expedientes.block + "','" + mye_expedientes.casa + "','" + mye_expedientes.telefono + "','" + mye_expedientes.quien_llama + "','" + mye_expedientes.compania + "','" + mye_expedientes.descripcion + "'," + mye_expedientes.codigo_llamado + "," + mye_expedientes.codigo_principal + "," + mye_expedientes.id_operadora + "," + mye_expedientes.enviado_redtic + "," + mye_expedientes.id_voluntario + "," + mye_expedientes.id_area + ")";
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
                NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM e_expedientes WHERE (id_expediente = " + myID + ")", myConn);
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
        public void Update(e_expedientes mye_expedientes)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE e_expedientes SET cero5='" + mye_expedientes.cero5 +
                "',seis2='" + mye_expedientes.seis2 + "',\"puntoX\"=" + PointD.ToPgString(mye_expedientes.puntoX) +
                ",comuna='" + mye_expedientes.comuna +
                "',geoz='" + mye_expedientes.geoz +
                "',activo=" + mye_expedientes.activo +
                ",\"puntoY\"=" + PointD.ToPgString(mye_expedientes.puntoY) +
                ",hora='" + mye_expedientes.hora +
                "',fecha='" + mye_expedientes.fecha +
                "',poblacion_villa='" + mye_expedientes.poblacion_villa +
                "',block='" + mye_expedientes.block +
                "',casa='" + mye_expedientes.casa +
                "',telefono='" + mye_expedientes.telefono +
                "',quien_llama='" + mye_expedientes.quien_llama +
                "',compania='" + mye_expedientes.compania +
                "',descripcion='" + mye_expedientes.descripcion +
                "',codigo_llamado=" + mye_expedientes.codigo_llamado +
                ",codigo_principal=" + mye_expedientes.codigo_principal +
                ",id_operadora=" + mye_expedientes.id_operadora +
                ",enviado_redtic=" + mye_expedientes.enviado_redtic +
                ",id_voluntario=" + mye_expedientes.id_voluntario +
                ",id_area=" + mye_expedientes.id_area +
                ",sit_controlada=" + mye_expedientes.sit_controlada +
                ", tono_incendio=" + mye_expedientes.tono_incendio +
                ", id_frecuencia='" + mye_expedientes.id_frecuencia +
                "',batallon='" + mye_expedientes.batallon +
                "',correlativo='" + mye_expedientes.correlativo +
                "',correlativo_iioo='" + mye_expedientes.correlativo_iioo +
                "',correlativo_redtic='" + mye_expedientes.correlativo_redtic +
                "',hora_retirada='" + mye_expedientes.hora_retirada +
                "',fecha_retirada='" + mye_expedientes.fecha_retirada +
                "',origen='" + mye_expedientes.origen +
                "',causa='" + mye_expedientes.causa +
                "',observaciones='" + mye_expedientes.observaciones +
                "',material_despachado='" + mye_expedientes.material_despachado +
                "',asisten=" + mye_expedientes.asisiten +
                ", fuente_calor='"+mye_expedientes.fuente_calor+
                "',cargo_informe='"+mye_expedientes.cargo_informe+
                "',cia_cargo_informe='"+mye_expedientes.cia_cargo_informe+
                "',cargo_llamado='"+mye_expedientes.cargo_llamado+
                /*NUEVOS CAMPOS AGREGADOS AL EXPEDIENTE*/
                "',asistencia='" + mye_expedientes.AsistenciaPorCompania +
                "',asistencia_oficiales='" + mye_expedientes.AsistenciaVoluntariosOtrasCompanias +
                "',lesionados='" + mye_expedientes.LesionadosActoServicio +
                "',persona_origen='" + mye_expedientes.OrigenAlamarma +
                "',ingreso_op='" + mye_expedientes.InformeIngresado +
                "',piso='" + mye_expedientes.Piso +
                "'  WHERE (id_expediente=" + mye_expedientes.id_expediente + ")";
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
        public e_expedientes getObjecte_expedientes(System.Int32 myID)
        {
            e_expedientes mye_expedientes = new e_expedientes();
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente,cero5,seis2,\"puntoX\",comuna,geoz,activo,\"puntoY\",hora,fecha,poblacion_villa,block,casa,telefono,quien_llama,compania,descripcion,codigo_llamado,codigo_principal,id_operadora,enviado_redtic, id_voluntario, id_area, sit_controlada, tono_incendio,id_frecuencia,batallon,correlativo,correlativo_iioo,hora_retirada,fecha_retirada,origen,causa,observaciones,material_despachado,correlativo_redtic,asisten,fuente_calor,cargo_informe,cia_cargo_informe,cargo_llamado, asistencia, asistencia_oficiales, lesionados, persona_origen, ingreso_op, piso FROM e_expedientes WHERE (id_expediente=" + myID + ")";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    mye_expedientes.id_expediente = Convert.ToInt32(myReader[0]);
                    mye_expedientes.cero5 = myReader[1].ToString();
                    mye_expedientes.seis2 = myReader[2].ToString();
                    mye_expedientes.puntoX = (System.Double)myReader[3];
                    mye_expedientes.comuna = myReader[4].ToString();
                    mye_expedientes.geoz = myReader[5].ToString();
                    mye_expedientes.activo = Convert.ToBoolean(myReader[6]);
                    mye_expedientes.puntoY = (System.Double)myReader[7];
                    mye_expedientes.hora = Convert.ToDateTime(myReader[8]);
                    mye_expedientes.fecha = Convert.ToDateTime(myReader[9]);
                    mye_expedientes.poblacion_villa = myReader[10].ToString();
                    mye_expedientes.block = myReader[11].ToString();
                    mye_expedientes.casa = myReader[12].ToString();
                    mye_expedientes.telefono = myReader[13].ToString();
                    mye_expedientes.quien_llama = myReader[14].ToString();
                    mye_expedientes.compania = myReader[15].ToString();
                    mye_expedientes.descripcion = myReader[16].ToString();
                    mye_expedientes.codigo_llamado = Convert.ToInt32(myReader[17]);
                    mye_expedientes.codigo_principal = Convert.ToInt32(myReader[18]);
                    mye_expedientes.id_operadora = Convert.ToInt32(myReader[19]);
                    mye_expedientes.enviado_redtic = Convert.ToBoolean(myReader[20]);
                    mye_expedientes.id_voluntario = Convert.ToInt32(myReader[21]);
                    mye_expedientes.id_area = Convert.ToInt32(myReader[22]);
                    mye_expedientes.sit_controlada = Convert.ToBoolean(myReader[23]);
                    mye_expedientes.tono_incendio = Convert.ToBoolean(myReader[24]);
                    mye_expedientes.id_frecuencia = Convert.ToInt32(myReader[25]);
                    mye_expedientes.batallon = Convert.ToInt32(myReader[26]);
                    mye_expedientes.correlativo = Convert.ToInt32(myReader[27]);
                    mye_expedientes.correlativo_iioo = Convert.ToInt32(myReader[28]);
                    mye_expedientes.hora_retirada = myReader.IsDBNull(29) ? DateTime.MinValue : Convert.ToDateTime(myReader[29]);
                    mye_expedientes.fecha_retirada = myReader.IsDBNull(30) ? DateTime.MinValue : Convert.ToDateTime(myReader[30]);
                    mye_expedientes.origen = myReader[31].ToString();
                    mye_expedientes.causa = myReader[32].ToString();
                    mye_expedientes.observaciones = myReader[33].ToString();
                    mye_expedientes.material_despachado = myReader[34].ToString();
                    mye_expedientes.correlativo_redtic = Convert.ToInt32(myReader[35]);
                    mye_expedientes.asisiten = Convert.ToInt32(myReader[36]);
                    mye_expedientes.fuente_calor = myReader[37].ToString();
                    mye_expedientes.cargo_informe = myReader[38].ToString();
                    mye_expedientes.cia_cargo_informe = myReader[39].ToString();
                    mye_expedientes.cargo_llamado = myReader[40].ToString();
                    mye_expedientes.AsistenciaPorCompania = myReader[41].ToString();
                    mye_expedientes.AsistenciaVoluntariosOtrasCompanias = myReader[42].ToString();
                    mye_expedientes.LesionadosActoServicio = myReader[43].ToString();
                    mye_expedientes.InformeIngresado = myReader[44].ToString();
                    mye_expedientes.OrigenAlamarma = myReader[45].ToString();
                    mye_expedientes.Piso = myReader[46].ToString();
                }
                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return mye_expedientes;
        }

        /// <summary>
        /// get a DataSet from records
        /// </summary>
        public DataSet Gete_expedientes()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente,seis2,cero5, \"puntoX\",\"puntoY\",fecha,hora,(z_llamados.clave||' '||z_llamados.descripcion) as servicio,e_expedientes.id_operadora,z_locutores.login, z_llamados.clave,(z_llamados.clave||' '||seis2||' / '||cero5) as clave_dir, id_area  FROM e_expedientes, z_llamados, z_locutores where activo=true and e_expedientes.codigo_llamado=z_llamados.codigo_llamado and e_expedientes.id_operadora=z_locutores.id_locutor order by login desc, fecha desc, hora desc";
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

        public DataSet Gete_expedientes_operadora(int id_operadora)
        {
            // INVOKE EXPEDIENTES POR OPERADORA MRKSPONCE
            CnxBase myBase = new CnxBase();
            //string reqSQL = "SELECT id_expediente, seis2, cero5, z_llamados.clave, fecha, sit_controlada from e_expedientes, z_llamados where e_expedientes.id_operadora=" + id_operadora + " and activo=true and e_expedientes.codigo_principal=z_llamados.codigo_llamado";
            string reqSQL = "SELECT id_expediente, seis2, cero5, z_llamados.clave, fecha, sit_controlada from e_expedientes, z_llamados where e_expedientes.id_operadora=" + id_operadora + " and activo=true and e_expedientes.codigo_principal=z_llamados.codigo_llamado";
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

        public DataSet Gete_expedientes_tomados()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente,seis2,cero5, \"puntoX\",\"puntoY\",fecha,hora,(z_llamados.clave||' '||z_llamados.descripcion) as servicio,e_expedientes.id_operadora,z_locutores.login, z_llamados.clave,(z_llamados.clave||' '||seis2||' / '||cero5) as clave_dir  FROM e_expedientes, z_llamados, z_locutores where activo=true and e_expedientes.codigo_llamado=z_llamados.codigo_llamado and e_expedientes.id_operadora=z_locutores.id_locutor and id_operadora!=0 order by login desc, fecha desc";
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

        public DataSet Gete_expedientes_cerrados(DateTime desde, DateTime hasta)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente, (seis2 || ' / '||  cero5) as esquina, fecha,z_llamados.clave from e_expedientes,z_llamados where activo=false and e_expedientes.codigo_principal=z_llamados.codigo_llamado and fecha>='"+desde.ToShortDateString()+"' and fecha <='"+hasta.ToShortDateString()+"' order by fecha desc";
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

        public DataSet Gete_expedientes_codigoprincipal(int codigo_principal)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente, (seis2 || ' / '||  cero5) as esquina, comuna, id_area from e_expedientes where e_expedientes.codigo_principal=" + codigo_principal + " and activo=true";
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

        public DataSet Gete_expedientes_codigoprincipal(int codigo_principal, DateTime fecha)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_expediente, (seis2 || ' / '||  cero5) as esquina, comuna from e_expedientes where e_expedientes.codigo_principal=" + codigo_principal + " and activo=false and fecha='" + fecha.ToShortDateString() + "'";
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

        public DataSet GetIncendios24Horas()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select hora, (seis2 || ' / '||  cero5) as esquina, comuna, compania||'° Compañía' as compania, '('||id_area||')' as area, material_despachado from e_expedientes where fecha>=current_timestamp-interval '1 day'  and fecha<=current_timestamp and batallon>0";
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

        public DataSet GetExpedientes24Horas()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, fecha, z_llamados.clave, (seis2 || ' / '||  cero5) as esquina, correlativo, correlativo_iioo, correlativo_redtic, material_despachado, (z_voluntarios.apellidos||' '||z_voluntarios.nombres)as voluntario from z_llamados,e_expedientes left join z_voluntarios on e_expedientes.id_voluntario=z_voluntarios.id_voluntario  where fecha>=current_timestamp-interval '1 day'  and fecha<=current_timestamp and e_expedientes.codigo_principal=z_llamados.codigo_llamado order by fecha desc";
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

        public DataSet GetExpedientes24Horas(DateTime desde, DateTime hasta)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, fecha, z_llamados.clave, (seis2 || ' / '||  cero5) as esquina, correlativo, correlativo_iioo, correlativo_redtic, material_despachado, (apellidos||' '||nombres)as voluntario from z_llamados, e_expedientes  left join z_voluntarios on e_expedientes.id_voluntario=z_voluntarios.id_voluntario where fecha>='" + desde.ToString() + "'  and fecha<='" + hasta.ToString() + "' and e_expedientes.codigo_principal=z_llamados.codigo_llamado order by fecha desc";
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


        public DataSet GetApoyos24Horas()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT descripcion, hora, quien_llama, material_despachado from e_expedientes where fecha>=current_timestamp-interval '1 day'  and fecha<=current_timestamp and codigo_principal=13";
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

        public int GetAlarmas24Horas()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "select count(id_expediente) from e_expedientes as alarmas where fecha>=current_timestamp-interval '1 day'  and fecha<=current_timestamp";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ret = Convert.ToInt32(myReader[0]);
                }
                myBase.CloseConnection(myConn);
                return ret;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public int GetNextCorrelativoIIOO()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "select nextval('e_expedientes_correlativo_iioo_seq'::regclass)";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ret = Convert.ToInt32(myReader[0]);
                }
                myBase.CloseConnection(myConn);
                return ret;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public int GetCorrelativoIIOO()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "select last_value from e_expedientes_correlativo_iioo_seq";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ret = Convert.ToInt32(myReader[0]);
                }
                myBase.CloseConnection(myConn);
                return ret;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public int GetCorrelativoExp()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "select last_value from e_expedientes_correlativo_seq";//"select currval('e_expedientes_correlativo_seq'::regclass)";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ret = Convert.ToInt32(myReader[0]);
                }
                myBase.CloseConnection(myConn);
                return ret;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }
        public int GetCorrelativoRedTIC()
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "select last_value from e_expedientes_correlativo_redtic_seq";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                NpgsqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ret = Convert.ToInt32(myReader[0]);
                }
                myBase.CloseConnection(myConn);
                return ret;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        public void UpdateCorrelativoIIOO(int valor)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "ALTER SEQUENCE public.e_expedientes_correlativo_iioo_seq INCREMENT 1  MINVALUE 1 RESTART "+valor+" CACHE 1  NO CYCLE;";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }
        public void UpdateCorrelativoExp(int valor)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "ALTER SEQUENCE public.e_expedientes_correlativo_seq INCREMENT 1  MINVALUE 1  RESTART " + valor + " CACHE 1  NO CYCLE;";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }
        public void UpdateCorrelativoRedTIC(int valor)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "ALTER SEQUENCE public.e_expedientes_correlativo_redtic_seq INCREMENT 1  MINVALUE 1  RESTART " + valor + " CACHE 1  NO CYCLE;";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }
        public int recuperarIDHoraDLL(string hora_decimal)
        {
            CnxBase myBase = new CnxBase();
            int id = 0;
            decimal abc = Convert.ToDecimal(hora_decimal);
            StringBuilder reqSQL = new StringBuilder("SELECT bloque FROM cs_bloque WHERE " + hora_decimal + " >= desde AND " + hora_decimal + " <= hasta");
            //string reqSQL = "";
            try
            {
                DataSet ds_id = new DataSet();
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlDataAdapter da_id = new NpgsqlDataAdapter(reqSQL.ToString(), myConn);
                //NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                //myCommand.ExecuteNonQuery();
                da_id.Fill(ds_id);
                foreach (DataRow r_id in ds_id.Tables[0].Rows)
                {
                    id = Convert.ToInt32(r_id["bloque"].ToString());
                }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return id;
        }

        public string[] recuperarDespachoHabil(int codigo_llamado)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT id_llamado, id_grupo, recurso FROM x_despacho_habil WHERE id_llamado = " + codigo_llamado;
            string in_query = "";
            string in_query_string = "";
            string[] arreglo_valores = null;
            int count_general = 0;
            try
            {
                int i = 0;
                string id_grupo = "";
                string recurso = "";
                DataSet ds_id = new DataSet();
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlDataAdapter da_id = new NpgsqlDataAdapter(reqSQL.ToString(), myConn);
                da_id.Fill(ds_id);
                int[] id = null;
                count_general = ds_id.Tables[0].Rows.Count;
                arreglo_valores = new string[count_general];
                    foreach (DataRow r_id in ds_id.Tables[0].Rows)
                    {
                        string sql_xtipo_grupo = "SELECT id_grupo, tipo_carro FROM x_tipo_grupo WHERE id_grupo = " + Convert.ToInt32(r_id["id_grupo"].ToString());
                        NpgsqlDataAdapter da_id2 = new NpgsqlDataAdapter(sql_xtipo_grupo.ToString(), myConn);
                        DataSet ds_id2 = new DataSet();
                        da_id2.Fill(ds_id2);
                        int count = ds_id2.Tables[0].Rows.Count;
                        foreach (DataRow r_id2 in ds_id2.Tables[0].Rows)
                        {
                            in_query += "" + r_id2["tipo_carro"] + ",";
                            id_grupo = r_id2["id_grupo"].ToString();
                            recurso = r_id["recurso"].ToString();
                        }
                        in_query += "#";
                        arreglo_valores[i] = in_query.Replace(",#","") + "/" + id_grupo + "/" + recurso;
                        in_query = "";
                        i++;
                    }
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return arreglo_valores;
        }

        public int recFechaExpediente(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            int id = 0;
            string fechaDB = "";
            string fecha_registro = "";
            string[] arreglo_1;
            string[] arreglo_2;
            string hora_decimal;
            //decimal abc = Convert.ToDecimal(hora_decimal);
            int bloque;

            //### Validar Día Feriado
            if (EsFeriado() == true)
            {
                bloque = 1;
            }
            else
            {

                StringBuilder reqSQL = new StringBuilder("SELECT fecha FROM e_expedientes WHERE id_expediente = " + idExpediente);
                try
                {
                    DataSet ds_id = new DataSet();
                    NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                    NpgsqlDataAdapter da_id = new NpgsqlDataAdapter(reqSQL.ToString(), myConn);
                    //NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                    //myCommand.ExecuteNonQuery();
                    da_id.Fill(ds_id);
                    foreach (DataRow r_id in ds_id.Tables[0].Rows)
                    {
                        fechaDB = r_id["fecha"].ToString();
                    }

                    e_expedientes exp = new e_expedientes(0, "", "", 0.0, "", "", false, 0.0, DateTime.Now, DateTime.Now, "", "", "", "", "", "", "", 0, 0, 0, false, 0, 0);
                    fecha_registro = fechaDB;
                    arreglo_1 = fecha_registro.Split(' ');
                    arreglo_2 = arreglo_1[1].Split(':');
                    hora_decimal = arreglo_2[0].ToString() + "." + arreglo_2[1].ToString() + arreglo_2[2].ToString();
                    bloque = exp.recuperarIDHoraDLL(hora_decimal);

                }
                catch (Exception myErr)
                {
                    throw (new Exception(myErr.ToString() + reqSQL));
                }
            }
            return bloque;
        }


        public bool EsFeriado()
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM x_bloque_feriado WHERE feriado = true ";
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



        public void ActualizarFeriado(bool AsignaFeriado)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE x_bloque_feriado SET feriado=" + AsignaFeriado +"";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        public int countRegistroZcarrosLlamado(int id_expediente, int id_grupo)
        {
            CnxBase myBase = new CnxBase();
            int contador = 0;
            string reqSQL = "SELECT count(*) as contador FROM z_carros_llamado WHERE id_expediente = "+id_expediente+" AND id_grupo = "+id_grupo+" and flag_estado = 'NOTEMPORAL'";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow dr_row in myResult.Tables[0].Rows)
                {
                    contador = Convert.ToInt32(dr_row["contador"].ToString());
                }
                return contador;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        //# Obtener Id de Carro Cascada
        public int IdCarroDespachado(int id_expediente, int id_grupo)
        {
            CnxBase myBase = new CnxBase();
            int contador = 0;
            string reqSQL = "SELECT id_carro FROM z_carros_llamado WHERE id_expediente = " + id_expediente + " AND id_grupo = " + id_grupo + " AND flag_estado = 'NOTEMPORAL'";
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow dr_row in myResult.Tables[0].Rows)
                {
                    contador = Convert.ToInt32(dr_row["id_carro"].ToString());
                }
                return contador;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }




        public void limpiarTablaZcarrosLlamado(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM z_carros_llamado WHERE id_expediente = "+idExpediente+"";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        public void limpiarRegistroZcarrosLlamado(int idExpediente, int IdCarro)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM z_carros_llamado WHERE id_expediente = " + idExpediente + " AND id_carro = " + IdCarro +"";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }


        public int CambioCodigoLlamadoExpediente(int codigoLlamado, int idArea)
        {
            CnxBase myBase = new CnxBase();

            int contador = 0;
            int codigoRetorno = 0;
            string reqSQL = "select id_area as IdArea, id_llamado as CodigoLlamado, id_caso as IdCaso from x_llamado_caso_especial where id_area = " + idArea + " and id_llamado = " + codigoLlamado + "";
            try
            {

                DataSet myResult = myBase.GetDataSet(reqSQL);
                if (myResult.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_row in myResult.Tables[0].Rows)
                    {
                        if (codigoLlamado.ToString() == dr_row["CodigoLlamado"].ToString() && idArea.ToString() == dr_row["IdArea"].ToString())
                        {
                            codigoRetorno = Convert.ToInt32(dr_row["IdCaso"].ToString());
                        }
                        else
                        {
                            codigoRetorno = codigoLlamado;
                        }
                    }
                }
                else
                {
                    codigoRetorno = codigoLlamado;
                }
                return codigoRetorno;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public void ActualizarFechaExpediente(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE e_expedientes SET fecha = '" + System.DateTime.Now + "' WHERE id_expediente = " + idExpediente + "";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        public DataSet GetDatosTwitter(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT a.seis2, a.cero5, b.clave, b.descripcion, a.id_area, a.material_despachado, a.plano, a.codigo_principal FROM e_expedientes a left join z_llamados b on a.codigo_llamado = b.codigo_llamado WHERE a.id_expediente = " + idExpediente;
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

        public string Utm_2_LatLong(string exp_x, string exp_y)
        {
            string strLatLong = "utm";
            string strLatLong_tm = "";
            string[] xey_arr = new string[2];

            var myBase = new CnxBase();
            var myD4MCnx = new CnxBase();

            string x_e_y = exp_x + " " + exp_y;
            string reqSQL = "SELECT ST_AsText(ST_Transform(ST_GeomFromText('POINT(" + x_e_y + ")', 32719), 4326)) As lat_long";
            try
            {
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow r_tcarros in myResult.Tables[0].Rows)
                {
                    strLatLong_tm = Convert.ToString(r_tcarros["lat_long"]);
                    strLatLong_tm = strLatLong_tm.Replace("POINT(", "");
                    strLatLong_tm = strLatLong_tm.Replace(")", "");
                    xey_arr = strLatLong_tm.Split(' ');
                    strLatLong = xey_arr[1] + "+" + xey_arr[0];
                }

            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr + reqSQL));
            }
            return strLatLong;
        }

        public void AgregarPlanoTwitter(int idExpediente, string strPlano)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "UPDATE e_expedientes SET plano = '" + strPlano + "' WHERE id_expediente = " + idExpediente + "";
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }





    }


}
