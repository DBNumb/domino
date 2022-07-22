using Library;

namespace DominoConsole;

public class EmptyHandWinner: IWinnersRule
{

    public Winner[] GetWinners(GameComponents gameComponents)
    {
        Winner[] solowin = new Winner[1];
        for (int i = 0; i < gameComponents.players.Length; i++)
        {
            if (gameComponents.players[i].PlayerHand.Count == 0)
            {
                solowin[0] = new Winner(i);
            }
        }

        if (solowin[0] == null) return null;
        return solowin;
    }
}

public class ScorePlayerWinner: IWinnersRule
{
    
    public Winner[] GetWinners(GameComponents gameComponents)
    {
        List<Winner> winners = new List<Winner>();
        var players = gameComponents.players;
        int[] maxs = new int[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            maxs[i] = players[i].GetPlayerScore;
        }

        int max = maxs.Max();
        for (int i = 0; i < maxs.Length; i++)
        {
            if(maxs[i]==max) winners.Add(new Winner(i)); 
        }

        if (winners.Count == 0) return null;
        return winners.ToArray();
    }
}