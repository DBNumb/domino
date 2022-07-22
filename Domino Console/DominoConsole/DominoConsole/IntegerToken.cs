using Library;

namespace DominoConsole;







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

    public override string ToString()
    {
        
        return value.ToString();//revisar...
    }

    public IntegerFace(int value)
    {
        this.value = value;
    }
}

public class IntegerToken : Token
{
    public IntegerFace _faceA;
    public IntegerFace _faceB;
    public IntegerToken(IntegerFace a, IntegerFace b) : base(a, b)
    {  Getscore();
        _faceA = a;
        _faceB = b;
        Getscore();
    }

    public override void Print()
    { 
        Console.ForegroundColor = ConsoleColor.Green;
        if (this.FaceA.CanbeMatch(this.FaceB))
        {
            Console.Write("[[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($" {this.FaceA} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]]");
        }
        else
        {
            Console.Write("[ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{this.FaceA} ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{this.FaceB} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("]");
        }
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
                IntegerToken aux = new IntegerToken(new IntegerFace(i), new IntegerFace(j));
                if (rule.Apply(aux))
                    deck.Add(aux);
            }
        }
    }
}

