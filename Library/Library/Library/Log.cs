namespace Library;

public static class Log
{
    public static List<string> log;

    public static void Register(Token play, int player) 
    {
        log.Add($"Jugador {player} jugó la ficha {play.ToString()}");
    }

    public static void Win(Player x,int playerindex)
    {
        log.Add($"El jugador {playerindex} ha ganado con una puntuación de {x.PlayerScore} puntos");
    }
    public static void Reset()
    {
        log.Clear();
    }
}