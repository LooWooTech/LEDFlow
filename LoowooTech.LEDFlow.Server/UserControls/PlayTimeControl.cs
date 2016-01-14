using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Model;
using LoowooTech.LEDFlow.Common;

namespace LoowooTech.LEDFlow.Server.UserControls
{
    public partial class PlayTimeControl : UserControl
    {
        private PlayMode _playMode;

        private List<int> GetIntArray(int min, int max)
        {
            var data = new List<int>();
            for (var i = min; i <= max; i++)
            {
                data.Add(i);
            }
            return data;
        }

        public PlayTimeControl()
        {
            InitializeComponent();
            cbxYear.DataSource = new int[] { DateTime.Today.Year, DateTime.Today.Year + 1 };
            cbxMonth.DataSource = GetIntArray(1, 12);
            cbxMonth.SelectedIndexChanged += cbxMonth_SelectedIndexChanged;

            cbxYear.Text = DateTime.Now.Year.ToString();
            cbxMonth.Text = DateTime.Now.Month.ToString();
            cbxDay.Text = DateTime.Now.Day.ToString();

            cbxHour.DataSource = GetIntArray(0, 23);
            cbxMinute.DataSource = new int[] { 0, 10, 20, 30, 40, 50 };
        }

        void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var year = StringHelper.ToInt(cbxYear.Text);
            var month = StringHelper.ToInt(cbxMonth.Text);
            var maxDay = 30;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    maxDay = 31;
                    break;
                case 2:
                    maxDay = DateTime.IsLeapYear(year) ? 29 : 28;
                    break;
            }
            cbxDay.DataSource = GetIntArray(1, maxDay);
        }

        public void SetPlayMode(PlayMode mode)
        {
            _playMode = mode;
            switch (mode)
            {
                case PlayMode.定点开始:
                    this.Show();
                    cbxYear.Visible = cbxMonth.Visible = cbxDay.Visible = true;
                    break;
                case PlayMode.立即开始:
                    this.Hide();
                    break;
                case PlayMode.定点轮播:
                    this.Show();
                    cbxYear.Visible = cbxMonth.Visible = cbxDay.Visible = false;
                    break;
            }
        }

        public DateTime GetValue()
        {
            var year = StringHelper.ToInt(cbxYear.Text);
            var month = StringHelper.ToInt(cbxMonth.Text);
            var day = StringHelper.ToInt(cbxDay.Text, 1);
            var hour = StringHelper.ToInt(cbxHour.Text);
            var minute = StringHelper.ToInt(cbxMinute.Text);

            switch (_playMode)
            {
                case PlayMode.定点开始:
                    return new DateTime(year, month, day, hour, minute, 0);
                case PlayMode.定点轮播:
                    return new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, hour, minute, 0);
                case PlayMode.立即开始:
                default:
                    return DateTime.Now.AddSeconds(1);
            }
        }

        internal void SetValue(DateTime? playTime)
        {
            if (playTime.HasValue)
            {
                cbxYear.Text = playTime.Value.Year.ToString();
                cbxMonth.Text = playTime.Value.Month.ToString();
                cbxDay.Text = playTime.Value.Day.ToString();
                cbxHour.Text = playTime.Value.Hour.ToString();
                cbxMinute.Text = playTime.Value.Minute.ToString();
            }
        }
    }
}
