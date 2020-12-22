using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hohoemi.ViewModel
{
    public static class ScreenViewModel
    {
        public static Screen Selected { private set; get; } = Screen.PrimaryScreen;

        public static event Action<Screen> OnSelectedScreenChanged = delegate { };

    public static int SelectedIndex
        {
            get
            {
                int i = 0;

                for (; i < Screen.AllScreens.Length; ++i)
                {
                    if(Screen.AllScreens[i].DeviceName.Equals(Selected.DeviceName))
                    {
                        break;
                    }
                }

                return i;
            }

            set
            {
                Selected = Screen.AllScreens[value];

                OnSelectedScreenChanged(Selected);
            }
        }

        public static string[] DisplayNames 
        { 
            get
            {
                return (from s in Screen.AllScreens select s.DeviceName).ToArray();
            }
        }

        public static string ScreenDescription
        { 
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Width  = {Selected.Bounds.Width}");
                sb.AppendLine($"Height = {Selected.Bounds.Height}");
                return sb.ToString();
            }
        }
    }
}
