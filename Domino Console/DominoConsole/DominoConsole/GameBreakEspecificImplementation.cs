namespace DominoConsole;
using Library;
public  class PlayerFinish : IGameBreak
{
    public bool draw { get; set; }

    

    
    
    public bool Over(GameComponents gamestatus)
    {
        for (int i = 0; i < gamestatus.players.Length; i++)
        {
            if (gamestatus.players[i].PlayerHand.Count==0)
            {
               
                return true;
            }
        }
        return false;
    }
}

public class PlayFinish : IGameBreak
{

    public bool draw { get; set; }

   

    public GameComponents _gameComponents { get; }
    
    private GameComponents aux;
    private int currentPlays=0;
    private int max;
    public PlayFinish(int max)
    {
        this.max = max;
    }
    public bool Over(GameComponents gamestatus)
    {
        
        currentPlays++;
        if (currentPlays==max|| draw)
        {
            return draw = true;
        }

        return false;
    }
}

