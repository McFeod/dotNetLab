using LabOneCinema.Artifacts;

namespace LabOneCinema.Factory
{
    public class LowBudgetFilmFactory: BaseFilmFactory
    {
        protected override double Factor { get; }

        public LowBudgetFilmFactory()
        {
            Factor = 1000;
        }
    }
}