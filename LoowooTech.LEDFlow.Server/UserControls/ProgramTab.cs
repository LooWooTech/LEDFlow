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
        }

        private DataGridViewRow GetSelectedRow()
        {
            var rows = dataGridView1.SelectedRows;
            if (rows == null || rows.Count == 0)
            {
                return null;
            }

            return rows[0];
        }

        private int GetSelectedProgramId()
        {
            var row = GetSelectedRow();
            if (row == null)
            {
                MessageBox.Show("请先选中一行再点修改或直接双击该行");
                return 0;
            }
            return (int)(row.Cells["ID"].Value);
        }

        private void EditProgram(int programId = 0)
        {
            var editForm = new EditProgramForm();
            editForm.BindData(programId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                BindData();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditProgram();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedProgramId();
            if (id == 0) return;
            EditProgram(id);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = GetSelectedProgramId();
            if (id == 0) return;
            EditProgram(id);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            var id = GetSelectedProgramId();
            if (id == 0) return;
            var form = new EditScheduleForm();
            form.BindData(id);
            form.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedProgramId();
            if (id == 0) return;
            if (MessageBox.Show("你确定要删除该节目吗？\n同时会删除该节目的所有排期！", "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProgramManager.Delete(id);
                BindData();
            }
        }
    }
}
