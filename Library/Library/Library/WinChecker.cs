using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PlayerChecker : IChecker<Player[]>
    {
        //si win retorna 1 es que alguien gano, si retorna 0 es que hay empate, si retorna -1 sigue el juego

        public int Win(Player[] player)
        {
            foreach (var p in player) 
            {
                if(p.PlayerHand.Count == 0) return 1;
            
            }
            return 0;
        }
    }
    class CheckerBoard : IChecker<Board>
    {
        public int Win(Board board)
        {
           throw new NotImplementedException();
        }
    }
}
