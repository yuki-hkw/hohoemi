using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hohoemi.View
{
    class HohoemiStraightPictureBox : HohoemiPictureBox
    {
        string type;
        int a;

        public HohoemiStraightPictureBox(string[] cmd, int Width, int Height)
        {
            System.Resources.ResourceManager resource = HohoemiClientViewer.Properties.Resources.ResourceManager;
            type = cmd[0];
            Bitmap bmp = (Bitmap)resource.GetObject(cmd[0]);

            Random r = new Random();
            a = r.Next(-5, 5);
            if (a == 0)
            {
                a = 6;
            }

            Image = bmp;
            SizeMode = PictureBoxSizeMode.AutoSize;
            Location = new Point(0, r.Next(0, Height));
            if (cmd.Length > 1)
            {
                try
                {
                    throws = Int32.Parse(cmd[1]);
                    if (throws > 10)
                    {
                        throws = 10;
                    }
                }
                catch (FormatException)
                {
                    //数値じゃないときは何もしない
                }
            }
        }

        public override bool CheckRemove(int Width, int Height)
        {
            if (throws > 0)
            {
                return false;
            }
            if ((this.Location.X > Width) || (this.Location.Y > Height))
            {
                return true;
            }

            return false;
        }

        public override HohoemiPictureBox Draw(int Width, int Height)
        {
            HohoemiPictureBox pictureBox = null;
            Location = new Point(Location.X + PIC_FLOW_SPEED, Location.Y + PIC_FLOW_SPEED / a);
            if (throws > 0)
            {
                if (throwCount-- < 0)
                {
                    pictureBox = new HohoemiStraightPictureBox(new string[] { this.type }, Width, Height);
                    throws--;
                    throwCount = THROW_INTERVAL;
                }
            }
            return pictureBox;
        }
    }
}
