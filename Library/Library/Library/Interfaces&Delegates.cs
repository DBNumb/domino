using System.Collections;
using System.Runtime.CompilerServices;

namespace Library;

#region GenericTokenInterface

public interface IPuntuable
{
    public int GetPuntuation();
}

public delegate bool IWin<T>(T checker);
public interface IComparable
{
    bool CanBeCompare(object other);
    int Compare(object other);
}

#region SelectionRule NOT YEEEET!!!!!
//permite a un jugador volver a seleccionar fichas acorde a la regla de selección del jugador
public delegate List<Token> Reselect(ReselectRule rule);
public interface ReselectRule
{
    public void RemoveSelection(List<Token> PlayerHand);
}
#endregion
public interface IFace: IComparable,IPuntuable
{
    bool CanbeMatch(IFace other);
}


#endregion

public interface IFilterFichas
{
    public List<Token> posiblesjugadas { get; set; }

    public bool Apply(List<Token> fichasPlayer, Token Estado_tablero, IComparer<Token>comp);
    //hay q abstraernos mas pq esto solo funciona para domino
}

// public delegate Library.TokenCollection Insert<Token, Int32, TokenCollection>(Token x,int pos,out TokenCollection collection);
public interface IGameBreak
{
    public Winner GetWinner();
    public bool Over(GameComponents gamestatus);
}

public  class PlayerFinish : IGameBreak
{
    public Winner GetWinner()
    {
        return _winner;
    }

    private Winner _winner;
    public bool Over(GameComponents gamestatus)
    {
        for (int i = 0; i < gamestatus.players.Length; i++)
        {
            if (gamestatus.players[i].PlayerHand.Count==0)
            {
                _winner = new Winner(i);
                return true;
            }
        }

        return false;
    }
}

public class PlayFinish : IGameBreak
{
    private Winner _winner;
    public Winner GetWinner()
    {
        throw new NotImplementedException();
    }

    private GameComponents aux;
    private int currentPlays=0;
    private int max;
    public PlayFinish(int max)
    {
        this.max = max;
    }
    public bool Over(GameComponents gamestatus)
    {
        currentPlays++;
        if (currentPlays==max)
        {
            aux = gamestatus;
            _winner = GetWinner();
            return true;
        }

        return false;
    }
}
