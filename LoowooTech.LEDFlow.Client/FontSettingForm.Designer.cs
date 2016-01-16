namespace LoowooTech.LEDFlow.Client
{
    partial class FontSettingForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxTextAnimation = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxTextAlignment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxFontFamily = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxIsHold = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(167, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(72, 201);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxTextAnimation
            // 
            this.cbxTextAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTextAnimation.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTextAnimation.FormattingEnabled = true;
            this.cbxTextAnimation.Location = new System.Drawing.Point(100, 91);
            this.cbxTextAnimation.Name = "cbxTextAnimation";
            this.cbxTextAnimation.Size = new System.Drawing.Size(121, 28);
            this.cbxTextAnimation.TabIndex = 32;
            this.cbxTextAnimation.TextChanged += new System.EventHandler(this.cbxTextAnimation_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "播放动画";
            // 
            // cbxTextAlignment
            // 
            this.cbxTextAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTextAlignment.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxTextAlignment.FormattingEnabled = true;
            this.cbxTextAlignment.Location = new System.Drawing.Point(100, 131);
            this.cbxTextAlignment.Name = "cbxTextAlignment";
            this.cbxTextAlignment.Size = new System.Drawing.Size(121, 28);
            this.cbxTextAlignment.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "对齐方式";
            // 
            // txtFontSize
            // 
            this.txtFontSize.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFontSize.Location = new System.Drawing.Point(100, 53);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(52, 26);
            this.txtFontSize.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "字体大小";
            // 
            // cbxFontFamily
            // 
            this.cbxFontFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFontFamily.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFontFamily.FormattingEnabled = true;
            this.cbxFontFamily.Location = new System.Drawing.Point(100, 14);
            this.cbxFontFamily.Name = "cbxFontFamily";
            this.cbxFontFamily.Size = new System.Drawing.Size(121, 28);
            this.cbxFontFamily.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "选择字体";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "是否停顿";
            // 
            // cbxIsHold
            // 
            this.cbxIsHold.AutoSize = true;
            this.cbxIsHold.Location = new System.Drawing.Point(100, 170);
            this.cbxIsHold.Name = "cbxIsHold";
            this.cbxIsHold.Size = new System.Drawing.Size(36, 16);
            this.cbxIsHold.TabIndex = 34;
            this.cbxIsHold.Text = "是";
            this.cbxIsHold.UseVisualStyleBackColor = true;
            this.cbxIsHold.CheckedChanged += new System.EventHandler(this.cbxIsHold_CheckedChanged);
            // 
            // FontSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 237);
            this.Controls.Add(this.cbxIsHold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTextAnimation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxTextAlignment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxFontFamily);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FontSettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "播放字体设置";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxTextAnimation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxTextAlignment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxFontFamily;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxIsHold;
    }
}