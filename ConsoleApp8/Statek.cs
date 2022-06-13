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
        protected string Znak;
        protected Punkt Koniec;

        public Statek(Punkt Srodek)
        {
            this.Srodek = Srodek;
            Random r = new Random();
            Koniec = new Punkt(r.Next(0, 10), 0);
        }
        public Punkt GetSrodek()
        {
            return Srodek;
        }


        public string GetZnak()
        {
            return Znak;
        }
        public void SetZnak(string Znak)
        {
            this.Znak = Znak;
        }
        public Punkt GetKoniec()
        {
            return Koniec;
        }



    }
}