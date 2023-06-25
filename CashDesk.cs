using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Praktika2023
{
    enum DeskStatus
    {
        open,
        busy,
        closed
    }


    internal class CashDesk
    {
        private int averageCheck;
        private List<int> checks;
        public List<int> Checks
        {
            get { return checks; }
        }
        private static int maxCustomers = 10;
        public static int MaxCustomers
        {
            get { return maxCustomers; }
        }
        private Rectangle form;
        public Rectangle Form
        {
            get { return form; }
        }
        private Color color;
        public Color Color
        {
            get { return color; }
        }
        private int income;
        public int Income
        {
            get
            {
                income = checks.Sum();
                return income;
            }

        }
        private Queue<Customer> queue;
        public Queue<Customer> Queue
        {
            get { return queue; }
        }
        private int countOfCustomers;
        public int CountOfCustomers
        {
            get
            {
                countOfCustomers = queue.Count;
                return countOfCustomers;
            }

        }
        private Cashier cashier;
        public Cashier Cashier
        {
            get { return cashier; }
            set
            {
                cashier = value;
                this.status = DeskStatus.open;
            }
        }
        private DeskStatus status;
        public DeskStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public CashDesk(Point position, Size size, Color color)
        {
            this.color = color;
            this.form = new Rectangle(position.X, position.Y, size.Width, size.Height);
            this.queue = new Queue<Customer>();
            this.checks = new List<int>();
            this.income = 0;
            this.status = DeskStatus.closed;
        }

        public void AddCustomerToQueue(Customer customer)
        {

            if (queue.Count != 0)
                customer.MoveTo(this.queue.ElementAt(this.queue.Count - 1));
            else
                customer.MoveTo(this);
            this.queue.Enqueue(customer);
        }

        public void Shop()
        {
            this.status = DeskStatus.busy;
            int check = 0;
            Customer customer = this.queue.Peek();
            for (int i = 0; i < customer.Cart.CountOfProducts; i++)
            {
                check += cashier.ScanProduct(customer);
                Thread.Sleep(cashier.Speed);
            }
            if (customer.Age >= 60)
            {
                check = check - (check * 5 / 100);
            }
            this.checks.Add(check);
            customer.MakePayment(check);
            this.queue.Dequeue();
            customer.MoveTo(new Point(500, 0));
            UpdateQueue();
            this.status = DeskStatus.open;
        }

        public void UpdateQueue()
        {
            if (this.queue.Count == 0) return;
            if (this.queue.Peek().Thread.IsAlive==true)
                this.queue.Peek().Thread.Abort();
            this.queue.Peek().MoveTo(this);
            for (int i = 1; i < this.Queue.Count; i++)
            {
                if (this.queue.ElementAt(i).Thread.IsAlive == true)
                    this.queue.ElementAt(i).Thread.Abort();
                this.queue.ElementAt(i).MoveTo(this.queue.ElementAt(i - 1));
            }
        }


        public override string ToString()
        {
            string info = "Касса\n" + "Собранная сумма денег: " + Convert.ToString(this.Income) + " руб.";
            return info;
        }
    }
}
