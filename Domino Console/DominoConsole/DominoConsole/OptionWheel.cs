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
    public static Team[] CreateTeamsUser(Player[] player, int numeroDeEquipos) 
    {
        Team[] teams = new Team[numeroDeEquipos];
        for (int i = 0; i< player.Length; i++) 
        {
            Program.Show("Diga en que equipo quiere poner al jugador " + i+1);
            int indiceEquipo = Program.parser(Console.ReadLine());
            while (indiceEquipo < 0 || indiceEquipo > numeroDeEquipos) 
            {
                indiceEquipo = Program.parser(Console.ReadLine());
            }
            AsignaPlayerAEquipo(i, teams, indiceEquipo);
        }
        return teams;
    }
    public static void AsignaPlayerAEquipo(int playerIndice, Team[] teams, int indice)
    {
        teams[indice].TeamMembers.Add(playerIndice);
    }
    public static Player[] CreatePlayers()
    {
        
        int option = 0;
        while (option <= 0|| option> MenuWheel.deck.deck.Count)
        {Console.WriteLine("Diga la cantidad de jugadores: ");
            option = Program.parser(Console.ReadLine());
            Console.Clear();
        }

        MenuWheel.Players_Initialized = true;
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
        
        while (true)
        {  Program.Show("Defina cuántas fichas deben tener los jugadores: ");
            option = Program.parser(Console.ReadLine());
            if (option <= 0)
            {Console.Clear();
                Program.Show("Debe introducir una opción válida");
            }
            else if (MenuWheel.deck.deck.Count/(players.Length*option)<1)
            {
                Program.Show($"Hay {MenuWheel.deck.deck.Count} fichas y {players.Length} jugadores" +
                             $", la cantidad máxima asignable es {MenuWheel.deck.deck.Count/players.Length}" +
                             $"\n presione enter para continuar");
                Console.ReadLine();
                Console.Clear();
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
        Program.Show("Quiere Jugar con equipos? Marque 1 para confirmar");
        option = Program.parser(Console.ReadLine());
        Console.Clear();
        if (option == 1) 
        {
            Console.Clear();
            Program.Show("Escoja una de las siguientes opciones");
            Program.Show("1- Generar los equipos automaticamente");
            Program.Show("2- Usted genera los equipos");
            Program.Show("0- Atrás");
            
            
            option = Program.parser(Console.ReadLine());

            while (option < 0 || option > 2) 
            {
               option = Program.parser(Console.ReadLine());         
            }
            switch (option) 
            {
                case 1: 
                    {
                        Team[] teams = CreateTeamsAuto(players);
                        break; 
                    }
                case 2: 
                    {
                        Program.Show("Diga la cantidad de equipos que quiere construir");
                        int cantEquipos = Program.parser(Console.ReadLine());
                        while (cantEquipos < 0 || cantEquipos > players.Length) 
                        {
                            cantEquipos = Program.parser(Console.ReadLine());
                        }
                        Team[] teams = CreateTeamsUser(players, cantEquipos);
                        break; 
                    }
                case 0:break;
                
                default: 
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

        return MenuWheel.defaultdeck;
    }

    #endregion
}