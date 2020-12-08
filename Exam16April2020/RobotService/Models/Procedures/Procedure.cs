using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected  List<IRobot> robots;

        public Procedure()
        {
            this.robots = new List<IRobot>();
        }

        public List<IRobot> Robots => this.robots;

        public abstract void DoService(IRobot robot, int procedureTime);
       
        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            foreach (var robot in this.Robots)
            {
                sb.AppendLine($" Robot type: {robot.GetType().Name} - {robot.Name} - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }

           return sb.ToString().TrimEnd();
        }
    }
}
