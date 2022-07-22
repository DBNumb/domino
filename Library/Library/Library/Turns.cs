namespace Library;

public class ClockTurn : ITurnRule
{
    //regla que modifica el modo de pasar los turnos de la siguiente manera:
    //si se pasa un jugador vuelve a jugar el jugador anterior
    public int nxt_turn { get; }
    private int consecutives_knocks = 0;

    public int NxtTurn(int knocks)
    {
        if (knocks == 0 || consecutives_knocks >= 2)
        {
            consecutives_knocks = 0;
            return 1;
        }
        consecutives_knocks++;
        return -1;
    }

    public ClockTurn()
    {
        nxt_turn = 0;
    }
}

public class ClassicTurn : ITurnRule
{
    //regla clasica de turnos en la que juega un jugador detras de otro y si uno se pasa se salta al proximo jugador
    public int nxt_turn { get; }

    public int NxtTurn(int knocks)
    {
        return 1;
    }

    public ClassicTurn()
    {
        nxt_turn = 0;
    }
}