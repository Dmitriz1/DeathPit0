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
        string facing;
        int monsterUnitSpeed = 3;
        int targetCount = 25;
        bool goUp, goDown, goLeft, goRight;
        private int playerHP = 6;
        private int HeroSpeed = 10;
        private int HeroAmmo = 20;

        int levelCount = 1;

        Random randNum = new Random();
        List<PictureBox> monsterUnitList = new List<PictureBox>();

        public GameForm()
        {
            InitializeComponent();
            RestartGame();
        }

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

            foreach (Control x in this.Controls)////////////////////////////////////////////////////
            {
                /*if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;

                    }
                }*/


                if (x is PictureBox && (string)x.Tag == "monster")
                {

                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHP -= 1;
                        Health(playerHP);
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
                        }
                    }
                }
            }

        }

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

        private void LevelCompleted()
        {
            levelCount++;
            DialogResult result = MessageBox.Show("Вы прошли уровень!", "Поздравляем", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if(levelCount == 2)
            {
                targetCount += 50;
                //меняем модельки, оружие
            }

            RestartGame();
        }

        private void GameOver()
        {
            this.Close();
            DialogResult result = MessageBox.Show("Обнулён", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
            FormMenu.IsClosedGame = true;
        }

        private void RestartGame()
        {
            Player.Image = Properties.Resources.HeroPistolUp;

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

            playerHP = 6;
            HeroAmmo = 20;

            GameTimer.Start();
        }

        private void Health(int hp)
        {
            if (hp == 0)
            {
                pictureBoxHealth1.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
                GameOver();
            }
            if (hp == 1)
            {
                pictureBoxHealth1.Image = Properties.Resources.halfHurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp == 2)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp == 3)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.halfHurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp == 4)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.fullHurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
            }
            if (hp == 5)
            {
                pictureBoxHealth1.Image = Properties.Resources.fullHurt;
                pictureBoxHealth2.Image = Properties.Resources.fullHurt;
                pictureBoxHealth3.Image = Properties.Resources.halfHurt;
            }
            if (hp == 6)
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
                Player.Image = Properties.Resources.HeroPistolUp;
            }

            if (down)
            {
                Player.Width = 64;
                Player.Height = 86;
                Player.Image = Properties.Resources.HeroPistolDown;
            }

            if (left)
            {
                Player.Width = 86;
                Player.Height = 64;
                Player.Image = Properties.Resources.HeroPistolLeft;
            }

            if (right)
            {
                Player.Width = 86;
                Player.Height = 64;
                Player.Image = Properties.Resources.HeroPistolRight;
            }
        }

        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = Player.Left + (Player.Width / 2);
            shootBullet.bulletTop = Player.Top + (Player.Height / 2);
            shootBullet.MakeBullet(this);
            HeroAmmo -= 1;
        }


        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
