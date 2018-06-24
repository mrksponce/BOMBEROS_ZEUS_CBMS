using System.Text;
using System.Windows.Forms;

namespace Zeus.Util
{
    public class ToolStripHelper
    {
        public static string GetItemOrder(ToolStrip toolStrip)
        {
            var builder = new StringBuilder(toolStrip.Items.Count);
            for (int i = 0; i < toolStrip.Items.Count; i++)
            {
                builder.Append(toolStrip.Items[i].Name ?? "null");
                if (i != (toolStrip.Items.Count - 1))
                {
                    builder.Append(",");
                }
            }
            return builder.ToString();
        }

        public static void SetItemOrder(ToolStrip toolStrip, string ItemOrder)
        {
            try
            {
                string[] str = ItemOrder.Split(',');
                for (int i = 0; (i < toolStrip.Items.Count) && (i < str.Length); i++)
                {
                    // buscar y reordenar
                    if (toolStrip.Items.ContainsKey(str[i]))
                    {
                        if (toolStrip.Items.IndexOfKey(str[i]) != i)
                        {
                            // sacar y poner donde corresponde
                            ToolStripItem ti = toolStrip.Items[toolStrip.Items.IndexOfKey(str[i])];
                            toolStrip.Items.RemoveByKey(str[i]);
                            toolStrip.Items.Insert(i, ti);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}