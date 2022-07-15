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

    public static int PlayerHandScore(this Player player)
    {
        int result = 0;
        foreach (var VARIABLE in player.PlayerHand)
        {
           result= VARIABLE.FaceA.GetPuntuation() + VARIABLE.FaceB.GetPuntuation();
        }

        return result;
    }
}