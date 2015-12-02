using LoowooTech.LEDFlow.Data;
using LoowooTech.LEDFlow.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Server
{
    public partial class EditLEDScreenForm : Form
    {
        public EditLEDScreenForm()
        {
            InitializeComponent();
        }

        private int _ledId;

        public void BindData(int ledId = 0)
        {
            _ledId = ledId;

            var clients = DataManager.Instance.GetList<Model.Client>();
            var clientDataSource = new List<string>();
            foreach (var c in clients)
            {
                clientDataSource.Add(c.Name);
            }

            lstClient.DataSource = clientDataSource;

            cbxFontFamily.DataSource = Enum.GetNames(typeof(Model.FontFamily));
            cbxTextAlignment.DataSource = Enum.GetNames(typeof(Model.TextAlignment));
            cbxTextAnimation.DataSource = Enum.GetNames(typeof(Model.TextAnimation));

            var model = LEDManager.GetModel(ledId) ?? new Model.LEDScreen();
            txtName.Text = model.Name;
            txtWidth.Text = model.Width.ToString();
            txtHeight.Text = model.Height.ToString();
            cbxFontFamily.Text = model.DefaultStyle.FontFamily.ToString();
            txtFontSize.Text = model.DefaultStyle.FontSize.ToString();
            cbxTextAlignment.Text = model.DefaultStyle.TextAlignment.ToString();
            cbxTextAnimation.Text = model.DefaultStyle.TextAnimation.ToString();
            if (model.Clients != null)
            {
                for (var i = 0; i < lstClient.Items.Count; i++)
                {
                    lstClient.SetSelected(i, false);
                    var item = lstClient.Items[i].ToString();
                    foreach (var name in model.Clients)
                    {
                        if(name == item)
                        {
                            lstClient.SetSelected(i, true);
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var model = LEDManager.GetModel(_ledId) ?? new Model.LEDScreen();
            model.Name = txtName.Text;
            if (string.IsNullOrEmpty(model.Name))
            {
                txtName.Focus();
                return;
            }

            model.Width = StringHelper.ToInt(txtWidth.Text);
            if (model.Width == 0)
            {
                txtWidth.Focus();
                return;
            }

            model.Height = StringHelper.ToInt(txtHeight.Text);
            if (model.Height == 0)
            {
                txtHeight.Focus();
                return;
            }
            var clients = new List<string>();
            foreach(var item in lstClient.SelectedItems)
            {
                clients.Add(item.ToString());
            }
            if(clients.Count == 0)
            {
                MessageBox.Show("没有指定客户端");
                return;
            }
            model.Clients = clients.ToArray();
            model.DefaultStyle.FontFamily = StringHelper.ToEnum<Model.FontFamily>(cbxFontFamily.Text);
            model.DefaultStyle.FontSize = StringHelper.ToInt(txtFontSize.Text);
            if (model.DefaultStyle.FontSize == 0)
            {
                txtFontSize.Focus();
                return;
            }
            model.DefaultStyle.TextAlignment = StringHelper.ToEnum<Model.TextAlignment>(cbxTextAlignment.Text);
            model.DefaultStyle.TextAnimation = StringHelper.ToEnum<Model.TextAnimation>(cbxTextAnimation.Text);

            LEDManager.Save(model);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
