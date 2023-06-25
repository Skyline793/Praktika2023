using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika2023
{
    enum ProductType
    {
        food,
        goods
    }
    enum PriceSegment
    {
        premium,
        medium,
        low
    }
    internal class Product
    {
        private int price;
        public int Price
        {
            get { return price; }
        }
        private ProductType type;
        public ProductType Type
        {
            get { return type; }
        }
        private PriceSegment priceSegment;
        public PriceSegment PriceSegment
        {
            get { return priceSegment; }
        }
        public Product(ProductType type, PriceSegment priceSegment)
        {
            this.type = type;
            this.priceSegment = priceSegment;
            Random rand = new Random();

            switch (this.priceSegment)
            {
                case PriceSegment.premium:
                    this.price = Randomizer.Rand(1000, 1500);
                    break;
                case PriceSegment.medium:
                    this.price = Randomizer.Rand(500, 1000);
                    break;
                case PriceSegment.low:
                    this.price = Randomizer.Rand(10, 500);
                    break;
            }

        }
    }
}

