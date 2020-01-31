using System;

namespace Modul3Oblig1
{
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }


        public void Show()
        {
            var output = $"ID: {Id}, Fornavn: {FirstName}";

            if (LastName != null) { output += $", Etternvan: {LastName}"; }

            if (BirthYear != null) { output += $", Fødselsår: {BirthYear}"; }
            if (DeathYear != null && DeathYear != 0) { output += $", Dødsår: {DeathYear}"; }

            if (Father != null) { output += $", Far ID: {Father.Id}"; }
            if (Mother != null) { output += $", Mor ID: {Mother.Id}"; }

            Console.WriteLine("  " + output);
        }
    }
}