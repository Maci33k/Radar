namespace StatkiPowietrzne
{
    public class Linia : Punkt
    {
        protected Punkt poczatek;
        protected Punkt koniec;
        protected int predkosc;
        protected int wysokosc;

        public Linia(Punkt start, Punkt koniec, int prd, int wys)
        {
            this.poczatek = start;
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

}