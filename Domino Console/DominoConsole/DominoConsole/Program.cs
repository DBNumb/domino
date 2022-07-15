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

// static class PlayGame
// {
//     public static void PrintCollection(List<Token> tokens)
//     {
//         for (int i = 0; i < tokens.Count; i++)
//         {
//             tokens[i].Print(tokens[i]);
//             if (i != 0 && i % 10 == 0){ Program.Show("");Program.Show("-----------------------------------------------------------------------------------------------------------");}
//         }
//     }
//
//     public static void Start(GameComponents gameComponents)
//     {
//         gameComponents.AsignaFichasAPlayers(Optionwheel.playerstoken);
//         
//         Console.BackgroundColor = ConsoleColor.White;
//         Console.Clear();
//         bool draw = false; //falta
//         int turn = Optionwheel.CurrentPlayer;
//         int currentgame = 0;
//         while (currentgame < gameComponents.numberofgames)
//         {
//             int knocks = 0;
//             while (!Program.BreakRule.Over(gameComponents))
//             {
//                 Console.Clear();
//                 Player current = gameComponents.players[turn];
//                 Program.Show($"Le toca al jugador {turn}");
//                 Program.Show(
//                     "************************************************************************************************************++");
//                 PrintCollection(gameComponents._board.board);
//                 Program.Show("");
//                 Program.Show(
//                     "************************************************************************************************************++");
//                 Program.Show($"Mano del jugador {turn}: ");
//                 PrintCollection(current.PlayerHand);
//                 if (knocks == gameComponents.players.Length) {draw = true; break;}
//                 if (!MenuWheel.automode)
//                 {
//                     Console.ReadLine();
//                 }
//                 else
//                 {
//                     Thread.Sleep(1000);
//                 }
//
//
//                 var currentmove = current.Juega(
//                     current.PosiblesJugadas(current.PlayerHand, gameComponents._board.Boardextremes()),
//                     gameComponents._board.Boardextremes());
//                 if (currentmove != null)
//                 {
//                     knocks = 0;
//                     gameComponents._board.Insert(currentmove);
//                     turn += gameComponents.TurnRule.NxtTurn(knocks);
//                     
//                 }
//                 else
//                 {
//                     knocks++;
//                     turn += gameComponents.TurnRule.NxtTurn(knocks);
//                 }
//
//                 if (turn>=gameComponents.players.Length)
//                 {
//                     turn = 0;
//                 }
//
//                 if (turn<0)
//                 {
//                     turn = gameComponents.players.Length - 1;
//                 }
//             }
//
//             if (draw)
//             {
//                 Winner[] winners =
//                     gameComponents.DrawWinner(gameComponents.players, new int[gameComponents.players.Length]);
//                 if (winners == null)
//                 {  Log.Draw();
//                     Program.Show(Log.log.Last());
//                 }
//                 else
//                 {
//                     currentgame++;
//                     int TeamConflict=0;
//                     foreach (var winner in winners)
//                     { 
//                         if (Program.Teams == null)
//                         {
//                             Log.WinSolo(gameComponents.players[winner.player_Index],winner.player_Index);
//                             break;
//                         }
//                         else
//                         {
//                             //faltaimplementarteams
//                         }
//                     }
//                 }
//             }
//         }
//     }
// }

static class MenuWheel
{
    public static Func<string, int> parser = s => Utils.TryParser(s);
    public static Action<string> Show = s => Console.WriteLine(s);
    public static bool automode = false;

    public static void Menu()
    {
        Board board = new Board();
        IDeck deck = Program.defaultdeck;
        bool menuout = false;
        int numberofgames = 1;
        bool TokensAlreadyInitialized = false;
        // Console.Clear();


        while (!menuout)
        {
            Console.Clear();
            Show(
                "Elija qué variaciónes quiere adicionar al juego en caso de qué no elija alguna\nse usaran la clásica ");
            Show("1- Regla de Turnos");
            Show("2- Regla de fichas");
            Show("3- Cantidad y Tipos de jugadores");
            Show("4- Regla de ganar: ");
            Show("5-Cantidad de juegos");
            Show("6- Continuar: ");
            Show("7- Salir: ");
            int option = parser(Console.ReadLine());
            // if (option <= 0 || option > 6) continue;
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
                    TokensAlreadyInitialized = true;
                    break;
                }
                case 3:
                { if(TokensAlreadyInitialized)
                    Program.Players = Optionwheel.CreatePlayers();
                    else
                    {
                        Program.Show("Modifique primero las fichas");
                        Console.ReadLine();
                    }
                    break;
                }
                case 4:
                {
                    int win = 0;
                    Show("Defina la regla de ganar: ");
                    Show("1-Se pegó un jugador: ");
                    Show("2-El jugador que mayor puntuacion haya obtenido despúes de 20 jugadas");
                    while (true)
                    {
                        win = parser(Console.ReadLine());
                        if (win <= 0)
                        {
                            Show("Debe Introducir un número válido: ");
                        }
                        else
                        {
                            break;
                        }
                    }

                    switch (win)
                    {
                        case 1:
                            Program.BreakRule = new PlayerFinish();
                            break;
                        case 2:
                        {
                            Show("Defina hasta cuántas jugadas: ");

                            while (true)
                            {
                                win = parser(Console.ReadLine());
                                if (win <= 0)
                                {
                                    Show("Debe introducir un número válido");
                                }
                                else
                                {
                                    break;
                                }
                            }

                            Program.BreakRule = new PlayFinish(win);
                            break;
                        }
                    }

                    break;
                }
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
                    Show("Teclee 1 si desea jugar en modo automático");
                    string temp = Console.ReadLine();
                    if (temp == "1")
                    {
                        automode = true;
                    }

                    Program.game = new GameComponents(Program.Players, Program.TokenRule, Program.TurnRule, deck.deck,
                        numberofgames);
                    menuout = true;
                    break;
                }
                case 7:
                {
                    Program.getout = true;
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

    public static int CurrentPlayer = 0;
    public static int playerstoken = 10;
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

        Console.Clear();
        Program.Show("Defina cuántas fichas deben tener los jugadores: ");
        while (true)
        {
            option = Program.parser(Console.ReadLine());
            if (option <= 0)
            {
                Program.Show("Debe introducir una opción válida");
            }
            else if (Program.defaultdeck.deck.Count/players.Length*option<1)
            {
                Program.Show($"Hay {Program.defaultdeck.deck.Count} fichas y {players.Length}jugadores" +
                             $", la cantidad máxima asignable es {Program.defaultdeck.deck.Count/players.Length}");
            }
            else
            {playerstoken = option;
                foreach (var VARIABLE in players)
                {
                    
                    VARIABLE.PlayerHand = new List<Token>();
                }
                break;
            }
        }

        foreach (var VARIABLE in players)
        {
            VARIABLE.PlayerHand = new List<Token>(option);
        }

        Program.Show($"Qué jugador debería empezar, hay un total de {players.Length} jugadores: ");
        while (true)
        {
            option = Program.parser(Console.ReadLine());
            if (option <= 0 || option > players.Length)
            {
                Console.WriteLine("Introduzca un número válido");
            }
            else
            {
                CurrentPlayer = option-1;
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
        Program.Show("3-Clásico doble nueve: ");
        int option = 0;
        while (true)
        {
            option = Program.parser(Console.ReadLine());
            if (option <= 0 || option > 3)
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
                option = -1;
                Program.Show("Defina el máximo de fichas hasta 12 ");
                while (option < 0 || option > 12)
                {
                    option = Program.parser(Console.ReadLine());
                }

                return new ColorsDeck(rule, option);
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