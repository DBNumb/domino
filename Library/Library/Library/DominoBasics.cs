using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;
public  class CanPlay<T> : IFilterFichas<T> where T : IToken<T>, IValuable
{
    public static bool SomeoneCanPlay;
    public List<T> posiblesjugadas { get; set; }
    public bool Apply(List<T> fichaPlayer,T Estado_tablero)
    {
        List<T> posiblesjugadas = new List<T>();
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

    public static bool TokenEqualToEdges(T x, T board)
    {
        return x.Item1 == board.Item1 || x.Item1 == board.Item2 || x.Item2 == board.Item1 ||
               x.Item2 == board.Item2;
    }
}