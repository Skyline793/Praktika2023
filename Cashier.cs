using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal class Cashier : Person
    {
        private int speed;
        public int Speed
        {
            get { return speed; }
        }
        public Cashier(Point position, Size size, Color color, int Speed): base(position, size, color)
        {
            this.speed = Speed;
        }

        public int ScanProduct(Customer customer)
        {
            customer.Cart.CountOfProducts--;
            return customer.Cart.ShoppingList.Pop();

        }

        public override void Move(Point Dest)
        {
            throw new NotImplementedException();
        }
    }
}
