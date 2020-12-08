using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Rest:Procedure
    {
        private const int RemovedHappinessValue = 3;
        private const int AddedEnergyValue = 10;

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= RemovedHappinessValue;
            robot.Energy += AddedEnergyValue;
        }
    }
}
