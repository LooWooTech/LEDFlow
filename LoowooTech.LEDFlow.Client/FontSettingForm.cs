using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Client
{
    public partial class FontSettingForm : Form
    {
        static FontSettingForm()
        {
            _configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        }

        private FontSettingForm()
        {
            InitializeComponent();
        }

        private int _ledId;
        public FontSettingForm(int ledId)
            : this()
        {
            _ledId = ledId;
        }

        private static string _configPath;
        private static string GetConfigKey(int ledId)
        {
            return "font-style-" + ledId;
        }

        public static TextStyle GetTextStyle(int ledId)
        {
            if (File.Exists(_configPath))
            {
                var data = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(File.ReadAllText(_configPath));
                var key = GetConfigKey(ledId);
                if (data.ContainsKey(key))
                {
                    return data[key].ToObject<TextStyle>();
                }
            }
            return null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cbxFontFamily.DataSource = Enum.GetNames(typeof(Model.FontFamily));
            cbxTextAlignment.DataSource = Enum.GetNames(typeof(Model.TextAlignment));
            cbxTextAnimation.DataSource = Enum.GetNames(typeof(Model.TextAnimation));

            var model = GetTextStyle(_ledId);
            if(model!=null)
            {
                cbxFontFamily.Text = model.FontFamily.ToString();
                cbxTextAlignment.Text = model.TextAlignment.ToString();
                cbxTextAnimation.Text = model.TextAnimation.ToString();
                txtFontSize.Text = model.FontSize.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var model = new TextStyle();
            model.FontFamily = StringHelper.ToEnum<Model.FontFamily>(cbxFontFamily.Text);
            model.FontSize = StringHelper.ToInt(txtFontSize.Text);
            if (model.FontSize == 0)
            {
                txtFontSize.Focus();
                return;
            }
            model.TextAlignment = StringHelper.ToEnum<Model.TextAlignment>(cbxTextAlignment.Text);
            model.TextAnimation = StringHelper.ToEnum<Model.TextAnimation>(cbxTextAnimation.Text);

            Dictionary<string, object> data = null;

            if (File.Exists(_configPath))
            {
                data = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(_configPath));
            }
            if (data == null)
            {
                data = new Dictionary<string, object>();
            }
            var key = GetConfigKey(_ledId);
            if (data.ContainsKey(key))
            {
                data[key] = model;
            }
            else
            {
                data.Add(key, model);
            }
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(_configPath, json);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
