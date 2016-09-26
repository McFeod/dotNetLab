﻿using LabOneCinema.Artifacts;
using LabOneCinema.Logging;
using LabOneCinema.People;

namespace LabOneCinema.Factory
{
    /// <summary>
    /// Абстрактная фабрика, создающая фильмы
    /// </summary>
    public abstract class BaseFilmFactory
    {
        /// <summary>
        /// Коэффициент "бюджетности" фильма
        /// </summary>
        protected abstract double Factor { get; }

        protected FilmLogger Logger;

        protected BaseFilmFactory(FilmLogger logger = null)
        {
            Logger = logger;
        }

        /// <summary>
        /// Создание фильма
        /// </summary>
        /// <param name="name">Название фильма</param>
        /// <param name="producerName">Имя режиссёра</param>
        /// <param name="writerName">Имя сценариста</param>
        /// <param name="artistNames">Имена актёров</param>
        /// <returns></returns>
        public Film MakeFilm(string name, string producerName, string writerName, params string[] artistNames)
        {
            var producer = new Producer(producerName) {Salary = (decimal) (5 * Factor)};
            var writer = new Writer(writerName) {Salary = (decimal) (2 * Factor)};
            var film = new Film(name, writer, producer);
            Logger?.SubscribeOnEvents(film);
            // Все работают над созданием фильма
            producer.DoWork(film);
            writer.DoWork(film);
            foreach (var artistName in artistNames)
            {
                var artist = new Artist(artistName);
                producer.Hire(artist, (decimal) (2 * Factor));
                artist.DoWork(film);
            }
            return film;
        }
    }
}