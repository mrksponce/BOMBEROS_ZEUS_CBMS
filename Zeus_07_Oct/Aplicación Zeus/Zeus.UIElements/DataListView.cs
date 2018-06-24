using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Zeus.UIElements
{
    public class DataListView : ListView
    {
        //Variables

        //private int columnWidth = 100;
        private CurrencyManager cm;
        private DataTable dataSource;
        private string displayMember;
        private string valueMember;


        //Constructor
        public DataListView()
        {
            //set default settings for listView
            //this.View = View.Details;
            //this.FullRowSelect = true;
            //this.MultiSelect = false;
            //this.BackColor = Color.Wheat;
            //this.ForeColor = Color.Brown;
            //this.HideSelection = false;

            SelectedIndexChanged += MyListView_SelectedIndexChanged;
        }

        //Properties
        [Category("Data")]
        public string DisplayMember
        {
            get { return displayMember; }
            set { displayMember = value; }
        }

        [Category("Data")]
        public string ValueMember
        {
            get { return valueMember; }
            set { valueMember = value; }
        }

        [Browsable(false)]
        public object SelectedValue
        {
            get { return cm == null ? null : ((DataRowView) cm.Current)[valueMember]; }
        }

        [Browsable(false)]
        public DataTable DataSource
        {
            get { return dataSource; }
            set
            {
                dataSource = value;
                if (value != null)
                {
                    dataBindControl();
                    setCurrencyManager();
                    if (Items.Count != 0)
                    {
                        Items[0].Selected = true;
                    }
                    OnSelectedIndexChanged(null);
                }
            }
        }

        //Methods
        private void setCurrencyManager()
        {
            //Assign CurrencyManager [from BindingContext]
            cm = (CurrencyManager) BindingContext[dataSource];
        }

        private void dataBindControl()
        {
            Items.Clear();

            ListViewItem newItem;

            for (int i = 0; i < dataSource.Rows.Count; i++)
            {
                newItem = new ListViewItem
                              {
                                  Text = dataSource.Rows[i][displayMember].ToString()
                              };
                //First Column
                //SubItems
                for (int subItems = 1; subItems < Columns.Count; subItems++)
                {
                    // match by column's Tag property
                    if (dataSource.Columns.Contains(Columns[subItems].Tag.ToString()))
                    {
                        newItem.SubItems.Add(dataSource.Rows[i][Columns[subItems].Tag.ToString()].ToString());
                    }
                    //if(dataSource.Columns.IndexOf(displayMember)!=subItems)
                    //    newItem.SubItems.Add(this.dataSource.Rows[i].ItemArray[subItems].ToString());
                }

                Items.Add(newItem);
            }
        }

        private void MyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItems.Count > 0)
            {
                //set Position of CurrencyManager to selectedIndex of ListView
                cm.Position = SelectedItems[0].Index;
            }
        }
    }
}