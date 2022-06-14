namespace StatkiPowietrzne
{
    public class Mapa
    {
        private List<Obiekt> Obiekty = new();

        public Mapa()
        {
        }

        //Metoda pozwala wczytac z wybranego pliku wspolzedne obiektow znajdujacych sie na radarze
        public void ZalaczMape(string[,] radar, string NazwaPlikuMapy)
        {
            StreamReader read = new StreamReader(NazwaPlikuMapy);
            foreach (string line in System.IO.File.ReadLines(NazwaPlikuMapy))
            {
                //format pliku:srodekx srodeky
                string[] par = read.ReadLine().Split(' ');
                Punkt p = new(int.Parse(par[0]), int.Parse(par[1]));
                DodajObiekt(radar, p);
            }
            read.Close();


        }
        //Metoda dodajaca obiekty do listy 
        public void DodajDoObiekty(Obiekt obiekt)
        {
            Obiekty.Add(obiekt);
        }
        //Metoda dodajaca nowy obiekt
        public void DodajObiekt(string[,] radar, Punkt srd)
        {
            Obiekt obiekt = new(srd);
            DodajDoObiekty(obiekt);
            radar[srd.GetX(), srd.GetY()] = "O";

        }

    }

}