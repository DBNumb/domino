using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public interface IStrategy
{
    public Token Strategy(List<Token> posiblesjugadas, Board board);
    public void SortHand(List<Token> playerHand);
}

public class RandomStrategy : IStrategy
{
    public Token Strategy(List<Token> posiblesjugadas, Board board)
    {
        var randomNumber = new Random(posiblesjugadas.Count);
        int x = randomNumber.Next(0, posiblesjugadas.Count);

        Token jugada = posiblesjugadas[x];
        return jugada;
    }

    public void SortHand(List<Token> playerHand)
    {
        //organiza random la mano del jugador

        List<Token> aux = playerHand;
        playerHand.Clear();
        playerHand = new List<Token>(aux.Count);

        for (int i = 0; i < playerHand.Count; i++)
        {
            var randomNumber = new Random(aux.Count);
            int x = randomNumber.Next(0, aux.Count);
            playerHand.Add(aux[x]);
            aux.RemoveAt(x);
        }
    }
}

public class BGStrategy : IStrategy
{
    public void SortHand(List<Token> playerHand)
    {
        //organiza la mano del jugador por puntuacion de mayor a menor

        Token[] aux = playerHand.ToArray();
        playerHand.Clear();
        playerHand = new List<Token>(aux.Length);
        Token temp;

        for (int i = 0; i < aux.Length - 1; i++)
        {
            for (int j = i + 1; j < aux.Length; j++)
            {
                if (aux[i].Score < aux[j].Score)
                {
                    temp = aux[i];
                    aux[i] = aux[j];
                    aux[j] = temp;
                }
            }
        }

        playerHand = aux.ToList();
    }

    public Token Strategy(List<Token> posiblesjugadas, Board board)
    {
        Token jugada = posiblesjugadas[0];

        for (int i = 1; i < posiblesjugadas.Count; i++)
        {
            if (jugada.Score < posiblesjugadas[i].Score)
                jugada = posiblesjugadas[i];
        }

        return jugada;
    }
}

public class PDStrategy : IStrategy
{
    public void SortHand(List<Token> playerHand)
    {
        //ordena las fichas del jugador poniendo su data para el final
        Token[] aux = playerHand.ToArray();
        IComparable data = GetData(playerHand);


        int i = aux.Length - 1;
        int j = aux.Length - 1;
        int k = 0;
        while (i > 0)
        {
            if (playerHand[i].FaceA.Compare(data) == 0 || playerHand[i].FaceB.Compare(data) == 0)
            {
                aux[j] = playerHand[i];
                j--;
            }
            else
            {
                aux[k] = playerHand[i];
                k++;
            }

            i--;
        }
    }

    public Token Strategy(List<Token> posiblesjugadas, Board board)
    {
        Token jugada = posiblesjugadas[0];

        IComparable data = GetData(posiblesjugadas);

        for (int i = 0; i < posiblesjugadas.Count; i++)
        {
            if (!(posiblesjugadas[i].FaceA.Compare(data) == 0 || posiblesjugadas[i].FaceB.Compare(data) == 0))
            {
                jugada = posiblesjugadas[i];
                break;
            }
        }

        return jugada;
    }

    public IComparable GetData(List<Token> fichas)
    {
        IComparable result;

        List<IComparable> carasDiferentes = new List<IComparable>();

        for (int i = 0; i < fichas.Count; i++)
        {
            if (!carasDiferentes.Contains(fichas[i].FaceA))
            {
                carasDiferentes.Add(fichas[i].FaceA);
            }

            if (!carasDiferentes.Contains(fichas[i].FaceB))
            {
                carasDiferentes.Add(fichas[i].FaceB);
            }
        }

        int[] repeticionesPorCara = new int[carasDiferentes.Count];

        for (int i = 0; i < carasDiferentes.Count; i++)
        {
            int count = 0;
            for (int j = 0; j < fichas.Count; j++)
            {
                if (carasDiferentes[i].Compare(fichas[j].FaceA) == 0
                    || carasDiferentes[i].Compare(fichas[j].FaceB) == 0)
                {
                    count++;
                }
            }

            repeticionesPorCara[i] = count;
        }

        int aux = 0;
        for (int i = 0; i < repeticionesPorCara.Length; i++)
        {
            if (repeticionesPorCara[i] == repeticionesPorCara.Max())
            {
                aux = i;
                break;
            }
        }

        result = carasDiferentes[aux];


        return result;
    }
}