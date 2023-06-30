using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    enum CustomerStatus
    {
        moving,
        staying,
        readyToPay,
        readyToPickUp,
        exited
    }

    internal class Customer : Person
    {
        private int speed;
        private Thread thread;
        public Thread Thread
        {
            get { return thread; }
        }
        private CustomerStatus status;
        public CustomerStatus Status
        {
            get { return status; }
            set { status = value; }
        }
        private int money;
        public int Money
        {
            get { return money; }
        }

        private Dictionary<ProductType, int> shoppingList;
        public Dictionary<ProductType, int> ShoppingList
        {
            get { return shoppingList; }
        }
        private Stack<Product> shoppingCart;
        public Stack<Product> ShoppingCart
        {
            get { return shoppingCart; }
        }
        public Customer(Point position, Size size, Color color, int ID) :
            base(position, size, color, ID)
        {
            this.age = Randomizer.Rand(10, 85);
            if (this.age < 18)
            {
                this.money = Randomizer.Rand(150, 1500);
                this.speed = 10;
            }
            else if (this.age < 60)
            {
                this.money = Randomizer.Rand(600, 5000);
                this.speed = 10;
            }
            else
            {
                this.money = Randomizer.Rand(400, 3500);
                this.speed = 10;
            }
            this.shoppingList = new Dictionary<ProductType, int>();
            this.shoppingList[ProductType.food] = 0;
            this.shoppingList[ProductType.goods] = 0;
            this.shoppingCart = new Stack<Product>();
            this.status = CustomerStatus.staying;
        }

        protected override void Move(Point Dest)
        {
            body = new Rectangle(Dest.X, Dest.Y, body.Width, body.Height);
        }

        public void MoveTo(Object obj)
        {
            this.status = CustomerStatus.moving;
            if (obj.GetType() == typeof(CashDesk))
            {
                thread = new Thread(this.MoveToCashDesk);
                thread.Start(obj);
            }
            if (obj.GetType() == typeof(ProductShelf))
            {
                thread = new Thread(this.MoveToShelf);
                thread.Start(obj);
            }
            if (obj.GetType() == typeof(Rectangle))
            {
                thread = new Thread(this.MoveToExit);
                thread.Start(obj);
            }
        }

        private void MoveToCashDesk(Object obj)
        {

            CashDesk dest = (CashDesk)obj;
            if (dest.Queue.Peek() == this)
            {
                while (this.body.X != dest.Form.X - this.body.Width - MainForm.DXY * 2 || this.body.Y != dest.Form.Y)
                {
                    while (this.body.X != dest.Form.X - this.body.Width - MainForm.DXY * 2)
                    {
                        if (this.body.X < dest.Form.X - this.body.Width - MainForm.DXY * 2)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > dest.Form.X - this.body.Width - MainForm.DXY * 2)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(this.speed);
                    }
                    while (this.body.Y != dest.Form.Y)
                    {
                        if (this.body.Y < dest.Form.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > dest.Form.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(this.speed);
                    }
                }
                this.status = CustomerStatus.readyToPay;
            }
            else
            {
                Customer last = null;
                int ind = -1 ;
                while (last == null)
                {
                    try
                    {
                        for (ind = 0; ind < dest.Queue.Count; ind++)
                        {
                            if (dest.Queue.ElementAt(ind) == this)
                                break;
                        }
                        last = dest.Queue.ElementAt(ind - 1);
                    }
                    catch (Exception ex)
                    {
                        last = null;
                    }
                }
                while (this.body.X != last.Body.X || this.body.Y != last.Body.Bottom + MainForm.DXY * 4 || last.Status == CustomerStatus.moving)
                {
                    while (this.body.X != last.Body.X)
                    {
                        if (this.body.X < last.Body.X)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > last.Body.X)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(this.speed);
                    }
                    while (this.body.Y != last.Body.Bottom + MainForm.DXY * 4)
                    {
                        if (this.body.Y < last.Body.Bottom + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > last.Body.Bottom + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(this.speed);
                    }
                }
                this.status = CustomerStatus.staying;
            }
        }
        private void MoveToShelf(Object obj)
        {

            ProductShelf shelf = (ProductShelf)obj;
            if (shelf.Queue.Peek() == this)
            {
                Point dest = new Point();
                if (shelf.DirectionOfApproach == 1)
                    dest = new Point(shelf.Form.Right + MainForm.DXY * 4, shelf.Form.Top + 2 * this.body.Height);
                else if (shelf.DirectionOfApproach == 2)
                    dest = new Point(shelf.Form.Left - this.body.Width - MainForm.DXY * 4, shelf.Form.Top + 2 * this.body.Height);

                while (this.body.X != dest.X || this.body.Y != dest.Y)
                {
                    while (this.body.X != dest.X)
                    {
                        if (this.body.X < dest.X)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > dest.X)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(this.speed);
                    }
                    while (this.body.Y != dest.Y)
                    {
                        if (this.body.Y < dest.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > dest.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(this.speed);
                    }
                }
                this.status = CustomerStatus.readyToPickUp;
            }
            else
            {
                int ind = -1 ;
                Customer last = null;
                while (last == null)
                {
                    try
                    {
                        for (ind = 0; ind < shelf.Queue.Count; ind++)
                            if (this == shelf.Queue.ElementAt(ind))
                                break;
                        last = shelf.Queue.ElementAt(ind - 1);
                    }
                    catch (Exception ex)
                    {
                        last = null;
                    }
                }
                int offsetX = 0;
                if (shelf.DirectionOfApproach == 1)
                {
                    offsetX = last.body.Width;
                    if (ind >=5)
                        offsetX += MainForm.DXY * 3;
                }
                else if (shelf.DirectionOfApproach == 2)
                {
                    offsetX = -last.body.Width;
                    if (ind >=5)
                        offsetX -= MainForm.DXY * 3;
                }

                    while (this.body.X != last.Body.X + offsetX || this.body.Y != last.Body.Bottom + MainForm.DXY * 4 || last.Status == CustomerStatus.moving)
                {
                    while (this.body.X != last.Body.X + offsetX)
                    {
                        if (this.body.X < last.Body.X + offsetX)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > last.Body.X + offsetX)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(this.speed);
                    }
                    if (ind < 5)
                    while (this.body.Y != last.Body.Bottom + MainForm.DXY * 4)
                    {
                        if (this.body.Y < last.Body.Bottom + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > last.Body.Bottom + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(this.speed);
                    }
                }
                this.status = CustomerStatus.staying;
            }
        }

        private void MoveToExit(Object obj)
        {
            Rectangle exit = (Rectangle)obj;
            int offsetY = exit.Bottom+this.body.Height;
            while (this.body.Y != offsetY)
            {
                this.Move(new Point(this.body.X, this.body.Y - 1));
                Thread.Sleep(this.speed);
            }
            int offsetX = Randomizer.Rand(this.body.Width, exit.Width/2)/this.body.Width*this.body.Width;
            if (this.body.Left < exit.X + exit.Width/2 - offsetX)
                while (this.body.Left != exit.X +exit.Width/2 - offsetX)
                {

                    this.Move(new Point(this.body.X + 1, this.body.Y));
                    Thread.Sleep(this.speed);
                }
            if (this.body.Right >exit.X + exit.Width/2 + offsetX)
                while (this.body.Right != exit.X + exit.Width / 2 + offsetX)
                {
                    this.Move(new Point(this.body.X - 1, this.body.Y));
                    Thread.Sleep(this.speed);
                }

            while (this.body.Y != exit.Top)
            {
                if (this.body.Y < exit.Top)
                    this.Move(new Point(this.Body.X, this.Body.Y + 1));
                if (this.body.Y > exit.Top)
                    this.Move(new Point(this.Body.X, this.Body.Y - 1));
                Thread.Sleep(this.speed);
            }
            this.status = CustomerStatus.exited;

        }

        public void FillTheCart(ProductShelf shelf)
        {
            do
            {
                this.shoppingList[ProductType.food] = Randomizer.Rand(0, this.money % 10 + 5);
                this.shoppingList[ProductType.goods] = Randomizer.Rand(0, this.money % 10 + 5);
            } while (this.shoppingList[ProductType.food]+this.shoppingList[ProductType.goods] <= 0);
            PriceSegment segment = new PriceSegment();
            int Try = 1,
                totalCost = 0;
            do
            {
                totalCost = 0;
                for (int i = 0; i < this.shoppingList[ProductType.food]; i++)
                {
                    Product food = null;
                    while (food == null)
                    {
                        int seg = Randomizer.Rand(0, 4);
                        if (seg <= 1) segment = PriceSegment.low;
                        if (seg > 1 && seg < 4) segment = PriceSegment.medium;
                        if (seg == 4) segment = PriceSegment.premium;
                        food = shelf.FoodShelf.Find(pr => pr.PriceSegment == segment);
                        shelf.FoodShelf.Remove(food);
                    }
                    this.shoppingCart.Push(food);
                    totalCost += food.Price;
                }
                for (int i = 0; i < this.shoppingList[ProductType.goods]; i++)
                {
                    Product goods = null;
                    while (goods == null)
                    {
                        int seg = Randomizer.Rand(0, 4);
                        if (seg <= 1) segment = PriceSegment.low;
                        if (seg > 1 && seg < 4) segment = PriceSegment.medium;
                        if (seg == 4) segment = PriceSegment.premium;
                        goods = shelf.GoodsShelf.Find(pr => pr.PriceSegment == segment);
                        shelf.GoodsShelf.Remove(goods);
                    }
                    this.ShoppingCart.Push(goods);
                    totalCost += goods.Price;
                }
                if (totalCost > this.money)
                {
                    while (this.shoppingCart.Count > 0)
                    {
                        Product ret = shoppingCart.Pop();
                        if (ret.Type == ProductType.food)
                            shelf.FoodShelf.Add(ret);
                        else
                            shelf.GoodsShelf.Add(ret);
                    }
                    if (Try % 5 == 0)
                    {
                        int rand = Randomizer.Rand(1, 2);
                        if (rand == 1 && this.shoppingList[ProductType.food] > 0) this.shoppingList[ProductType.food]--;
                        if (rand == 2 && this.shoppingList[ProductType.goods] > 0) this.shoppingList[ProductType.goods]--;
                    }
                    Try++;
                }
            } while (totalCost > this.money);
        }

        public void MakePayment(int check)
        {
            this.money -= check;
        }

        public override string ToString()
        {
            string info = String.Format("Покупатель №{0}\nВозраст: {1}\nБаланс кошелька: {2} руб.\nКорзина:\nКоличество пищевых продуктов: {3}\nКоличество хозяйственных товаров: {4}",
                Convert.ToString(this.Id), Convert.ToString(this.age), Convert.ToString(this.money), Convert.ToString(this.ShoppingList[ProductType.food]),
                Convert.ToString(this.ShoppingList[ProductType.goods]));
            return info;
        }
    }
}
