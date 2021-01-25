using Hohoemi.Model;
using System;

namespace Hohoemi.ViewModel
{
    public class HohoemiClientViewModel
    {
        public event Action<string, string> OnMessageArrived = delegate { };
        public HohoemiClientViewModel()
        {
            Communicator.Object.OnMessageArrived += Notify;
        }

        private void Notify(string user, string message)
        {
            OnMessageArrived(user, message);
        }
    }
}
