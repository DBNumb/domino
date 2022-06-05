using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Library;

public class Token
{
    public Tuple<int, int> values { get; }
    public int Item1;
    public int Item2;
    public int score { get; }

    public Token(int value1, int value2)
    {
        Item1 = value1;
        Item2 = value2;
        score = value1 + value2;
    }

    public Token[] RemoveToken(Token[] tokens, int i)
    {
        int index = 0;
        Token[] result = new Token[tokens.Length - 1];
        for (int j = 0; j < tokens.Length; j++)
        {
            if (j == i) continue;
            result[index] = tokens[j];
        }

        return result;
    }
}

public class TokenDeck
{
    private ITokenRule<Token> _tokenRule;
    public Token[] _deck;

    public TokenDeck(ITokenRule<Token> rule, int max)
    {
        _tokenRule = rule;
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
                if (_tokenRule.Apply(tmp))
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

public class NoDoubleRule : ITokenRule<Token>
{
    public bool Apply(Token x)
    {
        return x.Item1 != x.Item2;
    }
}

public class DefaultTokeRule : ITokenRule<Token>
{
    public ITokenRule<Token> TokenRule;


    public bool Apply(Token x)
    {
        return true;
    }
}

#endregion