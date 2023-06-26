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
        private List<Product> goodsShelf;
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
                customer.MoveTo(this); 
            
        }

        public void UpdateQueue()
        {
            for (int i = 0; i < this.Queue.Count; i++)
            {
                if (this.Queue.ElementAt(i).Thread.IsAlive == true)
                    this.Queue.ElementAt(i).Thread.Abort();
                this.Queue.ElementAt(i).MoveTo(this);
            }
        }

        public override string ToString()
        {
            string info = String.Format("Продуктовая полка\nЗапас съедобных товаров: {0} шт.\nЗапас несъедобных товаров: {1} шт.", Convert.ToString(this.foodShelf.Count), Convert.ToString(this.goodsShelf.Count));
            return info;
        }

    }
}
