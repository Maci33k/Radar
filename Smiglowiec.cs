using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Smiglowiec : Statek
    {
        private new string Znak = "#"; 
        public Smiglowiec(Punkt Srodek, int Szerokosc, int Dlugosc) : base(Srodek, Szerokosc, Dlugosc)
        {
            base.Znak = Znak;
        }
    }
}
