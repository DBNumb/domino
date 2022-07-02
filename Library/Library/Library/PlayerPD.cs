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
            List<IComparable> numerosDiferentes = new List<IComparable>();

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
                    if (numerosDiferentes[i].CompareTo(posiblesjugadas[j].ValueItem1)==0  
                        || numerosDiferentes[i] .CompareTo( posiblesjugadas[j].ValueItem2)==0) 
                    {
                        count++;
                    }
                }
                repeticionesPorNumero[i] = count;
            }

            IComparable data = repeticionesPorNumero.ToList().IndexOf(repeticionesPorNumero.Max());

            for (int i = 0; i < posiblesjugadas.Count; i++) 
            {
                if (!(posiblesjugadas[i].ValueItem1.CompareTo(data)==0 || posiblesjugadas[i].ValueItem2.CompareTo(data)==0 )) 
                {
                    jugada = posiblesjugadas[i];
                    break;
                }                
            }

            PlayerScore += jugada.score;
           
            int y=comp.Compare(jugada,extremos);
            if (y < 2)
            {
                return new Tuple<Token, IComparable>(jugada, extremos[y]);
            }
            return new Tuple<Token, IComparable>(jugada, extremos.ValueItem1);
            //juega protegiendo su data y en caso de que pueda jugar por los 2 extremos jugara para que en ambos
            //extremos este su data
            
        }
    }
}
