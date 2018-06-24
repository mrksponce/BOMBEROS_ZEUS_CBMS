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

namespace Zeus.Data
{
/// <summary>
/// a_comisaria
/// </summary>
public class a_comisaria
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _gid;
	public System.Int32 gid
	{ 
		get 
		{ 
			return _gid;
		}
		set 
        { 
			_gid = value;
		}
	}

	private System.Int64 _sgc1;
	public System.Int64 sgc1
	{ 
		get 
		{ 
			return _sgc1;
		}
		set 
        { 
			_sgc1 = value;
		}
	}

	private System.String _sgc2;
	public System.String sgc2
	{ 
		get 
		{ 
			return _sgc2;
		}
		set 
        { 
			_sgc2 = value;
		}
	}

	private System.String _the_geom;
	public System.String the_geom
	{ 
		get 
		{ 
			return _the_geom;
		}
		set 
        { 
			_the_geom = value;
		}
	}

    private int _id_empresa;

    public int id_empresa
    {
        get { return _id_empresa; }
        set { _id_empresa = value; }
    }

	#endregion

	/// <summary>
	/// a_comisaria
	/// </summary>
	public a_comisaria()
	{
	}


	/// <summary>
	/// a_comisaria
	/// </summary>
	public a_comisaria(System.Int32 gid,System.Int64 sgc1,System.String sgc2,System.String the_geom)
	{
		this.gid = gid;
		this.sgc1 = sgc1;
		this.sgc2 = sgc2;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	 //Not primary key detected on the corresponding table. Methods add/modify & remove could not be created. 

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Geta_comisaria()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM a_comisaria";
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
