namespace DominoConsole;
using Library;
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
