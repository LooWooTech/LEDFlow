using LoowooTech.LEDFlow.Data;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
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
            ChannelServices.RegisterChannel(new TcpClientChannel(), true);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static LEDService GetServiceClient()
        {
            return (LEDService)Activator.GetObject(typeof(LEDService), System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"]);
        }
    }
}
