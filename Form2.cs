using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    public partial class GameForm : Form
    {
        int monsterUnitSpeed = 3;
        int targetCount = 25;
        bool goUp, goDown, goLeft, goRight, gameOver;
        private int playerHP = 6;
        private int HeroSpeed = 10;
        private int HeroDamage = 2;
        private int HeroAmmo = 20;
        private int HeroScore = 0;

        Random randNum = new Random();
        List<PictureBox> monsterUnitList = new List<PictureBox>();

        public GameForm()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.map1;
        }

        private void MakeZombies()
        {
            PictureBox monster = new PictureBox();
            monster.Tag = "monster";
            //monster.Image = Properties.Resources.down;
            monster.Left = randNum.Next(0, 900);
            monster.Top = randNum.Next(0, 800);
            monster.SizeMode = PictureBoxSizeMode.AutoSize;
            monsterUnitList.Add(monster);
            this.Controls.Add(monster);
            // Player.BringToFront();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                goUp = true;
                GetSight(goUp, goDown, goLeft, goRight);
            }
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                goDown = true;
                GetSight(goUp, goDown, goLeft, goRight);
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                goLeft = true;
                GetSight(goUp, goDown, goLeft, goRight);
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                goRight = true;
                GetSight(goUp, goDown, goLeft, goRight);
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            labelAmmo.Text = $"Аммуниция: {HeroAmmo}";
            labelScore.Text = $"Счет: {HeroScore}";


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
        }

        private void labelScore_Click(object sender, EventArgs e)
        {

        }

        private void GameOver()
        {
            if (gameOver)
            {
                MessageBox.Show("Обнулён");
            }
        }

        private void Health(int hp)
        {
            if (hp <= 0)
            {
                pictureBoxHealth1.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth2.Image = Properties.Resources.emptyhurt;
                pictureBoxHealth3.Image = Properties.Resources.emptyhurt;
                gameOver = true;
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

        private void Shoot()
        {

        }

        private void Bullet()
        {

        }
    }
}
