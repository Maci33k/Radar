using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class Radar
    {
        public void DodajSamolot(string[,] radar, Punkt srodek, int szerokosc, int dlugosc)
        {
            Statek samolot = new Samolot(srodek, szerokosc, dlugosc);
            radar[srodek.GetX(), srodek.GetY()] = samolot.GetZnak();
            for (int i = 0; i <= dlugosc; ++i)
            {
                if (srodek.GetY() + i < radar.GetLength(1) && srodek.GetY() - i >= 0)
                {
                    radar[srodek.GetX(), srodek.GetY() + i] = samolot.GetZnak();
                    radar[srodek.GetX(), srodek.GetY() - i] = samolot.GetZnak();
                }
            }
            for (int i = 0; i <= szerokosc; ++i)
            {
                if (srodek.GetX() + i < radar.GetLength(0) && srodek.GetX() - i >= 0)
                {
                    radar[srodek.GetX() + i, srodek.GetY()] = samolot.GetZnak();
                    radar[srodek.GetX() - i, srodek.GetY()] = samolot.GetZnak();
                }
            }
        }

        public void DodajSmiglowiec(string[,] radar, Punkt srodek, int szerokosc, int dlugosc)
        {
            Statek smiglowiec = new Smiglowiec(srodek, szerokosc, dlugosc);
            radar[srodek.GetX(), srodek.GetY()] = smiglowiec.GetZnak();
            for (int i = 0; i <= dlugosc; ++i)
            {
                if (srodek.GetY() + i < radar.GetLength(1) && srodek.GetY() - i >= 0)
                {
                    radar[srodek.GetX(), srodek.GetY() + i] = smiglowiec.GetZnak();
                    radar[srodek.GetX(), srodek.GetY() - i] = smiglowiec.GetZnak();
                }
            }
            for (int i = 0; i <= szerokosc; ++i)
            {
                if (srodek.GetX() + i < radar.GetLength(0) && srodek.GetX() - i >= 0)
                {
                    radar[srodek.GetX() + i, srodek.GetY()] = smiglowiec.GetZnak();
                    radar[srodek.GetX() - i, srodek.GetY()] = smiglowiec.GetZnak();
                }
            }
        }
        public void DodajSzybowiec(string[,] radar, Punkt srodek, int szerokosc, int dlugosc)
        {
            Statek szybowiec = new Szybowiec(srodek, szerokosc, dlugosc);
            radar[srodek.GetX(), srodek.GetY()] = szybowiec.GetZnak();
            for (int i = 0; i <= dlugosc; ++i)
            {
                if (srodek.GetY() + i < radar.GetLength(1) && srodek.GetY() - i >= 0)
                {
                    radar[srodek.GetX(), srodek.GetY() + i] = szybowiec.GetZnak();
                    radar[srodek.GetX(), srodek.GetY() - i] = szybowiec.GetZnak();
                }
            }
            for (int i = 0; i <= szerokosc; ++i)
            {
                if (srodek.GetX() + i < radar.GetLength(0) && srodek.GetX() - i >= 0)
                {
                    radar[srodek.GetX() + i, srodek.GetY()] = szybowiec.GetZnak();
                    radar[srodek.GetX() - i, srodek.GetY()] = szybowiec.GetZnak();
                }
            }

        }
        public void DodajBalon(string[,] radar, Punkt srodek, int szerokosc, int dlugosc)
        {
            Statek balon = new Balon(srodek, szerokosc, dlugosc);
            radar[srodek.GetX(), srodek.GetY()] = balon.GetZnak();
            for (int i = 0; i <= dlugosc; ++i)
            {
                if (srodek.GetY() + i < radar.GetLength(1) && srodek.GetY() - i >= 0)
                {
                    radar[srodek.GetX(), srodek.GetY() + i] = balon.GetZnak();
                    radar[srodek.GetX(), srodek.GetY() - i] = balon.GetZnak();
                }
            }
            for (int i = 0; i <= szerokosc; ++i)
            {
                if (srodek.GetX() + i < radar.GetLength(0) && srodek.GetX() - i >= 0)
                {
                    radar[srodek.GetX() + i, srodek.GetY()] = balon.GetZnak();
                    radar[srodek.GetX() - i, srodek.GetY()] = balon.GetZnak();
                }
            }
        }


    }



}