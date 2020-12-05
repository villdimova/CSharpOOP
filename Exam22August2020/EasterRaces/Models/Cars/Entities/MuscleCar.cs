using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car
    {
        private const int DefaultMinHorsePower = 400;
        private const int DefaultMaxHorsePower = 600;
        private const double DefaultCubicCentimeters = 5000;

        private int horsePower;


        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, DefaultCubicCentimeters, DefaultMinHorsePower, DefaultMaxHorsePower)
        {

        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }

            protected set
            {
                if (value < DefaultMinHorsePower || value > DefaultMaxHorsePower)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public override double CubicCentimeters => DefaultCubicCentimeters;


    }
}
