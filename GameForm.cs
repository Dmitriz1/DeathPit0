using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    public partial class GameForm : Form
    {
        string facing = "up";
        bool goUp, goDown, goLeft, goRight;

        int monsterUnitSpeed = 3;
        int targetCount = 25;

        private int HeroHP = 300;
        private readonly int HeroSpeed = 10;
        private int HeroAmmo = 20;
        private int HeroDamage = 2;

        bool canDropAmmo = false;
        bool canDropHeal = true;
        bool canDropDamage = true;

        bool HeroIsShooting = false;

        int levelCount = 1;

        readonly List<Monster> monsterUnitList = new();
        readonly int MonsterDmg = 1;
        private int BossHealth = 200;
        private ProgressBar BossHP;

        public GameForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            Player.Image = Properties.Resources.HeroPistolUp;
            pictureBoxWeapon.Image = Properties.Resources.Pistol;

            RestartGame();
        }
        private void MakeZombie()
        {
            Monster monster = new();

            monsterUnitList.Add(monster);
            Controls.Add(monster);

            Player.BringToFront();
        }

        private void MakeBoss()
        {
            var boss = new Boss();
            Controls.Add(boss);

            var bossHP = new Label
            {
                Text = "Здоровье босса: ",
                Font = labelAmmo.Font,
                AutoSize = true,
                Location = new Point(pictureBoxWeapon.Right, 0)
            };
            BossHP = new ProgressBar
            {
                Maximum = BossHealth,
                Value = BossHealth,
                Width = Width,
                Height = Properties.Resources.Heal.Height,
                Location = new Point(bossHP.Right + 10, 0)
            };
            ShortPath.FindPath(boss.Location, Player.Location);
            Controls.Add(bossHP);
            Controls.Add(BossHP);
            bossHP.BringToFront();
            BossHP.BringToFront();

            Player.BringToFront();
        }
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
            }

            GetSight(goUp, goDown, goLeft, goRight);
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            labelAmmo.Text = $"Аммуниция: {HeroAmmo}";
            labelScore.Text = $"Цель: {targetCount}";


            if (goUp && Player.Top > pictureBoxWeapon.Width)
            {
                Health(HeroHP);
                Player.Top -= HeroSpeed;
            }

            if (goDown && Player.Top + Player.Height < ClientSize.Height)
            {
                Health(HeroHP);
                Player.Top += HeroSpeed;
            }

            if (goLeft && Player.Left > 0)
            {
                Health(HeroHP);
                Player.Left -= HeroSpeed;
            }

            if (goRight && Player.Left + Player.Width < ClientSize.Width)
            {
                Health(HeroHP);
                Player.Left += HeroSpeed;
            }

            foreach (Control x in Controls)
            {
                if (x is Ammo)
                {
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveElementFromForm(this, x);
                        HeroAmmo += 12;
                    }
                }

                if (x is HealBonus)
                {
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveElementFromForm(this, x);
                        HeroHP += 50;
                        canDropHeal = true;
                    }
                }

                if (x is Damage)
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveElementFromForm(this, x);
                        HeroDamage *= 2;
                        canDropDamage = true;
                    }

                if ((x is Monster || x is Boss) && ((string)x.Tag == "monster" || (string)x.Tag == "boss"))
                {

                    if ((string)x.Tag == "monster" && Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        HeroHP -= MonsterDmg;
                        Health(HeroHP);
                    }

                    if ((string)x.Tag == "boss" && Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        HeroHP -= MonsterDmg * 5;
                        Health(HeroHP);
                    }
                    if (x.Left > Player.Left)
                    {
                        x.Left -= monsterUnitSpeed;
                        if ((string)x.Tag == "monster") ((PictureBox)x).Image = Properties.Resources.zleft;
                        if ((string)x.Tag == "boss") ((PictureBox)x).Image = Properties.Resources.BossL;
                    }
                    if (x.Left < Player.Left)
                    {
                        x.Left += monsterUnitSpeed;
                        if ((string)x.Tag == "monster") ((PictureBox)x).Image = Properties.Resources.zright;
                        if ((string)x.Tag == "boss") ((PictureBox)x).Image = Properties.Resources.BossR;
                    }
                    if (x.Top > Player.Top)
                    {
                        x.Top -= monsterUnitSpeed;
                        if ((string)x.Tag == "monster") ((PictureBox)x).Image = Properties.Resources.zup;
                        if ((string)x.Tag == "boss") ((PictureBox)x).Image = Properties.Resources.BossU;
                    }
                    if (x.Top < Player.Top)
                    {
                        x.Top += monsterUnitSpeed;
                        if ((string)x.Tag == "monster") ((PictureBox)x).Image = Properties.Resources.zdown;
                        if ((string)x.Tag == "boss") ((PictureBox)x).Image = Properties.Resources.BossD;
                    }
                }

                foreach (Control j in Controls)
                {
                    if (j is PictureBox && ((string)j.Tag == "bullet" || (string)j.Tag == "ball") && (x is Monster && (string)x.Tag == "monster" || x is Boss && (string)x.Tag == "boss"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds) && (levelCount == 1 || levelCount == 2))
                        {
                            targetCount--;
                            if (targetCount == 0) LevelCompleted();

                            RemoveElementFromForm(this, j);
                            RemoveElementFromForm(this, x);

                            monsterUnitList.Remove((Monster)x);

                            MakeZombie();
                        }

                        if (x.Bounds.IntersectsWith(j.Bounds) && (string)x.Tag == "boss")
                        {
                            BossHealth -= HeroDamage;
                            BossHP.Value -= HeroDamage;
                            targetCount = BossHealth;

                            if (BossHealth <= 0) GameCompleted();


                            RemoveElementFromForm(this, j);
                        }
                    }
                }
            }
        }

        private void RemoveElementFromForm(Form form, Control c)
        {
            form.Controls.Remove(c);
            ((PictureBox)c).Dispose();
        }

        //Нажатие кнопок
        private async void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Space && HeroAmmo > 0)
            {
                if (levelCount == 1)
                {
                    ShootBullet(facing);
                }

                if (levelCount == 2)
                {
                    if (HeroAmmo >= 3 && !HeroIsShooting)
                    {
                        HeroIsShooting = true;
                        for (int i = 0; i < 3; i++)
                        {
                            ShootBullet(facing);
                            await Task.Delay(200);
                        }
                        HeroIsShooting = false;
                    }
                }

                if (levelCount == 3)
                {
                    if (HeroAmmo >= 2 && !HeroIsShooting)
                    {
                        HeroIsShooting = true;
                        for (int i = 0; i < 2; i++)
                        {
                            ShootDrob(facing);
                            await Task.Delay(i * 400 + 400);
                        }
                        HeroIsShooting = false;
                    }
                }
            }

            if (e.KeyCode == Keys.R)
            {
                if (HeroAmmo == 0 && canDropAmmo)
                {
                    DropAmmo();
                    canDropAmmo = false;
                }
            }

            if (e.KeyCode == Keys.H)
            {
                if (HeroHP != 0 && HeroHP < 100 && canDropHeal)
                {
                    DropHeal();
                    canDropHeal = false;
                }
            }

            if (e.KeyCode == Keys.G)
            {
                if (HeroDamage == 2 && levelCount == 3 && canDropDamage)
                {
                    DropDamage();
                    canDropDamage = false;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                GameTimer.Enabled = false;

                var p1 = new PauseForm();

                if (p1.ShowDialog() != DialogResult.OK)
                {
                    GameTimer.Enabled = true;
                    if (PauseForm.clickedExitButton)
                    {
                        p1.Close();
                        this.Close();
                    }
                }
            }
        }
        //Завершение уровня
        private void LevelCompleted()
        {
            levelCount++;
            GameTimer.Stop();

            foreach (Control j in Controls)
            {
                if (j is PictureBox && ((string)j.Tag == "bullet"))
                {
                    RemoveElementFromForm(this, j);
                }
            }
            MessageBox.Show("Вы прошли уровень!", "Поздравляем", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if (levelCount == 2)
            {
                targetCount += 50;
                HeroAmmo = 36;
                monsterUnitSpeed = 5;
                pictureBoxWeapon.Image = Properties.Resources.Auto;
            }
            else if (levelCount == 3)
            {
                targetCount += 1;
                HeroAmmo = 44;
                monsterUnitSpeed = 3;
                pictureBoxWeapon.Image = Properties.Resources.Shotgun;
            }
            else
                GameCompleted();

            RestartGame();
        }
        //Завершение игры
        private void GameCompleted()
        {
            Close();
            MessageBox.Show("Победа!!!", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            FormMenu.IsClosedGame = true;
        }

        private void GameOver()
        {
            Close();
            MessageBox.Show("Обнулён", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            FormMenu.IsClosedGame = true;
        }

        private void RestartGame()
        {
            foreach (Monster i in monsterUnitList)
            {
                Controls.Remove(i);
            }

            //foreach (Boss i in)

            monsterUnitList.Clear();
            if (levelCount == 1 || levelCount == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    MakeZombie();
                }
            }
            else MakeBoss();

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;

            GameTimer.Start();
        }

        private void Health(int hp)
        {
            if (hp == 0)
            {
                pictureBoxHealth1.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
                GameTimer.Enabled = false;
                GameOver();
            }
            if (hp >= 50 && hp < 100)
            {
                pictureBoxHealth1.Image = Properties.Resources.halfHurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 100 && hp < 150)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 150 && hp < 200)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.halfHurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 200 && hp < 250)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.fullHurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 250 && hp < 300)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.fullHurt;
                pictureBoxHealth3.Image = Properties.Resources.halfHurt;
            }
            if (hp == 300)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.fullHurt;
                pictureBoxHealth3.Image = Properties.Resources.fullHurt;
            }
        }

        private void GetSight(bool up, bool down, bool left, bool right)
        {
            if (up)
            {
                Player.Width = 64;
                Player.Height = 86;

                switch (levelCount)
                {
                    case 1:
                        Player.Image = Properties.Resources.HeroPistolUp;
                        break;
                    case 2:
                        Player.Image = Properties.Resources.HeroAutoUp;
                        break;
                    case 3:
                        Player.Image = Properties.Resources.HeroShotgunUp;
                        break;
                }
            }

            if (down)
            {
                Player.Width = 64;
                Player.Height = 86;

                switch (levelCount)
                {
                    case 1:
                        Player.Image = Properties.Resources.HeroPistolDown;
                        break;
                    case 2:
                        Player.Image = Properties.Resources.HeroAutoDown;
                        break;
                    case 3:
                        Player.Image = Properties.Resources.HeroShotgunDown;
                        break;
                }
            }

            if (left)
            {
                Player.Width = 86;
                Player.Height = 64;

                switch (levelCount)
                {
                    case 1:
                        Player.Image = Properties.Resources.HeroPistolLeft;
                        break;
                    case 2:
                        Player.Image = Properties.Resources.HeroAutoLeft;
                        break;
                    case 3:
                        Player.Image = Properties.Resources.HeroShotgunLeft;
                        break;
                }
            }

            if (right)
            {
                Player.Width = 86;
                Player.Height = 64;

                switch (levelCount)
                {
                    case 1:
                        Player.Image = Properties.Resources.HeroPistolRight;
                        break;
                    case 2:
                        Player.Image = Properties.Resources.HeroAutoRight;
                        break;
                    case 3:
                        Player.Image = Properties.Resources.HeroShotgunRight;
                        break;
                }
            }
        }

        private void ShootFromAuto(string direction)
        {

        }

        private void ShootFromShotgun(string direction)
        {

        }

        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new()
            {
                direction = direction,
                bulletLeft = Player.Left + (Player.Width / 2),
                bulletTop = Player.Top + (Player.Height / 2)
            };
            shootBullet.MakeBullet(this);

            Shoot();
        }

        private void ShootDrob(string direction)
        {
            ShellShot shootDrob = new()
            {
                direction = direction,
                ballLeft = Player.Left + (Player.Width / 2),
                ballTop = Player.Top + (Player.Height / 2)
            };
            shootDrob.MakeSGball(this);
            Shoot();
        }

        private void Shoot()
        {
            HeroAmmo -= 1;

            if (HeroAmmo <= 1)
            {
                canDropAmmo = true;
            }
        }

        private void DropAmmo()
        {
            Ammo ammo = new(this);

            ammo.BringToFront();
            Player.BringToFront();
        }

        private void DropHeal()
        {
            HealBonus heal = new(this);

            heal.BringToFront();
            Player.BringToFront();
        }

        private void DropDamage()
        {
            Damage damage = new(this);

            damage.BringToFront();
            Player.BringToFront();
        }
    }
}
