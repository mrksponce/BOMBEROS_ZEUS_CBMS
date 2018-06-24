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
/// p_paradero
/// </summary>
public class p_paradero
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

	private System.String _avenida;
	public System.String avenida
	{ 
		get 
		{ 
			return _avenida;
		}
		set 
        { 
			_avenida = value;
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
	/// p_paradero
	/// </summary>
	public p_paradero()
	{
	}


	/// <summary>
	/// p_paradero
	/// </summary>
	public p_paradero(System.Int32 gid,System.Int32 id,System.String avenida,System.Int64 sgc1,System.String sgc2,System.String the_geom)
	{
		this.gid = gid;
		this.id = id;
		this.avenida = avenida;
		this.sgc1 = sgc1;
		this.sgc2 = sgc2;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(p_paradero myp_paradero)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO p_paradero (gid,id,avenida,sgc1,sgc2,the_geom) VALUES ("+myp_paradero.gid+","+myp_paradero.id+",'"+myp_paradero.avenida+"',"+myp_paradero.sgc1+",'"+myp_paradero.sgc2+"','"+myp_paradero.the_geom+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM p_paradero WHERE (gid = "+myID+")",myConn);
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
	public void Update(p_paradero myp_paradero)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE p_paradero SET gid="+myp_paradero.gid+",id="+myp_paradero.id+",avenida='"+myp_paradero.avenida+"',sgc1="+myp_paradero.sgc1+",sgc2='"+myp_paradero.sgc2+"',the_geom='"+myp_paradero.the_geom+"' WHERE (gid="+myp_paradero.gid+")";
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
	public p_paradero getObjectp_paradero(System.Int32 myID)
	{
		p_paradero myp_paradero = new p_paradero();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT gid,id,avenida,sgc1,sgc2,the_geom FROM p_paradero WHERE (gid="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myp_paradero.gid = Convert.ToInt32(myReader[0]);
				myp_paradero.id = Convert.ToInt32(myReader[1]);
				myp_paradero.avenida = myReader[2].ToString();
				myp_paradero.sgc1 = Convert.ToInt64(myReader[3]);
				myp_paradero.sgc2 = myReader[4].ToString();
				myp_paradero.the_geom = myReader[5].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myp_paradero;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getp_paradero()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM p_paradero";
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
