using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Zeus.UIElements
{
    public partial class ReorderListBox : UserControl
    {
        private object dataSource;
        private List<int> items;

        public ReorderListBox()
        {
            InitializeComponent();
        }

        public object DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                if (value != null)
                {
                    items = new List<int>();
                    gridReorder.Rows.Clear();

                    for (int i = 0; i < ((DataTable) dataSource).Rows.Count; i++)
                    {
                        items.Add(Convert.ToInt32(((DataTable) dataSource).Rows[i][ValueMember]));
                        string[] row = {(i + 1).ToString(), Convert.ToString(((DataTable) dataSource).Rows[i][DisplayMember].ToString())};
                        gridReorder.Rows.Add(row);
                    }
                }
                else
                {
                    gridReorder.Rows.Clear();
                }
            }
        }

        public string DisplayMember { get; set; }

        public string ValueMember { get; set; }

        [Category("Appearance"), Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return Titulo.Text; }
            set { Titulo.Text = value; }
        }

        [Category("Behavior"), Browsable(true),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),DefaultValue(false)]
        public  bool ReadOnly
        {
            get { return gridReorder.ReadOnly; }
            set { gridReorder.ReadOnly = value; }
        }

        public int[] Items
        {
            get
            {
                if (gridReorder.Rows.Count != 0)
                {
                    //var items = new List<int>();
                    //foreach (DataGridViewRow li in gridReorder.Rows)
                    //{
                    //    items.Add(int.Parse(li.Cells[1].Value.ToString()));
                    //}
                    return items.ToArray();
                }
                return new int[] {};
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (gridReorder.SelectedRows.Count != 0 && gridReorder.SelectedRows[0].Index != 0)
            {
                // flip viewable
                int index = gridReorder.SelectedRows[0].Index;
                var value = (string) gridReorder.Rows[index].Cells[1].Value;
                gridReorder.Rows[index].Cells[1].Value = gridReorder.Rows[index - 1].Cells[1].Value;
                gridReorder.Rows[index - 1].Cells[1].Value = value;
                gridReorder.Rows[index - 1].Selected = true;

                // flip items
                var value2 = items[index];
                items.RemoveAt(index);
                items.Insert(index - 1, value2);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (gridReorder.SelectedRows.Count != 0 && gridReorder.SelectedRows[0].Index != gridReorder.Rows.Count - 1)
            {
                int index = gridReorder.SelectedRows[0].Index;
                var value = (string) gridReorder.Rows[index].Cells[1].Value;
                gridReorder.Rows[index].Cells[1].Value = gridReorder.Rows[index + 1].Cells[1].Value;
                gridReorder.Rows[index + 1].Cells[1].Value = value;
                gridReorder.Rows[index + 1].Selected = true;

                // flip items
                var value2 = items[index];
                items.RemoveAt(index);
                items.Insert(index + 1, value2);
            }
        }

        private void ReorderListBox_SizeChanged(object sender, EventArgs e)
        {
            gridReorder.Columns[1].Width = gridReorder.Width - gridReorder.Columns[0].Width - 10;
        }

        private void listBox1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int value;
            if (!ReadOnly&&(!int.TryParse(e.FormattedValue.ToString(), out value) || value < 0))
            {
                MessageBox.Show("El valor ingresado es inválido, debe ingresar un valor numérico y mayor que cero.",
                                "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}