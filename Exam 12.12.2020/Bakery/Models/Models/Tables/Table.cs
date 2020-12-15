using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();       
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
        }

       

        public int TableNumber
        {
            get { return this.tableNumber; }
            private set
            {
                this.tableNumber = value;
            }
        }
        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson
        {
            get { return pricePerPerson; }
            private set
            {
                pricePerPerson = value;
            }
        }
        public bool IsReserved
        {
            get { return isReserved; }
            private set
            {
                if (this.NumberOfPeople>0)
                {
                    isReserved= true;
                }
                else
                {
                    isReserved = false;
                }
            }
        }
        public decimal Price => this.PricePerPerson * this.NumberOfPeople;
        

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.NumberOfPeople = 0;
            
        }
        public decimal GetBill()
        {
            decimal billTotal=this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(d => d.Price)+this.Price;
            return billTotal;
        }
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            
                sb.AppendLine($"Table: {this.TableNumber}");
                sb.AppendLine($"Type: {this.GetType().Name}");
                sb.AppendLine($"Capacity: {this.Capacity}");
                sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();

        }
        public void OrderDrink(IDrink drink)
        {
           
                this.drinkOrders.Add(drink);
          
         
        }
        public void OrderFood(IBakedFood food)
        {
            
                this.foodOrders.Add(food);
            
        }
        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople<=0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
            }
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
