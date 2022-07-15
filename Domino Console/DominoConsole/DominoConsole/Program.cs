using System.Data.Common;
using Library;

namespace DominoConsole;

public static class Program
{
    public static Predicate<int> WinPredicate;
    public static Func<string, int> parser = s => Utils.TryParser(s);
    public static Action<string> Show = s => Console.WriteLine(s);
    public static Action<string> Attach = s => Console.Write(s);
    public static ITurnRule TurnRule = new ClassicTurn();
    public static ITokenRule TokenRule = new DefaultTokeRule();
    public static Player[] Players;
    public static IDeck defaultdeck = new IntegerDeck(TokenRule, 9);
    public static Team[] Teams;
    public static bool getout = false;
    public static GameComponents game;
    public static IGameBreak BreakRule = new PlayerFinish();


    public static void Main(string[] args)
    {
        MenuWheel.Menu();
        if (getout)
        {
        }
        else
        {
            PlayGame.Start(game);
        }
    }
}
static class Utils
{
    public static int TryParser(string s)
    {
        int option = 0;
        while (true)
        {
            try
            {
                option = Convert.ToInt32(s);
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Debe introducir un número válido: ");
            }

            break;
        }

        return option;
    }
}