using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Data;
using LoowooTech.LEDFlow.Model;
using System.Threading;

namespace LoowooTech.LEDFlow.Server
{
    public partial class EditScheduleForm : Form
    {
        public EditScheduleForm()
        {
            InitializeComponent();
        }

        public int ProgramID { get; private set; }

        public void BindData(int programId)
        {
            cbxPlayMode.DataSource = Enum.GetNames(typeof(Model.PlayMode));
            ProgramID = programId;
            var leds = LEDManager.GetList();
            foreach (var led in leds)
            {
                var index = lstLED.Rows.Add();
                var row = lstLED.Rows[index];
                row.Cells["ID"].Value = led.ID;
                row.Cells["LEDName"].Value = led.Name;
            }
        }

        private void cbxPlayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = (Model.PlayMode)Enum.Parse(typeof(Model.PlayMode), cbxPlayMode.Text);
            playTimeControl1.SetPlayMode(mode);
        }

        private void txtPlayTimes_KeyUp(object sender, KeyEventArgs e)
        {
            var val = StringHelper.ToInt(txtPlayTimes.Text);
            txtDuration.Enabled = val == 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstLED.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要播放的LED屏幕，可多选");
                return;
            }

            var playMode = StringHelper.ToEnum<Model.PlayMode>(cbxPlayMode.Text);
            var playTimes = StringHelper.ToInt(txtPlayTimes.Text);
            var duration = StringHelper.ToDouble(txtDuration.Text);
            var beginTime = playTimeControl1.GetValue();
            DateTime? endTime = null;
            if (duration > 0)
            {
                endTime = beginTime.AddMinutes(60 * duration);
            }
            else if (playTimes > 0) //如果设置了播放次数，则不能设置播放时长
            {
                var program = ProgramManager.GetModel(ProgramID);
                duration = program.GetPlayDuration(playTimes);
                endTime = beginTime.AddSeconds(duration);
            }

            var ledIds = new List<string>();
            foreach (DataGridViewRow row in lstLED.SelectedRows)
            {
                ledIds.Add(row.Cells["ID"].Value.ToString());
            }

            new Thread(() =>
            {
                var model = new Schedule()
                {
                    ProgramID = ProgramID,
                    LedIds = ledIds.ToArray(),
                    PlayMode = playMode,
                    BeginTime = beginTime,
                    EndTime = endTime,
                    PlayTimes = playTimes,
                };

                ScheduleManager.Save(model);
                if (model.PlayMode == PlayMode.立即开始)
                {
                    LEDService.PlaySchedule(model);
                }
            }).Start();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
