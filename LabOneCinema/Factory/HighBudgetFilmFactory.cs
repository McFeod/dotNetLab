using LabOneCinema.Artifacts;
using LabOneCinema.Logging;

namespace LabOneCinema.Factory
{
    /// <summary>
    /// Фабрика для создания высокобюджетных фильмов
    /// </summary>
    public class HighBudgetFilmFactory: BaseFilmFactory
    {
        protected override double Factor { get; }

        public HighBudgetFilmFactory(FilmLogger logger = null): base(logger)
        {
            Factor = 50000;
        }
    }
}