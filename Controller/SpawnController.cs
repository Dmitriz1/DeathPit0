using DeathPitTest.Model.Drops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest.Controller
{
    internal class SpawnController
    {

        public void DropAmmo(GameForm form, PictureBox Player)
        {
            Ammo ammo = new(form);

            ammo.BringToFront();
            Player.BringToFront();
        }

        public void DropHeal(GameForm form, PictureBox Player)
        {
            HealBonus heal = new(form);

            heal.BringToFront();
            Player.BringToFront();
        }

        public void DropDamage(GameForm form, PictureBox Player)
        {
            Damage damage = new(form);

            damage.BringToFront();
            Player.BringToFront();
        }
    }
}
