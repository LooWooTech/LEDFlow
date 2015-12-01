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

namespace LoowooTech.LEDFlow.Server
{
    public partial class EditScheduleForm : Form
    {
        public EditScheduleForm()
        {
            InitializeComponent();
        }

        public int ScheduleID { get; private set; }

        public int ProgramID { get; private set; }

        public void BindData(int scheduleId, int programId = 0)
        {
            cbxPlayMode.DataSource = Enum.GetNames(typeof(Model.PlayMode));
            ProgramID = programId;
            ScheduleID = scheduleId;
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
            DateTime endTime = DateTime.MinValue;
            if (playTimes == 0 && duration == 0)
            {
                MessageBox.Show("播放次数和播放时长必须有一个有值");
                return;
            }
            //如果设置了无限循环，则播放时长必须有值
            if (playTimes == 0)
            {
                endTime = beginTime.AddMinutes(60 * duration);
            }
            else
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

            var model = ScheduleManager.GetModel(ScheduleID) ?? new Schedule()
            {
                ProgramID = ProgramID,
                LedIds = ledIds.ToArray(),
                PlayMode = playMode,
                BeginTime = beginTime,
                EndTime = endTime,
                PlayTimes = playTimes,
            };

            ScheduleManager.Save(model);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
