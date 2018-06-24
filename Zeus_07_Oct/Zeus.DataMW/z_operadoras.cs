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
/// z_operadoras
/// </summary>
public class z_operadoras
{

	#region ***** Campos y propiedades ***** 

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

	private System.String _nombres;
	public System.String nombres
	{ 
		get 
		{ 
			return _nombres;
		}
		set 
        { 
			_nombres = value;
		}
	}

	private System.String _apellidos;
	public System.String apellidos
	{ 
		get 
		{ 
			return _apellidos;
		}
		set 
        { 
			_apellidos = value;
		}
	}

	private System.String _rut;
	public System.String rut
	{ 
		get 
		{ 
			return _rut;
		}
		set 
        { 
			_rut = value;
		}
	}

	private System.DateTime _fecha_nacimiento;
	public System.DateTime fecha_nacimiento
	{ 
		get 
		{ 
			return _fecha_nacimiento;
		}
		set 
        { 
			_fecha_nacimiento = value;
		}
	}

	private System.String _direccion;
	public System.String direccion
	{ 
		get 
		{ 
			return _direccion;
		}
		set 
        { 
			_direccion = value;
		}
	}

	private System.String _comuna;
	public System.String comuna
	{ 
		get 
		{ 
			return _comuna;
		}
		set 
        { 
			_comuna = value;
		}
	}

	private System.String _telefono;
	public System.String telefono
	{ 
		get 
		{ 
			return _telefono;
		}
		set 
        { 
			_telefono = value;
		}
	}

	private System.String _celular;
	public System.String celular
	{ 
		get 
		{ 
			return _celular;
		}
		set 
        { 
			_celular = value;
		}
	}

	#endregion

	/// <summary>
	/// z_operadoras
	/// </summary>
	public z_operadoras()
	{
	}


	/// <summary>
	/// z_operadoras
	/// </summary>
	public z_operadoras(System.Int32 id_operadora,System.String nombres,System.String apellidos,System.String rut,System.DateTime fecha_nacimiento,System.String direccion,System.String comuna,System.String telefono,System.String celular)
	{
		this.id_operadora = id_operadora;
		this.nombres = nombres;
		this.apellidos = apellidos;
		this.rut = rut;
		this.fecha_nacimiento = fecha_nacimiento;
		this.direccion = direccion;
		this.comuna = comuna;
		this.telefono = telefono;
		this.celular = celular;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_operadoras(z_operadoras myz_operadoras)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_operadoras (nombres,apellidos,rut,fecha_nacimiento,direccion,comuna,telefono,celular) VALUES ('"+myz_operadoras.nombres+"','"+myz_operadoras.apellidos+"','"+myz_operadoras.rut+"','"+myz_operadoras.fecha_nacimiento+"','"+myz_operadoras.direccion+"','"+myz_operadoras.comuna+"','"+myz_operadoras.telefono+"','"+myz_operadoras.celular+"')";
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
	public void deletez_operadoras(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_operadoras WHERE (id_operadora = "+myID+")",myConn);
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
	public void modifyz_operadoras(z_operadoras myz_operadoras)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_operadoras SET id_operadora="+myz_operadoras.id_operadora+",nombres='"+myz_operadoras.nombres+"',apellidos='"+myz_operadoras.apellidos+"',rut='"+myz_operadoras.rut+"',fecha_nacimiento='"+myz_operadoras.fecha_nacimiento+"',direccion='"+myz_operadoras.direccion+"',comuna='"+myz_operadoras.comuna+"',telefono='"+myz_operadoras.telefono+"',celular='"+myz_operadoras.celular+"' WHERE (id_operadora="+myz_operadoras.id_operadora+")";
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
	public z_operadoras getObjectz_operadoras(System.Int32 myID)
	{
		z_operadoras myz_operadoras = new z_operadoras();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_operadora,nombres,apellidos,rut,fecha_nacimiento,direccion,comuna,telefono,celular FROM z_operadoras WHERE (id_operadora="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_operadoras.id_operadora = Convert.ToInt32(myReader[0]);
				myz_operadoras.nombres = myReader[1].ToString();
				myz_operadoras.apellidos = myReader[2].ToString();
				myz_operadoras.rut = myReader[3].ToString();
				myz_operadoras.fecha_nacimiento = Convert.ToDateTime(myReader[4]);
				myz_operadoras.direccion = myReader[5].ToString();
				myz_operadoras.comuna = myReader[6].ToString();
				myz_operadoras.telefono = myReader[7].ToString();
				myz_operadoras.celular = myReader[8].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_operadoras;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_operadoras()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_operadoras";
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
    public DataSet Getz_operadorasLista()
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT *, apellidos||' '||nombres as nombre_completo FROM z_operadoras";
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

    public DataSet Getz_operadorasLista2()
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT *, 'OP ' || id_operadora as nombre_completo FROM z_operadoras ORDER BY id_operadora";
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
