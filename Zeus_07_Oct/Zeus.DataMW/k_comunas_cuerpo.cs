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
using System.Collections.Generic;
using Npgsql;

namespace Zeus.Data
{
/// <summary>
/// k_comunas_cuerpo
/// </summary>
public class k_comunas_cuerpo
{

	#region ***** Campos y propiedades ***** 

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

	#endregion

	/// <summary>
	/// k_comunas_cuerpo
	/// </summary>
	public k_comunas_cuerpo()
	{
	}


	/// <summary>
	/// k_comunas_cuerpo
	/// </summary>
	public k_comunas_cuerpo(System.String comuna)
	{
		this.comuna = comuna;
	}

	#region *****persistance managing methods

	 //Not primary key detected on the corresponding table. Methods add/modify & remove could not be created. 

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getk_comunas_cuerpo()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM k_comunas_cuerpo";
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

    public List<int> GetIDs()
    {
        List<int> ids = new List<int>();
        CnxBase myBase = new CnxBase();
        string reqSQL = "SELECT id FROM k_comunas_cuerpo";
        try
        {
            NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
            NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
            NpgsqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                ids.Add(Convert.ToInt32(myReader[0]));
            }
        }
        catch (Exception myErr)
        {
            throw (new Exception(myErr.ToString() + reqSQL));
        }
        return ids;
    }

	#endregion


}
 
 
 }
