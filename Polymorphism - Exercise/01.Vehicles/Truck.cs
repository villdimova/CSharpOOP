using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
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
            this.FuelQuantity += 0.95*(liters);
        }
    }
}
