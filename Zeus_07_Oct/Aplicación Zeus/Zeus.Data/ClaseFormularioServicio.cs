using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeus.Data
{
    public class ClaseFormularioServicio
    {
        #region INSERT
        public static int FormularioServicioEncabezado(
                int idExpediente,
                string dia,
                string mes,
                string anio,
                string horaInicio,
                string horaTermino,
                string motivoAlarma,
                string correlativoCompania,
                string correlativoCBPA,
                string claveDespacho,
                string enviadoAL,
                string juzgadoDe,
                string oficioNumero,
                string rolNumero,
                string direccion,
                string numero,
                string block,
                string departamento,
                string esquina,
                string sector,
                string comuna,
                string ocupadoPor,
                string rut,
                string propietario,
                string arrendatario,
                string allegado,
                string numeroAdultos,
                string numeroNinos
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_encabezado(id_expediente, dia, mes, anio, horaInicio, horaTermino, motivoAlarma, correlativoCompania, correlativoCBPA, claveDespacho, enviadoAL, juzgadoDe, oficioNumero, rolNumero, direccion, numero, block, departamento, esquina, sector, comuna, ocupadoPor, rut, propietario, allegado, numeroAdultos, numeroNinos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + dia + "', '" + mes + "', '" + anio + "', '" + horaInicio + "', '" + horaTermino + "', '" + motivoAlarma + "', '" + correlativoCompania + "','" + correlativoCBPA + "', '" + claveDespacho + "', '" + enviadoAL + "', '" + juzgadoDe + "', '" + oficioNumero + "', '" + rolNumero + "', '" + direccion + "','" + numero + "', '" + block + "', '" + departamento + "', '" + esquina + "', '" + sector + "', '" + comuna + "', '" + ocupadoPor + "', '" + rut + "', '" + propietario + "', '" + allegado + "', '" + numeroAdultos + "', '" + numeroNinos + "')";
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

        public static int FormularioServicioNaturalezaLugar(
                int idExpediente,
                string vivienda,
                string departamento,
                string negocio,
                string edificioPublico,
                string industria,
                string sitioEriazo,
                string estEducacional,
                string viaPublica,
                string mejora,
                string otro,
                string descripcionOtro,
                string vehiculoTipoMarca,
                string descripcionTipoMarcaUno,
                string patenteTipoMarcaUno,
                string descripcionTipoMarcaDos,
                string patenteTipoMarcaDos
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_naturaleza_lugar(id_expediente, vivienda, departamento, negocio, edificioPublico, industria, sitioEriazo, estEducacional,viaPublica,mejora,otro,descripcionOtro,vehiculoTipoMarca,descripcionTipoMarcaUno,patenteTipoMarcaUno,descripcionTipoMarcaDos,patenteTipoMarcaDos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + vivienda + "', '" + departamento + "', '" + negocio + "', '" + edificioPublico + "', '" + industria + "', '" + sitioEriazo + "', '" + estEducacional + "', '" + viaPublica + "', '" + mejora + "', '" + otro + "', '" + descripcionOtro + "', '" + vehiculoTipoMarca + "', '" + descripcionTipoMarcaUno + "', '" + patenteTipoMarcaUno + "', '" + descripcionTipoMarcaDos + "', '" + patenteTipoMarcaDos + "')";
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

        public static int FormularioServicioTipoConstruccion(
                int idExpediente,
                string numeroPisos,
                string hormigon,
                string adobe,
                string acero,
                string mixta,
                string madera,
                string prefabricado,
                string albanileria,
                string otro,
                string descripcionOtro
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_tipo_construccion(id_expediente, numeroPisos, hormigon, adobe, acero, mixta, madera, prefabricado, albanileria, otro, descripcionOtro) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + numeroPisos + "', '" + hormigon + "', '" + adobe + "', '" + acero + "', '" + mixta + "', '" + madera + "', '" + prefabricado + "', '" + albanileria + "', '" + otro + "', '" + descripcionOtro + "')";
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

        public static int FormularioServicioLugarInicioFuego(
                int idExpediente,
                string numeroPiso,
                string living,
                string bano,
                string comedor,
                string bodega,
                string cocina,
                string patio,
                string dormitorio,
                string otro,
                string descripcionOtro
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_lugar_inicio_fuego(id_expediente, numeroPiso, living, bano, comedor, bodega, cocina, patio, dormitorio, otro, descripcionOtro) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + numeroPiso + "', '" + living + "', '" + bano + "', '" + comedor + "', '" + bodega + "', '" + cocina + "', '" + patio + "', '" + dormitorio + "', '" + otro + "', '" + descripcionOtro + "')";
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

        public static int FormularioServicioDetalleDanos(
                int idExpediente,
                string porcentajeVivienda,
                string porcentajeEnseres,
                string porcentajeVehiculo,
                string porcentajeUno,
                string descripcionPorcentajeUno,
                string porcentajeDos,
                string descripcionPorcentajeDos
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_detalle_danos(id_expediente, porcentajeVivienda, porcentajeEnseres, porcentajeVehiculo, porcentajeUno, descripcionPorcentajeUno, porcentajeDos, descripcionPorcentajeDos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + porcentajeVivienda + "', '" + porcentajeEnseres + "', '" + porcentajeVehiculo + "', '" + porcentajeUno + "', '" + descripcionPorcentajeUno + "', '" + porcentajeDos + "', '" + descripcionPorcentajeDos + "')";
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

        public static int FormularioServicioOrigenCausaFuego(
                int idExpediente,
                string origenFuego,
                string causaFuego,
                string salvamiento,
                string lesionadosMuertos
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_origen_causa_fuego(id_expediente, origenFuego, causaFuego, salvamiento, lesionadosMuertos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + origenFuego + "', '" + causaFuego + "', '" + salvamiento + "', '" + lesionadosMuertos + "')";
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

        public static int FormularioServicioPresenciaGas(
                int idExpediente,
                string cilindro,
                string kilogramosCilindro,
                string estanque,
                string kilogramosPorMetroCubicoEstanque,
                string caneria,
                string ciudad,
                string licuado,
                string natural,
                string otro,
                string descripcionOtro,
                string companiaDistribuidora
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_presencia_gas(id_expediente, cilindro, kilogramosCilindro, estanque, kilogramosPorMetroCubicoEstanque, caneria, ciudad, licuado, cnatural, otro, descripcionOtro, companiaDistribuidora) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + cilindro + "', '" + kilogramosCilindro + "', '" + estanque + "', '" + kilogramosPorMetroCubicoEstanque + "', '" + caneria + "', '" + ciudad + "', '" + licuado + "', '" + natural + "', '" + otro + "', '" + descripcionOtro + "', '" + companiaDistribuidora + "')";
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

        public static int FormularioServicioConcurrieron(
            int idExpediente,
            string apoyoOtrosCuerpos,
            string apoyoOtrosCuerposAcargo,
            string apoyoOtrosCuerposProcedencia,
            string apoyoOtrosCuerposMotivo,
            string ambulancias,
            string ambulanciasLugarUno,
            string ambulanciasLugarDos,
            string ambulanciasLugarTres,
            string carabineros,
            string carabinerosAcargo,
            string carabinerosNumeroPatrullas,
            string oficinaEmergencia,
            string asistenteSocial,
            string otrosApoyos
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_concurrieron(id_expediente, apoyoOtrosCuerpos, apoyoOtrosCuerposAcargo, apoyoOtrosCuerposProcedencia, apoyoOtrosCuerposMotivo, ambulancias, ambulanciasLugarUno, ambulanciasLugarDos, ambulanciasLugarTres, carabineros, carabinerosAcargo, carabinerosNumeroPatrullas, oficinaEmergencia, asistenteSocial, otrosApoyos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + apoyoOtrosCuerpos + "', '" + apoyoOtrosCuerposAcargo + "', '" + apoyoOtrosCuerposProcedencia + "', '" + apoyoOtrosCuerposMotivo + "', '" + ambulancias + "', '" + ambulanciasLugarUno + "', '" + ambulanciasLugarDos + "', '" + ambulanciasLugarTres + "', '" + carabineros + "', '" + carabinerosAcargo + "', '" + carabinerosNumeroPatrullas + "', '" + oficinaEmergencia + "', '" + asistenteSocial + "', '" + otrosApoyos + "')";
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

        public static int FormuarioServicioExistian(
            int idExpediente,
            string explosivos,
            string gases,
            string liquidos,
            string solidos,
            string veneno,
            string radioactivos,
            string corrosivos,
            string oxidantes,
            string varios,
            string noClasificados,
            string nombreProductos
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formuario_servicio_existian(id_expediente, explosivos, gases, liquidos, solidos, veneno, radioactivos, corrosivos, oxidantes, varios, noClasificados, nombreProductos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + explosivos + "', '" + gases + "', '" + liquidos + "', '" + solidos + "', '" + veneno + "', '" + radioactivos + "', '" + corrosivos + "', '" + oxidantes + "', '" + varios + "', '" + noClasificados + "', '" + nombreProductos + "')";
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

        public static int FormularioServicioEspecificacionPersonal(
            int idExpediente,
            string gradoAcargo,
            string companiaAcargo,
            string nombreAcargo,
            string gradoEstadistica,
            string companiaEstadistica,
            string nombreEstadistica,
            string nombreVBCompania
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_especificacion_personal(id_expediente, gradoAcargo, companiaAcargo, nombreAcargo, gradoEstadistica, companiaEstadistica, nombreEstadistica, nombreVBCompania) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + gradoAcargo + "', '" + companiaAcargo + "', '" + nombreAcargo + "', '" + gradoEstadistica + "', '" + companiaEstadistica + "', '" + nombreEstadistica + "', '" + nombreVBCompania + "')";
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

        public static int FormularioServicioDatosGrilla(
            int idExpediente,
            string nombreJefeHogar,
            string rut,
            string propietario,
            string arrendatario,
            string allegado,
            string otro,
            string direccion,
            string adultos,
            string menores,
            string vivienda,
            string enseres,
            string vehiculo
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_datos_grilla(id_expediente, nombreJefeHogar, rut, propietario, arrendatario, allegado, otro, direccion, adultos, menores, vivienda, enseres, vehiculo) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + nombreJefeHogar + "', '" + rut + "', '" + propietario + "', '" + arrendatario + "', '" + allegado + "', '" + otro + "', '" + direccion + "', '" + adultos + "', '" + menores + "', '" + vivienda + "', '" + enseres + "', '" + vehiculo + "')";
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

        public static int FormularioServicioCompaniasConcurrentes(
            int idExpediente,
            string matMatorPrimeraCompaniaUno,
            string matMatorPrimeraCompaniaDos,
            string matMatorPrimeraCompaniaTres,
            string matMatorPrimeraCompaniaCuatro,
            string matMatorSegundaCompaniaUno,
            string matMatorSegundaCompaniaDos,
            string matMatorSegundaCompaniaTres,
            string matMatorSegundaCompaniaCuatro,
            string matMatorTerceraCompaniaUno,
            string matMatorTerceraCompaniaDos,
            string matMatorTerceraCompaniaTres,
            string matMatorTerceraCompaniaCuatro,
            string matMatorCuartaCompaniaUno,
            string matMatorCuartaCompaniaDos,
            string matMatorCuartaCompaniaTres,
            string matMatorCuartaCompaniaCuatro,
            string matMatorQuintaCompaniaUno,
            string matMatorQuintaCompaniaDos,
            string matMatorQuintaCompaniaTres,
            string matMatorQuintaCompaniaCuatro,
            string matMatorSextaCompaniaUno,
            string matMatorSextaCompaniaDos,
            string matMatorSextaCompaniaTres,
            string matMatorSextaCompaniaCuatro,
            string matMatorComandanciaCompaniaUno,
            string matMatorComandanciaCompaniaDos,
            string matMatorComandanciaCompaniaTres,
            string matMatorComandanciaCompaniaCuatro,
            string voluntariosCompaniaUno,
            string voluntariosCompaniaDos,
            string voluntariosCompaniaTres,
            string voluntariosCompaniaCuatro,
            string voluntariosCompaniaCinco,
            string voluntariosCompaniaSeis,
            string voluntariosCompaniaComandancia
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_companias_concurrentes(id_expediente,matMatorPrimeraCompaniaUno,matMatorPrimeraCompaniaDos,matMatorPrimeraCompaniaTres,matMatorPrimeraCompaniaCuatro,matMatorSegundaCompaniaUno,matMatorSegundaCompaniaDos,matMatorSegundaCompaniaTres,matMatorSegundaCompaniaCuatro,matMatorTerceraCompaniaUno,matMatorTerceraCompaniaDos,matMatorTerceraCompaniaTres,matMatorTerceraCompaniaCuatro,matMatorCuartaCompaniaUno,matMatorCuartaCompaniaDos,matMatorCuartaCompaniaTres,matMatorCuartaCompaniaCuatro,matMatorQuintaCompaniaUno,matMatorQuintaCompaniaDos,matMatorQuintaCompaniaTres,matMatorQuintaCompaniaCuatro,matMatorSextaCompaniaUno,matMatorSextaCompaniaDos,matMatorSextaCompaniaTres,matMatorSextaCompaniaCuatro,matMatorComandanciaCompaniaUno,matMatorComandanciaCompaniaDos,matMatorComandanciaCompaniaTres,matMatorComandanciaCompaniaCuatro,voluntariosCompaniaUno,voluntariosCompaniaDos,voluntariosCompaniaTres,voluntariosCompaniaCuatro,voluntariosCompaniaCinco,voluntariosCompaniaSeis,voluntariosCompaniaComandancia) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + matMatorPrimeraCompaniaUno + "', '" + matMatorPrimeraCompaniaDos + "', '" + matMatorPrimeraCompaniaTres + "', '" + matMatorPrimeraCompaniaCuatro + "', '" + matMatorSegundaCompaniaUno + "', '" + matMatorSegundaCompaniaDos + "', '" + matMatorSegundaCompaniaTres + "', '" + matMatorSegundaCompaniaCuatro + "', '" + matMatorTerceraCompaniaUno + "', '" + matMatorTerceraCompaniaDos + "', '" + matMatorTerceraCompaniaTres + "', '" + matMatorTerceraCompaniaCuatro + "', '" + matMatorCuartaCompaniaUno + "', '" + matMatorCuartaCompaniaDos + "', '" + matMatorCuartaCompaniaTres + "', '" + matMatorCuartaCompaniaCuatro + "', '" + matMatorQuintaCompaniaUno + "', '" + matMatorQuintaCompaniaDos + "', '" + matMatorQuintaCompaniaTres + "', '" + matMatorQuintaCompaniaCuatro + "', '" + matMatorSextaCompaniaUno + "', '" + matMatorSextaCompaniaDos + "', '" + matMatorSextaCompaniaTres + "', '" + matMatorSextaCompaniaCuatro + "', '" + matMatorComandanciaCompaniaUno + "', '" + matMatorComandanciaCompaniaDos + "', '" + matMatorComandanciaCompaniaTres + "', '" + matMatorComandanciaCompaniaCuatro + "', '" + voluntariosCompaniaUno + "', '" + voluntariosCompaniaDos + "', '" + voluntariosCompaniaTres + "', '" + voluntariosCompaniaCuatro + "', '" + voluntariosCompaniaCinco + "', '" + voluntariosCompaniaSeis + "', '" + voluntariosCompaniaComandancia + "')";
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

        public static int FormularioServicioSegurosMaterialApoyo(
            int idExpediente,
            string seguros,
            string compania,
            string especieAseg,
            string fotos,
            string muestras,
            string videos,
            string otros,
            string descripcionOtros
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_seguros_material_apoyo(id_expediente, seguros, compania, especieAseg, muestras, videos, otros, descripcionOtros, fotos) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + seguros + "', '" + compania + "', '" + especieAseg + "', '" + muestras + "', '" + videos + "', '" + otros + "', '" + descripcionOtros + "', '" + fotos + "')";
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

        public static int FormularioServicioConstanciaVoluntariosLesionados(
            int idExpediente,
            string nombreUno,
            string ciaUno,
            string numeroRegistroUno,
            string nombreDos,
            string ciaDos,
            string numeroRegistroDos,
            string nombreTres,
            string ciaTres,
            string numeroRegistroTres,
            string nombreCuatro,
            string ciaCuatro,
            string numeroRegistroCuatro,
            string comisaria,
            string numeroLibro,
            string numeroHoja,
            string numeroParrafo,
            string constanciaDejadaPor,
            string cargo,
            string fecha,
            string resumenActo
            )
        {
            CnxBase myBase = new CnxBase();
            int ret = 0;
            string reqSQL = "INSERT INTO Formulario_servicio_constancia_voluntarios_lesionados(id_expediente, nombreUno, ciaUno, numeroRegistroUno, nombreDos, ciaDos, numeroRegistroDos, nombreTres, ciaTres, numeroRegistroTres, nombreCuatro, ciaCuatro, numeroRegistroCuatro, comisaria, numeroLibro, numeroHoja, numeroParrafo, constanciaDejadaPor, cargo, fecha, resumenActo) ";
            reqSQL += "VALUES (" + idExpediente + ", '" + nombreUno + "', '" + ciaUno + "', '" + numeroRegistroUno + "', '" + nombreDos + "', '" + ciaDos + "', '" + numeroRegistroDos + "', '" + nombreTres + "', '" + ciaTres + "', '" + numeroRegistroTres + "', '" + nombreCuatro + "', '" + ciaCuatro + "', '" + numeroRegistroCuatro + "', '" + comisaria + "', '" + numeroLibro + "', '" + numeroHoja + "', '" + numeroParrafo + "', '" + constanciaDejadaPor + "', '" + cargo + "', '" + fecha + "', '" + resumenActo + "')";
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

        #region SELECT
        public static DataSet GetFormularioServicioEncabezado(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_encabezado WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioNaturalezaLugar(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_naturaleza_lugar WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioTipoConstruccion(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_tipo_construccion WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioLugarInicioFuego(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_lugar_inicio_fuego WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioDetalleDanos(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_detalle_danos WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioOrigenCausaFuego(
                int idExpediente,
                string origenFuego,
                string causaFuego,
                string salvamiento,
                string lesionadosMuertos
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_origen_causa_fuego WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioPresenciaGas(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_presencia_gas WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioConcurrieron(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_concurrieron WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormuarioServicioExistian(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formuario_servicio_existian WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioEspecificacionPersonal(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM Formulario_servicio_especificacion_personal WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioDatosGrilla(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM  Formulario_servicio_datos_grilla WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioCompaniasConcurrentes(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM  Formulario_servicio_companias_concurrentes WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioSegurosMaterialApoyo(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM  Formulario_servicio_seguros_material_apoyo WHERE id_expediente = " + idExpediente;
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

        public static DataSet GetFormularioServicioConstanciaVoluntariosLesionados(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "SELECT * FROM  Formulario_servicio_constancia_voluntarios_lesionados WHERE id_expediente = " + idExpediente;
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

        #region DELETE
        public static DataSet DeleteFormularioServicioEncabezado(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_encabezado WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioNaturalezaLugar(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_naturaleza_lugar WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioTipoConstruccion(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_tipo_construccion WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioLugarInicioFuego(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_lugar_inicio_fuego WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioDetalleDanos(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_detalle_danos WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioOrigenCausaFuego(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_origen_causa_fuego WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioPresenciaGas(
                int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_presencia_gas WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioConcurrieron(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_concurrieron WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormuarioServicioExistian(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formuario_servicio_existian WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioEspecificacionPersonal(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_especificacion_personal WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioDatosGrilla(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_datos_grilla WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioCompaniasConcurrentes(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_companias_concurrentes WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioSegurosMaterialApoyo(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_seguros_material_apoyo WHERE id_expediente = " + idExpediente;
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

        public static DataSet DeleteFormularioServicioConstanciaVoluntariosLesionados(
            int idExpediente
            )
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "DELETE FROM Formulario_servicio_constancia_voluntarios_lesionados WHERE id_expediente = " + idExpediente;
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
    }
}
