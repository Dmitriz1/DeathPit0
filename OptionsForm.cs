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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            richTextBox1.Text = "Настроек нет, зато есть обучение:\n\n\n\n" +
                "Стрелять на \"Space"\.\n\n" +
                "Мало патронов? Нажми \"R\". Если патронов больше 1, нажать не получится.\n\n" +
                "Мало хп? Нажми \"Н\". Если больше половины сердечка, ты еще живее всех живых.\n\n" +
                "Пауза на \"Escape\". Хотя, возможно, эта подсказка тебе и не понадобится.\n\n\n\n" +
                "Удачи!";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
