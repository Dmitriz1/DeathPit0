using DeathPitTest.Model.MonstersAndHero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal class CheckHealth
    {
        public CheckHealth(int hp, PictureBox hp1, PictureBox hp2, PictureBox hp3, Timer GameTimer, GameForm form)
        {
            if (hp <= 0)
            {
                hp1.Image = Properties.Resources.emptyhurt;
                hp2.Image = Properties.Resources.emptyhurt;
                hp3.Image = Properties.Resources.emptyhurt;
                GameTimer.Enabled = false;
                form.controller.GameOver(form);
            }
            if (hp >= form.HalfHeart && hp < form.OneHeart)
            {
                hp1.Image = Properties.Resources.halfHurt;
                hp2.Image = Properties.Resources.emptyhurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= form.OneHeart && hp < form.HeartAndHalf)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.emptyhurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= form.HeartAndHalf && hp < form.TwoHearts)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.halfHurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= form.TwoHearts && hp < form.TwoHeartAndHalf)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.fullHurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= form.TwoHeartAndHalf && hp < form.ThreeHearts)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.fullHurt;
                hp3.Image = Properties.Resources.halfHurt;
            }
            if (hp == form.ThreeHearts)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.fullHurt;
                hp3.Image = Properties.Resources.fullHurt;
            }
        }
    }
}
