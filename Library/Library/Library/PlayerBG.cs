using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PlayerBG : Player
    {
        public override int PlayerScore { get; protected set; } = 0;

        public override List<Token> PlayerHand { get; }

        public override Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos)
        {
            //player bota gorda
            Token jugada = posiblesjugadas[0];

            for (int i = 1; i < posiblesjugadas.Count; i++)
            {
                if (jugada.Score < posiblesjugadas[i].Score)
                    jugada = posiblesjugadas[i];
            }

            PlayerScore += jugada.Score;

            IComparable y = extremos.FaceB;
            if ((jugada.FaceA.Compare(extremos.FaceA) == 0 || jugada.FaceA.Compare(extremos.FaceB) == 0) &&
                          (jugada.FaceB.Compare(extremos.FaceA) == 0 || jugada.FaceB.Compare(extremos.FaceB) == 0))
            {
                y = extremos.FaceA.Compare(extremos.FaceB)== 1? extremos.FaceA: y;
                return new Tuple<Token, IComparable>(jugada, extremos.FaceA);
            }
            else if (jugada.FaceA == extremos.FaceA || jugada.FaceB == extremos.FaceA)
            {
                y = extremos.FaceA;
                return new Tuple<Token, IComparable>(jugada, y);
            }

            return new Tuple<Token, IComparable>(jugada, y);


            //bota la ficha mas gorda... en caso de que pueda jugar por ambos extremos juega por
            //el mayor extremo
        }
    }
}