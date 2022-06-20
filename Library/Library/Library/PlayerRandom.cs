using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PlayerRandom : Player
    {
        //clase para player random
        public override int PlayerScore { get; protected set; } = 0;

        public override Tuple<IToken, int> Juega(List<IToken> posiblesjugadas, IValuable extremo1, IValuable extremo2)
        {
            //envia una jugada random de las que se le pasan por parametro
            var randomNumber = new Random(posiblesjugadas.Count);
            int x = randomNumber.Next(0, posiblesjugadas.Count);
            PlayerScore += posiblesjugadas[x].score;

            IToken jugada = posiblesjugadas[x];
            int[] indices = {extremo1.value, extremo2.value};
            
            int y;
           
            if ((jugada.item1 == extremo1.value && jugada.item2 == extremo2.value)
                || (jugada.item1 == extremo2.value && jugada.item2 == extremo1.value))
            {
                var randomIndice = new Random(indices.Length);
                y = randomIndice.Next(0, indices.Length);
            }
            else if (jugada.item1 == extremo1.value || jugada.item2 == extremo1.value)
            {
                y = extremo1.value;
            }
            else y = extremo2.value;

            //retorna la ficha a jugar y el extremo que jugara al azar en caso de poder jugar por ambos extremos
            return Tuple.Create(jugada, y);
        }
    }

    
}
