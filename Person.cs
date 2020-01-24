using System;
using System.Collections.Generic;

namespace Modul3Oblig1
{
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }

        public List<Person> Children = new List<Person>();

        private Person _father;
        public Person Father {
            get => _father;
            set
            {
                _father = value;
                value.Children.Add(this);
            }
        }

        private Person _mother;
        public Person Mother
        {
            get => _mother;
            set
            {
                _mother = value;
                value.Children.Add(this);
            }
        }

        internal void SkrivInfoListe()
        {
            var output = $"ID: {Id}, Fornavn: {FirstName}";

            //if (LastName != null) { output += $", Etternvan: {LastName}"; }

            output += $", Fødselsår: {BirthYear}";
            if (DeathYear != null) { output += $", Dødsår: {DeathYear}"; }

            if (_father != null) { output += $", Far ID: {_father.Id}"; }
            if (_mother != null) { output += $", Mor ID: {_mother.Id}"; }

            Console.WriteLine("  " + output);
        }

        public void SkrivInfoEnkeltperson()
        {
            var output = $"  ID: {Id}, Fornavn: {FirstName}";

            if (LastName != null) { output += $", Etternvan: {LastName}"; }

            output += $", Fødselsår: {BirthYear}\n";

            if(_father != null || _mother != null) {
                output += "  Foreldre:\n";
                if (_father != null) { output += $"    Far: {_father.FirstName}, ID: {_father.Id}\n"; }
                if (_mother != null) { output += $"    Mor: {_mother.FirstName}, ID: {_mother.Id}\n"; }
            }

            if (Children.Count > 0)
            {
                output += "  Barn:\n";
                foreach (var child in Children)
                {
                    output += $"    {child.FirstName}, (ID: {child.Id})\n";
                }
            }

            Console.WriteLine(output);
        }
    }
}