namespace StatkiPowietrzne
{
    public class Punkt
    {
        protected int x;
        protected int y;

        public Punkt()
        {
            x = y = 0;
        }
        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }

    }

}