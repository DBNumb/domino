namespace Library;

public static class Log
{
    public static List<string> moves;

    public static void Register(Token play, int player)
    {
        moves.Add($"Jugador {player} jugó la ficha [{play.Item1},{play.Item2}]");
    }
}