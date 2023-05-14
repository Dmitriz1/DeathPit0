﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.DataFormats;

namespace DeathPitTest
{
    public partial class GameForm : Form
    {
        string facing;
        bool goUp, goDown, goLeft, goRight;

        int monsterUnitSpeed = 3;
        int targetCount = 25;

        private int HeroHP = 300;
        private readonly int HeroSpeed = 10;
        private int HeroAmmo = 20;

        bool canDropAmmo = false;
        bool canDropHeal = true;

        int levelCount = 1;

        readonly Random randNum = new();
        readonly List<PictureBox> monsterUnitList = new();
        //старт
        public GameForm()
        {
            InitializeComponent();
           // TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            Player.Image = Properties.Resources.HeroPistolUp;
            pictureBoxWeapon.Image = Properties.Resources.Pistol;

            RestartGame();
        }
        //создание мобов
        private void MakeZombies()
        {
            PictureBox monster = new ()
            {
                Tag = "monster",
                Image = Properties.Resources.zdown,
                Left = randNum.Next(500, 900), 
                Top = randNum.Next(200, 800),
                SizeMode = PictureBoxSizeMode.AutoSize
            };

            monsterUnitList.Add(monster);
            Controls.Add(monster);

            Player.BringToFront();
        }
        // нажатие кнопки
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                goUp = true;
                GetSight(goUp, goDown, goLeft, goRight);
                facing = "up";
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                goDown = true;
                GetSight(goUp, goDown, goLeft, goRight);
                facing = "down";
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                goLeft = true;
                GetSight(goUp, goDown, goLeft, goRight);
                facing = "left";
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                goRight = true;
                GetSight(goUp, goDown, goLeft, goRight);
                facing = "right";
            }
        }
        // движения перса и мобов во время игры
        private void GameTimerEvent(object sender, EventArgs e)
        {
            labelAmmo.Text = $"Аммуниция: {HeroAmmo}";
            labelScore.Text = $"Цель: {targetCount}";


            if (goUp && Player.Top > pictureBoxHealth1.Width)
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
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        HeroAmmo += 5;
                    }
                }

                else if ((string)x.Tag == "heal")
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        HeroHP += 50;
                        canDropHeal = true;
                    }

                if (x is PictureBox && (string)x.Tag == "monster")
                {

                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        HeroHP -= 1;
                        Health(HeroHP);
                    }

                    //Вставить алгос о нахождении кратч расстояния
                    if (x.Left > Player.Left)
                    {
                        x.Left -= monsterUnitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft; 
                    }
                    if (x.Left < Player.Left)
                    {
                        x.Left += monsterUnitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (x.Top > Player.Top)
                    {
                        x.Top -= monsterUnitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                    if (x.Top < Player.Top)
                    {
                        x.Top += monsterUnitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }

                }

                foreach (Control j in Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "monster")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            targetCount--;
                            if(targetCount==0)
                            {
                                LevelCompleted();
                            }

                            Controls.Remove(j);
                            ((PictureBox)j).Dispose();

                            Controls.Remove(x);
                            ((PictureBox)x).Dispose();

                            monsterUnitList.Remove((PictureBox)x);

                            MakeZombies();                         
                        }
                    }
                }
            }
        }
        //Нажатие кнопок
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
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

            if (e.KeyCode == Keys.Space)
            {
                if (HeroAmmo != 0)
                {
                    ShootBullet(facing);
                }
            }

            if (e.KeyCode == Keys.R)
            {
                if (HeroAmmo <= 1 && canDropAmmo)
                {
                    DropAmmo();
                    canDropAmmo = false;
                }
            }

            if (e.KeyCode == Keys.H)
            {
                if (HeroHP !=0 && HeroHP < 100 && canDropHeal)
                {
                    DropHeal();
                    canDropHeal = false;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                GameTimer.Enabled = false;

                PauseForm p1 = new PauseForm();
                if (p1.ShowDialog() != DialogResult.OK)
                {
                    GameTimer.Enabled = true;
                    if(PauseForm.clickedExitButton)
                    {
                        Close();
                    }
                }
            }
        }
        //Завершение уровня
        private void LevelCompleted()
        {
            levelCount++;
            GameTimer.Stop();
            MessageBox.Show("Вы прошли уровень!", "Поздравляем", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if(levelCount == 2)
            {
                targetCount += 50;
                HeroAmmo = 35;
                monsterUnitSpeed = 5;
                pictureBoxWeapon.Image = Properties.Resources.Auto;
            }
            else if (levelCount == 3)
            {
                targetCount += 75;
                HeroAmmo = 45;
                monsterUnitSpeed = 5;
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
        //Смерть
        private void GameOver()
        {
            Close();
            MessageBox.Show("Обнулён", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
            FormMenu.IsClosedGame = true;
        }
        //Перезапсук
        private void RestartGame()
        {
            foreach (PictureBox i in monsterUnitList)
            {
                Controls.Remove(i);
            }

            monsterUnitList.Clear();

            for (int i = 0; i < 3; i++)
            {
                MakeZombies();
            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;

            HeroAmmo = 20;

            GameTimer.Start();
        }
        //Здоровье
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
        // Направление взгляда
        private void GetSight(bool up, bool down, bool left, bool right)
        {
            if (up)
            {
                Player.Width = 64;
                Player.Height = 86;

                switch(levelCount)
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
        // Стрельба
        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new()
            {
                direction = direction,
                bulletLeft = Player.Left + (Player.Width / 2),
                bulletTop = Player.Top + (Player.Height / 2)
            };
            shootBullet.MakeBullet(this);
            HeroAmmo -= 1;

            if (HeroAmmo <= 1)
            {
                canDropAmmo = true;
            }
        }
        // Аммуниция
        private void DropAmmo()
        {
            PictureBox ammo = new ()
            {
                Image = Properties.Resources.ammo,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            ammo.Left = randNum.Next(10, ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";

            if (!Controls.Contains(ammo))
            {
                Controls.Add(ammo);
            }           

            ammo.BringToFront();
            Player.BringToFront();
        }
        //ХП
        private void DropHeal()
        {
            PictureBox heal = new ()
            {
                Image = Properties.Resources.Heal,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            heal.Left = randNum.Next(10, ClientSize.Width - heal.Width);
            heal.Top = randNum.Next(60, ClientSize.Height - heal.Height);
            heal.Tag = "heal";

            if (!Controls.Contains(heal))
            {
                Controls.Add(heal);
            }

            heal.BringToFront();
            Player.BringToFront();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}