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
    public partial class ProgramTab : UserControl, ITabControl
    {
        public ProgramTab()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            dataGridView1.Rows.Clear();
            var list = ProgramManager.GetList();
            foreach (var item in list)
            {
                AddRow(item);
            }
        }

        public void AddRow(Model.Program model)
        {
            var rowIndex = dataGridView1.Rows.Add();
            var row = dataGridView1.Rows[rowIndex];
            row.Cells["ID"].Value = model.ID;
            row.Cells["Content"].Value = model.Content;
            row.Cells["StartDay"].Value = model.StartDay.HasValue ? model.StartDay.Value.ToShortDateString() : null;
            row.Cells["StartTime"].Value = model.StartTime;
            row.Cells["PlayTimes"].Value = model.PlayTimes;
            if (model.Style != null)
            {
                row.Cells["FontFamily"].Value = model.Style.FontFamily;
                row.Cells["FontSize"].Value = model.Style.FontSize;
                row.Cells["TextAlignment"].Value = model.Style.TextAlignment;
                row.Cells["TextAnimation"].Value = model.Style.TextAnimation;
            }
        }

        private DataGridViewRow GetSelectedRow()
        {
            var rows = dataGridView1.SelectedRows;
            if (rows == null || rows.Count == 0)
            {
                return null;
            }

            var row = rows[0];

            return row;
        }

        private void EditProgram(int programId = 0)
        {
            var editForm = new EditProgramForm();
            editForm.BindData(programId);
            BindData();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditProgram();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null)
            {
                MessageBox.Show("请先选中一行再点修改或直接双击该行");
                return;
            }
            var id = (int)(row.Cells["ID"].Value);
            EditProgram(id);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = GetSelectedRow();
            var id = (int)(row.Cells["ID"].Value);
            EditProgram(id);
        }
    }
}
