using System;
using System.Threading;
using System.Drawing;

namespace Praktika2023
{
    /// <summary>Перечисление для отражения статуса менеджера</summary>
    enum ManagerStatus
    {
        /// <summary>свободен</summary>
        available,
        /// <summary>занят</summary>
        busy
    }

    /// <summary>класс Менеджер, наследуемый от Человека</summary>
    internal class Manager : Person
    {
        /// <summary>Статус менеджера</summary>
        private ManagerStatus status;
        /// <summary>Статус менеджера</summary>
        public ManagerStatus Status
        {
            get { return status; } //геттер
        }
        /// <summary>Количество пищевых продуктов, которым менеджер пополняет полку продуктов</summary>
        private int foodSupply;
        /// <summary>Количество хозяйственных товаров, которым менеджер пополняет полку продуктов</summary>
        private int goodsSupply;
        /// <summary>Поток, в котором передвигается и пополняет запасы менеджер</summary>
        private Thread thread;
        /// <summary>Поток, в котором передвигается и пополняет запасы менеджер</summary>
        public Thread Thread
        {
            get { return thread; } //геттер
        }

        /// <summary>
        /// Конструктор класса Менеджер
        /// </summary>
        /// <param name="position">Координата левого верхнего угла тела</param>
        /// <param name="size">Размеры тела</param>
        /// <param name="color">Цвет тела</param>
        public Manager(Point position, Size size, Color color, int ID) : base(position, size, color, ID) //конструктор
        {
            this.status = ManagerStatus.available; //начальный статус - свободен
            //пополнение по нулям
            this.foodSupply = 0;
            this.goodsSupply = 0;
        }

        /// <summary>
        /// метод приближения к полке и пополнения запасов
        /// </summary>
        /// <param name="shelf">пополняемая полка</param>
        /// <param name="foodSupply">количество пополняемых пищевых продуктов</param>
        /// <param name="goodsSupply">количество пополняемых хозяйственных товаров</param>
        public void TopUpTheShelf(ProductShelf shelf, int foodSupply, int goodsSupply)
        {
            this.foodSupply = foodSupply;
            this.goodsSupply = goodsSupply;
            this.status = ManagerStatus.busy;
            //инициализируем поток выполнения метода
            thread = new Thread(() =>
            {
                Point source = new Point(this.body.X, this.body.Y); //исходная позиция
                Point dest = new Point(shelf.Form.Left, shelf.Form.Bottom + MainForm.DXY * 2); //точка назначения
                //двигаемся по оси Y, пока не дойдем до нижнего края полки
                while (this.body.Y != dest.Y)
                {
                    if (this.body.Y < dest.Y)
                        this.Move(new Point(this.body.X, this.body.Y + 1));
                    if (this.body.Y > dest.Y)
                        this.Move(new Point(this.body.X, this.body.Y - 1));
                    Thread.Sleep(10); //пауза
                }
                //двигаемся по оси X, пока не дойдем до нижнего края полки
                while (this.body.X != dest.X)
                {
                    if (this.body.X < dest.X)
                        this.Move(new Point(this.body.X + 1, this.body.Y));
                    if (this.body.X > dest.X)
                        this.Move(new Point(this.body.X - 1, this.body.Y));
                    Thread.Sleep(10); //пауза
                }

                TopUp(shelf); //вызов метода пополнения полки
                Thread.Sleep(10000); //пауза

                //двигаемся по оси X, пока не дойдем до позиции, откуда пришли
                while (this.body.X != source.X)
                {
                    if (this.body.X < source.X)
                        this.Move(new Point(this.body.X + 1, this.body.Y));
                    if (this.body.X > source.X)
                        this.Move(new Point(this.body.X - 1, this.body.Y));
                    Thread.Sleep(10); //пауза
                }
                //двигаемся по оси X, пока не дойдем до позиции, откуда пришли
                while (this.body.Y != source.Y)
                {
                    if (this.body.Y < source.Y)
                        this.Move(new Point(this.body.X, this.body.Y + 1));
                    if (this.body.Y > source.Y)
                        this.Move(new Point(this.body.X, this.body.Y - 1));
                    Thread.Sleep(10); //пауза
                }
                this.status = ManagerStatus.available;
            });
            thread.Start(); //запускаем поток
        }

        /// <summary>
        /// Непосредственно метод пополнения запасов
        /// </summary>
        /// <param name="shelf">пополняемая полка</param>
        private void TopUp(ProductShelf shelf)
        {
            //пополняем секцию с едой
            for (int i = 0; i < foodSupply / 2; i++)
            {
                shelf.FoodSection.Add(new Product(ProductType.food, PriceSegment.low));
            }
            for (int i = 0; i < foodSupply / 3; i++)
            {
                shelf.FoodSection.Add(new Product(ProductType.food, PriceSegment.medium));
            }
            while (shelf.FoodSection.Count < foodSupply)
            {
                shelf.FoodSection.Add(new Product(ProductType.food, PriceSegment.premium));
            }

            //пополняем секцию с хозтоварами
            for (int i = 0; i < goodsSupply / 2; i++)
            {
                shelf.GoodsSection.Add(new Product(ProductType.goods, PriceSegment.low));
            }
            for (int i = 0; i < goodsSupply / 3; i++)
            {
                shelf.GoodsSection.Add(new Product(ProductType.goods, PriceSegment.medium));
            }
            while (shelf.GoodsSection.Count < goodsSupply)
            {
                shelf.GoodsSection.Add(new Product(ProductType.goods, PriceSegment.premium));
            }
        }

        /// <summary>
        /// Метод преобразования информации о менеджере в строку
        /// </summary>
        /// <returns>Cтрока типа string с информацией</returns>
        public override string ToString()
        {
            string info = String.Format("Менеджер\nПополнение пищевых продуктов: {0} шт.\nПополнение хозяйственных товаров: {1} шт.", this.foodSupply, this.goodsSupply);
            return info;
        }
    }
}
