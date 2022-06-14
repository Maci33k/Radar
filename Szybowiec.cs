﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Szybowiec : Statek
    {
        // Unikalny znak dla szybowca
        private string Znak = "*";
        // Konstruktor szybowca wraz z wywołaniem konstruktora klasy bazowej
        public Szybowiec(Punkt Srodek) : base(Srodek)
        {
            base.Znak = Znak;
            Random r = new Random();
            base.Koniec = new Punkt(r.Next(10, 40), r.Next(10, 94));
        }
    }
}