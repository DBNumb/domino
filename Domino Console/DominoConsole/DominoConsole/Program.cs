using System.Collections;
using System.Linq.Expressions;
using System.Threading.Channels;
using Library;

namespace DominoConsole;

public static class Program
{   public static Predicate<int> WinPredicate;
    public static Func<string, int> parser = s => Utils.TryParser(s);
    public static Action<string> Show = s => Console.WriteLine(s);
    public static Action<string> Attach = s => Console.Write(s);
    public static ITurnRule TurnRule = new ClassicTurn();
    public static IChecker<Player[]> defaultwincondition = new PlayerChecker();
    public static ITokenRule TokenRule = new DefaultTokeRule();
    public static Player[] Players;
    public static IntegerDeck defaultdeck = new IntegerDeck(TokenRule, 9);
    // public static IWin<Player[]> Player_Wincondition=checker =>PlayerChecker(checker) ;

    public static void Main(string[] args)
    {
        MenuWheel.Menu();
    }
}

static class MenuWheel
{
    public static Func<string, int> parser = s => Utils.TryParser(s);
    public static Action<string> Show = s => Console.WriteLine(s);

    public static void Menu()
    {
        Board board = new Board();
        IDeck deck = Program.defaultdeck;
        bool menuout = false;
        int numberofgames = 0;

        // Console.Clear();


        while (!menuout)
        {
            Show(
                "Elija qué variaciónes quiere adicionar al juego en caso de qué no elija alguna\nse usaran la clásica ");
            Show("1- Regla de Turnos");
            Show("2- Regla de fichas");
            Show("3- Cantidad y Tipos de jugadores");
            Show("4- Regla de ganar: ");
            Show("5-Cantidad de juegos");
            Show("- Continuar: ");
            Show("- Salir: ");
            int option = parser(Console.ReadLine());
            if (option <= 0 || option > 6) continue;
            Console.Clear();
            switch (option)
            {
                case 1:
                {
                    Program.TurnRule = Optionwheel.Turn();
                    break;
                }
                case 2:
                {
                    Program.TokenRule = Optionwheel.TokenRule();
                    deck = Optionwheel.TokenDeck(Program.TokenRule);
                    break;
                }
                case 3:
                {
                    Program.Players = Optionwheel.CreatePlayers();
                    break;
                }
                // case 4:
                // {
                //     int win = 0;
                //     Show("Defina la regla de ganar: ");
                //     Show("1-Se pegó un jugador: ");
                //     Show("2-El jugador que mayor puntuacion haya obtenido después que uno se pegó");
                //     while (win<=0)
                //     {
                //         win = parser(Console.ReadLine());
                //     }
                //
                //     switch (win)
                //     {   case 1:
                //             //NI IDEAAAAAAAAAAAAAAA
                //              break;
                //         case 2:
                //         {
                //             //;
                //             
                //             break;
                //         }
                //     }
                //     break;
                // }
                case 5:
                {
                    Show("Defina la cantidad de juegos: ");
                    while (numberofgames <= 0)
                    {
                        numberofgames = parser(Console.ReadLine());
                    }

                    break;
                }
                case 6:
                {
                    GameStart game = new GameStart(Program.Players, Program.TokenRule, Program.TurnRule, deck.deck,
                        numberofgames);
                    break;
                }
                case 7:
                {
                    menuout = true;
                    break;
                }
            }
        }
    }
}

static class Optionwheel
{
    public static ITurnRule Turn()
    {
        Console.Clear();
        Program.Show("1- Cada vez que un jugador se pase cambia el sentido.");
        Program.Show("2- Regla clásica");
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
        Program.Show("1- Sin dobles: ");
        Program.Show("2- Regla clásica");

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
        for (int i = 0; i < players.Length; i++)
        {
            int playertype = 0;
            Console.Clear();
            Console.WriteLine($"Selecione el tipo del jugador {i + 1}:");
            Console.WriteLine("1-Jugador Random: ");
            Console.WriteLine("2-Jugador Protege Data");
            Console.WriteLine("3-Jugador Bota Gorda");
            while (true)
            {
                playertype = Program.parser(Console.ReadLine());
                if (playertype <= 0 || playertype > 3)
                {
                    Console.WriteLine("Debe introducir un número válido");
                }
                else
                {
                    break;
                }
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

    #region Tokens

    public static IDeck TokenDeck(ITokenRule rule)
    {
        Program.Show("Escoja con qué fichas quiere jugar: ");
        Program.Show("1- Colores:");
        Program.Show("2- Números:");
        int option = 0;
        while (true)
        {
            option = Program.parser(Console.ReadLine());
            if (option <= 0 || option > 2)
            {
                Console.WriteLine("Debe introducir un número válido");
            }
            else
            {
                break;
            }
        }

        Console.Clear();
        switch (option)
        {
            case 1:
            {
                //IMPLEMENTAR ESTO
                break;
            }
            case 2:
            {
                option = -1;
                Program.Show("Defina el máximo de fichas: ");
                while (option < 0)
                {
                    option = Program.parser(Console.ReadLine());
                }

                return new IntegerDeck(rule, option);
            }
        }

        return Program.defaultdeck;
    }

    #endregion
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