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
        inQueue,
        readyToShop
    }

    internal class Customer : Person
    {
        public Thread thread;
        
        public bool destChanged;
        public bool DestChanged
        {
            set
            {
                destChanged = value;
            }
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
        }
        public Customer(Point position, Size size, Color color, int minCartCount, int maxCartCount, int minCartCost, int maxCartCost) :
            base(position, size, color)
        {
            Random random = new Random();
            this.money = random.Next(4700) + 300;
            this.Id = random.Next(100) + 1;
            cart = new ShoppingCart(money, minCartCount, maxCartCount, minCartCost, maxCartCost);
            this.status=CustomerStatus.moving;
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
                thread = new Thread(this.MoveToCash);
                thread.Start(obj);
            }
            if (obj.GetType() == typeof(Customer))
            {
                thread = new Thread(this.MoveToQueue);
                thread.Start(obj);
            }
        }
        private void MoveToCash(Object obj)
        {
            
            CashDesk dest = (CashDesk)obj;
            while (this.body.X != dest.Form.X - this.body.Width - 10)
            {
                if (MainForm.flag == false) thread.Abort();
                if (this.body.X < dest.Form.X - this.body.Width - 10)
                    this.Move(new Point(this.body.X + 1, this.body.Y));
                if (this.body.X > dest.Form.X - this.body.Width - 10)
                    this.Move(new Point(this.Body.X - 1, this.Body.Y));
                Thread.Sleep(5);
            }
            while (this.body.Y != dest.Form.Y)
            {
                if (MainForm.flag == false) thread.Abort();
                if (this.body.Y < dest.Form.Y)
                    this.MoveTo(new Point(this.Body.X, this.Body.Y + 1));
                if (this.body.Y > dest.Form.Y)
                    this.Move(new Point(this.Body.X, this.Body.Y - 1));
                Thread.Sleep(5);
            }
            this.status = CustomerStatus.readyToShop;
        }
        private void MoveToQueue(Object obj)
        {
            
            Customer dest = (Customer)obj;
            while (this.body.X != dest.Body.X)
            {
                if (MainForm.flag == false) thread.Abort();
                if (this.body.X < dest.Body.X)
                    this.Move(new Point(this.body.X + 1, this.body.Y));
                if (this.body.X > dest.Body.X)
                    this.Move(new Point(this.Body.X - 1, this.Body.Y));
                Thread.Sleep(5);
            }
            while (this.body.Y != dest.Body.Y + dest.Body.Height+20)
            {
                if (MainForm.flag == false) thread.Abort();
                if (this.body.Y < dest.Body.Y + dest.Body.Height + 20)
                    this.MoveTo(new Point(this.Body.X, this.Body.Y + 1));
                if (this.body.Y > dest.Body.Y - dest.Body.Height + 20)
                    this.Move(new Point(this.Body.X, this.Body.Y - 1));
                Thread.Sleep(5);
            }
            this.status = CustomerStatus.inQueue;
        }

        public void MakePayment(int check)
        {
            this.money-=check;
        }

        public override string ToString()
        {
            string info = "Покупатель №" + Convert.ToString(this.Id) + "\nБаланс кошелька: " + Convert.ToString(this.money) +" руб."
                + "\nКоличество товаров в корзине: " + Convert.ToString(this.cart.CountOfProducts) + "\nCуммарная стоимость: " + 
                Convert.ToString(this.cart.TotalCost) + " руб.";
            return info;
        }
    }
}
