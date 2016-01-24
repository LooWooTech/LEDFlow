namespace LoowooTech.LEDFlow.Server
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.container = new System.Windows.Forms.Panel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnProgram = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSchedule = new System.Windows.Forms.ToolStripButton();
            this.btnLED = new System.Windows.Forms.ToolStripButton();
            this.btnClient = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUser = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 56);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(714, 363);
            this.container.TabIndex = 3;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 56);
            // 
            // btnLogout
            // 
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::LoowooTech.LEDFlow.Server.Properties.Resources.power;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(36, 53);
            this.btnLogout.Text = "退出";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(58)))), ((int)(((byte)(86)))));
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProgram,
            this.toolStripSeparator4,
            this.btnSchedule,
            this.toolStripSeparator3,
            this.btnLED,
            this.toolStripSeparator1,
            this.btnClient,
            this.toolStripSeparator2,
            this.btnUser,
            this.toolStripSeparator5,
            this.btnLogout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(714, 56);
            this.toolStrip1.TabIndex = 2;
            // 
            // btnProgram
            // 
            this.btnProgram.ForeColor = System.Drawing.Color.White;
            this.btnProgram.Image = global::LoowooTech.LEDFlow.Server.Properties.Resources.program;
            this.btnProgram.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(60, 53);
            this.btnProgram.Text = "节目管理";
            this.btnProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProgram.Click += new System.EventHandler(this.btnProgram_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 56);
            // 
            // btnSchedule
            // 
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Image = global::LoowooTech.LEDFlow.Server.Properties.Resources.play;
            this.btnSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(60, 53);
            this.btnSchedule.Text = "播放列表";
            this.btnSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnLED
            // 
            this.btnLED.ForeColor = System.Drawing.Color.White;
            this.btnLED.Image = global::LoowooTech.LEDFlow.Server.Properties.Resources.window;
            this.btnLED.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLED.Name = "btnLED";
            this.btnLED.Size = new System.Drawing.Size(60, 53);
            this.btnLED.Text = "屏幕监控";
            this.btnLED.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLED.Click += new System.EventHandler(this.btnLED_Click);
            // 
            // btnClient
            // 
            this.btnClient.ForeColor = System.Drawing.Color.White;
            this.btnClient.Image = global::LoowooTech.LEDFlow.Server.Properties.Resources.client;
            this.btnClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(72, 53);
            this.btnClient.Text = "客户端管理";
            this.btnClient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 56);
            // 
            // btnUser
            // 
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = global::LoowooTech.LEDFlow.Server.Properties.Resources.users;
            this.btnUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(60, 53);
            this.btnUser.Text = "用户管理";
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 419);
            this.Controls.Add(this.container);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "LED主控系统";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnUser;
        private System.Windows.Forms.ToolStripButton btnLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnLED;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnProgram;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClient;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSchedule;
    }
}

