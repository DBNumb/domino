using System.Data;

namespace Library;

public static class Extensions
{
    public static Token Reverse(this Token x)
    {
        var tem = x.FaceA;
        x.FaceA = x.FaceB;
        x.FaceB = tem;

        return x;
    }

    public static int TeamPlayerContainer(this Team[] x, int playerindex)
    {
        foreach (var team in x)
        {
            if (team.TeamMembers.Contains(playerindex)) return team.TeamIndex;
        }

        return 0;
    }
    public static Winner[] PrintWinners(this List<Winner> x,int length)
    {
        int max = 0;
        bool[] used = new bool[x.Count];
        for (int i = 0; i < length; i++)
        {
            int resultmax = 0;
            for (int j = 0; j < x.Count; j++)
            {
                if (x[j].player_Index == i) resultmax += i;
            }

            if (max < resultmax) max = resultmax;
        }

        List<Winner> aux = new List<Winner>();
        for (int i = 0; i < length; i++)
        {
            int count = 0;
            for (int j = 0; j < x.Count; j++)
            {
                if (x[j].player_Index == i) count++;
            }

            if (count == max)
            {
                aux.Add(new Winner(i));
                aux.Last().wins = max;
            }
            
        }

        return aux.ToArray();
    }
    public static int PlayerHandScore(this Player player)
    {
        int result = 0;
        foreach (var VARIABLE in player.PlayerHand)
        {
            result = VARIABLE.FaceA.GetPuntuation() + VARIABLE.FaceB.GetPuntuation();
        }

        return result;
    }
}