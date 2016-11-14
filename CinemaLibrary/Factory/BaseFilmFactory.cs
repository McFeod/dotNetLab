using CinemaLibrary.Logging;

namespace CinemaLibrary.Factory
{
    /// <summary>
    /// Базовый класс для фабрик фильмов, поддерживающих логирование
    /// </summary>
    public abstract class BaseFilmFactory
    {
        /// <summary>
        /// Логгер для фабрики. Равен null, если логирование не нужно
        /// </summary>
        protected FilmLogger Logger;

        protected BaseFilmFactory(FilmLogger logger = null)
        {
            Logger = logger;
        }
    }
}