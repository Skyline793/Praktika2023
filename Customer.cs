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
        readyToPickUp
    }

    internal class Customer : Person
    {

        private Dictionary<ProductType, int> shoppingList;
        private List<Product> shoppingCart;
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
        private ShoppingCart cart;
        public ShoppingCart Cart
        {
            get { return cart; }
            set { cart = value; }
        }
        public Customer(Point position, Size size, Color color) :
            base(position, size, color)
        {

            this.shoppingList = new Dictionary<ProductType, int>();
            this.shoppingCart = new List<Product>();


            Random random = new Random();
            this.age = random.Next(10, 85);
            if (this.age < 18)
                this.money = random.Next(50, 1051);
            else if (this.age < 60)
                this.money = random.Next(500, 5501);
            else
                this.money = random.Next(200, 2201);
            this.Id = random.Next(1, 101);

            this.status = CustomerStatus.staying;
        }

        public override void Move(Point Dest)
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
            if (obj.GetType() == typeof(Point))
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
                        Thread.Sleep(5);
                    }
                    while (this.body.Y != dest.Form.Y)
                    {
                        if (this.body.Y < dest.Form.Y)
                            this.MoveTo(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > dest.Form.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(5);
                    }
                }
                this.status = CustomerStatus.readyToPay;
            }
            else
            {
                int ind;
                for (ind = 0; ind < dest.Queue.Count; ind++)
                {
                    if (dest.Queue.ElementAt(ind).Equals(this) == true)
                        break;
                }
                Customer last = dest.Queue.ElementAt(ind - 1);
                while (this.body.X != last.Body.X || this.body.Y != last.Body.Y + last.Body.Height + MainForm.DXY * 4 || last.Status == CustomerStatus.moving)
                {
                    while (this.body.X != last.Body.X)
                    {
                        if (this.body.X < last.Body.X)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > last.Body.X)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(5);
                    }
                    while (this.body.Y != last.Body.Y + last.Body.Height + MainForm.DXY * 4)
                    {
                        if (this.body.Y < last.Body.Y + last.Body.Height + MainForm.DXY * 4)
                            this.MoveTo(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > last.Body.Y - last.Body.Height + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(5);
                    }
                }
                this.status = CustomerStatus.staying;
            }
        }
        private void MoveToShelf(Object obj)
        {

            ProductShelf shelf = (ProductShelf)obj;
            bool canCollect = false;
            int ind;

            if (shelf.Queue.Count ==0)
                canCollect = true;
            else if (this == shelf.Queue.Peek())
                canCollect = true;
            for (ind = 0; ind < shelf.Queue.Count; ind++)
                if (this == shelf.Queue.ElementAt(ind))
                    break;

            if (canCollect)
            {
                Point dest = new Point();
                //if (shelf.Slots[0] == SlotStatus.available)
                //{

                //    shelf.Slots[0] = SlotStatus.busy;
                //}
                //else if (shelf.Slots[1] == SlotStatus.available)
                //{
                //    dest = new Point(shelf.Form.Right + MainForm.DXY * 4, shelf.Form.Bottom - 3 * this.body.Height);
                //    shelf.Slots[1] = SlotStatus.busy;
                //}
                if (shelf.DirectionOfApproach == 1)
                    dest = new Point(shelf.Form.Right + MainForm.DXY * 4, shelf.Form.Top + 3 * this.body.Height);
                else if (shelf.DirectionOfApproach == 2)
                    dest = new Point(shelf.Form.Left - this.body.Width - MainForm.DXY * 4, shelf.Form.Top + 3 * this.body.Height);

                while (this.body.X != dest.X || this.body.Y != dest.Y)
                {
                    while (this.body.X != dest.X)
                    {
                        if (this.body.X < dest.X)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > dest.X)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(5);
                    }
                    while (this.body.Y != dest.Y)
                    {
                        if (this.body.Y < dest.Y)
                            this.MoveTo(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > dest.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(5);
                    }
                }

            }
            else
            {
                Customer last = shelf.Queue.ElementAt(ind - 1);
                int offset = 0;
                if (shelf.DirectionOfApproach == 1)
                    offset = last.body.Width;
                else if (shelf.DirectionOfApproach == 2)
                    offset = -last.body.Width;
                while (this.body.X != last.Body.X+offset || this.body.Y != last.Body.Y + MainForm.DXY * 4)
                {
                    while (this.body.X != last.Body.X+offset)
                    {
                        if (this.body.X < last.Body.X+offset)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > last.Body.X+offset)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(5);
                    }

                    while (this.body.Y != last.Body.Top + last.Body.Height+  MainForm.DXY * 4)
                    {
                        if (this.body.Y < last.Body.Top + last.Body.Height + MainForm.DXY * 4)
                            this.MoveTo(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > last.Body.Top + last.Body.Height + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(5);
                    }
                }
            }
            if (canCollect)
                this.status = CustomerStatus.readyToPickUp;
            else
                this.status = CustomerStatus.staying;
        }

        private void MoveToExit(Object obj)
        {
            Point dest = (Point)obj;
            int destY = this.body.Y - this.body.Height - MainForm.DXY * 4;
            while (this.body.Y != destY)
            {
                this.Move(new Point(this.body.X, this.body.Y - 1));
                Thread.Sleep(5);
            }
            int offsetX = (Randomizer.Rand(0, MainForm.DXY * 15));
            if (this.body.X < dest.X - offsetX)
                while (this.body.X != dest.X - offsetX)
                {
                    this.Move(new Point(this.body.X + 1, this.body.Y));
                    Thread.Sleep(5);
                }
            if (this.body.X > dest.X + offsetX)
                while (this.body.X != dest.X + offsetX)
                {
                    this.Move(new Point(this.body.X - 1, this.body.Y));
                    Thread.Sleep(5);
                }
            while (this.body.Y != dest.Y - this.body.Height)
            {
                if (this.body.Y < dest.Y - this.body.Height)
                    this.MoveTo(new Point(this.Body.X, this.Body.Y + 1));
                if (this.body.Y > dest.Y - this.body.Height)
                    this.Move(new Point(this.Body.X, this.Body.Y - 1));
                Thread.Sleep(5);
            }
            this.status = CustomerStatus.staying;

        }

        public void MakePayment(int check)
        {
            this.money -= check;
        }

        public override string ToString()
        {
            string info = "Покупатель №" + Convert.ToString(this.Id) + "\nВозраст: " + Convert.ToString(this.age) + "\nБаланс кошелька: " + Convert.ToString(this.money) + " руб."
                + "\nКоличество товаров в корзине: " + Convert.ToString(this.cart.CountOfProducts) + "\nCуммарная стоимость: " +
                Convert.ToString(this.cart.TotalCost) + " руб.";
            return info;
        }
    }
}
