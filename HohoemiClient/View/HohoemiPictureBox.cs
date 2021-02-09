using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hohoemi.View
{
    public static class HohoemiPictureBoxType
    {
        public static readonly Dictionary<string, string> ClassName
            = new Dictionary<string, string>
            {
                { "stone", "Hohoemi.View.HohoemiThrowPictureBox" },
                { "trash", "Hohoemi.View.HohoemiThrowPictureBox" },
                { "zoku", "Hohoemi.View.HohoemiFixedPictureBox" },
                { "ogre", "Hohoemi.View.HohoemiFixedPictureBox" },
                { "crab", "Hohoemi.View.HohoemiStraightPictureBox" },
            };

    }
    public abstract class HohoemiPictureBox : PictureBox
    {
        protected const int PIC_FLOW_SPEED = 20; /* px/timer_tick*/
        protected const int THROW_INTERVAL = 15;
        protected int throws = 0;
        protected int throwCount = THROW_INTERVAL;


        public abstract bool CheckRemove(int Width, int Height);
        public abstract HohoemiPictureBox Draw(int Width, int Height);

    }
}
