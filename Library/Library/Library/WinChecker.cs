using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
   public class PlayerChecker : IChecker<Player[]>
    {
        

        public int Win(Player[] player)
        {
            foreach (var p in player) 
            {
                if(p.PlayerHand.Count == 0) return 1;
            
            }
            return -1;
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
