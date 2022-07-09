using Library;

namespace DominoConsole;

public static class Especific_Implementations
{
}

public interface IDeck
{
    public List<Token> deck { get; }
}

public class IntegerFace : Face
{
    public readonly int value;

    public override int GetPuntuation()
    {
        return this.value;
    }

    public override int Compare(object other)
    {
        if (CanBeCompare(other))
        {
            return value.CompareTo(((IntegerFace) other).value);
        }

        throw new Exception("Las Caras no se pueden Comparar");
    }

    public IntegerFace(int value)
    {
        this.value = value;
    }
}

public class IntegerDeck: IDeck
{
    public List<Token> deck { get; }

    public IntegerDeck(ITokenRule rule, int max)
    {
        deck = new List<Token>();
        GenerateDeck(rule, max);
    }

    private void GenerateDeck(ITokenRule rule, int max)
    {
        for (int i = 0; i <= max; i++)
        {
            for (int j = i; j <= max; j++)
            {
                Token aux = new Token(new IntegerFace(i), new IntegerFace(j));
                if (rule.Apply(aux))
                    deck.Add(aux);
            }
        }
    }
}