using LoowooTech.LEDFlow.Data;
using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Server
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                txtPassword.Focus();
                return;
            }
            new Thread(() =>
            {
                btnLogin.Invoke(new Action(() =>
                {
                    var currentUser = AdminManager.Login(username, password);
                    if (currentUser != null)
                    {
                        this.Hide();
                        var mainForm = new MainForm();
                        mainForm.Show();
                        txtUsername.Text = null;
                        txtPassword.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("找不到该账号，请检查用户名或密码");
                    }
                }));

            }).Start();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                e.Cancel = true;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoPlayService.Instance.Stop();
            Application.Exit();
            Environment.Exit(0);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (AdminManager.GetCurrentUser() != null)
            {
                return;
            }
            this.Show();
            this.WindowState = FormWindowState.Normal;

        }
    }
}
