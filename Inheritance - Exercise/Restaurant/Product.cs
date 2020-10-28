﻿
namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}
