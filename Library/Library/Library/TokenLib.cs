using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Library;

public  abstract class Face : IFace
{

    public abstract int GetPuntuation();
  
    public bool CanbeMatch(IFace other)
    {
        if (CanBeCompare(other))
        {
            return this.Compare(other)==0;
        }

        return false;
    }

    public abstract override string ToString();

    public bool CanBeCompare(object other)
    {
        return this.GetType() == other.GetType() ;
    }

    public abstract int Compare(object other);
}

public class Token
{
    public IFace FaceA { get; }
    public IFace FaceB { get; }
    public int Score { get; private set; }
    public Token(IFace a, IFace b)
    {
        FaceA = a;
        FaceB = b;
    }

    public  virtual void Print(Token p)
    {
        Console.Write($"[ {p.FaceA} | {p.FaceB} ]" );
    }
    public void Getscore(Func<int, int, int> TokenScore)
    {
        Score= TokenScore(FaceA.GetPuntuation(), FaceB.GetPuntuation());
    }
    public  string Description(Token token) 
    {
        return token.FaceA.ToString() + "|" + token.FaceB.ToString();
    }
}


#region Tokenrule

public class NoDoubleRule : ITokenRule
{
    public bool Apply(Token x)
    {
        return x.FaceA.Compare(x.FaceB)!=0 ;
    }
}

public class DefaultTokeRule : ITokenRule
{
    public bool Apply(Token x)
    {
        return true;
    }
}

#endregion

