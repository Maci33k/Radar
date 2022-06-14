using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Balon : Statek
    { 
        // Unikalny znak dla balona @
        private string Znak = "@";
        // Konstruktor razem z wywołaniem konstruktora bazowego z klasy Statek
        // W konstruktorze przypisanie znaku do pola w klasie bazowej i wylosowanie punktu
        // końcowego dla balona
        public Balon(Punkt Srodek) : base(Srodek)
        {
            base.Znak = Znak;
            Random r = new Random();
            base.Koniec = new Punkt(r.Next(10, 40), r.Next(10, 94));
        }
    }
}