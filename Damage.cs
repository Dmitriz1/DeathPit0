using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class Damage : PictureBox
    {
        Random r = new Random();
        public Damage(GameForm gf)
        {
            this.Tag = "damage";
            this.Image = Properties.Resources.damage;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Left = r.Next(10, gf.ClientSize.Width - this.Width);
            this.Top = r.Next(60, gf.ClientSize.Height - this.Height);

            if (!gf.Controls.Contains(this))
            {
                gf.Controls.Add(this);
            }
        }
    }
}
