using System.Collections;
using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer:ISpecialisedSoldier
    {
        public ICollection<IRepair> Repairs { get;}
    }
}
