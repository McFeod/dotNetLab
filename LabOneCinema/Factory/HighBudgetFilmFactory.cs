using LabOneCinema.Artifacts;

namespace LabOneCinema.Factory
{
    public class HighBudgetFilmFactory: BaseFilmFactory
    {
        protected override double Factor { get; }

        public HighBudgetFilmFactory()
        {
            Factor = 50000;
        }
    }
}