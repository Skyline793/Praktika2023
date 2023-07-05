using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Linq;

namespace Praktika2023
{

    /// <summary>Перечисление для статуса покупателя</summary>
    enum CustomerStatus
    {
        /// <summary>в движении</summary>
        moving,
        /// <summary>стоит на месте</summary>
        staying,
        /// <summary>готов к оплате покупок</summary>
        readyToPay,
        /// <summary>готов к выбору товаров</summary>
        readyToPickUp,
        /// <summary>ушел из магазина</summary>
        exited
    }

    /// <summary>Класс Покупатель, наследуемый от Человека</summary>
    internal class Customer : Person
    {
        /// <summary>Статус покупателя</summary>
        private CustomerStatus status;
        public CustomerStatus Status
        {
            get { return status; } //геттер
            set { status = value; } //сеттер
        }
        /// <summary>Баланс кошешлька покупателя</summary>
        private int money;
        /// <summary>Баланс кошешлька покупателя</summary>
        public int Money
        {
            get { return money; }
        }
        /// <summary>Список покупок</summary>
        private Dictionary<ProductType, int> shoppingList;
        /// <summary>Список покупок</summary>
        public Dictionary<ProductType, int> ShoppingList
        {
            get { return shoppingList; } //геттер
        }
        /// <summary>Корзина покупок</summary>
        private Stack<Product> shoppingCart;
        /// <summary>Корзина покупок</summary>
        public Stack<Product> ShoppingCart
        {
            get { return shoppingCart; } //геттер
        }
        /// <summary>Скорость движения покупателя</summary>
        private int speed;
        /// <summary>Поток, в котором двигается покупатель</summary>
        private Thread thread;
        /// <summary>Поток, в котором двигается покупатель</summary>
        public Thread Thread
        {
            get { return thread; } //геттер
        }

        /// <summary>
        /// Конструктоp класса Покупатель
        /// </summary>
        /// <param name="position">Координата левого верхнего угла тела</param>
        /// <param name="size">Размеры тела</param>
        /// <param name="color">Цвет тела</param>
        /// <param name="ID">Индетификатор</param>
        public Customer(Point position, Size size, Color color, int ID) : base(position, size, color, ID)
        {
            this.age = Randomizer.Rand(10, 85); //возраст генерируется случайно
            //баланс генерируется случайно в зависимости от возраста
            if (this.age < 18)
                this.money = Randomizer.Rand(150, 1500);
            else if (this.age <= 60)
                this.money = Randomizer.Rand(600, 5000);
            else
                this.money = Randomizer.Rand(400, 3500);
            this.speed = 10;
            this.shoppingList = new Dictionary<ProductType, int>();
            this.shoppingList[ProductType.food] = 0;
            this.shoppingList[ProductType.goods] = 0;
            this.shoppingCart = new Stack<Product>();
            this.status = CustomerStatus.staying;
            //генерируем случайное количество пищевых и хозяйственных товаров в списке покупок
            do
            {
                this.shoppingList[ProductType.food] = Randomizer.Rand(0, this.money % 10 + 5);
                this.shoppingList[ProductType.goods] = Randomizer.Rand(0, this.money % 10 + 5);
            } while (this.shoppingList[ProductType.food] + this.shoppingList[ProductType.goods] <= 0);
        }

        /// <summary>
        /// Метод движения к кассе
        /// </summary>
        /// <param name="desk">Касса</param>
        public void MoveToCashDesk(CashDesk desk)
        {
            this.status = CustomerStatus.moving;
            //инициализируем новый поток для выполнения движения
            this.thread = new Thread(() =>
            {
                if (desk.Queue.Peek() == this) //если покупатель первый в очереди, двигаемся сразу к кассе
                {
                    //двигаемся по оси X
                    while (this.body.X != desk.Form.X - this.body.Width - MainForm.DXY * 2)
                    {
                        if (this.body.X < desk.Form.X - this.body.Width - MainForm.DXY * 2)
                            this.Move(new Point(this.body.X + 1, this.body.Y));
                        if (this.body.X > desk.Form.X - this.body.Width - MainForm.DXY * 2)
                            this.Move(new Point(this.Body.X - 1, this.Body.Y));
                        Thread.Sleep(this.speed); //пауза
                    }
                    //двигаемся по оси Y
                    while (this.body.Y != desk.Form.Y)
                    {
                        if (this.body.Y < desk.Form.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y + 1));
                        if (this.body.Y > desk.Form.Y)
                            this.Move(new Point(this.Body.X, this.Body.Y - 1));
                        Thread.Sleep(this.speed); //пауза
                    }
                    this.status = CustomerStatus.readyToPay; //статус - готов к оплате
                }


                else //иначе, если покупатель не первый в очереди 
                {
                    Customer prev = null;
                    int ind = -1; //место покупателя в очереди
                    while (prev == null) //находим стоящего впереди покупателя
                    {
                        try
                        {
                            for (ind = 0; ind < desk.Queue.Count; ind++)
                            {
                                if (desk.Queue.ElementAt(ind) == this)
                                    break;
                            }
                            prev = desk.Queue.ElementAt(ind - 1);
                        }
                        catch (Exception ex)
                        {
                            prev = null;
                        }
                    }
                    //двигаемся в очереди за покупателем, стоящим впереди, пока не дойдем до нужной позиции 
                    while (this.body.X != prev.Body.X || this.body.Y != prev.Body.Bottom + MainForm.DXY * 4 || prev.Status == CustomerStatus.moving)
                    {
                        //двигаемся по оси X
                        while (this.body.X != prev.Body.X)
                        {
                            if (this.body.X < prev.Body.X)
                                this.Move(new Point(this.body.X + 1, this.body.Y));
                            if (this.body.X > prev.Body.X)
                                this.Move(new Point(this.Body.X - 1, this.Body.Y));
                            Thread.Sleep(this.speed); //пауза
                        }
                        //двигаемся по оси Y
                        while (this.body.Y != prev.Body.Bottom + MainForm.DXY * 4)
                        {
                            if (this.body.Y < prev.Body.Bottom + MainForm.DXY * 4)
                                this.Move(new Point(this.Body.X, this.Body.Y + 1));
                            if (this.body.Y > prev.Body.Bottom + MainForm.DXY * 4)
                                this.Move(new Point(this.Body.X, this.Body.Y - 1));
                            Thread.Sleep(this.speed); //пауза
                        }
                    }
                    this.status = CustomerStatus.staying; //статус - стоит на месте
                }
            });
            thread.Start(); //запустить поток
        }

        /// <summary>
        /// Метод движения к полке
        /// </summary>
        /// <param name="shelf">Полка с товарами</param>
        public void MoveToShelf(ProductShelf shelf)
        {

            this.status = CustomerStatus.moving;
            //инициализируем новый поток для выполнения движения
            this.thread = new Thread(() =>
             {
                 if (shelf.Queue.Peek() == this) //если покупатель первый в очереди, двигаемся сразу к полке
                 {
                     //вычисляем точку, к которой нужно подойти
                     Point dest = new Point();
                     if (shelf.DirectionOfApproach == 1)
                         dest = new Point(shelf.Form.Right + MainForm.DXY * 4, shelf.Form.Top + 2 * this.body.Height);
                     else if (shelf.DirectionOfApproach == 2)
                         dest = new Point(shelf.Form.Left - this.body.Width - MainForm.DXY * 4, shelf.Form.Top + 2 * this.body.Height);
                     //двигаемся по оси X
                     while (this.body.X != dest.X)
                     {
                         if (this.body.X < dest.X)
                             this.Move(new Point(this.body.X + 1, this.body.Y));
                         if (this.body.X > dest.X)
                             this.Move(new Point(this.Body.X - 1, this.Body.Y));
                         Thread.Sleep(this.speed); //пауза
                     }
                     //двигаемся по оси Y
                     while (this.body.Y != dest.Y)
                     {
                         if (this.body.Y < dest.Y)
                             this.Move(new Point(this.Body.X, this.Body.Y + 1));
                         if (this.body.Y > dest.Y)
                             this.Move(new Point(this.Body.X, this.Body.Y - 1));
                         Thread.Sleep(this.speed); //пауза
                     }
                     this.status = CustomerStatus.readyToPickUp; //статус - готов к выбору товаров
                 }
                 else //иначе, если покупатель не первый в очереди
                 {
                     Customer prev = null;
                     int ind = -1; //место покупателя в очереди
                     while (prev == null) //находим стоящего впереди покупателя
                     {
                         try
                         {
                             for (ind = 0; ind < shelf.Queue.Count; ind++)
                                 if (this == shelf.Queue.ElementAt(ind))
                                     break;
                             prev = shelf.Queue.ElementAt(ind - 1);
                         }
                         catch (Exception ex)
                         {
                             prev = null;
                         }
                     }
                     //вычисляем расстояние между покупателями
                     int offsetX = 0;
                     if (shelf.DirectionOfApproach == 1)
                     {
                         offsetX = prev.body.Width;
                         if (ind >= 5)
                             offsetX += MainForm.DXY * 3;
                     }
                     else if (shelf.DirectionOfApproach == 2)
                     {
                         offsetX = -prev.body.Width;
                         if (ind >= 5)
                             offsetX -= MainForm.DXY * 3;
                     }

                     if (ind < 5) //если покупатель в первой пятерке, подходит к полке лесенкой
                     {
                         //двигаемся в очереди за покупателем, стоящим впереди, пока не дойдем до нужной позиции 
                         while (this.body.X != prev.Body.X + offsetX || this.body.Y != prev.Body.Bottom + MainForm.DXY * 4 || prev.Status == CustomerStatus.moving)
                         {
                             //двигаемся по оси X
                             while (this.body.X != prev.Body.X + offsetX)
                             {
                                 if (this.body.X < prev.Body.X + offsetX)
                                     this.Move(new Point(this.body.X + 1, this.body.Y));
                                 if (this.body.X > prev.Body.X + offsetX)
                                     this.Move(new Point(this.Body.X - 1, this.Body.Y));
                                 Thread.Sleep(this.speed); //пауза
                             }
                             //двигаемся по оси Y
                             while (this.body.Y != prev.Body.Bottom + MainForm.DXY * 4)
                             {
                                 if (this.body.Y < prev.Body.Bottom + MainForm.DXY * 4)
                                     this.Move(new Point(this.Body.X, this.Body.Y + 1));
                                 if (this.body.Y > prev.Body.Bottom + MainForm.DXY * 4)
                                     this.Move(new Point(this.Body.X, this.Body.Y - 1));
                                 Thread.Sleep(this.speed); //пауза
                             }
                         }
                         this.status = CustomerStatus.staying; //статус - стоит на месте
                     }
                     else if (ind >= 5) //если покупатель не в первой пятерке, очередь двигается друг за другом
                     {
                         //двигаемся в очереди за покупателем, стоящим впереди, пока не дойдем до нужной позиции 
                         while (this.body.X != prev.Body.X + offsetX || prev.Status == CustomerStatus.moving)
                         {
                             //двигаемся по оси X
                             while (this.body.X != prev.Body.X + offsetX)
                             {
                                 if (this.body.X < prev.Body.X + offsetX)
                                     this.Move(new Point(this.body.X + 1, this.body.Y));
                                 if (this.body.X > prev.Body.X + offsetX)
                                     this.Move(new Point(this.Body.X - 1, this.Body.Y));
                                 Thread.Sleep(this.speed); //пауза
                             }
                         }
                         this.status = CustomerStatus.staying; //статус - стоит на месте
                     }
                 }
             });
            thread.Start(); //запускаем поток
        }

        /// <summary>
        /// //Метод движения к выходу из магазина
        /// </summary>
        /// <param name="exit">дверцы выхода из магазина</param>
        public void MoveToExit(Rectangle exit)
        {
            this.status = CustomerStatus.moving;
            //инициализируем новый поток для выполнения движения
            this.thread = new Thread(() =>
            {
                //двигаемся по оси Y к верхней стене магазина
                int offsetY = exit.Bottom + this.body.Height;
                while (this.body.Y != offsetY)
                {
                    this.Move(new Point(this.body.X, this.body.Y - 1));
                    Thread.Sleep(this.speed);
                }
                int offsetX = Randomizer.Rand(this.body.Width, exit.Width / 2) / this.body.Width * this.body.Width; //вычисляем случайное смещение от центра дверей выхода
                if (this.body.Left < exit.X + exit.Width / 2 - offsetX) //если покупатель слева от выхода, двигаемся по оси X к левой двери
                    while (this.body.Left != exit.X + exit.Width / 2 - offsetX)
                    {

                        this.Move(new Point(this.body.X + 1, this.body.Y));
                        Thread.Sleep(this.speed); //пауза
                    }
                if (this.body.Right > exit.X + exit.Width / 2 + offsetX) //если покупатель слева от выхода, двигаемся по оси X к правой двери
                    while (this.body.Right != exit.X + exit.Width / 2 + offsetX)
                    {
                        this.Move(new Point(this.body.X - 1, this.body.Y));
                        Thread.Sleep(this.speed); //пауза
                    }
                //двигаемся по оси Y границу магазина
                while (this.body.Y != exit.Top)
                {
                    if (this.body.Y < exit.Top)
                        this.Move(new Point(this.Body.X, this.Body.Y + 1));
                    if (this.body.Y > exit.Top)
                        this.Move(new Point(this.Body.X, this.Body.Y - 1));
                    Thread.Sleep(this.speed); //пауза
                }
                this.status = CustomerStatus.exited; //статус - вышел из магазина
            });
            thread.Start(); //запускаем поток
        }

        /// <summary>
        /// Метод заполнения корзина с товарами
        /// </summary>
        /// <param name="shelf">Полка с товарами</param>
        public void FillTheCart(ProductShelf shelf)
        {
            PriceSegment segment = new PriceSegment();
            int Try = 1, //номер попытки собрать корзину
                totalCost = 0; //суммарная стоимость покупок
            do //цикл собирания корзины
            {
                totalCost = 0; //начальная стоимость
                for (int i = 0; i < this.shoppingList[ProductType.food]; i++) //набираем еды по списку
                {
                    Product food = null;
                    while (food == null) //выбираем товар из случайной ценовой категории
                    {
                        int seg = Randomizer.Rand(0, 4);
                        if (seg <= 1) segment = PriceSegment.low;
                        if (seg > 1 && seg < 4) segment = PriceSegment.medium;
                        if (seg == 4) segment = PriceSegment.premium;
                        food = shelf.FoodSection.Find(pr => pr.PriceSegment == segment);
                        shelf.FoodSection.Remove(food);
                    }
                    this.shoppingCart.Push(food); //добавляем продукт
                    totalCost += food.Price; //увеличиваем стоимость
                }
                for (int i = 0; i < this.shoppingList[ProductType.goods]; i++) //набираем хозтоваров по списку
                {
                    Product goods = null;
                    while (goods == null) //выбираем товар из случайной ценовой категории
                    {
                        int seg = Randomizer.Rand(0, 4);
                        if (seg <= 1) segment = PriceSegment.low;
                        if (seg > 1 && seg < 4) segment = PriceSegment.medium;
                        if (seg == 4) segment = PriceSegment.premium;
                        goods = shelf.GoodsSection.Find(pr => pr.PriceSegment == segment);
                        shelf.GoodsSection.Remove(goods);
                    }
                    this.ShoppingCart.Push(goods); //долавляем товар
                    totalCost += goods.Price; //увеличиваем стоимость
                }
                if (totalCost > this.money) //если суммарная стоимость покупок больше баланса покупателя
                {
                    while (this.shoppingCart.Count > 0) //обнуляем корзину
                    {
                        Product ret = shoppingCart.Pop();
                        if (ret.Type == ProductType.food)
                            shelf.FoodSection.Add(ret);
                        else
                            shelf.GoodsSection.Add(ret);
                    }
                    if (Try % 5 == 0) //каждую пятую неудачную попытку собрать корзину уменьшаем число еды или хозтоваров в списке на 1
                    {
                        int rand = Randomizer.Rand(1, 2);
                        if (rand == 1 && this.shoppingList[ProductType.food] > 0) this.shoppingList[ProductType.food]--;
                        if (rand == 2 && this.shoppingList[ProductType.goods] > 0) this.shoppingList[ProductType.goods]--;
                    }
                    Try++;
                }
            } while (totalCost > this.money); //повторяем цикл, пока корзина не станет по карману покупателю
        }

        /// <summary>
        /// Метод оплаты товаров
        /// </summary>
        /// <param name="check">Чек со стоимостью покупок</param>
        public void MakePayment(int check)
        {
            this.money -= check;
        }

        /// <summary>
        /// метод преобразования информации о покупателе в строку
        /// </summary>
        /// <returns>Cтрока типа string с информацией</returns>
        public override string ToString()
        {
            string info = String.Format("Покупатель №{0}\nВозраст: {1}\nБаланс кошелька: {2} руб.\nКорзина:\nКоличество пищевых продуктов: {3}\nКоличество хозяйственных товаров: {4}",
            this.Id, this.age, this.money, this.ShoppingList[ProductType.food], this.ShoppingList[ProductType.goods]);
            return info;
        }
    }
}
