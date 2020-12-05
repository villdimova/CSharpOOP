using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        private readonly List<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
    }
}
