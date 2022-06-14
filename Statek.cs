using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    // Klasa bazowa podklas Samolot, Smiglowiec, Balon i Szybowiec
    public class Statek
    {
        protected Punkt Srodek; // aktualne wspolrzedne statku
        protected string Znak; // znak przedstawiający statek
        protected Punkt Koniec; // współrzędne końca trasy statku, ew. miejsce lądowania

        public Statek()
        {

        }
        public Statek(Statek s)
        {
            this.Srodek = s.GetSrodek();
            Random r = new Random();
            Koniec = new Punkt(r.Next(10, 20), r.Next(40, 50));
        }
        public Statek(Punkt Srodek)
        {
            this.Srodek = Srodek;
            Random r = new Random();
            Koniec = new Punkt(r.Next(10, 20), r.Next(40, 50));
        }
        public Punkt GetSrodek()
        {
            return Srodek;
        }
        public void SetSrodek(Punkt p)
        {
            Srodek = new Punkt(p.GetX(), p.GetY());
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

        public void SetKoniec(Punkt p)
        {
            Koniec = new Punkt(p.GetX(), p.GetY());
        }



    }
}