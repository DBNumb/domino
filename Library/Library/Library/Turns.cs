namespace Library;

public class Turns
{
    private int turn;
    private int max;

    public Turns(int start,int max)
    {
        turn = start;
        this.max = max;
    }

    public void NxtTurn()
    {
        if (turn == max) turn = 0;
        else
        {
            turn++;
        }
    }
}