namespace LoowooTech.LEDFlow.Server.UserControls
{
    partial class ScheduleTab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtPage = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEnd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator1,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnPrev,
            this.btnNext,
            this.toolStripSeparator3,
            this.txtPage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(616, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 22);
            this.btnAdd.Text = "修改";
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(36, 22);
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrev
            // 
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(48, 22);
            this.btnPrev.Text = "上一页";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(48, 22);
            this.btnNext.Text = "下一页";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // txtPage
            // 
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(34, 22);
            this.txtPage.Text = "1/10";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Content,
            this.PlayTimes,
            this.Duration,
            this.PlayMode,
            this.PlayTime,
            this.IsEnd});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(616, 395);
            this.dataGridView1.TabIndex = 11;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Content
            // 
            this.Content.FillWeight = 303.4808F;
            this.Content.HeaderText = "播放节目";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            // 
            // PlayTimes
            // 
            this.PlayTimes.FillWeight = 101.1603F;
            this.PlayTimes.HeaderText = "播放次数";
            this.PlayTimes.Name = "PlayTimes";
            this.PlayTimes.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.FillWeight = 101.1603F;
            this.Duration.HeaderText = "池逊时间";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // PlayMode
            // 
            this.PlayMode.FillWeight = 101.1603F;
            this.PlayMode.HeaderText = "播放方式";
            this.PlayMode.Name = "PlayMode";
            this.PlayMode.ReadOnly = true;
            // 
            // PlayTime
            // 
            this.PlayTime.FillWeight = 101.1603F;
            this.PlayTime.HeaderText = "播放时间";
            this.PlayTime.Name = "PlayTime";
            this.PlayTime.ReadOnly = true;
            // 
            // IsEnd
            // 
            this.IsEnd.FillWeight = 41.87817F;
            this.IsEnd.HeaderText = "已播";
            this.IsEnd.Name = "IsEnd";
            this.IsEnd.ReadOnly = true;
            this.IsEnd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ScheduleTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ScheduleTab";
            this.Size = new System.Drawing.Size(616, 420);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPrev;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel txtPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsEnd;


    }
}
