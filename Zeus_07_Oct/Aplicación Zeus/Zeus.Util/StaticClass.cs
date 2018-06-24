using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Zeus.Util
{
    public static class StaticClass
    {
        private static ArrayList arrGrupoCarros = new ArrayList();

        public static ArrayList ArrGrupoCarros
        {
            get { return StaticClass.arrGrupoCarros; }
            set { StaticClass.arrGrupoCarros = value; }
        }

         
    }
}
