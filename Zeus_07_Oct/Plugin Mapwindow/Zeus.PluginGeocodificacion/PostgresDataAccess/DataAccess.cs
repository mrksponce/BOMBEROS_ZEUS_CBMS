using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Npgsql;
using Zeus.Data;

namespace PostgresDataAccess
{
    public class DataAccess
    {
        public DataAccess()
        {
            //inicializar conexion
            Config.Load();
            //_conexion = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=burrix;Password=hola;Database=bd_sgc;");
            //_conexion = new NpgsqlConnection("Server="+Config.Host+";Port=5432;User Id=burrix;Password=hola;Database="+Config.Database+";CommandTimeout=120;timeout=120");
            _conexion = new NpgsqlConnection(new CnxBase().cnxString);
        }

        public DataAccess(TipoServidor s)
        {
            switch (s)
            {
                case TipoServidor.Local:
                    _conexion = new NpgsqlConnection("Server=192.168.56.101;Port=5432;User Id=zeus_cbqn;Password=123;Database=zeus-cbqn-new;");
                    break;
                case TipoServidor.Remoto:
                    _conexion = new NpgsqlConnection("Server=" + Zeus.PluginGeocodificacion.DatosSGC.Host + ";Port=5432;User Id=burrix;Password=hola;Database=bd_sgc;");
                    break;
                default:
                    break;
            }
        }
        public bool Test()
        {
            bool ok = true;
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("select version();", _conexion);
                _conexion.Open();
                cmd.ExecuteScalar();
            }
            catch (NpgsqlException e)
            {
                ok = false;
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return ok;
        }

        private NpgsqlConnection _conexion;

        public NpgsqlConnection Conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private void TraceEx(NpgsqlException e)
        {
            Trace.WriteLine("-------------------------------------------------------");
            Trace.WriteLine(DateTime.Now.ToString());
            Trace.WriteLine(e.ToString());
            Trace.WriteLine(e.Code);
            Trace.WriteLine(e.Data);
            Trace.WriteLine(e.Detail);
            Trace.WriteLine(e.Errors.ToString());
            Trace.WriteLine(e.ErrorSql);
            Trace.WriteLine(e.Hint);
            Trace.WriteLine(e.Message);
            Trace.WriteLine(e.Position);
            Trace.WriteLine(e.Where);
            System.Windows.Forms.MessageBox.Show("El servidor de bases de datos ha entregado el siguiente mensaje:\n" + e.Message, "Mensaje de ZEUS", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        #region GEOCODIFICACION
        public List<string> ObtenerComunas()
        {
            List<string> Comunas = new List<string>();
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("select comuna from " + Tablas.Comunas, _conexion);
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                    Comunas.Add(dr.GetString(0));

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return Comunas;
        }

        public List<string> ObtenerComunasCuerpo()
        {
            List<string> Comunas = new List<string>();
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("select comuna from " + Tablas.ComunasCuerpo, _conexion);
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                    Comunas.Add(dr.GetString(0));

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            } 
            return Comunas;
        }

        public List<string> ObtenerCallesSinComuna()
        {
            List<string> Calles = new List<string>();
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT(nombre) FROM " + Tablas.Esquinas_RM, _conexion);
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                    Calles.Add(dr.GetString(0));

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            } 
            return Calles;
        }

        public List<string> ObtenerCallesConComuna(string calle, string Comuna)
        {
            List<string> Calles = new List<string>();
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT(nombre) FROM " + Tablas.Maestro + " where nombre like :nombre and comuna =:comuna", _conexion);
            command.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = "%" + calle + "%";
            command.Parameters.Add("comuna", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Comuna;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                    Calles.Add(dr.GetString(0));

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            } 
            return Calles;
        }

        public List<string> ObtenerCallesConComuna(string Comuna)
        {
            List<string> Calles = new List<string>();
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT(nombre) FROM " + Tablas.Maestro + " where comuna =:comuna", _conexion);
            command.Parameters.Add("comuna", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Comuna;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                    Calles.Add(dr.GetString(0));

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return Calles;
        }

        public List<string> ObtenerCallesCuerpo()
        {
            List<string> Calles = new List<string>();
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT("+Tablas.Maestro+".nombre) FROM " + Tablas.Maestro + ", k_comunas_cuerpo where "+Tablas.Maestro+".comuna =k_comunas_cuerpo.comuna", _conexion);
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                    Calles.Add(dr.GetString(0));

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return Calles;
        }

        public List<string> ObtenerEsquinas(string Calle, bool rm, bool UsarComuna, string Comuna)
        {
            List<string> l = new List<string>();
            bool coma = true;
            string strSQL, Instr = "";
            NpgsqlCommand command;
            NpgsqlDataReader drd;
            NpgsqlDataAdapter da;
            DataSet ds = new DataSet();

            if (UsarComuna)
            {
                // En la comuna seleccionada
                strSQL = "SELECT gech11, gech12, gech13, gech14, gech15, gech16, gech17, gech18, gech19, gech20, gech21, gech22, " +
                 "gech23, gech24, gech25, gech26, gech27, gech28, gech29, gech30, gech31, gech32, gech33, gech34, gech35, gech36, gech37, gech38, gech39, gech40 " +
                 "From " + Tablas.Esquinas_RM +
                 " INNER JOIN " + Tablas.Maestro + " ON " + Tablas.Esquinas_RM + ".nombre = " + Tablas.Maestro + ".nombre " +
                 " WHERE " + Tablas.Esquinas_RM + ".nombre = '" + Calle + "' AND " + Tablas.Maestro + ".comuna = '" + Comuna + "'";
            }
            else
            {
                if (rm)
                {
                    // Todas las comunas
                    strSQL = "SELECT gech11, gech12, gech13, gech14, gech15, gech16, gech17, gech18, gech19, gech20, gech21, gech22, " +
                     "gech23, gech24, gech25, gech26, gech27, gech28, gech29, gech30, gech31, gech32, gech33, gech34, gech35, gech36, gech37, gech38, gech39, gech40 " +
                     "From " + Tablas.Esquinas_RM +
                     " WHERE nombre = '" + Calle + "'";
                }
                else
                {
                    // comunas del cuerpo
                    strSQL = "SELECT gech11, gech12, gech13, gech14, gech15, gech16, gech17, gech18, gech19, gech20, gech21, gech22, " +
                     "gech23, gech24, gech25, gech26, gech27, gech28, gech29, gech30, gech31, gech32, gech33, gech34, gech35, gech36, gech37, gech38, gech39, gech40 " +
                     "From " + Tablas.Esquinas_Cuerpo + ", k_comunas_cuerpo, " +Tablas.Maestro+
                     " WHERE "+Tablas.Esquinas_Cuerpo+".nombre = '" + Calle + "' and " + Tablas.Maestro + ".comuna=k_comunas_cuerpo.comuna and "+Tablas.Esquinas_Cuerpo+".nombre="+Tablas.Maestro+".nombre";
                }

            }
            // dataadapter
            try
            {
                da = new NpgsqlDataAdapter(new NpgsqlCommand(strSQL, _conexion));
                da.Fill(ds);

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                return l;
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string s;
                s = dr.IsNull("gech11") ? "" : dr["gech11"].ToString();
                if (s != "")
                {
                    if (coma)
                    {
                        Instr = s;
                        coma = false;
                    }
                    Instr += "," + s;
                }
                s = dr.IsNull("gech12") ? "" : dr["gech12"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech13") ? "" : dr["gech13"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech14") ? "" : dr["gech14"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech15") ? "" : dr["gech15"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech16") ? "" : dr["gech16"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech17") ? "" : dr["gech17"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech18") ? "" : dr["gech18"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech19") ? "" : dr["gech19"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech20") ? "" : dr["gech20"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech21") ? "" : dr["gech21"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech22") ? "" : dr["gech22"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech23") ? "" : dr["gech23"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech24") ? "" : dr["gech24"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech25") ? "" : dr["gech25"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech26") ? "" : dr["gech26"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech27") ? "" : dr["gech27"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech28") ? "" : dr["gech28"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech29") ? "" : dr["gech29"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech30") ? "" : dr["gech30"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech31") ? "" : dr["gech31"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech32") ? "" : dr["gech32"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech33") ? "" : dr["gech33"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech34") ? "" : dr["gech34"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech35") ? "" : dr["gech35"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech36") ? "" : dr["gech36"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech37") ? "" : dr["gech37"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech38") ? "" : dr["gech38"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech39") ? "" : dr["gech39"].ToString();
                if (s != "")
                    Instr += "," + s;
                s = dr.IsNull("gech40") ? "" : dr["gech40"].ToString();
                if (s != "")
                    Instr += "," + s;
            }
            if (Instr == "")
                return l;

            // segunda consulta
            if (UsarComuna)
            {
                strSQL = "SELECT "+Tablas.Esquinas_RM+".nombre from " + Tablas.Esquinas_RM + 
                " INNER JOIN " + Tablas.Maestro + " ON " + Tablas.Esquinas_RM + ".nombre = " + Tablas.Maestro + ".nombre " +
                 " WHERE recno IN (" + Instr + ") AND " + Tablas.Esquinas_RM + ".nombre != '" + Calle + "' AND " + Tablas.Maestro + ".comuna = '" + Comuna + "'";
            }
            else
            {
                if (rm)
                {
                    strSQL = "SELECT nombre from " + Tablas.Esquinas_RM + " WHERE recno IN (" + Instr + ") AND nombre != '" + Calle + "'";
                }
                else
                {
                    strSQL = "SELECT distinct(" + Tablas.Esquinas_Cuerpo + ".nombre) from " + Tablas.Esquinas_Cuerpo + "," + Tablas.Maestro + ",k_comunas_cuerpo" + " WHERE recno IN (" + Instr + ") AND " + Tablas.Esquinas_Cuerpo + ".nombre != '" + Calle + "' AND " + Tablas.Esquinas_Cuerpo + ".nombre= "+Tablas.Maestro+".nombre and k_comunas_cuerpo.comuna="+Tablas.Maestro+".comuna";
                }
            } 
            command = new NpgsqlCommand(strSQL, _conexion);
            try
            {
                _conexion.Open();
                drd = command.ExecuteReader();

                while (drd.Read())
                {
                    l.Add(drd.GetString(0));
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return l;
        }

        public string ObtenerGeoz(string punto)
        {
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT geoz FROM k_geoz WHERE intersects(geometryfromtext('POINT(" + punto + ")',-1),the_geom)", _conexion);
            string ret = "";
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                if (dr.Read())
                    ret = dr.GetString(0);

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            } 
            return ret;
        }

        public int ObtenerArea(string punto)
        {
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT id_area FROM k_areas WHERE intersects(geometryfromtext('POINT(" + punto + ")',-1),the_geom)", _conexion);
            int ret = 0;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                if (dr.Read())
                    ret = dr.GetInt32(0);

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return ret;
        }
        #endregion

        #region GRIFOS
        public Grifo[] ObtenerGrifos(PointD centro, int radio)
        {
            NpgsqlDataReader dr;
            PointD x1 = new PointD(centro.X - radio, centro.Y - radio);
            PointD x2 = new PointD(centro.X + radio, centro.Y + radio);
            Grifo[] points = null;


            NpgsqlCommand command = new NpgsqlCommand("SELECT k_grifos.gid, direccion, esquina, Distance(the_geom,GeometryFromText('POINT(" + centro.ToString() + ")',-1)) As radio, " +
                "astext(the_geom), estado FROM k_grifos left join e_grifos_usados on k_grifos.gid=e_grifos_usados.gid " +
                "WHERE the_geom && setsrid('BOX3D(" + x1.ToString() + "," + x2.ToString() + ")'::box3d,-1) " +
                "AND Distance(GeometryFromText('POINT(" + centro.ToString() + ")',-1),the_geom) < " + radio.ToString() + " ORDER BY radio", _conexion);
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    //points = new Grifo[dr.RecordsAffected];
                    List<Grifo> l = new List<Grifo>();
                    int i = 0;
                    while (dr.Read())
                    {
                        l.Add(new Grifo(dr.GetInt32(0), dr.GetString(1), dr.IsDBNull(2)?"":dr.GetString(2), dr.GetDouble(3), PointD.FromSQLPoint(dr.GetString(4)), dr.IsDBNull(5) ? false : dr.GetBoolean(5)));
                        i++;
                    }
                    points = l.ToArray();
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return points;
        }

        public bool MarcarGrifo(int gid, int id_expediente)
        {
            NpgsqlCommand command = new NpgsqlCommand("insert into " + Tablas.GrifosUsados + " values (" + gid.ToString() + "," + id_expediente.ToString() + ", true);", _conexion);
            bool ok = true;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                ok = false;
            }
            finally
            {
                _conexion.Close();
            }
            return ok;
        }

        public bool DesmarcarGrifo(int gid)
        {
            NpgsqlCommand command = new NpgsqlCommand("delete from " + Tablas.GrifosUsados + " where gid = " + gid.ToString() + ";", _conexion);
            bool ok = true;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                ok = false;
            }
            finally
            {
                _conexion.Close();
            }
            return ok;
        }
        #endregion

        #region EXPEDIENTE
        public bool InsertarExpediente(Expediente exp)
        {
            bool error = false;
            NpgsqlCommand command = new NpgsqlCommand("insert into " + Tablas.Expedientes + 
                "(cero5, seis2, \"puntoX\", comuna, geoz, activo, \"puntoY\", hora, fecha, poblacion_villa, block, casa, telefono, quien_llama, compania, descripcion, codigo_llamado, codigo_principal, id_area) "+
                "values ('" +
                exp.Cero5 + "', '" +
                exp.Seis2 + "', '" +
                PointD.ToPgString(exp.Ubicacion.X) + "', '" +
                exp.Comuna + "', '" +
                exp.Geoz + "', '" +
                "true" + "', '" +
                PointD.ToPgString(exp.Ubicacion.Y) + "', '" +
                exp.Hora.ToLongTimeString() + "', '" +
                /*exp.Fecha.ToString()*/exp.Fecha.ToShortDateString()+" "+exp.Hora.ToLongTimeString() + "', '" +
                exp.Poblacion_villa + "', '" +
                exp.Block + "', '" +
                exp.Casa + "', '" +
                exp.Telefono + "', '" +
                exp.Quien_llama + "', '" +
                exp.Compania + "', '" +
                exp.Descripcion + "', '" +
                exp.Codigo_llamado.ToString() + "','"+
                exp.Codigo_principal.ToString()+"', "+
                exp.Id_area+");", _conexion);

            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                error = true;
            }
            finally
            {
                _conexion.Close();
            }
            return !error;
        }

        public DataTable ObtenerExpedientesActivos()
        {
            DataSet ds = new DataSet();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select id_expediente, (clave || ' ' || "+Tablas.Llamados+".descripcion) as servicio, (seis2||' '||casa) as seis2, cero5, fecha, hora, \"puntoX\",\"puntoY\", "+Tablas.Expedientes+".codigo_llamado  from " + Tablas.Expedientes + ", "+ Tablas.Llamados+ " where activo=true and "+Tablas.Expedientes+".codigo_llamado="+Tablas.Llamados+".codigo_llamado order by fecha desc, hora desc;", _conexion);
            try
            {
                da.Fill(ds);

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                ds.Tables.Add();
            }
            return ds.Tables[0];
        }

        public Expediente ObtenerExpediente(int id_expediente)
        {
            Expediente exp = null;
            NpgsqlCommand command = new NpgsqlCommand("select * from " + Tablas.Expedientes + " where id_expediente = " + id_expediente.ToString(), _conexion);

            try
            {
                _conexion.Open();
                NpgsqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    exp = new Expediente();
                    // rellenar
                    exp.Id_expediente = dr.GetInt32(0);
                    exp.Cero5 = dr.GetString(1);
                    exp.Seis2 = dr.GetString(2);
                    exp.Ubicacion = new PointD(dr.GetDouble(3), dr.GetDouble(7));
                    exp.Comuna = dr.GetString(4);
                    exp.Geoz = dr.GetString(5);
                    exp.Activo = dr.GetBoolean(6);
                    exp.Hora = dr.GetDateTime(8);
                    exp.Fecha = dr.GetDateTime(9);
                    exp.Poblacion_villa = dr.GetString(10);
                    exp.Block = dr.GetString(11);
                    exp.Casa = dr.GetString(12);
                    exp.Telefono = dr.GetString(13);
                    exp.Quien_llama = dr.GetString(14);
                    exp.Compania = dr.GetString(15);
                    exp.Descripcion = dr.GetString(16);
                    exp.Codigo_llamado = dr.GetInt32(17);
                }
            }
            catch(NpgsqlException e)
            {
                exp = null;
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return exp;
        }

        public bool ActualizarExpediente(Expediente exp)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("UPDATE " + Tablas.Expedientes + " SET " +
                "cero5 = '" + exp.Cero5 + "'," +
                "seis2 = '" + exp.Seis2 + "'," +
                "\"puntoX\" = '" + PointD.ToPgString(exp.Ubicacion.X) + "'," +
                "comuna = '" + exp.Comuna + "'," +
                "geoz = '" + exp.Geoz + "'," +
                "activo = '" + exp.Activo.ToString() + "'," +
                "\"puntoY\" = '" + PointD.ToPgString(exp.Ubicacion.Y) + "'," +
                "hora = '" + exp.Hora.ToShortTimeString() + "'," +
                "fecha = '" + exp.Fecha.ToShortDateString() + " " + exp.Hora.ToLongTimeString() + "'," +
                "poblacion_villa = '" + exp.Poblacion_villa + "'," +
                "block = '" + exp.Block + "'," +
                "casa = '" + exp.Casa + "'," +
                "telefono = '" + exp.Telefono + "'," +
                "quien_llama = '" + exp.Quien_llama + "'," +
                "compania = '" + exp.Compania + "'," +
                "descripcion = '" + exp.Descripcion + "', " +
                "codigo_llamado = '" + exp.Codigo_llamado.ToString() + "', " +
                "codigo_principal = '" + exp.Codigo_principal.ToString() + "'" +

                "WHERE id_expediente = " + exp.Id_expediente.ToString() + ";", _conexion);
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch(NpgsqlException e)
            {
                res = false;
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool EliminarExpediente(int id_expediente)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("delete from " + Tablas.Expedientes + " where id_expediente = " + id_expediente.ToString() + ";", _conexion);
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                res = false;
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }
        #endregion

        #region TIPOS DE SERVICIO
        public List<string> ObtenerTiposServicio()
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT servicio FROM " + Tablas.Expedientes + " WHERE servicio != 'Exploración';", _conexion);
            NpgsqlDataReader dr;
            List<string> l = new List<string>();
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    l.Add(dr.GetString(0));
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return l;
        }

        public Expediente[] ObtenerLlamados(int codigo_llamado)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT id_expediente,  cero5, seis2, \"puntoX\",  \"puntoY\", geoz  FROM "+
                Tablas.Expedientes + " WHERE activo=true and codigo_llamado between :a and :b order by fecha desc, hora desc;", _conexion);
            command.Parameters.Add("a", NpgsqlTypes.NpgsqlDbType.Integer).Value = codigo_llamado * 100;
            command.Parameters.Add("b", NpgsqlTypes.NpgsqlDbType.Integer).Value = codigo_llamado * 100 + 99;
            NpgsqlDataReader dr;
            List<Expediente> l = new List<Expediente>();

            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Expediente exp = new Expediente();
                    exp.Id_expediente = dr.GetInt32(0);
                    exp.Cero5 = dr.GetString(1);
                    exp.Seis2 = dr.GetString(2);
                    exp.Ubicacion = new PointD(dr.GetDouble(3), dr.GetDouble(4));
                    exp.Geoz = dr.GetString(5);
                    l.Add(exp);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return l.ToArray();
        }
        #endregion

        #region AGENDA
        public bool TablaExiste(string nombre)
        {
            bool res = false;
            NpgsqlCommand command = new NpgsqlCommand("select exists(select relname from pg_class where relname=:tabla);", _conexion);
            try
            {
                command.Parameters.Add("tabla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nombre;
                _conexion.Open();
                res = (bool)command.ExecuteScalar();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return res;
        }

        public Clave[] ObtenerClaves(int? id)
        {
            List<Clave> l = new List<Clave>();
            NpgsqlCommand command = new NpgsqlCommand("select * from " + Tablas.AgendaCat, _conexion);
            if (id.HasValue)
            {
                command.CommandText += " where id_cat=" + id.Value.ToString();
            }
            command.CommandText += " order by orden";
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Clave c = new Clave();
                    c.Id_cat = dr.GetInt32(0);
                    c.Nombre = dr.GetString(1);
                    c.Ref_espacial = dr.GetBoolean(2);
                    c.Tabla = dr.IsDBNull(3)? "" : dr.GetString(3);
                    l.Add(c);
                }
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l.ToArray();
        }

        public bool InsertarClave(string nombre, bool ref_espacial, string tabla)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("insert into "+Tablas.AgendaCat+" (nombre, ref_espacial, tabla) values (:nombre, :ref, :tabla);", _conexion);
            command.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nombre;
            command.Parameters.Add("ref", NpgsqlTypes.NpgsqlDbType.Boolean).Value = ref_espacial;
            command.Parameters.Add("tabla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = tabla;

            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool ActualizarClave(int id_cat, string nombre, bool ref_espacial, string tabla)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("update " + Tablas.AgendaCat + " set nombre=:nombre, ref_espacial=:ref, tabla=:tabla where id_cat=:id_cat;", _conexion);
            command.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nombre;
            command.Parameters.Add("ref", NpgsqlTypes.NpgsqlDbType.Boolean).Value = ref_espacial;
            command.Parameters.Add("tabla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = tabla;
            command.Parameters.Add("id_cat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_cat;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                res = false;
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool EliminarClave(int id_cat)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("delete from " + Tablas.AgendaCat + "  where id_cat=:id_cat;", _conexion);
            command.Parameters.Add("id_cat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_cat;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public KeyValuePair<int, string>[] ObtenerSubCats(int id_cat)
        {
            List<KeyValuePair<int, string>> l = new List<KeyValuePair<int, string>>();
            NpgsqlCommand command = new NpgsqlCommand("select id_subcat, nombre from " + Tablas.AgendaSubcat + " where id_cat=:id_cat;", _conexion);
            command.Parameters.Add("id_cat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_cat;
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    KeyValuePair<int, string> k = new KeyValuePair<int, string>(dr.GetInt32(0), dr.GetString(1));
                    l.Add(k);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l.ToArray();
        }

        public KeyValuePair<int, string> ObtenerSubCat(int id_subcat)
        {
            KeyValuePair<int, string> l = new KeyValuePair<int, string>() ;
            NpgsqlCommand command = new NpgsqlCommand("select id_subcat, nombre from " + Tablas.AgendaSubcat + " where id_subcat=:id_subcat;", _conexion);
            command.Parameters.Add("id_subcat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_subcat;
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    l = new KeyValuePair<int, string>(dr.GetInt32(0), dr.GetString(1));
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l;
        }

        public bool InsertarSubCat(int id_cat, string nombre)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("insert into " + Tablas.AgendaSubcat + " (id_cat, nombre) values (:id_cat, :nombre);", _conexion);
            command.Parameters.Add("id_cat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_cat;
            command.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nombre;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool ActualizarSubCat(int id_subcat, string nombre)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("update " + Tablas.AgendaSubcat + " set nombre=:nombre where id_subcat=:id_subcat;", _conexion);
            command.Parameters.Add("id_subcat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_subcat;
            command.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nombre;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool EliminarSubCat(int id_subcat)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("delete from " + Tablas.AgendaSubcat + "  where id_subcat=:id_subcat;", _conexion);
            command.Parameters.Add("id_subcat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_subcat;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public Empresa[] ObtenerEmpresas(int id_subcat)
        {
            List<Empresa> l = new List<Empresa>();
            NpgsqlCommand command = new NpgsqlCommand("select id_empresa,nombre, telefono from " + Tablas.AgendaDetalle + " where id_subcat=:id_subcat order by nombre;", _conexion);
            command.Parameters.Add("id_subcat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_subcat;
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Empresa c = new Empresa();
                    c.Id_empresa = dr.GetInt32(0);
                    c.Nombre = dr.GetString(1);
                    c.Telefono = dr.GetString(2);
                    l.Add(c);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l.ToArray();
        }

        public Empresa ObtenerEmpresa(int id_empresa)
        {
            Empresa c = new Empresa();
            NpgsqlCommand command = new NpgsqlCommand("select id_empresa,nombre, telefono from " + Tablas.AgendaDetalle + " where id_empresa=:id_empresa;", _conexion);
            command.Parameters.Add("id_empresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_empresa;
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    c.Id_empresa = dr.GetInt32(0);
                    c.Nombre = dr.GetString(1);
                    c.Telefono = dr.GetString(2);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return c;
        }

        public bool InsertarEmpresa(int id_subcat, string nombre, string telefono)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("insert into " + Tablas.AgendaDetalle + " (id_subcat, nombre, telefono) values (:id_subcat, :nombre, :telefono);", _conexion);
            command.Parameters.Add("id_subcat", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_subcat;
            command.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nombre;
            command.Parameters.Add("telefono", NpgsqlTypes.NpgsqlDbType.Varchar).Value = telefono;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool ActualizarEmpresa(int id_empresa, string nombre, string telefono)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("update " + Tablas.AgendaDetalle + " set nombre=:nombre, telefono=:telefono where id_empresa=:id_empresa;", _conexion);
            command.Parameters.Add("id_empresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_empresa;
            command.Parameters.Add("nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = nombre;
            command.Parameters.Add("telefono", NpgsqlTypes.NpgsqlDbType.Varchar).Value = telefono;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool EliminarEmpresa(int id_empresa)
        {
            bool res = true;
            NpgsqlCommand command = new NpgsqlCommand("delete from " + Tablas.AgendaDetalle + "  where id_empresa=:id_empresa;", _conexion);
            command.Parameters.Add("id_empresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_empresa;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                res = false;
            }
            finally
            {
                _conexion.Close();
            }
            return res;
        }

        public bool? ObtenerEmpresaSolicitado(int id_empresa, int id_expediente)
        {
            bool? ret = null;
            NpgsqlCommand command = new NpgsqlCommand("select estado from " + Tablas.RecursosEmpresas + " where id_empresa=:id_empresa and id_expediente=:id_expediente;", _conexion);
            command.Parameters.Add("id_empresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_empresa;
            command.Parameters.Add("id_expediente", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_expediente;
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    ret = dr.GetBoolean(0);
                }
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return ret;
        }

        public string ObtenerNombreEmpresa(PointD ubicacion, string tabla)
        {
            string ret = null;
            NpgsqlCommand command = new NpgsqlCommand("select sgc2 from " + tabla + " WHERE intersects(geometryfromtext('POINT(" + ubicacion.ToString() + ")',-1),the_geom);", _conexion);
            try
            {
                _conexion.Open();
                ret = (string)command.ExecuteScalar();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return ret;
        }

        public bool MarcarEmpresa(int id_empresa, int id_expediente, bool estado)
        {
            bool ret = true, existe=true;
            NpgsqlCommand command = new NpgsqlCommand("select exists(select estado from "+Tablas.RecursosEmpresas+" where id_empresa=:id_empresa and id_expediente=:id_expediente);", _conexion);
            command.Parameters.Add("id_empresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_empresa;
            command.Parameters.Add("id_expediente", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_expediente;
            try
            {
                _conexion.Open();
                existe = (bool)command.ExecuteScalar();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                ret = false;
            }
            finally
            {
                _conexion.Close();
            }
            if (ret == false)
                return ret;
            if (existe)
            {
                command = new NpgsqlCommand("update " + Tablas.RecursosEmpresas + " set estado=:estado where id_empresa=:id_empresa and id_expediente=:id_expediente;", _conexion);
            }
            else
            {
                command = new NpgsqlCommand("insert into " + Tablas.RecursosEmpresas + " (estado, id_empresa, id_expediente) values (:estado, :id_empresa, :id_expediente);", _conexion);
            }
            command.Parameters.Add("estado", NpgsqlTypes.NpgsqlDbType.Boolean).Value = estado;
            command.Parameters.Add("id_empresa", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_empresa;
            command.Parameters.Add("id_expediente", NpgsqlTypes.NpgsqlDbType.Integer).Value = id_expediente;
            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                ret = false;
            }
            finally
            {
                _conexion.Close();
            }
            return ret;
        }

        
        #endregion

        #region PUNTOS DE INTERES
        public PuntoInteres[] ObtenerPuntosInteres()
        {
            NpgsqlCommand command = new NpgsqlCommand("select radio_text, label1, combo1, label2, tabla from " + Tablas.PuntosInteres, _conexion);
            NpgsqlDataReader dr;
            List<PuntoInteres> l = new List<PuntoInteres>();
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    PuntoInteres p = new PuntoInteres();
                    p.RadioText = dr.GetString(0);
                    p.Label1 = dr.GetString(1);
                    p.Combo1 = dr.GetString(2);
                    p.Label2 = dr.GetString(3);
                    p.Tabla = dr.GetString(4);
                    l.Add(p);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l.ToArray();
        }


        public PuntoInteres[] ObtenerPuntosInteresCarretera()
        {
            NpgsqlCommand command = new NpgsqlCommand("select radio_text, label1, combo1, label2, tabla from " + Tablas.PuntosInteresCarretera, _conexion);
            NpgsqlDataReader dr;
            List<PuntoInteres> l = new List<PuntoInteres>();
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    PuntoInteres p = new PuntoInteres();
                    p.RadioText = dr.GetString(0);
                    p.Label1 = dr.GetString(1);
                    p.Combo1 = dr.GetString(2);
                    p.Label2 = dr.GetString(3);
                    p.Tabla = dr.GetString(4);
                    l.Add(p);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l.ToArray();
        }

        public PInteres[] ObtenerPInteres(int index, string tabla)
        {
            NpgsqlCommand command = new NpgsqlCommand("select sgc2, astext(the_geom) from " + tabla +" where sgc1=:index;", _conexion);
            command.Parameters.Add("index", NpgsqlTypes.NpgsqlDbType.Integer).Value = index;
            NpgsqlDataReader dr;
            PInteres[] p = null;
            List<PInteres> l = new List<PInteres>();
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    PInteres pi = new PInteres(dr.GetString(0), PointD.FromSQLPoint(dr.GetString(1)));

                    l.Add(pi);
                }
                p = l.ToArray();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
                p = null;
            }
            finally
            {
                _conexion.Close();
            }

            return p;
        }
        #endregion

        #region TIPOS DE LLAMADO
        public KeyValuePair<string, int>[] ObtenerTipoLlamado()
        {
            List<KeyValuePair<string, int>> l = new List<KeyValuePair<string, int>>();
            NpgsqlCommand command = new NpgsqlCommand("select codigo_llamado, clave || ' ' || descripcion from " + Tablas.Llamados + " where codigo_llamado<100 order by codigo_llamado", _conexion);
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    KeyValuePair<string, int> k = new KeyValuePair<string, int>(dr.GetString(1), dr.GetInt32(0));
                    l.Add(k);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l.ToArray();
        }

        public string ObtenerTipoLlamado(int codigo_llamado)
        {
            string ret=null;
            NpgsqlCommand command = new NpgsqlCommand("select clave || ' ' || descripcion from " + Tablas.Llamados + " where codigo_llamado=:codigo order by codigo_llamado", _conexion);
            command.Parameters.Add("codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = codigo_llamado;
            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    ret = dr.GetString(0);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return ret;
        }


        public List<KeyValuePair<string, int>> ObtenerSubTipoLlamados(int codigo_llamado)
        {
            List<KeyValuePair<string, int>> l = new List<KeyValuePair<string, int>>();
            NpgsqlCommand command = new NpgsqlCommand("select codigo_llamado, clave || ' ' || descripcion from " + Tablas.Llamados + " where codigo_llamado between :a and :b", _conexion);
            command.Parameters.Add("a", NpgsqlTypes.NpgsqlDbType.Integer).Value = codigo_llamado*100;
            command.Parameters.Add("b", NpgsqlTypes.NpgsqlDbType.Integer).Value = codigo_llamado*100+99;

            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    KeyValuePair<string, int> k = new KeyValuePair<string, int>(dr.GetString(1), dr.GetInt32(0));
                    l.Add(k);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return l;
        }

        public string ObtenerClaveLlamado(int codigo_llamado)
        {
            string s = null;
            NpgsqlCommand command = new NpgsqlCommand("select clave from " + Tablas.Llamados + " where codigo_llamado= :a", _conexion);
            command.Parameters.Add("a", NpgsqlTypes.NpgsqlDbType.Integer).Value = codigo_llamado;

            NpgsqlDataReader dr;
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    s = dr.GetString(0);
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }

            return s;
        }


        #endregion


        public List<string> ObtenerHojas(PointD x1, PointD x2)
        {
            NpgsqlDataReader dr;
            List<string> s = new List<string>();

            NpgsqlCommand command = new NpgsqlCommand("SELECT hoja FROM k_hojas WHERE the_geom && setsrid('BOX3D("+x1.ToString()+","+x2.ToString()+")'::box3d,-1)", _conexion);
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        s.Add("H_"+dr.GetInt64(0).ToString()+".ecw");
                    }
                   
                }

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return s;
        }
        
        public int claveCarro63(string clave, int punto_x, int punto_y, string calle_1, string calle_2)
        {
            string[] clave_final = clave.Split(':');
            int resultado_query = 0;

            limpiarTablaZsTraspaso();

            NpgsqlCommand command = new NpgsqlCommand("insert into " + Tablas.Traspasos +
                "(clave, punto_x, punto_y, calle_1, calle_2, descripcion_clave) " +
                "values ('" + clave_final[0] + "', " + punto_x + ", " + punto_y + ", '" + calle_1 + "', '" + calle_2 + "', '" + clave + "');", _conexion);

            try
            {
                _conexion.Open();
                resultado_query = command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return resultado_query;
        }

        public void limpiarTablaZsTraspaso()
        {
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM zs_trapasos", _conexion);

            try
            {
                _conexion.Open();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
        }

        public List<string> ObtenerCallesExp2(string coordenadas)
        {
            string[] split_coordenadas = coordenadas.Split(' ');
            string[] val1_split = split_coordenadas[0].ToString().Split('.');
            string[] val2_split = split_coordenadas[1].ToString().Split('.');

            int valor_sumado1 = Convert.ToInt32(val1_split[0]) + 200;
            int valor_sumado2 = Convert.ToInt32(val2_split[0]) + 200;
            string valor_sumado_final_1 = "" + valor_sumado1 + " " + valor_sumado2 + "";

            int valor_restado1 = Convert.ToInt32(val1_split[0]) - 200;
            int valor_restado2 = Convert.ToInt32(val2_split[0]) - 200;
            string valor_restado_final_1 = "" + valor_restado1 + " " + valor_restado2 + "";

            List<string> Calles = new List<string>();
            NpgsqlDataReader dr;
            NpgsqlCommand command = new NpgsqlCommand("SELECT nombre, Distance(the_geom,GeometryFromText('POINT(" + coordenadas + ")',-1)) As radio FROM a241719_rm  WHERE the_geom && setsrid('BOX3D(" + valor_sumado_final_1 + "," + valor_restado_final_1 + ")'::box3d,-1) AND Distance(GeometryFromText('POINT(" + coordenadas + ")',-1),the_geom) < 200 ORDER BY radio;", _conexion);
            try
            {
                _conexion.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                    Calles.Add(dr.GetString(0));

            }
            catch (NpgsqlException e)
            {
                TraceEx(e);
            }
            finally
            {
                _conexion.Close();
            }
            return Calles;
        }
    }   
    public enum TipoServidor
    {
        Local,Remoto
    };
}

