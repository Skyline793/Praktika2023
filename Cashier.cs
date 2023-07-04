using System;
using System.Drawing;

namespace Praktika2023
{
    /// <summary>Класс Кассир, наследуемый от Человека</summary>
    internal class Cashier : Person
    {
        /// <summary>Скорость сканирования одного товара</summary>
        private int scanSpeed;
        /// <summary>Скорость сканирования одного товара</summary>
        public int ScanSpeed
        {
            get { return scanSpeed; } //геттер
        }

        /// <summary>
        /// Конструктор класса Кассир
        /// </summary>
        /// <param name="position">Координата левого верхнего угла тела</param>
        /// <param name="size">Размеры тела</param>
        /// <param name="color">Цвет тела</param>
        /// <param name="scanSpeed">Скорость сканирования товара</param>
        /// <param name="ID">Идентификатор</param>
        public Cashier(Point position, Size size, Color color, int scanSpeed, int ID) : base(position, size, color, ID)
        {
            this.scanSpeed = scanSpeed;
            this.age = Randomizer.Rand(18, 60); //возраст генерируется случайным образом
        }

        /// <summary>
        /// метод сканирования товара 
        /// </summary>
        /// <param name="customer">обьект класса Покупатель</param>
        /// <returns>целочисленная цена отсканированного товара</returns>
        public int ScanProduct(Customer customer)
        {
            return customer.ShoppingCart.Pop().Price; //извлекаем товар из корзины покупателя
        }

        /// <summary>
        /// метод преобразования информации о кассире в строку
        /// </summary>
        /// <returns>Cтрока типа string с информацией</returns>
        public override string ToString()
        {
            string info = String.Format("Кассир №{0}\nВозраст: {1}\nСкорость сканирования: {2} секунд(-ы) на товар", this.Id,this.age, this.scanSpeed / 1000.0);
            return info;
        }
    }
}
