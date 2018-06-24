using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Zeus.Data
{
    public class z_servicio
    {
        int _id_carro;

        public int id_carro
        {
            get { return _id_carro; }
            set { _id_carro = value; }
        }
        DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        int _estado;

        public int estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        int _id_conductor;

        public int id_conductor
        {
            get { return _id_conductor; }
            set { _id_conductor = value; }
        }
        string _motivo_fuera_servicio;

        public string motivo_fuera_servicio
        {
            get { return _motivo_fuera_servicio; }
            set { _motivo_fuera_servicio = value; }
        }

        public z_servicio(int id_carro, DateTime fecha, int estado, int id_conductor, string motivo_fuera_servicio)
        {
            _id_carro = id_carro;
            _fecha = fecha;
            _estado = estado;
            _id_conductor = id_conductor;
            _motivo_fuera_servicio = motivo_fuera_servicio;
        }



        public z_servicio()
        {

        }





        public void Insert(z_servicio servicio)
        {
            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_servicio (id_carro,fecha,estado,id_conductor,motivo_fuera_servicio) VALUES (" + servicio.id_carro + ",'" + servicio.fecha + "'," + servicio.estado + "," + servicio.id_conductor + ",'" + servicio.motivo_fuera_servicio + "')";
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


        //### Insert Multiple
        public void InsertMultiple(string strIdCarros, string strIdConductores, string strCarros)
        {
            string[] ArIdCarro = strIdCarros.ToString().Split(',');
            string[] ArIdConductor = strIdConductores.ToString().Split(',');
            string[] ArNomCarro = strCarros.ToString().Split(',');
            string[] MultiInsert = new string[ArIdCarro.Length];
            
            //### Crear cada Registro del Insert Multiple
            string strVector = "";
            for (int x = 0; x < ArIdCarro.Length; x++)
            {
                //# Crear Registro
                strVector = ArIdCarro[x] + ",'" + System.DateTime.Now + "',4," + ArIdConductor[x] + ",'Despacho de " + ArNomCarro[x] + "'";
                MultiInsert[x] = strVector;
            }

            //### Crear String del Insert Multiple
            string strValores = "";
            string strVectorFinal = "";
            for (int x = 0; x < ArIdCarro.Length; x++)
            {
                strValores += "(" + MultiInsert[x] + "),";
            }
            strValores += "#";
            strVectorFinal = strValores.Replace(",#", "");

            CnxBase myBase = new CnxBase();
            string reqSQL = "INSERT INTO z_servicio (id_carro,fecha,estado,id_conductor,motivo_fuera_servicio) VALUES " + strVectorFinal;
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


    }
}
