namespace DominoConsole;
using Library;
public class ColorToken : Token
{
    public Color _faceA;
    public Color _faceB;
    public ColorToken(Color a, Color b) : base(a, b)
    {
        
        _faceA = a;
        _faceB = b;
        Getscore();
    }

    

    public override void Print()

    {
        Console.ForegroundColor = ConsoleColor.Black;
        if (this.FaceA.CanbeMatch(this.FaceB))
        { 
            Console.Write("[[");
            SwitchColorPrint(this.FaceA.ToString());
            Console.Write("]]");
        }
        else
        {
            Console.Write("|");

            SwitchColorPrint(this.FaceA.ToString());
           
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("|");
            
            SwitchColorPrint(this.FaceB.ToString());
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("|");
        }
    }

    public void SwitchColorPrint(string Face)
    {
        switch (Face)
        {
           case "negro":
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($" ");
                    break;
                }
            case "azul":
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write($" ");
                    break;
                }
            case "verde":
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write($" ");
                    break;
                }
            case "lima":
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write($" ");
                    break;
                }
            case "gris":
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write($" ");
                    break;
                }
            case "purpura":
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.Write($" ");
                    break;
                }
            case "marron":
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write($" ");
                    break;
                }
            case "rojo":
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write($" ");
                    break;
                }
            case "magenta":
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Write($" ");
                    break;
                }
            case "naranja":
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write($" ");
                    break;
                }
            case "amarillo":
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write($" ");
                    break;
                }
            case "blanco":
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write($" ");
                    break;
                }
            default:
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($" ");
                    break;
                }
        }

        Console.BackgroundColor = ConsoleColor.White;
    }
}

public class Color : Face
{
    public string colorName;
    int colorRed;
    int colorGreen;
    int colorBlue;
    public int decimalCode;
    public Tuple<Tuple<int, int>, int> RGBColorCode;
    public Color(string colorName, int colorRed, int colorGreen, int colorBlue, int decimalCode)
    {
        this.colorName = colorName;
        this.colorRed = colorRed;
        this.colorGreen = colorGreen;
        this.colorBlue = colorBlue;
        this.decimalCode = decimalCode;
        this.RGBColorCode = new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(colorRed, colorGreen), colorBlue);
    }

    public override int GetPuntuation()
    {
        return this.decimalCode;
    }
    public override int Compare(Object other)
    {
        if (this.decimalCode < ((Color)other).decimalCode) return -1;
        else if (this.decimalCode == ((Color)other).decimalCode) return 0;
        return 1;
    }

    public override string ToString()
    {
        return this.colorName;
       
    }

    /*Algunos Colores con su codigo RGB, hexadecimal y decimal
    color x           (R, G, B )       , hex, Dec
    color negro       (0, 0, 0)        , 000000, 0
    color azul        (0, 0, 255)      , 0000FF, 255 
    color verde       (0, 128, 0)      , 008000, 32768 
    color verde lima  (0, 255, 0)      , 00FF00, 65280  
    color azul aqua   (0, 255, 255)    , 00FFFF, 65535 
    color gris        (112, 128, 144)  , 708090, 7372944 
    color Purpura     (128, 0, 128)    , 800080, 8388736 
    color Marron      (165, 42, 42)    , A52A2A, 10824234 
    color rojo        (255, 0, 0)      , FF0000, 16711680 
    color Magenta     (255, 0, 255)    , FF00FF, 16711935 
    color naranja     (255, 165, 0)    , FFA500, 16753920 
    color amarillo    (255, 255, 0)    , FFFF00, 16776960 
    color blanco      (255, 255, 255)  , FFFFFF, 16777215 
    */
    //los codigos rgb no pueden ser menores de 0 ni mayores de 255

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
        Array.Copy(colors, colorsSelected, max);
        
        for (int i = 0; i < max; i++)
        {
            for (int j = i; j < max; j++)
            {
                Token aux = new ColorToken(colorsSelected[i], colorsSelected[j]);
                if (rule.Apply(aux))
                    deck.Add(aux);
            }
        }
    }

}