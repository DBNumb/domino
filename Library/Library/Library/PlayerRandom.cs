using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
   public class PlayerRandom : Player
    {
        //clase para player random
        public override int PlayerScore { get; protected set; } = 0;

        public override List<Token> PlayerHand { get; set; }

        public override Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos)
        {
            //envia una jugada random de las que se le pasan por parametro
            
            if (posiblesjugadas == null) return null;
            //si no hay posibles jugadas no puede jugar
            
            var randomNumber = new Random(posiblesjugadas.Count);
            int x = randomNumber.Next(0, posiblesjugadas.Count);
            PlayerScore += posiblesjugadas[x].Score;

            Token jugada = posiblesjugadas[x];
            PlayerHand.Remove(jugada);

            if (extremos.FaceA == null || extremos.FaceB == null) return new Tuple<Token, IComparable>(jugada, null);
            // int[] indices = {extremo1.value, extremo2.value};
            return Comp(jugada, extremos);
            IComparable y=extremos.FaceB;
            //
            // if ((jugada.FaceA.Compare(extremos.FaceA) == 0 || jugada.FaceA.Compare(extremos.FaceB) == 0) &&
            //     (jugada.FaceB.Compare(extremos.FaceA) == 0 || jugada.FaceB.Compare(extremos.FaceB) == 0))
            // if (expr)
            // {
            //   
            //    
            //     return new Tuple<Token, IComparable>(jugada, extremos.FaceA);
            // }
            // else if (jugada.FaceA.Compare(extremos.FaceA)==0 || jugada.FaceB.Compare(extremos.FaceA)==0)
            // {
            //     //caso en el que solo se puede jugar por el extremo A
            //     return new Tuple<Token, IComparable>(jugada, extremos.FaceA);
            // }
            // //caso en el que solo se puede jugar por el extremo B
            // return new Tuple<Token, IComparable>(jugada, extremos.FaceB);

            
            //retorna la ficha a jugar y el extremo que jugara al azar en caso de poder jugar por ambos extremos
        }
    }

    
}
