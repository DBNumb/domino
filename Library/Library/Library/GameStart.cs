namespace Library;

public class GameStart
{
    private Board _board = new Board();
    private bool win = false;
    private ITokenRule TokenRule;
    private ITurnRule TurnRule;
    private Player[] players;
    private CanPlay _canPlay = new CanPlay();
    private List<Token> domain;
    private IComparer<Token> _comparer;

    public GameStart(Player[] players, ITokenRule tokenRule, ITurnRule turnRule,List<IValuable> valuables,IComparer<Token> comp)
    {
        this.players = players;
        TurnRule = turnRule;
        TokenRule = tokenRule;
        domain = CreateDeck(valuables, tokenRule);
    }

    private List<Token> CreateDeck(List<IValuable> valuables, ITokenRule tokenRule)
    {
        List<Token> result = new List<Token>();
        foreach (var valuable1 in valuables)
        {
            foreach (var valuable2 in valuables)
            {
                Token aux = new Token(valuable1, valuable2);
                if (tokenRule.Apply(aux))
                {
                    result.Add(aux);
                }
            }
        }

        return result;
    }

    public void Play(Player[] player, IChecker checker)
    {
        for (int i = 0;!checker.Win(); i++)
        {
            if (i >= player.Length) i = 0;
            if (_canPlay.Apply(player[i].PlayerHand, _board.Boardextremes(), _comparer))
            {
               _board.Insert( player[i].Juega(_canPlay.posiblesjugadas,_board.Boardextremes(),_comparer));
            }
            else
            {
                i = TurnRule.NxtTurn();
            }
        }
    }
}