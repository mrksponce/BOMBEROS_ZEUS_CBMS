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
/// z_estado_carros
/// </summary>
public class z_estado_carros
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_estado;
	public System.Int32 id_estado
	{ 
		get 
		{ 
			return _id_estado;
		}
		set 
        { 
			_id_estado = value;
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

	private System.Boolean _visible;
	public System.Boolean visible
	{ 
		get 
		{ 
			return _visible;
		}
		set 
        { 
			_visible = value;
		}
	}

	#endregion

	/// <summary>
	/// z_estado_carros
	/// </summary>
	public z_estado_carros()
	{
	}


	/// <summary>
	/// z_estado_carros
	/// </summary>
	public z_estado_carros(System.Int32 id_estado,System.String descripcion,System.Boolean visible)
	{
		this.id_estado = id_estado;
		this.descripcion = descripcion;
		this.visible = visible;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_estado_carros(z_estado_carros myz_estado_carros)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_estado_carros (id_estado,descripcion,visible) VALUES ("+myz_estado_carros.id_estado+",'"+myz_estado_carros.descripcion+"',"+myz_estado_carros.visible+")";
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
	public void deletez_estado_carros(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_estado_carros WHERE (id_estado = "+myID+")",myConn);
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
	public void modifyz_estado_carros(z_estado_carros myz_estado_carros)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_estado_carros SET id_estado="+myz_estado_carros.id_estado+",descripcion='"+myz_estado_carros.descripcion+"',visible="+myz_estado_carros.visible+" WHERE (id_estado="+myz_estado_carros.id_estado+")";
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
	public z_estado_carros getObjectz_estado_carros(System.Int32 myID)
	{
		z_estado_carros myz_estado_carros = new z_estado_carros();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_estado,descripcion,visible FROM z_estado_carros WHERE (id_estado="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_estado_carros.id_estado = Convert.ToInt32(myReader[0]);
				myz_estado_carros.descripcion = myReader[1].ToString();
				myz_estado_carros.visible = Convert.ToBoolean(myReader[2]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_estado_carros;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_estado_carros()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_estado_carros";
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
