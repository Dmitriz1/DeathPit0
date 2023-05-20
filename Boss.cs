using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class Boss : PictureBox
    {
        readonly Random r = new ();
        public Boss()
        {
            this.Tag = "boss";
            this.Left = r.Next(500, 900);
            this.Top = r.Next(200, 800);
            this.Image = Properties.Resources.BossD;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
