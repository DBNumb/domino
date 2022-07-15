namespace DominoConsole;
using Library;
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

    public static Team[] CreateTeamsAuto(Player[] players) 
    {
       
        Team[] teams = new Team[players.Length/2];
        for (int i = 0, k = players.Length/2; i < players.Length / 2; i++, k++) 
        {
            teams[i].TeamMembers.Add(i);
            teams[i].TeamMembers.Add(k);
        }

        return teams;
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