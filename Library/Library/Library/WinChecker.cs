using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PlayerChecker : IChecker<Player>
    {
        public bool Win(Player player)
        {
            if(player.PlayerHand.Count == 0) return true;
            return false;
        }
    }
    class CheckerBoard : IChecker<Board>
    {
        public bool Win(Board board)
        {
           throw new NotImplementedException();
        }
    }
}
