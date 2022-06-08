using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Balon : Statek
    {
        
        public Balon(Punkt Srodek, double Szerokosc, double Dlugosc, char Znak) : base(Srodek, Szerokosc, Dlugosc)
        {
            base.Znak = Znak;
        }
    }
}
