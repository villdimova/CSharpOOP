using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private const int minimumNameLength = 5;
        private string name;
        private bool canParticipate;

        public Driver(string name)
        {
            this.Name = name;
            this.canParticipate = false;

        }



        public string Name
        {
            get
            { 
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length < minimumNameLength)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, this.Name, minimumNameLength));
                }

                this.name = value;
            }
        }
        public ICar Car { get; private set; }
       
        public int NumberOfWins { get; private set; }
        
        public bool CanParticipate
        {
            get
            {
                return this.canParticipate;
            }
            set
            {
                if (this.Car != null)
                {
                    this.canParticipate = true;
                }
                else
                {
                    this.canParticipate = false;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }
            this.Car = car;
            this.CanParticipate = true;

        }
        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}