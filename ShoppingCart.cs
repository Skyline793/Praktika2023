using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal class ShoppingCart
    {
        private Stack<int> shoppingList;
        public Stack<int> ShoppingList
        {
            get { return shoppingList; }
        }
        private int countOfProducts;
        public int CountOfProducts
        {
            get { return countOfProducts; }
            set { countOfProducts = value; }
        }
        
        private int totalCost;
        public int TotalCost
        {
            get { return totalCost; }
        }
        public ShoppingCart(int maxTotalCost, int minCount, int maxCount, int minCost, int maxCost)
        {
            shoppingList = new Stack<int>();
            
            Random random = new Random();
            this.countOfProducts = random.Next(maxCount - minCost) + minCount;
            do
            {
                totalCost = 0;
                for (int i = 0; i < countOfProducts; i++)
                {
                    shoppingList.Push(random.Next(maxCost - minCost) + minCost);
                    totalCost += shoppingList.Peek();
                }
                if (totalCost > maxTotalCost) shoppingList.Clear();
            } while (totalCost >= maxTotalCost);

        }
    }
}
