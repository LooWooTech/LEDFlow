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
            var list = ScheduleManager.GetList(Page);
            var programIds = new List<int>();
            foreach(var item in list)
            {
                programIds.Add(item.ProgramID);
            }
            var programs = ProgramManager.GetScheduleList(programIds);
            txtPage.Text = Page.CurrentPage + "/" + Page.PageCount;
            dataGridView1.Rows.Clear();
            foreach (var item in list)
            {
                var program = programs.Find(delegate(Model.Program p) { return p.ID == item.ProgramID; });
                if (program == null) continue;
                var index = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[index];
                row.Cells["Messages"].Value = program.Content;
                row.Cells["ClientID"].Value = program.ClientID;
                row.Cells["ID"].Value = item.ID;
                row.Cells["PlayMode"].Value = item.PlayMode.ToString();
                row.Cells["PlayTimes"].Value = item.PlayTimes;
                row.Cells["BeginTime"].Value = item.BeginTime;
                row.Cells["EndTime"].Value = item.EndTime;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择一行数据");
                return;
            }

            if (MessageBox.Show("你确定要删除选中的节目安排吗？", "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var id = (int)row.Cells["ID"].Value;
                    ScheduleManager.Delete(id);
                }
                BindData();
            }
        }
    }
}
