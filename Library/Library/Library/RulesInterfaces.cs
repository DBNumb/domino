namespace Library;

public interface ITokenRule 
{
    public bool Apply(Token x);
}

public interface ITurnRule
{
    public int NxtTurn();
}


public interface IChecker<T>
{
    public int Win(T obj);
    
}

