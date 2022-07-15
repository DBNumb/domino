namespace Library;

public class GameComponents
{
    public Board _board = new Board();
    public ITokenRule TokenRule;
    public ITurnRule TurnRule;
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
    

    private Winner[] DrawWinner(Player[] player, int[] totalScoreHand) 
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

    public void AsignaFichasAPlayers(Player[] players, List<Token> deck)
    {
        bool[] mask = new bool[deck.Count];
        while (true)
        {
            if (players.Length > CuentaFalses(mask)) break;
            for (int i = 0; i < players.Length; i++)
            {
                var randomNumber = new Random(mask.Length);
                int x = randomNumber.Next(0, mask.Length);
                if (mask[x] == false)
                {
                    mask[x] = true;
                    players[i].PlayerHand.Add(deck[x]);
                }
                else
                {
                    i--;
                }
            }
        }
    }
    public int CuentaFalses(bool[] item)
    {
        int aux = 0;
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] == false) aux++;
        }
        return aux;
    }
}
