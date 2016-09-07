using LabOneCinema.Artifacts;

namespace LabOneCinema.People
{
    public class Artist: Person, IWorking<Film>
    {
        public Artist(string name) : base(name)
        {
        }

        public void DoWork(Film film)
        {
            film.Duration += Random.Next(5, 30);
        }
    }
}