using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal class Supermarket
    {
        Size sceneSize;
        int cashierSpeed;

        //private int totalIncome;
        public int TotalIncome
        {
            get
            {
                int totalIncome = 0;
                foreach (CashDesk desk in desks)
                    totalIncome += desk.Income;
                return totalIncome;
            }
        }
        //private int averageCheck;
        public int AverageCheck
        {
            get
            {
                int averageCheck = 0;
                foreach (CashDesk desk in desks)
                    averageCheck += desk.DeskAverageCheck;
                averageCheck /= desks.Count;
                return averageCheck;
            }
        }
        public int ServedCustomers
        {
            get
            {
                int servedCustomers = 0;
                foreach (CashDesk desk in desks)
                    servedCustomers += desk.ServedCustomers;
                return servedCustomers;
            }
        }
        private int countOfCustomers;
        public int CountOfCustomers
        {
            get { return countOfCustomers; }
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
                    cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed, 1));
                    desks[i].Cashier = cashiers[i];
                }
                if (i == 1)
                {
                    desks.Add(new CashDesk(new Point(sceneSize.Width / 2, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed, 1));
                    desks[i].Cashier = cashiers[i];
                }
                if (i == 2)
                {
                    desks.Add(new CashDesk(new Point(sceneSize.Width - sceneSize.Width / 5, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed, 1));
                    desks[i].Cashier = cashiers[i];
                }
            }
            shelves = new List<ProductShelf>();
            for (int i = 0; i < countOfShelves; i++)
            {
                if (i == 0)
                    shelves.Add(new ProductShelf(new Point(0, sceneSize.Height / 2), new Size(MainForm.DXY * 10, MainForm.DXY * 30), Color.Brown, 1, 200, 200));
                if (i == 1)
                    shelves.Add(new ProductShelf(new Point(sizeOfScene.Width - MainForm.DXY * 10, sceneSize.Height / 2), new Size(MainForm.DXY * 10, MainForm.DXY * 30), Color.Brown, 2, 200, 200));
            }
            customers = new List<Customer>();
            this.countOfCustomers = 0;
        }

        public void AddCustomer()
        {
            if (shelves.Count == 1 && shelves[0].Queue.Count == ProductShelf.MaxCustomers)
            {
                    return;
            }
            if (shelves.Count==2 && shelves[0].Queue.Count == ProductShelf.MaxCustomers && shelves[1].Queue.Count == ProductShelf.MaxCustomers)
                return;
            Customer newCustomer = new Customer(new Point(sceneSize.Width / 2, sceneSize.Height - MainForm.DXY * 10), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Green, ++countOfCustomers);
            customers.Add(newCustomer);
            if (shelves.Count == 1)
                shelves[0].AddCustomerToQueue(newCustomer);
            else
            {
                if (shelves[0].Queue.Count < shelves[1].Queue.Count)
                    shelves[0].AddCustomerToQueue(newCustomer);
                else if (shelves[0].Queue.Count > shelves[1].Queue.Count)
                    shelves[1].AddCustomerToQueue(newCustomer);
                else
                    shelves[Randomizer.Rand(0, 1)].AddCustomerToQueue(newCustomer);
            }

        }

        public void SendCustomerToCashDesk(Customer customer)
        {
            int min = desks[0].CountOfCustomers;
            for (int i = 1; i < desks.Count; i++)
            {
                if (desks[i].CountOfCustomers < min)
                    min = desks[i].CountOfCustomers;
            }
            int ind = -1;
            int distance = int.MaxValue;
            for(int i = 0; i < desks.Count; i++)
            {
                if(desks[i].Queue.Count==min && Math.Abs(customer.Body.X - desks[i].Form.X) < distance)
                {
                    distance = Math.Abs(customer.Body.X - desks[i].Form.X);
                    ind = i;
                }
            }
            this.desks[ind].AddCustomerToQueue(customer);
        }

        public void Shoppings()
        {
            foreach (CashDesk desk in this.desks)
            {
                if (desk.Status == DeskStatus.open && desk.Queue.Count != 0 && desk.Queue.Peek().Status == CustomerStatus.readyToPay)
                {
                    desk.Status = DeskStatus.busy;
                    int check = 0;
                    Customer customer = desk.Queue.Peek();
                    Task task = new Task(async () =>
                    {

                        for (int i = 0; i < customer.Cart.CountOfProducts; i++)
                        {
                            check += desk.Cashier.ScanProduct(customer);
                        }
                        await Task.Delay(desk.Cashier.ScanSpeed*customer.Cart.CountOfProducts);
                        if (customer.Age >= 60)
                        {
                            check = check - (check * 5 / 100);
                        }
                        desk.Checks.Add(check);
                        customer.MakePayment(check);
                        desk.Queue.Dequeue();
                        if (MainForm.simulation)
                        {
                            customer.MoveTo(new Point(this.sceneSize.Width / 2, 0));
                            desk.UpdateQueue();
                        }
                        desk.Status = DeskStatus.open;
                    });
                    task.Start();

                }
            }
        }

        public void PickingUp()
        {
            foreach (ProductShelf shelf in this.Shelves)
            {
                if (shelf.Queue.Count != 0 && shelf.Queue.Peek().Status == CustomerStatus.readyToPickUp)
                {
                    Customer customer = shelf.Queue.Peek();
                    customer.Status = CustomerStatus.staying;
                    Task task = new Task(async () =>
                    {
                        customer.Cart.FillTheCart(customer.Money, shelf);
                            await Task.Delay(customer.Cart.CountOfProducts*1000);
                        bool canGo = false;
                        while (!canGo)
                        {
                            if (desks.Count == 1 && desks[0].Queue.Count < CashDesk.MaxCustomers)
                                canGo = true;
                            if (desks.Count == 2 && (desks[0].Queue.Count < CashDesk.MaxCustomers || desks[1].Queue.Count < CashDesk.MaxCustomers))
                                canGo = true;
                            if (desks.Count == 3 && (desks[0].Queue.Count < CashDesk.MaxCustomers || desks[1].Queue.Count < CashDesk.MaxCustomers || desks[2].Queue.Count < CashDesk.MaxCustomers))
                                canGo = true;
                        }
                        shelf.Queue.Dequeue();
                        if (MainForm.simulation)
                        {
                            this.SendCustomerToCashDesk(customer);
                            shelf.UpdateQueue();
                        }
                    });
                    task.Start();
                }
            }
        }
    }
}
