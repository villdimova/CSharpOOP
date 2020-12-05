using EasterRaces.Core.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Text;
using System.Linq;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Races;
using EasterRaces.Models.Drivers;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private const int minDriversCount = 3;

        private readonly DriverRepository drivers;
        private readonly CarRepository cars;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            var car = this.cars.GetAll().FirstOrDefault(c => c.Model == carModel);

            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {

            if (this.cars.GetAll().Any(c => c.Model == model))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }


            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.cars.Add(car);

            return String.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {


            if (this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }
            Driver driver = new Driver(driverName);
            this.drivers.Add(driver);
            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {

            if (this.races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            Race race = new Race(name, laps);
            this.races.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, minDriversCount));
            }
            var drivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format(OutputMessages.DriverFirstPosition, drivers[0].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.DriverSecondPosition, drivers[1].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.DriverThirdPosition, drivers[2].Name, raceName));


            return sb.ToString().TrimEnd();

        }
    }
}
