namespace Library;

public class Board<T> where T: IToken, IComparable, IValuable
{
    public List<T> board;

    public Board()
    {
        board = new List<T>();
        
    }
    
    public int CountBoard(int value)
    {
        int count = 0;
        foreach (var token in board)
        {
            foreach (var val in token._valuables)
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