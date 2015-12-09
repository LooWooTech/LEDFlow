using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Data;
using LoowooTech.LEDFlow.Model;

namespace LoowooTech.LEDFlow.Server.UserControls
{
    public partial class PlayLogTab : UserControl, ITabControl
    {
        public PlayLogTab()
        {
            InitializeComponent();
        }

        private readonly PageParameter Page = new PageParameter();

        public void BindData()
        {
            var list = PlayLogManager.GetList(Page);
            txtPage.Text = Page.CurrentPage + "/" + Page.PageCount;
            foreach (var item in list)
            {
                var index = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[index];
                row.Cells["Content"].Value = item.Content;
                row.Cells["ClientId"].Value = item.ClientId;
                row.Cells["PlayTime"].Value = item.PlayTime;
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
    }
}
