namespace Library;

public static class Extensions
{
    public static Token Reverse(this Token x)
    {
        Token aux = new Token(x.FaceB, x.FaceA);
        return x = aux;
    }
}