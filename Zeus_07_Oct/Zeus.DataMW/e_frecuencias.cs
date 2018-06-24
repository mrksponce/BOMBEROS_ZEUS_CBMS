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
/// e_frecuencias
/// </summary>
public class e_frecuencias
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_frecuencia;
	public System.Int32 id_frecuencia
	{ 
		get 
		{ 
			return _id_frecuencia;
		}
		set 
        { 
			_id_frecuencia = value;
		}
	}

	private System.String _frecuencia;
	public System.String frecuencia
	{ 
		get 
		{ 
			return _frecuencia;
		}
		set 
        { 
			_frecuencia = value;
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

	private System.Int32 _color;
	public System.Int32 color
	{ 
		get 
		{ 
			return _color;
		}
		set 
        { 
			_color = value;
		}
	}

	#endregion

	/// <summary>
	/// e_frecuencias
	/// </summary>
	public e_frecuencias()
	{
	}


	/// <summary>
	/// e_frecuencias
	/// </summary>
	public e_frecuencias(System.Int32 id_frecuencia,System.String frecuencia,System.String descripcion,System.Int32 color)
	{
		this.id_frecuencia = id_frecuencia;
		this.frecuencia = frecuencia;
		this.descripcion = descripcion;
		this.color = color;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(e_frecuencias mye_frecuencias)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO e_frecuencias (id_frecuencia,frecuencia,descripcion,color) VALUES ("+mye_frecuencias.id_frecuencia+",'"+mye_frecuencias.frecuencia+"','"+mye_frecuencias.descripcion+"',"+mye_frecuencias.color+")";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM e_frecuencias WHERE (id_frecuencia = "+myID+")",myConn);
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
	public void Update(e_frecuencias mye_frecuencias)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE e_frecuencias SET id_frecuencia="+mye_frecuencias.id_frecuencia+",frecuencia='"+mye_frecuencias.frecuencia+"',descripcion='"+mye_frecuencias.descripcion+"',color="+mye_frecuencias.color+" WHERE (id_frecuencia="+mye_frecuencias.id_frecuencia+")";
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
	public e_frecuencias getObjecte_frecuencias(System.Int32 myID)
	{
		e_frecuencias mye_frecuencias = new e_frecuencias();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_frecuencia,frecuencia,descripcion,color FROM e_frecuencias WHERE (id_frecuencia="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				mye_frecuencias.id_frecuencia = Convert.ToInt32(myReader[0]);
				mye_frecuencias.frecuencia = myReader[1].ToString();
				mye_frecuencias.descripcion = myReader[2].ToString();
				mye_frecuencias.color = Convert.ToInt32(myReader[3]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return mye_frecuencias;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Gete_frecuencias()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM e_frecuencias";
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
