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
    public partial class FormMenu : Form
    {
        public bool IsClosed = true;
        public static bool IsClosedGame = true;
        
        public FormMenu()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm();
            IsClosedGame = false;
            gameForm.Show();
            if (IsClosedGame)
            {
                this.Show();
            }
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            var optionsForm = new Form();
            IsClosedGame = false;
            optionsForm.Show();
            if (!IsClosed)
            {

            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
