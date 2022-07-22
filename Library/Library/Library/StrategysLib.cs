using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library;

public interface IStrategy
{
    public Token Strategy(List<Token> posiblesjugadas, Board board);
    public List<Token> GiveSortedHand(List<Token> playerHand);
}

public class RandomStrategy : IStrategy
{
    public Token Strategy(List<Token> posiblesjugadas, Board board)
    {
        //escoge una ficha random entre las posibles jugadas y la devuelve.
        var randomNumber = new Random(posiblesjugadas.Count);
        int x = randomNumber.Next(0, posiblesjugadas.Count);

        Token jugada = posiblesjugadas[x];
        return jugada;
    }

    public List<Token> GiveSortedHand(List<Token> playerHand)
    {
        //organiza random la mano del jugador

        List<Token> aux = new List<Token>();
        foreach (var token in playerHand)
        {
            aux.Add(token);
        }
        return aux;
    }
}

public class BGStrategy : IStrategy
{
    public List<Token> GiveSortedHand(List<Token> playerHand)
    {
        //organiza la mano del jugador por puntuacion de mayor a menor

        List<Token> aux = new List<Token>();
        foreach (var token in playerHand)
        {
            aux.Add(token);
        }
        for (int j = 0; j < aux.Count - 1; j++)
        {
            for (int k = j + 1; k < aux.Count; k++)
            {
                if (aux[j].Score < aux[k].Score)
                {
                   var temp = aux[j];
                    aux[j] = aux[k];
                    aux[k] = temp;
                }
            }
        }
        
        return aux;
    }

    public Token Strategy(List<Token> posiblesjugadas, Board board)
    {
        //juega la ficha que mas puntos otorgue de esa manera se "libra de la ficha gorda".
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
    public List<Token> GiveSortedHand(List<Token> playerHand)
    {
        //ordena las fichas del jugador poniendo su data para el final
        List<Token> aux = new List<Token>();
        int l = 0;
        foreach (var token in playerHand)
        {
            aux.Add(token);
        }
        IComparable data = GetData(playerHand);


        int i = aux.Count - 1;
        int j = aux.Count - 1;
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
        
        return aux;
    }

    public Token Strategy(List<Token> posiblesjugadas, Board board)
    {
        //va jugando las fichas que no son su data, dejando esta para el final
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
        //dada una lista de fichas devuelve la data entre estas fichas.
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