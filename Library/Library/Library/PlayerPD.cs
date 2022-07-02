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
        public override List<Token> PlayerHand { get; }
        

        public override Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos, IComparer<Token> comp)
        {
          Token jugada;
            List<int> numerosDiferentes = new List<int>();

            jugada = posiblesjugadas[0];//esto es para q no me marque error en el return....

            for (int i = 0; i< posiblesjugadas.Count; i++) 
            {
                if (!numerosDiferentes.Contains(posiblesjugadas[i].ValueItem1)) 
                {
                    numerosDiferentes.Add(posiblesjugadas[i].ValueItem1);
                }
                if (!numerosDiferentes.Contains(posiblesjugadas[i].ValueItem2))
                {
                    numerosDiferentes.Add(posiblesjugadas[i].ValueItem2);
                }
            }

            int[] repeticionesPorNumero = new int[numerosDiferentes.Count];

            for (int i = 0; i< numerosDiferentes.Count; i++) 
            {
                int count = 0;
                for (int j =0; j< posiblesjugadas.Count; j++) 
                {
                    if (numerosDiferentes[i] == posiblesjugadas[j].ValueItem1 
                        || numerosDiferentes[i] == posiblesjugadas[j].ValueItem2) 
                    {
                        count++;
                    }
                }
                repeticionesPorNumero[i] = count;
            }

            int data = repeticionesPorNumero.Max();

            for (int i = 0; i < posiblesjugadas.Count; i++) 
            {
                if (!(posiblesjugadas[i].ValueItem1 == data || posiblesjugadas[i].ValueItem2 == data)) 
                {
                    jugada = posiblesjugadas[i];
                    break;
                }                
            }

            PlayerScore += jugada.score;
           
            int y;
            if (comp.Compare(jugada,extremos)==1)
            {
                return new Tuple<Token, int>(jugada, extremos.ValueItem1);
            }
            else if (jugada.ValueItem1 == extremos.ValueItem1 || jugada.ValueItem2 == extremos.ValueItem1)
            {
                return new Tuple<Token, int>(jugada, extremos.ValueItem1);
            }

            return new Tuple<Token, int>(jugada, extremos.ValueItem2);
            //juega protegiendo su data y en caso de que pueda jugar por los 2 extremos jugara para que en ambos
            //extremos este su data
            
        }
    }
}
