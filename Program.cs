using System;
using System.Linq;
namespace StatkiPowietrzne
{

    class Prototyp_prymitywny
    {

        static void Main()
        {

            string[,] Radar = new string[40, 94];
            NaRadar rad = new();



            Pusty(Radar);
            
            Wypisz(Radar);
            Punkt punkt = new Punkt(15, 15);
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.D1:
                        WygenerujSamolot(Radar, rad);
                        break;
                    case ConsoleKey.D2:
                        Przesun(Radar, rad);
                        Wypisz(Radar);
                        break;
                    case ConsoleKey.D3:
                        Pusty(Radar);
                        Wypisz(Radar);
                        rad.GetStatki().GetLista().Clear();
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine();
                        Console.WriteLine("Podaj numer statku powietrznego");
                        int indeks = int.Parse(Console.ReadLine());
                        rad.Sledzenie(indeks,Radar);
                        break;
                    
                    case ConsoleKey.D8:
                        WygenerujSamolot(Radar, punkt, rad);

                        break;
                    
                    case ConsoleKey.D9:
                        Przesun(Radar, "X", punkt, 2, 2);

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
        public static void Przesun(string[,] Radar, NaRadar rad)
        {
            Przesun(Radar, "X", rad);
            Przesun(Radar, "#", rad);
            Przesun(Radar, "*", rad);
            Przesun(Radar, "@", rad);
        }
        public static void Przesun(string[,] Radar, string znak, Punkt sr, int sz, int dl)
        {
            //OD WSPOLZEDNYCH SRODKA BEDZIE SIE SPRAWDZALO CZY TE X CZY INNE BALONY NADAL TAM SA I WTEDY JESLI SA TO GIT A JAK NIE TO DODAJA SIE NA POZIOMIE PRZESUWANIA CZYLI TU XDD I JAK JAKIS JEST POZA SAMOLTOEM TAK JAKBY TO GO USUWA BUM

            int i = sr.GetX();
            int j = sr.GetY();
            if (Radar[i, j] == znak /*Radar[i, j] == "\u2708"*/)
            {
                Radar[i, j] = " ";
                for (int s = 0; s <= sz; s++)
                {
                    if (j + s <= Radar.GetLength(1) - 1)//prawa szer
                    {
                        if (Radar[i, j + s] == znak) Radar[i, j + s] = " ";

                    }
                    if (j - s >= 0)//lewa szer
                    {
                        if (Radar[i, j - s] == znak) Radar[i, j - s] = " ";

                    }
                }
                for (int d = 0; d <= dl; d++)
                {
                    if (i + d <= Radar.GetLength(0) - 1)//dolna dl
                    {
                        if (Radar[i + d, j] == znak) Radar[i + d, j] = " ";

                    }

                    if (i - d >= 0)//gorna dl
                    {
                        if (Radar[i - d, j] == znak) Radar[i - d, j] = " ";
                    }
                }
                //if czy inny ch sprawdzajacy wspolzedne trasy teraz bedzie 0,0
                int x = 5;//temp na x Punktu
                int y = 5;//temp na y Punktu
                if (x == i && y == j)
                {

                }
                else
                {
                    if (i > x)
                    {
                        i = i - 1;
                    }
                    if (i < x)
                    {
                        i = i + 1;
                    }
                    if (j > y)
                    {
                        j = j - 1;
                    }
                    if (j < y)
                    {
                        j = j + 1;
                    }
                    Radar[i, j] = znak;
                    for (int s = 0; s <= sz; s++)
                    {
                        if (j + s <= Radar.GetLength(1) - 1)//prawa szer
                        {
                            if (Radar[i, j + s] != znak) Radar[i, j + s] = znak;
                        }
                        if (j - s >= 0)//lewa szer
                        {
                            if (Radar[i, j - s] != znak) Radar[i, j - s] = znak;
                        }

                    }
                    for (int d = 0; d <= dl; d++)
                    {
                        if (i + d <= Radar.GetLength(0) - 1)//dolna dl
                        {
                            if (Radar[i + d, j] != znak) Radar[i + d, j] = znak;
                        }
                        if (i - d >= 0)//gorna dl
                        {
                            if (Radar[i - d, j] != znak) Radar[i - d, j] = znak;
                        }

                    }
                    sr.SetX(i);
                    sr.SetY(j);

                }
            }
            Wypisz(Radar);



        }
        public static void Przesun(string[,] Radar, string znak, NaRadar rad)//prototyp przesuwania czasu sie zrobi automatycznie jakos pozniej i przerobi to w wykrywanie kolizji 
        {
            //OD WSPOLZEDNYCH SRODKA BEDZIE SIE SPRAWDZALO CZY TE X CZY INNE BALONY NADAL TAM SA I WTEDY JESLI SA TO GIT A JAK NIE TO DODAJA SIE NA POZIOMIE PRZESUWANIA CZYLI TU XDD I JAK JAKIS JEST POZA SAMOLTOEM TAK JAKBY TO GO USUWA BUM

            foreach (Statek s in rad.GetStatki().GetLista())
            {
                int x = s.GetKoniec().GetX();
                int y = s.GetKoniec().GetY();
                int i = s.GetSrodek().GetX();
                int j = s.GetSrodek().GetY();
                if (Radar[i, j] == znak)
                {
                    Radar[i, j] = " ";
                    if (i == x && j == y)
                    {
                        Radar[i, j] = " ";
                        continue;
                    }

                    Punkt p = new Punkt(i, j);
                    if (x > Radar.GetLength(0) && y > Radar.GetLength(1)) Radar[i, j] = " ";
                    if (i > x)
                    {
                        if (Radar[i - 1, j] == null || Radar[i - 1, j] == " ")
                        {
                            p.SetX(--i);

                        }
                    }

                    if (i < x && i + 1 < Radar.GetLength(0))
                    {
                        if (Radar[i + 1, j] == null || Radar[i + 1, j] == " ")
                        {
                            p.SetX(++i);

                        }
                    }

                    if (j > y)
                    {
                        if (Radar[i, j - 1] == null || Radar[i, j - 1] == " ")
                        {
                            p.SetY(--j);
                        }
                    }

                    if (j < y && j + 1 < Radar.GetLength(1))
                    {
                        if (Radar[i, j + 1] == null || Radar[i, j + 1] == " ")
                        {
                            p.SetY(++j);
                        }
                    }

                    if (i == 0 || i + 1 == Radar.GetLength(0) || j == 0 || j + 1 == Radar.GetLength(1))
                    {
                        Radar[i, j] = " ";
                        p.SetX(0);
                        p.SetY(0);
                        s.SetSrodek(p);
                        continue;
                    }
                    //Radar[i, j] = "\u2708";
                    if (i < Radar.GetLength(0) && j < Radar.GetLength(1))
                    {
                        Radar[i, j] = znak;
                        s.SetSrodek(p);
                    }

                }

            }
            /*for (int i = 0; i < Radar.GetLength(0); i++)
            {
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    if (Radar[i, j] == znak /*Radar[i, j] == "\u2708"/)
                    {
                        Statek a = new Statek();
                        foreach (Statek s in rad.GetStatki().GetLista()){
                            if (i == s.GetSrodek().GetX() && j==s.GetSrodek().GetY())
                            {
                                Punkt p = new Punkt(s.GetKoniec().GetX(), s.GetKoniec().GetY());
                                a.SetKoniec(p);
                                break;
                            }
                        }
                        Radar[i, j] = " ";
                        if(a.GetKoniec() != null)
                        {
                            x = a.GetKoniec().GetX();
                            y = a.GetKoniec().GetY();
                        }
                        
                        //if czy inny ch sprawdzajacy wspolzedne trasy teraz bedzie 0,0
                        if (x == i && y == j)
                        {
                            Radar[x, y] = null;                            
                            rad.GetStatki().GetLista().Remove(a);
                            break;
                        }
                        else
                        {
                            if (i> x)
                            {
                                if(Radar[i-1,j] == null|| Radar[i - 1, j] == " ") i--;
                            }
                            if (i  < x && i+1<Radar.GetLength(0))
                            {
                                if(Radar[i+1, j]==null || Radar[i + 1, j] == " ") i++;
                            }
                            if (j  > y)
                            {
                                if(Radar[i,j-1]==null || Radar[i, j-1] == " ") j--;
                            }
                            if (j  < y && j + 1 < Radar.GetLength(1))
                            {
                                if(Radar[i,j+1]==null || Radar[i, j+1] == " ") j++;
                            }
                            
                            //Radar[i, j] = "\u2708";
                            if(i<Radar.GetLength(0) && j<Radar.GetLength(1)) Radar[i, j] = znak;
                        }
                    }
                }
            }*/

        }

        public static void WygenerujSamolot(string[,] Radar, NaRadar rad)//prototyp generacji losowego samolotu narazie tylko jeden typ
        {
            Random r = new();
            int i = r.Next(0, Radar.GetLength(0));
            if (i > 0 || i < Radar.GetLength(0) - 1)
            {
                int j = r.Next(Radar.GetLength(1) - 1);
                Punkt sr = new Punkt(i, j);
                WygenerujSamolot(Radar, sr, rad);


            }
            else
            {
                int x = r.Next(2);
                if (x == 0)
                {
                    Punkt sr = new Punkt(i, x);
                    WygenerujSamolot(Radar, sr, rad);



                }
                else
                {
                    x = Radar.GetLength(1) - 1;
                    Punkt sr = new Punkt(i, x);
                    WygenerujSamolot(Radar, sr, rad);


                }
            }
        }
        public static void WygenerujSamolot(string[,] Radar, Punkt sr, NaRadar rad)//prototyp generacji losowego samolotu narazie tylko jeden typ
        {
            Random r = new();
            int i = sr.GetX();
            int j = sr.GetY();
            int znakr = r.Next(0, 4);
            int szerokosc;
            int dlugosc;
            switch (znakr)
            {
                case 0:
                    szerokosc = r.Next(2, 4);
                    dlugosc = r.Next(2, 4);
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@")
                    {
                        rad.DodajSamolot(Radar, sr, szerokosc, dlugosc);
                    }
                    else
                    {
                        WygenerujSamolot(Radar, rad);
                    }
                    break;
                case 1:
                    szerokosc = 0;
                    dlugosc = 0;
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@")
                    {
                        rad.DodajBalon(Radar, sr);
                    }
                    else
                    {
                        WygenerujSamolot(Radar, rad);
                    }
                    break;
                case 2:
                    szerokosc = r.Next(1, 3);
                    dlugosc = r.Next(1, 3);
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@")
                    {
                        rad.DodajSzybowiec(Radar, sr);
                    }
                    else
                    {
                        WygenerujSamolot(Radar, rad);
                    }
                    break;
                case 3:
                    szerokosc = r.Next(0, 2);
                    dlugosc = r.Next(0, 2);
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@")
                    {
                        rad.DodajSmiglowiec(Radar, sr, szerokosc, dlugosc);
                    }
                    else
                    {
                        WygenerujSamolot(Radar, rad);
                    }
                    break;
                default:

                    szerokosc = 2000000;
                    dlugosc = 2005151;
                    break;

            }



            Wypisz(Radar);


            //mark


        }
        public static void Pusty(string[,] Radar)//strasznie okrojony prototyp obrazu. zeruje niebo czyt. usuwa wszystkie elementy znajdujace sie na radarze lub inaczej wypelnia caly radar w polach pustych czyli ~ 
        {
            for (int i = 0; i < Radar.GetLength(0); i++)
            {
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    //Radar[i, j] = "\u2601";
                    Radar[i, j] = " ";
                }
            }

        }
        public static void Wypisz(string[,] Radar)//to takie pomocnicze do pokazywania graficznego co sie dzieje akurat na radarze. pewnie zostanie jako radar po usprawnieniach. wydaje mi sie ze powinna byc to metoda w mainie juz
        {

            Console.Clear();
            for (int i = 0; i < (2 * Radar.GetLength(1)) + 1; i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
            for (int i = 0; i < Radar.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    if (j == Radar.GetLength(1) - 1)
                    {

                        Console.Write(Radar[i, j] + "|" + "\n");
                    }
                    else
                    {
                        Console.Write(Radar[i, j] + " ");
                    }
                }
            }
            for (int i = 0; i < (2 * Radar.GetLength(1)) + 1; i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
            Console.WriteLine("Wcisnij 1 aby wygenerowac samolot");
            Console.WriteLine("Wcisnij 2 aby przesunac czas do przodu");
            Console.WriteLine("Wcisnij 3 aby wyczyscic obraz");
            Console.WriteLine("Wcisnij 4 aby sledzic statek powietrzny");
            Console.WriteLine("Wcisnij Enter wyjsc");

        }

    }
}