using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace Zeus.Data
{
    public class ClaseFormularioRescate
    {
        public int FormularioRescateEncabezado(int idExpediente, 
            string fechaEmergencia, 
            string horaInicio, 
            string horaLlegadaPrimerCarro, 
            string horaLlegadaCarroRescate, 
            string horaTermino, 
            int correlativoCompania, 
            int correlativoCBPA, 
            string clasificacionAccidente, 
            string clasificacionZona, 
            string tipoDeVia, 
            string estadoAtmosferico,
            string sector,
            int frenteNumero,
            string esquina,
            string comuna)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO formulario_rescate_encabezado(id_expediente, fecha_emergencia, hora_inicio, hora_llegada_primer_carro, hora_llegada_carro_rescate, hora_termino, correlativo_compania, correlativo_cbpa, clasificacion_accidente, clasificacion_zona, tipo_de_via, estado_atmosferico, sector, frente_numero, esquina, comuna) ";
            reqSQL += "VALUES ("+idExpediente+", '"+fechaEmergencia+"', '"+horaInicio+"', '"+horaLlegadaPrimerCarro+"', '"+horaLlegadaCarroRescate+"', '"+horaTermino+"', '"+correlativoCompania+"', '"+correlativoCBPA+"', '"+clasificacionAccidente+"', '"+clasificacionZona+"', '"+tipoDeVia+"', '"+estadoAtmosferico+"', '"+sector+"', "+frenteNumero+", '"+esquina+"', '" + comuna + "')";
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

        public int FormularioRescateVehiculosInvolucrados(int idExpediente,
            string tipo,
            string marca,
            string modelo,
            string patente,
            string conductor,
            string ciConductor,
            string acompanante1,
            string ciAcompanante1,
            string acompanante2,
            string ciAcompanante2)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO formulario_rescate_vehiculos_involucrados(id_expediente, tipo, marca, modelo, patente, conductor, ci_conductor, acompanante_1, ci_acompanante_1, acompanante_2, ci_acompanante_2) ";
            reqSQL += "VALUES ("+idExpediente+", '"+tipo+"', '"+marca+"', '"+modelo+"', '"+patente+"', '"+conductor+"', '"+ciConductor+"', '"+acompanante1+"', '"+ciAcompanante1+"', '"+acompanante2+"', '"+ciAcompanante2+"')";
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

        public int FormularioRescateLesionadosFallecidos(int idExpediente,
            string nombre,
            string ci,
            string estadoConsiente,
            string estadoLleso,
            string estadoFracturasVisibles,
            string estadoHeridasVisibles,
            string estadoManiobrasRCP,
            string lugarEncuentro,
            string atrapadoDescripcion,
            string detalleFracturas,
            string detalleHeridas,
            string detalleOtrasLesiones,
            string trasladoA,
            string trasladoPor,
            string movil_numero,
            string VehiculoVeniaAUno,
            string VehiculoVeniaADos,
            string VehiculoVeniaBUno,
            string VehiculoVeniaBDos)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO formulario_rescate_lesionados_fallecidos(id_expediente, nombre, ci, estado_consiente, estado_lleso, estado_fracturas_visibles, estado_heridas_visibles, estado_maniobras_de_rcp, lugar_encuentro, atrapado_descripcion, detalle_fracturas, detalle_heridas, detalle_otras_lesiones, traslado_a, traslado_por, movil_numero, vehiculoveniaauno, vehiculoveniaados, vehiculoveniabuno, vehiculoveniabdos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + nombre + "', '" + ci + "', '" + estadoConsiente + "', '" + estadoLleso + "', '" + estadoFracturasVisibles + "', '" + estadoHeridasVisibles + "', '" + estadoManiobrasRCP + "', '" + lugarEncuentro + "', '" + atrapadoDescripcion + "', '" + detalleFracturas + "', '" + detalleHeridas + "', '" + detalleOtrasLesiones + "', '" + trasladoA + "', '" + trasladoPor + "', '" + movil_numero + "', '" + VehiculoVeniaAUno + "', '" + VehiculoVeniaADos + "', '" + VehiculoVeniaBUno + "', '" + VehiculoVeniaBDos + "')";
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

        public int FormularioRescateServicioPolicial(int idExpediente,
            string concurrio,
            string acargo,
            string unidad,
            string rp_numero,
            string z_numero)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO formulario_rescate_servicio_policial(id_expediente, concurrio, acargo, unidad, rp_numero, z_numero) ";
            reqSQL += "VALUES ("+idExpediente+", '"+concurrio+"', '"+acargo+"', '"+unidad+"', '"+rp_numero+"', '"+z_numero+"')";
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

        public int FormularioRescateServicioMedico(int idExpediente,
            string concurrio,
            string acargo,
            string unidadSamu,
            string unidadSapu,
            string unidadPrivado,
            string unidadOtro)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO formulario_rescate_servicio_medico(id_expediente, concurrio, acargo, unidad_samu, unidad_sapu, unidad_privado, unidad_otro) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + concurrio + "', '" + acargo + "', '" + unidadSamu + "', '" + unidadSapu + "', '" + unidadPrivado + "', '"+unidadOtro+"')";
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

        public int FormularioRescateDescripciones(int idExpediente,
            string resumenActo,
            string materialInmovilizacionUtilizado,
            string materialMayorConcurrente,
            string materialMayorOtrosCuerpos)
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO formulario_rescate_descripciones(id_expediente, resumen_acto, material_inmovilizacion_utilizado, material_mayor_concurrente, material_mayor_apollo_otros_cuerpos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + resumenActo + "', '" + materialInmovilizacionUtilizado + "', '" + materialMayorConcurrente + "', '" + materialMayorOtrosCuerpos + "')";
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

        public DataSet ObtenerFormularioRescateEncabezado(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, fecha_emergencia, hora_inicio, hora_llegada_primer_carro, hora_llegada_carro_rescate, hora_termino, correlativo_compania, correlativo_cbpa, clasificacion_accidente, clasificacion_zona, tipo_de_via, estado_atmosferico, sector, frente_numero, esquina, comuna from formulario_rescate_encabezado where id_expediente = " + idExpediente;
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

        public DataSet ObtenerFormularioRescateVehiculosInvolucrados(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, tipo, marca, modelo, patente, conductor, ci_conductor, acompanante_1, ci_acompanante_1, acompanante_2, ci_acompanante_2 from formulario_rescate_vehiculos_involucrados where id_expediente = " + idExpediente;
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

        public DataSet ObtenerFormularioRescateLesionadosFallecidos(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, nombre, ci, estado_consiente, estado_lleso, estado_fracturas_visibles, estado_heridas_visibles, estado_maniobras_de_rcp, lugar_encuentro, atrapado_descripcion, detalle_fracturas, detalle_heridas, detalle_otras_lesiones, traslado_a, traslado_por, movil_numero, vehiculoveniaauno, vehiculoveniaados, vehiculoveniabuno, vehiculoveniabdos from formulario_rescate_lesionados_fallecidos where id_expediente = " + idExpediente;
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

        public DataSet ObtenerFormularioRescateServicioPolicial(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, concurrio, acargo, unidad, rp_numero, z_numero from formulario_rescate_servicio_policial where id_expediente = " + idExpediente;
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

        public DataSet ObtenerFormularioRescateServicioMedico(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, concurrio, acargo, unidad_samu, unidad_sapu, unidad_privado, unidad_otro from formulario_rescate_servicio_medico where id_expediente = " + idExpediente;
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

        public DataSet ObtenerFormularioRescateDescripcion(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select id_expediente, resumen_acto, material_inmovilizacion_utilizado, material_mayor_concurrente, material_mayor_apollo_otros_cuerpos from formulario_rescate_descripciones where id_expediente = " + idExpediente;
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

        public DataSet BorrarFormularioRescateEncabezado(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "delete from formulario_rescate_encabezado where id_expediente = " + idExpediente;
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

        public DataSet BorrarFormularioRescateLesionadosFallecidos(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "delete from formulario_rescate_lesionados_fallecidos where id_expediente = " + idExpediente;
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

        public DataSet BorrarFormularioRescateVehiculosInvolucrados(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "delete from formulario_rescate_vehiculos_involucrados where id_expediente = " + idExpediente;
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

        public DataSet BorrarFormularioRescateServicioPolicial(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "delete from formulario_rescate_servicio_policial where id_expediente = " + idExpediente;
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

        public DataSet BorrarFormularioRescateServicioMedico(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "delete from formulario_rescate_servicio_medico where id_expediente = " + idExpediente;
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

        public DataSet BorrarFormularioRescateDescripcion(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "delete from formulario_rescate_descripciones where id_expediente = " + idExpediente;
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

        public string ObtenerPrimerCarroEnLlegar(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select fecha from bitacora_llamados where id_expediente = " + idExpediente + " AND evento = '6-3' order by fecha asc limit 1";
            string fecha = string.Empty;
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow row in myResult.Tables[0].Rows)
                {
                    fecha = row["fecha"].ToString();
                }

                return fecha;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }

        // select fecha, id_expediente, evento from bitacora_llamados where evento = '6-7' and id_expediente = 7888 order by fecha desc limit 1

        public string ObtenerHoraDeTermino(int idExpediente)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "select fecha from bitacora_llamados where id_expediente = " + idExpediente + " AND evento = '6-7' order by fecha desc limit 1";
            string fecha = string.Empty;
            try
            {
                CnxBase myD4MCnx = new CnxBase();
                DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
                foreach (DataRow row in myResult.Tables[0].Rows)
                {
                    fecha = row["fecha"].ToString();
                }

                return fecha;
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
        }
    }
}
