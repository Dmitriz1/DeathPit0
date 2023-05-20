using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class ShellShot
    {
        public string direction = "up";
        public int ballLeft;
        public int ballTop;

<<<<<<< HEAD
        private readonly int speed = 20;
        private PictureBox drob = new ();
=======
        private readonly int speed = 10;
        private PictureBox ball = new ();
>>>>>>> f7e709feb91dd9f352d29d02b9073873caa0db69
        private Timer ballTimer = new ();


        public void MakeSGball(Form form)
        {
<<<<<<< HEAD
            drob.BackColor = Color.Yellow;
            drob.Size = new Size(20, 20);
            drob.Tag = "ball";
            drob.Left = ballLeft;
            drob.Top = ballTop;
            drob.BringToFront();
=======
            ball.BackColor = Color.DarkGray;
            ball.Size = new Size(20, 20);
            ball.Tag = "ball";
            ball.Left = ballLeft;
            ball.Top = ballTop;
            ball.BringToFront();
>>>>>>> f7e709feb91dd9f352d29d02b9073873caa0db69

            form.Controls.Add(drob);

            ballTimer.Interval = speed;
            ballTimer.Tick += new EventHandler(BallTimerEvent);
            ballTimer.Start();
        }

        private void BallTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                drob.Left -= speed;
            }
            if (direction == "right")
            {
                drob.Left += speed;
            }
            if (direction == "up")
            {
                drob.Top -= speed;
            }
            if (direction == "down")
            {
                drob.Top += speed;
            }

            if (drob.Left < 0 || drob.Left > 1920 || drob.Top < 0 || drob.Top > 1080)
            {
                ballTimer.Stop();
                ballTimer.Dispose();
                drob.Dispose();
                ballTimer = null;
                drob = null;
            }
        }

    }
}
