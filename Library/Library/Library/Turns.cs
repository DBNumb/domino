namespace Library;

public class ClockTurn : ITurnRule
{
    public int nxt_turn { get; }
    private int consecutives_knocks = 0;

    public int NxtTurn(int knocks)
    {
        if (knocks == 0 || consecutives_knocks >= 2)
        {
            consecutives_knocks = 0;
            return 1;
        }
        consecutives_knocks++;
        return -1;
    }

    public ClockTurn()
    {
        nxt_turn = 0;
    }
}

public class ClassicTurn : ITurnRule
{
    public int nxt_turn { get; }

    public int NxtTurn(int knocks)
    {
        return 1;
    }

    public ClassicTurn()
    {
        nxt_turn = 0;
    }
}