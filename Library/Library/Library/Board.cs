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
            foreach (var val in token)
            {
                if (value == val.value)
                {
                    count++;
                }
            }
        }

        return count;
    }
  
}