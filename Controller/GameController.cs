using DeathPitTest.Model.MonstersAndHero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest.Controller
{
    internal class GameController
    {
        public void MakeZombie(GameForm form, List<Monster> monsterUnitList, PictureBox Player)
        {
            Monster monster = new();

            monsterUnitList.Add(monster);
            form.Controls.Add(monster);

            Player.BringToFront();
        }

        public void GameCompleted(GameForm form)
        {
            form.Close();
            MessageBox.Show("Победа!!!", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            FormMenu.IsClosedGame = true;
        }

        public void GameOver(GameForm form)
        {
            form.Close();
            MessageBox.Show("Обнулён", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            FormMenu.IsClosedGame = true;
        }

        public void LevelCompleted(GameForm form, Timer gameTimer)
        {
            form.levelCount++;
            gameTimer.Stop();

            foreach (Control j in form.Controls)
            {
                if (j is PictureBox && (string)j.Tag == "bullet")
                {
                    RemoveElementFromForm(form, j);
                }
            }
        }

        public void RestartGame(GameForm form, List<Monster> monsterUnitList, PictureBox Player, Font font, PictureBox spawn, int BossHealth)
        {
            foreach (Monster i in monsterUnitList)
                form.Controls.Remove(i);

            monsterUnitList.Clear();

            if (form.levelCount == 1 || form.levelCount == 2)
                for (int i = 0; i < 3; i++)
                    MakeZombie(form, monsterUnitList, Player);

            if (form.levelCount == 3) MakeBoss(form, font, spawn, BossHealth, Player);
        }

        private void MakeBoss(GameForm form, Font font, PictureBox spawn, int BossHealth, PictureBox Player)
        {
            var boss = new Boss();
            form.Boss = boss;
            form.Controls.Add(boss);

            var bossHP = new Label
            {
                Text = "Здоровье босса: ",
                Font = font,
                AutoSize = true,
                Location = new Point(spawn.Right, 0)
            };
            ProgressBar BossHP = new ProgressBar
            {
                Maximum = BossHealth,
                Value = BossHealth,
                Width = form.Width / 2,
                Height = Properties.Resources.Heal.Height,
                Location = new Point(bossHP.Right + 30, 0)
            };

            form.BossHP = BossHP;
            form.Controls.Add(bossHP);
            form.Controls.Add(BossHP);
            bossHP.BringToFront();
            BossHP.BringToFront();
            Player.BringToFront();
        }

        private static void RemoveElementFromForm(Form form, Control c)
        {
            form.Controls.Remove(c);
            ((PictureBox)c).Dispose();
        }
    }
}
