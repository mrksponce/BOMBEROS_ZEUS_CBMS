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
/// z_prueba_equipo
/// </summary>
public class z_prueba_equipo
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_prueba_equipo;
	public System.Int32 id_prueba_equipo
	{ 
		get 
		{ 
			return _id_prueba_equipo;
		}
		set 
        { 
			_id_prueba_equipo = value;
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

	private System.Int32 _id_carro;
	public System.Int32 id_carro
	{ 
		get 
		{ 
			return _id_carro;
		}
		set 
        { 
			_id_carro = value;
		}
	}

	private System.Boolean _estado;
	public System.Boolean estado
	{ 
		get 
		{ 
			return _estado;
		}
		set 
        { 
			_estado = value;
		}
	}

	#endregion

	/// <summary>
	/// z_prueba_equipo
	/// </summary>
	public z_prueba_equipo()
	{
	}


	/// <summary>
	/// z_prueba_equipo
	/// </summary>
	public z_prueba_equipo(System.DateTime fecha,System.Int32 id_carro,System.Boolean estado)
	{
		this.fecha = fecha;
		this.id_carro = id_carro;
		this.estado = estado;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_prueba_equipo(z_prueba_equipo myz_prueba_equipo)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_prueba_equipo (fecha,id_carro,estado) VALUES ('"+myz_prueba_equipo.fecha+"',"+myz_prueba_equipo.id_carro+","+myz_prueba_equipo.estado+")";
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
				myCommand.ExecuteNonQuery();	
				myBase.CloseConnection(myConn);
			}
			catch(Exception myErr)
			{
				throw(new Exception(myErr.ToString() + reqSQL));
			}
	}

	/// <summary>
	/// delete record from datasource
	/// </summary>
	/// <param name="myID"></param>
	public void deletez_prueba_equipo(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_prueba_equipo WHERE (id_prueba_equipo = "+myID+")",myConn);
				myCommand.ExecuteNonQuery();	
				myBase.CloseConnection(myConn);
			}
			catch(Exception myErr)
			{
				throw(new Exception(myErr.ToString()));
			}
	}

	/// <summary>
	/// modify a record
	/// </summary>
	public void modifyz_prueba_equipo(z_prueba_equipo myz_prueba_equipo)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_prueba_equipo SET id_prueba_equipo="+myz_prueba_equipo.id_prueba_equipo+",fecha='"+myz_prueba_equipo.fecha+"',id_carro="+myz_prueba_equipo.id_carro+",estado="+myz_prueba_equipo.estado+" WHERE (id_prueba_equipo="+myz_prueba_equipo.id_prueba_equipo+")";
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
				myCommand.ExecuteNonQuery();	
				myBase.CloseConnection(myConn);
			}
			catch(Exception myErr)
			{
				throw(new Exception(myErr.ToString() + reqSQL));
			}
	}

	/// <summary>
	/// get an instance of object
	/// </summary>
	/// <param name="myID"></param>
	public z_prueba_equipo getObjectz_prueba_equipo(System.Int32 myID)
	{
		z_prueba_equipo myz_prueba_equipo = new z_prueba_equipo();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_prueba_equipo,fecha,id_carro,estado FROM z_prueba_equipo WHERE (id_prueba_equipo="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_prueba_equipo.id_prueba_equipo = Convert.ToInt32(myReader[0]);
				myz_prueba_equipo.fecha = Convert.ToDateTime(myReader[1]);
				myz_prueba_equipo.id_carro = Convert.ToInt32(myReader[2]);
				myz_prueba_equipo.estado = Convert.ToBoolean(myReader[3]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_prueba_equipo;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_prueba_equipo()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_prueba_equipo";
			try
			{
				CnxBase myD4MCnx = new CnxBase();	
				DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
				return myResult;
			}
			catch(Exception myErr)
			{
				throw(new Exception(myErr.ToString() + reqSQL));
			}
	}

	#endregion


}
 
 
 }
