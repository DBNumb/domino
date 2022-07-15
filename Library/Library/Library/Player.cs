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
        public abstract List<Token>PlayerHand { get; set; }
        public abstract Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos);
        public List<Token> PosiblesJugadas(List<Token> playerHand, Token extremos) 
        {
            List<Token> result = new List<Token>();
            foreach (var t in playerHand)
            {
                if (t.FaceA.Compare(extremos.FaceA) == 0 || t.FaceB.Compare(extremos.FaceA) == 0 ||
                    t.FaceA.Compare(extremos.FaceB) == 0 || t.FaceB.Compare(extremos.FaceB) == 0)
                {
                    result.Add(t);
                }
            }

            if (result.Count == 0) return null;
            return result;
        }
    }

    
}
