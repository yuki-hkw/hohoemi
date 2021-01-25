using HohoemiCommunicationLib;
using System;

namespace Hohoemi.Model
{
    // 通信周りを管理しているクラス。全画面とセッションを共有したいのでシングルトン
    public class Communicator
    {
        private ICommunicator _comm;

        public static Communicator Object
        {
            get;

            private set;
        } = new Communicator();

        private Communicator()
        {
        }

        public void Init()
        {
            _comm = CommunicatorFactory.Create();
            _comm.OnMessageArrived += Notify;
            _comm.Connect();
        }

        public event Action<string, string> OnMessageArrived = delegate { };

        private void Notify(object sender, MessageArrivedArgs e)
        {
            // 今のところsenderは使わない
            if (!string.IsNullOrWhiteSpace(e.Message))
            {
                OnMessageArrived(e.Sender, e.Message);
            }
        }

        public bool Send(string user, string message)
        {
            return _comm.Send(user, message) > 0;
        }

        public void Disconnect()
        {
            try
            {
                lock (Object)
                {
                    if (_comm != null)
                    {
                        _comm.Disconnect();
                        _comm = null;
                    }
                }
            }
            catch
            {
                // もう終わるし、、、何もしない(◞‸◟)
            }
        }
    }
}
