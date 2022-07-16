using System.Data.Common;
using Library;

namespace DominoConsole;

public static class Program
{
    public static GameComponents game;
    public static Func<string, int> parser = s => Utils.TryParser(s);
    
    public static Action<string> Show = s => Console.WriteLine(s);
    public static bool getout = false;
    

    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        MenuWheel.Menu();
        while (!getout)
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