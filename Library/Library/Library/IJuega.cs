using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IJuega
    {
        public Ficha Juega();
        //aca deberiamos poner de alguna manera los parametros de la jugada... por ejemplo en domino clasico tenemos 2 cabezas..
        //en cada una tenemos un int y para jugar tiene que coincidir la cabeza con alguna de las fichas q tenga el player... 
        //pero a la hora de poner otro juego (ejemplo tictactoe) la regla de la jugada cambia asi q como se podria poner eso?

    }
}
