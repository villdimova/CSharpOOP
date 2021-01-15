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

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

        }

        public IReadOnlyList<IBakedFood> FoodOrders => this.foodOrders;
        public IReadOnlyList<IDrink> DrinkOrders => this.drinkOrders;
        public int TableNumber
        {
            get
            {
                return this.tableNumber;
            }
            private set
            {
                this.tableNumber = value;
            }
        }
        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
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
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson
        {
            get
            {
                return this.pricePerPerson;
            }
            private set
            {
                this.pricePerPerson = value;
            }
        }
        public bool IsReserved
        {
            get 
            { 
                return this.isReserved;
            }
            private set
            {
                this.isReserved = value;
            }
        }
        public decimal Price => this.PricePerPerson * NumberOfPeople;

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            Capacity += NumberOfPeople;
            IsReserved = false;
           // NumberOfPeople = 0;

        }
        public decimal GetBill()
        {
            decimal totalBill = this.DrinkOrders.Sum(d => d.Price) + this.FoodOrders.Sum(f => f.Price)+this.Price;
            return totalBill;
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
            if (IsReserved == true)
            {
                this.drinkOrders.Add(drink);
            }
        }
        public void OrderFood(IBakedFood food)
        {
            if (IsReserved == true)
            {
                this.foodOrders.Add(food);
            }
        }
        public void Reserve(int numberOfPeople)
        {
            
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
            this.Capacity -= NumberOfPeople;
        }
    }
}
