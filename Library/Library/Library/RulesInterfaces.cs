namespace Library;

public interface ITokenRule 
{
    public bool Apply(Token x);
}

public interface ITurnRule // Regla de turnos 
{   int nxt_turn { get; }
    public int NxtTurn(int knocks);
}


public interface IReglaDeSelección //Encargada de asignar las fichas 
{
    public void AsignaFichaPlayer(List<Token> domain,Player[] players, int max);
}

public interface IGameBreak
{  public bool draw { get; set; }
    

    public bool Over(GameComponents gamestatus);
}

public interface IWinnersRule
{
    
    public Winner[] GetWinners(GameComponents gameComponents);
}
