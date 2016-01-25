using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Data;
using System.Threading;
using LoowooTech.LEDFlow.Common;

namespace LoowooTech.LEDFlow.Server.UserControls
{
    public partial class LEDScreenTab : UserControl, ITabControl
    {
        private Thread _playThread;

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
            _playThread = new Thread(() =>
            {
                while (true)
                {
                    Invoke(new Action(() =>
                    {
                        foreach (LEDScreenControl control in flowLayoutPanel1.Controls)
                        {
                            control.PlayProgram();
                        }
                    }));
                    Thread.Sleep(StringHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["HoldTime"], 5) * 1000);
                }
            });
            _playThread.Start();
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
                AutoPlayService.Instance.AddLED(last);
            }
        }

        private void LEDScreenTab_ParentChanged(object sender, EventArgs e)
        {
            if (_playThread != null)
            {
                _playThread.Abort();
                _playThread = null;
            }
        }
    }
}
