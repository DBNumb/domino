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
        Winlog.Add($"El jugador {playerindex} ha ganado con una puntuación de {x.PlayerScore} puntos");
    }

    public static void TeamWin(Team team, int playerindex,Player x)
    {
        Winlog.Add($"Ganó el equipo {team.TeamIndex} con el jugador {playerindex} " +
                   $"con una puntuación de {x.PlayerScore}");
    }

    public static void Draw()
    {
        log.Add("Empate");
    }
    public static void Reset()
    {
        log.Clear();
    }
}