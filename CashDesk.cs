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
            this.queue.Enqueue(customer);
            customer.MoveTo(this);
            
        }

        public void UpdateQueue()
        {
            if (this.queue.Count == 0) return;
            for (int i = 0; i < this.Queue.Count; i++)
            {
                if (this.queue.ElementAt(i).Thread.IsAlive == true)
                    this.queue.ElementAt(i).Thread.Abort();
                this.queue.ElementAt(i).MoveTo(this);
            }
        }


        public override string ToString()
        {
            string info = "Касса\n" + "Собранная сумма денег: " + Convert.ToString(this.Income) + " руб.";
            return info;
        }
    }
}
