using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    
    public class Player
    {
        private IStrategy strategy;
        public int PlayerScore { get; protected set; }
        public List<Token> PlayerHand { get; set; }
        
        public Player(IStrategy strategy) 
        {
            this.strategy = strategy;
        }

       
        public Tuple<Token, IComparable> Juega( Board board)
        {
            var posiblesjugadas = PosiblesJugadas(PlayerHand, board.Boardextremes());
            if (posiblesjugadas == null) return null;
            //si no hay posibles jugadas no puede jugar

            
            
            Token jugada = strategy.Strategy(posiblesjugadas, board);
            
            PlayerScore += jugada.Score;
            PlayerHand.Remove(jugada);

            Token extremos = board.Boardextremes();

            if (extremos.FaceA == null || extremos.FaceB == null) return new Tuple<Token, IComparable>(jugada, null);
            return Comp(jugada, extremos);
        }
        public List<Token> PosiblesJugadas(List<Token> playerHand, Token extremos)
        {
            if (extremos.FaceA == null || extremos.FaceB == null) return playerHand;
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

        protected Tuple<Token, IComparable> Comp(Token jugada, Token extremos)
        {
            Random x = new Random();
            Func<Random, IComparable> randomface = x => x.Next(0, 1) == 0 ? extremos.FaceA : extremos.FaceB;
            if (extremos.FaceA.CanbeMatch(extremos.FaceB))
                return new Tuple<Token, IComparable>(jugada, randomface(x));
            if (jugada.FaceA.CanbeMatch(extremos.FaceA) || jugada.FaceB.CanbeMatch(extremos.FaceA))
                return new Tuple<Token, IComparable>(jugada, extremos.FaceA);

            return new Tuple<Token, IComparable>(jugada, extremos.FaceB);
        }
    }
}
