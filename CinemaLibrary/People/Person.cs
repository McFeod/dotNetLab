using System;

namespace CinemaLibrary.People
{
    /// <summary>
    /// Абстрактный класс для человека, участвующего в создании фильма
    /// </summary>
    [Serializable]
    public abstract class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Гонорар
        /// </summary>
        public decimal Salary { get; set; }

        protected static readonly Random Random = new Random();

        protected Person(string name)
        {
            Name = name;
        }

        protected Person(){}
    }
}