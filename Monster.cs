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
        Random random = new Random();
        public Monster()
        {
            this.Tag = "monster";
            this.Left = random.Next(500, 900);
            this.Top = random.Next(200, 800);
            this.Image = Properties.Resources.zdown;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
