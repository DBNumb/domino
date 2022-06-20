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
            if (index == 1) return this.item1;
            else
            {
                return this.item2;
            }
        }
        
    }
    public int item1 { get; }
    public int item2 { get; }
    public Token(IValuable value1, IValuable value2)
    {
        this.item1 = value1.value;
        this.item2 = value2.value;
        score = value1.value + value2.value;

    }
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


    

    public List<IValuable> _valuables { get; }

    public void Getvalues(ICollection<IValuable> coll)
    {
        foreach (var element in coll)
        {
            _valuables.Add(element);
        }
    }

    public int score { get; }
    
}
public class TokenComparer: IComparer<Token>{
    public int Compare(Token? x, Token? y)
    {
        int count = -1;
        bool[] used = new bool[2];
        for (int i = 0; i < used.Length; i++)
        {
            for (int j = 0; j < used.Length; j++)
            {
                if (x[i] == y[j]&& !used[j])
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
        int first = x.item1;
        foreach (var element in x)
        {
            foreach (var element2 in x)
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