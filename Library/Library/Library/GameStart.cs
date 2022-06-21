namespace Library;

public class GameStart
{   private Board _board= new Board();
    private bool win= false;
    private ITokenRule TokenRule;
    private ITurnRule TurnRule;
    private Player[] players;
    private CanPlay _canPlay = new CanPlay();
    public GameStart(Player[] players, ITokenRule tokenRule, ITurnRule turnRule)
    {
        this.players = players; 
        TurnRule = turnRule;
        TokenRule = tokenRule;
        
    }

    public void Play(Player []player,IChecker checker)
    {
        for (int i = 0; ; i++)
        {
            if (i >= player.Length) i = 0;
            // _canPlay.Apply(player[i].)
        }
    }
}