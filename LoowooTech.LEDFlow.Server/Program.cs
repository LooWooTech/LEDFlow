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
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            OpenService();
            OpenLEDs();
            AutoPlay();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            StopPlay();
        }

        public static void StopPlay()
        {
            if (_playThread != null)
            {
                _playThread.Abort();
                _playThread = null;
            }
        }

        private static Thread _playThread;
        /// <summary>
        /// 自动播放只播放定时播放的节目，立即播放的节目会在创建后立即播放，每隔一分钟查询一次排期。
        /// </summary>
        private static void AutoPlay()
        {
            //_playThread = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        LEDService.PlayAllLED();
            //        Thread.Sleep(1000 * 60);
            //    }
            //});
            //_playThread.Start();
        }

        private static void OpenService()
        {
            var servicePort = 0;
            if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["ServicePort"], out servicePort))
            {
                servicePort = 8080;
            }
            var channel = new TcpServerChannel(servicePort);
            ChannelServices.RegisterChannel(channel, true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LEDService), "LEDService", WellKnownObjectMode.SingleCall);
        }

        private static void OpenLEDs()
        {
            var list = LEDManager.GetList();
            foreach(var item in list)
            {
                LEDService.OpenLED(item);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            var content = new StringBuilder();
            content.AppendLine(ex.Message);
            content.AppendLine(ex.StackTrace);
            File.WriteAllText(Path.Combine(logPath, ex.GetType().Name + DateTime.Now.Ticks.ToString() + ".txt"), content.ToString());
        }

    }

}
