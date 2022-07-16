﻿using System.Collections;
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
{  public bool draw { get; set; }
    public Winner GetWinner();
    public bool Over(GameComponents gamestatus);
}

