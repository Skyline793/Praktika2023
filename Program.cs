using System;
using System.Windows.Forms;

namespace Praktika2023
{
    //Главный файл приложения
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IntroForm());
        }
    }
}
