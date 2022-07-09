using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Library;

public class Token : IToken
{
    
    public IComparable this[int index]
    {
        get
        {
            if (index > 1|| index<0) throw new NotImplementedException();
            if (index == 0) return this.ValueItem1;
            else
            {
                return this.ValueItem2;
            }
        }
        
    }
    public IComparable ValueItem1 { get; }
    public IComparable ValueItem2 { get; }
    public Token(IComparable value1, IComparable value2)
    {
        this.ValueItem1 = value1;
        this.ValueItem2 = value2;
    }
    public override string ToString()
    {
        return $"[ {ValueItem1.ToString()}, {ValueItem2.ToString()} ]";
    }



    public int score { get; }
    
}

public class TokenComparer : IComparer<Token>
{
    public int Compare(Token? x, Token? y)
    {
        int count = 0;
        bool[] used = new bool[2];
        for (int i = 0; i < used.Length; i++)
        {
            for (int j = 0; j < used.Length ; j++)
            {
                if (!used[j]&& x[i].CompareTo(y[j])==0)
                {
                    count++;
                    used[j] = true;
                }
            }
        }

        if (count == 0) return -1;
        if (count == 1)
        {
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i]) return i;
            }
        }

        return 2;
    }
}
    #region Tokenrule

public class NoDoubleRule : ITokenRule
{
    public bool Apply(IToken x)
    {
        return x.ValueItem1.CompareTo(x.ValueItem2)!=0 ;
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

