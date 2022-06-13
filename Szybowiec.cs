using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Szybowiec : Statek
    {
        private string Znak = "*";
        public Szybowiec(Punkt Srodek, int Szerokosc, int Dlugosc) : base(Srodek, Szerokosc, Dlugosc)
        {
            base.Znak = Znak;
        }
    }
}
