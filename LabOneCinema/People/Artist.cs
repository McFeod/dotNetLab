using System;
using LabOneCinema.Artifacts;
using LabOneCinema.Logging;

namespace LabOneCinema.People
{
    /// <summary>
    /// Класс, описывающий актёра
    /// </summary>
    [Serializable]
    public class Artist: Person, IWorking<Film>
    {
        /// <summary>
        /// Событие, возникающее при игре актера в фильме
        ///</summary>
        public event EventHandler<WorkerEventArgs> OnWork = (sender, value) => {};

        public Artist(string name) : base(name)
        {
        }

        private Artist(){}

        /// <summary>
        /// Актёр играет в фильме, увеличивая его длительность
        /// </summary>
        /// <param name="film">Фильм</param>
        public Film DoWork(Film film)
        {
            var extraTime = Random.Next(5, 30);
            film.Duration += extraTime;
            OnWork(this, new WorkerEventArgs(){Type=ArtifactType.FilmDuration, Measurement = extraTime});
            return film;
        }

    }
}