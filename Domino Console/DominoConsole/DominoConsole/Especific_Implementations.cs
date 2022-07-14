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
public class ColorsDeck : IDeck
{
    public List<Token> deck { get; }
    /* para ver mas buscar la clase Color en la que hay una lista con algunos mas
     cada color tiene un codigo decimal, por ahi sera el criterio de comparacion */

    Color[] colors = 
    {
        new Color("negro"   , 0  , 0  , 0  , 0),
        new Color("azul"    , 0  , 0  , 255, 255),
        new Color("verde"   , 0  , 128, 0  , 32768),
        new Color("lima"    , 0  , 255, 0  , 65280),
        new Color("gris"    , 112, 128, 144, 7372944),
        new Color("purpura" , 128, 0  , 128, 8388736),
        new Color("marron"  , 165, 42 , 42 , 10824234),
        new Color("rojo"    , 255, 0  , 0  , 16711680),
        new Color("magenta" , 255, 0  , 255, 16711935),
        new Color("naranja" , 255, 165, 0  , 16753920),
        new Color("amarillo", 255, 255, 0  , 16776960),
        new Color("blanco"  , 255, 255, 255, 16777215)
    };

    public ColorsDeck(ITokenRule rule, int max)
    {
        deck = new List<Token>();
        GenerateDeck(rule, max);
    }

    private void GenerateDeck(ITokenRule rule, int max)
    {
        Color[] colorsSelected = new Color[max];
        Array.Copy(colors, colorsSelected, max);//estara bien asi???
        
        for (int i = 0; i <= max; i++)
        {
            for (int j = i; j <= max; j++)
            {
                Token aux = new Token(colorsSelected[i], colorsSelected[j]);
                if (rule.Apply(aux))
                    deck.Add(aux);
            }
        }
    }

}