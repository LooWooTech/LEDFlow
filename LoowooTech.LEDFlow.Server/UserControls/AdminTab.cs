using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Model;

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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow(new Admin());
        }
    }
}
