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
    public partial class LEDScreenTab : UserControl, ITabControl
    {
        public LEDScreenTab()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            var list = LEDManager.GetList();
            foreach (var model in list)
            {
                AddControl(model);
            }
        }

        private void AddControl(Model.LEDScreen data)
        {
            var control = new LEDScreenControl();
            control.BindData(data);
            control.Margin = new System.Windows.Forms.Padding(10);
            flowLayoutPanel1.Controls.Add(control);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditLEDScreenForm();
            form.BindData();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LEDScreenTab_ParentChanged(null, null);
                var list = LEDManager.GetList();
                var last = list[list.Count - 1];
                AddControl(last);
            }
        }

        private void LEDScreenTab_ParentChanged(object sender, EventArgs e)
        {
            foreach (LEDScreenControl control in flowLayoutPanel1.Controls)
            {
                control.Stop();
            }
        }
    }
}
