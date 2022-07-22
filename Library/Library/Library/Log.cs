namespace Library;

public static class Log
{
    public static List<string> log= new List<string>();
    public static List<string> Winlog= new List<string>();
    public static void Register(Token play, int player) 
    {
        log.Add($"Jugador {player} jugó la ficha {play.ToString()}");
    }

    public static void WinSolo(Player x,int playerindex)
    {
        Winlog.Add($"El jugador {playerindex} ha ganado con una puntuación de {x.GetPlayerScore} puntos");
    }

    public static void TeamWin(int TeamIndex, int playerindex,Player x)
    {
        Winlog.Add($"Ganó el equipo {TeamIndex} con el jugador {playerindex} " +
                   $"con una puntuación de {x.GetPlayerScore}");
    }

    public static void TeamWin(int TeamIndex, Winner[] winners, Player[] players)
    {
        string result = "";
        result+=$"Ganó el equipo {TeamIndex} con los jugadores: ";
        foreach (var VARIABLE in winners)
        {
            result += "\n" + VARIABLE.player_Index + $"con una puntuacion de: {players[VARIABLE.player_Index]} ";
        }
        Winlog.Add(result);
    }
    public static void Draw()
    {  Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Black;
        log.Add("Empate");
    }
    public static void Reset()
    {
        log.Clear();
    }
}