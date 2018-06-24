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
using System.Collections.Generic;

namespace Zeus.Data
{
/// <summary>
/// z_companias
/// </summary>
public class z_companias
{

	#region ***** Campos y propiedades ***** 

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

	private System.String _email;
	public System.String email
	{ 
		get 
		{ 
			return _email;
		}
		set 
        { 
			_email = value;
		}
	}

	#endregion

	/// <summary>
	/// z_companias
	/// </summary>
	public z_companias()
	{
	}


	/// <summary>
	/// z_companias
	/// </summary>
	public z_companias(System.Int32 id_compania,System.String email)
	{
		this.id_compania = id_compania;
		this.email = email;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_companias(z_companias myz_companias)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_companias (id_compania,email) VALUES ("+myz_companias.id_compania+",'"+myz_companias.email+"')";
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
	public void deletez_companias(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_companias WHERE (id_compania = "+myID+")",myConn);
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
	public void modifyz_companias(z_companias myz_companias)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_companias SET id_compania="+myz_companias.id_compania+",email='"+myz_companias.email+"' WHERE (id_compania="+myz_companias.id_compania+")";
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
	public z_companias getObjectz_companias(System.Int32 myID)
	{
		z_companias myz_companias = new z_companias();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_compania,email FROM z_companias WHERE (id_compania="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_companias.id_compania = Convert.ToInt32(myReader[0]);
				myz_companias.email = myReader[1].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_companias;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_companias()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_companias order by id_compania";
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

    public string get_CompaniaCarroConsulta(int id_carro)
    {
        CnxBase myBase = new CnxBase();
        string SQL = "SELECT zco.nombre_compania FROM z_carros zca left join z_companias zco on zca.id_compania_orig = zco.id_compania where zca.id_carro = " + id_carro;
        try
        {
            string nombre = "";
            DataSet ds_ds = new DataSet();
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            NpgsqlDataAdapter da_da = new NpgsqlDataAdapter(SQL, myConn);
            da_da.Fill(ds_ds);
            foreach (DataRow rs_rs in ds_ds.Tables[0].Rows)
            {
                nombre = rs_rs["nombre_compania"].ToString();
            }
            return nombre;
        }
        catch (Exception myErr)
        {
            throw (new Exception(myErr.ToString() + SQL));
        }
    }

    public string[] get_ListaCarrosCompania()
    {
        string[] lista;
        CnxBase myBase = new CnxBase();
        string SQL = "SELECT nombre_compania FROM z_companias order by nombre_compania";
        try
        {
            string nombre = "";
            int i = 0;
            DataSet ds_ncompania = new DataSet();
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            NpgsqlDataAdapter da_da = new NpgsqlDataAdapter(SQL, myConn);
            da_da.Fill(ds_ncompania);
            lista = new string[ds_ncompania.Tables[0].Rows.Count];
            foreach (DataRow rs_rs in ds_ncompania.Tables[0].Rows)
            {
                lista[i] = rs_rs["nombre_compania"].ToString();
                i++;
            }
            return lista;
        }
        catch (Exception myErr)
        {
            throw (new Exception(myErr.ToString() + SQL));
        }
    }



    //### Nuevo Código
    public string ObtenerCompaniaPorCoordenada(int comp_x, int comp_y)
    {
        CnxBase myBase = new CnxBase();
        string nombreCompania = "";
        string reqSQL = "SELECT nombre_compania FROM z_companias WHERE compania_x = " + comp_x + " and compania_y = " + comp_y;
        try
        {
            CnxBase myD4MCnx = new CnxBase();
            DataSet myResult = myD4MCnx.GetDataSet(reqSQL);
            foreach (DataRow row in myResult.Tables[0].Rows)
            {
                nombreCompania = row["nombre_compania"].ToString();
            }

            return nombreCompania;
        }
        catch (Exception myErr)
        {
            throw (new Exception(myErr.ToString() + reqSQL));
        }
    }

   



	#endregion


}
 
 
 }
