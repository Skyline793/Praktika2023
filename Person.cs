using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal abstract class Person //абстрактый класс человек
    {
        protected int Id; //идентификатор
        protected int age; //возраст
        public int Age
        {
            get { return age; }
        }
        protected Rectangle body;
            public Rectangle Body
        {
            get { return body; }    
        }
        protected Color color;
        public Color Color
        {
            get { return color; }
        }
        public Person(Point position, Size size, Color color, int ID)
        {
            this.color = color;
            this.body = new Rectangle(position.X, position.Y, size.Width, size.Height);
            this.Id = ID;
        }
        abstract protected void Move(Point Dest);

    }
}
