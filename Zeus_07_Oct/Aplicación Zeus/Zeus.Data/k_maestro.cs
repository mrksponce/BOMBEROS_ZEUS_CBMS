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
/// k_maestro
/// </summary>
public class k_maestro
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _count;
	public System.Int32 count
	{ 
		get 
		{ 
			return _count;
		}
		set 
        { 
			_count = value;
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

	private System.String _nomxcom;
	public System.String nomxcom
	{ 
		get 
		{ 
			return _nomxcom;
		}
		set 
        { 
			_nomxcom = value;
		}
	}

	#endregion

	/// <summary>
	/// k_maestro
	/// </summary>
	public k_maestro()
	{
	}


	/// <summary>
	/// k_maestro
	/// </summary>
	public k_maestro(System.Int32 count,System.String nombre,System.String comuna,System.String nomxcom)
	{
		this.count = count;
		this.nombre = nombre;
		this.comuna = comuna;
		this.nomxcom = nomxcom;
	}

	#region *****persistance managing methods

	 //Not primary key detected on the corresponding table. Methods add/modify & remove could not be created. 

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getk_maestro()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM k_maestro";
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
