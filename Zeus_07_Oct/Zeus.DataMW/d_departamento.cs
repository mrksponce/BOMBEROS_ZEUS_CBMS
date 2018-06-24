/* Clases generadas por D4Modelizer
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
/// d_departamento
/// </summary>
public class d_departamento
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_departamento;
	public System.Int32 id_departamento
	{ 
		get 
		{ 
			return _id_departamento;
		}
		set 
        { 
			_id_departamento = value;
		}
	}

	private System.String _nombre;
	public System.String nombre
	{ 
		get 
		{ 
			return _nombre;
		}
		set 
        { 
			_nombre = value;
		}
	}

	#endregion

	/// <summary>
	/// d_departamento
	/// </summary>
	public d_departamento()
	{
	}


	/// <summary>
	/// d_departamento
	/// </summary>
	public d_departamento(System.Int32 id_departamento,System.String nombre)
	{
		this.id_departamento = id_departamento;
		this.nombre = nombre;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(d_departamento myd_departamento)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO d_departamento (nombre) VALUES ('"+myd_departamento.nombre+"')";
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
	public void Delete(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM d_departamento WHERE (id_departamento = "+myID+")",myConn);
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
	public void Update(d_departamento myd_departamento)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE d_departamento SET id_departamento="+myd_departamento.id_departamento+",nombre='"+myd_departamento.nombre+"' WHERE (id_departamento="+myd_departamento.id_departamento+")";
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
	public d_departamento getObjectd_departamento(System.Int32 myID)
	{
		d_departamento myd_departamento = new d_departamento();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_departamento,nombre FROM d_departamento WHERE (id_departamento="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myd_departamento.id_departamento = Convert.ToInt32(myReader[0]);
				myd_departamento.nombre = myReader[1].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myd_departamento;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getd_departamento()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM d_departamento";
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
