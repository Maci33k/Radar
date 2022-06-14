using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiPowietrzne
{
    // Klasa przechowująca pola reprezentujące statek na płaszczyźnie radaru, współrzędna x i y
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
        public int SetX(int x) => this.x = x;
        public int SetY(int y) => this.y = y;
    }
}