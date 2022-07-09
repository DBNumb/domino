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

    public void Getscore(Func<int, int, int> TokenScore)
    {
        Score= TokenScore(FaceA.GetPuntuation(), FaceB.GetPuntuation());
    }
}
// public class TokenComparer : IComparer<Face>
// {
//     public int Compare(Face? x, Face? y)
//     {
//         int count = 0;
//         bool[] used = new bool[2];
//         for (int i = 0; i < used.Length; i++)
//         {
//             for (int j = 0; j < used.Length ; j++)
//             {
//                 if (!used[j]&& x[i].CompareTo(y[j])==0)
//                 {
//                     count++;
//                     used[j] = true;
//                 }
//             }
//         }
//
//         if (count == 0) return -1;
//         if (count == 1)
//         {
//             for (int i = 0; i < used.Length; i++)
//             {
//                 if (used[i]) return i;
//             }
//         }
//
//         return 2;
//     }
// }
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

