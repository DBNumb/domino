namespace DominoConsole;

using Library;

static class PlayGame
{
    //Método q se encarga de imprimir
    public static void PrintCollection(List<Token> tokens)
    {
        for (int i = 0; i < tokens.Count; i++)
        {
            tokens[i].Print();
            if (i != 0 && i % 10 == 0)
            {
                Program.Show("");
                Program.Show(
                    "-----------------------------------------------------------------------------------------------------------");
            }
        }
    }

    public static void Start(GameComponents gameComponents)
    {
        List<Winner> TotalWinners = new List<Winner>();
        IGameBreak winrule = MenuWheel.BreakRule;

        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        int turn = Optionwheel.CurrentPlayer;
        int currentgame = 0;
        while (currentgame < gameComponents.numberofgames)
        {
            winrule.draw = false;
            gameComponents.AsignaFichasAPlayers(Optionwheel.playerstoken);
            gameComponents._board = new Board();
            int knocks = 0;
            while (!winrule.Over(gameComponents))
            {
                if (turn >= gameComponents.players.Length)
                {
                    turn = 0;
                }

                if (turn < 0)
                {
                    turn = gameComponents.players.Length - 1;
                }
                Console.Clear();
                Player current = gameComponents.players[turn];
                Console.ForegroundColor = ConsoleColor.Black;
                Program.Show($"Le toca al jugador {turn + 1}");
                Program.Show(
                    "******************************************************************************************************************");
                if (gameComponents._board.board.Count != 0)
                    PrintCollection(gameComponents._board.board);
                Console.ForegroundColor = ConsoleColor.Black;
                Program.Show("");
                Program.Show(
                    "******************************************************************************************************************");
                Program.Show($"Mano del jugador {turn + 1}: ");
                PrintCollection(current.PlayerHand);

                if (!MenuWheel.automode)
                {
                    Console.ReadLine();
                }
                else
                {
                    Thread.Sleep(1000);
                }


                var currentmove = current.Juega(gameComponents._board);
                if (currentmove != null)
                {
                    knocks = 0;
                    gameComponents._board.Insert(currentmove);

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Program.Show($"Le toca al jugador {turn + 1}");
                    Program.Show(
                        "******************************************************************************************************************");
                    if (gameComponents._board.board.Count != 0)
                        PrintCollection(gameComponents._board.board);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Program.Show("");
                    Program.Show(
                        "******************************************************************************************************************");

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"El jugador {turn + 1} jugó: ");
                    currentmove.Item1.Print();
                    Program.Show("");
                    PrintCollection(current.PlayerHand);
                    Thread.Sleep(1000);
                    turn += gameComponents.TurnRule.NxtTurn(knocks);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Program.Show("");
                    Program.Show($"El jugador {turn+1} se ha pasado");
                    Thread.Sleep(750);
                    knocks++;
                    turn += gameComponents.TurnRule.NxtTurn(knocks);
                }
                if (turn >= gameComponents.players.Length)
                {
                    turn = 0;
                }

                if (turn < 0)
                {
                    turn = gameComponents.players.Length - 1;
                }
                if (knocks == gameComponents.players.Length)
                {
                    winrule.draw = true;
                    break;
                }

               
            }

            Console.ForegroundColor = ConsoleColor.Red;
            var w1 = gameComponents._winnersRule.GetWinners(gameComponents);
            if (w1 == null)
            {
                Log.Draw();
                Program.Show(Log.log.Last());
                Console.ReadLine();
            }
            else if (w1.Length > 1 && MenuWheel.Teams == null)
            {
                Log.Draw();
                Program.Show(Log.log.Last());
                Console.ReadLine();
            }
            else if (w1.Length > 1 && MenuWheel.Teams != null)
            {
                bool founded = false;
                int ComunTeam = w1[0].InTeam(MenuWheel.Teams);
                for (int i = 0; i < w1.Length; i++)
                {
                    if (ComunTeam != w1[i].InTeam(MenuWheel.Teams))
                    {
                        founded = !founded;
                        Log.Draw();
                        Program.Show(Log.log.Last());
                        Console.ReadLine();
                    }
                }

                if (!founded)
                {
                    currentgame++;
                    MenuWheel.Teams[ComunTeam].Wins++;
                    Log.TeamWin(ComunTeam, w1,
                        gameComponents.players);
                    Program.Show(Log.Winlog.Last());
                }
            }
            else if (w1.Length == 1 && MenuWheel.Teams == null)
            {
                Program.Show("");
                Log.WinSolo(gameComponents.players[w1[0].player_Index], w1[0].player_Index);
                Program.Show(Log.Winlog.Last());
                Console.ReadLine();
                currentgame++;
            }
            else if(w1.Length==1&& MenuWheel.Teams!=null)
            {
                int team = w1[0].InTeam(MenuWheel.Teams);
                currentgame++;
                Log.TeamWin(team, w1[0].player_Index, gameComponents.players[w1[0].player_Index]);
                Program.Show(Log.Winlog.Last());
                Console.ReadLine();
            }
            
            //     if (winrule.draw)
            //     {
            //         Winner[] winners =
            //             gameComponents.DrawWinner(gameComponents.players, new int[gameComponents.players.Length]);
            //         if (winners.Length == 1 && MenuWheel.Teams == null)
            //         {
            //             winners.Last().wins++;
            //
            //             Log.WinSolo(gameComponents.players[winners.Last().player_Index], winners.Last().player_Index);
            //             Program.Show(Log.Winlog.Last());
            //             Console.ReadLine();
            //             TotalWinners.Add(winners.Last());
            //             currentgame++;
            //             continue;
            //         }
            //         else
            //         {
            //             Log.Draw();
            //             Program.Show(Log.log.Last());
            //             Console.ReadLine();
            //         }
            //
            //         if (winners == null)
            //         {
            //             Log.Draw();
            //             Program.Show(Log.log.Last());
            //             Console.ReadLine();
            //             continue;
            //         }
            //
            //         int ComunTeam = winners[0].InTeam(MenuWheel.Teams);
            //         for (int i = 0; i < winners.Length; i++)
            //         {
            //             if (ComunTeam != winners[i].InTeam(MenuWheel.Teams))
            //             {
            //                 Log.Draw();
            //                 Program.Show(Log.log.Last());
            //                 Console.ReadLine();
            //                 continue;
            //             }
            //         }
            //
            //         Program.Show($"Gano el equipo {ComunTeam} con los players: ");
            //         for (int w = 0; w < winners.Length; w++)
            //         {
            //             winners[w].wins++;
            //             if (w == winners.Length - 1) Console.Write(winners[w].player_Index);
            //             else
            //             {
            //                 Console.Write(winners[w].player_Index + ", ");
            //             }
            //         }
            //     }
            //     else
            //     {
            //         Winner winner = winrule.GetWinner();
            //         if (MenuWheel.Teams == null)
            //         {
            //             Program.Show("");
            //             Log.WinSolo(gameComponents.players[winner.player_Index], winner.player_Index);
            //             Program.Show(Log.Winlog.Last());
            //             Console.ReadLine();
            //             TotalWinners.Add(winner);
            //             currentgame++;
            //         }
            //         else
            //         {
            //             int team = winner.InTeam(MenuWheel.Teams);
            //             currentgame++;
            //             MenuWheel.Teams[team].Wins++;
            //             Log.TeamWin(MenuWheel.Teams[team], winner.player_Index,
            //                 gameComponents.players[winner.player_Index]);
            //             Program.Show(Log.Winlog.Last());
            //             TotalWinners.Add(winner);
            //             continue;
            //         }
            //     }
            // }
            //
            // Winner[] printWinners = TotalWinners.PrintWinners(gameComponents.players.Length);
            // if (printWinners.Length == 1)
            // {
            //     Console.Clear();
            //     Program.Show($"FELICIDADES jugador {printWinners[0].player_Index} haz ganado!!! ");
            // }

           
        }
        Console.ReadLine();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        MenuWheel.Menu();
    }
}