namespace _02.VehiclesExtensions
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]),double.Parse(carInfo[3]));

            var truckInfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]),double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                var commands = Console.ReadLine().Split();
                if (commands[0] == "Drive"|| commands[0]== "DriveEmpty")
                {
                    if (commands[1] == "Car")
                    {
                        car.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[1]=="Bus")
                    {
                        bus.BusStatus = commands[0];
                        bus.Drive(double.Parse(commands[2]));
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
                    else if (commands[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(commands[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2):f2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2):f2}");
            Console.WriteLine($"Bus: {Math.Round(bus.FuelQuantity, 2):f2}");
        }
    }
}
