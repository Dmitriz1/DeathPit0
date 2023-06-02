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
    internal class Shooting
    {
        public void ShootBullet(string direction, PictureBox Player, int HeroAmmo, bool canDropAmmo, GameForm gf)
        {
            Bullet shootBullet = new()
            {
                direction = direction,
                bulletLeft = Player.Left + (Player.Width / 2),
                bulletTop = Player.Top + (Player.Height / 2)
            };
            shootBullet.MakeBullet(gf);

            Shoot(HeroAmmo, canDropAmmo);
        }

        public void ShootDrob(string direction, PictureBox Player, int HeroAmmo, bool canDropAmmo, GameForm gf)
        {
            ShellShot shootDrob = new()
            {
                direction = direction,
                ballLeft = Player.Left + (Player.Width / 2),
                ballTop = Player.Top + (Player.Height / 2)
            };
            shootDrob.MakeSGball(gf);
            Shoot(HeroAmmo, canDropAmmo);
        }

        public static int Shoot(int HeroAmmo, bool canDropAmmo)
        {
            HeroAmmo -= 1;

            if (HeroAmmo <= 1)
                canDropAmmo = true;

            return HeroAmmo;
        }
    }
}
