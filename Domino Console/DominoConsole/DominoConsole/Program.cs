using System.Linq.Expressions;
using System.Threading.Channels;
using Library;

namespace DominoConsole;

public static class Program
{
    public static Func<string, int> parser = s => Utils.TryParser(s);
    public static Action<string> Attach = s => Console.Write(s);
    public static Action<string> Show = s => Console.WriteLine(s);
    public static ITurnRule TurnRule = new ClassicTurn();
    public static IChecker<Player[]> wincondition = new PlayerChecker();
    public static ITokenRule TokenRule = new DefaultTokeRule();
    public static Player[] Players;
    
    public static void Main(string[] args)
    {
        IDeck deck;
        bool menuout = false;
        Show("Escoja con qué fichas quiere jugar: ");
        Show("1- Colores:");
        Show("2- Números:");
        int Tokenoption = 0;
        while (Tokenoption<=0|| Tokenoption>2)
        {
            Tokenoption = parser(Console.ReadLine());
            
        }
        
        Console.Clear();
        Show(
            "Elija qué variaciónes quiere adicionar al juego en caso de qué no elija alguna\nse usaran la clásica ");
        Show("1- Regla de Turnos");
        Show("2- Regla de fichas");
        Show("3- Cantidad y Tipos de jugadores");
        Show("4- Regla de ganar: ");
        Show("5- Continuar: ");
        Show("6- Salir: ");

        while (!menuout)
        {
            int option = parser(Console.ReadLine());
            if (option <= 0 || option > 6) continue;
            Console.Clear();
            switch (option)
            {
                case 1:
                    TurnRule = Optionwheel.Turn();
                    break;
                case 2:
                {
                    
                    break;
                }
                case 3:
                    Players = Optionwheel.CreatePlayers();
                    break;
            }
        }
    }
}

static class Optionwheel
{
    public static ITurnRule Turn()
    {
        Console.WriteLine("1- Cada vez que un jugador se pase cambia el sentido.");
        Console.WriteLine("2- Regla clásica");
        int option = 0;
        while (option <= 0 || option > 2)
        {
            option = Program.parser(Console.ReadLine());
        }

        switch (option)
        {
            case 1: return new ClockTurn();
            default: return new ClassicTurn();
        }
    }

    public static ITokenRule TokenRule()
    {
        int option = 0;
        Console.WriteLine("1- Sin dobles: ");
        Console.WriteLine("2- Regla clásica");

        while (option <= 0 || option > 2)
        {
            option = Program.parser(Console.ReadLine());
        }

        switch (option)
        {
            case 1: return new NoDoubleRule();
            default: return new DefaultTokeRule();
        }
    }

    public static Player[] CreatePlayers()
    {
        Console.WriteLine("Diga la cantidad de jugadores: ");
        int option = 0;
        while (option <= 0)
        {
            option = Program.parser(Console.ReadLine());
        }

        Player[] players = new Player[option];
        for (int i = 1; i <= option; i++)
        {
            int playertype = 0;
            Console.Clear();
            Console.WriteLine($"Selecione el tipo del jugador {i}:");
            Console.WriteLine("1-Jugador Random: ");
            Console.WriteLine("2-Jugador Protege Data");
            Console.WriteLine("3-Jugador Bota Gorda");
            while (playertype <= 0 || playertype > 3)
            {
                playertype = Program.parser(Console.ReadLine());
            }

            switch (playertype)
            {
                case 1:
                    players[i] = new PlayerRandom();
                    break;
                case 2:
                    players[i] = new PlayerPD();
                    break;
                default:
                    players[i] = new PlayerBG();
                    break;
            }
        }

        return players;
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
                option = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Debe introducir un número válido");
            }
        }

        return option;
    }
}