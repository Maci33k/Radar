
namespace StatkiPowietrzne
{

    class Prototyp_prymitywny
    {
        static void Main()
        {

            string[,] Radar = new string[20, 20];
            Pusty(Radar);
            //Console.OutputEncoding = System.Text.Encoding.UTF8; to i wszystkie \u(costam) jest do emoji czyt. do zabawy pozniej jesli bedzie czas
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
        public static void Czas(string[,] Radar)//to nie wiem czemu istnieje? dlaczego ja istnieje? kim jestesmy? dokad zmierzamy?
        {
            Przesun(Radar);
            Wypisz(Radar);

        }
        public static void Przesun(string[,] Radar)//prototyp przesuwania czasu sie zrobi automatycznie jakos pozniej i przerobi to w wykrywanie kolizji 
        {
            //OD WSPOLZEDNYCH SRODKA BEDZIE SIE SPRAWDZALO CZY TE X CZY INNE BALONY NADAL TAM SA I WTEDY JESLI SA TO GIT A JAK NIE TO DODAJA SIE NA POZIOMIE PRZESUWANIA CZYLI TU XDD I JAK JAKIS JEST POZA SAMOLTOEM TAK JAKBY TO GO USUWA BUM
            for (int i = 0; i < Radar.GetLength(0); i++)
            {
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    if (Radar[i, j] == "X" /*Radar[i, j] == "\u2708"*/)
                    {
                        Radar[i, j] = "~";
                        //if czy inny ch sprawdzajacy wspolzedne trasy teraz bedzie 0,0
                        int x = 0;//temp na x Punktu
                        int y = 0;//temp na y Punktu
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


        public static void DodajSamolot(string [,] Radar)//prototyp generacji losowego samolotu narazie tylko jeden typ
        {
            Random r = new();
            int i = r.Next(Radar.GetLength(0));
            int szerokosc = 2;//temp na szerokosc samolotu
            int wysokosc = 0;//temp na dlugosc samolotu
            if (i == 0 | i == Radar.GetLength(0)-1)
            {
                int j = r.Next(Radar.GetLength(1)-1);
                Radar[i, j] = "X";
                for (int w = 0; w <= wysokosc; w++)
                {
                    if (i + w <= Radar.GetLength(0) - 1)//dolna dl
                    {
                        Radar[i + w, j] = "X";
                    }
                    if (i - w >= 0)//gorna dl
                    {
                        Radar[i - w, j] = "X";
                    }

                }
                for (int s = 0; s <= szerokosc; s++)
                {
                    if (j + s <= Radar.GetLength(1) - 1)//prawa szer
                    {
                        Radar[i, j + s] = "X";
                    }
                    if (j - 1 >= 0)//lewa szer
                    {
                        Radar[i, j - s] = "X";
                    }
                    //Radar[i, j] = "\u2708";
                    Wypisz(Radar);
                }
            }
            else
            {
                int x = r.Next(2);
                if (x == 0)
                {
                    Radar[i, x] = "X";
                    for (int w = 0; w <= wysokosc; w++)
                    {
                        if (i + w <= Radar.GetLength(0) - 1)//dolna dl
                        {
                            Radar[i + w, x] = "X";
                        }
                        if (i - w >= 0)//gorna dl
                        {
                            Radar[i - w, x] = "X";
                        }

                    }
                    for (int s = 0; s <= szerokosc; s++)
                    {
                        if (x + s <= Radar.GetLength(1) - 1)//prawa szer
                        {
                            Radar[i, x + s] = "X";
                        }
                        if (x - 1 >= 0)//lewa szer
                        {
                            Radar[i, x - s] = "X";
                        }
                    }
                    //Radar[i, x] = "\u2708";
                    Wypisz(Radar);
                }
                else
                {
                    x = Radar.GetLength(1) - 1;
                    Radar[i, Radar.GetLength(1) - 1] = "X";
                    for(int w = 0; w <= wysokosc; w++)
                    {
                        if (i + w <= Radar.GetLength(0) - 1)//dolna dl
                        {
                            Radar[i + w, x] = "X";
                        }
                        if (i - w >= 0)//gorna dl
                        {
                            Radar[i - w, x] = "X";
                        }

                    }
                    for(int s = 0; s <= szerokosc; s++)
                    {
                        if (x + s <= Radar.GetLength(1) - 1)//prawa szer
                        {
                            Radar[i, x + s] = "X";
                        }
                        if (x - 1 >= 0)//lewa szer
                        {
                            Radar[i, x - s] = "X";
                        }
                    }
                    //Radar[i, Radar.GetLength(1) - 1] = "\u2708";
                    Wypisz(Radar);

                }
            }
            
        }
        public static void Pusty(string[,] Radar)//strasznie okrojony prototyp obrazu. zeruje niebo czyt. usuwa wszystkie elementy znajdujace sie na radarze lub inaczej wypelnia caly radar w polach pustych czyli ~ 
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
        public static void Wypisz(string[,] Radar)//to takie pomocnicze do pokazywania graficznego co sie dzieje akurat na radarze. pewnie zostanie jako radar po usprawnieniach. wydaje mi sie ze powinna byc to metoda w mainie juz
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



