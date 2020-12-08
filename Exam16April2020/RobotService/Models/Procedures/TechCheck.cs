using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
   
    public class TechCheck:Procedure
    {
        private const int RemovedEnergyValue = 8;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
            robot.Energy -= RemovedEnergyValue;
            if (robot.IsChecked)
            {
                robot.Energy -= RemovedEnergyValue;
            }
            else
            {
                robot.IsChecked = true;
            }
        }
    }
}
