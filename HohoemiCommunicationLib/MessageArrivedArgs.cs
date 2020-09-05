using System;

namespace HohoemiCommunicationLib
{
    public class MessageArrivedArgs : EventArgs
    {
        public string Message { get; private set; } = string.Empty;

        public string Sender { get; private set; } = string.Empty; 

        internal MessageArrivedArgs(string sender, string message)
        {
            Message = message;
            Sender = sender;
        }
    }
}   
