namespace Library;

public static class Extensions
{
    public static Token Reverse(this Token x)
    {
        Token aux = new Token(new Valuable(x.ValueItem2, x.DescriptionItem2),
            new Valuable(x.ValueItem2, x.DescriptionItem2));
        return x = aux;
    }
}