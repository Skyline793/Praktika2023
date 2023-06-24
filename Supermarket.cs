using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal class Supermarket
    {
        Size sceneSize;
        int minCartCount,
            maxCartCount,
            minCartCost,
            maxCartCost,
            cashierSpeed;

        private int totalIncome;
        public int TotalIncome
        {
            get
            {   
                totalIncome = 0;
                foreach (CashDesk desk in desks)
                    totalIncome += desk.Income;
                return TotalIncome; 
            }
        }
        private List<Customer> customers;
        public List<Customer> Customers
        {
            get { return customers; }
        }
        private List<CashDesk> desks;
        public List<CashDesk> Desks
        {
            get { return desks; }
        }
        public List<Cashier> cashiers;

        public Supermarket(int countOfDesks, int minCartCount, int maxCartCount, int minCartCost, int maxCartCost, int cashierSpeed, Size sizeOfScene)
        {
            this.sceneSize = sizeOfScene;
            this.cashierSpeed = cashierSpeed;
            if (countOfDesks > 0 && countOfDesks < 4)
            {
                desks = new List<CashDesk>();
                cashiers = new List<Cashier>();
                for (int i = 0; i < countOfDesks; i++)
                {
                    if (i == 0)
                    {
                        
                        desks.Add(new CashDesk(new Point(sceneSize.Width / 5, 100), new Size(40, 60), Color.Gray));
                        cashiers.Add(new Cashier(new Point(desks[i].Form.Right+10, desks[i].Form.Top+desks[i].Form.Size.Height/4),new Size(20,20), Color.Blue,cashierSpeed));
                        desks[i].Cashier = cashiers[i];
                    }
                    if (i == 1)
                    {
                        desks.Add(new CashDesk(new Point(sceneSize.Width / 2, 100), new Size(40, 60), Color.Gray));
                        cashiers.Add(new Cashier(new Point(desks[i].Form.Right + 10, desks[i].Form.Top + desks[i].Form.Size.Height / 4), new Size(20, 20), Color.Blue, cashierSpeed));
                        desks[i].Cashier = cashiers[i];
                    }
                    if (i == 2)
                    {
                        desks.Add(new CashDesk(new Point(sceneSize.Width - sceneSize.Width / 5, 100), new Size(40, 60), Color.Gray));
                        cashiers.Add(new Cashier(new Point(desks[i].Form.Right + 10, desks[i].Form.Top + desks[i].Form.Size.Height / 4), new Size(20, 20), Color.Blue, cashierSpeed));
                        desks[i].Cashier = cashiers[i];
                    }
                }
            }
            else throw new Exception("Некорректное число касс!");
            customers = new List<Customer>();
            this.maxCartCount = maxCartCount;
            this.minCartCount = minCartCount;
            this.minCartCost = minCartCost;
            this.maxCartCost = maxCartCost;
            
        }

        public void AddCustomer()
        {
            Customer newCustomer = new Customer(new Point(sceneSize.Width / 2, sceneSize.Height-50), new Size(20, 20), Color.Green,
                minCartCount, maxCartCount, minCartCost, maxCartCost);
            customers.Add(newCustomer);
            int min = 100; int max = -1;
            for(int i = 0; i < desks.Count; i++)
            {
                if (desks[i].CountOfCustomers < min)
                    min = desks[i].CountOfCustomers;
                if(desks[i].CountOfCustomers > max)
                    max = desks[i].CountOfCustomers;
            }
            if(min==CashDesk.MaxCustomers)
            {

            }
            else if (min == max)
            {
                Random rand = new Random();
                int ind = rand.Next(this.desks.Count);
                this.desks[ind].AddCustomerToQueue(newCustomer);
            }
            else
            {
                for (int i = 0; i < desks.Count; i++)
                    if(min== desks[i].CountOfCustomers)
                    {
                        this.desks[i].AddCustomerToQueue(newCustomer);
                        break;
                    }
            }
        }
}
}
