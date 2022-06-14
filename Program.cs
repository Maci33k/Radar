using System;
using System.Linq;
namespace StatkiPowietrzne
{

    class Program
    {

        static void Main()
        {
            //Podstawowe czynnosci zwiazane z inicjalizacja programu, alokacja pamieci zmiennych uzywanych w calym programie
            string[,] Radar = new string[40, 94];
            NaRadar rad = new();
            Mapa map = new();
            Pusty(Radar);
            Wypisz(Radar);
            
            //Ustawienie wybranego punktu "okolosrodkowego"
            Punkt punkt = new Punkt(15, 15);
            
            //Menu kontekstowe
            ConsoleKeyInfo k;
            do
            {
                k = Console.ReadKey();
                switch (k.Key)
                {

                    //Losowe generowanie samolotu
                    case ConsoleKey.D1:
                        WygenerujSamolot(Radar, rad);
                        break;

                    //Przesuniecie czasu
                    case ConsoleKey.D2:
                        Przesun(Radar, rad);
                        Wypisz(Radar);
                        break;

                    //Czyszczenie radaru oraz obrazu
                    case ConsoleKey.D3:
                        Pusty(Radar);
                        Wypisz(Radar);
                        rad.GetStatki().GetLista().Clear();
                        break;

                    //Modul sledzenia statku powietrznego po jego indeksie
                    case ConsoleKey.D4:
                        Console.WriteLine();
                        Console.WriteLine("Podaj numer statku powietrznego (indeks na ktorym znajduje sie na liscie): ");
                        int indeks = int.Parse(Console.ReadLine());
                        if (rad.GetStatki().GetLista().Count()>0) rad.Sledzenie(indeks, Radar); //Sprawdzenie czy indeks istnieje na liscie
                        else Console.WriteLine("Indeks wykracza poza liczbe statkow na lisice wynoszacej " + rad.GetStatki().GetLista().Count());
                        break;

                    //Zalaczanie mapy obiektow nieruchomych 
                    case ConsoleKey.D5:
                        Console.WriteLine();
                        Console.WriteLine("Podaj nazwe pliku: ");
                        string nazwa = Console.ReadLine();
                        if (File.Exists(nazwa))
                        {

                            map.ZalaczMape(Radar, nazwa);
                            Wypisz(Radar);
                        }
                        else
                        {
                            Console.WriteLine("Plik nie istnieje");
                        }

                        break;


                    //Zakonczenie programu
                    case ConsoleKey.Enter:
                        Console.WriteLine("Dziekujemy za korzystanie z naszych linii lotniczych");
                        break;


                    default:
                        Console.WriteLine("Podano zly przycisk");
                        break;

                }
            } while (k.Key != ConsoleKey.Enter);





        }

        //Pierwsze przeciazenie Przesun sluzace do wywolania przesuniecia na "obrazie", ktore przesuwa wszystkie znaki
        public static void Przesun(string[,] Radar, NaRadar rad)
        {
            Przesun(Radar, "X", rad); //wywolanie dla samolotow
            Przesun(Radar, "#", rad); //wywolanie dla smiglowcow
            Przesun(Radar, "*", rad); //wywolanie dla szybowcow
            Przesun(Radar, "@", rad); //wywolanie dla balonow
        }

        //Drugie przeciazenie, ktore wykonuje sie dla konkretnego znaku na obrazie 
        public static void Przesun(string[,] Radar, string znak, NaRadar rad)
        {
            string[] symbole = { "#", "@", "X", "*", "O" }; //oznaczenie symboli powodujacych kolizje

            foreach (Statek s in rad.GetStatki().GetLista().ToList())
            {
                int x = s.GetKoniec().GetX(); //Wspolrzedna x konca trasy
                int y = s.GetKoniec().GetY(); //Wspolrzedna y konca trasy
                int i = s.GetSrodek().GetX(); //Aktualna pozycja na Radarze[i,...]
                int j = s.GetSrodek().GetY(); //Aktualna pozycja na Radarze[...,j]

                if (Radar[i, j] == znak) //Weryfikacja, dla ktorego znaku wywolana zostala metoda
                {
                    Radar[i, j] = " "; //Rozpoczecie ruchu, ktore przypuszcza sie, ze poskutkuje zmiana pozycji

                    //Sprawdzenie czy statek powietrzny dotarl do swojego celu
                    if (i == x && j == y)
                    {
                        Radar[i, j] = " ";
                        rad.GetStatki().GetLista().Remove(s); //Usuniecie samolotu jezeli dotarl do celu
                        continue;
                    }

                    Punkt p = new Punkt(i, j); //Stworzenie punktu, ktory bedzie ustalac pozycje po odbytym ruchu


                    if (x > Radar.GetLength(0) && y > Radar.GetLength(1)) Radar[i, j] = " "; //Sprawdzenie poprawnosci wygenerowania konca trasy
                    if (i > x) //Sprawdzenie czy osiegnieta zostala wspolrzedna x konca trasy
                    {
                        if (!(symbole.Contains(Radar[i-1,j]))) //Sprawdzanie kolizji w przypadku ruchu do gory
                        {
                            p.SetX(--i);

                        }
                        else
                        {
                            Console.WriteLine("Wykryto kolizje na wspolrzednych (" + (i-1) + ", " + j + "). Wprowadz kierunek, w ktorym ma poruszac sie statek:" +
                                "\nN - na polnosc (w gore radaru)," +
                                "\nE - na wschod (w prawo)," +
                                "\nS - na poludnie (w dol radaru)," +
                                "\nW - za zachod (w lewo)," +
                                "\nWcisniecie innego klawisza spowoduje zatoczenie kolka na wspolrzednych, na ktorych znajduje sie statek powietrzny!");
                            ConsoleKeyInfo k = Console.ReadKey();
                            switch (k.Key)
                            {
                                case ConsoleKey.S:
                                    if (i + 1 < Radar.GetLength(0) && (Radar[i + 1, j] == null || Radar[i + 1, j] == " ")) p.SetX(++i);
                                    else Console.WriteLine("Zwrot na poludnie rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.E:
                                    if (j + 1 < Radar.GetLength(1) && (Radar[i, j + 1] == null || Radar[i, j + 1] == " ")) p.SetY(++j);
                                    else Console.WriteLine("Zwrot na wschod rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.N:
                                    Console.WriteLine("Nie mozesz leciec na polnoc, skoro tam wykryto kolizje!");
                                    break;

                                case ConsoleKey.W:
                                    if (j - 1 < 0 && (Radar[i, j - 1] == null || Radar[i, j - 1] == " ")) p.SetY(--j);
                                    else Console.WriteLine("Zwrot na wschod rowniez doprowadzi do kolizji!");
                                    break;

                                default:
                                    break;

                            }
                        }
                    }

                    if (i < x && i + 1 < Radar.GetLength(0)) //Sprawdzenie czy osiegnieta zostala wspolrzedna x konca trasy
                    {
                        if (!(symbole.Contains(Radar[i + 1, j])))//Sprawdzenie kolizji w przypadku ruchu do dolu
                        {
                            p.SetX(++i);

                        }
                        else
                        {
                            Console.WriteLine("Wykryto kolizje na wspolrzednych (" + (i - 1) + ", " + j + "). Wprowadz kierunek, w ktorym ma poruszac sie statek:" +
                                "\nN - na polnosc (w gore radaru)," +
                                "\nE - na wschod (w prawo)," +
                                "\nS - na poludnie (w dol radaru)," +
                                "\nW - za zachod (w lewo)," +
                                "\nWcisniecie innego klawisza spowoduje zatoczenie kolka na wspolrzednych, na ktorych znajduje sie statek powietrzny!");
                            ConsoleKeyInfo k = Console.ReadKey();
                            switch (k.Key)
                            {
                                case ConsoleKey.N:
                                    if (i - 1 < 0 && (Radar[i - 1, j] == null || Radar[i - 1, j] == " ")) p.SetX(--i);
                                    else Console.WriteLine("Zwrot na polnoc rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.E:
                                    if (j + 1 < Radar.GetLength(1) && (Radar[i, j + 1] == null || Radar[i, j + 1] == " ")) p.SetY(++j);
                                    else Console.WriteLine("Zwrot na wschod rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.S:
                                    Console.WriteLine("Nie mozesz leciec na poludnie, skoro tam wykryto kolizje!");
                                    break;

                                case ConsoleKey.W:
                                    if (j - 1 < 0 && (Radar[i, j - 1] == null || Radar[i, j - 1] == " ")) p.SetY(--j);
                                    else Console.WriteLine("Zwrot na wschod rowniez doprowadzi do kolizji!");
                                    break;

                                default:
                                    break;

                            }
                        }
                    }

                    if (j > y) //Sprawdzenie czy osiegnieta zostala wspolrzedna y konca trasy
                    {
                        if (!(symbole.Contains(Radar[i , j-1]))) //Sprawdzenie kolizji w przypadku ruchu w lewo
                        {
                            p.SetY(--j);
                        }
                        else
                        {
                            Console.WriteLine("Wykryto kolizje na wspolrzednych (" + (i - 1) + ", " + j + "). Wprowadz kierunek, w ktorym ma poruszac sie statek:" +
                                "\nN - na polnosc (w gore radaru)," +
                                "\nE - na wschod (w prawo)," +
                                "\nS - na poludnie (w dol radaru)," +
                                "\nW - za zachod (w lewo)," +
                                "\nWcisniecie innego klawisza (lub wykrycie kolizji w obranym kierunku) spowoduje zatoczenie kolka na wspolrzednych, na ktorych znajduje sie statek powietrzny!");
                            ConsoleKeyInfo k = Console.ReadKey();
                            switch (k.Key)
                            {
                                case ConsoleKey.S:
                                    if (i + 1 < Radar.GetLength(0) && (Radar[i + 1, j] == null || Radar[i + 1, j] == " ")) p.SetX(++i);
                                    else Console.WriteLine("Zwrot na poludnie rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.E:
                                    if (j + 1 < Radar.GetLength(1) && (Radar[i, j + 1] == null || Radar[i, j + 1] == " ")) p.SetY(++j);
                                    else Console.WriteLine("Zwrot na wschod rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.W:
                                    Console.WriteLine("Nie mozesz leciec na zachod, skoro tam wykryto kolizje!");
                                    break;

                                case ConsoleKey.N:
                                    if (i-1 < 0 && (Radar[i-1, j] == null || Radar[i-1, j] == " ")) p.SetX(--i);
                                    else Console.WriteLine("Zwrot na polnoc rowniez doprowadzi do kolizji!");
                                    break;

                                default:
                                    break;

                            }
                        }
                    }

                    if (j < y && j + 1 < Radar.GetLength(1)) //Sprawdzenie czy osiegnieta zostala wspolrzedna y konca trasy
                    {
                        if (!(symbole.Contains(Radar[i, j+1]))) // Sprawdzenie kolizji w przypadku ruchu w prawo
                        {
                            p.SetY(++j);
                        }
                        else
                        {
                            Console.WriteLine("Wykryto kolizje na wspolrzednych (" + (i - 1) + ", " + j + "). Wprowadz kierunek, w ktorym ma poruszac sie statek:" +
                                "\nN - na polnosc (w gore radaru)," +
                                "\nE - na wschod (w prawo)," +
                                "\nS - na poludnie (w dol radaru)," +
                                "\nW - za zachod (w lewo)," +
                                "\nWcisniecie innego klawisza spowoduje zatoczenie kolka na wspolrzednych, na ktorych znajduje sie statek powietrzny!");
                            ConsoleKeyInfo k = Console.ReadKey();
                            switch (k.Key)
                            {
                                case ConsoleKey.S:
                                    if (i + 1 < Radar.GetLength(0) && (Radar[i + 1, j] == null || Radar[i + 1, j] == " ")) p.SetX(++i);
                                    else Console.WriteLine("Zwrot na poludnie rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.N:
                                    if (i - 1 < 0 && (Radar[i - 1, j] == null || Radar[i - 1, j] == " ")) p.SetX(--i);
                                    else Console.WriteLine("Zwrot na polnoc rowniez doprowadzi do kolizji!");
                                    break;

                                case ConsoleKey.E:
                                    Console.WriteLine("Nie mozesz leciec na polnoc, skoro tam wykryto kolizje!");
                                    break;

                                case ConsoleKey.W:
                                    if (j - 1 < 0 && (Radar[i, j - 1] == null || Radar[i, j - 1] == " ")) p.SetY(--j);
                                    else Console.WriteLine("Zwrot na wschod rowniez doprowadzi do kolizji!");
                                    break;

                                default:
                                    break;

                            }
                        }
                    }

                    if (i == 0 || i + 1 == Radar.GetLength(0) || j == 0 || j + 1 == Radar.GetLength(1)) //Sprawdzenie czy statek osiagnal kres radaru - jezeli tak to usuniecie go
                    {
                        Radar[i, j] = " ";
                        p.SetX(0);
                        p.SetY(0);
                        s.SetSrodek(p);
                        rad.GetStatki().GetLista().Remove(s);
                        continue;
                    }
                    if (i < Radar.GetLength(0) && j < Radar.GetLength(1)) //Srpawdzenie czy nadal i,j mieszcza sie w zakresie radaru - jezeli tak to wypisanie znaku po ruchu
                    {
                        Radar[i, j] = znak;
                        s.SetSrodek(p);
                    }

                }

            }
           

        }

        //Pierwsze przeciazenie metody sluzacej do generowania samolotow - w tym miejscu okresla gdzie statek zostanie wygenerowany
        public static void WygenerujSamolot(string[,] Radar, NaRadar rad)
        {
            Random r = new();
            int i = r.Next(0, Radar.GetLength(0));
            if (i > 0 || i < Radar.GetLength(0) - 1) //Sprawdzenie czy nie na krawedzi
            {
                int j = r.Next(Radar.GetLength(1) - 1);
                Punkt sr = new Punkt(i, j);
                WygenerujSamolot(Radar, sr, rad);


            }
            else //jezeli tak to na ktorej gornej
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

        //Drugie przeciazenie WygenerujSamolot - wlasciwe, ktore dodatkowo determinuje typ statku powietrznego
        public static void WygenerujSamolot(string[,] Radar, Punkt sr, NaRadar rad)
        {
            Random r = new();
            int i = sr.GetX();
            int j = sr.GetY();
            int znakr = r.Next(0, 4);
            int szerokosc; //efekt wczesnej fazy projektu - zabraklo czasu, aby usunac 
            int dlugosc; //efekt wczesnej fazy projektu - zabraklo czasu, aby usunac 
            switch (znakr) //w zaleznosci wygenerowanego randoma okreslany jest typ statku
            {
                case 0: //samolot
                    szerokosc = r.Next(2, 4);
                    dlugosc = r.Next(2, 4);
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@" | Radar[i, j] != "O")
                    {
                        rad.DodajSamolot(Radar, sr, szerokosc, dlugosc);
                    }
                    else WygenerujSamolot(Radar, rad);
                    break;

                case 1: //balon
                    szerokosc = 0;
                    dlugosc = 0;
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@" | Radar[i, j] != "O")
                    {
                        rad.DodajBalon(Radar, sr);
                    }
                    else WygenerujSamolot(Radar, rad);
                    break;

                case 2: //szybowiec
                    szerokosc = r.Next(1, 3);
                    dlugosc = r.Next(1, 3);
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@" | Radar[i, j] != "O")
                    {
                        rad.DodajSzybowiec(Radar, sr);
                    }
                    else WygenerujSamolot(Radar, rad);
                    break;

                case 3: //smiglowiec
                    szerokosc = r.Next(0, 2);
                    dlugosc = r.Next(0, 2);
                    if (Radar[i, j] != "X" | Radar[i, j] != "*" | Radar[i, j] != "#" | Radar[i, j] != "@" | Radar[i, j] != "O")
                    {
                        rad.DodajSmiglowiec(Radar, sr, szerokosc, dlugosc);
                    }
                    else WygenerujSamolot(Radar, rad);
                    break;


                default:
                    szerokosc = 0;
                    dlugosc = 0;
                    break;
            }
            Wypisz(Radar);//Po wygenerowaniu wypisanie calego radaru
        }

        //Metoda sluzaca do czyszczenia radaru poprzez wstawienie do niego zamiast znakow " "
        public static void Pusty(string[,] Radar)
        {
            for (int i = 0; i < Radar.GetLength(0); i++)
            {
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    Radar[i, j] = " ";
                }
            }

        }
        //Wypisywanie calego radaru w postaci wizualnej - na podstawie Radar[a,b]
        public static void Wypisz(string[,] Radar)
        {

            Console.Clear(); //Najpierw wyczyszczenie konsoli
            for (int i = 0; i < (2 * Radar.GetLength(1)) + 1; i++) //Tworzenie sufitu
                Console.Write("-");

            Console.Write("\n");
            for (int i = 0; i < Radar.GetLength(0); i++)//Tworzenie bokow
            {
                Console.Write("|");//Bok lewy
                for (int j = 0; j < Radar.GetLength(1); j++)
                {
                    if (j == Radar.GetLength(1) - 1)
                    {

                        Console.Write(Radar[i, j] + "|" + "\n"); //Bok prawy
                    }
                    else
                    {
                        Console.Write(Radar[i, j] + " ");
                    }
                }
            }
            for (int i = 0; i < (2 * Radar.GetLength(1)) + 1; i++) //Tworzenie "podlogi"
            {
                Console.Write("-");
            }
            //Wyswietlanie menu kontekstowego
            Console.Write("\n");
            Console.WriteLine("Wcisnij 1 aby wygenerowac samolot");
            Console.WriteLine("Wcisnij 2 aby przesunac czas do przodu");
            Console.WriteLine("Wcisnij 3 aby wyczyscic obraz");
            Console.WriteLine("Wcisnij 4 aby sledzic statek powietrzny");
            Console.WriteLine("Wcisnij 5 aby dodac obiekty z pliku");
            Console.WriteLine("Wcisnij Enter aby wyjsc");

        }

    }
}