using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Data;

namespace LoowooTech.LEDFlow.Server.UserControls
{
    public partial class ClientTab : UserControl, ITabControl
    {
        public ClientTab()
        {
            InitializeComponent();
        }

        private void SaveData()
        {
            var list = new List<Model.Client>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (string.IsNullOrEmpty(row.Cells[0].OwningColumn.Name)) continue;
                var name = row.Cells["ClientName"].Value;
                if (name == null) continue;

                var canAdd = true;

                foreach (var c in list)
                {
                    if (c.Name == name.ToString())
                    {
                        MessageBox.Show("名称不能重复");
                        canAdd = false;
                        break;
                    }
                }
                if (canAdd)
                {
                    list.Add(new Model.Client { Name = name.ToString() });
                }
            }
            DataManager.Instance.Save(list);
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            SaveData();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            var name = e.Row.Cells["ClientName"].Value;
            if (name == null)
            {
                return;
            }
            var list = DataManager.Instance.GetList<Model.Client>();
            var index = list.FindIndex(delegate(Model.Client c) { return c.Name == name.ToString(); });
            list.RemoveAt(index);
            DataManager.Instance.Save(list);
        }

        public void BindData()
        {
            var list = DataManager.Instance.GetList<Model.Client>();
            foreach (var item in list)
            {
                var rowIndex = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[rowIndex];
                row.Cells["ClientName"].Value = item.Name;
            }
        }
        
    }
}
