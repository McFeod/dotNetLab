using System;
using LabOneCinema.Artifacts;
using LabOneCinema.Logging;

namespace LabOneCinema.People
{
    /// <summary>
    /// Класс для сценариста
    /// </summary>
    public class Writer: Person, IWorking<Scenario>, IStartingFromScratch<Scenario>
    {
        /// <summary>
        /// Событие, возникающее при написании сценария
        /// </summary>
        public event EventHandler<WorkerEventArgs> OnWork = (sender, args) => {};

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
            var extraPages = Random.Next(20, 100);
            film.Scenario.PageCount += (ushort) extraPages;
            OnWork(this, new WorkerEventArgs(){Type = ArtifactType.ScenarioLength, Measurement = extraPages});
            return film.Scenario;
        }

        /// <summary>
        /// Сценарист может начать писать сценарий заново
        /// </summary>
        /// <param name="scenario">Сценарий</param>
        public void StartFromScratch(out Scenario scenario)
        {
            scenario = new Scenario();
        }
    }
}