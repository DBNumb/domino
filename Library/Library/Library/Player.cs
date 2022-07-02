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
        public abstract List<Token>PlayerHand { get; }
        public abstract Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos, IComparer<Token> comp);

    }
    
}
