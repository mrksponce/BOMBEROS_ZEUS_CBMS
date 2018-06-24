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
/// s_central
/// </summary>
public class s_central
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_central;
	public System.Int32 id_central
	{ 
		get 
		{ 
			return _id_central;
		}
		set 
        { 
			_id_central = value;
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

	#endregion

	/// <summary>
	/// s_central
	/// </summary>
	public s_central()
	{
	}


	/// <summary>
	/// s_central
	/// </summary>
	public s_central(System.Int32 id_central,System.String nombre,System.String telefono)
	{
		this.id_central = id_central;
		this.nombre = nombre;
		this.telefono = telefono;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void adds_central(s_central mys_central)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO s_central (id_central,nombre,telefono) VALUES ("+mys_central.id_central+",'"+mys_central.nombre+"','"+mys_central.telefono+"')";
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
	public void deletes_central(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM s_central WHERE (id_central = "+myID+")",myConn);
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
	public void modifys_central(s_central mys_central)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE s_central SET id_central="+mys_central.id_central+",nombre='"+mys_central.nombre+"',telefono='"+mys_central.telefono+"' WHERE (id_central="+mys_central.id_central+")";
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
	public s_central getObjects_central(System.Int32 myID)
	{
		s_central mys_central = new s_central();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_central,nombre,telefono FROM s_central WHERE (id_central="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				mys_central.id_central = Convert.ToInt32(myReader[0]);
				mys_central.nombre = myReader[1].ToString();
				mys_central.telefono = myReader[2].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return mys_central;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Gets_central()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM s_central";
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
