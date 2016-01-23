using LoowooTech.LEDFlow.Common;
using LoowooTech.LEDFlow.Data;
using LoowooTech.LEDFlow.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LoowooTech.LEDFlow.Server
{
    public delegate void Action();

    public delegate void Action<T>(T t);

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            OpenService();
            AutoPlayService.Instance.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }

        private static void OpenService()
        {
            var servicePort = 0;
            if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["ServicePort"], out servicePort))
            {
                servicePort = 8080;
            }
            var channel = new TcpServerChannel(servicePort);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LEDService), "LEDService", WellKnownObjectMode.SingleCall);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            LogHelper.WriteLog(ex);
            MessageBox.Show("程序出错\n" + ex.Message);
        }

    }

}
