namespace Library;

public static class Extensions
{
    public static Token Reverse(this Token x)
    { 
        Token aux = new Token(x.FaceB, x.FaceA);
        return x = aux;
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