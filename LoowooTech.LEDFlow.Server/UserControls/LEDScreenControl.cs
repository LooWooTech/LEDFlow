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
    public partial class LEDScreenControl : UserControl
    {
        private Thread _playThread;
        public LEDScreenControl()
        {
            InitializeComponent();
        }

        public int LEDID { get; private set; }

        public void Stop()
        {
            if (_playThread != null)
            {
                _playThread.Abort();
                _playThread = null;
            }
        }

        public void BindData(Model.LEDScreen model)
        {
            LEDID = model.ID;
            txtName.Text = model.Name;

            _playThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        if (model.VirtualID == -1)
                        {
                            txtMessage.Invoke(new Action(() =>
                            {
                                txtMessage.Text = "关闭中";
                                model = LEDManager.GetModel(model.ID);
                            }));
                            Thread.Sleep(1000);
                        }
                        PlayProgram(model.CurrentProgram);
                    }
                    catch { }
                }
            });
            _playThread.Start();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var form = new EditLEDScreenForm();
            form.BindData(LEDID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.Stop();
                var model = LEDManager.GetModel(LEDID);
                BindData(model);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LEDManager.Delete(LEDID);
            this.Hide();
        }

        private int GetHoldTime()
        {
            return StringHelper.ToInt(System.Configuration.ConfigurationManager.AppSettings["HoldTime"], 5);
        }

        private void PlayProgram(Model.Program program)
        {
            if (program == null)
            {
                Thread.Sleep(1000);
                return;
            }
            foreach (var msg in program.Messages)
            {
                txtMessage.Invoke(new Action(() =>
                {
                    txtMessage.Text = msg.Content;
                    txtUpdateTime.Text = DateTime.Now.ToString();
                }));

                Thread.Sleep(GetHoldTime() * 1000);
            }
        }
    }
}
