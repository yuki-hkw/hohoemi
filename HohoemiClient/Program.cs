using Hohoemi.View;
using System;
using System.Windows.Forms;
using Hohoemi.Model;

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
            
            try
            {
                Communicator.Object.Init();
            }
            catch
            {
                MessageBox.Show("初期化に失敗しました。" + Environment.NewLine + Environment.CurrentDirectory + "\\hohoemi.configを確認してください。");
                Application.Exit();
                return;
            }

            Application.Run(new HohoemiClientSenderView());
            Communicator.Object.Disconnect();
        }
    }
}
