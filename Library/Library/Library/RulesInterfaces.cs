namespace Library;

public interface ITokenRule<T> where T : IToken<T>, IValuable
{
    public bool Apply(T x);
}

public interface ITurnRule
{
    public int NxtTurn();
}

public interface IWin
{
    
}

public interface ISuperToken
{
    
}