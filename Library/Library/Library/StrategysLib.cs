using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class StrategysLib
    {
    }
    public interface IStrategy 
    {
        public Token Strategy(List<Token> posiblesjugadas, Board board);
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
    }
    public class BGStrategy : IStrategy
    {
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
        public Token Strategy(List<Token> posiblesjugadas, Board board)
        {
            Token jugada = posiblesjugadas[0];
            List<IComparable> carasDiferentes = new List<IComparable>();

            for (int i = 0; i < posiblesjugadas.Count; i++)
            {
                if (!carasDiferentes.Contains(posiblesjugadas[i].FaceA))
                {
                    carasDiferentes.Add(posiblesjugadas[i].FaceA);
                }
                if (!carasDiferentes.Contains(posiblesjugadas[i].FaceB))
                {
                    carasDiferentes.Add(posiblesjugadas[i].FaceB);
                }
            }

            int[] repeticionesPorCara = new int[carasDiferentes.Count];

            for (int i = 0; i < carasDiferentes.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < posiblesjugadas.Count; j++)
                {
                    if (carasDiferentes[i].Compare(posiblesjugadas[j].FaceA) == 0
                        || carasDiferentes[i].Compare(posiblesjugadas[j].FaceB) == 0)
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

            IComparable data = carasDiferentes[aux];


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
    }
}
