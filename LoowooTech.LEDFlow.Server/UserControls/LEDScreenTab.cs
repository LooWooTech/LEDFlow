using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Server.UserControls
{
    public partial class LEDScreenTab : UserControl, ITabControl
    {
        public LEDScreenTab()
        {
            InitializeComponent();
        }

        public void BindData()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditLEDScreenForm();
            form.BindData();
            if (form.ShowDialog() == DialogResult.OK)
            {
                BindData();
            }
        }
    }
}
