namespace Library;

public class Winner
{
    public int player_Index { get; }
    public int wins { get; set; }
    public Winner(int playerIndex)
    {
        player_Index = playerIndex;
    }
}