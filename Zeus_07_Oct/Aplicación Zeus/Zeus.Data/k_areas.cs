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
/// k_areas
/// </summary>
public class k_areas
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

	private System.Int32 _id_area;
	public System.Int32 id_area
	{ 
		get 
		{ 
			return _id_area;
		}
		set 
        { 
			_id_area = value;
		}
	}

	private System.Int64 _count;
	public System.Int64 count
	{ 
		get 
		{ 
			return _count;
		}
		set 
        { 
			_count = value;
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
	/// k_areas
	/// </summary>
	public k_areas()
	{
	}


	/// <summary>
	/// k_areas
	/// </summary>
	public k_areas(System.Int32 gid,System.Int32 id_area,System.Int64 count,System.String the_geom)
	{
		this.gid = gid;
		this.id_area = id_area;
		this.count = count;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(k_areas myk_areas)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO k_areas (gid,id_area,count,geom) VALUES ("+myk_areas.gid+","+myk_areas.id_area+","+myk_areas.count+",'"+myk_areas.the_geom+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM k_areas WHERE (id_area = "+myID+")",myConn);
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
	public void Update(k_areas myk_areas)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE k_areas SET gid="+myk_areas.gid+",id_area="+myk_areas.id_area+",count="+myk_areas.count+",geom='"+myk_areas.the_geom+"' WHERE (id_area="+myk_areas.id_area+")";
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
	public k_areas getObjectk_areas(System.Int32 myID)
	{
		k_areas myk_areas = new k_areas();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT gid,id_area,count,geom FROM k_areas WHERE (id_area="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myk_areas.gid = Convert.ToInt32(myReader[0]);
				myk_areas.id_area = Convert.ToInt32(myReader[1]);
				myk_areas.count = Convert.ToInt64(myReader[2]);
				myk_areas.the_geom = myReader[3].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myk_areas;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getk_areas()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM k_areas";
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

    public DataSet Getz_llamados()
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT * FROM z_llamados WHERE codigo_llamado >= 50";
        try
        {
            CnxBase myD4MCnx = new CnxBase();
            DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
            return myResult;
        }
        catch (Exception myErr)
        {
            throw (new Exception(myErr.ToString() + reqSQL));
        }
    }

	#endregion


}
 
 
 }
