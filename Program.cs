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
                    Console.WriteLine();
                    continue;
                }

                input = input.ToLower();

                if (input == "hjelp")
                {
                    ShowHelp();
                }
                else if (input == "liste")
                {
                    foreach (var person in liste)
                    {
                        person.Show();
                    }
                }
                else if (input.Length > 4 && input.Substring(0, 4) == "vis ")
                {
                    var indexStr = input.Substring(4);
                    if (indexStr.Length == 0 || !indexStr.All(char.IsDigit))
                    {
                        Console.WriteLine("  Finner ikke ID.");
                        Console.WriteLine();
                        continue;
                    }

                    var id = int.Parse(indexStr);
                    var index = liste.FindIndex(p => p.Id == id);

                    if (index == -1)
                    {
                        Console.WriteLine("  Finner ikke ID.");
                        Console.WriteLine();
                        continue;
                    }

                    var person = liste[index];
                    
                    person.Show();
                    ShowChildren(liste, id);
                }
                else
                {
                    Console.WriteLine("  Ikke godkjent input. Skriv \"hjelp\" for å se alternativer.");
                }

                Console.WriteLine();
            }
        }

        private static void ShowChildren(List<Person> liste, int id)
        {
            foreach (var p in liste)
            {
                if (p.Father != null && p.Father.Id == id)
                {
                    Console.Write("  Barn:"); 
                    p.Show();
                }

                if (p.Mother != null && p.Mother.Id == id)
                {
                    Console.Write("  Barn:");
                    p.Show();
                }
            }
        }
        private static void ShowHelp()
        {
            const string text = "  hjelp => Vis tilgjengelige kommandoer og hva de gjør.\n" +
                                "  liste => Lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på foreldre som er registrert.\n" +
                                "  vis < id > => Viser en bestemt person med navn og ID for foreldre og barn";
            Console.WriteLine(text);
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
    }
}
