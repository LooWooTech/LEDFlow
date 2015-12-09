namespace LoowooTech.LEDFlow.Server
{
    partial class EditScheduleForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.playTimeControl1 = new LoowooTech.LEDFlow.Server.UserControls.PlayTimeControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPlayMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlayTimes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstLED = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEDName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstLED)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDuration);
            this.groupBox1.Controls.Add(this.playTimeControl1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxPlayMode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPlayTimes);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 232);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "播放设置";
            this.groupBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(83, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "不限次数时必须限制时长";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(142, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "0为不限制次数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "小时(支持小数)";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(84, 93);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(52, 21);
            this.txtDuration.TabIndex = 25;
            // 
            // playTimeControl1
            // 
            this.playTimeControl1.Location = new System.Drawing.Point(12, 134);
            this.playTimeControl1.Name = "playTimeControl1";
            this.playTimeControl1.Size = new System.Drawing.Size(213, 62);
            this.playTimeControl1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "播放时长";
            // 
            // cbxPlayMode
            // 
            this.cbxPlayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlayMode.FormattingEnabled = true;
            this.cbxPlayMode.Location = new System.Drawing.Point(83, 23);
            this.cbxPlayMode.Name = "cbxPlayMode";
            this.cbxPlayMode.Size = new System.Drawing.Size(121, 20);
            this.cbxPlayMode.TabIndex = 22;
            this.cbxPlayMode.SelectedIndexChanged += new System.EventHandler(this.cbxPlayMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "播放方式";
            // 
            // txtPlayTimes
            // 
            this.txtPlayTimes.Location = new System.Drawing.Point(83, 56);
            this.txtPlayTimes.Name = "txtPlayTimes";
            this.txtPlayTimes.Size = new System.Drawing.Size(52, 21);
            this.txtPlayTimes.TabIndex = 19;
            this.txtPlayTimes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPlayTimes_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "播放次数";
            // 
            // lstLED
            // 
            this.lstLED.AllowUserToAddRows = false;
            this.lstLED.AllowUserToDeleteRows = false;
            this.lstLED.AllowUserToResizeColumns = false;
            this.lstLED.AllowUserToResizeRows = false;
            this.lstLED.BackgroundColor = System.Drawing.Color.White;
            this.lstLED.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLED.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.lstLED.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LEDName});
            this.lstLED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLED.Location = new System.Drawing.Point(0, 0);
            this.lstLED.Name = "lstLED";
            this.lstLED.ReadOnly = true;
            this.lstLED.RowHeadersVisible = false;
            this.lstLED.RowTemplate.Height = 23;
            this.lstLED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lstLED.Size = new System.Drawing.Size(461, 297);
            this.lstLED.TabIndex = 30;
            // 
            // ID
            // 
            this.ID.FillWeight = 30F;
            this.ID.HeaderText = "编号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 64;
            // 
            // LEDName
            // 
            this.LEDName.FillWeight = 184.7716F;
            this.LEDName.HeaderText = "名称";
            this.LEDName.Name = "LEDName";
            this.LEDName.ReadOnly = true;
            this.LEDName.Width = 397;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 43);
            this.panel1.TabIndex = 36;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(374, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(279, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 36;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // EditScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 297);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstLED);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditScheduleForm";
            this.Text = "选择需要播放的LED屏幕";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstLED)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private UserControls.PlayTimeControl playTimeControl1;
        private System.Windows.Forms.ComboBox cbxPlayMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlayTimes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView lstLED;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEDName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
