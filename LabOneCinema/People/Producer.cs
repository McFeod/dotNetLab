using LabOneCinema.Artifacts;

namespace LabOneCinema.People
{
    public class Producer: Person, IWorking<Film>, IHiring
    {
        private Film _currentFilm;

        public Producer(string name) : base(name)
        {
        }

        public void DoWork(Film film)
        {
            this._currentFilm = film;
        }

        public void Hire(Artist artist, decimal salary)
        {
            artist.Salary = Salary;
            _currentFilm.Artists.Add(artist);

        }
    }

}