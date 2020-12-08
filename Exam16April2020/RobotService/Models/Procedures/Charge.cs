using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
   public class Charge:Procedure
    {
        private const int AddedHappinessValue = 12;
        private const int AddedEnergyValue = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
            robot.Happiness += AddedHappinessValue;
            robot.Energy += AddedEnergyValue;
        }
    }
}
