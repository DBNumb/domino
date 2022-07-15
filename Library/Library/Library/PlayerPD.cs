using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
   public class PlayerPD : Player
    {
        //player protege data
       
        public override int PlayerScore { get; protected set; } = 0;
        public override List<Token> PlayerHand { get; set; }


        public override Tuple<Token, IComparable> Juega(List<Token> posiblesjugadas, Token extremos)
        {
            if (posiblesjugadas == null) return null;

            Token jugada;
            List<IComparable> carasDiferentes = new List<IComparable>();

            jugada = posiblesjugadas[0];//esto es para q no me marque error en el return....

            for (int i = 0; i< posiblesjugadas.Count; i++) 
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

            for (int i = 0; i< carasDiferentes.Count; i++) 
            {
                int count = 0;
                for (int j =0; j< posiblesjugadas.Count; j++) 
                {
                    if (carasDiferentes[i].Compare(posiblesjugadas[j].FaceA)==0  
                        || carasDiferentes[i] .Compare( posiblesjugadas[j].FaceB)==0) 
                    {
                        count++;
                    }
                }
                repeticionesPorCara[i] = count;
            }

            int xd = 0;
            for (int i = 0; i< repeticionesPorCara.Length; i++) 
            {
                if (repeticionesPorCara[i] == repeticionesPorCara.Max())
                {
                    xd = i;
                    break;
                }
            }

            IComparable data = carasDiferentes[xd];
           

            for (int i = 0; i < posiblesjugadas.Count; i++) 
            {
                if (!(posiblesjugadas[i].FaceA.Compare(data)==0 || posiblesjugadas[i].FaceB.Compare(data)==0 )) 
                {
                    jugada = posiblesjugadas[i];
                    break;
                }                
            }

            PlayerScore += jugada.Score;
            PlayerHand.Remove(jugada);
            
            if (extremos.FaceA == null || extremos.FaceB == null) return new Tuple<Token, IComparable>(jugada, null);
            return Comp(jugada, extremos);
            if ((jugada.FaceA.Compare(extremos.FaceA) == 0 || jugada.FaceA.Compare(extremos.FaceB) == 0) &&
               (jugada.FaceB.Compare(extremos.FaceA) == 0 || jugada.FaceB.Compare(extremos.FaceB) == 0))
            {
                //caso en que la ficha se puede jugar por cualquier extremo

                if (extremos.FaceA.Compare(data) == 0) return new Tuple<Token, IComparable>(jugada, extremos.FaceB);
                return new Tuple<Token, IComparable>(jugada, extremos.FaceA);
            }
            else if (jugada.FaceA.Equals(extremos.FaceA) || jugada.FaceB.Equals(extremos.FaceA))
            {
                //caso en el que solo se puede jugar por el extremo A
                return new Tuple<Token, IComparable>(jugada, extremos.FaceA);
            }
            //caso en el que solo se puede jugar por el extremo B
            return new Tuple<Token, IComparable>(jugada, extremos.FaceB);

            //juega protegiendo su data y en caso de que pueda jugar por los 2 extremos jugara para que en ambos
            //extremos este su data

        }
    }
}
