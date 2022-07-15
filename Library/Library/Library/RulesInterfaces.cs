namespace Library;

public interface ITokenRule 
{
    public bool Apply(Token x);
}

public interface ITurnRule
{   int nxt_turn { get; }
    public int NxtTurn(int knocks);
}


public interface IChecker<T>
{   
    public int Win(T obj);
    
}

