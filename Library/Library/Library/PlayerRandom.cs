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

        public override Token Juega(Token[] posiblesjugadas)
        {
            //envia una jugada random de las que se le pasan por parametro
            var randomNumber = new Random(posiblesjugadas.Length);
            int x = randomNumber.Next(0, posiblesjugadas.Length);
            PlayerScore += posiblesjugadas[x].score;
            return posiblesjugadas[x];
        }
    }
}
