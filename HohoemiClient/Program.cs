using Hohoemi.View;
using System;
using System.Windows.Forms;

namespace Hohoemi
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += delegate { /* 捕まえきれなかった例外は無視 */ };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HohoemiClientSenderView());
        }
    }
}
