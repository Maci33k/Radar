using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using StatkiPowietrzne;
namespace StatkiPowietrzne
{
    public class Radar
    {
        private Mapa MapaTerenu;
        private List<Statek> StatkiPowietrzne;
        private Obraz Wyswietlacz;

        public Radar(Mapa Teren, Obraz Ekran)
        {
            MapaTerenu = Teren;
            Wyswietlacz = Ekran;
            StatkiPowietrzne = new List<Statek>();
        }

        public void DodajStatek(Statek s)
        {
            StatkiPowietrzne.Add(s);
        }

        public void WygenerujStatek()
        {
            Random rnd = new Random();
            switch (rnd.Next(0, 3))
            {
                case 0:
                    Samolot a;
                    Trasa l = new Trasa();
                    a = new Samolot(l, rnd.NextDouble() + rnd.Next(30, 90), rnd.NextDouble() + rnd.Next(30, 90), rnd.NextDouble() + rnd.Next(10, 20));
                    StatkiPowietrzne.Add(a);
                    break;

                case 1:
                    Smiglowiec b;
                    l = new Trasa();
                    b = new Smiglowiec(l, rnd.NextDouble() + rnd.Next(4, 70), rnd.NextDouble() + rnd.Next(4, 37), rnd.NextDouble() + rnd.Next(2, 13));
                    StatkiPowietrzne.Add(b);
                    break;

                case 2:
                    Balon c;
                    l = new Trasa();
                    c = new Balon(l, rnd.NextDouble() + rnd.Next(10, 20), rnd.NextDouble() + rnd.Next(10, 20), rnd.NextDouble() + rnd.Next(20, 25));
                    StatkiPowietrzne.Add(c);
                    break;

                case 3:
                    Szybowiec d;
                    l = new Trasa();
                    d = new Szybowiec(l, rnd.NextDouble() + rnd.Next(10, 25), rnd.NextDouble() + rnd.Next(5, 15), rnd.NextDouble() + rnd.Next(1, 2));
                    StatkiPowietrzne.Add(d);
                    break;
            }
        }

        public void WykryjNiebezpieczenstwo()
        {
            foreach(Statek s in StatkiPowietrzne)
            {

            }
        }

        public void EdytujLot(int ID, Trasa ZmienionyLot)
        {
            StatkiPowietrzne[ID].SetLot(ZmienionyLot);
        }

        public void UsunStatek(int ID)
        {
            StatkiPowietrzne.RemoveAt(ID);
        }

        public void RysujStatek(Statek s)
        {

        }

        public void RysujObiekt(Mapa m)
        {

        }

    }


}
