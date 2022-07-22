namespace Library;

public interface ITokenRule 
{
    public bool Apply(Token x);
}

public interface ITurnRule
{   int nxt_turn { get; }
    public int NxtTurn(int knocks);
}


public interface SelectionRule
{
    
}

public interface IGameBreak
{  public bool draw { get; set; }
    public Winner GetWinner();
    public bool Over(GameComponents gamestatus);
}
