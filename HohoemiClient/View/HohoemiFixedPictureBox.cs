using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hohoemi.View
{
    class HohoemiFixedPictureBox : HohoemiPictureBox
    {
        string type;
        int displayCount = 200;
        int x;
        int y;

        public HohoemiFixedPictureBox(string[] cmd, int Width, int Height)
        {
            System.Resources.ResourceManager resource = HohoemiClientViewer.Properties.Resources.ResourceManager;
            type = cmd[0];
            Bitmap bmp = (Bitmap)resource.GetObject(cmd[0]);

            Random r = new Random();
            x = r.Next(10, Width - 10);
            y = r.Next(10, Height - 10);

            Image = bmp;
            SizeMode = PictureBoxSizeMode.AutoSize;
            Location = new Point(x, y);
            // 連続は無効
        }

        public override bool CheckRemove(int Width, int Height)
        {
            if (displayCount-- < 0)
            {
                return true;
            }

            return false;
        }

        public override HohoemiPictureBox Draw(int Width, int Height)
        {
            return null;
        }
    }
}
