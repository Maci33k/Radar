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
                    
                    
                    
                    

            }
        }
    }


}
