using System;

namespace UrzadzeniaDomowe
{
    class Urzadzenie
    {
        public virtual void WyswietlKomunikat(string komunikat)
        {
            Console.WriteLine(komunikat);
        }
    }

    class Pralka : Urzadzenie
    {
        private int numerProgramu;

        public void UstawProgramPrania(int numer)
        {
            if (numer >= 1 && numer <= 12)
            {
                numerProgramu = numer;
                WyswietlKomunikat($"Wybrano program prania numer {numerProgramu}");
            }
            else
            {
                WyswietlKomunikat("Podano niepoprawny numer programu prania");
            }
        }
    }

    class Odkurzacz : Urzadzenie
    {
        private bool wlaczony;

        public void Wlacz()
        {
            wlaczony = true;
            WyswietlKomunikat("Odkurzacz włączono");
        }

        public void Wylacz()
        {
            wlaczony = false;
            WyswietlKomunikat("Odkurzacz wyłączono");
        }
    }
}

