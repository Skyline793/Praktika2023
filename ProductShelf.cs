using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{

    internal class ProductShelf
    {
        public static int MaxCustomers = 10;
        private Thread thread;
        public Thread Thread
        {
            get { return thread; }
            set { thread = value; }
        }
        private Color color;
        public Color Color
        {
            get { return color; }
        }
        private Rectangle form;
        public Rectangle Form
        {
            get { return form; }
        }
        private List<Product> foodShelf;
        public List<Product> FoodShelf
        {
            get { return foodShelf; }
        }
        private List<Product> goodsShelf;
        public List <Product> GoodsShelf
        { 
            get { return goodsShelf; }
        }
        private Queue<Customer> queue;
        public Queue<Customer> Queue
        {
            get { return queue; }
        }
        private int directionOfApproach;
        public int DirectionOfApproach
        {
            get { return directionOfApproach; }
        }

        public ProductShelf(Point position, Size size, Color color, int direction, int foodCount, int goodsCount)
        {
            this.form = new Rectangle(position, size);
            this.color = color;
            foodShelf = new List<Product>();
            for (int i = 0; i < foodCount / 2; i++)
            {
                foodShelf.Add(new Product(ProductType.food, PriceSegment.low));
            }
            for (int i = 0; i < foodCount / 3; i++)
            {
                foodShelf.Add(new Product(ProductType.food, PriceSegment.medium));
            }
            while (foodShelf.Count < foodCount)
            {
                foodShelf.Add(new Product(ProductType.food, PriceSegment.premium));
            }
            goodsShelf = new List<Product>();

            for (int i = 0; i < goodsCount / 2; i++)
            {
                goodsShelf.Add(new Product(ProductType.goods, PriceSegment.low));
            }
            for (int i = 0; i < goodsCount / 3; i++)
            {
                goodsShelf.Add(new Product(ProductType.goods, PriceSegment.medium));
            }
            while (goodsShelf.Count < goodsCount)
            {
                goodsShelf.Add(new Product(ProductType.goods, PriceSegment.premium));
            }
            this.queue = new Queue<Customer>();
            this.directionOfApproach = direction;
        }

        public void AddCustomerToQueue(Customer customer)
        {
            this.queue.Enqueue(customer);
                customer.MoveToShelf(this); 
            
        }

        public void UpdateQueue()
        {
            for (int i = 0; i < this.Queue.Count; i++)
            {
                if (this.Queue.ElementAt(i).Thread.IsAlive == true)
                    this.Queue.ElementAt(i).Thread.Abort();
                this.Queue.ElementAt(i).MoveToShelf(this);
            }
        }

        public override string ToString()
        {
            int lowfood = 0,
                mediumfood = 0,
                premfood = 0,
                lowgoods = 0,
                mediumgoods = 0,
                premgoods = 0;
            foreach(var food in this.foodShelf)
            {
                if(food.PriceSegment==PriceSegment.low)
                    lowfood++;
                if(food.PriceSegment==PriceSegment.medium)
                    mediumfood++;
                if(food.PriceSegment==PriceSegment.premium)
                    premfood++;
            }
            foreach (var food in this.goodsShelf)
            {
                if (food.PriceSegment == PriceSegment.low)
                    lowgoods++;
                if (food.PriceSegment == PriceSegment.medium)
                    mediumgoods++;
                if (food.PriceSegment == PriceSegment.premium)
                    premgoods++;
            }
            string info = String.Format("Товарная полка\nЗапас пищевых продуктов: {0} шт.\nДешевых (49 руб): {1}\nБюджетных (249 руб): {2}\nПремиальных (449 руб): {3}" +
                "\nЗапас хозяйственных товаров: {4} шт.\nДешевых (99 руб): {5}\nБюджетных (399 руб): {6}\nПремиальных (599 руб): {7}", Convert.ToString(this.foodShelf.Count),
                lowfood, mediumfood, premfood, Convert.ToString(this.goodsShelf.Count), lowgoods, mediumgoods, premgoods);

            return info;
        }

    }
}
