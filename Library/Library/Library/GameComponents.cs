namespace Library;

public class GameComponents
{
    public Board _board = new Board();
    private ITokenRule TokenRule;
    private ITurnRule TurnRule;
    public Player[] players { get; }
    private CanPlay _canPlay = new CanPlay();
    private List<Token> domain;
    private IComparer<Token> _comparer;
    public int numberofgames;

    public GameComponents(Player[] players, ITokenRule tokenRule, ITurnRule turnRule, List<Token> Deck, int numberofgames)
    {
        this.players = players;
        TurnRule = turnRule;
        TokenRule = tokenRule;
        this.numberofgames = numberofgames;
    }
    

  
    private int DrawWinner(Player[] player, int[] totalScoreHand) 
    { 
        int playerWinner = -1;//para q no de error el return
        for (int j = 0; j < player.Length; j++)
        {
            
            totalScoreHand[j] = player[j].PlayerHandScore();
        }

        int x = totalScoreHand.Min();

        int count = 0;
        for (int j = 0; j < player.Length; j++)
        {
            if (x == totalScoreHand[j]) 
            {
                playerWinner = j;
                count++;
            }
        }

        if (count > 1) return -1;
        //en caso de haber mas de 1 jugador con el mismo score entonces se empato el juego y hay que repetirlo
        return playerWinner;
    }
}
