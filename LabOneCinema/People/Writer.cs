using System;
using LabOneCinema.Artifacts;

namespace LabOneCinema.People
{
    /// <summary>
    /// Класс для сценариста
    /// </summary>
    public class Writer: Person, IWorking<Scenario>
    {
        public Writer(string name) : base(name)
        {
        }

        /// <summary>
        /// Работа сценариста - написание сценария (увеличение числа страниц)
        /// </summary>
        /// <param name="film">Фильм</param>
        /// <returns>Сценарий</returns>
        public Scenario DoWork(Film film)
        {
            film.Scenario.PageCount += (ushort)Random.Next(20, 100);
            return film.Scenario;
        }
    }
}