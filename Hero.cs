using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class Hero : PictureBox
    {
        public Hero()
        {
            this.Tag = "Player";
            this.Image = Properties.Resources.HeroPistolUp;
            this.Top = 275;
            this.Left = 124;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
