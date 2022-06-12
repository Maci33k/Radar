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
        protected int Szerokosc;
        protected int Dlugosc;
        protected string? Znak;

        public Statek(Punkt Srodek, int Szerokosc, int Dlugosc)
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
        public string GetZnak()
        {
            if (Znak != null)
            {
                return Znak;
            }
            else
            {
                return "thonk";
            }
        }
        public void SetZnak(string  Znak)
        {
            this.Znak = Znak;  
        }
        public void SetDlugosc(int Dlugosc)
        {
            this.Dlugosc = Dlugosc;
        }
        public void SetSzerokosc(int Szerokosc)
        {
            this.Szerokosc = Szerokosc;
        }
        

    }
}
