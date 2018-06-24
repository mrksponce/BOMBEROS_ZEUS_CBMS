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
/// d_departamento_detalle
/// </summary>
public class d_departamento_detalle
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_detalle;
	public System.Int32 id_detalle
	{ 
		get 
		{ 
			return _id_detalle;
		}
		set 
        { 
			_id_detalle = value;
		}
	}

	private System.Int32 _id_departamento;
	public System.Int32 id_departamento
	{ 
		get 
		{ 
			return _id_departamento;
		}
		set 
        { 
			_id_departamento = value;
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

	private System.String _cargo;
	public System.String cargo
	{ 
		get 
		{ 
			return _cargo;
		}
		set 
        { 
			_cargo = value;
		}
	}

	private System.String _codigo;
	public System.String codigo
	{ 
		get 
		{ 
			return _codigo;
		}
		set 
        { 
			_codigo = value;
		}
	}

	private System.String _fono_fijo;
	public System.String fono_fijo
	{ 
		get 
		{ 
			return _fono_fijo;
		}
		set 
        { 
			_fono_fijo = value;
		}
	}

	private System.String _fono_movil;
	public System.String fono_movil
	{ 
		get 
		{ 
			return _fono_movil;
		}
		set 
        { 
			_fono_movil = value;
		}
	}

	#endregion

	/// <summary>
	/// d_departamento_detalle
	/// </summary>
	public d_departamento_detalle()
	{
	}


	/// <summary>
	/// d_departamento_detalle
	/// </summary>
	public d_departamento_detalle(System.Int32 id_detalle,System.Int32 id_departamento,System.String nombre,System.String cargo,System.String codigo,System.String fono_fijo,System.String fono_movil)
	{
		this.id_detalle = id_detalle;
		this.id_departamento = id_departamento;
		this.nombre = nombre;
		this.cargo = cargo;
		this.codigo = codigo;
		this.fono_fijo = fono_fijo;
		this.fono_movil = fono_movil;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(d_departamento_detalle myd_departamento_detalle)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO d_departamento_detalle (id_departamento,nombre,cargo,codigo,fono_fijo,fono_movil) VALUES ("+myd_departamento_detalle.id_departamento+",'"+myd_departamento_detalle.nombre+"','"+myd_departamento_detalle.cargo+"','"+myd_departamento_detalle.codigo+"','"+myd_departamento_detalle.fono_fijo+"','"+myd_departamento_detalle.fono_movil+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM d_departamento_detalle WHERE (id_detalle = "+myID+")",myConn);
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
	public void Update(d_departamento_detalle myd_departamento_detalle)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE d_departamento_detalle SET id_detalle="+myd_departamento_detalle.id_detalle+",id_departamento="+myd_departamento_detalle.id_departamento+",nombre='"+myd_departamento_detalle.nombre+"',cargo='"+myd_departamento_detalle.cargo+"',codigo='"+myd_departamento_detalle.codigo+"',fono_fijo='"+myd_departamento_detalle.fono_fijo+"',fono_movil='"+myd_departamento_detalle.fono_movil+"' WHERE (id_detalle="+myd_departamento_detalle.id_detalle+")";
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
	public d_departamento_detalle getObjectd_departamento_detalle(System.Int32 myID)
	{
		d_departamento_detalle myd_departamento_detalle = new d_departamento_detalle();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_detalle,id_departamento,nombre,cargo,codigo,fono_fijo,fono_movil FROM d_departamento_detalle WHERE (id_detalle="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myd_departamento_detalle.id_detalle = Convert.ToInt32(myReader[0]);
				myd_departamento_detalle.id_departamento = Convert.ToInt32(myReader[1]);
				myd_departamento_detalle.nombre = myReader[2].ToString();
				myd_departamento_detalle.cargo = myReader[3].ToString();
				myd_departamento_detalle.codigo = myReader[4].ToString();
				myd_departamento_detalle.fono_fijo = myReader[5].ToString();
				myd_departamento_detalle.fono_movil = myReader[6].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myd_departamento_detalle;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getd_departamento_detalle()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM d_departamento_detalle";
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

    public DataSet Getd_departamento_detalle(int id_departamento)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT * FROM d_departamento_detalle where id_departamento="+id_departamento;
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
