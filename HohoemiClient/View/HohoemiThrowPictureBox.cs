using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hohoemi.View
{
    class HohoemiThrowPictureBox : HohoemiPictureBox
    {
        string type;
        int a;
        int p;
        int q;
        int x;
        double y;

        public HohoemiThrowPictureBox(string[] cmd, int Width, int Height)
        {
            System.Resources.ResourceManager resource = HohoemiClientViewer.Properties.Resources.ResourceManager;
            type = cmd[0];
            Bitmap bmp = (Bitmap)resource.GetObject(cmd[0]);

            Random r = new Random();
            a = r.Next(8, 128);
            p = r.Next(0, 30);
            q = r.Next(0, 30);
            x = 0;
            y = (double)((x - p) * (x - p)) / a + q;

            Image = bmp;
            SizeMode = PictureBoxSizeMode.AutoSize;
            Location = new Point(0, (int)(y * PIC_FLOW_SPEED));
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
            x++;
            //y = (Math.Pow(x - p, 2) / a) + q;
            y = (double)((x - p) * (x - p)) / a + q;
            Location = new Point(x * PIC_FLOW_SPEED, (int)(y * PIC_FLOW_SPEED));
            if (throws > 0)
            {
                if (throwCount-- < 0)
                {
                    pictureBox = new HohoemiThrowPictureBox(new string[] { this.type }, Width, Height);
                    throws--;
                    throwCount = THROW_INTERVAL;
                }
            }
            return pictureBox;
        }
    }
}
