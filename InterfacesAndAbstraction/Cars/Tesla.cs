using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public string Model { get; }
        public string Color { get; }
        public int Batteries { get; }

        public Tesla(string model, string color, int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Batteries = batteries;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Batteries} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().TrimEnd();
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
