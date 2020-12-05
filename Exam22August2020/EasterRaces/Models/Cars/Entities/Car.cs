using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private const int minimumModelLength = 4;

        private string model;
        private int horsePower;
        private double cubicCentimeters;


        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;

        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (value.Length < minimumModelLength || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, this.Model, minimumModelLength));
                }
                this.model = value;
            }
        }
        public int MinHorsePower { get; }
        public int MaxHorsePower { get; }
        public virtual int HorsePower
        {
            get { return this.horsePower; }
            protected set
            {
                this.HorsePower = value;
            }
        }
        public virtual double CubicCentimeters
        {
            get { return this.cubicCentimeters; }

            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            double CalculateRacePoints = this.CubicCentimeters / this.HorsePower * laps;
            return CalculateRacePoints;
        }

    }
}
