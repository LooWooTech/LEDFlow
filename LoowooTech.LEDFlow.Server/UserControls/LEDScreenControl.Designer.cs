namespace LoowooTech.LEDFlow.Server.UserControls
{
    partial class LEDScreenControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtUpdateTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnEdit.Location = new System.Drawing.Point(194, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(240, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(45, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(6, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(71, 12);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "LED屏幕编号";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.txtUpdateTime);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 100);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(296, 32);
            this.panelBottom.TabIndex = 1;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.AutoSize = true;
            this.txtUpdateTime.Location = new System.Drawing.Point(66, 10);
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.Size = new System.Drawing.Size(89, 12);
            this.txtUpdateTime.TabIndex = 1;
            this.txtUpdateTime.Text = " - / - / - -:-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "最后更新：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMessage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 62);
            this.panel3.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Black;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtMessage.ForeColor = System.Drawing.Color.Red;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(296, 62);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "没有节目";
            this.txtMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LEDScreenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel1);
            this.Name = "LEDScreenControl";
            this.Size = new System.Drawing.Size(296, 132);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label txtUpdateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
