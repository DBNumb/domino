using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;
public  class CanPlay: IFilterFichas
{
    public static bool SomeoneCanPlay;
    public List<IToken> posiblesjugadas { get; set; }
    public bool Apply(List<IToken> fichaPlayer,IToken Estado_tablero)
    {
        List<IToken> posiblesjugadas = new List<IToken>();
        foreach (var vToken in fichaPlayer)
        {
            if (TokenEqualToEdges(vToken, Estado_tablero))
            {
                SomeoneCanPlay = true;
                posiblesjugadas.Add(vToken);
            }
        }

        this.posiblesjugadas = posiblesjugadas;
        SomeoneCanPlay = posiblesjugadas.Count != 0;
        return SomeoneCanPlay;
    }

    public static bool TokenEqualToEdges(IToken x, IToken board)
    {
        foreach (var playertoken in x._valuables)
        {
            foreach (var boardtoken in board._valuables)
            {
                if (playertoken.value == boardtoken.value) return true;
            }
        }

        return false;
    }
}