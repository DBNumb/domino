using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Library;

public class Token : IToken
{
    public Token(ICollection<IValuable> collection)
    {
        score = GetScore(collection);
        Getvalues(collection);
    }

    //
    //  public List<Token> values { get; }
    //
    //
    //  public void Getvalues(ICollection<Token> coll)
    //  {
    //      foreach (var elem in coll)
    //      {
    //          values.Add(elem);
    //      }
    //  }
    //
    //  public int score { get; }
    //
    //  public int GetScore(ICollection<T>coll)
    //  {
    //      int result = 0;
    //      foreach (var VARIABLE in coll)
    //      {
    //          result += VARIABLE.value;
    //      }
    //
    //      return result;
    //  }
    //
    //  public Token(ICollection<T> coll)
    //  {
    //      Getvalues(coll);
    //      var score = GetScore(coll);
    //  }
    //
    //  public IEnumerator<T> GetEnumerator()
    //  {
    //      return new TokenEnumerator<T>(values);
    //  }
    public virtual string Description()
    {
        string result = "[ ";
        for (int i = 0; i < _valuables.Count; i++)
        {
            if (i == 0)
            {
                result += _valuables[i].description;
                continue;
            }

            result += ", "+_valuables[i].description;
        }

        return result + " ]";
    }

    private class TokenEnumerator<T> : IEnumerator<T>
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

    public IEnumerator<IValuable> GetEnumerator()
    {
        return new TokenEnumerator<IValuable>(_valuables);
    }


    public int this[int index] => _valuables[index].value;

    public List<IValuable> _valuables { get; }

    public void Getvalues(ICollection<IValuable> coll)
    {
        foreach (var element in coll)
        {
            _valuables.Add(element);
        }
    }

    public int score { get; }

    public int GetScore(ICollection<IValuable> collection)
    {
        int result = 0;
        foreach (var element in collection)
        {
            result += element.value;
        }

        return result;
    }
}

#region Tokenrule

public class NoDoubleRule : ITokenRule
{
    public bool Apply(IToken x)
    {
        int first = x._valuables[0].value;
        foreach (var element in x._valuables)
        {
            foreach (var element2 in x._valuables)
            {
                if (element2.value != first) return false;
            }
        }

        return true;
    }
}

public class DefaultTokeRule<T> : ITokenRule
{
    public bool Apply(IToken x)
    {
        return true;
    }
}

#endregion