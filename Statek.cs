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

        public Statek(Punkt Srodek)
        {
            this.Srodek = Srodek;
        }
        public Punkt GetSrodek()
        {
            return Srodek;
        }
       
        
        public string GetZnak()
        {
            return Znak;
        }
        public void SetZnak(string  Znak)
        {
            this.Znak = Znak;  
        }
        
        
        

    }
}
