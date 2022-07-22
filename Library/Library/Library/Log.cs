namespace Library;

public static class Log
{
    public static List<string> log= new List<string>();
    public static List<string> Winlog= new List<string>();
    

    public static void WinSolo(Player x,int playerindex)
    {
        Winlog.Add($"El jugador {playerindex+1} ha ganado con una puntuación de {x.GetPlayerScore} puntos");
    }

    public static void TeamWin(int TeamIndex, int playerindex,Player x)
    {
        Winlog.Add($"Ganó el equipo {TeamIndex+1} con el jugador {playerindex+1} " +
                   $"con una puntuación de {x.GetPlayerScore}");
    }

    public static void TeamWin(int TeamIndex, Winner[] winners, Player[] players)
    {
        string result = "";
        result+=$"Ganó el equipo {TeamIndex+1} con los jugadores: ";
        foreach (var VARIABLE in winners)
        {
            result += "\n" + $"{VARIABLE.player_Index+1}" + $"con una puntuacion de: {players[VARIABLE.player_Index].GetPlayerScore} ";
        }
        Winlog.Add(result);
    }
    public static void Draw()
    {  Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Black;
        log.Add("Empate!!");
    }
    public static void Reset()
    {   Winlog.Clear();
        log.Clear();
    }
}