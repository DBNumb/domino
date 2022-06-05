namespace Library;

public  class Turns
{
    public  int nxturn { get; }
    public Turns(ITurnRule rule)
    {
        nxturn = rule.NxtTurn();
    }
    
}

public class ClockTurn : ITurnRule
{
    public int NxtTurn()
    {
        if (CanPlay.SomeoneCanPlay) return  1;
        else
        {
            return  -1;
        }
    }
}

public class ClassicTurn : ITurnRule
{
    public int NxtTurn()
    {
        return 1;
    }
}