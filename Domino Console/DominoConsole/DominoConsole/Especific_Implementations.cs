using Library;

namespace DominoConsole;

public  static class Especific_Implementations
{
    
}

public interface IDeck
{
    public Token[] deck { get; }
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
            return value.CompareTo(((IntegerFace)other).value);
        }

        throw new Exception("Las Caras no se pueden Comparar");
    }

    public IntegerFace(int value)
    {
        this.value = value;
    }
}

public class IntegerToken
{
    
}