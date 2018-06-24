using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Npgsql;
using PostgresDataAccess;
using Zeus.Data;
using Zeus.Util;


namespace Zeus.PluginGeocodificacion
{
    public class Geocodificacion
    {
        public GeoReferencia[] BuscarEsquina(string calle1, string calle2, string comuna, bool rm)
        {
            int id1, id2;
            e171924r t_rm = new e171924r();
            z_gsl gsl=new z_gsl();
            z_gclase clase=new z_gclase();
            z_gcom com=new z_gcom();
            List<GeoReferencia> GeoRef = new List<GeoReferencia>();
            DataSet calles=null;

            try
            {
                // obtener ids
                id1 = t_rm.GetRecno(calle1);
                id2 = t_rm.GetRecno(calle2);

                if (rm)
                {
                    calles = gsl.Get_gsl(id1, id2);
                }
                else
                {
                    // filtrado por comunas
                    List<int> comunas = null;
                    if (string.IsNullOrEmpty(comuna))
                    {
                        // comunas cuerpo
                        comunas = new k_comunas_cuerpo().GetIDs();
                    }
                    else
                    {
                        // una comuna
                        comunas = new List<int>();
                        comunas.Add(com.GetID(comuna));
                    }
                    calles = gsl.Get_gsl(id1, id2, comunas);
                }

                foreach (DataRow dr in calles.Tables[0].Rows)
                {
                    // obtener clase e ingresar al array
                    GeoReferencia gr = new GeoReferencia();
                    gr.Dato1 = clase.GetClase(Convert.ToInt32(dr["gsl_6"])) + " " + calle1;
                    gr.Dato2 = clase.GetClase(Convert.ToInt32(dr["gsl_7"])) + " " + calle2;
                    gr.Dato3 = com.GetComuna(Convert.ToInt32(dr["gsl_5"]));

                    string[] pto = (dr["gsl_4"] as string).Split(' ');

                    gr.Punto1 = new PointD(pto[0], pto[1]);
                    gr.TipoRef = TipoReferencia.Esquina;

                    GeoRef.Add(gr);
                }

            }
            catch (Exception e)
            {
                Log.ShowAndLog(e);
            }
            return GeoRef.ToArray();
        }

        [Obsolete("Usar BuscarEsquina(string,string,string,bool")]
        public GeoReferencia[] BuscarEsquina(string strCalle1, string strCalle2, bool rm)
        {
            string Pto;
            string[] CadaPto;
            string[] CadaValorTem;
            string[] CadaValor;
            //GeoReferencia[] GeoRef = null;
            List<GeoReferencia> GeoRef = new List<GeoReferencia>();
            int i;


            if (rm)
            {
                Pto = this.BuscaEsquina(strCalle1, strCalle2, Tablas.Esquinas_RM);
            }
            else
            {
                Pto = this.BuscaEsquina(strCalle1, strCalle2, Tablas.Esquinas_Cuerpo);
            }

            CadaPto = Regex.Split(Pto.Trim(), "___");
            CadaValorTem = CadaPto[0].Split('_');
            // ERROR: Not supported in C#: ReDimStatement
            
            for (i = 0; i <= (int.Parse(CadaValorTem[4]) - 1); i++)
            {
                GeoReferencia gr = new GeoReferencia();
                CadaValor = CadaPto[i].Split("_".ToCharArray());
                gr.Dato1 = CadaValor[1] + " " + strCalle1.Trim();
                gr.Dato2 = CadaValor[2] + " " + strCalle2.Trim();
                gr.Dato3 = CadaValor[3];
                // de string a point
                Regex re = new Regex("POINT\\(([0-9]*\\.?[0-9]*)\\s([0-9]*\\.?[0-9]*)\\)");
                PointD p = new PointD(re.Match(CadaValor[0]).Groups[1].ToString(), re.Match(CadaValor[0]).Groups[2].ToString());

                gr.Punto1 = p;
                gr.TipoRef = TipoReferencia.Esquina;
                GeoRef.Add(gr);
            }
            return GeoRef.ToArray();
        }

        public GeoReferencia[] BuscarAltura(string strCalle, long intAltura)
        {
            string Pto = this.BuscaAltura(strCalle, intAltura);
            string[] CadaPto;
            string[] CadaValorTem;
            string[] CadaValor;
            List<GeoReferencia> GeoRef = new List<GeoReferencia>();
            int i;

            CadaPto = Regex.Split(Pto.Trim(),"___");
            CadaValorTem = CadaPto[0].Split('_');
            if (strTipoGeo == "alturas")
            {
                // ERROR: Not supported in C#: ReDimStatement

                for (i = 0; i <= (int.Parse(CadaValorTem[5]) - 1); i++)
                {
                    CadaValor = CadaPto[i].Split('_');
                    GeoReferencia gr = new GeoReferencia();
                    gr.Dato1 = CadaValor[1] + " " + strCalle.Trim();
                    gr.Dato2 = CadaValor[3];
                    gr.Dato3 = CadaValor[4];
                    // de string a point
                    Regex re = new Regex("POINT\\(([0-9]*\\.?[0-9]*)\\s([0-9]*\\.?[0-9]*)\\)");
                    //Dim p As New PointF(CDec(re.Match(CadaValor(0)).Groups(1).ToString().Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)), CDec(re.Match(CadaValor(0)).Groups(2).ToString().Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)))
                    PointD p = new PointD(re.Match(CadaValor[0]).Groups[1].ToString(), re.Match(CadaValor[0]).Groups[2].ToString());
                    gr.Punto1 = p;
                    gr.TipoRef = TipoReferencia.Altura;
                    GeoRef.Add(gr);
                }
            }
            if (strTipoGeo == "tramos")
            {
                // ERROR: Not supported in C#: ReDimStatement

                for (i = 0; i <= (int.Parse(CadaValorTem[4]) - 1); i++)
                {
                    CadaValor = CadaPto[i].Split('_');
                    GeoReferencia gr = new GeoReferencia();
                    gr.Dato1 = CadaValor[1];
                    gr.Dato2 = CadaValor[2];
                    gr.Dato3 = CadaValor[3];
                    //vItem.SubItems(3) = CadaValor(0)
                    // de string a point
                    Regex re = new Regex("BOX\\(([0-9]*\\.?[0-9]*)\\s([0-9]*\\.?[0-9]*),([0-9]*\\.?[0-9]*)\\s([0-9]*\\.?[0-9]*)\\)");
                    //Dim p As New PointF(CDec(re.Match(CadaValor(0)).Groups(1).ToString().Replace(".", ",")), CDec(re.Match(CadaValor(0)).Groups(2).ToString().Replace(".", ",")))
                    PointD p = new PointD(re.Match(CadaValor[0]).Groups[1].ToString(), re.Match(CadaValor[0]).Groups[2].ToString());

                    gr.Punto1 = p;
                    //p = New PointF(CDec(re.Match(CadaValor(0)).Groups(3).ToString().Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)), CDec(re.Match(CadaValor(0)).Groups(4).ToString().Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)))
                    p = new PointD(re.Match(CadaValor[0]).Groups[3].ToString(), re.Match(CadaValor[0]).Groups[4].ToString());

                    gr.Punto2 = p;
                    gr.TipoRef = TipoReferencia.Tramo;
                    GeoRef.Add(gr);

                }
            }

            return GeoRef.ToArray();
        }
        private string BuscaEsquina(string strCalle1, string strCalle2, string TablaEsquinas)
        {
            NpgsqlDataReader dr;
            string strSQL;
            string the_geom = "";
            bool boolEnIf;
            string EntrePtos;
            string[] the_geom_array;
            int i;
            string the_geom_Conca;
            //Dim Res_the_geom As String
            string strComuna;
            string strClase;
            //Dim intNumRs, n As Integer
            long nVeces;

            boolEnIf = true;

            strSQL = "SELECT DISTINCT(astext(intersection((SELECT geomunion(the_geom) as the_geom";
            strSQL = strSQL + " FROM " + TablaEsquinas + " WHERE nombre = '" + strCalle1 + "'), (SELECT geomunion(the_geom) As the_geom";
            strSQL = strSQL + " FROM " + TablaEsquinas + " WHERE nombre = '" + strCalle2 + "')))) As the_geom";
            strSQL = strSQL + " FROM " + TablaEsquinas + " WHERE (nombre = '" + strCalle1 + "' OR nombre = '" + strCalle2 + "')";
            strSQL = strSQL + " AND intersects((SELECT geomunion(the_geom) As the_geom";
            strSQL = strSQL + " FROM " + TablaEsquinas + " WHERE nombre = '" + strCalle1 + "'), (SELECT geomunion(the_geom) As the_geom";
            strSQL = strSQL + " FROM " + TablaEsquinas + " WHERE nombre = '" + strCalle2 + "'));";
            NpgsqlCommand command = new NpgsqlCommand(strSQL, Data.Conexion);
            Data.Conexion.Open();
            dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                the_geom_Conca = "";
                while (dr.Read())
                {
                    the_geom = dr.GetString(0);

                    //*** MULTIPOINT
                    if (the_geom.Contains("MULTIPOINT"))
                    {
                        boolEnIf = false;
                        the_geom = the_geom.Replace("MULTIPOINT(", "");
                        the_geom = the_geom.Replace(")", "");
                        the_geom_array = the_geom.Split(',');
                        //                for ($i=0; $i < count($the_geom_array); $i++) {
                        for (i = 0; i < the_geom_array.Length; i++)
                        {
                            the_geom = "POINT(" + the_geom_array[i] + ")";
                            //                   //IdTramosEnComun($the_geom);
                            strComuna = ObtieneComuna(the_geom);
                            strClase = ObtieneClase(the_geom, strCalle1, strCalle2);
                            EntrePtos = "___";
                            //               $the_coord .= $the_geom."_".$clase."_".$comuna."_".count($the_geom_array).$entreptos;
                            the_geom_Conca = the_geom_Conca + the_geom + "_" + strClase + "_" + strComuna + "_" + "$" + EntrePtos;
                        }
                        nVeces = CuantasVeces(the_geom_Conca, "$");
                        the_geom_Conca = the_geom_Conca.Replace("$", nVeces.ToString());
                        the_geom = the_geom_Conca;
                    }

                    //*** GEOMETRYCOLLECTION
                    if (the_geom.Contains("GEOMETRYCOLLECTION"))
                    {
                        boolEnIf = false;
                        the_geom = the_geom.Replace("GEOMETRYCOLLECTION(", "");
                        the_geom_array = the_geom.Split(',');
                        for (i = 0; i < the_geom_array.Length; i++)
                        {
                            if ((the_geom_array[i].Contains("POINT") && (!the_geom_array[i].Contains("MULTIPOINT")) && (!(the_geom_array[i].Contains("))")))))
                            {
                                the_geom = the_geom_array[i];
                                strComuna = ObtieneComuna(the_geom);
                                strClase = ObtieneClase(the_geom, strCalle1, strCalle2);
                                EntrePtos = "___";
                                the_geom_Conca = the_geom_Conca + the_geom + "_" + strClase + "_" + strComuna + "_" + "$" + EntrePtos;
                            }
                        }
                        nVeces = CuantasVeces(the_geom_Conca, "$");
                        the_geom_Conca = the_geom_Conca.Replace("$", nVeces.ToString());
                        the_geom = the_geom_Conca;
                    }

                    //*** GEOMETRYCOLLECTION EMPTY
                    if (!(the_geom.Contains("GEOMETRYCOLLECTION EMPTY")) && (boolEnIf))
                    {
                        strComuna = ObtieneComuna(the_geom);
                        strClase = ObtieneClase(the_geom, strCalle1, strCalle2);
                        EntrePtos = "___";
                        the_geom = the_geom + "_" + strClase + "_" + strComuna + "_" + "1" + EntrePtos;
                    }
                }
            }
            strTipoGeo = "esquinas";
            Data.Conexion.Close();
            return the_geom;
        }
        private string ObtieneComuna(string strPto)
        {
            //Dim rs As Recordset
            NpgsqlDataReader dr;
            string strSQL;
            string the_comuna;

            strSQL = "SELECT comuna";
            strSQL = strSQL + " FROM " + Tablas.Comunas;
            strSQL = strSQL + " WHERE intersects(geometryfromtext('" + strPto + "',-1),the_geom)";
            NpgsqlCommand command = new NpgsqlCommand(strSQL, Data.Conexion);
            if (Data.Conexion.State == ConnectionState.Closed)
            {
                Data.Conexion.Open();
            }
            dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                the_comuna = dr.GetString(0);
                //rs.Fields("comuna")
            }
            else
            {
                the_comuna = "0";
            }
            Data.Conexion.Close();
            return the_comuna;
        }



        //'//*** OBTENER CLASE A PARTIR DE UN PUNTO
        private string ObtieneClase(string strPto, string strCalle1, string strCalle2)
        {
            NpgsqlDataReader dr;
            string strSQL;
            string the_clases;
            string the_clase1;
            string the_clase2;


            strSQL = "SELECT clase";
            strSQL = strSQL + " FROM " + Tablas.Alturas;
            strSQL = strSQL + " WHERE geometryfromtext('" + strPto + "',-1) && expand(the_geom,0.5)";
            strSQL = strSQL + " AND nombre = '" + strCalle1.Trim() + "'";
            NpgsqlCommand command = new NpgsqlCommand(strSQL, Data.Conexion);
            Data.Conexion.Open();
            dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                the_clase1 = dr.GetString(0);
            }
            else
            {
                the_clase1 = "0";
            }

            Data.Conexion.Close();
            strSQL = "SELECT clase";
            strSQL = strSQL + " FROM " + Tablas.Alturas;
            strSQL = strSQL + " WHERE geometryfromtext('" + strPto + "',-1) && expand(the_geom,0.5)";
            strSQL = strSQL + " AND nombre = '" + strCalle2.Trim() + "'";
            command = new NpgsqlCommand(strSQL, Data.Conexion);
            Data.Conexion.Open();
            dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                the_clase2 = dr.GetString(0);
            }
            else
            {
                the_clase2 = "0";
            }
            the_clases = the_clase1 + "_" + the_clase2;
            Data.Conexion.Close();
            return the_clases;
        }

        private long tCuadra(long Id, string T, long d2, int mgsl_6, long d1, int mgsl_10)
        {
            long dTramo=0;

            if ((T == "t1"))
            {
                if ((mgsl_6 == 0))
                {
                    dTramo = d1;
                }
                if ((mgsl_10 == 0))
                {
                    dTramo = d2;
                }
            }
            else
            {
                if ((mgsl_6 == -1))
                {
                    dTramo = d1;
                }
                if ((mgsl_10 == 1))
                {
                    dTramo = d2;
                }
            }
            return dTramo;
        }



        private string InterpolaElPto(long idvial, double distan, long Length, int intTransito)
        {
            NpgsqlDataReader dr;
            double pstg;
            string the_point;
            string strSQL;
            string strPstg;

            if (((intTransito == 1) | (intTransito == 0)))
            {
                pstg = Math.Round((distan / Length), 3);
            }
            else
            {
                pstg = Math.Round(1 - (distan / Length), 3);
            }
            if ((distan == Length))
            {
                pstg = 0.5;
            }
            strPstg =  pstg.ToString().Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            strPstg = strPstg.Replace("-", "");
            strSQL = "SELECT AsText(line_interpolate_point(geometryN(the_geom,1)," + strPstg + ")) As inter_point";
            strSQL = strSQL + " FROM " + Tablas.Alturas;
            strSQL = strSQL + " WHERE " + id_altura + " = " + idvial;
            NpgsqlCommand command = new NpgsqlCommand(strSQL, Data.Conexion);
            if (Data.Conexion.State == ConnectionState.Closed)
            {
                Data.Conexion.Open();
            }
            dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                the_point = dr.GetString(0);
            }
            else
            {
                the_point = "SinData";
            }
            Data.Conexion.Close();
            return the_point;
        }


        private void Opciones(string nombre)
        {
            NpgsqlDataReader dr;
            string strSQL;
            string the_geom_Conca;
            string strClase;
            string strComuna;
            string the_geom_tramo;
            string nVeces;

            the_geom_Conca = "";
            strSQL = "SELECT eje.clase As clase, com.comuna As comuna, extent(astext(eje.the_geom)) as the_geom_alt ";
            strSQL = strSQL + " FROM " + Tablas.Alturas + " eje, " + Tablas.Comunas + " com ";
            strSQL = strSQL + " WHERE WITHIN(eje.the_geom, com.the_geom) ";
            strSQL = strSQL + " AND eje.nombre = '" + nombre + "' ";
            strSQL = strSQL + " GROUP BY eje.clase, com.comuna ORDER BY com.comuna, eje.clase ";
            NpgsqlCommand command = new NpgsqlCommand(strSQL, Data.Conexion);
            if (Data.Conexion.State == ConnectionState.Closed)
            {
                Data.Conexion.Open();
            }
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                strClase = dr.GetString(0);
                strComuna = dr.GetString(1);
                the_geom_tramo = dr.GetString(2);
                the_geom_Conca = the_geom_Conca + the_geom_tramo + "_" + strClase + "_" + nombre + "_" + strComuna + "_" + "$" + "___";
            }
            nVeces = CuantasVeces(the_geom_Conca, "$").ToString();
            the_geom_Conca = the_geom_Conca.Replace( "$", nVeces);
            the_coord = the_geom_Conca;
            Data.Conexion.Close();
        }

        //*** OBTENER ALTURAS
        private string BuscaAltura(string strCalle, long intAltura)
        {
            double intR;
            long intE;
            double intD;
            string strSQLt;
            //Dim strOpciones As String
            string strTipo;
            bool variable;
            bool intRes;

            intR = intAltura / 2.0;
            intE = (long)intR;
            intD = intR - intE;

            the_coord = "";
            if ((intD == 0))
            {
                strSQLt = TipoQuery1(intAltura.ToString());
                strTipo = "t1";
            }
            else
            {
                strSQLt = TipoQuery2(intAltura.ToString());
                strTipo = "t2";
            }
            variable = false;
            intRes = Cuadras(variable, strCalle, (long)intAltura, strSQLt, strTipo);
            strTipoGeo = "alturas";
            if ((intRes))
            {
                Opciones(strCalle);
                strTipoGeo = "tramos";
            }
            return the_coord;
        }

        //*** QUERY 1
        private string TipoQuery1(string strAltura)
        {
            string strSQLor;

            strSQLor = "((((((((mgsl_6 = 0 AND mgsl_2 = -1 AND inider >= " + strAltura + " AND terder <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_6 = 0 AND mgsl_2 = 1 AND mgsl_9 = 1 AND inider <= " + strAltura + " AND terder >= " + strAltura + "))) ";
            strSQLor = strSQLor + " OR (((mgsl_10 = 0 AND mgsl_5 = -1 AND iniizq >= " + strAltura + " AND terizq <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_10 = 0 AND mgsl_5 = 1 AND mgsl_3 = 1 AND iniizq <= " + strAltura + " AND terizq >= " + strAltura + "))))) ";
            strSQLor = strSQLor + " OR (((((mgsl_6 = 0 AND mgsl_2 = -1 AND inider >= " + strAltura + " AND terder <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_6 = 0 AND mgsl_2 = 1 AND mgsl_9 = 0 AND inider <= " + strAltura + " AND terder >= " + strAltura + "))) ";
            strSQLor = strSQLor + " OR (((mgsl_10 = 0 AND mgsl_5 = -1 AND iniizq >= " + strAltura + " AND terizq <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_10 = 0 AND mgsl_5 = 1 AND mgsl_3 = 0 AND iniizq <= " + strAltura + " AND terizq >= " + strAltura + "))))))) ";
            strSQLor = strSQLor + " OR ((iniizq = " + strAltura + " AND mgsl_12 = 1) or (inider = " + strAltura + " AND mgsl_7 = 0))) ";
            return strSQLor;
        }

        //*** QUERY 2
        private string TipoQuery2(string strAltura)
        {
            string strSQLor;

            strSQLor = "((((((((mgsl_6 = -1 AND mgsl_2 = -1 AND inider >= " + strAltura + " AND terder <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_6 = -1 AND mgsl_2 = 1 AND mgsl_9 = 1 AND inider <= " + strAltura + " AND terder >= " + strAltura + "))) ";
            strSQLor = strSQLor + " OR (((mgsl_10 = 1 AND mgsl_5 = -1 AND iniizq >= " + strAltura + " AND terizq <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_10 = 1 AND mgsl_5 = 1 AND mgsl_3 = 1 AND iniizq <= " + strAltura + " AND terizq >= " + strAltura + "))))) ";
            strSQLor = strSQLor + " OR (((((mgsl_6 = -1 AND mgsl_2 = -1 AND inider >= " + strAltura + " AND terder <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_6 = -1 AND mgsl_2 = 1 AND mgsl_9 = 0 AND inider <= " + strAltura + " AND terder >= " + strAltura + "))) ";
            strSQLor = strSQLor + " OR (((mgsl_10 = 1 AND mgsl_5 = -1 AND iniizq >= " + strAltura + " AND terizq <= " + strAltura + ") ";
            strSQLor = strSQLor + " OR (mgsl_10 = 1 AND mgsl_5 = 1 AND mgsl_3 = 0 AND iniizq <= " + strAltura + " AND terizq >= " + strAltura + "))))))) ";
            strSQLor = strSQLor + " OR ((iniizq = " + strAltura + " AND mgsl_12 = 1) OR (inider = " + strAltura + " AND mgsl_7 = 0))) ";
            return strSQLor;
        }

        //*** CUADRAS
        private bool Cuadras(bool S, string C, long A, string O, string T)
        {

            NpgsqlDataReader dr;
            string strSQLw;
            string strSQL;
            string bq;
            string strClase;
            string EntrePtos;
            string comuna;
            string the_point;
            int intTransito;
            long longCuadra;
            long longIdVial;
            long dIzq;
            long dDer;
            long tF;
            long fF;
            long DisIni;
            long DelAlt;
            long mi_alt;
            double DelAltp;
            long longLength;
            double distan;
            bool booRec;
            long nVeces;
            string the_geom_Conca;

            the_geom_Conca = "";
            strSQLw = "FROM " + Tablas.Alturas + " WHERE " + O + " AND nombre = '" + C + "'";
            strSQL = "SELECT " + id_altura + ", length, iniizq, terizq, inider, terder, transito, clase, mgsl_10, mgsl_6 " + strSQLw;
            NpgsqlCommand command = new NpgsqlCommand(strSQL, Data.Conexion);
            Data.Conexion.Open();
            dr = command.ExecuteReader();

            if (!dr.HasRows)
            {
                booRec = true;
            }
            else
            {
                while (dr.Read())
                {
                    longIdVial = dr.GetInt64(0);
                    dIzq = Math.Abs(dr.GetInt32(2) - dr.GetInt32(3));
                    dDer = Math.Abs(dr.GetInt32(4) - dr.GetInt32(5));
                    longCuadra = tCuadra(dr.GetInt64(0), T, dIzq, dr.GetInt32(9), dDer, dr.GetInt32(8));
                    if (((int)longCuadra == (int)dIzq))
                    {
                        if (((int)dr.GetInt32(2) < (int)dr.GetInt32(3)))
                        {
                            tF = dr.GetInt32(2);
                            fF = dr.GetInt32(3);
                            bq = "a";
                        }
                        else
                        {
                            tF = dr.GetInt32(3);
                            fF = dr.GetInt32(2);
                            bq = "b";
                        }
                    }
                    else
                    {
                        if ((dr.GetInt32(4) < dr.GetInt32(5)))
                        {
                            tF = dr.GetInt32(4);
                            fF = dr.GetInt32(5);
                            bq = "c";
                        }
                        else
                        {
                            tF = dr.GetInt32(5);
                            fF = dr.GetInt32(4);
                            bq = "d";
                        }
                    }
                    DisIni = tF;
                    if (((A <= fF) & (A >= tF)))
                    {
                        bq = "a";
                    }
                    else
                    {
                        if (((bq == "d") | (bq == "c")))
                        {
                            longCuadra = dIzq;
                            if ((dr.GetInt32(2) < dr.GetInt32(3)))
                            {
                                DisIni = dr.GetInt32(2);
                            }
                            else
                            {
                                DisIni = dr.GetInt32(3);
                            }
                        }
                        else
                        {
                            longCuadra = dDer;
                            if ((dr.GetInt32(4) < dr.GetInt32(5)))
                            {
                                DisIni = dr.GetInt32(4);
                            }
                            else
                            {
                                DisIni = dr.GetInt32(5);
                            }
                        }
                    }
                    DelAlt = A - DisIni;
                    longLength = (long)dr.GetDecimal(1);//Conversion.Fix((int)Strings.Replace((string)dr.GetDecimal(1), ".", ","));
                    intTransito = Convert.ToInt32(dr.GetInt64(6));
                    strClase = dr.GetString(7);
                    if ((longCuadra != 0))
                    {
                        DelAltp = (DelAlt * 100) / longCuadra;
                        distan = (longLength * DelAltp) / 100;
                    }
                    else
                    {
                        distan = longLength;
                    }

                    the_point = InterpolaElPto(longIdVial, distan, longLength, intTransito);
                    if ((the_point != "GEOMETRYCOLLECTION EMPTY"))
                    {
                        comuna = ObtieneComuna(the_point);
                        EntrePtos = "___";
                        if ((S))
                        {
                            mi_alt = A - 1;
                        }
                        else
                        {
                            mi_alt = A;
                        }
                        the_geom_Conca = the_geom_Conca + the_coord + the_point + "_" + strClase + "_" + C + "_" + mi_alt + "_" + comuna + "_" + "$" + EntrePtos;
                    }
                    else
                    {
                        the_coord = "Falso...";
                    }

                }
                nVeces = CuantasVeces(the_geom_Conca, "$");
                the_geom_Conca = the_geom_Conca.Replace("$",nVeces.ToString());
                the_coord = the_geom_Conca;
                booRec = false;
            }
            Data.Conexion.Close();
            return booRec;

        }

        private long CuantasVeces(string sCadena, string sLetra)
        {
            int i;
            //Variable para el bucle
            long nVeces=0;
            //variable temporal para el número de veces

            //bucle para recorrer la cadena completa
            for (i = 0; i < sCadena.Length; i++)
            {
                //Si el caracter comprobado es la letra buscada
                if (sCadena.Substring(i,1) == sLetra)
                {
                    //incrementar el número de veces
                    nVeces = nVeces + 1;
                }
            }
            return nVeces;
            //Devolver el total de veces
        }

        private DataAccess Data;
        private string the_coord;
        private string strTipoGeo;
        private const string id_altura = "vial_id";


        public Geocodificacion()
        {
            Data = new DataAccess();
        }
    }

    public class GeoReferencia
    {
        private string _dato1;
        private string _dato2;
        private string _dato3;
        private PointD _punto1;
        private PointD _punto2;
        private TipoReferencia _tipoRef;

        public string Dato1
        {
            get { return _dato1; }
            set { _dato1 = value; }
        }
        public string Dato2
        {
            get { return _dato2; }
            set { _dato2 = value; }
        }
        public string Dato3
        {
            get { return _dato3; }
            set { _dato3 = value; }
        }

        public PointD Punto1
        {
            get { return _punto1; }
            set { _punto1 = value; }
        }
        public PointD Punto2
        {
            get { return _punto2; }
            set { _punto2 = value; }
        }
        public TipoReferencia TipoRef
        {
            get { return _tipoRef; }
            set { _tipoRef = value; }
        }
    }

    public enum TipoReferencia
    {
        Altura,
        Esquina,
        Tramo
    }

    //Public Structure PointD
    //    Public Sub New(ByVal x As String, ByVal y As String)
    //        Me.X = Double.Parse(x.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
    //        Me.Y = Double.Parse(y.Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
    //    End Sub
    //    Public Sub New(ByVal x As Double, ByVal y As Double)
    //        Me.X = x
    //        Me.Y = y
    //    End Sub

    //    Public Overrides Function ToString() As String
    //        Return x.ToString().Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".") _
    //                + " " + y.ToString().Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")
    //    End Function

    //    Public X, Y As Double

    //    'Public Property X() As Double
    //    '    Get
    //    '        Return _x
    //    '    End Get
    //    '    Set(ByVal value As Double)
    //    '        _x = value
    //    '        _isEmpty = False
    //    '    End Set
    //    'End Property
    //    'Public Property Y() As Double
    //    '    Get
    //    '        Return _y
    //    '    End Get
    //    '    Set(ByVal value As Double)
    //    '        _y = value
    //    '        _isEmpty = False
    //    '    End Set
    //    'End Property
    //    'Public ReadOnly Property IsEmpty() As Boolean
    //    '    Get
    //    '        Return _isEmpty
    //    '    End Get
    //    'End Property
    //End Structure

}