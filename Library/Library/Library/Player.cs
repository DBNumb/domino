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
        public abstract Tuple<IToken, int> Juega(List<IToken> posiblesjugadas, Token extremos, Comparer<Token> comp);

    }
    
}
