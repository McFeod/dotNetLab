using LabOneCinema.Artifacts;
using LabOneCinema.Logging;

namespace LabOneCinema.Factory
{
    /// <summary>
    /// Фабрика для создания низкобюджетных фильмов
    /// </summary>
    public class LowBudgetBudgetFilmFactory: BaseBudgetFilmFactory
    {
        protected override double Factor { get; }

        public LowBudgetBudgetFilmFactory(FilmLogger logger = null): base(logger)
        {
            Factor = 1000;
        }
    }
}