using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Library;

public  abstract class Face : IFace
{

    public abstract int GetPuntuation();
  
    public bool CanbeMatch(IFace other)
    {
        if (CanBeCompare(other))
        {
            return this.Compare(other)==0;
        }

        return false;
    }

    

    public bool CanBeCompare(object other)
    {
        return this.GetType() == other.GetType() ;
    }

    public abstract int Compare(object other);
}

public class Token
{
    public IFace FaceA { get; }
    public IFace FaceB { get; }
    public int Score { get; private set; }
    public Token(IFace a, IFace b)
    {
        FaceA = a;
        FaceB = b;
    }

    public void Getscore(Func<int, int, int> TokenScore)
    {
        Score= TokenScore(FaceA.GetPuntuation(), FaceB.GetPuntuation());
    }
}

public class Color: Face
{
    //he de imaginar que hay q acomodar esto en otro sitio pero mientras tanto que se quede aca
   
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
#region Tokenrule

public class NoDoubleRule : ITokenRule
{
    public bool Apply(Token x)
    {
        return x.FaceA.Compare(x.FaceB)!=0 ;
    }
}

public class DefaultTokeRule : ITokenRule
{
    public bool Apply(Token x)
    {
        return true;
    }
}

#endregion

