using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Balon : Statek
    {
        private string Znak = "@";
        public Balon(Punkt Srodek) : base(Srodek)
        {
            base.Znak = Znak;
            Random r = new Random();
            base.Koniec = new Punkt(r.Next(10, 94), r.Next(10, 40));
        }
    }
}
