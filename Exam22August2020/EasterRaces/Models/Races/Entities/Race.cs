using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private const int minimumNameLength = 5;
        private const int minimumLapsValue = 1;

        private readonly List<IDriver> drivers;
        private string name;
        private int laps;

        public Race(string name,int laps)
        {
            this.drivers = new List<IDriver>();
            this.Name = name;
            this.Laps = laps;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length < minimumNameLength )
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, minimumNameLength));
                }

                this.name = value;
            }
        }
        public int Laps
        {
            get { return laps; }
            private set
            {
                if (value<minimumLapsValue)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, minimumLapsValue));
                }
                laps = value;
            }
        }
        public IReadOnlyCollection<IDriver> Drivers => drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver ==null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.CanParticipate==false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}
