using System;
using System.Collections.Generic;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
