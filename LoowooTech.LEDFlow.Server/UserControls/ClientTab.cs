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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Selected = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("保存成功");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("你确定要删除吗？", "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                    SaveData();
                }
            }
        }
    }
}
