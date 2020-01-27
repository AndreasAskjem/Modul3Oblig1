using System;
using System.Collections.Generic;
using System.Linq;

namespace Modul3Oblig1
{
    class Program
    {
        static void Main()
        {
            var liste = SetUpPersonObjects();

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();

                if (input.Length == 0)
                {
                    continue;
                }

                if (input == "hjelp")
                {
                    ShowHelp();
                }
                else if (input == "liste")
                {
                    foreach (var person in liste)
                    {
                        person.SkrivInfoListe();
                    }
                }
                else if (input.Substring(0, 4) == "vis ")
                {
                    var indexStr = input.Substring(4);
                    if (indexStr.Length == 0 || !indexStr.All(char.IsDigit))
                    {
                        Console.WriteLine($"  ID må være et tall mellom 1 og {liste.Count}.");
                        continue;
                    }
                    var index = int.Parse(indexStr) - 1;
                    if (index >= liste.Count || index < 0)
                    {
                        Console.WriteLine($"  ID må være et tall mellom 1 og {liste.Count}.");
                        continue;
                    }

                    liste[index].SkrivInfoEnkeltperson(liste);
                }
                else
                {
                    Console.WriteLine("  Ikke godkjent input. Skriv \"hjelp\" for å se alternativer.");
                }
            }
        }

        private static List<Person> SetUpPersonObjects()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var metteMarit = new Person { Id = 4, FirstName = "Mette-Marit", BirthYear = 1973 };
            var marius = new Person { Id = 5, FirstName = "Marius", LastName = "Borg Høiby", BirthYear = 1997 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            var sonja = new Person { Id = 7, FirstName = "Sonja", BirthYear = 1937 };
            var olav = new Person { Id = 8, FirstName = "Olav", BirthYear = 1903, DeathYear = 1991};

            sverreMagnus.Father = haakon;
            sverreMagnus.Mother = metteMarit;
            ingridAlexandra.Father = haakon;
            ingridAlexandra.Mother = metteMarit;
            marius.Mother = metteMarit;
            haakon.Father = harald;
            haakon.Mother = sonja;
            harald.Father = olav;

            var liste = new List<Person>
            {
                sverreMagnus,
                ingridAlexandra,
                haakon,
                metteMarit,
                marius,
                harald,
                sonja,
                olav
            };

            return liste;
        }

        private static void ShowHelp()
        {
            const string text = "  hjelp => Vis tilgjengelige kommandoer og hva de gjør.\n" +
                                "  liste => Lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på foreldre som er registrert.\n" +
                                "  vis < id > => Viser en bestemt person med navn og ID for foreldre og barn";
            Console.WriteLine(text);
        }
    }
}
