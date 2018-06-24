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
/// z_cuarteleros
/// </summary>
public class z_cuarteleros
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_cuartelero;
	public System.Int32 id_cuartelero
	{ 
		get 
		{ 
			return _id_cuartelero;
		}
		set 
        { 
			_id_cuartelero = value;
		}
	}

	private System.Int32 _id_compania;
	public System.Int32 id_compania
	{ 
		get 
		{ 
			return _id_compania;
		}
		set 
        { 
			_id_compania = value;
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

	private System.String _tipo_sangre;
	public System.String tipo_sangre
	{ 
		get 
		{ 
			return _tipo_sangre;
		}
		set 
        { 
			_tipo_sangre = value;
		}
	}

	private System.String _alergia;
	public System.String alergia
	{ 
		get 
		{ 
			return _alergia;
		}
		set 
        { 
			_alergia = value;
		}
	}

	private System.String _padece;
	public System.String padece
	{ 
		get 
		{ 
			return _padece;
		}
		set 
        { 
			_padece = value;
		}
	}

	#endregion

	/// <summary>
	/// z_cuarteleros
	/// </summary>
	public z_cuarteleros()
	{
	}


	/// <summary>
	/// z_cuarteleros
	/// </summary>
	public z_cuarteleros(System.Int32 id_cuartelero,System.Int32 id_compania,System.String nombres,System.String apellidos,System.String rut,System.DateTime fecha_nacimiento,System.String telefono,System.String celular,System.String tipo_sangre,System.String alergia,System.String padece)
	{
		this.id_cuartelero = id_cuartelero;
		this.id_compania = id_compania;
		this.nombres = nombres;
		this.apellidos = apellidos;
		this.rut = rut;
		this.fecha_nacimiento = fecha_nacimiento;
		this.telefono = telefono;
		this.celular = celular;
		this.tipo_sangre = tipo_sangre;
		this.alergia = alergia;
		this.padece = padece;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_cuarteleros(z_cuarteleros myz_cuarteleros)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_cuarteleros (id_compania,nombres,apellidos,rut,fecha_nacimiento,telefono,celular,tipo_sangre,alergia,padece) VALUES ("+myz_cuarteleros.id_compania+",'"+myz_cuarteleros.nombres+"','"+myz_cuarteleros.apellidos+"','"+myz_cuarteleros.rut+"','"+myz_cuarteleros.fecha_nacimiento+"','"+myz_cuarteleros.telefono+"','"+myz_cuarteleros.celular+"','"+myz_cuarteleros.tipo_sangre+"','"+myz_cuarteleros.alergia+"','"+myz_cuarteleros.padece+"')";
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
	public void deletez_cuarteleros(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_cuarteleros WHERE (id_cuartelero = "+myID+")",myConn);
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
	public void modifyz_cuarteleros(z_cuarteleros myz_cuarteleros)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_cuarteleros SET id_cuartelero="+myz_cuarteleros.id_cuartelero+",id_compania="+myz_cuarteleros.id_compania+",nombres='"+myz_cuarteleros.nombres+"',apellidos='"+myz_cuarteleros.apellidos+"',rut='"+myz_cuarteleros.rut+"',fecha_nacimiento='"+myz_cuarteleros.fecha_nacimiento+"',telefono='"+myz_cuarteleros.telefono+"',celular='"+myz_cuarteleros.celular+"',tipo_sangre='"+myz_cuarteleros.tipo_sangre+"',alergia='"+myz_cuarteleros.alergia+"',padece='"+myz_cuarteleros.padece+"' WHERE (id_cuartelero="+myz_cuarteleros.id_cuartelero+")";
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
	public z_cuarteleros getObjectz_cuarteleros(System.Int32 myID)
	{
		z_cuarteleros myz_cuarteleros = new z_cuarteleros();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_cuartelero,id_compania,nombres,apellidos,rut,fecha_nacimiento,telefono,celular,tipo_sangre,alergia,padece FROM z_cuarteleros WHERE (id_cuartelero="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_cuarteleros.id_cuartelero = Convert.ToInt32(myReader[0]);
				myz_cuarteleros.id_compania = Convert.ToInt32(myReader[1]);
				myz_cuarteleros.nombres = myReader[2].ToString();
				myz_cuarteleros.apellidos = myReader[3].ToString();
				myz_cuarteleros.rut = myReader[4].ToString();
				myz_cuarteleros.fecha_nacimiento = Convert.ToDateTime(myReader[5]);
				myz_cuarteleros.telefono = myReader[6].ToString();
				myz_cuarteleros.celular = myReader[7].ToString();
				myz_cuarteleros.tipo_sangre = myReader[8].ToString();
				myz_cuarteleros.alergia = myReader[9].ToString();
				myz_cuarteleros.padece = myReader[10].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_cuarteleros;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_cuarteleros()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_cuarteleros";
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
    public DataSet Getz_cuartelerosLista()
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT apellidos||' '||nombres as nombre_completo, id_cuartelero FROM z_cuarteleros";
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
