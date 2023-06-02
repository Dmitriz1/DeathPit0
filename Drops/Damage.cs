using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest.Drops
{
    internal class Damage : PictureBox
    {
        Random r = new Random();
        public Damage(GameForm gf)
        {
            Tag = "damage";
            Image = Properties.Resources.damage;
            SizeMode = PictureBoxSizeMode.AutoSize;
            Left = r.Next(10, gf.ClientSize.Width - Width);
            Top = r.Next(60, gf.ClientSize.Height - Height);

            if (!gf.Controls.Contains(this))
            {
                gf.Controls.Add(this);
            }
        }
    }
}
