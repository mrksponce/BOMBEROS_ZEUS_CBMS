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
/// s_mecanica
/// </summary>
public class s_mecanica
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_especialidad;
	public System.Int32 id_especialidad
	{ 
		get 
		{ 
			return _id_especialidad;
		}
		set 
        { 
			_id_especialidad = value;
		}
	}

	private System.Int32 _id_sector;
	public System.Int32 id_sector
	{ 
		get 
		{ 
			return _id_sector;
		}
		set 
        { 
			_id_sector = value;
		}
	}

	private System.Int32 _prioridad;
	public System.Int32 prioridad
	{ 
		get 
		{ 
			return _prioridad;
		}
		set 
        { 
			_prioridad = value;
		}
	}

	private System.String _contacto;
	public System.String contacto
	{ 
		get 
		{ 
			return _contacto;
		}
		set 
        { 
			_contacto = value;
		}
	}
    private System.Int32 _id_central;
    public System.Int32 id_central
    {
        get
        {
            return _id_central;
        }
        set
        {
            _id_central = value;
        }
    }
	#endregion

	/// <summary>
	/// s_mecanica
	/// </summary>
	public s_mecanica()
	{
	}


	/// <summary>
	/// s_mecanica
	/// </summary>
	public s_mecanica(System.Int32 id_especialidad,System.Int32 id_sector,System.Int32 prioridad,System.String contacto)
	{
		this.id_especialidad = id_especialidad;
		this.id_sector = id_sector;
		this.prioridad = prioridad;
		this.contacto = contacto;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void adds_mecanica(s_mecanica mys_mecanica)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO s_mecanica (id_especialidad,id_sector,prioridad,contacto,id_central) VALUES ("+mys_mecanica.id_especialidad+","+mys_mecanica.id_sector+","+mys_mecanica.prioridad+",'"+mys_mecanica.contacto+"',"+mys_mecanica.id_central+")";
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
	public void deletes_mecanica(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM s_mecanica WHERE (id_especialidad = "+myID+")",myConn);
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
	public void modifys_mecanica(s_mecanica mys_mecanica)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE s_mecanica SET id_especialidad="+mys_mecanica.id_especialidad+",id_sector="+mys_mecanica.id_sector+",prioridad="+mys_mecanica.prioridad+",contacto='"+mys_mecanica.contacto+"',id_central="+mys_mecanica.id_central+" WHERE (id_especialidad="+mys_mecanica.id_especialidad+")";
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
	public s_mecanica getObjects_mecanica(System.Int32 myID)
	{
		s_mecanica mys_mecanica = new s_mecanica();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_especialidad,id_sector,prioridad,contacto,id_central FROM s_mecanica WHERE (id_especialidad="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				mys_mecanica.id_especialidad = Convert.ToInt32(myReader[0]);
				mys_mecanica.id_sector = Convert.ToInt32(myReader[1]);
				mys_mecanica.prioridad = Convert.ToInt32(myReader[2]);
				mys_mecanica.contacto = myReader[3].ToString();
                mys_mecanica.id_central = Convert.ToInt32(myReader[4]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return mys_mecanica;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Gets_mecanica()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM s_mecanica";
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

    public DataSet Gets_mecanica_sector(int id_sector)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT s_mecanica.*,s_central.* FROM s_mecanica,s_central WHERE id_sector=" + id_sector + " and s_mecanica.id_central=s_central.id_central order by prioridad asc";
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
