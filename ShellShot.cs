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

        private readonly int speed = 20;
        private PictureBox ball = new ();
        private Timer ballTimer = new ();


        public void MakeSGball(Form form)
        {
            ball.BackColor = Color.Yellow;
            ball.Size = new Size(20, 20);
            ball.Tag = "ball";
            ball.Left = ballLeft;
            ball.Top = ballTop;
            ball.BringToFront();

            form.Controls.Add(ball);

            ballTimer.Interval = speed;
            ballTimer.Tick += new EventHandler(BallTimerEvent);
            ballTimer.Start();
        }

        private void BallTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                ball.Left -= speed;
            }
            if (direction == "right")
            {
                ball.Left += speed;
            }
            if (direction == "up")
            {
                ball.Top -= speed;
            }
            if (direction == "down")
            {
                ball.Top += speed;
            }

            if (ball.Left < 0 || ball.Left > 1920 || ball.Top < 0 || ball.Top > 1080)
            {
                ballTimer.Stop();
                ballTimer.Dispose();
                ball.Dispose();
                ballTimer = null;
                ball = null;
            }
        }

    }
}
