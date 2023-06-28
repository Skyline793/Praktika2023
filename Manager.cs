using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;

namespace Praktika2023
{
    enum ManagerStatus
    {
        available,
        busy
    }

    internal class Manager :Person
    {
        private ManagerStatus status;
        public ManagerStatus Status
        {
            get { return status; }
        }
        public Manager(Point position, Size size, Color color, int ID): base(position, size, color, ID)
        {
            this.status = ManagerStatus.available;
        }
        protected override void Move(Point Dest)
        {
            body = new Rectangle(Dest.X, Dest.Y, body.Width, body.Height);
        }

        public void TopUpTheShelf(ProductShelf shelf)
        {
            this.status= ManagerStatus.busy;
            Thread thread = new Thread(() =>
            {
                Point source = new Point(this.body.X, this.body.Y);
                Point dest = new Point(shelf.Form.Left, shelf.Form.Bottom + MainForm.DXY * 2);
                while (this.body.Y != dest.Y)
                {
                    if (this.body.Y < dest.Y)
                        this.Move(new Point(this.body.X, this.body.Y + 1));
                    if (this.body.Y > dest.Y)
                        this.Move(new Point(this.body.X, this.body.Y - 1));
                    Thread.Sleep(10);
                }
                while (this.body.X != dest.X)
                {
                    if (this.body.X < dest.X)
                        this.Move(new Point(this.body.X + 1, this.body.Y));
                    if(this.body.X > dest.X)
                        this.Move(new Point(this.body.X-1, this.body.Y));
                    Thread.Sleep(10);
                }
                
                TopUp(shelf);
                Thread.Sleep(10000);
                while (this.body.X != source.X)
                {
                    if (this.body.X < source.X)
                        this.Move(new Point(this.body.X + 1, this.body.Y));
                    if (this.body.X > source.X)
                        this.Move(new Point(this.body.X - 1, this.body.Y));
                    Thread.Sleep(10);
                }
                while (this.body.Y != source.Y)
                {
                    if (this.body.Y < source.Y)
                        this.Move(new Point(this.body.X, this.body.Y + 1));
                    if (this.body.Y > source.Y)
                        this.Move(new Point(this.body.X, this.body.Y - 1));
                    Thread.Sleep(10);
                }
                this.status = ManagerStatus.available;
            });
            thread.Start();
        }

        private void TopUp(ProductShelf shelf)
        {
            int foodCount = 30,
                goodsCount = 30;
            for (int i = 0; i < foodCount / 2; i++)
            {
                shelf.FoodShelf.Add(new Product(ProductType.food, PriceSegment.low));
            }
            for (int i = 0; i < foodCount / 3; i++)
            {
                shelf.FoodShelf.Add(new Product(ProductType.food, PriceSegment.medium));
            }
            while (shelf.FoodShelf.Count < foodCount)
            {
                shelf.FoodShelf.Add(new Product(ProductType.food, PriceSegment.premium));
            }

            for (int i = 0; i < goodsCount / 2; i++)
            {
                shelf.GoodsShelf.Add(new Product(ProductType.goods, PriceSegment.low));
            }
            for (int i = 0; i < goodsCount / 3; i++)
            {
                shelf.GoodsShelf.Add(new Product(ProductType.goods, PriceSegment.medium));
            }
            while (shelf.GoodsShelf.Count < goodsCount)
            {
                shelf.GoodsShelf.Add(new Product(ProductType.goods, PriceSegment.premium));
            }
        }
    }
}
