namespace Library;

public class Team
{
    public int TeamIndex { get; }
    public List<int> TeamMembers { get; }
    public int Wins = 0;

    public Team(int teamIndex)
    {
        TeamMembers = new List<int>();
        TeamIndex = teamIndex;
    }
}