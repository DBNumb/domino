using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    
    public abstract class Player
    {  public abstract int PlayerScore { get; protected set; }
        //clase abstracta jugador
        public abstract IToken<T> Juega<T>(List<IToken<T>> posiblesjugadas, int extremo1, int extremo2) where T : IComparable, IValuable;

    }
    
}
