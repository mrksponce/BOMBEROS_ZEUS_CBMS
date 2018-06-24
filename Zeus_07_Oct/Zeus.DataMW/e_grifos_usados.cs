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
/// e_grifos_usados
/// </summary>
public class e_grifos_usados
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

	private System.Int32 _id_expediente;
	public System.Int32 id_expediente
	{ 
		get 
		{ 
			return _id_expediente;
		}
		set 
        { 
			_id_expediente = value;
		}
	}

	private System.Boolean _estado;
	public System.Boolean estado
	{ 
		get 
		{ 
			return _estado;
		}
		set 
        { 
			_estado = value;
		}
	}

	#endregion

	/// <summary>
	/// e_grifos_usados
	/// </summary>
	public e_grifos_usados()
	{
	}


	/// <summary>
	/// e_grifos_usados
	/// </summary>
	public e_grifos_usados(System.Int32 gid,System.Int32 id_expediente,System.Boolean estado)
	{
		this.gid = gid;
		this.id_expediente = id_expediente;
		this.estado = estado;
	}

	#region *****persistance managing methods

	 //Not primary key detected on the corresponding table. Methods add/modify & remove could not be created. 

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Gete_grifos_usados()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM e_grifos_usados";
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
