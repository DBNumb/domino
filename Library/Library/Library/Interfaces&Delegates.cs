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


public interface IFace: IComparable,IPuntuable
{
    bool CanbeMatch(IFace other);
}


#endregion


public interface IDeck
{
    public List<Token> deck { get; }
}

