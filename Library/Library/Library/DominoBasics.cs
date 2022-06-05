using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;
public  class CanPlay : IFilterFichas
{
    public static bool SomeoneCanPlay;
    public Token[] posiblesjugadas { get; set; }

    public bool Apply(Token[] fichaPlayer, Token tablero)
    {
        List<Token> posiblesjugadas = new List<Token>();
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