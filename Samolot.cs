using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Samolot : Statek
    {
        // Unikalny znak dla samolotu
        private string Znak = "X";
        // Konstruktor wraz z wywołaniem konstruktora z klasy bazowej i wylosowanie punktu końcowego
        public Samolot(Punkt Srodek) : base(Srodek)
        {
            base.Znak = Znak;
            Random r = new Random();
            base.Koniec = new Punkt(r.Next(10, 40), r.Next(10, 94));
        }




    }
}