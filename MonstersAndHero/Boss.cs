using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest.MonstersAndHero
{
    internal class Boss : PictureBox
    {
        readonly Random r = new();
        public Boss()
        {
            Tag = "boss";
            Left = r.Next(500, 900);
            Top = r.Next(200, 800);
            Image = Properties.Resources.BossD;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
