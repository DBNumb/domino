namespace Library;

public class Game
{
    public Game(Player[] players)
    {
        Turns turn = new Turns(0, players.Length - 1);
    }
}