using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Praktika2023
{
    /// <summary>Класс Супермаркет, реализующий взаимодействие других классов</summary>
    internal class Supermarket
    {
        /// <summary>Массив покупателей</summary>
        private List<Customer> customers;
        /// <summary>Массив покупателей</summary>
        public List<Customer> Customers
        {
            get { return customers; } //геттер
        }
        /// <summary>Массив касс</summary>
        private List<CashDesk> desks;
        /// <summary>Массив касс</summary>
        public List<CashDesk> Desks
        {
            get { return desks; } //геттер
        }
        /// <summary>Массив кассиров</summary>
        private List<Cashier> cashiers;
        /// <summary>Массив кассиров</summary>
        public List<Cashier> Cashiers
        {
            get { return cashiers; } //геттер
        }
        /// <summary>Массив полок с товарами</summary>
        private List<ProductShelf> shelves;
        /// <summary>Массив полок с товарами</summary>
        public List<ProductShelf> Shelves
        {
            get { return shelves; } //геттер
        }
        /// <summary>Менеджер</summary>
        private Manager manager;
        /// <summary>Менеджер</summary>
        public Manager Manager
        {
            get { return manager; } //геттер
        }
        /// <summary>Счетчик покупателей</summary>
        private int countOfCustomers;
        /// <summary>Максимально число покупателей в очереди у полки с товарами</summary>
        private static int shelfMaxCustomers = 10;
        /// <summary>максимальное число покупателей в очереди у кассы</summary>
        private static int deskMaxCustomers = 7;
        /// <summary>Суммарный доход всех касс</summary>
        public int TotalIncome
        {
            get //геттер
            {
                int totalIncome = 0;
                foreach (CashDesk desk in desks)
                    totalIncome += desk.Income;
                return totalIncome;
            }
        }
        /// <summary>Средний чек всех касс</summary>
        public int AverageCheck
        {
            get //геттер
            {
                int averageCheck = 0;
                if (this.ServedCustomers > 0)
                    averageCheck = this.TotalIncome / this.ServedCustomers;
                return averageCheck;
            }
        }
        /// <summary>Число обслуженных покупателей в магазине</summary>
        public int ServedCustomers
        {
            get //геттер
            {
                int servedCustomers = 0;
                foreach (CashDesk desk in desks)
                    servedCustomers += desk.ServedCustomers;
                return servedCustomers;
            }
        }
        /// <summary>Прямоугольник, соответствующий входу в магазин</summary>
        private Rectangle entranceDoor;
        /// <summary>Прямоугольник, соответствующий выходу из магазина</summary>
        private Rectangle exitDoor;

        /// <summary>
        /// Конструктор класса Супермаркет
        /// </summary>
        /// <param name="countOfDesks">число касс</param>
        /// <param name="countOfShelves">число полок с товарами</param>
        /// <param name="cashierSpeed">скорость сканирования товара</param>
        /// <param name="shopSize">размер магазина</param>
        /// <param name="warehouseDoor">прямоугольник, соответствующий двери на склад</param>
        /// <param name="entrance">прямоугольник, соответствующий входу в магазин</param>
        /// <param name="exit">прямоугольник, соответствующий выходу из магазина</param>
        public Supermarket(int countOfDesks, int countOfShelves, int cashierSpeed, Size shopSize, Rectangle warehouseDoor, Rectangle entranceDoor, Rectangle exitDoor)
        {
            this.desks = new List<CashDesk>();
            this.cashiers = new List<Cashier>();
            for (int i = 0; i < countOfDesks; i++) //создаем кассы
            {
                if (i == 0) //создаем первую кассу и первого кассира
                {
                    if (countOfDesks == 1)
                        this.desks.Add(new CashDesk(new Point(shopSize.Width / 2, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    else if (countOfDesks == 2)
                        this.desks.Add(new CashDesk(new Point(shopSize.Width / 3, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    else
                        this.desks.Add(new CashDesk(new Point(shopSize.Width / 5, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    this.cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed, 1));
                    this.desks[i].Cashier = cashiers[i];
                }
                if (i == 1) //содаем вторую кассу, если она есть, и второго кассира
                {
                    if (countOfDesks == 2)
                        this.desks.Add(new CashDesk(new Point(shopSize.Width - shopSize.Width / 3, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    else
                        this.desks.Add(new CashDesk(new Point(shopSize.Width / 2, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    this.cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed, 1));
                    this.desks[i].Cashier = cashiers[i];
                }
                if (i == 2) //создаем третью кассу, если она есть, и третьего кассира
                {
                    this.desks.Add(new CashDesk(new Point(shopSize.Width - shopSize.Width / 5, MainForm.DXY * 20), new Size(MainForm.DXY * 8, MainForm.DXY * 12), Color.Gray));
                    this.cashiers.Add(new Cashier(new Point(desks[i].Form.Right + MainForm.DXY * 2, desks[i].Form.Top + desks[i].Form.Size.Height / MainForm.DXY), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Blue, cashierSpeed, 1));
                    this.desks[i].Cashier = cashiers[i];
                }
            }
            this.shelves = new List<ProductShelf>();
            for (int i = 0; i < countOfShelves; i++) //создаем полки
            {
                if (i == 0) //создаем первую полку
                    this.shelves.Add(new ProductShelf(new Point(0, shopSize.Height / 2), new Size(MainForm.DXY * 10, MainForm.DXY * 25), Color.DarkGoldenrod, 1, 70, 70));
                if (i == 1) //создаем вторую полку, если она есть
                    this.shelves.Add(new ProductShelf(new Point(shopSize.Width - MainForm.DXY * 10, shopSize.Height / 2), new Size(MainForm.DXY * 10, MainForm.DXY * 25), Color.DarkGoldenrod, 2, 70, 70));
            }
            this.customers = new List<Customer>();
            this.manager = new Manager(new Point(warehouseDoor.X, warehouseDoor.Bottom), new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Red, 1); //создаем менеджера
            this.countOfCustomers = 0;
            this.entranceDoor = entranceDoor;
            this.exitDoor = exitDoor;
        }

        /// <summary>
        /// Метод добавления нового покупателя в магазин
        /// </summary>
        public void AddCustomer()
        {
            //если в магазине одна полка и очередь к ней переполнена, не добавляем покупателя
            if (this.shelves.Count == 1 && this.shelves[0].Queue.Count == shelfMaxCustomers)
                return;
            //если в магазине две полки и обе очереди переполнены, не добавляем покупателя
            if (this.shelves.Count == 2 && this.shelves[0].Queue.Count == shelfMaxCustomers && this.shelves[1].Queue.Count == shelfMaxCustomers)
                return;
            Point start = new Point(this.entranceDoor.Left + this.entranceDoor.Width / 2 - MainForm.DXY * 2, this.entranceDoor.Top); //точка появления покупателя
            Customer newCustomer = new Customer(start, new Size(MainForm.DXY * 4, MainForm.DXY * 4), Color.Green, ++countOfCustomers);
            this.customers.Add(newCustomer); //создаем покупателя и добавляем в массив
            //если полка одна, отправляем покупателя к полке
            if (this.shelves.Count == 1)
                this.shelves[0].AddCustomerToQueue(newCustomer);
            else //иначе отправляем покупателя к той полке, где меньше очередь
            {
                if (this.shelves[0].Queue.Count < this.shelves[1].Queue.Count)
                    this.shelves[0].AddCustomerToQueue(newCustomer);
                else if (this.shelves[0].Queue.Count > this.shelves[1].Queue.Count)
                    this.shelves[1].AddCustomerToQueue(newCustomer);
                else //если очереди равны, выбираем полку случайно
                    this.shelves[Randomizer.Rand(0, 1)].AddCustomerToQueue(newCustomer);
            }
        }

        /// <summary>
        /// Метод отправки покупателя к кассе
        /// </summary>
        /// <param name="customer">Покупатель</param>
        public void SendCustomerToCashDesk(Customer customer)
        {
            //вычисляем минимальное колмчество человек в очереди к кассам
            int min = desks[0].Queue.Count;
            for (int i = 1; i < desks.Count; i++)
            {
                if (desks[i].Queue.Count < min)
                    min = desks[i].Queue.Count;
            }
            int ind = -1; //индекс кассы в массиве
            int distance = int.MaxValue; //расстояние от кассы до покупателя
            //ищем самую близкую к покупателю кассу с самой маленькой очередью
            for (int i = 0; i < desks.Count; i++)
            {
                if (desks[i].Queue.Count == min && Math.Abs(customer.Body.X - desks[i].Form.X) < distance)
                {
                    distance = Math.Abs(customer.Body.X - desks[i].Form.X);
                    ind = i;
                }
            }
            this.desks[ind].AddCustomerToQueue(customer); //отправляем покупателя к этой кассе
        }

        /// <summary>
        /// Метод обработки работы касс
        /// </summary>
        public void Shoppings()
        {
            foreach (CashDesk desk in this.desks) //для всех касс в массиве
            {
                //если в очереди к кассе есть покупатели и первый покупатель в очереди готов к оплате
                if (desk.Queue.Count != 0 && desk.Queue.Peek().Status == CustomerStatus.readyToPay)
                {
                    int check = 0; //чек 
                    Customer customer = desk.Queue.Peek(); //первый в очереди покупатель
                    customer.Status = CustomerStatus.staying;
                    //инициализируем поток кассы для обработки покупателя
                    desk.Thread = new Thread(() =>
                    {
                        int countOfProducts = customer.ShoppingList[ProductType.food] + customer.ShoppingList[ProductType.goods];
                        //извлекаем все товары из корзины покупателя
                        for (int i = 0; i < countOfProducts; i++)
                        {
                            check += desk.Cashier.ScanProduct(customer);
                        }
                        Thread.Sleep(desk.Cashier.ScanSpeed * countOfProducts); //пауза = число товаров*скорость сканирования
                        //если возраст покупателя >=60, делаем ему скидку 5%
                        if (customer.Age >= 60)
                        {
                            check = check - (check * 5 / 100);
                        }
                        desk.Checks.Add(check); //добавляем чек в массив чеков
                        customer.MakePayment(check); //покупатель оплачивает покупку
                        desk.Queue.Dequeue(); //извлекаем покупателя из очереди
                        customer.MoveToExit(this.exitDoor); //отправляем его к выходу
                        desk.UpdateQueue(); //обновляем очередь
                    });
                    desk.Thread.Start(); //запускаем поток
                }
            }
        }

        /// <summary>
        /// Метод обработки заполнения корзины товаров
        /// </summary>
        public void PickingUp()
        {
            foreach (ProductShelf shelf in this.Shelves) //для всех полок в магазине
            {
                //если в очереди к полке есть покупатели и первый покупатель в очереди готов к выбору
                if (shelf.Queue.Count != 0 && shelf.Queue.Peek().Status == CustomerStatus.readyToPickUp)
                {
                    Customer customer = shelf.Queue.Peek(); //первый покупатель в очереди
                    customer.Status = CustomerStatus.staying;
                    //инициализируем поток для заполнения корзины товаров покупателем
                    shelf.Thread = new Thread(() =>
                    {
                        customer.FillTheCart(shelf); //метод заполнения корзины
                        Thread.Sleep(customer.ShoppingCart.Count * 1000); //пауза = количество товаров * 1с
                        bool canGo = false; //флаг возможности идти к кассе
                        while (!canGo) //цикл до тех пор, пока хотя бы в одной из очередей к кассам не будет свободного места
                        {
                            if (desks.Count == 1 && desks[0].Queue.Count < deskMaxCustomers)
                                canGo = true;
                            if (desks.Count == 2 && (desks[0].Queue.Count < deskMaxCustomers || desks[1].Queue.Count < deskMaxCustomers))
                                canGo = true;
                            if (desks.Count == 3 && (desks[0].Queue.Count < deskMaxCustomers || desks[1].Queue.Count < deskMaxCustomers || desks[2].Queue.Count < deskMaxCustomers))
                                canGo = true;
                        }
                        shelf.Queue.Dequeue(); //извлекаем покупателя из очереди
                        this.SendCustomerToCashDesk(customer); //отправляем покупателя к кассе
                        shelf.UpdateQueue(); //обновляем очередь к полке
                    });
                    shelf.Thread.Start(); //запускаем поток
                }
            }
        }

        /// <summary>
        /// Метод пополнения запасов полок менеджером
        /// </summary>
        public void TopUpTheShelves()
        {
            if (this.manager.Status == ManagerStatus.available) //если менеджер свободен
                foreach (ProductShelf shelf in shelves) //для всех полок в магазине
                {
                    //когда количество товаров в полке опускается до определенного уровня, отправляем к ней менеджера
                    if ((shelf.FoodSection.Count < 50 && shelf.GoodsSection.Count < 50) || shelf.FoodSection.Count < 25 || shelf.GoodsSection.Count < 25)
                    {
                        if (shelf.FoodSection.Count < 25 && shelf.GoodsSection.Count >= 25)
                            this.manager.TopUpTheShelf(shelf, 50, 30);
                        else if (shelf.GoodsSection.Count < 25 && shelf.FoodSection.Count >= 25)
                            this.Manager.TopUpTheShelf(shelf, 30, 50);
                        else if (shelf.FoodSection.Count < 25 && shelf.GoodsSection.Count < 25)
                            this.manager.TopUpTheShelf(shelf, 50, 50);
                        else
                            this.manager.TopUpTheShelf(shelf, 30, 30);
                        break;
                    }
                }
        }

        /// <summary>
        /// Метод проверки переполнения магазина
        /// </summary>
        /// <returns>true, если магазин переполнен, false, если нет</returns>
        public bool IsOverFull()
        {
            //магазин переполнен, если все очереди всех касс и полок равны максимальным значением
            bool overfull = true;
            foreach (var shelf in shelves)
                if (shelf.Queue.Count < shelfMaxCustomers)
                    overfull = false;
            foreach (var desk in desks)
                if (desk.Queue.Count < deskMaxCustomers)
                    overfull = false;
            return overfull;
        }
    }
}
