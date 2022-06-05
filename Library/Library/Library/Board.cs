namespace Library;

public class Board
{
    public List<Token> board;

    public Board()
    {
        board = new List<Token>();
        
    }

    public int CountBoard(int value)
    {
        int count = 0;
        foreach (var token in board)
        {
            if (value == token.Item1 || value == token.Item2)
            {
                count++;
            }
        }

        return count;
    }
  
}