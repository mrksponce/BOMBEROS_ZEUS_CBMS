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
/// z_preinforme
/// </summary>
public class z_preinforme
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_preinforme;
	public System.Int32 id_preinforme
	{ 
		get 
		{ 
			return _id_preinforme;
		}
		set 
        { 
			_id_preinforme = value;
		}
	}

	private System.Int32 _codigo_llamado;
	public System.Int32 codigo_llamado
	{ 
		get 
		{ 
			return _codigo_llamado;
		}
		set 
        { 
			_codigo_llamado = value;
		}
	}

	private System.String _preinforme;
	public System.String preinforme
	{ 
		get 
		{ 
			return _preinforme;
		}
		set 
        { 
			_preinforme = value;
		}
	}

	#endregion

	/// <summary>
	/// z_preinforme
	/// </summary>
	public z_preinforme()
	{
	}


	/// <summary>
	/// z_preinforme
	/// </summary>
	public z_preinforme(System.Int32 id_preinforme,System.Int32 codigo_llamado,System.String preinforme)
	{
		this.id_preinforme = id_preinforme;
		this.codigo_llamado = codigo_llamado;
		this.preinforme = preinforme;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_preinforme(z_preinforme myz_preinforme)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_preinforme (codigo_llamado,preinforme) VALUES ("+myz_preinforme.codigo_llamado+",'"+myz_preinforme.preinforme+"')";
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
	public void deletez_preinforme(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_preinforme WHERE (id_preinforme = "+myID+")",myConn);
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
	public void modifyz_preinforme(z_preinforme myz_preinforme)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_preinforme SET id_preinforme="+myz_preinforme.id_preinforme+",codigo_llamado="+myz_preinforme.codigo_llamado+",preinforme='"+myz_preinforme.preinforme+"' WHERE (id_preinforme="+myz_preinforme.id_preinforme+")";
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
	public z_preinforme getObjectz_preinforme(System.Int32 myID)
	{
		z_preinforme myz_preinforme = new z_preinforme();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_preinforme,codigo_llamado,preinforme FROM z_preinforme WHERE (id_preinforme="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_preinforme.id_preinforme = Convert.ToInt32(myReader[0]);
				myz_preinforme.codigo_llamado = Convert.ToInt32(myReader[1]);
				myz_preinforme.preinforme = myReader[2].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_preinforme;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_preinforme()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_preinforme";
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

    public DataSet Getz_preinforme(int codigo_llamado)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT * FROM z_preinforme WHERE codigo_llamado=" + codigo_llamado;
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
}
 
 
 }
