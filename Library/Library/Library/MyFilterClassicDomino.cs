using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class MyFilterClassicDomino : IFilterFichas
    {
        public bool Apply(FichaDomino fichaPlayer, Tuple<int, int> tablero)
        {
            
            if ((fichaPlayer.mitadIzq == tablero.Item1 || fichaPlayer.mitadIzq == tablero.Item2) || (fichaPlayer.mitadDer == tablero.Item1 || fichaPlayer.mitadDer == tablero.Item2)) 
            {
                return true;
            }
            return false;
        }
    }
}
