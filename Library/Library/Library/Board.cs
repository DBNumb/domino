namespace Library;

public class Board 
{
    private List<Token> board;
    
    public Board()
    {
        board = new List<Token>();
        
    }
    
    public int CountBoard(int value)
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
        if (board.Count == 0) return new Token(new Valuable(-1,"<blank>"),new Valuable(-1,"<blank>"));
        int begin = board[0].ValueItem1, ending= board[board.Count-1].ValueItem2;
        string begindesc = board[0].DescriptionItem1, endingdesc = board[board.Count - 1].DescriptionItem2;
        return new Token(new Valuable(begin, begindesc), new Valuable(ending, endingdesc));
    }

    public void Insert(Tuple<Token, int> play)
    {
        Token board_Extremes = Boardextremes();
        if (board.Count==0)
        {
            board.Add(play.Item1);
            return;
        }

        if (board_Extremes.ValueItem1 == play.Item2)
        {
            if (play.Item1.ValueItem2==board_Extremes.ValueItem1)
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
            if (play.Item1.ValueItem1 == board_Extremes.ValueItem2)
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