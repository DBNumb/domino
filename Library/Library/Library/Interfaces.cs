namespace Library;

public interface Ifilter<T>
{
    public bool Apply(T x);
}
interface IFilterFichas
{
    public Token[] posiblesjugadas { get; set; }
    public bool Apply(Token[] fichasPlayer, Tuple<int, int> Estado_tablero);
    //hay q abstraernos mas pq esto solo funciona para domino
}