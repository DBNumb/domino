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
    public int item1 { get; }
    public int item2 { get; }

    public int score { get; }
    
}


#endregion

public interface IFilterFichas
{
    public List<IToken> posiblesjugadas { get; set; }

    public bool Apply(List<IToken> fichasPlayer, IToken Estado_tablero);
    //hay q abstraernos mas pq esto solo funciona para domino
}

// public delegate Library.TokenCollection Insert<Token, Int32, TokenCollection>(Token x,int pos,out TokenCollection collection);