using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {

        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion,brand);
            }
            else if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);
            string message = String.Format(OutputMessages.DrinkAdded, name, brand);
            return message;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food=null;
            if (type==nameof(Bread))
            {
                food = new Bread(name, price);
            }
            else if (type==nameof(Cake))
            {
                food = new Cake(name, price);
            }

            this.bakedFoods.Add(food);
            string message = String.Format(OutputMessages.FoodAdded, name, food.GetType().Name);
            return message;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber,capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            string message = String.Format(OutputMessages.TableAdded,tableNumber);
            return message;
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables)
            {
                
                if (table.IsReserved==false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }

            }

            return sb.ToString().TrimEnd();

        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal tableBill = table.GetBill();
            this.totalIncome += tableBill;
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {tableBill:f2}");
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName&&d.Brand==drinkBrand);
            string message = null;

            if (table == null)
            {
                message = $"Could not find table {tableNumber}";
            }

            if (drink == null)
            {
                message = $"There is no {drinkName} {drinkBrand} available";
            }

            else
            {
                table.OrderDrink(drink);
                message = $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
            }

            return message;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber==tableNumber);
            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);
            string message = null;

            if (table==null)
            {
                message = $"Could not find table {tableNumber}";
            }

            if (food==null)
            {
                message = $"No {foodName} in the menu";
            }

            else
            {
                table.OrderFood(food);
                message = $"Table {tableNumber} ordered {foodName}";
            }

            return message;
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            string message = null;
            if (table==null)
            {
                message= String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);

            }
            else
            {
                table.Reserve(numberOfPeople);
                message = String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }

            return message;
        }
    }
}
