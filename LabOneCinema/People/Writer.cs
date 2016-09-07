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
        /// <param name="scenario">Сценарий</param>
        public void DoWork(Scenario scenario)
        {
            scenario.PageCount += (ushort)Random.Next(20, 100);
        }
    }
}