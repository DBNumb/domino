namespace Library;

public class TrialToken<T> where T: IValuable
{
    public int[] values { get; }

    public TrialToken(T x)
    {
        values = x.values;
    }
}

