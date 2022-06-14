using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Smiglowiec : Statek
    {
        // Unikalny znak dla śmigłowca
        private String Znak = "#";
        // Konstruktor wraz z wywołaniem konstruktora klasy bazowej oraz wylosowanie punktu końcowego
        public Smiglowiec(Punkt Srodek) : base(Srodek)
        {
            base.Znak = Znak;
            Random r = new Random();
            base.Koniec = new Punkt(r.Next(10, 40), r.Next(10, 94));
        }
    }
}