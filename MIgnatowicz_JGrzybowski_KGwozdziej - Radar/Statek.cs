using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Statek
    {
        protected Trasa lot;
        protected double szerokosc;
        protected Punkt srodek;
        protected double dlugosc;
        protected double wzrost;

        public Trasa getLot()
        {
            return lot;
        }
        public Punkt GetSrodek()
        {
            return srodek;
        }
        public double GetSzerokosc()
        {
            return szerokosc;
        }
        public double GetDlugosc()
        {
            return dlugosc;
        }
        public double GetWzrost()
        {
            return wzrost;
        }

        public void SetLot(Trasa l)
        {
            lot = l;
        }
    }
}
