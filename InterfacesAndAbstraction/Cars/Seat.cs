using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat:ICar
    {
        public string Model { get; }
        public string Color { get; }

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Seat {this.Model} ");
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
