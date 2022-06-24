namespace Library;

public interface ITokenRule 
{
    public bool Apply(IToken x);
}

public interface ITurnRule
{
    public int NxtTurn();
}


public interface IChecker<T>
{
    public int Win(T obj);
}

