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
/// k_grifos
/// </summary>
public class k_grifos
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

	private System.Int32 _identifica;
	public System.Int32 identifica
	{ 
		get 
		{ 
			return _identifica;
		}
		set 
        { 
			_identifica = value;
		}
	}

	private System.String _comuna_;
	public System.String comuna_
	{ 
		get 
		{ 
			return _comuna_;
		}
		set 
        { 
			_comuna_ = value;
		}
	}

	private System.String _direccion;
	public System.String direccion
	{ 
		get 
		{ 
			return _direccion;
		}
		set 
        { 
			_direccion = value;
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
	/// k_grifos
	/// </summary>
	public k_grifos()
	{
	}


	/// <summary>
	/// k_grifos
	/// </summary>
	public k_grifos(System.Int32 gid,System.Int32 identifica,System.String comuna_,System.String direccion,System.String the_geom)
	{
		this.gid = gid;
		this.identifica = identifica;
		this.comuna_ = comuna_;
		this.direccion = direccion;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(k_grifos myk_grifos)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO k_grifos (gid,identifica,comuna_,direccion,the_geom) VALUES ("+myk_grifos.gid+","+myk_grifos.identifica+",'"+myk_grifos.comuna_+"','"+myk_grifos.direccion+"','"+myk_grifos.the_geom+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM k_grifos WHERE (gid = "+myID+")",myConn);
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
	public void Update(k_grifos myk_grifos)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE k_grifos SET gid="+myk_grifos.gid+",identifica="+myk_grifos.identifica+",comuna_='"+myk_grifos.comuna_+"',direccion='"+myk_grifos.direccion+"',the_geom='"+myk_grifos.the_geom+"' WHERE (gid="+myk_grifos.gid+")";
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
	public k_grifos getObjectk_grifos(System.Int32 myID)
	{
		k_grifos myk_grifos = new k_grifos();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT gid,identifica,comuna_,direccion,the_geom FROM k_grifos WHERE (gid="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myk_grifos.gid = Convert.ToInt32(myReader[0]);
				myk_grifos.identifica = Convert.ToInt32(myReader[1]);
				myk_grifos.comuna_ = myReader[2].ToString();
				myk_grifos.direccion = myReader[3].ToString();
				myk_grifos.the_geom = myReader[4].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myk_grifos;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getk_grifos()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM k_grifos";
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
