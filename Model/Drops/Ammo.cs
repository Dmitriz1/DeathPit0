using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest.Model.Drops
{
    internal class Ammo : PictureBox
    {
        Random r = new Random();
        public Ammo(GameForm gf)
        {
            Tag = "ammo";
            Image = Properties.Resources.ammo;
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
