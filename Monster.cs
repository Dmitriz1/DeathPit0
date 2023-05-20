using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class Monster : PictureBox
    {
        Random r = new Random();
        public Monster()
        {
            this.Tag = "monster";
            this.Left = r.Next(500, 900);
            this.Top = r.Next(200, 800);
            this.Image = Properties.Resources.zdown;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
