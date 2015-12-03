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
    public partial class ScheduleTab : UserControl, ITabControl
    {
        public ScheduleTab()
        {
            InitializeComponent();
        }

        private int _pageIndex = 1;
        private int _pageSize = 20;
        private int _recordCount;

        private int _pageCount
        {
            get
            {
                var count = _recordCount / _pageSize;
                return count + (_recordCount % _pageSize > 0 ? 1 : 0);
            }
        }

        public void BindData()
        {
            var programs = ProgramManager.GetList();
            var list = ScheduleManager.GetList(_pageIndex, _pageSize, out _recordCount);
            txtPage.Text = _pageIndex + "/" + _pageCount;
            dataGridView1.Rows.Clear();
            foreach (var item in list)
            {
                var program = programs.Find(delegate(Model.Program p) { return p.ID == item.ProgramID; });
                if (program == null) continue;
                //var messages = new StringBuilder();
                //foreach (var msg in program.Messages)
                //{
                //    messages.Append(msg.Content);
                //    messages.Append("...");
                //}

                var index = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[index];
                row.Cells["Messages"].Value = program.Messages[0].Content + "...";
                row.Cells["ID"].Value = item.ID;
                row.Cells["PlayMode"].Value = item.PlayMode.ToString();
                row.Cells["PlayTimes"].Value = item.PlayTimes;
                row.Cells["BeginTime"].Value = item.BeginTime;
                row.Cells["Duration"].Value = item.PlayTimes > 0 ? null : (item.EndTime - item.BeginTime).TotalHours.ToString("f1");
                ((DataGridViewCheckBoxCell)row.Cells["Played"]).Value = DateTime.Now > item.EndTime;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_pageIndex <= 1) return;
            _pageIndex--;
            BindData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_pageIndex + 1 >= _pageCount)
            {
                return;
            }
            _pageIndex++;
            BindData();
        }

        private int GetSelectedID()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择一行数据");
                return 0;
            }
            return (int)(dataGridView1.SelectedRows[0].Cells["ID"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedID();
            if (id == 0) return;
            if (MessageBox.Show("你确定要删除这个节目安排吗？", "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ScheduleManager.Delete(id);
                BindData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var id = GetSelectedID();
            if (id == 0) return;
            var form = new EditScheduleForm();
            form.BindData(id, 0);
        }
    }
}
