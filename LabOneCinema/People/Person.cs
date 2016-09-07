using System;

namespace LabOneCinema.People
{
    /// <summary>
    /// Абстрактный класс для человека, участвующего в создании фильма
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Гонорар
        /// </summary>
        public decimal Salary { get; set; }

        protected static readonly Random Random = new Random();

        protected Person(string name)
        {
            Name = name;
        }
    }
}