using HohoemiCommunicationLib;
using System;
using System.IO;

namespace Hohoemi.ViewModel
{
    public class HohoemiClientSenderViewModel
    {
        public event EventHandler<string> OnMessageArrived = delegate { };

        private readonly ICommunicator comm;

        public HohoemiClientSenderViewModel()
        {
            comm = CommunicatorFactory.Create();
            comm.OnMessageArrived += Notify;
            comm.Connect();
        }

        private void Notify(object sender, MessageArrivedArgs e)
        {
            // 今のところこのアプリでは使わない。コメントのリストとか見たくなったらここを実装
        }

        public bool Send(string user, string message)
        {
            // 今のバージョンはユーザ名はPCからとってくる
            user = Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            return comm.Send(user, message) > 0;
        }

        public void Disconnect()
        {
            try
            {
                OnMessageArrived = delegate { }; // これ以上通知がいかないようにする
                comm.Disconnect();
            }
            catch
            {
                // もう終わるし、、、何もしない(◞‸◟)
            }
        }
    }
}
