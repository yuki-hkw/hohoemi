using Hohoemi.Model;

namespace Hohoemi.ViewModel
{
    public class HohoemiClientSenderViewModel
    {
        public bool Send(string user, string message)
        {
            return Communicator.Object.Send(user, message);
        }
    }
}
