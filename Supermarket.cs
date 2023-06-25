using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal class Supermarket
    {
        Size sceneSize;
        int cashierSpeed;

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

        private List<Cashier> cashiers;
        public List<Cashier> Cashiers
        {
            get { return cashiers; }
        }
        private List<ProductShelf> shelves;
        public List<ProductShelf> Shelves
        {
            get { return shelves; }
        }

        public Supermarket(int countOfDesks, int countOfShelves, int cashierSpeed, Size sizeOfScene)
        {
            this.sceneSize = sizeOfScene;
            this.cashierSpeed = cashierSpeed;
            desks = new List<CashDesk>();
            cashiers = new List<Cashier>();
            for (int i = 0; i < countOfDesks; i++)
            {
                if (i == 0)
                {

                    desks.Add(new CashDesk(new Point(sceneSize.Width / 5, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed));
                    desks[i].Cashier = cashiers[i];
                }
                if (i == 1)
                {
                    desks.Add(new CashDesk(new Point(sceneSize.Width / 2, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed));
                    desks[i].Cashier = cashiers[i];
                }
                if (i == 2)
                {
                    desks.Add(new CashDesk(new Point(sceneSize.Width - sceneSize.Width / 5, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed));
                    desks[i].Cashier = cashiers[i];
                }
            }
            shelves = new List<ProductShelf>();
            for(int i = 0; i < countOfShelves; i++)
            {
                if(i==0)
                    shelves.Add(new ProductShelf(new Point(0, sceneSize.Height / 2), new Size(MainForm.DXY * 10, MainForm.DXY * 40), Color.Brown, 1000, 1000));
                if (i == 1)
                    shelves.Add(new ProductShelf(new Point(sizeOfScene.Width-MainForm.DXY*10, sceneSize.Height / 2), new Size(MainForm.DXY * 10, MainForm.DXY * 40), Color.Brown, 1000, 1000));
            }
            customers = new List<Customer>();
        }

        public void AddCustomer()
        {
            Customer newCustomer = new Customer(new Point(sceneSize.Width / 2, sceneSize.Height - MainForm.DXY * 10), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Green);
            customers.Add(newCustomer);
            int min = 100; int max = -1;
            for (int i = 0; i < desks.Count; i++)
            {
                if (desks[i].CountOfCustomers < min)
                    min = desks[i].CountOfCustomers;
                if (desks[i].CountOfCustomers > max)
                    max = desks[i].CountOfCustomers;
            }
            if (min == CashDesk.MaxCustomers)
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
                    if (min == desks[i].CountOfCustomers)
                    {
                        this.desks[i].AddCustomerToQueue(newCustomer);
                        break;
                    }
            }
        }

        public void Shoppings()
        {
            foreach (CashDesk desk in this.desks)
            {
                if (desk.Status == DeskStatus.open && desk.Queue.Count != 0 && desk.Queue.Peek().Status == CustomerStatus.readyToShop)
                {
                    desk.Status = DeskStatus.busy;
                    int check = 0;
                    Customer customer = desk.Queue.Peek();
                    Task task = new Task(async () =>
                    {

                        for (int i = 0; i < customer.Cart.CountOfProducts; i++)
                        {
                            check += desk.Cashier.ScanProduct(customer);
                            await Task.Delay(desk.Cashier.Speed);
                        }
                        if (customer.Age >= 60)
                        {
                            check = check - (check * 5 / 100);
                        }
                        desk.Checks.Add(check);
                        customer.MakePayment(check);
                        desk.Queue.Dequeue();
                        customer.MoveTo(new Point(this.sceneSize.Width / 2, 0));
                        desk.UpdateQueue();
                        desk.Status = DeskStatus.open;
                    });
                    //Thread thread = new Thread(() =>
                    //  {

                    //      for (int i = 0; i < customer.Cart.CountOfProducts; i++)
                    //      {
                    //          check += desk.Cashier.ScanProduct(customer);
                    //          Thread.Sleep(desk.Cashier.Speed);
                    //      }
                    //      if (customer.Age >= 60)
                    //      {
                    //          check = check - (check * 5 / 100);
                    //      }
                    //      desk.Checks.Add(check);
                    //      customer.MakePayment(check);
                    //      desk.Queue.Dequeue();
                    //      customer.MoveTo(new Point(this.sceneSize.Width/2, 0));
                    //      desk.UpdateQueue();
                    //      desk.Status = DeskStatus.open;
                    //  });
                    task.Start();

                }
            }
        }
    }
}
