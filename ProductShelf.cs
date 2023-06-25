using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    enum SlotStatus
    {
        available,
        busy
    }

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
        private List<SlotStatus> slots;
        public List<SlotStatus> Slots
        {
            get { return slots; }
        }



        public ProductShelf(Point position, Size size, Color color, int foodCount, int goodsCount)
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
            this.slots = new List<SlotStatus>(2) { SlotStatus.available, SlotStatus.available };
        }

        public void AddCustomerToQueue(Customer customer)
        {
            this.queue.Enqueue(customer);
                customer.MoveTo(this); 
            
        }

    }
}
