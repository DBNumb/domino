

namespace Library;

public class CanPlay : IFilterFichas
{
    public static bool SomeoneCanPlay;
    public List<Token> posiblesjugadas { get; set; }

    public bool Apply(List<Token> fichaPlayer, Token Estado_tablero, IComparer<Token> comp)
    {
        List<Token> posiblesjugadas = new List<Token>();
        foreach (var vToken in fichaPlayer)
        {
            if (TokenEqualToEdges(vToken, Estado_tablero, comp))
            {
                SomeoneCanPlay = true;
                posiblesjugadas.Add(vToken);
            }
        }

        this.posiblesjugadas = posiblesjugadas;
        SomeoneCanPlay = posiblesjugadas.Count != 0;
        return SomeoneCanPlay;
    }

    private static bool TokenEqualToEdges(Token x, Token board, IComparer<Token> comp)
    {
        int a = 0;
        a = comp.Compare(x, board);
        return a >= 0;
    }
}