namespace _02.VehiclesExtensions
{
    using System;

    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double kilometers)
        {
            double consumedFuel = (this.FuelConsumption + 0.9) * kilometers;
            if (consumedFuel <= FuelQuantity)
            {
                this.FuelQuantity -= consumedFuel;
                Console.WriteLine($"Car travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        
    }
}
