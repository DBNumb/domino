namespace Library;

public class GameComponents
{
    public Board _board = new Board();
    public ITokenRule TokenRule;
    public ITurnRule TurnRule;
    public Player[] players { get; }
    public IReglaDeSelección _reglaDeSelección;
    public List<Token> domain;
    private IComparer<Token> _comparer;
    public int numberofgames;

    public GameComponents(Player[] players, ITokenRule tokenRule, ITurnRule turnRule, List<Token> Deck,
        int numberofgames,IReglaDeSelección reglaDeSelección)
    {
        _reglaDeSelección = reglaDeSelección;
        domain = Deck;
        this.players = players;
        TurnRule = turnRule;
        TokenRule = tokenRule;
        this.numberofgames = numberofgames;
    }


    public Winner[] DrawWinner(Player[] player, int[] totalScoreHand)
    {
        List<Winner> result = new List<Winner>();
        for (int j = 0; j < player.Length; j++)
        {
            totalScoreHand[j] = player[j].PlayerHandScore();
        }

        int x = totalScoreHand.Min();

        for (int j = 0; j < player.Length; j++)
        {
            if (x == totalScoreHand[j])
            {
                Winner aux = new Winner(j);
                result.Add(aux);
            }
        }

        return result.ToArray();
    }

    public void AsignaFichasAPlayers( int max)
    {
        _reglaDeSelección.AsignaFichaPlayer(domain,players,max);
    }
    
}