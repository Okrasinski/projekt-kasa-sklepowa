using System;
using System.Collections.Generic;

namespace SymulatorAplikacji
{
    class Program
    {
        static Dictionary<string, (string, decimal)> produkty = new Dictionary<string, (string, decimal)>()
        {
            {"001", ("Masło extra", 6.50m)},
            {"002", ("Chleb wiejski", 4.50m)},
            {"003", ("Makaron Babuni", 9.20m)},
            {"004", ("Dżem truskawkowy", 8.10m)},
            {"005", ("Kiełbasa myśliwska", 29.00m)},
            {"006", ("Szynka konserwowa", 22.00m)},
            {"007", ("Chipsy paprykowe", 6.00m)},
            {"008", ("Serek wiejski", 3.50m)},
            {"009", ("Sól kuchenna", 2.70m)},
            {"010", ("Cukier kryształ", 3.20m)}
        };

        static List<(string, decimal)> koszyk = new List<(string, decimal)>();
        static decimal sumaBrutto = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Symulator aplikacji");

            while (true)
            {
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1. Wyświetl listę produktów");
                Console.WriteLine("2. Rozpocznij zakupy");
                Console.WriteLine("3. Zakończ program");

                int opcja;
                if (!int.TryParse(Console.ReadLine(), out opcja))
                {
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    continue;
                }

                switch (opcja)
                {
                    case 1:
                        WyswietlListeProduktow();
                        break;
                    case 2:
                        RozpocznijZakupy();
                        break;
                    case 3:
                        Console.WriteLine("Program zakończony.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void WyswietlListeProduktow()
        {
            Console.WriteLine("\nLista produktów wirtualnego sklepu:");
            Console.WriteLine("Kod kreskowy\tNazwa produktu\tCena netto");
            foreach (var produkt in produkty)
            {
                Console.WriteLine($"{produkt.Key}\t\t{produkt.Value.Item1}\t{produkt.Value.Item2.ToString("C2")}");
            }
        }

        static void RozpocznijZakupy()
        {
            Console.WriteLine("\nRozpoczęto zakupy. Wprowadź kod kreskowy produktu (lub 'P' aby zakończyć):");

            while (true)
            {
                string kod = Console.ReadLine().Trim().ToUpper();
                if (kod == "P")
                {
                    WyswietlParagon();
                    break;
                }

                if (produkty.ContainsKey(kod))
                {
                    var produkt = produkty[kod];
                    koszyk.Add(produkt);
                    sumaBrutto += produkt.Item2 * 1.23m; // dodanie ceny brutto do sumy
                    Console.WriteLine($"Dodano do koszyka: {produkt.Item1} - {produkt.Item2.ToString("C2")} (brutto). Aktualna suma brutto: {sumaBrutto.ToString("C2")}");
                }
                else
                {
                    Console.WriteLine("NIEPRAWIDŁOWY KOD KRESKOWY. Wprowadź prawidłowy kod lub 'P' aby zakończyć zakupy.");
                }
            }
        }

        static void WyswietlParagon()
        {
            Console.WriteLine("\nParagon za zakupy:");
            Console.WriteLine($"Data zakupu: {DateTime.Now}");
            Console.WriteLine("Produkty:");
            foreach (var pozycja in koszyk)
            {
                Console.WriteLine($"{pozycja.Item1} - {pozycja.Item2.ToString("C2")}");
            }
            Console.WriteLine($"Łączna kwota do zapłaty (brutto): {sumaBrutto.ToString("C2")}");
            decimal podatekVAT = sumaBrutto - (sumaBrutto / 1.23m); // obliczenie podatku VAT
            Console.WriteLine($"Łączny podatek VAT: {podatekVAT.ToString("C2")}");
        }
    }
}
