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
            if(this.type==ProductType.food)
            switch (this.priceSegment)
            {
                case PriceSegment.premium:
                        this.price = 449;
                    break;
                case PriceSegment.medium:
                        this.price = 249;
                    break;
                case PriceSegment.low:
                        this.price = 49;
                    break;
            }
            if (this.type == ProductType.goods)
                switch (this.priceSegment)
                {
                    case PriceSegment.premium:
                        this.price = 599;
                        break;
                    case PriceSegment.medium:
                        this.price = 399;
                        break;
                    case PriceSegment.low:
                        this.price = 99;
                        break;
                }

        }
    }
}

