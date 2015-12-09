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

        private readonly Model.PageParameter Page = new Model.PageParameter();
        
        public void BindData()
        {
            var programs = ProgramManager.GetList();
            var list = ScheduleManager.GetList(Page);
            txtPage.Text = Page.CurrentPage + "/" + Page.PageCount;
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
                ((DataGridViewCheckBoxCell)row.Cells["Played"]).Value = DateTime.Now > item.EndTime;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (Page.CurrentPage <= 1) return;
            Page.CurrentPage--;
            BindData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.CurrentPage + 1 >= Page.PageCount)
            {
                return;
            }
            Page.CurrentPage++;
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
    }
}
