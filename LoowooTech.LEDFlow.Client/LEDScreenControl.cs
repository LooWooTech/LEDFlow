﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Model;
using System.Threading;
using Newtonsoft.Json.Serialization;

namespace LoowooTech.LEDFlow.Client
{
    public partial class LEDScreenControl : UserControl
    {
        private Thread _updater;
        public LEDScreenControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public LEDScreenControl(LEDScreen model)
            : this()
        {
            LedID = model.ID;
            txtName.Text = model.Name;
            _updater = new Thread(() =>
            {
                var client = Program.GetServiceClient();
                while (true)
                {
                    var program = client.GetCurrentProgram(LedID);
                    PlayProgram(program);
                }
            });
            _updater.Start();
        }

        private void PlayProgram(Model.Program program)
        {
            if (program == null)
            {
                Thread.Sleep(1000);
                return;
            }
            foreach (var msg in program.Messages)
            {
                txtMessage.Invoke(new Action(() =>
                {
                    txtMessage.Text = msg.Content;
                    txtUpdateTime.Text = DateTime.Now.ToString();
                }));

                Thread.Sleep(GetHoldTime() * 1000);
            }
        }

        private int GetHoldTime()
        {
            var holdTime = 0;
            if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["HoldTime"], out holdTime))
            {
                return holdTime;
            }
            return 5;
        }

        public bool Selected { get; private set; }

        public new void Select()
        {
            Selected = true;
            this.BackColor = Color.Green;
        }
        public void Unselecte()
        {
            Selected = false;
            this.BackColor = Color.Transparent;
        }

        public void Stop()
        {
            if (_updater != null)
            {
                _updater.Abort();
            }
        }

        private void txtMessage_Click(object sender, EventArgs e)
        {
            foreach (LEDScreenControl c in this.Parent.Controls)
            {
                c.Unselecte();
            }
            Select();
        }

        public int LedID { get; private set; }
    }
}
