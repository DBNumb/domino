using System.Runtime.CompilerServices;

namespace Library;

#region  GenericTokenInterface
public interface IValuable
{
    public int value { get; }
}
public interface IToken<T>: IEnumerable<T>
{
    public T this[int index] { get; }
    public List<T> values { get;  }
    public void Getvalues(ICollection<T> coll);
    public int score { get; }
    public int GetScore(ICollection<T> collection);
}
#endregion 
public interface IFilterFichas<Token> where Token: IToken<Token>
{
    public List<Token> posiblesjugadas { get; set; }
    public bool Apply(List<Token> fichasPlayer, Token Estado_tablero);
    //hay q abstraernos mas pq esto solo funciona para domino
}

// public delegate Library.TokenCollection Insert<Token, Int32, TokenCollection>(Token x,int pos,out TokenCollection collection);

