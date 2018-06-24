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
/// s_rescate_urbano
/// </summary>
public class s_rescate_urbano
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
	/// s_rescate_urbano
	/// </summary>
	public s_rescate_urbano()
	{
	}


	/// <summary>
	/// s_rescate_urbano
	/// </summary>
	public s_rescate_urbano(System.Int32 id_especialidad,System.Int32 id_sector,System.Int32 prioridad,System.String contacto)
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
	public void adds_rescate_urbano(s_rescate_urbano mys_rescate_urbano)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO s_rescate_urbano (id_especialidad,id_sector,prioridad,contacto, id_central) VALUES ("+mys_rescate_urbano.id_especialidad+","+mys_rescate_urbano.id_sector+","+mys_rescate_urbano.prioridad+",'"+mys_rescate_urbano.contacto+"',"+mys_rescate_urbano.id_central+")";
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
	public void deletes_rescate_urbano(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM s_rescate_urbano WHERE (id_especialidad = "+myID+")",myConn);
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
	public void modifys_rescate_urbano(s_rescate_urbano mys_rescate_urbano)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE s_rescate_urbano SET id_especialidad="+mys_rescate_urbano.id_especialidad+",id_sector="+mys_rescate_urbano.id_sector+",prioridad="+mys_rescate_urbano.prioridad+",contacto='"+mys_rescate_urbano.contacto+"',id_central="+mys_rescate_urbano.id_central+" WHERE (id_especialidad="+mys_rescate_urbano.id_especialidad+")";
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
	public s_rescate_urbano getObjects_rescate_urbano(System.Int32 myID)
	{
		s_rescate_urbano mys_rescate_urbano = new s_rescate_urbano();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_especialidad,id_sector,prioridad,contacto,id_central FROM s_rescate_urbano WHERE (id_especialidad="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				mys_rescate_urbano.id_especialidad = Convert.ToInt32(myReader[0]);
				mys_rescate_urbano.id_sector = Convert.ToInt32(myReader[1]);
				mys_rescate_urbano.prioridad = Convert.ToInt32(myReader[2]);
				mys_rescate_urbano.contacto = myReader[3].ToString();
                mys_rescate_urbano.id_central = Convert.ToInt32(myReader[4]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return mys_rescate_urbano;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Gets_rescate_urbano()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM s_rescate_urbano";
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

    public DataSet Gets_rescate_urbano_sector(int id_sector)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT s_rescate_urbano.*,s_central.* FROM s_rescate_urbano,s_central WHERE id_sector=" + id_sector + " and s_rescate_urbano.id_central=s_central.id_central order by prioridad asc";
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
