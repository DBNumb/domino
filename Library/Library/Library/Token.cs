namespace Library;

public class Token
{
    public int value1, value2;
    public int score;
    public Token(int value1, int value2)
    {
        this.value1 = value1;
        this.value2 = value2;
        this.score = value1 + value2;
    }
}