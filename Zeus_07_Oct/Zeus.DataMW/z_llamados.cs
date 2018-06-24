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
/// z_llamados
/// </summary>
public class z_llamados
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_llamado;
	public System.Int32 id_llamado
	{ 
		get 
		{ 
			return _id_llamado;
		}
		set 
        { 
			_id_llamado = value;
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

	private System.String _clave;
	public System.String clave
	{ 
		get 
		{ 
			return _clave;
		}
		set 
        { 
			_clave = value;
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

    private int _max_b;

    public int max_b
    {
        get { return _max_b; }
        set { _max_b = value; }
    }

    private bool _incendio, _rest_incendio;

    public bool rest_incendio
    {
        get { return _rest_incendio; }
        set { _rest_incendio = value; }
    }

    public bool incendio
    {
        get { return _incendio; }
        set { _incendio = value; }
    }
	#endregion

	/// <summary>
	/// z_llamados
	/// </summary>
	public z_llamados()
	{
	}


	/// <summary>
	/// z_llamados
	/// </summary>
	public z_llamados(System.Int32 id_llamado,System.Int32 codigo_llamado,System.String clave,System.String descripcion)
	{
		this.id_llamado = id_llamado;
		this.codigo_llamado = codigo_llamado;
		this.clave = clave;
		this.descripcion = descripcion;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_llamados(z_llamados myz_llamados)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_llamados (codigo_llamado,clave,descripcion, max_b, incendio, rest_incendio) VALUES ("+myz_llamados.codigo_llamado+",'"+myz_llamados.clave+"','"+myz_llamados.descripcion+"',"+myz_llamados.max_b+","+myz_llamados.incendio+","+myz_llamados.rest_incendio+")";
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
	public void deletez_llamados(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_llamados WHERE (id_llamado = "+myID+")",myConn);
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
	public void modifyz_llamados(z_llamados myz_llamados)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_llamados SET id_llamado="+myz_llamados.id_llamado+",codigo_llamado="+myz_llamados.codigo_llamado+",clave='"+myz_llamados.clave+"',descripcion='"+myz_llamados.descripcion+"' WHERE (id_llamado="+myz_llamados.id_llamado+")";
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
	public z_llamados getObjectz_llamados(System.Int32 myID)
	{
		z_llamados myz_llamados = new z_llamados();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_llamado,codigo_llamado,clave,descripcion, max_b, incendio, rest_incendio FROM z_llamados WHERE (codigo_llamado="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_llamados.id_llamado = Convert.ToInt32(myReader[0]);
				myz_llamados.codigo_llamado = Convert.ToInt32(myReader[1]);
				myz_llamados.clave = myReader[2].ToString();
				myz_llamados.descripcion = myReader[3].ToString();
                myz_llamados.max_b = Convert.ToInt32(myReader[4]);
                myz_llamados.incendio = Convert.ToBoolean(myReader[5]);
                myz_llamados.rest_incendio = Convert.ToBoolean(myReader[6]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_llamados;
	}

    public z_llamados getObjectz_llamados_id(System.Int32 myID)
    {
        z_llamados myz_llamados = new z_llamados();
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT id_llamado,codigo_llamado,clave,descripcion, max_b, incendio, rest_incendio FROM z_llamados WHERE (id_llamado=" + myID + ")";
        try
        {
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
            NpgsqlDataReader myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                myz_llamados.id_llamado = Convert.ToInt32(myReader[0]);
                myz_llamados.codigo_llamado = Convert.ToInt32(myReader[1]);
                myz_llamados.clave = myReader[2].ToString();
                myz_llamados.descripcion = myReader[3].ToString();
                myz_llamados.max_b = Convert.ToInt32(myReader[4]);
                myz_llamados.incendio = Convert.ToBoolean(myReader[5]);
                myz_llamados.rest_incendio = Convert.ToBoolean(myReader[6]);
            }
            myBase.CloseConnection(myConn);
        }
        catch (Exception myErr)
        {
            throw (new Exception(myErr.ToString() + reqSQL));
        }
        return myz_llamados;
    }

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_llamados()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_llamados";
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

    public DataSet Getz_llamados_principal()
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT codigo_llamado, (clave || ' ' || descripcion) as desc,clave FROM z_llamados WHERE codigo_llamado<100 order by codigo_llamado";
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

    public DataSet Getz_llamados_incendio()
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT * FROM z_llamados WHERE incendio=true order by codigo_llamado";
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

    public DataSet Getz_llamados_clave(string clave)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT *, (clave || ' ' || descripcion) as desc FROM z_llamados WHERE clave='" + clave + "' order by codigo_llamado";
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
    public DataSet Getz_llamados_codigo(int codigo_llamado)
    {
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT codigo_llamado, (clave || ' ' || descripcion) as desc FROM z_llamados WHERE codigo_llamado between "+(codigo_llamado*100)+" and "+(codigo_llamado*100+99) +" order by codigo_llamado";
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
