using LoowooTech.LEDFlow.Server.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Server
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnProgram_Click(null, null);
        }

        private void AddContainer<T>() where T : UserControl, UserControls.ITabControl, new()
        {
            new Thread(() =>
            {
                container.Invoke(new Action(() =>
                {
                    if (container.Controls.Count == 1)
                    {
                        var currentControl = (UserControls.ITabControl)container.Controls[0];
                        if (currentControl is T)
                        {
                            return;
                        }
                        else
                        {
                            container.Controls.RemoveAt(0);
                        }
                    }
                    var control = new T();
                    container.Controls.Add(control);
                    control.Dock = DockStyle.Fill;
                    control.BindData();
                }));
            }).Start();
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            AddContainer<ProgramTab>();
        }

        private void btnLED_Click(object sender, EventArgs e)
        {
            AddContainer<LEDScreenTab>();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddContainer<AdminTab>();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            AddContainer<ClientTab>();
        }

        protected override void OnClosed(EventArgs e)
        {
            container.Controls.Clear();
            base.OnClosed(e);
        }
    }
}
