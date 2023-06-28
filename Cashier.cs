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
            this.age = Randomizer.Rand(18, 60);
        }

        public int ScanProduct(Customer customer)
        {
            return customer.ShoppingCart.Pop().Price;

        }

        protected override void Move(Point Dest)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string info = String.Format("Кассир №{0}\nВозраст: {1}\nСкорость сканирования: {2} секунд(-ы) на товар",
                Convert.ToString(this.Id), Convert.ToString(this.age), Convert.ToString(this.scanSpeed/1000.0));
            return info;
        }
    }
}
