using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Library;

public class Token : IToken
{
    public int this[int index]
    {
        get
        {
            if (index > 1|| index<0) throw new NotImplementedException();
            if (index == 1) return this.ValueItem1;
            else
            {
                return this.ValueItem2;
            }
        }
        
    }
    public int ValueItem1 { get; }
    public int ValueItem2 { get; }
    public string DescriptionItem1 { get; }
    public string DescriptionItem2 { get; }
    public Token(IValuable value1, IValuable value2)
    {
        this.ValueItem1 = value1.value;
        this.ValueItem2 = value2.value;
        score = value1.value + value2.value;
        this.DescriptionItem1 = value1.description;
        this.DescriptionItem2 = value2.description;
    }
    public virtual string Description()
    {
        return $"[ {DescriptionItem1}, {DescriptionItem2} ]";
    }



    public int score { get; }
    
}
public class TokenComparer: IComparer<Token>{
    public int Compare(Token x, Token edges)
    {
        if (edges.score == -2) return 1;
        int count = -1;
        bool[] used = new bool[2];
        for (int i = 0; i < used.Length; i++)
        {
            for (int j = 0; j < used.Length; j++)
            {
                if (x[i] == edges[j]&& !used[j])
                {
                    count++;
                    used[j] = true;
                }
            }
        }

        return count;
    }
}
#region Tokenrule

public class NoDoubleRule : ITokenRule
{
    public bool Apply(IToken x)
    {
        return x.ValueItem1 != x.ValueItem2;
    }
}

public class DefaultTokeRule : ITokenRule
{
    public bool Apply(IToken x)
    {
        return true;
    }
}

#endregion
public class Valuable : IValuable
{
    public int value { get; }
    public string description { get; }

    public Valuable(int value, string description)
    {
        this.value = value;
        this.description = description;
    }
}
