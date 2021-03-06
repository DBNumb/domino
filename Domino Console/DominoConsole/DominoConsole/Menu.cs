namespace DominoConsole;

using Library;

static class MenuWheel
{
    public static ITurnRule TurnRule = new ClassicTurn();
    public static ITokenRule TokenRule = new DefaultTokeRule();
    public static Player[] Players;
    public static IDeck defaultdeck = new IntegerDeck(TokenRule, 9);
    public static Team[] Teams;
    public static IGameBreak BreakRule = new PlayerFinish();
    public static IReglaDeSelección _reglaDeSelección;
    public static Func<string, int> parser = s => Utils.TryParser(s);
    public static Action<string> Show = s => Console.WriteLine(s);
    public static bool automode;
    public static IDeck deck;
    public static bool Players_Initialized = false;
    public static IWinnersRule winnersRule;
    public static void Menu()
    {
        bool winruleassigned = false;
        Board board = new Board();
        // deck = defaultdeck;
        bool menuout = false;
        int numberofgames = 1;
        bool tokensAlreadyInitialized = false;
        // Console.Clear();

        bool selectrule = false;
        while (!menuout)
        {
            Console.Clear();
            Show(
                "Elija qué variaciónes quiere adicionar al juego en caso de qué no elija alguna\nse usaran la clásica ");
            Show("1- Regla de Turnos");
            Show("2- Regla de fichas");
            Show("3- Cantidad y Tipos de jugadores");
            Show("4- Regla de finalización del juego: ");
            Show("5-Cantidad de juegos");
            Show("6-Regla de selección");
            Show("7-Regla de ganadores");
            Show("8- Continuar: ");
            Show("9- Salir: ");
            int option = parser(Console.ReadLine());
            if (option <= 0 || option >9) continue;
            Console.Clear();
            switch (option)
            {
                case 1:
                {
                    TurnRule = Optionwheel.Turn();
                    break;
                }
                case 2:
                {
                    TokenRule = Optionwheel.TokenRule();
                    deck = Optionwheel.TokenDeck(TokenRule);
                    tokensAlreadyInitialized = true;
                    break;
                }
                case 3:
                {
                    if (tokensAlreadyInitialized)
                        Players = Optionwheel.CreatePlayers();
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
                    Show("2-El jugador que mayor puntuacion haya obtenido despúes de n jugadas");
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
                            BreakRule = new PlayerFinish();
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

                            BreakRule = new PlayFinish(win);
                            break;
                        }
                    }

                    break;
                }
                case 5:
                {
                    Show("Defina la cantidad de juegos: ");
                    do
                    {
                        numberofgames = parser(Console.ReadLine());
                    } while (numberofgames <= 0);


                    break;
                }
                case 6:
                {
                    Console.Clear();
                    if (!Players_Initialized)
                    {
                        Show("Debe inicializar los jugadores: ");
                        Console.ReadLine();
                        break;
                    }

                    Show("Regla de Selección de fichas: ");
                    Show("1-Clásica los jugadores solamente escogen ");
                    Show("2-Con posibilidad de reseleccionar n fichas: ");
                    do
                    {
                        option = parser(Console.ReadLine());
                    } while (option > 2 || option < 1);

                    switch (option)
                    {
                        case 1:
                            _reglaDeSelección = new AsignaFichaPlayers();
                            break;
                        case 2:
                            Console.Clear();
                            Show($"Seleccione cuántas fichas puede cambiar el jugador." +
                                 $"\n Recuerde los jugadores tienen {Optionwheel.playerstoken}: ");
                            do
                            {
                                option = parser(Console.ReadLine());
                            } while (option<0|| option>Optionwheel.playerstoken);

                            _reglaDeSelección = new ReseleccionarAsignacion(option);
                            break;
                    }

                    selectrule = true;
                    break;
                }
                case 7:
                {
                    Show("Defina la regla de ganadores: ");

                    Show(
                        "1-Clásico gana el jugador q se pegue primero en caso de que no puedan seguir jugando empate: ");
                    Show("2-Gana el jugador que mayor puntuación tenga en caso " +
                         "\n de que existan dos si no están en el mismo equipo es empate: ");
                    do
                    {
                        option = parser(Console.ReadLine());
                    } while (option<=0||option>2);

                    switch (option)
                    {
                        case 1:
                        {
                            winnersRule = new EmptyHandWinner();
                            break;
                        }
                        case 2:
                        {
                            winnersRule = new ScorePlayerWinner();
                            break;
                        }
                    }

                    winruleassigned = true;
                    break;
                }
                case 8:
                {
                    if (tokensAlreadyInitialized && Players_Initialized)
                    {
                        Show("Teclee 1 si desea jugar en modo automático");
                        string temp = Console.ReadLine();
                        if (temp == "1")
                        {
                            automode = true;
                        }
                        if(!winruleassigned) winnersRule= new EmptyHandWinner();
                        if (!selectrule)
                            _reglaDeSelección = new AsignaFichaPlayers();
                        Program.game = new GameComponents(Players, TokenRule, TurnRule,
                            deck.deck,
                            numberofgames, _reglaDeSelección,winnersRule);

                        menuout = true;
                    }
                    else
                    {
                        Console.Clear();
                        Show("Debe Inicializar los jugadores y las fichas\n" +
                             "presione cualquier tecla para continuar");
                        Console.ReadLine();
                    }

                    break;
                }
                case 9:
                {
                    Program.getout = true;
                    menuout = true;
                    break;
                }
            }
        }
    }
}