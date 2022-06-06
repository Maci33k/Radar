
namespace StatkiPowietrzne
{

    class Radar
    {
        static void Main()
        {

            string[,] Radar = new string[20, 20];
            Pusty(Radar);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Wypisz(Radar);
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.D1:
                        DodajSamolot(Radar);
                        break;
                    case ConsoleKey.D2:
                        Czas(Radar);
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine("Dziekujemy za korzystanie z naszych linii lotniczych");
                        break;
                    default:
                        Console.WriteLine("Podano zly przycisk");
                        break;

                }
            } while (k.Key != ConsoleKey.Enter);


            


        }
        public static void Czas(string[,] Radar)//prototyp
        {
            Przesun(Radar);
            Wypisz(Radar);

        }
        public static void Przesun(string[,] Radar)//prototyp
        {
            for (int i = 0; i < Radar.GetLength(0); i++)
            {
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    if (Radar[i, j] == "X" /*Radar[i, j] == "\u2708"*/)
                    {
                        Radar[i, j] = "~";
                        //if czy inny ch sprawdzajacy wspolzedne trasy teraz bedzie 0,0
                        int x = 0;
                        int y = 0;
                        if (x == i && y == j)
                        {

                        }
                        else
                        {
                            if (i - x > 0)
                            {
                                i = i - 1;
                            }
                            if (i - x < 0)
                            {
                                i = i + 1;
                            }
                            if (j - y > 0)
                            {
                                j = j - 1;
                            }
                            if (j - y < 0)
                            {
                                j = j + 1;
                            }
                            //Radar[i, j] = "\u2708";
                            Radar[i, j] = "X";
                        }
                    }
                }
            }

        }


        public static void DodajSamolot(string [,] Radar)//prototyp
        {
            Random r = new();
            int i = r.Next(Radar.GetLength(0));
            if (i == 0 | i == Radar.GetLength(0)-1)
            {
                int j = r.Next(Radar.GetLength(1)-1);
                Radar[i, j] = "X";
                //Radar[i, j] = "\u2708";
                Wypisz(Radar);
            }
            else
            {
                int x = r.Next(2);
                if (x == 0)
                {
                    Radar[i, x] = "X";
                    //Radar[i, x] = "\u2708";
                    Wypisz(Radar);
                }
                else
                {
                    Radar[i, Radar.GetLength(1) - 1] = "X";
                    //Radar[i, Radar.GetLength(1) - 1] = "\u2708";
                    Wypisz(Radar);

                }
            }
            
        }
        public static void Pusty(string[,] Radar)
        {
            for (int i = 0; i < Radar.GetLength(0); i++)
            {
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    //Radar[i, j] = "\u2601";
                    Radar[i, j] = "~";
                }
            }

        }
        public static void Wypisz(string[,] Radar)
        {

            Console.Clear();
            for (int i = 0; i < Radar.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    if (j == Radar.GetLength(1)-1)
                    {

                        Console.Write(Radar[i, j] + "}" +"\n");
                    }
                    else
                    {
                        Console.Write(Radar[i, j] + " ");
                    }
                }
            }
            Console.WriteLine("Wcisnij 1 aby dodac samolot");
            Console.WriteLine("Wcisnij 2 aby przesunac czas do przodu");
            Console.WriteLine("Wcisnij Enter wyjsc");

        }

    }
}



