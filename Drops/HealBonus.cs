using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest.Drops
{
    internal class HealBonus : PictureBox
    {
        Random r = new Random();
        public HealBonus(GameForm gf)
        {
            Tag = "heal";
            Image = Properties.Resources.Heal;
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
