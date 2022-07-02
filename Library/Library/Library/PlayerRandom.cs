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

        public override List<Token> PlayerHand { get; }

        public override Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos, IComparer<Token> comp)
        {
            //envia una jugada random de las que se le pasan por parametro
            var randomNumber = new Random(posiblesjugadas.Count);
            int x = randomNumber.Next(0, posiblesjugadas.Count);
            PlayerScore += posiblesjugadas[x].score;

            Token jugada = posiblesjugadas[x];
            // int[] indices = {extremo1.value, extremo2.value};
            
            IComparable y=extremos.ValueItem2;
           
            if (comp.Compare(jugada,extremos)==1)
            {
                return new Tuple<Token, IComparable>(jugada, extremos.ValueItem1);
            }
            else if (jugada.ValueItem1 == extremos.ValueItem1 || jugada.ValueItem2 == extremos.ValueItem1)
            {
                return new Tuple<Token, IComparable>(jugada, extremos.ValueItem1);
            }

            return new Tuple<Token, IComparable>(jugada, extremos.ValueItem2);

            
            //retorna la ficha a jugar y el extremo que jugara al azar en caso de poder jugar por ambos extremos
        }
    }

    
}
