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

        //нажатие кнопки об авторе
        private void authorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Имитационная модель работы магазина\nРазработчик: Тюкавкин И.А.," +
                " студент группы ПИ-11\nАлтГТУ им. И.И. Ползунова, 2023", "Об авторе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
