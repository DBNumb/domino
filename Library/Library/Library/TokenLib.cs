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

public class BoardToken : Token
{
    public BoardToken(IFace a, IFace b) : base(a, b)
    {
        
    }

    public override void Print()
    {
        
    }
}

public abstract class Token
{
    public IFace FaceA { get; internal set; }
    public IFace FaceB { get; internal set; }
    public  int Score { get;  set; }
    public Token(IFace a, IFace b)
    {
        FaceA = a;
        FaceB = b;
    }

    public abstract void Print();
    
    public void Getscore()
    {
        Score= FaceA.GetPuntuation()+ FaceB.GetPuntuation();
    }
    public  string Description(Token token) 
    {
        return "[" + token.FaceA.ToString() + "|" + token.FaceB.ToString() + "]";
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

