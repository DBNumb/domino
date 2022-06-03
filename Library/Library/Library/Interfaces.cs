namespace Library;

public interface Ifilter<T>
{
    public bool Apply(T x);
}