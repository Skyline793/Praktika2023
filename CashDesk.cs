using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Praktika2023
{
    /// <summary>Класс Касса</summary>
    internal class CashDesk
    {
        /// <summary>Прямоугольник, определяющий форму и положение кассы</summary>
        private Rectangle form;
        /// <summary>Прямоугольник, определяющий форму и положение кассы</summary>
        public Rectangle Form
        {
            get { return form; } //геттер
        }
        /// <summary>Цвет кассы</summary>
        private Color color;
        /// <summary>Цвет кассы</summary> 
        public Color Color
        {
            get { return color; } //геттер
        }
        /// <summary>Кассир, работающий за кассой</summary>
        private Cashier cashier;
        /// <summary>Кассир, работающий за кассой</summary>
        public Cashier Cashier
        {
            get { return cashier; } //геттер
            set { cashier = value; } //сеттер
        }
        /// <summary>Очередь покупателей у кассы</summary>
        private Queue<Customer> queue;
        /// <summary>Очередь покупателей у кассы</summary>
        public Queue<Customer> Queue
        {
            get { return queue; } //геттер
        }
        /// <summary>Список чеков</summary>
        private List<int> checks;
        /// <summary>Список чеков</summary>
        public List<int> Checks
        {
            get { return checks; } //геттер
        }
        /// <summary>Поток, в котором обрабатывается очередь покупателей к кассе</summary>
        private Thread thread;
        /// <summary>Поток, в котором обрабатывается очередь покупателей к кассе</summary>
        public Thread Thread
        {
            get { return thread; } //геттер
            set { thread = value; } //сеттер
        }
        /// <summary>Доход кассы</summary>
        public int Income
        {
            get //геттер
            {
                int income = checks.Sum();
                return income;
            }
        }
        /// <summary>Число обслуженных покупателей</summary>
        public int ServedCustomers
        {
            get { return checks.Count; } //геттер
        }

        /// <summary>
        /// Конструктор класса Касса
        /// </summary>
        /// <param name="position">Координата левого верхнего угла кассы</param>
        /// <param name="size">Размеры кассы</param>
        /// <param name="color">Цвет кассы</param>
        public CashDesk(Point position, Size size, Color color)
        {
            this.color = color;
            this.form = new Rectangle(position.X, position.Y, size.Width, size.Height);
            this.queue = new Queue<Customer>();
            this.checks = new List<int>();
        }

        /// <summary>
        /// Метод добавления покупателя в очередь к кассе
        /// </summary>
        /// <param name="customer">Покупатель</param>
        public void AddCustomerToQueue(Customer customer)
        {
            this.queue.Enqueue(customer); //добавить покупателя в очередь
            customer.MoveToCashDesk(this); //вызвать у покупателя метод движения к кассе
        }

        /// <summary>
        /// Метод обновления очереди покупателей
        /// </summary>
        public void UpdateQueue()
        {
            for (int i = 0; i < this.queue.Count; i++) //для всех покупателей в очереди
            {
                if (this.queue.ElementAt(i).Thread.IsAlive) //если поток покупателя активен
                    this.queue.ElementAt(i).Thread.Abort(); //завершить его
                this.queue.ElementAt(i).MoveToCashDesk(this); //вызвать у покупателя метод движения к кассе
            }
        }

        /// <summary>
        /// метод преобразования информации о кассе в строку
        /// </summary>
        /// <returns>Cтрока типа string с информацией</returns>
        public override string ToString()
        {
            string info = String.Format("Касса\nПокупателей обслужено: {0}\nТекущий доход: {1} руб.", this.checks.Count, this.Income);
            return info;
        }
    }
}
