using System;
using System.Data;
using Npgsql;

namespace Zeus.Data
{
    public class x_grupo_alias
    {
        #region ***** Campos y propiedades *****

        public Int32 id_grupo { get; set; }

        public Int32 alias { get; set; }

        public string carros_grupo { get; set; }



        #endregion

        /// <summary>
        /// x_grupo_alias
        /// </summary>
        public x_grupo_alias()
        {
        }


        /// <summary>
        /// x_grupo_alias
        /// </summary>
        public x_grupo_alias(Int32 id_grupo, Int32 alias)
        {
            this.id_grupo = id_grupo;
            this.alias = alias;
        }



        public int GetAliasGrupo(string IdGrupo)
        {
            x_grupo_alias myx_grupo_alias = new x_grupo_alias();
            CnxBase myBase = new CnxBase();
            int GrpReturn = 0;
            string reqSQL = "SELECT alias FROM x_grupo_alias WHERE id_grupo = " + IdGrupo;
            try
            {
                NpgsqlConnection myConn = myBase.OpenConnection(myBase.cnxString);
                NpgsqlCommand myCommand = new NpgsqlCommand(reqSQL, myConn);
                GrpReturn = Convert.ToInt32(myCommand.ExecuteScalar());

                myBase.CloseConnection(myConn);
            }
            catch (Exception myErr)
            {
                throw (new Exception(myErr.ToString() + reqSQL));
            }
            return GrpReturn;
        }

    }
}
