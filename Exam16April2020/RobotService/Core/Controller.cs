using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;

        private Chip chip;
        private Charge charge;
        private Polish polish;
        private Rest rest;
        private TechCheck techCheck;
        private Work work;


        public Controller()
        {
            this.garage = new Garage();
            this.chip = new Chip();
            this.charge = new Charge();
            this.polish =new  Polish();
            this.rest = new Rest();
            this.techCheck = new TechCheck();
            this.work = new Work();
        }

        public string Charge(string robotName, int procedureTime)
        {
            IsRobotExisting(robotName);
            IRobot robot = garage.Robots[robotName];
            charge.DoService(robot, procedureTime);
            charge.Robots.Add(robot);
            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IsRobotExisting(robotName);
            IRobot robot = garage.Robots[robotName];
            chip.DoService(robot, procedureTime);
            chip.Robots.Add(robot);

            return String.Format(OutputMessages.ChipProcedure, robotName);

        }

        public string History(string procedureType)
        {
            string history = null;

            if (procedureType == nameof(Chip))
            {
                history = chip.History();
            }
            else if (procedureType == nameof(Charge))
            {
                history = charge.History();
            }

            else if (procedureType == nameof(Polish))
            {
                history = polish.History();
            }
            else if (procedureType == nameof(Rest))
            {
                history = rest.History();
            }
            else if (procedureType == nameof(TechCheck))
            {
                history = techCheck.History();
            }
            else if (procedureType == nameof(Work))
            {
                history = work.History();
            }
            return history;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, happiness, energy, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            garage.Manufacture(robot);
            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IsRobotExisting(robotName);
            IRobot robot = garage.Robots[robotName];
            polish.DoService(robot, procedureTime);
            polish.Robots.Add(robot);
            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IsRobotExisting(robotName);

            IRobot robot = garage.Robots[robotName];
            rest.DoService(robot, procedureTime);
            rest.Robots.Add(robot);
            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IsRobotExisting(robotName);
            IRobot robot = garage.Robots[robotName];
            garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }


        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IsRobotExisting(robotName);

            IRobot robot = garage.Robots[robotName];
            techCheck.DoService(robot, procedureTime);
            techCheck.Robots.Add(robot);
            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            IsRobotExisting(robotName);

            IRobot robot = garage.Robots[robotName];
            work.DoService(robot, procedureTime);
            work.Robots.Add(robot);
            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public void IsRobotExisting(string robotName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
