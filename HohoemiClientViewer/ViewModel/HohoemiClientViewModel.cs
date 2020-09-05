using HohoemiCommunicationLib;
using System;
using System.IO;


namespace Hohoemi.ViewModel
{
    public class HohoemiClientViewModel
    {
        public static event EventHandler<string> OnMessageArrived = delegate { };

        private readonly static HohoemiClientViewModel _self = new HohoemiClientViewModel();

        private ICommunicator _comm;

        private HohoemiClientViewModel()
        {
        }

        public static void Init()
        {
            _self._comm = CommunicatorFactory.Create();
            _self._comm.OnMessageArrived += _self.Notify;
            _self._comm.Connect();
        }

        private void Notify(object sender, MessageArrivedArgs e)
        {
            // 今のところsenderは使わない
            if (!string.IsNullOrWhiteSpace(e.Message))
            {
                OnMessageArrived(this, e.Message);
            }
        }

        public static void Disconnect()
        {
            try
            {
                OnMessageArrived = delegate { }; // これ以上通知がいかないようにする
                _self._comm.Disconnect();
            }
            catch
            {
                // もう終わるし、、、何もしない(◞‸◟)
            }
        }


        public static bool Send(string user, string message)
        {
            // 今のバージョンはユーザ名はPCからとってくる
            user = Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            return _self._comm.Send(user, message) > 0;
        }
    }
}
