using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ChannelServices.RegisterChannel(new TcpClientChannel(), false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            LogHelper.WriteLog(ex);
            MessageBox.Show("程序出错\n" + ex.Message);
        }

        public static LEDService GetServiceClient()
        {
            return (LEDService)Activator.GetObject(typeof(LEDService), System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"]);
        }
    }
}
