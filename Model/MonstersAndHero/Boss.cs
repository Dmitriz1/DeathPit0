using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest.Model.MonstersAndHero
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
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
