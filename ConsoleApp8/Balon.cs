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
        }
    }
}
