using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public  class Samolot : Statek
    {
        public Samolot(Punkt Srodek, int Szerokosc, int Dlugosc, string Znak) : base(Srodek, Szerokosc, Dlugosc)
        {
            base.Znak = Znak; 
        }
        
        
             
       
    }
}
