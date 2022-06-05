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

        public override Tuple<Token, int> Juega(Token[] posiblesjugadas, int extremo1, int extremo2)
        {
            //envia una jugada random de las que se le pasan por parametro
            var randomNumber = new Random(posiblesjugadas.Length);
            int x = randomNumber.Next(0, posiblesjugadas.Length);
            PlayerScore += posiblesjugadas[x].score;

            Token jugada = posiblesjugadas[x];
            int[] indices = {extremo1, extremo2};
            
            int y;
           
            if ((jugada.values.Item1 == extremo1 && jugada.values.Item2 == extremo2)
                || (jugada.values.Item1 == extremo2 && jugada.values.Item2 == extremo1))
            {
                var randomIndice = new Random(indices.Length);
                y = randomIndice.Next(0, indices.Length);
            }
            else if (jugada.values.Item1 == extremo1 || jugada.values.Item2 == extremo1)
            {
                y = extremo1;
            }
            else y = extremo2;

            //retorna la ficha a jugar y el extremo que jugara al azar en caso de poder jugar por ambos extremos
            return Tuple.Create(jugada, y);
        }
    }
}
