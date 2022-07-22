namespace Library;

public class Board
{
    //clase Board, simula el tablero de juego y a traves de sus diferentes metodos brinda informacion.
    public List<Token> board;
    
    public Board()
    {
        board = new List<Token>();
        
    }
    
    public int CountBoard(IComparable value)
    {
        //cuenta la cantidad de fichas en el tablero del mismo valor que se le pasa como parametro. 
        int count = 0;
        foreach (var token in board)
        {
            if (value == token.FaceA || value == token.FaceB) count++;
        }

        return count;
    }

    public Token Boardextremes()
    { 
        //devuelve los extremos del tablero.
        if (board.Count == 0) return new BoardToken(null,null);
        IFace begin = board[0].FaceA, ending= board[board.Count-1].FaceB;
        
        return new BoardToken(begin, ending);
    }

    public void Insert(Tuple<Token, IComparable> play)
    {
        Token board_Extremes = Boardextremes();
        
        if (board.Count==0)
        {
            board.Add(play.Item1);
            return;
        }

        if (board_Extremes.FaceA.Compare(play.Item2) == 0)
        {
            if (play.Item1.FaceB.Compare(board_Extremes.FaceA)==0)
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
            if (play.Item1.FaceA.Compare(board_Extremes.FaceB)==0 )
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