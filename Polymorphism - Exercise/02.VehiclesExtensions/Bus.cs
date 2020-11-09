namespace _02.VehiclesExtensions
{
    using System;

    public class Bus : Vehicle
    {

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
           
        }

        public string BusStatus { get; set; }
        public override void Drive(double kilometers)
        {
            double consumedFuel = this.FuelConsumption *kilometers;
            if (BusStatus== "Drive")
            {
               consumedFuel = (this.FuelConsumption + 1.4) * kilometers;
            }
          
            if (consumedFuel <= FuelQuantity)
            {
                this.FuelQuantity -= consumedFuel;
                Console.WriteLine($"Bus travelled {kilometers} km");
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
    }
}
