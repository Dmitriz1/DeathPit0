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

namespace DeathPitTest
{
    public partial class Form1 : Form
    {
        int monsterUnitSpeed = 3;
        int targetCount = 25;
        Random randNum = new Random();
        List<PictureBox> monsterUnitList = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
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
    }
}
