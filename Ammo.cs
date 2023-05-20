using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class Ammo : PictureBox
    {
        Random random = new Random();
        public Ammo(GameForm gf)
        {
            this.Tag = "ammo";
            this.Image = Properties.Resources.ammo;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Left = random.Next(10, gf.ClientSize.Width - this.Width);
            this.Top = random.Next(60, gf.ClientSize.Height - this.Height);

            if (!gf.Controls.Contains(this))
            {
                gf.Controls.Add(this);
            }
        }
    }
}
