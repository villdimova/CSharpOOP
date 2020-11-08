using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        
        public override void Drive(double kilometers)
        {
            double consumedFuel = (this.FuelConsumption + 0.9) * kilometers;
            if (consumedFuel<=FuelQuantity)
            {
                this.FuelQuantity -= consumedFuel;
                Console.WriteLine($"Car travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }


    }
}
