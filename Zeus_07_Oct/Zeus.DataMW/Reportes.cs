using System;
using System.Data;

namespace Zeus.Data
{
    public class Reportes
    {
        public DataSet ReporteFrecuenciasPorActo(int mes, int año)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = @"select 'Incendios' as tipo, get_frecuencia_llamados(" + mes + "," + ((año - 1)) + @",'incendio') as frecuencia_ant
                , get_frecuencia_llamados(" + mes + "," + año + ",'incendio') as frecuencia, get_dif_porcentual(" + mes + "," + año + @",'incendio') as dif_porcentual, 
                get_asistencia(" + mes + "," + año + ",'incendio') as asistencia,get_asistencia(" + mes + "," + año + ",'incendio')/get_frecuencia_llamados(" + mes + "," + año + @",'incendio') as asistencia_prom,
                get_duracion_llamados(" + mes + "," + año + ",'incendio') as duracion_llamados,get_duracion_llamados(" + mes + "," + año + ",'incendio')/get_frecuencia_llamados(" + mes + "," + año + @",'incendio') as duracion_promedio
                UNION
                select 'Llams. de Comandancia' as tipo, get_frecuencia_llamados(" + mes + "," + (año - 1) + @",'comandancia') as frecuencia_ant
                , get_frecuencia_llamados(" + mes + "," + año + ",'comandancia') as frecuencia, get_dif_porcentual(" + mes + "," + año + @",'comandancia') as dif_porcentual, 
                get_asistencia(" + mes + "," + año + ",'comandancia') as asistencia,get_asistencia(" + mes + "," + año + ",'comandancia')/get_frecuencia_llamados(" + mes + "," + año + @",'comandancia') as asistencia_prom,
                get_duracion_llamados(" + mes + "," + año + ",'comandancia') as duracion_llamados,get_duracion_llamados(" + mes + "," + año + ",'comandancia')/get_frecuencia_llamados(" + mes + "," + año + @",'comandancia') as duracion_promedio
                UNION
                select 'Otros Servicios' as tipo, get_frecuencia_llamados(" + mes + "," + (año - 1) + @",'otro') as frecuencia_ant
                , get_frecuencia_llamados(" + mes + "," + año + ",'otro') as frecuencia, get_dif_porcentual(" + mes + "," + año + @",'otro') as dif_porcentual, 
                get_asistencia(" + mes + "," + año + ",'otro') as asistencia,get_asistencia(" + mes + "," + año + ",'otro')/get_frecuencia_llamados(" + mes + "," + año + @",'otro') as asistencia_prom,
                get_duracion_llamados(" + mes + "," + año + ",'otro') as duracion_llamados,get_duracion_llamados(" + mes + "," + año + ",'otro')/get_frecuencia_llamados(" + mes + "," + año + @",'otro') as duracion_promedio
                UNION
                select 'Rescate Vehicular' as tipo, get_frecuencia_llamados(" + mes + "," + (año - 1) + @",'vehicular') as frecuencia_ant
                , get_frecuencia_llamados(" + mes + "," + año + ",'vehicular') as frecuencia, get_dif_porcentual(" + mes + "," + año + @",'vehicular') as dif_porcentual, 
                get_asistencia(" + mes + "," + año + ",'vehicular') as asistencia,get_asistencia(" + mes + "," + año + ",'vehicular')/get_frecuencia_llamados(" + mes + "," + año + @",'vehicular') as asistencia_prom,
                get_duracion_llamados(" + mes + "," + año + ",'vehicular') as duracion_llamados,get_duracion_llamados(" + mes + "," + año + ",'vehicular')/get_frecuencia_llamados(" + mes + "," + año + @",'vehicular') as duracion_promedio
                UNION
                select 'Rescate Emergencias' as tipo, get_frecuencia_llamados(" + mes + "," + (año - 1) + @",'emergencia') as frecuencia_ant
                , get_frecuencia_llamados(" + mes + "," + año + ",'emergencia') as frecuencia, get_dif_porcentual(" + mes + "," + año + @",'emergencia') as dif_porcentual, 
                get_asistencia(" + mes + "," + año + ",'emergencia') as asistencia,get_asistencia(" + mes + "," + año + ",'emergencia')/get_frecuencia_llamados(" + mes + "," + año + @",'emergencia') as asistencia_prom,
                get_duracion_llamados(" + mes + "," + año + ",'emergencia') as duracion_llamados,get_duracion_llamados(" + mes + "," + año + ",'emergencia')/get_frecuencia_llamados(" + mes + "," + año + @",'emergencia') as duracion_promedio
                UNION
                select 'Simulacro' as tipo, get_frecuencia_llamados(" + mes + "," + (año - 1) + @",'simulacro') as frecuencia_ant
                , get_frecuencia_llamados(" + mes + "," + año + ",'simulacro') as frecuencia, get_dif_porcentual(" + mes + "," + año + @",'simulacro') as dif_porcentual, 
                get_asistencia(" + mes + "," + año + ",'simulacro') as asistencia,get_asistencia(" + mes + "," + año + ",'simulacro')/get_frecuencia_llamados(" + mes + "," + año + @",'simulacro') as asistencia_prom,
                get_duracion_llamados(" + mes + "," + año + ",'simulacro') as duracion_llamados,get_duracion_llamados(" + mes + "," + año + ",'simulacro')/get_frecuencia_llamados(" + mes + "," + año + ",'simulacro') as duracion_promedio";
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

        public DataSet ReporteFrecuenciasPorLlamado(int mes, int año)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = @"select clave as tipo, get_frecuencia_llamados(" + mes + "," + (año - 1).ToString() + ",clave) as frecuencia_ant" +
                ", get_frecuencia_llamados(" + mes + "," + año + ",clave) as frecuencia, get_dif_porcentual(" + mes + "," + año + ",clave) as dif_porcentual, " +
                "get_asistencia(" + mes + "," + año + ",clave) as asistencia,get_asistencia(" + mes + "," + año + ",clave)/get_frecuencia_llamados(" + mes + "," + año + ",clave) as asistencia_prom," +
                "get_duracion_llamados(" + mes + "," + año + ",clave) as duracion_llamados,get_duracion_llamados(" + mes + "," + año + ",clave)/get_frecuencia_llamados(" + mes + "," + año + ",clave) as duracion_promedio from z_llamados where codigo_llamado<100";
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

        public DataSet ReporteFrecuenciaActosPorCompañia(int mes, int año)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = @"select 'Incendios' as tipo, get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','1') as c1,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','2') as c2,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','3') as c3,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','4') as c4,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','5') as c5,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','6') as c6,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','7') as c7,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','8') as c8,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','9') as c9,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','10') as c10,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'incendio','11') as c11
                UNION
                select 'Llams. de Comandancia' as tipo, get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','1') as c1,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','2') as c2,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','3') as c3,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','4') as c4,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','5') as c5,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','6') as c6,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','7') as c7,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','8') as c8,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','9') as c9,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','10') as c10,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'comandancia','11') as c11
                UNION
                select 'Otros Servicios' as tipo, get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','1') as c1,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','2') as c2,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','3') as c3,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','4') as c4,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','5') as c5,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','6') as c6,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','7') as c7,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','8') as c8,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','9') as c9,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','10') as c10,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'otro','11') as c11
                UNION
                select 'Rescate Vehicular' as tipo, get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','1') as c1,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','2') as c2,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','3') as c3,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','4') as c4,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','5') as c5,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','6') as c6,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','7') as c7,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','8') as c8,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','9') as c9,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','10') as c10,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'vehicular','11') as c11
                UNION
                select 'Rescate Emergencias' as tipo, get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','1') as c1,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','2') as c2,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','3') as c3,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','4') as c4,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','5') as c5,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','6') as c6,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','7') as c7,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','8') as c8,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','9') as c9,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','10') as c10,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'emergencia','11') as c11
                UNION
                select 'Simulacro' as tipo, get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','1') as c1,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','2') as c2,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','3') as c3,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','4') as c4,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','5') as c5,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','6') as c6,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','7') as c7,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','8') as c8,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','9') as c9,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','10') as c10,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",'simulacro','11') as c11";
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

        public DataSet ReporteFrecuenciaLlamadosPorCompañia(int mes, int año)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = @"select clave as tipo, get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'1') as c1,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'2') as c2,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'3') as c3,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'4') as c4,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'5') as c5,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'6') as c6,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'7') as c7,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'8') as c8,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'9') as c9,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'10') as c10,
                get_frecuencia_llamados_compania(" + mes + "," + año + @",clave,'11') as c11 
                from z_llamados where codigo_llamado<100";
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

        public DataSet ReporteFrecuenciaActosPorComuna(int mes, int año)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = @"select 'Incendios' as tipo, 
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'incendio','EL BOSQUE') as el_bosque,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'incendio','LA CISTERNA') as la_cisterna,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'incendio','LO ESPEJO') as lo_espejo,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'incendio','PEDRO AGUIRRE CERDA') as pac,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'incendio','SAN MIGUEL') as san_miguel,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'incendio','SAN JOAQUIN') as san_joaquin,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'incendio','-') as fuera,
                get_frecuencia_llamados(" + mes + "," + año + @",'incendio') as total
                UNION
                select 'Llams. de Comandancia' as tipo, 
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'comandancia','EL BOSQUE') as el_bosque,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'comandancia','LA CISTERNA') as la_cisterna,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'comandancia','LO ESPEJO') as lo_espejo,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'comandancia','PEDRO AGUIRRE CERDA') as pac,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'comandancia','SAN MIGUEL') as san_miguel,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'comandancia','SAN JOAQUIN') as san_joaquin,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'comandancia','-') as fuera,
                get_frecuencia_llamados(" + mes + "," + año + @",'comandancia') as total
                UNION
                select 'Otros Servicios' as tipo, 
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'otro','EL BOSQUE') as el_bosque,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'otro','LA CISTERNA') as la_cisterna,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'otro','LO ESPEJO') as lo_espejo,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'otro','PEDRO AGUIRRE CERDA') as pac,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'otro','SAN MIGUEL') as san_miguel,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'otro','SAN JOAQUIN') as san_joaquin,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'otro','-') as fuera,
                get_frecuencia_llamados(" + mes + "," + año + @",'otro') as total
                UNION
                select 'Rescate Vehicular' as tipo, 
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'vehicular','EL BOSQUE') as el_bosque,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'vehicular','LA CISTERNA') as la_cisterna,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'vehicular','LO ESPEJO') as lo_espejo,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'vehicular','PEDRO AGUIRRE CERDA') as pac,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'vehicular','SAN MIGUEL') as san_miguel,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'vehicular','SAN JOAQUIN') as san_joaquin,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'vehicular','-') as fuera,
                get_frecuencia_llamados(" + mes + "," + año + @",'vehicular') as total
                UNION
                select 'Rescate Emergencias' as tipo, 
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'emergencia','EL BOSQUE') as el_bosque,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'emergencia','LA CISTERNA') as la_cisterna,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'emergencia','LO ESPEJO') as lo_espejo,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'emergencia','PEDRO AGUIRRE CERDA') as pac,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'emergencia','SAN MIGUEL') as san_miguel,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'emergencia','SAN JOAQUIN') as san_joaquin,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'emergencia','-') as fuera,
                get_frecuencia_llamados(" + mes + "," + año + @",'emergencia') as total
                UNION
                select 'Simulacro' as tipo, 
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'simulacro','EL BOSQUE') as el_bosque,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'simulacro','LA CISTERNA') as la_cisterna,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'simulacro','LO ESPEJO') as lo_espejo,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'simulacro','PEDRO AGUIRRE CERDA') as pac,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'simulacro','SAN MIGUEL') as san_miguel,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'simulacro','SAN JOAQUIN') as san_joaquin,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",'simulacro','-') as fuera,
                get_frecuencia_llamados(" + mes + "," + año + @",'simulacro') as total";
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

        public DataSet ReporteFrecuenciaLlamadosPorComuna(int mes, int año)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = @"select clave as tipo, 
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",clave,'EL BOSQUE') as el_bosque,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",clave,'LA CISTERNA') as la_cisterna,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",clave,'LO ESPEJO') as lo_espejo,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",clave,'PEDRO AGUIRRE CERDA') as pac,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",clave,'SAN MIGUEL') as san_miguel,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",clave,'SAN JOAQUIN') as san_joaquin,
                get_frecuencia_llamados_comuna(" + mes + "," + año + @",clave,'-') as fuera,
                get_frecuencia_llamados(" + mes + "," + año + @",clave) as total
                from z_llamados where codigo_llamado<100";
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
