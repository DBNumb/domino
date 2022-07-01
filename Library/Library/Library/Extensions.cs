namespace Library;

public static class Extensions
{
    public static Token Reverse(this Token x)
    {
        Token aux = new Token(x.ValueItem2, x.ValueItem1);
        return x = aux;
    }
}