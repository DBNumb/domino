using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PlayerPD : Player
    {
        //player protege data
        public override Token Juega(Token[] posiblesjugadas)
        {
            Token jugada;
            List<int> numerosDiferentes = new List<int>();

            jugada = posiblesjugadas[0];//esto es para q no me marque error en el return....

            for (int i = 0; i< posiblesjugadas.Length; i++) 
            {
                if (!numerosDiferentes.Contains(posiblesjugadas[i].values.Item1)) 
                {
                    numerosDiferentes.Add(posiblesjugadas[i].values.Item1);
                }
                if (!numerosDiferentes.Contains(posiblesjugadas[i].values.Item2))
                {
                    numerosDiferentes.Add(posiblesjugadas[i].values.Item2);
                }
            }

            int[] repeticionesPorNumero = new int[numerosDiferentes.Count];

            for (int i = 0; i< numerosDiferentes.Count; i++) 
            {
                int count = 0;
                for (int j =0; j< posiblesjugadas.Length; j++) 
                {
                    if (numerosDiferentes[i] == posiblesjugadas[j].values.Item1 || numerosDiferentes[i] == posiblesjugadas[j].values.Item2) 
                    {
                        count++;
                    }
                }
                repeticionesPorNumero[i] = count;
            }

            int data = repeticionesPorNumero.Max();

            for (int i = 0; i < posiblesjugadas.Length; i++) 
            {
                if (!(posiblesjugadas[i].values.Item1 == data || posiblesjugadas[i].values.Item2 == data)) 
                {
                    jugada = posiblesjugadas[i];
                    break;
                }                
            }
            return jugada;
        }
    }
}
