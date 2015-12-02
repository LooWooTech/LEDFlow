using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LoowooTech.LEDFlow.Model;

namespace LoowooTech.LEDFlow.Client
{
    public partial class LEDScreenControl : UserControl
    {
        public LEDScreenControl()
        {
            InitializeComponent();
        }

        public LEDScreenControl(LEDScreen model)
            : this()
        {
            LedID = model.ID;
            txtName.Text = model.Name;
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

        private void txtMessage_Click(object sender, EventArgs e)
        {
            foreach(LEDScreenControl c in this.Parent.Controls)
            {
                c.Unselecte();
            }
            Select();
        }

        public int LedID { get; private set; }
    }
}
