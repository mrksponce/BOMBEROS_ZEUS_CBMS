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
/// z_dos_6
/// </summary>
public class z_dos_6
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_dos_6;
	public System.Int32 id_dos_6
	{ 
		get 
		{ 
			return _id_dos_6;
		}
		set 
        { 
			_id_dos_6 = value;
		}
	}

	private System.Int32 _id_despacho;
	public System.Int32 id_despacho
	{ 
		get 
		{ 
			return _id_despacho;
		}
		set 
        { 
			_id_despacho = value;
		}
	}

	private System.Int32 _id_carro;
	public System.Int32 id_carro
	{ 
		get 
		{ 
			return _id_carro;
		}
		set 
        { 
			_id_carro = value;
		}
	}

	#endregion

	/// <summary>
	/// z_dos_6
	/// </summary>
	public z_dos_6()
	{
	}


	/// <summary>
	/// z_dos_6
	/// </summary>
	public z_dos_6(System.Int32 id_dos_6,System.Int32 id_despacho,System.Int32 id_carro)
	{
		this.id_dos_6 = id_dos_6;
		this.id_despacho = id_despacho;
		this.id_carro = id_carro;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_dos_6(z_dos_6 myz_dos_6)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_dos_6 (id_despacho,id_carro) VALUES ("+myz_dos_6.id_despacho+","+myz_dos_6.id_carro+")";
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
	public void deletez_dos_6(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_dos_6 WHERE (id_dos_6 = "+myID+")",myConn);
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
	public void modifyz_dos_6(z_dos_6 myz_dos_6)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_dos_6 SET id_dos_6="+myz_dos_6.id_dos_6+",id_despacho="+myz_dos_6.id_despacho+",id_carro="+myz_dos_6.id_carro+" WHERE (id_dos_6="+myz_dos_6.id_dos_6+")";
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
	public z_dos_6 getObjectz_dos_6(System.Int32 myID)
	{
		z_dos_6 myz_dos_6 = new z_dos_6();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_dos_6,id_despacho,id_carro FROM z_dos_6 WHERE (id_despacho="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_dos_6.id_dos_6 = Convert.ToInt32(myReader[0]);
				myz_dos_6.id_despacho = Convert.ToInt32(myReader[1]);
				myz_dos_6.id_carro = Convert.ToInt32(myReader[2]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_dos_6;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_dos_6()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_dos_6";
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

    public DataSet GetDos6Despacho(int id_despacho)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT * FROM z_dos_6 where id_despacho="+id_despacho;
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

    public void DeleteDos6Despacho(int id_despacho)
    {
        CnxBase myBase = new CnxBase();
        try
        {
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_dos_6 WHERE (id_despacho = " + id_despacho + ")", myConn);
            myCommand.ExecuteNonQuery();
            myBase.CloseConnection(myConn);
        }
        catch (Exception myErr)
        {
            throw (new Exception(myErr.ToString()));
        }
    }
	#endregion


}
 
 
 }
