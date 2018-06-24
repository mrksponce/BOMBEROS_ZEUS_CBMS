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
/// z_ficha_medica
/// </summary>
public class z_ficha_medica
{

	#region ***** Campos y propiedades ***** 

	private System.Int32 _id_voluntario;
	public System.Int32 id_voluntario
	{ 
		get 
		{ 
			return _id_voluntario;
		}
		set 
        { 
			_id_voluntario = value;
		}
	}

	private System.String _grupo_sanguineo;
	public System.String grupo_sanguineo
	{ 
		get 
		{ 
			return _grupo_sanguineo;
		}
		set 
        { 
			_grupo_sanguineo = value;
		}
	}

	private System.String _factor_rh;
	public System.String factor_rh
	{ 
		get 
		{ 
			return _factor_rh;
		}
		set 
        { 
			_factor_rh = value;
		}
	}

	private System.Boolean _rubeola;
	public System.Boolean rubeola
	{ 
		get 
		{ 
			return _rubeola;
		}
		set 
        { 
			_rubeola = value;
		}
	}

	private System.Boolean _bronquitis;
	public System.Boolean bronquitis
	{ 
		get 
		{ 
			return _bronquitis;
		}
		set 
        { 
			_bronquitis = value;
		}
	}

	private System.Boolean _epilepsia;
	public System.Boolean epilepsia
	{ 
		get 
		{ 
			return _epilepsia;
		}
		set 
        { 
			_epilepsia = value;
		}
	}

	private System.Boolean _epistaxis;
	public System.Boolean epistaxis
	{ 
		get 
		{ 
			return _epistaxis;
		}
		set 
        { 
			_epistaxis = value;
		}
	}

	private System.Boolean _anginas;
	public System.Boolean anginas
	{ 
		get 
		{ 
			return _anginas;
		}
		set 
        { 
			_anginas = value;
		}
	}

	private System.Boolean _poliomielitis;
	public System.Boolean poliomielitis
	{ 
		get 
		{ 
			return _poliomielitis;
		}
		set 
        { 
			_poliomielitis = value;
		}
	}

	private System.Boolean _convulsiones;
	public System.Boolean convulsiones
	{ 
		get 
		{ 
			return _convulsiones;
		}
		set 
        { 
			_convulsiones = value;
		}
	}

	private System.Boolean _urinarias;
	public System.Boolean urinarias
	{ 
		get 
		{ 
			return _urinarias;
		}
		set 
        { 
			_urinarias = value;
		}
	}

	private System.Boolean _asma;
	public System.Boolean asma
	{ 
		get 
		{ 
			return _asma;
		}
		set 
        { 
			_asma = value;
		}
	}

	private System.Boolean _varicela;
	public System.Boolean varicela
	{ 
		get 
		{ 
			return _varicela;
		}
		set 
        { 
			_varicela = value;
		}
	}

	private System.Boolean _otitis;
	public System.Boolean otitis
	{ 
		get 
		{ 
			return _otitis;
		}
		set 
        { 
			_otitis = value;
		}
	}

	private System.Boolean _colecistitis;
	public System.Boolean colecistitis
	{ 
		get 
		{ 
			return _colecistitis;
		}
		set 
        { 
			_colecistitis = value;
		}
	}

	private System.Boolean _sarampion;
	public System.Boolean sarampion
	{ 
		get 
		{ 
			return _sarampion;
		}
		set 
        { 
			_sarampion = value;
		}
	}

	private System.Boolean _diabetes;
	public System.Boolean diabetes
	{ 
		get 
		{ 
			return _diabetes;
		}
		set 
        { 
			_diabetes = value;
		}
	}

	private System.Boolean _hepatitis;
	public System.Boolean hepatitis
	{ 
		get 
		{ 
			return _hepatitis;
		}
		set 
        { 
			_hepatitis = value;
		}
	}

	private System.Boolean _amigadalas;
	public System.Boolean amigadalas
	{ 
		get 
		{ 
			return _amigadalas;
		}
		set 
        { 
			_amigadalas = value;
		}
	}

	private System.Boolean _hernias;
	public System.Boolean hernias
	{ 
		get 
		{ 
			return _hernias;
		}
		set 
        { 
			_hernias = value;
		}
	}

	private System.Boolean _apendicitis;
	public System.Boolean apendicitis
	{ 
		get 
		{ 
			return _apendicitis;
		}
		set 
        { 
			_apendicitis = value;
		}
	}

	private System.Boolean _otras;
	public System.Boolean otras
	{ 
		get 
		{ 
			return _otras;
		}
		set 
        { 
			_otras = value;
		}
	}

	private System.DateTime _fecha_amigdalas;
	public System.DateTime fecha_amigdalas
	{ 
		get 
		{ 
			return _fecha_amigdalas;
		}
		set 
        { 
			_fecha_amigdalas = value;
		}
	}

	private System.DateTime _fecha_hernias;
	public System.DateTime fecha_hernias
	{ 
		get 
		{ 
			return _fecha_hernias;
		}
		set 
        { 
			_fecha_hernias = value;
		}
	}

	private System.DateTime _fecha_apendicitis;
	public System.DateTime fecha_apendicitis
	{ 
		get 
		{ 
			return _fecha_apendicitis;
		}
		set 
        { 
			_fecha_apendicitis = value;
		}
	}

	private System.DateTime _fecha_otras;
	public System.DateTime fecha_otras
	{ 
		get 
		{ 
			return _fecha_otras;
		}
		set 
        { 
			_fecha_otras = value;
		}
	}

	private System.String _diagnostico;
	public System.String diagnostico
	{ 
		get 
		{ 
			return _diagnostico;
		}
		set 
        { 
			_diagnostico = value;
		}
	}

	private System.String _tratamiento;
	public System.String tratamiento
	{ 
		get 
		{ 
			return _tratamiento;
		}
		set 
        { 
			_tratamiento = value;
		}
	}

	private System.String _medicamentos;
	public System.String medicamentos
	{ 
		get 
		{ 
			return _medicamentos;
		}
		set 
        { 
			_medicamentos = value;
		}
	}

	private System.String _dosis;
	public System.String dosis
	{ 
		get 
		{ 
			return _dosis;
		}
		set 
        { 
			_dosis = value;
		}
	}

	private System.String _duracion;
	public System.String duracion
	{ 
		get 
		{ 
			return _duracion;
		}
		set 
        { 
			_duracion = value;
		}
	}

	private System.String _alergia_medicamentos;
	public System.String alergia_medicamentos
	{ 
		get 
		{ 
			return _alergia_medicamentos;
		}
		set 
        { 
			_alergia_medicamentos = value;
		}
	}

	private System.Boolean _alergia_penicilina;
	public System.Boolean alergia_penicilina
	{ 
		get 
		{ 
			return _alergia_penicilina;
		}
		set 
        { 
			_alergia_penicilina = value;
		}
	}

	private System.String _alergia_alimentos;
	public System.String alergia_alimentos
	{ 
		get 
		{ 
			return _alergia_alimentos;
		}
		set 
        { 
			_alergia_alimentos = value;
		}
	}

	private System.Boolean _alergia_picadura;
	public System.Boolean alergia_picadura
	{ 
		get 
		{ 
			return _alergia_picadura;
		}
		set 
        { 
			_alergia_picadura = value;
		}
	}

	#endregion

	/// <summary>
	/// z_ficha_medica
	/// </summary>
	public z_ficha_medica()
	{
	}


	/// <summary>
	/// z_ficha_medica
	/// </summary>
	public z_ficha_medica(System.Int32 id_voluntario,System.String grupo_sanguineo,System.String factor_rh,System.Boolean rubeola,System.Boolean bronquitis,System.Boolean epilepsia,System.Boolean epistaxis,System.Boolean anginas,System.Boolean poliomielitis,System.Boolean convulsiones,System.Boolean urinarias,System.Boolean asma,System.Boolean varicela,System.Boolean otitis,System.Boolean colecistitis,System.Boolean sarampion,System.Boolean diabetes,System.Boolean hepatitis,System.Boolean amigadalas,System.Boolean hernias,System.Boolean apendicitis,System.Boolean otras,System.DateTime fecha_amigdalas,System.DateTime fecha_hernias,System.DateTime fecha_apendicitis,System.DateTime fecha_otras,System.String diagnostico,System.String tratamiento,System.String medicamentos,System.String dosis,System.String duracion,System.String alergia_medicamentos,System.Boolean alergia_penicilina,System.String alergia_alimentos,System.Boolean alergia_picadura)
	{
		this.id_voluntario = id_voluntario;
		this.grupo_sanguineo = grupo_sanguineo;
		this.factor_rh = factor_rh;
		this.rubeola = rubeola;
		this.bronquitis = bronquitis;
		this.epilepsia = epilepsia;
		this.epistaxis = epistaxis;
		this.anginas = anginas;
		this.poliomielitis = poliomielitis;
		this.convulsiones = convulsiones;
		this.urinarias = urinarias;
		this.asma = asma;
		this.varicela = varicela;
		this.otitis = otitis;
		this.colecistitis = colecistitis;
		this.sarampion = sarampion;
		this.diabetes = diabetes;
		this.hepatitis = hepatitis;
		this.amigadalas = amigadalas;
		this.hernias = hernias;
		this.apendicitis = apendicitis;
		this.otras = otras;
		this.fecha_amigdalas = fecha_amigdalas;
		this.fecha_hernias = fecha_hernias;
		this.fecha_apendicitis = fecha_apendicitis;
		this.fecha_otras = fecha_otras;
		this.diagnostico = diagnostico;
		this.tratamiento = tratamiento;
		this.medicamentos = medicamentos;
		this.dosis = dosis;
		this.duracion = duracion;
		this.alergia_medicamentos = alergia_medicamentos;
		this.alergia_penicilina = alergia_penicilina;
		this.alergia_alimentos = alergia_alimentos;
		this.alergia_picadura = alergia_picadura;
	}

	#region *****persistance managing methods

	/// <summary>
	/// add a record
	/// </summary>
	/// <param name="myID"></param>
	public void addz_ficha_medica(z_ficha_medica myz_ficha_medica)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "INSERT INTO z_ficha_medica (id_voluntario,grupo_sanguineo,factor_rh,rubeola,bronquitis,epilepsia,epistaxis,anginas,poliomielitis,convulsiones,urinarias,asma,varicela,otitis,colecistitis,sarampion,diabetes,hepatitis,amigadalas,hernias,apendicitis,otras,fecha_amigdalas,fecha_hernias,fecha_apendicitis,fecha_otras,diagnostico,tratamiento,medicamentos,dosis,duracion,alergia_medicamentos,alergia_penicilina,alergia_alimentos,alergia_picadura) VALUES ("+myz_ficha_medica.id_voluntario+",'"+myz_ficha_medica.grupo_sanguineo+"','"+myz_ficha_medica.factor_rh+"',"+myz_ficha_medica.rubeola+","+myz_ficha_medica.bronquitis+","+myz_ficha_medica.epilepsia+","+myz_ficha_medica.epistaxis+","+myz_ficha_medica.anginas+","+myz_ficha_medica.poliomielitis+","+myz_ficha_medica.convulsiones+","+myz_ficha_medica.urinarias+","+myz_ficha_medica.asma+","+myz_ficha_medica.varicela+","+myz_ficha_medica.otitis+","+myz_ficha_medica.colecistitis+","+myz_ficha_medica.sarampion+","+myz_ficha_medica.diabetes+","+myz_ficha_medica.hepatitis+","+myz_ficha_medica.amigadalas+","+myz_ficha_medica.hernias+","+myz_ficha_medica.apendicitis+","+myz_ficha_medica.otras+",'"+myz_ficha_medica.fecha_amigdalas+"','"+myz_ficha_medica.fecha_hernias+"','"+myz_ficha_medica.fecha_apendicitis+"','"+myz_ficha_medica.fecha_otras+"','"+myz_ficha_medica.diagnostico+"','"+myz_ficha_medica.tratamiento+"','"+myz_ficha_medica.medicamentos+"','"+myz_ficha_medica.dosis+"','"+myz_ficha_medica.duracion+"','"+myz_ficha_medica.alergia_medicamentos+"',"+myz_ficha_medica.alergia_penicilina+",'"+myz_ficha_medica.alergia_alimentos+"',"+myz_ficha_medica.alergia_picadura+")";
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
	public void deletez_ficha_medica(int myID)
	{
		CnxBase myBase = new CnxBase();
			try
			{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand("DELETE FROM z_ficha_medica WHERE (id_voluntario = "+myID+")",myConn);
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
	public void modifyz_ficha_medica(z_ficha_medica myz_ficha_medica)
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "UPDATE z_ficha_medica SET id_voluntario="+myz_ficha_medica.id_voluntario+",grupo_sanguineo='"+myz_ficha_medica.grupo_sanguineo+"',factor_rh='"+myz_ficha_medica.factor_rh+"',rubeola="+myz_ficha_medica.rubeola+",bronquitis="+myz_ficha_medica.bronquitis+",epilepsia="+myz_ficha_medica.epilepsia+",epistaxis="+myz_ficha_medica.epistaxis+",anginas="+myz_ficha_medica.anginas+",poliomielitis="+myz_ficha_medica.poliomielitis+",convulsiones="+myz_ficha_medica.convulsiones+",urinarias="+myz_ficha_medica.urinarias+",asma="+myz_ficha_medica.asma+",varicela="+myz_ficha_medica.varicela+",otitis="+myz_ficha_medica.otitis+",colecistitis="+myz_ficha_medica.colecistitis+",sarampion="+myz_ficha_medica.sarampion+",diabetes="+myz_ficha_medica.diabetes+",hepatitis="+myz_ficha_medica.hepatitis+",amigadalas="+myz_ficha_medica.amigadalas+",hernias="+myz_ficha_medica.hernias+",apendicitis="+myz_ficha_medica.apendicitis+",otras="+myz_ficha_medica.otras+",fecha_amigdalas='"+myz_ficha_medica.fecha_amigdalas+"',fecha_hernias='"+myz_ficha_medica.fecha_hernias+"',fecha_apendicitis='"+myz_ficha_medica.fecha_apendicitis+"',fecha_otras='"+myz_ficha_medica.fecha_otras+"',diagnostico='"+myz_ficha_medica.diagnostico+"',tratamiento='"+myz_ficha_medica.tratamiento+"',medicamentos='"+myz_ficha_medica.medicamentos+"',dosis='"+myz_ficha_medica.dosis+"',duracion='"+myz_ficha_medica.duracion+"',alergia_medicamentos='"+myz_ficha_medica.alergia_medicamentos+"',alergia_penicilina="+myz_ficha_medica.alergia_penicilina+",alergia_alimentos='"+myz_ficha_medica.alergia_alimentos+"',alergia_picadura="+myz_ficha_medica.alergia_picadura+" WHERE (id_voluntario="+myz_ficha_medica.id_voluntario+")";
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
	public z_ficha_medica getObjectz_ficha_medica(System.Int32 myID)
	{
		z_ficha_medica myz_ficha_medica = new z_ficha_medica();
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT id_voluntario,grupo_sanguineo,factor_rh,rubeola,bronquitis,epilepsia,epistaxis,anginas,poliomielitis,convulsiones,urinarias,asma,varicela,otitis,colecistitis,sarampion,diabetes,hepatitis,amigadalas,hernias,apendicitis,otras,fecha_amigdalas,fecha_hernias,fecha_apendicitis,fecha_otras,diagnostico,tratamiento,medicamentos,dosis,duracion,alergia_medicamentos,alergia_penicilina,alergia_alimentos,alergia_picadura FROM z_ficha_medica WHERE (id_voluntario="+myID+")";
		try
		{
				NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
				NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL,myConn);
			NpgsqlDataReader myReader = myCommand.ExecuteReader();
			if(myReader.Read())
			{
				myz_ficha_medica.id_voluntario = Convert.ToInt32(myReader[0]);
				myz_ficha_medica.grupo_sanguineo = myReader[1].ToString();
				myz_ficha_medica.factor_rh = myReader[2].ToString();
				myz_ficha_medica.rubeola = Convert.ToBoolean(myReader[3]);
				myz_ficha_medica.bronquitis = Convert.ToBoolean(myReader[4]);
				myz_ficha_medica.epilepsia = Convert.ToBoolean(myReader[5]);
				myz_ficha_medica.epistaxis = Convert.ToBoolean(myReader[6]);
				myz_ficha_medica.anginas = Convert.ToBoolean(myReader[7]);
				myz_ficha_medica.poliomielitis = Convert.ToBoolean(myReader[8]);
				myz_ficha_medica.convulsiones = Convert.ToBoolean(myReader[9]);
				myz_ficha_medica.urinarias = Convert.ToBoolean(myReader[10]);
				myz_ficha_medica.asma = Convert.ToBoolean(myReader[11]);
				myz_ficha_medica.varicela = Convert.ToBoolean(myReader[12]);
				myz_ficha_medica.otitis = Convert.ToBoolean(myReader[13]);
				myz_ficha_medica.colecistitis = Convert.ToBoolean(myReader[14]);
				myz_ficha_medica.sarampion = Convert.ToBoolean(myReader[15]);
				myz_ficha_medica.diabetes = Convert.ToBoolean(myReader[16]);
				myz_ficha_medica.hepatitis = Convert.ToBoolean(myReader[17]);
				myz_ficha_medica.amigadalas = Convert.ToBoolean(myReader[18]);
				myz_ficha_medica.hernias = Convert.ToBoolean(myReader[19]);
				myz_ficha_medica.apendicitis = Convert.ToBoolean(myReader[20]);
				myz_ficha_medica.otras = Convert.ToBoolean(myReader[21]);
				myz_ficha_medica.fecha_amigdalas = Convert.ToDateTime(myReader[22]);
				myz_ficha_medica.fecha_hernias = Convert.ToDateTime(myReader[23]);
				myz_ficha_medica.fecha_apendicitis = Convert.ToDateTime(myReader[24]);
				myz_ficha_medica.fecha_otras = Convert.ToDateTime(myReader[25]);
				myz_ficha_medica.diagnostico = myReader[26].ToString();
				myz_ficha_medica.tratamiento = myReader[27].ToString();
				myz_ficha_medica.medicamentos = myReader[28].ToString();
				myz_ficha_medica.dosis = myReader[29].ToString();
				myz_ficha_medica.duracion = myReader[30].ToString();
				myz_ficha_medica.alergia_medicamentos = myReader[31].ToString();
				myz_ficha_medica.alergia_penicilina = Convert.ToBoolean(myReader[32]);
				myz_ficha_medica.alergia_alimentos = myReader[33].ToString();
				myz_ficha_medica.alergia_picadura = Convert.ToBoolean(myReader[34]);
			}
		myBase.CloseConnection(myConn);
		}
	catch(Exception myErr)
	{
		throw(new Exception(myErr.ToString() + reqSQL));
	}
	return myz_ficha_medica;
	}

	/// <summary>
	/// get a DataSet from records
	/// </summary>
	public DataSet Getz_ficha_medica()
	{
		CnxBase myBase = new CnxBase();
		string reqSQL = "SELECT * FROM z_ficha_medica";
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
