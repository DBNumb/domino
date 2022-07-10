namespace Library;

public class GameStart
{
    private Board _board = new Board();
    private ITokenRule TokenRule;
    private ITurnRule TurnRule;
    private Player[] players;
    private CanPlay _canPlay = new CanPlay();
    private List<Token> domain;
    private IComparer<Token> _comparer;
    

    public GameStart(Player[] players, ITokenRule tokenRule, ITurnRule turnRule, List<Token> Deck, int numberofgames)
    {
        this.players = players;
        TurnRule = turnRule;
        TokenRule = tokenRule;
        
    }
    

    public void Play(Player[] player, IChecker<Player[]> checker)
    {
        int consecutivesKnocks = 0;
        int[] totalScoreHand = new int[players.Length];
        int playerWinner;
        int i = 0;
        do 
        {
            if (i >= player.Length) i = 0;

            if (_canPlay.Apply(player[i].PlayerHand, _board.Boardextremes(), _comparer))
            {
                consecutivesKnocks = 0;
                _board.Insert(player[i].Juega(_canPlay.posiblesjugadas, _board.Boardextremes()));
            }
            else
            {
                consecutivesKnocks++;
                i = TurnRule.NxtTurn();
            }

            if (consecutivesKnocks == player.Length - 1)
            {
                playerWinner = DrawWinner(player, totalScoreHand);
                break;
            }
            
            i++;
        } while (checker.Win(player) == -1);
        playerWinner = i;
        //...................
    }

    private int DrawWinner(Player[] player, int[] totalScoreHand) 
    {
        int playerWinner = -1;//para q no de error el return
        for (int j = 0; j < player.Length; j++)
        {
            int aux = 0;
            for (int k = 0; k < player[j].PlayerHand.Count; k++)
            {
                aux += player[j].PlayerHand[k].Score;
            }
            totalScoreHand[j] = aux;
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
