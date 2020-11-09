using System;

namespace _02.VehiclesExtensions
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
             : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }


        public override void Drive(double kilometers)
        {
            double consumedFuel = (this.FuelConsumption + 1.6) * kilometers;
            if (consumedFuel <= FuelQuantity)
            {
                this.FuelQuantity -= consumedFuel;
                Console.WriteLine($"Truck travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                if (FuelQuantity > this.TankCapacity)
                {
                    this.FuelQuantity = 0;
                }
                else
                {
                    if (this.FuelQuantity + liters > this.TankCapacity)
                    {
                        Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                    }
                    else
                    {
                        this.FuelQuantity += 0.95 * (liters);
                    }
                }
            }
            
        }
    }
}
