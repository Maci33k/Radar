using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Radar
{
    public class Punkt
    {
        protected int x;
        protected int y;

        public Punkt()
        {
            x = y = 0;
        }
        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

    }
    public class Linia : Punkt
    {
        protected Punkt poczatek;
        protected Punkt koniec;
        protected int predkosc;
        protected int wysokosc;

        public Linia(Punkt start, Punkt koniec, int prd, int wys)
        {
            //if sprawdzajacy czy koordynaty sa poza mapa
            this.poczatek = start;
            //if sprawdzajacy czy koordynaty sa poza mapa
            this.koniec = koniec;
            if (prd > 0)
            {
                this.predkosc = prd;
            }
            else
            {
                throw new ArgumentException("Statek powietrzny wzial i wybuchl");
            }
            if (wys > 150)
            {
                this.wysokosc = wys;
            }
            else
            {
                this.wysokosc = 150;
                //https://calypteaviation.com/jak-nisko-mozna-leciec/
                //throw new ArgumentException("Uwazaj na stalowe brzozy");
            }
        }
        public Punkt GetPoczatek()
        {
            return poczatek;
        }
        public Punkt GetKoniec()
        {
            return koniec;
        }
        public int GetPredkosc()
        {
            return predkosc;
        }

    }
    public class Obiekt : Punkt 
    {
        protected double szerokosc;
        protected double wysokosc;
        protected double dlugosc;
        protected double kolor; //ja tu bym chyba string pierdolna
        protected Punkt srodek;
        protected Trasa sciezka;//???????

        public Obiekt(double sz, double dl, double wys, double kolor, Punkt srd)
        {
            if (sz > 0)
            {
                this.szerokosc = sz;
            }
            else
            {
                throw new ArgumentException("Error");
            }
            if (wys > 0)
            {
                this.wysokosc = wys;
            }
            else
            {
                throw new ArgumentException("Error");
            }
            if (dl > 0)
            {
                this.dlugosc = dl;
            }
            else
            {
                throw new ArgumentException("Error");
            }
            this.kolor = kolor;
            this.srodek = srd;
        }
        public double GetSzerokosc()
        {
            return szerokosc;
        }
        public double GetDlugosc()
        {
            return dlugosc;
        }
        public double GetWysokosc()
        {
            return wysokosc;
        }
        //tu nawet getkolor nie ma to nie wiem


    }
    public class Mapa : Obiekt
    {
        protected List<Obiekt> Obiekty = new();

        public void ZalaczMape(string NazwaPlikuMapy, StreamReader read)
        {
            foreach (string line in System.IO.File.ReadLines(NazwaPlikuMapy))
            {
                //format pliku: sz dl wys kolor srodekx srodeky
                string[] par = read.ReadToEnd().Split(' ');
                Punkt p = new(int.Parse(par[4]), int.Parse(par[5]));
                Obiekty.Add(new Obiekt(int.Parse(par[0]), int.Parse(par[1]), int.Parse(par[2]), int.Parse(par[3]), p));
            }
        }
        public int GetObiekty()
        {
            throw new NotImplementedException();
        }
    }



}