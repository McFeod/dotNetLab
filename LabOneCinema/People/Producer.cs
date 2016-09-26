﻿using System;
using LabOneCinema.Artifacts;
using LabOneCinema.Logging;

namespace LabOneCinema.People
{
    /// <summary>
    /// Класс для режиссёра
    /// </summary>
    public class Producer: Person, IWorking<Film>, IHiring<Artist>
    {
        /// <summary>
        /// Одновременно режиссёр работает над одним фильмом
        /// </summary>
        private Film _currentFilm;

        public event EventHandler<WorkerEventArgs> OnWork = (sender, args) => {};
        public event EventHandler<HiringEventArgs> OnHire = (sender, args) => {};


        public Producer(string name) : base(name)
        {
        }

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
            artist.Salary = Salary;
            _currentFilm.Artists.Add(artist);
            OnHire(this, new HiringEventArgs() {Hired = artist});
        }
    }

}