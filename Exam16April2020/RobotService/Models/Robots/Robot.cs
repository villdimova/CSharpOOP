using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private const int happinesMinValue = 0;
        private const int happinesMaxValue = 100;
        private const int energyMinValue = 0;
        private const int energyMaxValue = 100;

        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isBought;
        private bool isChipped;
        private bool isChecked;

        protected Robot(string name, int happiness, int energy, int procedureTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;
            this.Owner = "Service";
            this.isBought = false;
            this.isChecked = false;
            this.IsChipped = false;

        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }
        public int Happiness
        {
            get { return this.happiness; }
             set
            {
                if (value<happinesMinValue||value>happinesMaxValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                this.happiness = value;
            }
        }
        public int Energy
        {
            get { return this.energy; }
            set
            {
                if (value < energyMinValue || value > energyMaxValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                this.energy = value;
            }
        }
        public int ProcedureTime
        {
            get { return this.procedureTime; }
            set
            {
                this.procedureTime = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set
            {
                this.owner = value;
            }
        }
        public bool IsBought
        {
            get { return this.isBought; }
            set
            {
                this.isBought = value;
            }
        }
        public bool IsChipped
        {
            get { return this.isChipped; }
            set
            {
                this.isChipped = value;
            }
        }
        public bool IsChecked
        {
            get { return this.isChecked; }
            set
            {
                this.isChecked = value;
            }
        }

        public override string ToString()
        {
            return $"Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
