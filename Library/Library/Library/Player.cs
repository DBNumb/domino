using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PosiblesJugadas: IFilterFichas
    {
        public Token[] posiblesjugadas { get; set; }
        public bool Apply(Token[] fichasPlayer, Tuple<int, int> Estado_tablero)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Player
    {
        //clase abstracta jugador
        public abstract Token Juega(Token[] posiblesjugadas);

    }
    
}
