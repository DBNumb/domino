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
        
        public override Token Juega(Token[] posiblesjugadas)
        {
            //player bota gorda
            Token jugada = posiblesjugadas[0];

            for (int i = 1; i < posiblesjugadas.Length; i++)
            {
                if (jugada.score < posiblesjugadas[i].score)
                    jugada = posiblesjugadas[i];
            }

            PlayerScore += jugada.score;
            return jugada;
        }
    }
}