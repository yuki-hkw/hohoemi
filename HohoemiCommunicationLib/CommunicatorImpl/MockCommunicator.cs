using System;
using System.Collections.Generic;

namespace HohoemiCommunicationLib.CommunicatorImpl
{
    internal class MockCommunicator : ICommunicator
    {
        public event EventHandler<MessageArrivedArgs> OnMessageArrived;

        public void Connect()
        {
        
        }

        public void Disconnect()
        {
        }

        public void Init(Dictionary<string, string> properties)
        {
        }

        public int Send(string sender, string message)
        {
            OnMessageArrived(this, new MessageArrivedArgs(sender, message));

            return 1;
        }
    }
}
