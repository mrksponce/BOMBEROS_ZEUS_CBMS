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
/// s_hazmat
/// </summary>
public class s_hazmat
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
	/// s_hazmat
	/// </summary>
	public s_hazmat()
	{
	}


	/// <summary>
	/// s_hazmat
	/// </summary>
	public s_hazmat(System.Int32 id_especialidad,System.Int32 id_sector,System.Int32 prioridad,System.String contacto)
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
	public void adds_hazmat(s_hazmat mys_hazmat)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO s_hazmat (id_especialidad,id_sector,prioridad,contacto,id_central) VALUES ("+mys_hazmat.id_especialidad+","+mys_hazmat.id_sector+","+mys_hazmat.prioridad+",'"+mys_hazmat.contacto+"',"+mys_hazmat.id_central+")";
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
	public void deletes_hazmat(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM s_hazmat WHERE (id_especialidad = "+myID+")",myConn);
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
	public void modifys_hazmat(s_hazmat mys_hazmat)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE s_hazmat SET id_especialidad="+mys_hazmat.id_especialidad+",id_sector="+mys_hazmat.id_sector+",prioridad="+mys_hazmat.prioridad+",contacto='"+mys_hazmat.contacto+"',id_central="+mys_hazmat.id_central+" WHERE (id_especialidad="+mys_hazmat.id_especialidad+")";
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
	public s_hazmat getObjects_hazmat(System.Int32 myID)
	{
		s_hazmat mys_hazmat = new s_hazmat();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_especialidad,id_sector,prioridad,contacto,id_central FROM s_hazmat WHERE (id_especialidad="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				mys_hazmat.id_especialidad = Convert.ToInt32(myReader[0]);
				mys_hazmat.id_sector = Convert.ToInt32(myReader[1]);
				mys_hazmat.prioridad = Convert.ToInt32(myReader[2]);
				mys_hazmat.contacto = myReader[3].ToString();
                mys_hazmat.id_central = Convert.ToInt32(myReader[4]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return mys_hazmat;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Gets_hazmat()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM s_hazmat";
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

    public DataSet Gets_hazmat_sector(int id_sector)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT s_hazmat.*,s_central.* FROM s_hazmat,s_central WHERE id_sector=" + id_sector + " and s_hazmat.id_central=s_central.id_central order by prioridad asc";
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
