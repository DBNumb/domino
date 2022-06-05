using System.Runtime.CompilerServices;

namespace Library;


public interface IFilterFichas
{
    public Token[] posiblesjugadas { get; set; }
    public bool Apply(Token[] fichasPlayer, Token Estado_tablero);
    //hay q abstraernos mas pq esto solo funciona para domino
}

// public delegate Library.TokenCollection Insert<Token, Int32, TokenCollection>(Token x,int pos,out TokenCollection collection);

