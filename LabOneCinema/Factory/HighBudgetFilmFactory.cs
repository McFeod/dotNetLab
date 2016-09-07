using LabOneCinema.Artifacts;

namespace LabOneCinema.Factory
{
    /// <summary>
    /// Фабрика для создания высокобюджетных фильмов
    /// </summary>
    public class HighBudgetFilmFactory: BaseFilmFactory
    {
        protected override double Factor { get; }

        public HighBudgetFilmFactory()
        {
            Factor = 50000;
        }
    }
}