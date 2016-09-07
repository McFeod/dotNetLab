using LabOneCinema.Artifacts;

namespace LabOneCinema.Factory
{
    /// <summary>
    /// Фабрика для создания низкобюджетных фильмов
    /// </summary>
    public class LowBudgetFilmFactory: BaseFilmFactory
    {
        protected override double Factor { get; }

        public LowBudgetFilmFactory()
        {
            Factor = 1000;
        }
    }
}