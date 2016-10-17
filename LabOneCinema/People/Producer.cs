using System;
using LabOneCinema.Artifacts;
using LabOneCinema.Exceptions;
using LabOneCinema.Logging;

namespace LabOneCinema.People
{
    /// <summary>
    /// Класс для режиссёра
    /// </summary>
    [Serializable]
    public class Producer: Person, IWorking<Film>, IHiring<Artist>
    {
        /// <summary>
        /// Одновременно режиссёр работает над одним фильмом
        /// </summary>
        private Film _currentFilm;

        /// <summary>
        /// Событие, возникающее при работе режиссёра над фильмом
        /// </summary>
        public event EventHandler<WorkerEventArgs> OnWork = (sender, args) => {};

        /// <summary>
        /// Событие, возникающее при найме актёра
        /// </summary>
        public event EventHandler<HiringEventArgs> OnHire = (sender, args) => {};


        public Producer(string name) : base(name)
        {
        }

        private Producer(){}

        /// <summary>
        /// Режиссёр переключается на работу над заданным фильмом
        /// </summary>
        /// <param name="film">Фильм</param>
        public Film DoWork(Film film)
        {
            _currentFilm = film;
            OnWork(this, new WorkerEventArgs(){Type = ArtifactType.FilmItself});
            return film;
        }

        /// <summary>
        /// Режиссёр нанимает актёра для съёмок в текущем фильме
        /// </summary>
        /// <param name="artist">Актёр</param>
        /// <param name="salary">Гонорар актёра</param>
        public void Hire(Artist artist, decimal salary)
        {
            if (_currentFilm == null)
                throw new HiringOrderException();
            artist.Salary = salary;
            _currentFilm.Artists.Add(artist);
            OnHire(this, new HiringEventArgs() {Hired = artist});
        }
    }

}