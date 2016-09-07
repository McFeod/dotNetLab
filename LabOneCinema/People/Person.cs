using System;

namespace LabOneCinema.People
{
    public abstract class Person
    {
        public string Name { get; }
        public decimal Salary { get; set; }
        protected static readonly Random Random = new Random();

        protected Person(string name)
        {
            Name = name;
        }
    }
}