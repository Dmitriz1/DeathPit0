using DeathPitTest.MonstersAndHero;
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
        public CheckHealth(int hp, int HalfHeart, int OneHeart, int HeartAndHalf, int TwoHearts, int TwoHeartAndHalf, int ThreeHearts, PictureBox hp1, PictureBox hp2, PictureBox hp3, Timer GameTimer, Form form)
        {
            if (hp == 0)
            {
                hp1.Image = Properties.Resources.emptyhurt;
                hp2.Image = Properties.Resources.emptyhurt;
                hp3.Image = Properties.Resources.emptyhurt;
                GameTimer.Enabled = false;
                GameOver(form);
            }
            if (hp >= HalfHeart && hp < OneHeart)
            {
                hp1.Image = Properties.Resources.halfHurt;
                hp2.Image = Properties.Resources.emptyhurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= OneHeart && hp < HeartAndHalf)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.emptyhurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= HeartAndHalf && hp < TwoHearts)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.halfHurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= TwoHearts && hp < TwoHeartAndHalf)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.fullHurt;
                hp3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= TwoHeartAndHalf && hp < ThreeHearts)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.fullHurt;
                hp3.Image = Properties.Resources.halfHurt;
            }
            if (hp == ThreeHearts)
            {
                hp1.Image = Properties.Resources.fullHurt;
                hp2.Image = Properties.Resources.fullHurt;
                hp3.Image = Properties.Resources.fullHurt;
            }
        }

        public static void GameOver(Form form)
        {
            form.Close();
            MessageBox.Show("Обнулён", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            FormMenu.IsClosedGame = true;
        }
    }
}
