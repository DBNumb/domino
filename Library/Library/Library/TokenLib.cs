﻿using System.Diagnostics.CodeAnalysis;

namespace Library;

public class Token
{
    public Tuple<int, int> values;

    public Token(int value1, int value2)
    {
        values = new Tuple<int, int>(value1, value2);
    }
}

public class TokenDeck
{
    private TokenRule _filter;
    public Token[] _deck;

    public TokenDeck(TokenRule rule, int max)
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
public abstract class TokenRule : ITokenRule
{
    public abstract Ifilter<Token> Check();
}

public class NoDoubleRule : TokenRule
{
    public override Ifilter<Token> Check()
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

public class DefaultTokeRule : TokenRule
{
    public Ifilter<Token> filter;

    public override Ifilter<Token> Check()
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