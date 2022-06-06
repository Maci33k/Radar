namespace StatkiPowietrzne
{
    public class Mapa : Obiekt
    {
        protected List<Obiekt> Obiekty = new();

        public Mapa(double sz, double wys, double dl, double kolor, Punkt srd) : base(sz, wys, dl, kolor, srd)
        {
        }

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