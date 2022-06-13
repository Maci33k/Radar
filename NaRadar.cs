using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StatkiPowietrzne
{
    public class NaRadar
    {
        ListaStatkow lista = new ListaStatkow();
        
        public void DodajSamolot( string[,] radar, Punkt srodek, int szerokosc, int dlugosc)
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
        public ListaStatkow GetStatki()
        {
            return lista;
        }
        

    }



}




