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
/// p_interes
/// </summary>
public class p_interes
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_puntos;
	public System.Int32 id_puntos
	{ 
		get 
		{ 
			return _id_puntos;
		}
		set 
        { 
			_id_puntos = value;
		}
	}

	private System.String _radio_text;
	public System.String radio_text
	{ 
		get 
		{ 
			return _radio_text;
		}
		set 
        { 
			_radio_text = value;
		}
	}

	private System.String _label1;
	public System.String label1
	{ 
		get 
		{ 
			return _label1;
		}
		set 
        { 
			_label1 = value;
		}
	}

	private System.String _combo1;
	public System.String combo1
	{ 
		get 
		{ 
			return _combo1;
		}
		set 
        { 
			_combo1 = value;
		}
	}

	private System.String _label2;
	public System.String label2
	{ 
		get 
		{ 
			return _label2;
		}
		set 
        { 
			_label2 = value;
		}
	}

	private System.String _tabla;
	public System.String tabla
	{ 
		get 
		{ 
			return _tabla;
		}
		set 
        { 
			_tabla = value;
		}
	}

	#endregion

	/// <summary>
	/// p_interes
	/// </summary>
	public p_interes()
	{
	}


	/// <summary>
	/// p_interes
	/// </summary>
	public p_interes(System.Int32 id_puntos,System.String radio_text,System.String label1,System.String combo1,System.String label2,System.String tabla)
	{
		this.id_puntos = id_puntos;
		this.radio_text = radio_text;
		this.label1 = label1;
		this.combo1 = combo1;
		this.label2 = label2;
		this.tabla = tabla;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void Insert(p_interes myp_interes)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO p_interes (id_puntos,radio_text,label1,combo1,label2,tabla) VALUES ("+myp_interes.id_puntos+",'"+myp_interes.radio_text+"','"+myp_interes.label1+"','"+myp_interes.combo1+"','"+myp_interes.label2+"','"+myp_interes.tabla+"')";
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
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM p_interes WHERE (id_puntos = "+myID+")",myConn);
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
	public void Update(p_interes myp_interes)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE p_interes SET id_puntos="+myp_interes.id_puntos+",radio_text='"+myp_interes.radio_text+"',label1='"+myp_interes.label1+"',combo1='"+myp_interes.combo1+"',label2='"+myp_interes.label2+"',tabla='"+myp_interes.tabla+"' WHERE (id_puntos="+myp_interes.id_puntos+")";
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
	public p_interes getObjectp_interes(System.Int32 myID)
	{
		p_interes myp_interes = new p_interes();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_puntos,radio_text,label1,combo1,label2,tabla FROM p_interes WHERE (id_puntos="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myp_interes.id_puntos = Convert.ToInt32(myReader[0]);
				myp_interes.radio_text = myReader[1].ToString();
				myp_interes.label1 = myReader[2].ToString();
				myp_interes.combo1 = myReader[3].ToString();
				myp_interes.label2 = myReader[4].ToString();
				myp_interes.tabla = myReader[5].ToString();
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myp_interes;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getp_interes()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM p_interes";
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
