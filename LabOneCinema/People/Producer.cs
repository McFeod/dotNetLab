﻿using LabOneCinema.Artifacts;

namespace LabOneCinema.People
{
    /// <summary>
    /// Класс для режиссёра
    /// </summary>
    public class Producer: Person, IWorking<Film>, IHiring
    {
        /// <summary>
        /// Одновременно режиссёр работает над одним фильмом
        /// </summary>
        private Film _currentFilm;

        public Producer(string name) : base(name)
        {
        }

        /// <summary>
        /// Режиссёр переключается на работу над заданным фильмом
        /// </summary>
        /// <param name="film">Фильм</param>
        public void DoWork(Film film)
        {
            this._currentFilm = film;
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

        }
    }

}