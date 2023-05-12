using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace DeathPitTest
{
    public partial class GameForm : Form
    {
        string facing = "up";
        int monsterUnitSpeed = 3;
        int targetCount = 25;
        bool goUp, goDown, goLeft, goRight;
        private int playerHP = 6000;
        private readonly int HeroSpeed = 10;
        private int HeroAmmo = 20;

        int levelCount = 1;
        readonly Random randNum = new();
        readonly List<PictureBox> monsterUnitList = new();
        //старт
        public GameForm()
        {
            InitializeComponent();

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            Player.Image = Properties.Resources.HeroPistolUp;
            pictureBoxWeapon.Image = Properties.Resources.Pistol;

            RestartGame();
        }
        //создание мобов
        private void MakeZombies()
        {
            PictureBox monster = new PictureBox
            {
                Tag = "monster",
                Image = Properties.Resources.zdown,
                Left = randNum.Next(500, 900), 
                Top = randNum.Next(200, 800),
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            monsterUnitList.Add(monster);
            this.Controls.Add(monster);
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


            if (goUp && Player.Top > 40)
            {
                Health(playerHP);
                Player.Top -= HeroSpeed;
            }

            if (goDown && Player.Top + Player.Height < this.ClientSize.Height)
            {
                Health(playerHP);
                Player.Top += HeroSpeed;
            }

            if (goLeft && Player.Left > 0) 
            {
                Health(playerHP);
                Player.Left -= HeroSpeed;
            }

            if (goRight && Player.Left + Player.Width < this.ClientSize.Width)
            {
                Health(playerHP);
                Player.Left += HeroSpeed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        HeroAmmo += 5;
                    }
                }


                if (x is PictureBox && (string)x.Tag == "monster")
                {

                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHP -= 1;
                        Health(playerHP);
                       // GameTimer.Interval = 1000; ////////////////
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

                foreach (Control j in this.Controls)
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

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            monsterUnitList.Remove(((PictureBox)x));
                            MakeZombies();

                            if (HeroAmmo == 0)
                            {
                                DropAmmo();
                            }

                            if (playerHP == 1)
                            {
                                DropHeal();
                            }
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
                if(HeroAmmo!=0)
                {
                    ShootBullet(facing);
                }

            }
        }
        //Завершение уровня
        private void LevelCompleted()
        {
            levelCount++;
            GameTimer.Stop();
            DialogResult result = MessageBox.Show("Вы прошли уровень!", "Поздравляем", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if(levelCount == 2)
            {
                targetCount += 50;
                HeroAmmo = 35;
                monsterUnitSpeed = 5;
                pictureBoxWeapon.Image = Properties.Resources.HeroAutoDown;
                labelWeapon.Image = Properties.Resources.Auto;
            }
            else if (levelCount == 3)
            {
                targetCount += 75;
                HeroAmmo = 45;
                monsterUnitSpeed = 5;
                pictureBoxWeapon.Image = Properties.Resources.HeroShotgunDown;
                labelWeapon.Image = Properties.Resources.Shotgun;
            }
            else
            {
                GameCompleted();
            }

            RestartGame();
        }
        //Завершение игры
        private void GameCompleted()
        {
            this.Close();
            DialogResult result = MessageBox.Show("Победа!!!", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            FormMenu.IsClosedGame = true;
        }
        //Смерть
        private void GameOver()
        {
            this.Close();
            DialogResult result = MessageBox.Show("Обнулён", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
            FormMenu.IsClosedGame = true;
        }
        //Перезапсук
        private void RestartGame()
        {
            foreach (PictureBox i in monsterUnitList)
            {
                this.Controls.Remove(i);
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

            //playerHP = 6;
            HeroAmmo = 20;

            GameTimer.Start();
        }
        //Здоровье
        private void Health(int hp)
        {
            if (hp <= 0)
            {
                pictureBoxHealth1.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
                GameOver();
            }
            if (hp >= 1000 && hp < 2000)
            {
                pictureBoxHealth1.Image = Properties.Resources.halfHurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 2000 && hp < 3000)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 3000 && hp < 4000)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.halfHurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 4000 && hp < 5000)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.fullHurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp >= 5000 && hp < 6000)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.fullHurt;
                pictureBoxHealth3.Image = Properties.Resources.halfHurt;
            }
            if (hp >= 6000)
            {
                hp = 6000;
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
                        Player.Image = Properties.Resources.HeroAutoRight;
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
                        Player.Image = Properties.Resources.HeroAutoUp;
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
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = Player.Left + (Player.Width / 2);
            shootBullet.bulletTop = Player.Top + (Player.Height / 2);
            shootBullet.MakeBullet(this);
            HeroAmmo -= 1;
        }
        // Аммуниция
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            Player.BringToFront();
        }
        //ХП
        private void DropHeal()
        {
            PictureBox heal = new PictureBox();
            heal.Image = Properties.Resources.Heal;
            heal.SizeMode = PictureBoxSizeMode.AutoSize;
            heal.Left = randNum.Next(10, this.ClientSize.Width - heal.Width);
            heal.Top = randNum.Next(60, this.ClientSize.Height - heal.Height);
            heal.Tag = "heal";
            this.Controls.Add(heal);
            playerHP += 1000;
            heal.BringToFront();
            Player.BringToFront();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
