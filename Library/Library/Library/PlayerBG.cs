﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PlayerBG : Player
    {
        public override int PlayerScore { get; protected set; } = 0;
        
        public override IToken<T> Juega<T>(List<IToken<T>> posiblesjugadas, int extremo1, int extremo2)
        {
            //player bota gorda
            IToken<T> jugada = posiblesjugadas[0];

            for (int i = 1; i < posiblesjugadas.Count; i++)
            {
                if (jugada.score < posiblesjugadas[i].score)
                    jugada = posiblesjugadas[i];
            }
            PlayerScore += jugada.score;

            int y;
            if ((jugada.values.Item1 == extremo1 && jugada.values.Item2 == extremo2)
               || (jugada.values.Item1 == extremo2 && jugada.values.Item2 == extremo1))
            {
                int[] indices = { extremo1, extremo2 };
                y = indices.Min();
            }
            else if (jugada.values.Item1 == extremo1 || jugada.values.Item2 == extremo1)
            {
                y = extremo1;
            }
            else y = extremo2;

            
            //bota la ficha mas gorda... en caso de que pueda jugar por ambos extremos juega por
            //el menor extremo


            return jugada;
        }
    }
}