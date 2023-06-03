using DeathPitTest.Model.Shots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class ShootingController
    {
        public void ShootBullet(string direction, PictureBox Player, GameForm gf)
        {
            Bullet shootBullet = new()
            {
                direction = direction,
                bulletLeft = Player.Left + (Player.Width / 2),
                bulletTop = Player.Top + (Player.Height / 2)
            };
            shootBullet.MakeBullet(gf);

            Shoot(gf);
        }

        public void ShootDrob(string direction, PictureBox Player, GameForm gf)
        {
            ShellShot shootDrob = new()
            {
                direction = direction,
                ballLeft = Player.Left + (Player.Width / 2),
                ballTop = Player.Top + (Player.Height / 2)
            };
            shootDrob.MakeSGball(gf);
            Shoot(gf);
        }

        public int Shoot(GameForm gf)
        {
            gf.HeroAmmoLvl1 -= 1;

            if (gf.HeroAmmoLvl1 <= 1)
                gf.canDropAmmo = true;

            return gf.HeroAmmoLvl1;
        }
    }
}
