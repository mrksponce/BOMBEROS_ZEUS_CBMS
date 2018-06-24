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
/// z_novedad
/// </summary>
public class z_novedad
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_novedad;
	public System.Int32 id_novedad
	{ 
		get 
		{ 
			return _id_novedad;
		}
		set 
        { 
			_id_novedad = value;
		}
	}

	private System.Int32 _id_operadora;
	public System.Int32 id_operadora
	{ 
		get 
		{ 
			return _id_operadora;
		}
		set 
        { 
			_id_operadora = value;
		}
	}

	private System.DateTime _fecha;
	public System.DateTime fecha
	{ 
		get 
		{ 
			return _fecha;
		}
		set 
        { 
			_fecha = value;
		}
	}

	private System.String _novedad;
	public System.String novedad
	{ 
		get 
		{ 
			return _novedad;
		}
		set 
        { 
			_novedad = value;
		}
	}

	private System.String _descripcion;
	public System.String descripcion
	{ 
		get 
		{ 
			return _descripcion;
		}
		set 
        { 
			_descripcion = value;
		}
	}

	#endregion

	/// <summary>
	/// z_novedad
	/// </summary>
	public z_novedad()
	{
	}


	/// <summary>
	/// z_novedad
	/// </summary>
	public z_novedad(System.Int32 id_novedad,System.Int32 id_operadora,System.DateTime fecha,System.String novedad,System.String descripcion)
	{
		this.id_novedad = id_novedad;
		this.id_operadora = id_operadora;
		this.fecha = fecha;
		this.novedad = novedad;
		this.descripcion = descripcion;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_novedad(z_novedad myz_novedad)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_novedad (id_operadora,fecha,novedad,descripcion) VALUES ("+myz_novedad.id_operadora+",'"+myz_novedad.fecha+"','"+myz_novedad.novedad+"','"+myz_novedad.descripcion+"')";
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
	public void deletez_novedad(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_novedad WHERE (id_novedad = "+myID+")",myConn);
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
	public void modifyz_novedad(z_novedad myz_novedad)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_novedad SET id_novedad="+myz_novedad.id_novedad+",id_operadora="+myz_novedad.id_operadora+",fecha='"+myz_novedad.fecha+"',novedad='"+myz_novedad.novedad+"',descripcion='"+myz_novedad.descripcion+"' WHERE (id_novedad="+myz_novedad.id_novedad+")";
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
	public z_novedad getObjectz_novedad(System.Int32 myID)
	{
		z_novedad myz_novedad = new z_novedad();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_novedad,id_operadora,fecha,novedad,descripcion FROM z_novedad WHERE (id_novedad="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_novedad.id_novedad = Convert.ToInt32(myReader[0]);
				myz_novedad.id_operadora = Convert.ToInt32(myReader[1]);
				myz_novedad.fecha = Convert.ToDateTime(myReader[2]);
				myz_novedad.novedad = myReader[3].ToString();
				myz_novedad.descripcion = myReader[4].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_novedad;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_novedad()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_novedad";
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
