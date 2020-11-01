using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
   public class Person
    {
        //name-no empty
        //money-no negative
        //bagOfProducts

        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.bagOfProducts = new List<Product>();
            this.Name = name;
            this.Money = money;

        }

        public string Name {
            get
            {
                return this.name;
            } 
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyList<Product> BagOfProducts
        {
            get
            {
                return this.bagOfProducts.AsReadOnly();
            }
            
        }

        public bool AddProduct(Product product)
        {
            if (this.Money<product.Price)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
                return false;
            }

            else
            {
                this.Money -= product.Price;
                this.bagOfProducts.Add(product);
                return true;
            }
        }

    }
}
