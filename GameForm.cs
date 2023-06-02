﻿using DeathPitTest.Drops;
using DeathPitTest.MonstersAndHero;
using DeathPitTest.Shots;
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

        int targetCountLvl1 = 25;
        readonly int targetCountLvl2 = 50;
        readonly int targetCountLvl3 = 1;

        private readonly int Shell = 2;
        private readonly int Turn= 3;

        private int HeroHP = 300;
        private readonly int HeroSpeed = 10;
        int HeroAmmoLvl1 = 20;
        private readonly int HeroAmmoLvl2 = 36;
        private readonly int HeroAmmoLvl3 = 44;
        private int HeroDamage = 2;

        private readonly int HalfHeart = 50;
        private readonly int OneHeart = 100;
        private readonly int HeartAndHalf = 150;
        private readonly int TwoHearts = 200;
        private readonly int TwoHeartAndHalf = 250;
        private readonly int ThreeHearts = 300;

        private readonly int BoxOfBullets = 12;
        private readonly int BoxOfHp = 50;
        private readonly int BoxOfDamage = 2;

        bool canDropAmmo = false;
        bool canDropHeal = true;
        bool canDropDamage = true;
        bool HeroIsShooting = false;

        int levelCount = 1;
        readonly int firstLevel = 1;
        readonly int secondLevel = 2;
        readonly int thirdLevel = 3;

        readonly List<Monster> monsterUnitList = new();
        readonly int MonsterDmg = 1;
        int monsterSpeedFirstLvl = 3;
        readonly int monsterSpeedSecondLvl = 5;
        private readonly Boss Boss;
        readonly int BossDmg = 5;
        readonly int BossSpeed = 6;
        private int BossHealth = 200;
        private ProgressBar BossHP;

        public GameForm()
        {
            InitializeComponent();

            Player.SizeMode= PictureBoxSizeMode.AutoSize;
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
                Width = Width / 2,
                Height = Properties.Resources.Heal.Height,
                Location = new Point(bossHP.Right + 10, 0)
            };

            Controls.Add(Boss);
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
            labelAmmo.Text = $"Аммуниция: {HeroAmmoLvl1}";
            labelScore.Text = $"Цель: {targetCountLvl1}";

            if (goUp && Player.Top > pictureBoxWeapon.Width)
                Player.Top -= HeroSpeed;

            if (goDown && Player.Top + Player.Height < ClientSize.Height)
                Player.Top += HeroSpeed;

            if (goLeft && Player.Left > 0)
                Player.Left -= HeroSpeed;

            if (goRight && Player.Left + Player.Width < ClientSize.Width)
                Player.Left += HeroSpeed;

            foreach (Control x in Controls)
            {
                if (x is Ammo)
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveElementFromForm(this, x);
                        HeroAmmoLvl1 += BoxOfBullets;
                    }

                if (x is HealBonus)
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveElementFromForm(this, x);
                        HeroHP += BoxOfHp;
                        canDropHeal = true;
                    }

                if (x is Damage)
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveElementFromForm(this, x);
                        HeroDamage *= BoxOfDamage;
                        canDropDamage = true;
                    }

                if ((x is Monster || x is Boss) && ((string)x.Tag == "monster" || (string)x.Tag == "boss"))
                {
                    int[,] field = new int[100, 100];

                    if ((string)x.Tag == "monster" && Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        HeroHP -= MonsterDmg;
                        new CheckHealth(HeroHP, HalfHeart, OneHeart, HeartAndHalf, TwoHearts, TwoHeartAndHalf, ThreeHearts, pictureBoxHealth1, pictureBoxHealth2, pictureBoxHealth3, GameTimer, this);
                    }

                    if ((string)x.Tag == "boss" && Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        HeroHP -= BossDmg;
                        new CheckHealth(HeroHP, HalfHeart, OneHeart, HeartAndHalf, TwoHearts, TwoHeartAndHalf, ThreeHearts, pictureBoxHealth1, pictureBoxHealth2, pictureBoxHealth3, GameTimer, this);
                    }

                    if (x.Left > Player.Left)
                    {
                        //CheckIntersectsOfMonsters.CheckIntersectsOfMonstersByLocation(monsterUnitList, Player, monsterSpeedFirstLvl, GameTimer);
                        x.Left -= monsterSpeedFirstLvl;
                        if ((string)x.Tag == "monster")
                            ((PictureBox)x).Image = Properties.Resources.zleft;

                        if ((string)x.Tag == "boss")
                        {
                            ((PictureBox)x).Image = Properties.Resources.BossL;
                            ShortPath.FindPath(field, Boss.Location, Player.Location);
                        }
                    }

                    if (x.Left < Player.Left)
                    {
                        //CheckIntersectsOfMonsters.CheckIntersectsOfMonstersByLocation(monsterUnitList, Player, monsterSpeedFirstLvl, GameTimer);
                        x.Left += monsterSpeedFirstLvl;
                        if ((string)x.Tag == "monster") 
                            ((PictureBox)x).Image = Properties.Resources.zright;

                        if ((string)x.Tag == "boss")
                        {
                            ((PictureBox)x).Image = Properties.Resources.BossR;
                            ShortPath.FindPath(field, Boss.Location, Player.Location);
                        }
                    }

                    if (x.Top > Player.Top)
                    {
                        //CheckIntersectsOfMonsters.CheckIntersectsOfMonstersByLocation(monsterUnitList, Player, monsterSpeedFirstLvl, GameTimer);
                        x.Top -= monsterSpeedFirstLvl;
                        if ((string)x.Tag == "monster") 
                            ((PictureBox)x).Image = Properties.Resources.zup;

                        if ((string)x.Tag == "boss")
                        {
                            ((PictureBox)x).Image = Properties.Resources.BossU;
                            ShortPath.FindPath(field, Boss.Location, Player.Location);
                        }
                    }

                    if (x.Top < Player.Top)
                    {
                        //CheckIntersectsOfMonsters.CheckIntersectsOfMonstersByLocation(monsterUnitList, Player, monsterSpeedFirstLvl, GameTimer);
                        x.Top += monsterSpeedFirstLvl;
                        if ((string)x.Tag == "monster") 
                            ((PictureBox)x).Image = Properties.Resources.zdown;

                        if ((string)x.Tag == "boss")
                        {
                            ((PictureBox)x).Image = Properties.Resources.BossD;
                            ShortPath.FindPath(field, Boss.Location, Player.Location);
                        }
                    }
                }

                foreach (Control j in Controls)
                {
                    if (j is PictureBox && ((string)j.Tag == "bullet" || (string)j.Tag == "ball") && (x is Monster && (string)x.Tag == "monster" || x is Boss && (string)x.Tag == "boss"))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds) && (levelCount == firstLevel || levelCount == secondLevel))
                        {
                            targetCountLvl1--;
                            if (targetCountLvl1 == 0) LevelCompleted();

                            RemoveElementFromForm(this, j);
                            RemoveElementFromForm(this, x);

                            monsterUnitList.Remove((Monster)x);

                            MakeZombie();
                        }

                        else if (x.Bounds.IntersectsWith(j.Bounds) && (string)x.Tag == "boss" && levelCount == thirdLevel)
                        {
                            BossHealth -= HeroDamage;
                            BossHP.Value -= HeroDamage;
                            targetCountLvl1 = BossHealth;

                            if (BossHealth <= 0) GameCompleted();

                            RemoveElementFromForm(this, j);
                        }
                    }
                }
            }
        }

        private static void RemoveElementFromForm(Form form, Control c)
        {
            form.Controls.Remove(c);
            ((PictureBox)c).Dispose();
        }

        private async void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                goUp = false;

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
                goDown = false;

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                goLeft = false;

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                goRight = false;

            if (e.KeyCode == Keys.Space && HeroAmmoLvl1 > 0)
            {
                if (levelCount == firstLevel) ShootBullet(facing);

                if (levelCount == secondLevel)
                {
                    if (HeroAmmoLvl1 >= Turn && !HeroIsShooting)
                    {
                        HeroIsShooting = true;
                        for (int i = 0; i < Turn; i++)
                        {
                            ShootBullet(facing);
                            await Task.Delay(200);
                        }
                        HeroIsShooting = false;
                    }
                }

                if (levelCount == thirdLevel)
                {
                    if (HeroAmmoLvl1 >= Shell && !HeroIsShooting)
                    {
                        HeroIsShooting = true;
                        for (int i = 0; i < Shell; i++)
                        {
                            ShootDrob(facing);
                            await Task.Delay(i * 400 + 400);
                        }
                        HeroIsShooting = false;
                    }
                }
            }

            if (e.KeyCode == Keys.R)
                if (HeroAmmoLvl1 == 0 && canDropAmmo)
                {
                    DropAmmo();
                    canDropAmmo = false;
                }

            if (e.KeyCode == Keys.H)
                if (HeroHP != 0 && HeroHP < OneHeart && canDropHeal)
                {
                    DropHeal();
                    canDropHeal = false;
                }

            if (e.KeyCode == Keys.G)
                if (HeroDamage == 2 && levelCount == thirdLevel && canDropDamage)
                {
                    DropDamage();
                    canDropDamage = false;
                }

            if (e.KeyCode == Keys.Escape)
            {
                GameTimer.Enabled = false;

                var p1 = new PauseForm();

                if (p1.ShowDialog() != DialogResult.OK)
                    GameTimer.Enabled = true;
                    if (PauseForm.clickedExitButton)
                    {
                        p1.Close();
                        Close();
                    }
            }
        }
        
        private void LevelCompleted()
        {
            levelCount++;
            GameTimer.Stop();

            foreach (Control j in Controls)
                if (j is PictureBox && ((string)j.Tag == "bullet"))
                    RemoveElementFromForm(this, j);
            MessageBox.Show("Вы прошли уровень!", "Поздравляем", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if (levelCount == secondLevel)
            {
                targetCountLvl1 = targetCountLvl2;
                HeroAmmoLvl1 = HeroAmmoLvl2;
                monsterSpeedFirstLvl = monsterSpeedSecondLvl;
                pictureBoxWeapon.Image = Properties.Resources.Auto;
            }

            else if (levelCount == thirdLevel)
            {
                targetCountLvl1 = targetCountLvl3;
                HeroAmmoLvl1 = HeroAmmoLvl3;
                monsterSpeedFirstLvl = BossSpeed;
                pictureBoxWeapon.Image = Properties.Resources.Shotgun;
            }

            else GameCompleted();

            RestartGame();
        }
        
        private void GameCompleted()
        {
            Close();
            MessageBox.Show("Победа!!!", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            FormMenu.IsClosedGame = true;
        }

        private void RestartGame()
        {
            foreach (Monster i in monsterUnitList)
                Controls.Remove(i);

            monsterUnitList.Clear();

            if (levelCount == firstLevel || levelCount == secondLevel)
                for (int i = 0; i < thirdLevel; i++)
                    MakeZombie();

            if(levelCount == thirdLevel) MakeBoss();

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;

            GameTimer.Start();
        }

        private void GetSight(bool up, bool down, bool left, bool right)
        {
            if (up)
            {
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
            HeroAmmoLvl1 -= 1;

            if (HeroAmmoLvl1 <= 1)
                canDropAmmo = true;
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
