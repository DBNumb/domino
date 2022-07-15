using System.Collections;
using System.Runtime.CompilerServices;

namespace Library;

#region GenericTokenInterface

public interface IPuntuable
{
    public int GetPuntuation();
}


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

public interface IGameBreak
{
    public Winner GetWinner();
    public bool Over(GameComponents gamestatus);
}

