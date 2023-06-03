using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DeathPitTest.Model.MonstersAndHero
{
    internal class Monster : PictureBox
    {
        Random r = new Random();
        public Monster()
        {
            Tag = "monster";
            Left = r.Next(500, 900);
            Top = r.Next(200, 800);
            Image = Properties.Resources.zdown;
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
