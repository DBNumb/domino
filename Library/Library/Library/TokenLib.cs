using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Library;


public class Token<T> : IToken<T> where T : IComparable, IValuable
{
    public T this[int index] => values[index];

    public List<T> values { get; }


    public void Getvalues(ICollection<T> coll)
    {
        foreach (var elem in coll)
        {
            values.Add(elem);
        }
    }

    public int score { get; }

    public int GetScore(ICollection<T>coll)
    {
        int result = 0;
        foreach (var VARIABLE in coll)
        {
            result += VARIABLE.value;
        }

        return result;
    }

    public Token(ICollection<T> coll)
    {
        Getvalues(coll);
        var score = GetScore(coll);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new TokenEnumerator<T>(values);
    }
   private class TokenEnumerator<T>: IEnumerator<T>
   {
       private int pos = -1; 
       private List<T> values;
       public TokenEnumerator(List<T> comparables)
       {
           values = comparables;
       }
       public void Reset()
       {
           pos = -1;
       }

       object IEnumerator.Current => Current;

       public T Current { get; }

       public bool MoveNext()
       {
           pos++;
           if (pos >= 0 || pos < values.Count) return true;
           return false;
       }
       

       public void Dispose()
       {
           throw new NotImplementedException();
       }
   }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
#region Tokenrule

public class NoDoubleRule<T> : ITokenRule<T> where T: IToken<T>, IValuable
{
    public bool Apply(T x)
    {
        int first = x[0].score;
        foreach (var ob in x)
        {
            foreach (var val in ob)
            {
                if (val.value != first) return false;
            }
        }

        return true;
    }
}

public class DefaultTokeRule<T> : ITokenRule<T> where T: IToken<T>, IValuable
{
    public bool Apply(T x)
    {
        return true;
    }
}

#endregion