using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Data;
using System.Threading;

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

            _playThread = new Thread(new ParameterizedThreadStart(delegate
            {
                while (true)
                {
                    var program = ScheduleManager.GetCurrentProgram(model);
                    if (program != null)
                    {
                        PlayProgram(program);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            }));
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

        private void PlayProgram(Model.Program program)
        {
            foreach (var msg in program.Messages)
            {
                txtMessage.Invoke(new Action(() =>
                {
                    txtMessage.Text = msg.Content;
                    txtUpdateTime.Text = DateTime.Now.ToString();
                }));

                Thread.Sleep(msg.Duration * 1000);
            }
        }
    }
}
