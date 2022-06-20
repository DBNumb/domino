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
        
        public override Tuple<IToken, int> Juega(List<IToken> posiblesjugadas, IValuable extremo1, IValuable extremo2)
        {
            //player bota gorda
            IToken jugada = posiblesjugadas[0];

            for (int i = 1; i < posiblesjugadas.Count; i++)
            {
                if (jugada.score < posiblesjugadas[i].score)
                    jugada = posiblesjugadas[i];
            }
            PlayerScore += jugada.score;

            int y;
            if ((jugada.item1 == extremo1.value && jugada.item2 == extremo2.value)
               || (jugada.item1 == extremo2.value && jugada.item2 == extremo1.value))
            {
                int[] indices = { extremo1.value, extremo2.value };
                y = indices.Min();
            }
            else if (jugada.item1 == extremo1.value || jugada.item2 == extremo1.value)
            {
                y = extremo1.value;
            }
            else y = extremo2.value;

            
            //bota la ficha mas gorda... en caso de que pueda jugar por ambos extremos juega por
            //el menor extremo


            return Tuple.Create(jugada, y);
        }
    }
}