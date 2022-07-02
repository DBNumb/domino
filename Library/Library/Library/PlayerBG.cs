using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PlayerBG : Player
    {
        public override int PlayerScore { get; protected set; } = 0;

        public override List<Token> PlayerHand { get; }

        public override Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos, IComparer<Token> comp)
        {
            //player bota gorda
            Token jugada = posiblesjugadas[0];

            for (int i = 1; i < posiblesjugadas.Count; i++)
            {
                if (jugada.score < posiblesjugadas[i].score)
                    jugada = posiblesjugadas[i];
            }

            PlayerScore += jugada.score;

            IComparable y = extremos.ValueItem2;
            if (comp.Compare(jugada, extremos) == 1)
            {
                y = extremos.ValueItem1.CompareTo(extremos.ValueItem2)==-1? extremos.ValueItem1: y;
                return new Tuple<Token, IComparable>(jugada, extremos.ValueItem1);
            }

            if (jugada.ValueItem1 == extremos.ValueItem1 || jugada.ValueItem2 == extremos.ValueItem1)
            {
                y = extremos.ValueItem1;
                return new Tuple<Token, IComparable>(jugada, y);
            }

            return new Tuple<Token, IComparable>(jugada, y);


            //bota la ficha mas gorda... en caso de que pueda jugar por ambos extremos juega por
            //el menor extremo
        }
    }
}