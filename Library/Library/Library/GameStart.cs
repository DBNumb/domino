namespace Library;

public class GameStart
{
    private bool win= false;
    private ITokenRule TokenRule;
    private ITurnRule TurnRule;
    private Player[] players;
    public GameStart(Player[] players, ITokenRule tokenRule, ITurnRule turnRule)
    {
        this.players = players; 
        TurnRule = turnRule;
        TokenRule = tokenRule;
        Play();
    }

    private void Play()
    {
        while (!win)
        {
            
        }
    }
}