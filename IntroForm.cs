using System;
using System.Windows.Forms;

namespace Praktika2023
{
    //Форма приветственного окна
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        //нажатие кнопки начать
        private void Startbutton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(); //создать экземпляр главной формы
            mainForm.Show(); //показать окно
            this.Hide(); //скрыть привественное окно
        }

        //нажатие кнопки выйти
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
