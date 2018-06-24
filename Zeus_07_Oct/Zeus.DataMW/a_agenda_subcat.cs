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
/// a_agenda_subcat
/// </summary>
public class a_agenda_subcat
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_subcat;
	public System.Int32 id_subcat
	{ 
		get 
		{ 
			return _id_subcat;
		}
		set 
        { 
			_id_subcat = value;
		}
	}

	private System.Int32 _id_cat;
	public System.Int32 id_cat
	{ 
		get 
		{ 
			return _id_cat;
		}
		set 
        { 
			_id_cat = value;
		}
	}

	private System.String _nombre;
	public System.String nombre
	{ 
		get 
		{ 
			return _nombre;
		}
		set 
        { 
			_nombre = value;
		}
	}

	#endregion

	/// <summary>
	/// a_agenda_subcat
	/// </summary>
	public a_agenda_subcat()
	{
	}


	/// <summary>
	/// a_agenda_subcat
	/// </summary>
	public a_agenda_subcat(System.Int32 id_subcat,System.Int32 id_cat,System.String nombre)
	{
		this.id_subcat = id_subcat;
		this.id_cat = id_cat;
		this.nombre = nombre;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(a_agenda_subcat mya_agenda_subcat)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO a_agenda_subcat (id_cat,nombre) VALUES ("+mya_agenda_subcat.id_cat+",'"+mya_agenda_subcat.nombre+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM a_agenda_subcat WHERE (id_subcat = "+myID+")",myConn);
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
	public void Update(a_agenda_subcat mya_agenda_subcat)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE a_agenda_subcat SET id_subcat="+mya_agenda_subcat.id_subcat+",id_cat="+mya_agenda_subcat.id_cat+",nombre='"+mya_agenda_subcat.nombre+"' WHERE (id_subcat="+mya_agenda_subcat.id_subcat+")";
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
	public a_agenda_subcat getObjecta_agenda_subcat(System.Int32 myID)
	{
		a_agenda_subcat mya_agenda_subcat = new a_agenda_subcat();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_subcat,id_cat,nombre FROM a_agenda_subcat WHERE (id_subcat="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				mya_agenda_subcat.id_subcat = Convert.ToInt32(myReader[0]);
				mya_agenda_subcat.id_cat = Convert.ToInt32(myReader[1]);
				mya_agenda_subcat.nombre = myReader[2].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return mya_agenda_subcat;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Geta_agenda_subcat()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM a_agenda_subcat";
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

    public DataSet Geta_agenda_subcat(int id_cat)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT * FROM a_agenda_subcat where id_cat="+id_cat+" order by id_subcat";
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
