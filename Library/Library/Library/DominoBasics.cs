using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class MyFilterClassicDomino : IFilterFichas
    {
        public Token[] posiblesjugadas { get; set; }

        public bool Apply(Token[] fichaPlayer, Tuple<int, int> tablero)
        {
            List<Token> posiblesjugadas = new List<Token>();
            foreach (var vToken in fichaPlayer)
            {
                if (vToken.TokenEqualToEdges(tablero))
                {
                    posiblesjugadas.Add(vToken);
                }
            }

            this.posiblesjugadas = posiblesjugadas.ToArray();
            return posiblesjugadas.Count != 0;
        }
    }
}
