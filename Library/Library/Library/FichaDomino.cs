using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class FichaDomino:Ficha
    {
        public int mitadIzq;
        public int mitadDer;
        public int puntos;
        public FichaDomino(int mitadIzq, int mitadDer) 
        {
            this.mitadIzq = mitadIzq;
            this.mitadDer = mitadDer;
            this.puntos = mitadDer + mitadIzq;
        }
    }
}
