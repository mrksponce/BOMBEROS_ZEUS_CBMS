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
/// k_comuna
/// </summary>
public class k_comuna
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

	private System.Int32 _id;
	public System.Int32 id
	{ 
		get 
		{ 
			return _id;
		}
		set 
        { 
			_id = value;
		}
	}

	private System.String _etiqueta;
	public System.String etiqueta
	{ 
		get 
		{ 
			return _etiqueta;
		}
		set 
        { 
			_etiqueta = value;
		}
	}

	private System.String _provinc;
	public System.String provinc
	{ 
		get 
		{ 
			return _provinc;
		}
		set 
        { 
			_provinc = value;
		}
	}

	private System.Int64 _cod_ine;
	public System.Int64 cod_ine
	{ 
		get 
		{ 
			return _cod_ine;
		}
		set 
        { 
			_cod_ine = value;
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

	#endregion

	/// <summary>
	/// k_comuna
	/// </summary>
	public k_comuna()
	{
	}


	/// <summary>
	/// k_comuna
	/// </summary>
	public k_comuna(System.Int32 gid,System.String comuna,System.Int32 id,System.String etiqueta,System.String provinc,System.Int64 cod_ine,System.String the_geom)
	{
		this.gid = gid;
		this.comuna = comuna;
		this.id = id;
		this.etiqueta = etiqueta;
		this.provinc = provinc;
		this.cod_ine = cod_ine;
		this.the_geom = the_geom;
	}

	#region *****persistance managing methods

	 //Not primary key detected on the corresponding table. Methods add/modify & remove could not be created. 

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getk_comuna()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM k_comuna";
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
