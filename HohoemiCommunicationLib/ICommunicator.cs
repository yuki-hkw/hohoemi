using System;
using System.Collections.Generic;

namespace HohoemiCommunicationLib
{
    public interface ICommunicator
    {
        void Init(Dictionary<string, string> properties);

        void Connect();

        void Disconnect();

        int Send(string sender, string message);

        event EventHandler<MessageArrivedArgs> OnMessageArrived;
    }
}
