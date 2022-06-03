namespace Library;

public class Game: IValid
{
    private Player[] _players;
    private bool win_or_draw;
    public Game(Player[] players)
    {
        _players = players;
        Turns turn = new Turns(0, players.Length - 1);
        
    }
    public bool ValidPlay()
    {
        throw new NotImplementedException();
    }
}

public interface IValid
{
    bool ValidPlay();
}