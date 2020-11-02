using System;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaInput = Console.ReadLine().Split().ToArray();
                var doughInput = Console.ReadLine().Split().ToArray();
                var dough = new Dough(doughInput[1],
                                     doughInput[2],
                                     double.Parse(doughInput[3]));
                var pizza = new Pizza(pizzaInput[1], dough);

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    else
                    {
                        var toppingInput = input.Split().ToArray();
                        var topping = new Topping(toppingInput[1], double.Parse(toppingInput[2]));
                        pizza.AddToppings(topping);
                    }
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
