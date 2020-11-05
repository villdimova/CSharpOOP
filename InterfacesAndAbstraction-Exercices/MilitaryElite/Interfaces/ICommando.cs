using System.Collections;
using System.Collections.Generic;

namespace MilitaryElite
{
   public interface ICommando: ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; }

    }
}
