namespace Library;

public class Board 
{
    private List<Token> board;
    
    public Board()
    {
        board = new List<Token>();
        
    }
    
    public int CountBoard(IComparable value)
    {
        int count = 0;
        foreach (var token in board)
        {
            if (value == token.ValueItem1 || value == token.ValueItem2) count++;
        }

        return count;
    }

    public Token Boardextremes()
    {
        if (board.Count == 0) return new Token(null,null);
        IComparable begin = board[0].ValueItem1, ending= board[board.Count-1].ValueItem2;
        return new Token(begin, ending);
    }

    public void Insert(Tuple<Token, IComparable> play)
    {
        Token board_Extremes = Boardextremes();
        if (board.Count==0)
        {
            board.Add(play.Item1);
            return;
        }

        if (board_Extremes.ValueItem1.CompareTo(play.Item2)==0)
        {
            if (play.Item1.ValueItem2.CompareTo(board_Extremes.ValueItem1)==0)
            {
                board.Insert(0,play.Item1);
            }
            else
            {
                board.Insert(0,play.Item1.Reverse());
            }
        }
        else
        {
            if (play.Item1.ValueItem1.CompareTo(board_Extremes.ValueItem2)==0 )
            {
                board.Insert(board.Count,play.Item1);
            }
            else
            {
                board.Insert(board.Count,play.Item1.Reverse());
            }
        }
    }
}