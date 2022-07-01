using System.Collections;
using System.Runtime.CompilerServices;

namespace Library;

#region GenericTokenInterface

public interface IValuable
{ 
    public int value { get; }
    public string  description { get; } 
        
}

public class CaradeFicha: IValuable
{
    public int value { get; }
    public string description { get; }

    public CaradeFicha(int value, string description)
    {
        this.value = value;
        this.description = description;
    }
}
public interface IToken 
{   
    
    public IComparable ValueItem1 { get; }
    public IComparable ValueItem2 { get; }
    
    public int score { get; }
    
}


#endregion

public interface IFilterFichas
{
    public List<Token> posiblesjugadas { get; set; }

    public bool Apply(List<Token> fichasPlayer, Token Estado_tablero, IComparer<Token>comp);
    //hay q abstraernos mas pq esto solo funciona para domino
}

// public delegate Library.TokenCollection Insert<Token, Int32, TokenCollection>(Token x,int pos,out TokenCollection collection);