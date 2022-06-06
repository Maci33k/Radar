namespace StatkiPowietrzne
{
    public class Obiekt : Punkt
    {
        protected double szerokosc;
        protected double wysokosc;
        protected double dlugosc;
        protected double kolor; //kolor w c# ogarnac
        protected Punkt srodek;
        protected Trasa sciezka;//obiekt ruchomy

        public Obiekt(double sz, double wys, double dl, double kolor, Punkt srd)
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
        public Obiekt(double sz, double wys, double dl, double kolor, Punkt srd, Trasa sc)
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
            this.sciezka = sc;
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


    }

}