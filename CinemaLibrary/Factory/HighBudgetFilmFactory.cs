using CinemaLibrary.Logging;

namespace CinemaLibrary.Factory
{
    /// <summary>
    /// Фабрика для создания высокобюджетных фильмов
    /// </summary>
    public class HighBudgetFilmFactory: BaseBudgetFilmFactory
    {
        protected override double Factor { get; }

        public HighBudgetFilmFactory(FilmLogger logger = null): base(logger)
        {
            Factor = 50000;
        }
    }
}