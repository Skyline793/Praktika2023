using System.Drawing;

namespace Praktika2023
{
    /// <summary>
    /// абстрактый класс Человек
    /// </summary>
    internal abstract class Person
    {
        ///<summary>Идентификатор человека </summary>
        protected int Id;
        /// <summary>Возраст человека</summary>
        protected int age;
        /// <summary>Возраст человека</summary>
        public int Age
        {
            get { return age; } //геттер
        }
        /// <summary>Прямоугольник-тело, определяющий позицию и размер человека</summary>
        protected Rectangle body;
        /// <summary>Прямоугольник-тело, определяющий позицию и размер человека</summary>
        public Rectangle Body
        {
            get { return body; } //геттер
        }
        /// <summary>Цвет фигуры человека</summary>
        protected Color color;
        /// <summary>Цвет фигуры человека</summary>
        public Color Color
        {
            get { return color; } //геттер
        }

        /// <summary>
        /// Конструктор класса Человек
        /// </summary>
        /// <param name="position">Координата левого верхнего угла тела</param>
        /// <param name="size">Размеры тела</param>
        /// <param name="color">Цвет тела</param>
        /// <param name="ID">Индетификатор</param>
        public Person(Point position, Size size, Color color, int ID)
        {
            this.color = color;
            this.body = new Rectangle(position.X, position.Y, size.Width, size.Height);
            this.Id = ID;
        }

        /// <summary>
        /// Метод перемещения позиции человека
        /// </summary>
        /// <param name="Dest">Точка назначения</param>
        protected void Move(Point Dest)
        {
            this.body.X = Dest.X;
            this.body.Y = Dest.Y;
        }
    }
}
