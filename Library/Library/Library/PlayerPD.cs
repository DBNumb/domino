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
        public override int PlayerScore { get; protected set; } = 0;

        public override Tuple<IToken, int> Juega(List<IToken>posiblesjugadas, IValuable extremo1, IValuable extremo2)
        {
            IToken jugada;
            List<int> numerosDiferentes = new List<int>();

            jugada = posiblesjugadas[0];//esto es para q no me marque error en el return....

            for (int i = 0; i< posiblesjugadas.Count; i++) 
            {
                if (!numerosDiferentes.Contains(posiblesjugadas[i].item1)) 
                {
                    numerosDiferentes.Add(posiblesjugadas[i].item1);
                }
                if (!numerosDiferentes.Contains(posiblesjugadas[i].item2))
                {
                    numerosDiferentes.Add(posiblesjugadas[i].item2);
                }
            }

            int[] repeticionesPorNumero = new int[numerosDiferentes.Count];

            for (int i = 0; i< numerosDiferentes.Count; i++) 
            {
                int count = 0;
                for (int j =0; j< posiblesjugadas.Count; j++) 
                {
                    if (numerosDiferentes[i] == posiblesjugadas[j].item1 
                        || numerosDiferentes[i] == posiblesjugadas[j].item2) 
                    {
                        count++;
                    }
                }
                repeticionesPorNumero[i] = count;
            }

            int data = repeticionesPorNumero.Max();

            for (int i = 0; i < posiblesjugadas.Count; i++) 
            {
                if (!(posiblesjugadas[i].item1 == data || posiblesjugadas[i].item2 == data)) 
                {
                    jugada = posiblesjugadas[i];
                    break;
                }                
            }

            PlayerScore += jugada.score;
           
            int y;
            if ((jugada.item1 == extremo1.value && jugada.item2 == extremo2.value)
              || (jugada.item1 == extremo2.value && jugada.item2 == extremo1.value))
            {
                int[] indices = { extremo1.value, extremo2.value };
                if (extremo1.value == data) y = extremo2.value;
                else if (extremo2.value == data) y = extremo1.value;
                else 
                {
                    //entra aca en caso de que su data no sea ninguno de los extremos... en ese caso juega al indice random
                    var randomIndice = new Random(indices.Length);
                    y = randomIndice.Next(0, indices.Length);
                }
            }
            else if (jugada.item1 == extremo1.value || jugada.item2 == extremo1.value)
            {
                y = extremo1.value;
            }
            else y = extremo2.value;
            
            //juega protegiendo su data y en caso de que pueda jugar por los 2 extremos jugara para que en ambos
            //extremos este su data
            return Tuple.Create(jugada, y);
        }
    }
}
