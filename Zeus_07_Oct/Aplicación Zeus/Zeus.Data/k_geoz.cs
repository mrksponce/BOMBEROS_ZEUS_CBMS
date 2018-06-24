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
/// k_geoz
/// </summary>
public class k_geoz
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _gid;
	public System.Int32 gid
	{ 
		get 
		{ 
			return _gid;
		}
		set 
        { 
			_gid = value;
		}
	}

	private System.Int64 _id_hoja;
	public System.Int64 id_hoja
	{ 
		get 
		{ 
			return _id_hoja;
		}
		set 
        { 
			_id_hoja = value;
		}
	}

	private System.String _id_celda;
	public System.String id_celda
	{ 
		get 
		{ 
			return _id_celda;
		}
		set 
        { 
			_id_celda = value;
		}
	}

	private System.String _fila;
	public System.String fila
	{ 
		get 
		{ 
			return _fila;
		}
		set 
        { 
			_fila = value;
		}
	}

	private System.Int32 _columna;
	public System.Int32 columna
	{ 
		get 
		{ 
			return _columna;
		}
		set 
        { 
			_columna = value;
		}
	}

	private System.String _geoz;
	public System.String geoz
	{ 
		get 
		{ 
			return _geoz;
		}
		set 
        { 
			_geoz = value;
		}
	}

	private System.String _the_geom;
	public System.String the_geom
	{ 
		get 
		{ 
			return _the_geom;
		}
		set 
        { 
			_the_geom = value;
		}
	}

	#endregion

	/// <summary>
	/// k_geoz
	/// </summary>
	public k_geoz()
	{
	}


	/// <summary>
	/// k_geoz
	/// </summary>
	public k_geoz(System.Int32 gid,System.Int64 id_hoja,System.String id_celda,System.String fila,System.Int32 columna,System.String geoz,System.String the_geom)
	{
		this.gid = gid;
		this.id_hoja = id_hoja;
		this.id_celda = id_celda;
		this.fila = fila;
		this.columna = columna;
		this.geoz = geoz;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(k_geoz myk_geoz)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO k_geoz (gid,id_hoja,id_celda,fila,columna,geoz,geom) VALUES ("+myk_geoz.gid+","+myk_geoz.id_hoja+",'"+myk_geoz.id_celda+"','"+myk_geoz.fila+"',"+myk_geoz.columna+",'"+myk_geoz.geoz+"','"+myk_geoz.the_geom+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM k_geoz WHERE (gid = "+myID+")",myConn);
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
	public void Update(k_geoz myk_geoz)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE k_geoz SET gid="+myk_geoz.gid+",id_hoja="+myk_geoz.id_hoja+",id_celda='"+myk_geoz.id_celda+"',fila='"+myk_geoz.fila+"',columna="+myk_geoz.columna+",geoz='"+myk_geoz.geoz+"',geom='"+myk_geoz.the_geom+"' WHERE (gid="+myk_geoz.gid+")";
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
	public k_geoz getObjectk_geoz(System.Int32 myID)
	{
		k_geoz myk_geoz = new k_geoz();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT gid,id_hoja,id_celda,fila,columna,geoz,geom FROM k_geoz WHERE (gid="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myk_geoz.gid = Convert.ToInt32(myReader[0]);
				myk_geoz.id_hoja = Convert.ToInt64(myReader[1]);
				myk_geoz.id_celda = myReader[2].ToString();
				myk_geoz.fila = myReader[3].ToString();
				myk_geoz.columna = Convert.ToInt32(myReader[4]);
				myk_geoz.geoz = myReader[5].ToString();
				myk_geoz.the_geom = myReader[6].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myk_geoz;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getk_geoz()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM k_geoz";
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
