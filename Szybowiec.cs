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
        public Szybowiec(Punkt Srodek) : base(Srodek)
        {
            base.Znak = Znak;
        }
    }
}
