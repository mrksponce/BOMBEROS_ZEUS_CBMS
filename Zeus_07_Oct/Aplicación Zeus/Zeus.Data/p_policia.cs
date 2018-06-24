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
/// p_policia
/// </summary>
public class p_policia
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

	private System.Int64 _sgc1;
	public System.Int64 sgc1
	{ 
		get 
		{ 
			return _sgc1;
		}
		set 
        { 
			_sgc1 = value;
		}
	}

	private System.String _sgc2;
	public System.String sgc2
	{ 
		get 
		{ 
			return _sgc2;
		}
		set 
        { 
			_sgc2 = value;
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
	/// p_policia
	/// </summary>
	public p_policia()
	{
	}


	/// <summary>
	/// p_policia
	/// </summary>
	public p_policia(System.Int32 gid,System.Int64 sgc1,System.String sgc2,System.String the_geom)
	{
		this.gid = gid;
		this.sgc1 = sgc1;
		this.sgc2 = sgc2;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(p_policia myp_policia)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO p_policia (gid,sgc1,sgc2,geom) VALUES ("+myp_policia.gid+","+myp_policia.sgc1+",'"+myp_policia.sgc2+"','"+myp_policia.the_geom+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM p_policia WHERE (gid = "+myID+")",myConn);
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
	public void Update(p_policia myp_policia)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE p_policia SET gid="+myp_policia.gid+",sgc1="+myp_policia.sgc1+",sgc2='"+myp_policia.sgc2+"',geom='"+myp_policia.the_geom+"' WHERE (gid="+myp_policia.gid+")";
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
	public p_policia getObjectp_policia(System.Int32 myID)
	{
		p_policia myp_policia = new p_policia();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT gid,sgc1,sgc2,geom FROM p_policia WHERE (gid="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myp_policia.gid = Convert.ToInt32(myReader[0]);
				myp_policia.sgc1 = Convert.ToInt64(myReader[1]);
				myp_policia.sgc2 = myReader[2].ToString();
				myp_policia.the_geom = myReader[3].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myp_policia;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getp_policia()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM p_policia";
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
