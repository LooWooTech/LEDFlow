﻿using LoowooTech.LEDFlow.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Server
{
    public partial class EditProgramForm : Form
    {
        public EditProgramForm()
        {
            InitializeComponent();

        }

        private int _programId;

        private void btnOK_Click(object sender, EventArgs e)
        {
            var model = ProgramManager.GetModel(_programId) ?? new Model.Program();
            model.Messages.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var content = string.Empty;
                if (row.Cells["Content"].Value != null)
                {
                    content = row.Cells["Content"].Value.ToString();
                }
                else
                {
                    continue;
                }
                var duration = 0;
                if (row.Cells["Duration"].Value != null)
                {
                    int.TryParse(row.Cells["Duration"].Value.ToString(), out duration);
                }
                model.Messages.Add(new Model.Message
                {
                    Content = content,
                    Duration = duration
                });
            }

            var playTimes = 0;
            int.TryParse(txtPlayTimes.Text, out playTimes);
            model.PlayTimes = playTimes;
            model.PlayTime = playTimeControl1.GetValue();
            model.PlayMode = ParseEnum<Model.PlayMode>(cbxPlayMode.Text);
            if (!string.IsNullOrEmpty(cbxFontFamily.Text)
                || !string.IsNullOrEmpty(txtFontSize.Text)
                || !string.IsNullOrEmpty(cbxTextAlignment.Text)
                || !string.IsNullOrEmpty(cbxTextAnimation.Text)
                )
            {
                model.Style = new Model.TextStyle();
                model.Style.FontFamily = ParseEnum<Model.FontFamily>(cbxFontFamily.Text);

                var fontSize = 0;
                int.TryParse(txtFontSize.Text, out fontSize);
                model.Style.FontSize = fontSize;
                model.Style.TextAlignment = ParseEnum<Model.TextAlignment>(cbxTextAlignment.Text);
                model.Style.TextAnimation = ParseEnum<Model.TextAnimation>(cbxTextAnimation.Text);
            }

            ProgramManager.Save(model);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private T ParseEnum<T>(string text) where T : struct
        {
            var result = Enum.Parse(typeof(T), text);
            return (T)result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //if (MessageBox.Show("确定关闭吗?", "提醒", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }


        internal void BindData(int programId = 0)
        {
            _programId = programId;
            cbxPlayMode.DataSource = Enum.GetNames(typeof(Model.PlayMode));
            cbxFontFamily.DataSource = Enum.GetNames(typeof(Model.FontFamily));
            cbxTextAlignment.DataSource = Enum.GetNames(typeof(Model.TextAlignment));
            cbxTextAnimation.DataSource = Enum.GetNames(typeof(Model.TextAnimation));
            cbxFontFamily.SelectedIndex = cbxTextAlignment.SelectedIndex = cbxTextAnimation.SelectedIndex = -1;
            if (programId > 0)
            {
                var model = ProgramManager.GetModel(programId);
                if (model != null)
                {
                    foreach (var msg in model.Messages)
                    {
                        var rowIndex = dataGridView1.Rows.Add();
                        var row = dataGridView1.Rows[rowIndex];
                        row.Cells["Content"].Value = msg.Content;
                        row.Cells["Duration"].Value = msg.Duration;
                    }

                    playTimeControl1.SetValue(model.PlayTime);
                    txtPlayTimes.Text = model.PlayTimes.ToString();

                    if (model.Style != null)
                    {
                        cbxFontFamily.Text = model.Style.FontFamily.ToString();
                        txtFontSize.Text = model.Style.FontSize.ToString();
                        cbxTextAlignment.Text = model.Style.TextAlignment.ToString();
                        cbxTextAnimation.Text = model.Style.TextAnimation.ToString();
                    }
                }
            }
        }

        private void cbxPlayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = (Model.PlayMode)Enum.Parse(typeof(Model.PlayMode), cbxPlayMode.Text);
            playTimeControl1.SetPlayMode(mode);
        }
    }
}
