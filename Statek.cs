using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Statek
    {
        protected Punkt Srodek;
        protected double Szerokosc;
        protected double Dlugosc;
        protected char Znak;

        public Statek(Punkt Srodek, double Szerokosc, double Dlugosc)
        {
            this.Srodek = Srodek;
            this.Szerokosc = Szerokosc;
            this.Dlugosc = Dlugosc;

        }
        public Punkt GetSrodek()
        {
            return Srodek;
        }
        public double GetSzerokosc()
        {
            return Szerokosc;
        }
        public double getDlugosc()
        {
            return Dlugosc;
        }
        public char getZnak()
        {
            return Znak;
        }
        

    }
}
