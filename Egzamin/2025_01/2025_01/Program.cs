using System;


/*
nazwa: UrzadzeniaDomowe

opis: Program symuluje działanie pralki i odkurzacza – użytkownik wybiera program prania, a następnie włącza i wyłącza odkurzacz.
   
parametry:
Urzadzenie.WyswietlKomunikat(string komunikat) – void – wyświetla komunikat na konsoli
Pralka.UstawProgramPrania(int numer) – void – ustawia program prania (1–12)
Odkurzacz.Wlacz() – void – włącza odkurzacz
Odkurzacz.Wylacz() – void – wyłącza odkurzacz

autor: Filip Ciesielski
*/

namespace UrzadzeniaDomowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Pralka pralka = new Pralka();
            Odkurzacz odkurzacz = new Odkurzacz();

            Console.Write("Podaj numer prania 1..12: ");
            int numer;
            if (int.TryParse(Console.ReadLine(), out numer))
            {
                pralka.UstawProgramPrania(numer);
            }
            else
            {
                Console.WriteLine("Podano niepoprawny numer programu prania");
                return;
            }

            odkurzacz.Wlacz();
            odkurzacz.Wylacz();
        }
    }
}
