namespace Library;

public interface ITokenRule
{
    public Ifilter<Token> Check();
    
}