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
        public Customer(Point position, Size size, Color color, int ID) :
            base(position, size, color, ID)
        {

            this.shoppingList = new Dictionary<ProductType, int>();
            this.shoppingCart = new List<Product>();

            this.age = Randomizer.Rand(10, 85);
            if (this.age < 18)
            {
                this.money = Randomizer.Rand(50, 1000);
                this.speed = 5;
            }
            else if (this.age < 60)
            {
                this.money = Randomizer.Rand(500, 5000);
                this.speed = 10;
            }
            else
            {
                this.money = Randomizer.Rand(200, 2000);
                this.speed = 15;
            }

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
                int ind;
                for (ind = 0; ind < dest.Queue.Count; ind++)
                {
                    if (dest.Queue.ElementAt(ind).Equals(this) == true)
                        break;
                }
                Customer last = dest.Queue.ElementAt(ind - 1);
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
            bool canCollect = false;
            int ind;

            if (shelf.Queue.Count == 0)
                canCollect = true;
            else if (this == shelf.Queue.Peek())
                canCollect = true;
            for (ind = 0; ind < shelf.Queue.Count; ind++)
                if (this == shelf.Queue.ElementAt(ind))
                    break;

            if (canCollect)
            {
                Point dest = new Point();
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

            }
            else
            {
                Customer last = shelf.Queue.ElementAt(ind - 1);
                int offset = 0;
                if (shelf.DirectionOfApproach == 1)
                    offset = last.body.Width;
                else if (shelf.DirectionOfApproach == 2)
                    offset = -last.body.Width;
                while (this.body.X != last.Body.X + offset || this.body.Y != last.Body.Bottom + MainForm.DXY * 4 || last.Status == CustomerStatus.moving)
                {
                    while (this.body.X != last.Body.X + offset)
                    {
                        if (this.body.X < last.Body.X + offset)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > last.Body.X + offset)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(this.speed);
                    }

                    while (this.body.Y != last.Body.Top + last.Body.Height + MainForm.DXY * 4)
                    {
                        if (this.body.Y < last.Body.Bottom + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > last.Body.Bottom + MainForm.DXY * 4)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(this.speed);
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
            int destY = dest.Y + MainForm.DXY * 10;
            while (this.body.Y != destY)
            {
                this.Move(new Point(this.body.X, this.body.Y - 1));
                Thread.Sleep(this.speed);
            }
            int offsetX = Randomizer.Rand(0, 3)*this.body.Width;
           // while (this.body.X != dest.X && this.Body.Y != dest.Y)
            {
                if (this.body.Right < dest.X-offsetX)
                    while (this.body.Right != dest.X - offsetX)
                    {

                        this.Move(new Point(this.body.X + 1, this.body.Y));
                        Thread.Sleep(this.speed);
                    }
                if (this.body.Left > dest.X+offsetX)
                    while (this.body.Left != dest.X + offsetX)
                    {
                        this.Move(new Point(this.body.X - 1, this.body.Y));
                        Thread.Sleep(this.speed);
                    }
            }
            while (this.body.Y != dest.Y)
            {
                if (this.body.Y < dest.Y)
                    this.Move(new Point(this.Body.X, this.Body.Y + 1));
                if (this.body.Y > dest.Y)
                    this.Move(new Point(this.Body.X, this.Body.Y - 1));
                Thread.Sleep(this.speed);
            }
            this.status = CustomerStatus.exited;

        }

        public void MakePayment(int check)
        {
            this.money -= check;
        }

        public override string ToString()
        {
            string info = String.Format("Покупатель №{0}\nВозраст: {1}\nБаланс кошелька: {2} руб.", Convert.ToString(this.Id), Convert.ToString(this.age), Convert.ToString(this.money));
            return info;
        }
    }
}
