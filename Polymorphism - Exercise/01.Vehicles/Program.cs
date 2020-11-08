using System;
using System.Collections.Generic;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            var truckInfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                var commands = Console.ReadLine().Split();
                if (commands[0]=="Drive")
                {
                    if (commands[1]=="Car")
                    {
                        car.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Drive(double.Parse(commands[2]));
                    }
                }
                else if (commands[0] == "Refuel")
                {
                    if (commands[1] == "Car")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity,2):f2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2):f2}");
        }
    }
}
