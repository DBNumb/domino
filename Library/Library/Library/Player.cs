﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class Player
    {
        //clase abstracta jugador
        public abstract IJuega Juega(IJuega[] posiblesjugadas);

    }
}
