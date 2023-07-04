namespace Praktika2023
{
    /// <summary>Перечисление для типа товара</summary>
    enum ProductType
    {
        /// <summary>Еда</summary>
        food,
        /// <summary>Хозяйственный товар</summary>
        goods
    }

    /// <summary>Перечисления для ценового сегмента товара</summary>
    enum PriceSegment
    {
        /// <summary>Премиальный сегмент</summary>
        premium,
        /// <summary>Средний бюджетный сегмент</summary>
        medium,
        /// <summary>Дешевый низший сегмент </summary>
        low
    }

    /// <summary>Класс Товар</summary>
    internal class Product
    {
        /// <summary>Цена товара</summary>
        private int price;
        /// <summary>Цена товара</summary>
        public int Price
        {
            get { return price; }
        }
        /// <summary>Тип товара</summary>
        private ProductType type;
        /// <summary>Тип товара</summary>
        public ProductType Type
        {
            get { return type; } //геттер
        }
        /// <summary>Ценовой сегмент товара</summary>
        private PriceSegment priceSegment;
        /// <summary>Ценовой сегмент товара</summary>
        public PriceSegment PriceSegment
        {
            get { return priceSegment; }
        }

        /// <summary>
        /// Конструктор класса Товар
        /// </summary>
        /// <param name="type">Тип товара</param>
        /// <param name="priceSegment">Ценовой сегмент товара</param>
        public Product(ProductType type, PriceSegment priceSegment)
        {
            this.type = type;
            this.priceSegment = priceSegment;
            //устанавливаем цену в зависимости от типа и сегмента
            if (this.type == ProductType.food)
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

