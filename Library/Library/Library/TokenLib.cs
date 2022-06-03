using System.Diagnostics.CodeAnalysis;

namespace Library;

public class Token
{
    public Tuple<int, int> values;
    public int Score;
    public Token(int value1, int value2)
    {
        values = new Tuple<int, int>(value1, value2);
        Score = value1 + value2;
    }

    public Token[] RemoveToken(Token[] tokens, int i)
    {
        int index = 0;
        Token[] result = new Token[tokens.Length - 1];
        for (int j = 0; j < tokens.Length; j++)
        {
            if(j==i) continue;
            result[index] = tokens[j];
        }

        return result;
    }
    public bool TokenEqualToEdges(Tuple<int,int> x)
    {
        return this.values.Item1 == x.Item1 || this.values.Item1 == x.Item2 || this.values.Item2 == x.Item1 ||
               this.values.Item2 == x.Item2;
    }
}

public class TokenDeck
{
    private ITokenRule _filter;
    public Token[] _deck;

    public TokenDeck(ITokenRule rule, int max)
    {
        _filter = rule;
        _deck = GenerateDeck(max);
    }

    private Token[]? GenerateDeck(int max)
    {
        List<Token> temp = new List<Token>();
        for (int i = 0; i <= max; i++)
        {
            for (int j = i; j <= max; j++)
            {
                Token tmp = new Token(i, j);
                if (_filter.Check().Apply(tmp))
                {
                    temp.Add(tmp);
                }
            }
        }

        return temp.ToArray();
    }

    private int Sum(int max)
    {
        int result = 0;
        for (int i = 1; i <= max; i++)
        {
            result += i;
        }

        return result;
    }
}
#region Tokenrule
public class NoDoubleRule : ITokenRule
{
    public  Ifilter<Token> Check()
    {
        return new Filter();
    }
    private class Filter: Ifilter<Token>
    {
        public bool Apply(Token x)
        {
            return x.values.Item1 == x.values.Item2;
        }
    }
}

public class DefaultTokeRule : ITokenRule
{
    public Ifilter<Token> filter;

    public Ifilter<Token> Check()
    {
        return new Filter();
    }
    private class Filter : Ifilter<Token>
    {
        public bool Apply(Token x)
        {
            return true;
        }
    }
}
#endregion