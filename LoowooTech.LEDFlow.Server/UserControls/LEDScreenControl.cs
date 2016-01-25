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
        public LEDScreenControl()
        {
            InitializeComponent();
        }

        private Model.LEDScreen LED;

        public void BindData(Model.LEDScreen model)
        {
            LED = model;
            txtName.Text = model.Name;
        }

        private Model.Program _lastProgram = null;
        private int _lastIndex = -1;
        public void PlayProgram()
        {
            if (LED.VirtualID == -1)
            {
                LED = LEDManager.GetModel(LED.ID);
                if (LED.VirtualID == -1)
                {
                    txtMessage.Text = "关闭中";
                }
            }
            else
            {
                if (LED.CurrentProgram == null)
                {
                    txtMessage.Text = "没有节目";
                }
                else
                {
                    if (_lastProgram != null)
                    {
                        if (LED.CurrentProgram.ID == _lastProgram.ID)
                        {
                            _lastIndex++;

                            if(_lastIndex >= LED.CurrentProgram.Messages.Count)
                            {
                                _lastIndex -= LED.CurrentProgram.Messages.Count;
                            }
                            txtMessage.Text = LED.CurrentProgram.Messages[_lastIndex].Content;
                            txtUpdateTime.Text = LED.LastUpdateTime.HasValue ? LED.LastUpdateTime.Value.ToString() : string.Empty;
                        }
                    }
                    else
                    {
                        _lastProgram = LED.CurrentProgram;
                        _lastIndex = 0;
                        txtMessage.Text = LED.CurrentProgram.Messages[_lastIndex].Content;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var form = new EditLEDScreenForm();
            form.BindData(LED.ID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var model = LEDManager.GetModel(LED.ID);
                BindData(model);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LEDManager.Delete(LED.ID);
            this.Hide();
        }
    }
}
