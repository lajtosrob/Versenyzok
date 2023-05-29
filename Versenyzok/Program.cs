using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Versenyzok.DATAS;

namespace Versenyzok
{
    internal class Program
    {
        static List<Pilotak> pilotakList2;

        static void Main(string[] args)
        {
            //2.

            List<Pilotak> pilotakList2 = BeolvasPilotak("Datas\\pilotak.csv");

            //3.

            Console.WriteLine("3. feladat: " + pilotakList2.Count());

            //4.

            Console.WriteLine("4. feladat: " + pilotakList2.Last().Nev);

            //5.

            Console.WriteLine("5. feladat: ");
            List<Pilotak> newPilotakList = pilotakList2.Where(p => p.SzuletesiDatum < new DateTime(1901, 1, 1)).ToList();

            newPilotakList.ForEach(x => Console.WriteLine($"\t{x.Nev}" + " (" + x.SzuletesiDatum.ToShortDateString() + ")"));

            //6.

            Console.Write("6. feladat: ");
            string legkisebbRajtszamNemzetisege = pilotakList2
                .Where(x => !string.IsNullOrEmpty(x.Rajtszam))
                .OrderBy(x => int.Parse(x.Rajtszam))
                .First()
                .Nemzetiseg;
            Console.WriteLine(legkisebbRajtszamNemzetisege);

            //7.

            Console.Write("7. feladat: ");
            var ismetlodoRajtszamok = pilotakList2
                .Where(p => !string.IsNullOrEmpty(p.Rajtszam))
                .GroupBy(p => p.Rajtszam)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            ismetlodoRajtszamok.ForEach(x => Console.Write(x + ", "));

            Console.WriteLine();

        }

        static List<Pilotak> BeolvasPilotak(string fajlnev)
        {
            List<Pilotak> pilotakList2 = new List<Pilotak>();

            string[] sorok = File.ReadAllLines(fajlnev);
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split(';');
                string nev = adatok[0];
                DateTime szuletesiDatum = DateTime.Parse(adatok[1]);
                string nemzetiseg = adatok[2];
                string rajtszam = adatok[3];

                Pilotak pilota = new Pilotak(nev, szuletesiDatum, nemzetiseg, rajtszam);
                pilotakList2.Add(pilota);
            }

            return pilotakList2;
        }
    }
}

