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
/// p_supermercado
/// </summary>
public class p_supermercado
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

	private System.Int32 _id;
	public System.Int32 id
	{ 
		get 
		{ 
			return _id;
		}
		set 
        { 
			_id = value;
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
	/// p_supermercado
	/// </summary>
	public p_supermercado()
	{
	}


	/// <summary>
	/// p_supermercado
	/// </summary>
	public p_supermercado(System.Int32 gid,System.Int32 id,System.Int64 sgc1,System.String sgc2,System.String the_geom)
	{
		this.gid = gid;
		this.id = id;
		this.sgc1 = sgc1;
		this.sgc2 = sgc2;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(p_supermercado myp_supermercado)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO p_supermercado (gid,id,sgc1,sgc2,the_geom) VALUES ("+myp_supermercado.gid+","+myp_supermercado.id+","+myp_supermercado.sgc1+",'"+myp_supermercado.sgc2+"','"+myp_supermercado.the_geom+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM p_supermercado WHERE (gid = "+myID+")",myConn);
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
	public void Update(p_supermercado myp_supermercado)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE p_supermercado SET gid="+myp_supermercado.gid+",id="+myp_supermercado.id+",sgc1="+myp_supermercado.sgc1+",sgc2='"+myp_supermercado.sgc2+"',the_geom='"+myp_supermercado.the_geom+"' WHERE (gid="+myp_supermercado.gid+")";
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
	public p_supermercado getObjectp_supermercado(System.Int32 myID)
	{
		p_supermercado myp_supermercado = new p_supermercado();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT gid,id,sgc1,sgc2,the_geom FROM p_supermercado WHERE (gid="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myp_supermercado.gid = Convert.ToInt32(myReader[0]);
				myp_supermercado.id = Convert.ToInt32(myReader[1]);
				myp_supermercado.sgc1 = Convert.ToInt64(myReader[2]);
				myp_supermercado.sgc2 = myReader[3].ToString();
				myp_supermercado.the_geom = myReader[4].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myp_supermercado;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getp_supermercado()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM p_supermercado";
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
