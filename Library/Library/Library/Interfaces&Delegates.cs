using System.Collections;
using System.Runtime.CompilerServices;

namespace Library;

#region GenericTokenInterface

public interface IValuable
{ 
    public int value { get; }
    public string  description { get; } 
        
}

public interface IToken : IEnumerable
{   
    List<IValuable>_valuables { get; }
    public void Getvalues(ICollection<IValuable> coll);
    public int score { get; }
    public int GetScore(ICollection<IValuable> collection) ;
    
}


#endregion

public interface IFilterFichas
{
    public List<IToken> posiblesjugadas { get; set; }

    public bool Apply(List<IToken> fichasPlayer, IToken Estado_tablero);
    //hay q abstraernos mas pq esto solo funciona para domino
}

// public delegate Library.TokenCollection Insert<Token, Int32, TokenCollection>(Token x,int pos,out TokenCollection collection);