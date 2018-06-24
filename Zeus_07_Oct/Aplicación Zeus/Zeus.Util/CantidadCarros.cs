using System;
using System.Data;
using Zeus.Data;

namespace Zeus.Util
{
    public class CantidadCarros : IComparable
    {
        private int[] _cantidad;
        private int[] _id_tipo;
        private int[] _orden;

        public CantidadCarros()
        {
            var tc = new z_tipo_carro();
            int largo = tc.getCantidad();
            _id_tipo = new int[largo];
            _cantidad = new int[largo];
            _orden = new int[largo];
            DataSet ds = tc.Getz_tipo_carro_despacho();


            for (int i = 0; i < largo; i++)
            {
                _orden[i] = i + 1;
                _id_tipo[i] = (int)ds.Tables[0].Rows[i]["id_tipo_carro"];
            }
        }

        public int[] Id_tipo
        {
            get { return _id_tipo; }
            set { _id_tipo = value; }
        }

        public int[] Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public int[] Orden
        {
            get { return _orden; }
            set { _orden = value; }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            // menor o mayor?? TODOS MENORES, o TODOS MAYORES, sino son iguales
            var cc = obj as CantidadCarros;
            if (cc == null)
            {
                return -1;
            }
            int menor = 0;
            int mayor = 0;
            for (int i = 0; i < Cantidad.Length; i++)
            {
                if (Cantidad[i] <= cc.Cantidad[i])
                {
                    menor++;
                }
                else
                {
                    mayor++;
                }
            }
            if (menor == Cantidad.Length)
            {
                return -1;
            }
            if (mayor == Cantidad.Length)
            {
                return 1;
            }
            return 0;
        }

        #endregion

        public void Ordenar()
        {
            int i;
            for (i = 1; i <= Cantidad.GetLength(0); i++)
            {
                for (int j = Cantidad.GetLength(0) - 1; j >= i; j--)
                {
                    if (Orden[j - 1] > Orden[j])
                    {
                        int AUX = Orden[j - 1];
                        Orden[j - 1] = Orden[j];
                        Orden[j] = AUX;

                        AUX = Cantidad[j - 1];
                        Cantidad[j - 1] = Cantidad[j];
                        Cantidad[j] = AUX;

                        AUX = Id_tipo[j - 1];
                        Id_tipo[j - 1] = Id_tipo[j];
                        Id_tipo[j] = AUX;
                    }
                }
            }
        }

        public int getCantidadOrden(int index)
        {
            return _cantidad[_orden[index] - 1];
        }

        public void setCantidadOrden(int index, int val)
        {
            _cantidad[_orden[index] - 1] = val;
        }

        public static CantidadCarros operator -(CantidadCarros c1, CantidadCarros c2)
        {
            var c = new CantidadCarros();
            for (int i = 0; i < c1.Cantidad.Length; i++)
            {
                c.Cantidad[i] = c1.Cantidad[i] - c2.Cantidad[i];
                if (c.Cantidad[i] < 0)
                {
                    c.Cantidad[i] = 0;
                }
            }
            return c;
        }

        public static bool operator <(CantidadCarros c1, CantidadCarros c2)
        {
            int menor = 0;
            for (int i = 0; i < c1.Cantidad.Length; i++)
            {
                if (c1.Cantidad[i] < c2.Cantidad[i])
                {
                    menor++;
                }
            }
            if (menor == c1.Cantidad.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(CantidadCarros c1, CantidadCarros c2)
        {
            int menor = 0;
            for (int i = 0; i < c1.Cantidad.Length; i++)
            {
                if (c1.Cantidad[i] > c2.Cantidad[i])
                {
                    menor++;
                }
            }
            if (menor == c1.Cantidad.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(CantidadCarros c1, CantidadCarros c2)
        {
            int mayor = 0;
            for (int i = 0; i < c1.Cantidad.Length; i++)
            {
                if (c1.Cantidad[i] >= c2.Cantidad[i])
                {
                    mayor++;
                }
            }
            if (mayor == c1.Cantidad.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(CantidadCarros c1, CantidadCarros c2)
        {
            int mayor = 0;
            for (int i = 0; i < c1.Cantidad.Length; i++)
            {
                if (c1.Cantidad[i] <= c2.Cantidad[i])
                {
                    mayor++;
                }
            }
            if (mayor == c1.Cantidad.Length)
            {
                return true;
            }
            return false;
        }
    }
}