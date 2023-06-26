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
        private int scanSpeed;
        public int ScanSpeed
        {
            get { return scanSpeed; }
        }
        public Cashier(Point position, Size size, Color color, int scanSpeed, int ID): base(position, size, color, ID)
        {
            this.scanSpeed = scanSpeed;
        }

        public int ScanProduct(Customer customer)
        {
            return customer.Cart.ShoppingList.Pop();

        }

        public override void Move(Point Dest)
        {
            throw new NotImplementedException();
        }
    }
}
