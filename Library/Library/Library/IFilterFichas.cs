using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface IFilterFichas
    {
        public bool Apply(FichaDomino fichaPlayer, Tuple<int, int> tablero);
        //hay q abstraernos mas pq esto solo funciona para domino
    }
}
