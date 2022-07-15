namespace DominoConsole;
using Library;

static class PlayGame
{
    public static void PrintCollection(List<Token> tokens) 
    {
        for (int i = 0; i < tokens.Count; i++)
        {
            tokens[i].Print(tokens[i]);
            if (i != 0 && i % 10 == 0){ Program.Show("");Program.Show("-----------------------------------------------------------------------------------------------------------");}
        }
    }

    public static void Start(GameComponents gameComponents)
    {
        gameComponents.AsignaFichasAPlayers(Optionwheel.playerstoken);
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        bool draw = false; //falta
        int turn = Optionwheel.CurrentPlayer;
        int currentgame = 0;
        while (currentgame < gameComponents.numberofgames)
        {
            int knocks = 0;
            while (!Program.BreakRule.Over(gameComponents))
            {
                Console.Clear();
                Player current = gameComponents.players[turn];
                Console.ForegroundColor = ConsoleColor.Black;
                Program.Show($"Le toca al jugador {turn}");
                Program.Show(
                    "************************************************************************************************************++");
               if(gameComponents._board.board.Count!=0)
                PrintCollection(gameComponents._board.board);
               Console.ForegroundColor = ConsoleColor.Black;
               Program.Show("");
                Program.Show(
                    "************************************************************************************************************++");
                Program.Show($"Mano del jugador {turn}: ");
                PrintCollection(current.PlayerHand);
                
                if (knocks == gameComponents.players.Length) {draw = true; break;}
                if (!MenuWheel.automode)
                {
                    Console.ReadLine();
                }
                else
                {
                    Thread.Sleep(1000);
                }


                var currentmove = current.Juega(
                    current.PosiblesJugadas(current.PlayerHand, gameComponents._board.Boardextremes()),
                    gameComponents._board.Boardextremes());
                if (currentmove != null)
                {
                    knocks = 0;
                    gameComponents._board.Insert(currentmove);
                    turn += gameComponents.TurnRule.NxtTurn(knocks);
                    
                }
                else
                {
                    knocks++;
                    turn += gameComponents.TurnRule.NxtTurn(knocks);
                }

                if (turn>=gameComponents.players.Length)
                {
                    turn = 0;
                }

                if (turn<0)
                {
                    turn = gameComponents.players.Length - 1;
                }
            }

            if (draw)
            {
                Winner[] winners =
                    gameComponents.DrawWinner(gameComponents.players, new int[gameComponents.players.Length]);
                if (winners == null)
                {  Log.Draw();
                    Program.Show(Log.log.Last());
                    Console.ReadLine();
                }
                else
                {
                    currentgame++;
                    int TeamConflict=0;
                    foreach (var winner in winners)
                    { 
                        if (Program.Teams == null)
                        {
                            Log.WinSolo(gameComponents.players[winner.player_Index],winner.player_Index);
                            Program.Show(Log.Winlog.Last());
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            //faltaimplementarteams
                        }
                    }
                }
            }
        }
    }
}
