using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Model;
using LoowooTech.LEDFlow.Data;

namespace LoowooTech.LEDFlow.Server.UserControls
{
    public partial class AdminTab : UserControl, ITabControl
    {
        public AdminTab()
        {
            InitializeComponent();
        }

        private void AddRow(Admin model)
        {
            var rowIndex = dataGridView1.Rows.Add();

            var row = dataGridView1.Rows[rowIndex];
            row.Cells["Username"].Value = model.Username;
            row.Cells["Password"].Value = model.Password;
            row.Cells["Role"].Value = model.Role.ToString();

            dataGridView1.CurrentCell = row.Cells[0];
            dataGridView1.BeginEdit(false);
        }

        public void BindData()
        {
            (dataGridView1.Columns["Role"] as DataGridViewComboBoxColumn).DataSource = Enum.GetNames(typeof(Role));
            var list = DataManager.Instance.GetList<Admin>();
            foreach(var item in list)
            {
                AddRow(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new Admin());
        }

        public void SaveData()
        {
            var list = new List<Model.Admin>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    list.Add(new Admin
                    {
                        Username = row.Cells["Username"].Value.ToString(),
                        Password = row.Cells["Password"].Value.ToString(),
                        Role = (Role)Enum.Parse(typeof(Role), row.Cells["Role"].Value.ToString())
                    });
                }
                catch { }
            }
            DataManager.Instance.Save(list);
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
