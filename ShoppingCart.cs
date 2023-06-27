using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    internal class ShoppingCart
    {
        private Stack<Product> shoppingList;
        public Stack<Product> ShoppingList
        {
            get { return shoppingList; }
        }
        private int countOfProducts;
        public int CountOfProducts
        {
            get
            {
                this.countOfProducts = countOfFood + countOfGoods;
                return countOfProducts;
            }
        }
        private int countOfFood;
        public int CountOfFood
        {
            get { return countOfFood; }
        }
        private int countOfGoods;    
        public int CountOfGoods
        {
            get { return countOfGoods; }
        }
        private int totalCost;
        public int TotalCost
        {
            get { return totalCost; }
        }
        public ShoppingCart()
        {
            this.shoppingList = new Stack<Product>();
            this.countOfFood = 0;
            this.countOfGoods = 0;
            this.totalCost = 0;
            this.countOfProducts = 0;
        }
        public void FillTheCart(int maxTotalCost, ProductShelf shelf)
        {
            do
            {
                this.countOfFood = Randomizer.Rand(0, maxTotalCost%10+5);
                this.countOfGoods = Randomizer.Rand(0, maxTotalCost%10+5);
            } while (this.CountOfProducts <=0);
            PriceSegment segment = new PriceSegment();
            int Try= 1;
            do
            {
                this.totalCost = 0;
                for(int i = 0; i < this.countOfFood; i++)
                {
                    Product food = null;
                    while (food == null)
                    {
                        int seg = Randomizer.Rand(0, 2);
                        if (seg == 0) segment = PriceSegment.low;
                        if (seg == 1) segment = PriceSegment.medium;
                        if (seg == 2) segment = PriceSegment.premium;
                        food = shelf.FoodShelf.Find(pr => pr.PriceSegment == segment);
                        shelf.FoodShelf.Remove(food);
                    }
                    shoppingList.Push(food);
                    this.totalCost += food.Price;   
                }
                for (int i = 0; i < this.countOfGoods; i++)
                {
                    Product goods = null;
                    while (goods == null)
                    {
                        int seg = Randomizer.Rand(0, 2);
                        if (seg == 0) segment = PriceSegment.low;
                        if (seg == 1) segment = PriceSegment.medium;
                        if (seg == 2) segment = PriceSegment.premium;
                        goods = shelf.GoodsShelf.Find(pr => pr.PriceSegment == segment);
                        shelf.GoodsShelf.Remove(goods);
                    }
                    shoppingList.Push(goods);
                    this.totalCost += goods.Price;
                }
                if (totalCost > maxTotalCost)
                {
                    while (shoppingList.Count > 0)
                    {
                        Product ret = shoppingList.Pop();
                        if (ret.Type == ProductType.food)
                            shelf.FoodShelf.Add(ret);
                        else
                            shelf.GoodsShelf.Add(ret);
                    }
                    if (Try % 5 == 0)
                    {
                        int rand = Randomizer.Rand(1, 2);
                        if (rand == 1 && this.countOfFood > 0) this.countOfFood--;
                        if (rand == 2 && this.countOfGoods > 0) this.countOfGoods--;
                    }
                    Try++;
                }
            } while (this.totalCost > maxTotalCost);
        }

        public override string ToString()
        {
            string info = String.Format("Корзина:\nКоличество съедобных товаров: {0}\nКоличество несъедобных товаров в корзине: {1}",
                Convert.ToString(this.countOfFood), Convert.ToString(this.countOfGoods));
            return info;
        }
    }
}
