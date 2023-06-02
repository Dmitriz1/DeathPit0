using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DeathPitTest.MonstersAndHero
{
    internal class Hero : PictureBox
    {
        public Hero()
        {
            Tag = "Player";
            Image = Properties.Resources.HeroPistolUp;
            Top = 275;
            Left = 124;
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
