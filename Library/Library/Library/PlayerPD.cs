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

        public override IToken Juega(List<IToken>posiblesjugadas, int extremo1, int extremo2)
        {
            IToken jugada;
            List<int> numerosDiferentes = new List<int>();

            jugada = posiblesjugadas[0];//esto es para q no me marque error en el return....

            for (int i = 0; i< posiblesjugadas.Count; i++) 
            {
                if (!numerosDiferentes.Contains(posiblesjugadas[i].Item1)) 
                {
                    numerosDiferentes.Add(posiblesjugadas[i].Item1);
                }
                if (!numerosDiferentes.Contains(posiblesjugadas[i].Item2))
                {
                    numerosDiferentes.Add(posiblesjugadas[i].Item2);
                }
            }

            int[] repeticionesPorNumero = new int[numerosDiferentes.Count];

            for (int i = 0; i< numerosDiferentes.Count; i++) 
            {
                int count = 0;
                for (int j =0; j< posiblesjugadas.Length; j++) 
                {
                    if (numerosDiferentes[i] == posiblesjugadas[j].Item1 
                        || numerosDiferentes[i] == posiblesjugadas[j].Item2) 
                    {
                        count++;
                    }
                }
                repeticionesPorNumero[i] = count;
            }

            int data = repeticionesPorNumero.Max();

            for (int i = 0; i < posiblesjugadas.Length; i++) 
            {
                if (!(posiblesjugadas[i].Item1 == data || posiblesjugadas[i].Item2 == data)) 
                {
                    jugada = posiblesjugadas[i];
                    break;
                }                
            }

            PlayerScore += jugada.score;
           
            int y;
            if ((jugada.values.Item1 == extremo1 && jugada.values.Item2 == extremo2)
              || (jugada.values.Item1 == extremo2 && jugada.values.Item2 == extremo1))
            {
                int[] indices = { extremo1, extremo2 };
                if (extremo1 == data) y = extremo2;
                else if (extremo2 == data) y = extremo1;
                else 
                {
                    //entra aca en caso de que su data no sea ninguno de los extremos... en ese caso juega al indice random
                    var randomIndice = new Random(indices.Length);
                    y = randomIndice.Next(0, indices.Length);
                }
            }
            else if (jugada.values.Item1 == extremo1 || jugada.values.Item2 == extremo1)
            {
                y = extremo1;
            }
            else y = extremo2;
            
            //juega protegiendo su data y en caso de que pueda jugar por los 2 extremos jugara para que en ambos
            //extremos este su data
            return Tuple.Create(jugada, y);
        }
    }
}
