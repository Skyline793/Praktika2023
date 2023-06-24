using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal class CustomersQueue
    {
        public static int maxCustomers = 10;
        private Queue<Customer> customers;
        public Queue<Customer> Customers
        {
            get { return customers; }
        }
        public CustomersQueue()
        {
            customers = new Queue<Customer>();
        }
        public void Add(Customer customer)
        {
            if (customers.Count < maxCustomers)
                customers.Enqueue(customer);
            else throw new Exception("Превышено число покупателей в очереди");
               
        }

    }
}
