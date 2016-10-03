using LabOneCinema.Artifacts;
using LabOneCinema.Logging;

namespace LabOneCinema.Factory
{
    /// <summary>
    /// Фабрика для создания высокобюджетных фильмов
    /// </summary>
    public class HighBudgetBudgetFilmFactory: BaseBudgetFilmFactory
    {
        protected override double Factor { get; }

        public HighBudgetBudgetFilmFactory(FilmLogger logger = null): base(logger)
        {
            Factor = 50000;
        }
    }
}