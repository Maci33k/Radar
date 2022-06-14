using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StatkiPowietrzne
{
    // Klasa NaRadar jest pośrednikiem między statkami a radarem, tutaj są tworzone oraz rysowane
    // na radar poszczególne statki powietrzne
    public class NaRadar 
    {
        
        private ListaStatkow lista = new ListaStatkow();

        // Metody do dodawania oraz rysowania statków powietrznych na radar
        public void DodajSamolot(string[,] radar, Punkt srodek, int szerokosc, int dlugosc)
        {
            Statek samolot = new Samolot(srodek);
            lista.DodajDoListy(samolot);
            radar[srodek.GetX(), srodek.GetY()] = samolot.GetZnak();

        }

        public void DodajSmiglowiec(string[,] radar, Punkt srodek, int szerokosc, int dlugosc)
        {
            Statek smiglowiec = new Smiglowiec(srodek);
            lista.DodajDoListy(smiglowiec);
            radar[srodek.GetX(), srodek.GetY()] = smiglowiec.GetZnak();

        }
        public void DodajSzybowiec(string[,] radar, Punkt srodek)
        {
            Statek szybowiec = new Szybowiec(srodek);
            lista.DodajDoListy(szybowiec);
            radar[srodek.GetX(), srodek.GetY()] = szybowiec.GetZnak();
        }
        public void DodajBalon(string[,] radar, Punkt srodek)
        {
            Statek balon = new Balon(srodek);
            lista.DodajDoListy(balon);
            radar[srodek.GetX(), srodek.GetY()] = balon.GetZnak();

        }
        // Pobiera aktualną listę statków
        public ListaStatkow GetStatki()
        {
            return lista;
        }
       // Metoda umożliwia śledzenie parametrów dotyczących lotu konkretnego statku powietrznego
       // oraz rysuje punkty końcowe na radarze
        public void Sledzenie(int indeks, string[,] radar)
        {
            string statek = "statek";
            if (lista.GetStatek(indeks - 1).GetZnak() == "X")
                statek = "Samolot";
            else if (lista.GetStatek(indeks - 1).GetZnak() == "#")
                statek = "Smiglowiec";
            else if (lista.GetStatek(indeks - 1).GetZnak() == "@")
                statek = "Balon";
            else if (lista.GetStatek(indeks - 1).GetZnak() == "*")
                statek = "Szybowiec";
            Console.WriteLine();
            Console.WriteLine("Statek nr" + indeks + ": " + statek);
            Console.WriteLine("Położenie:   (X = " +  lista.GetStatek(indeks - 1).GetSrodek().GetX() + ", Y = " +  lista.GetStatek(indeks - 1).GetSrodek().GetY() + ")");
            Console.WriteLine("Leci w kierunku punktu " + "(X = " + lista.GetStatek(indeks - 1).GetKoniec().GetX() + ", Y = "  + lista.GetStatek(indeks - 1).GetKoniec().GetY() + ")");
            radar[lista.GetStatek(indeks - 1).GetKoniec().GetX(), lista.GetStatek(indeks - 1).GetKoniec().GetY()] = "D" + indeks;
        }
        


    }



}


