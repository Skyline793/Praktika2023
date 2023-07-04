using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;

namespace Praktika2023
{
    /// <summary>Класс Полка с товарами</summary>
    internal class ProductShelf
    {
        /// <summary>Прямоугольник, определяющий форму и положение полки</summary>
        private Rectangle form;
        /// <summary>Прямоугольник, определяющий форму и положение полки</summary>
        public Rectangle Form
        {
            get { return form; } //геттер
        }
        /// <summary>Цвет полки</summary>
        private Color color;
        /// <summary>Цвет полки</summary>
        public Color Color
        {
            get { return color; } //геттер
        }
        /// <summary>Секция с едой в полке</summary>
        private List<Product> foodSection;
        /// <summary>Секция с едой в полке</summary>
        public List<Product> FoodSection
        {
            get { return foodSection; } //геттер
        }
        /// <summary>Секция с хозтоварами в полке</summary>
        private List<Product> goodsSection;
        /// <summary>Секция с хозтоварами в полке</summary>
        public List<Product> GoodsSection
        {
            get { return goodsSection; } //геттер
        }
        /// <summary>Очередь покупателей у полки</summary>
        private Queue<Customer> queue;
        /// <summary>Очередь покупателей у полки</summary>
        public Queue<Customer> Queue //геттер
        {
            get { return queue; }
        }
        /// <summary>Направление, по которому нужно подходить к полке. 1 - справа, 2 - слева</summary>
        private int directionOfApproach;
        /// <summary>Направление, по которому нужно подходить к полке. 1 - справа, 2 - слева</summary>
        public int DirectionOfApproach
        {
            get { return directionOfApproach; }
        }
        /// <summary>Поток, в котором обрабатывается очередь покупателей у полки</summary>
        private Thread thread;
        /// <summary>Поток, в котором обрабатывается очередь покупателей у полки</summary>
        public Thread Thread
        {
            get { return thread; } //геттер
            set { thread = value; } //сеттер
        }

        /// <summary>
        /// Конструктор класса Полка с товарами
        /// </summary>
        /// <param name="position">Координата левого верхнего угла полки</param>
        /// <param name="size">Размеры полки</param>
        /// <param name="color">Цвет полки</param>
        /// <param name="direction">Направление подхода</param>
        /// <param name="foodCount">Начальное число пищевых продуктов</param>
        /// <param name="goodsCount">Начальное число хозтоваров</param>
        public ProductShelf(Point position, Size size, Color color, int direction, int foodCount, int goodsCount)
        {
            this.form = new Rectangle(position, size);
            this.color = color;

            this.foodSection = new List<Product>();
            for (int i = 0; i < foodCount / 2; i++)
            {
                foodSection.Add(new Product(ProductType.food, PriceSegment.low));
            }
            for (int i = 0; i < foodCount / 3; i++)
            {
                foodSection.Add(new Product(ProductType.food, PriceSegment.medium));
            }
            while (foodSection.Count < foodCount)
            {
                foodSection.Add(new Product(ProductType.food, PriceSegment.premium));
            }

            this.goodsSection = new List<Product>();
            for (int i = 0; i < goodsCount / 2; i++)
            {
                goodsSection.Add(new Product(ProductType.goods, PriceSegment.low));
            }
            for (int i = 0; i < goodsCount / 3; i++)
            {
                goodsSection.Add(new Product(ProductType.goods, PriceSegment.medium));
            }
            while (goodsSection.Count < goodsCount)
            {
                goodsSection.Add(new Product(ProductType.goods, PriceSegment.premium));
            }

            this.queue = new Queue<Customer>();
            this.directionOfApproach = direction;
        }

        /// <summary>
        /// Метод добавления покупателя в очередь к полке
        /// </summary>
        /// <param name="customer">Покупатель</param>
        public void AddCustomerToQueue(Customer customer)
        {
            this.queue.Enqueue(customer); //добавить покупателя в очередь
            customer.MoveToShelf(this); //вызвать у покупателя метод движения к полке
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
                this.queue.ElementAt(i).MoveToShelf(this); //вызвать у покупателя метод движения к полке
            }
        }

        /// <summary>
        /// метод преобразования информации о полке в строку
        /// </summary>
        /// <returns>Cтрока типа string с информацией</returns>
        public override string ToString()
        {
            int lowfood = 0,
                mediumfood = 0,
                premfood = 0,
                lowgoods = 0,
                mediumgoods = 0,
                premgoods = 0;
            foreach (var food in this.foodSection)
            {
                if (food.PriceSegment == PriceSegment.low)
                    lowfood++;
                if (food.PriceSegment == PriceSegment.medium)
                    mediumfood++;
                if (food.PriceSegment == PriceSegment.premium)
                    premfood++;
            }
            foreach (var food in this.goodsSection)
            {
                if (food.PriceSegment == PriceSegment.low)
                    lowgoods++;
                if (food.PriceSegment == PriceSegment.medium)
                    mediumgoods++;
                if (food.PriceSegment == PriceSegment.premium)
                    premgoods++;
            }
            string info = String.Format("Товарная полка\nЗапас пищевых продуктов: {0} шт.\nДешевых (49 руб): {1}\nБюджетных (249 руб): {2}\nПремиальных (449 руб): {3}" +
                "\nЗапас хозяйственных товаров: {4} шт.\nДешевых (99 руб): {5}\nБюджетных (399 руб): {6}\nПремиальных (599 руб): {7}", this.foodSection.Count,
                lowfood, mediumfood, premfood, this.goodsSection.Count, lowgoods, mediumgoods, premgoods);
            return info;
        }
    }
}
