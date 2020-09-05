using System;
using System.Collections.Generic;
using System.Threading;

namespace HohoemiCommunicationLib.CommunicatorImpl
{
    internal class MockCommunicator : ICommunicator
    {
        public event EventHandler<MessageArrivedArgs> OnMessageArrived;

        private Timer _cyclicProc;

        public void Connect()
        {
        
        }

        public void Disconnect()
        {
            _cyclicProc.Dispose();
        }

        public void Init(Dictionary<string, string> properties)
        {
             _cyclicProc = new Timer((s)=> { Send("self", DateTime.Now.ToString()); }, null, 1000, 100);
        }

        public int Send(string sender, string message)
        {
            OnMessageArrived(this, new MessageArrivedArgs(sender, message));

            return 1;
        }
    }
}
