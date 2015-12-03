using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Data;
using LoowooTech.LEDFlow.Model;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private readonly string ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];

        private Thread _bindDataThread;

        private LEDService GetServiceClient()
        {
            return (LEDService)Activator.GetObject(typeof(LEDService), System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"]);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ChannelServices.RegisterChannel(new TcpClientChannel(), true);
            if (string.IsNullOrEmpty(ClientId))
            {
                MessageBox.Show("请在App.config里配置ClientId，再启动软件。");
                Application.Exit();
                return;
            }
            BindGrid();
            _bindDataThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        this.BeginInvoke(new Action(BindData));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Thread.Sleep(1000 * 60);
                }

            });
            _bindDataThread.Start();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _bindDataThread.Abort();
            _bindDataThread = null;
        }

        public void BindData()
        {
            var client = GetServiceClient();
            var leds = client.GetLEDs(ClientId);
            if (leds.Count == 0)
            {
                MessageBox.Show("你没有可用的LED屏幕，请确认Client配置正确或与主控管理员联系");
                btnSend.Enabled = false;
                return;
            }

            this.Width = flowLayoutPanel1.Width * leds.Count;
            foreach (var led in leds)
            {
                flowLayoutPanel1.Controls.Add(new LEDScreenControl(led)
                {
                    //Height = flowLayoutPanel1.Height + 10,
                    Width = flowLayoutPanel1.Width / leds.Count - 10,
                    Margin = new Padding(3)
                });
            }
            ((LEDScreenControl)flowLayoutPanel1.Controls[0]).Select();
        }

        private int GetSelectedLEDID()
        {
            foreach (LEDScreenControl c in flowLayoutPanel1.Controls)
            {
                if (c.Selected)
                {
                    return c.LedID;
                }
            }
            return 0;
        }

        private void BindGrid()
        {
            dataGridView1.Rows.Clear();
            var list = MessageManager.GetList();
            foreach (var msg in list)
            {
                var index = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[index];
                row.Cells["ID"].Value = msg.ID;
                row.Cells["Content"].Value = msg.Content;
                row.Cells["Duration"].Value = msg.Duration;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中需要删除的信息行");
            }
            if (MessageBox.Show("你确定要删除选中的信息吗？", "提醒", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var id = row.Cells["ID"].Value;
                    if (id == null) continue;
                    MessageManager.Delete(int.Parse(id.ToString()));
                }
                BindData();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中需要发送的信息行");
            }
            var program = new Model.Program();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var content = row.Cells["Content"].Value;
                if (content == null)
                {
                    MessageBox.Show("你选择的信息不能包含内容为空的数据");
                    break;
                }
                var duration = row.Cells["Duration"].Value;
                program.Messages.Add(new Model.Message
                {
                    Content = content.ToString(),
                    Duration = duration == null ? 10 : int.Parse(duration.ToString())
                });
                program.ClientID = ClientId;
            }
            var client = GetServiceClient();
            var ledId = GetSelectedLEDID();
            client.SendProgram(ledId, program, FontSettingForm.GetTextStyle(ledId));
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];
            var id = StringHelper.ToInt(row.Cells["ID"].Value == null ? null : row.Cells["ID"].Value.ToString(), 0);
            var content = row.Cells["Content"].Value == null ? null : row.Cells["Content"].Value.ToString();
            if (string.IsNullOrEmpty(content))
            {
                return;
            }
            var duration = StringHelper.ToInt(row.Cells["Duration"].Value == null ? null : row.Cells["Duration"].Value.ToString(), 10);
            var model = new Message
            {
                ID = id,
                Content = content,
                Duration = duration
            };
            MessageManager.Save(model);
            if (id == 0)
            {
                row.Cells["ID"].Value = model.ID;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            var form = new FontSettingForm(GetSelectedLEDID());
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
    }
}
