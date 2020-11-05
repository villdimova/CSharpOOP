
using System.Collections.Generic;

namespace MilitaryElite
{
  public  interface ILieutenantGeneral:IPrivate
    {
        public Dictionary<int,IPrivate> Privates { get;}
    }
}
