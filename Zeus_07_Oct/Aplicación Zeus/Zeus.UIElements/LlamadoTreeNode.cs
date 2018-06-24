using System;
using System.Collections;
using System.Windows.Forms;
using Zeus.Interfaces;

namespace Zeus.UIElements
{
    internal class LlamadoTreeNode : TreeNode
    {
        public LlamadoTreeNode()
        {
        }

        public LlamadoTreeNode(string text)
            : base(text)
        {
            Name = text;
        }

        public int NodeId { get; set; }

        public TipoElemento NodeType { get; set; }

        public DateTime Fecha { get; set; }

        public long NodeOrder { get; set; }
    }

    internal class ZNodeSorter : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            var tx = (LlamadoTreeNode)x;
            var ty = (LlamadoTreeNode)y;
            if (tx.NodeType == TipoElemento.Carro && ty.NodeType == TipoElemento.Carro)
            {
                return (int) (tx.NodeOrder - ty.NodeOrder);
            }
            return DateTime.Compare(ty.Fecha, tx.Fecha);
        }

        #endregion
    }
}