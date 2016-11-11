using CinemaLibrary.Logging;

namespace CinemaLibrary.Factory
{
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