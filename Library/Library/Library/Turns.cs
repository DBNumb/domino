namespace Library;

public class Turns
{
    private int turn;
    

    public Turns(int start)
    {
        turn = start;
    }

    public void NxtTurn()
    {
        turn++;
    }
}