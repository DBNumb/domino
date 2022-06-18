using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;
public  class CanPlay<T> : IFilterFichas<T> where T : IToken<T>
{
    public static bool SomeoneCanPlay;
    public List<T> posiblesjugadas { get; set; }

    public bool Apply<T>(List<IToken<T>> fichaPlayer,T tablero)
    {
        List<IToken<T>> posiblesjugadas = new List<IToken<T>>();
        foreach (var vToken in fichaPlayer)
        {
            if (TokenEqualToEdges(vToken, tablero))
            {
                SomeoneCanPlay = true;
                posiblesjugadas.Add(vToken);
            }
        }

        this.posiblesjugadas = posiblesjugadas.ToArray();
        SomeoneCanPlay = posiblesjugadas.Count != 0;
        return SomeoneCanPlay;
    }

    public static bool TokenEqualToEdges(Token x, Token board)
    {
        return x.Item1 == board.Item1 || x.Item1 == board.Item2 || x.Item2 == board.Item1 ||
               x.Item2 == board.Item2;
    }
}