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

        public override Tuple<Token, int> Juega(List<Token> posiblesjugadas, Token extremos, IComparer<Token> comp)
        {
            //player bota gorda
            Token jugada = posiblesjugadas[0];

            for (int i = 1; i < posiblesjugadas.Count; i++)
            {
                if (jugada.score < posiblesjugadas[i].score)
                    jugada = posiblesjugadas[i];
            }

            PlayerScore += jugada.score;

            int y = extremos.ValueItem2;
            if (comp.Compare(jugada, extremos) == 1)
            {
                y = Math.Min(extremos.ValueItem1, extremos.ValueItem2);
                return new Tuple<Token, int>(jugada, extremos.ValueItem1);
            }

            if (jugada.ValueItem1 == extremos.ValueItem1 || jugada.ValueItem2 == extremos.ValueItem1)
            {
                y = extremos.ValueItem1;
                return new Tuple<Token, int>(jugada, y);
            }

            return new Tuple<Token, int>(jugada, y);


            //bota la ficha mas gorda... en caso de que pueda jugar por ambos extremos juega por
            //el menor extremo
        }
    }
}