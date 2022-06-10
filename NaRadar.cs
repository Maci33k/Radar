using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    public class NaRadar
    {
        public void DodajStatek( string[,] radar, Punkt srodek, int szerokosc, int dlugosc,string znak)
        {
            Samolot samolot = new Samolot(srodek, szerokosc, dlugosc, znak);
            radar[srodek.GetX(), srodek.GetY()] = znak;
            for (int i = 0; i <= dlugosc; ++i)
            {
                radar[srodek.GetX(), srodek.GetY() + i] = znak;
                radar[srodek.GetX(), srodek.GetY() - i] = znak;
            }
            for (int i = 0; i <= szerokosc; ++i)
            {
                radar[srodek.GetX() + i, srodek.GetY()] = znak;
                radar[srodek.GetX() - i, srodek.GetY()] = znak;
            }
        }
        public void DodajX(string[,] radar, Punkt Srodek, int szerokosc, int dlugosc, string znak)
        {
            Samolot samolot = new Samolot(Srodek, szerokosc, dlugosc, znak);
            radar[Srodek.GetX(), Srodek.GetY()] = znak;
        }

    }
}
