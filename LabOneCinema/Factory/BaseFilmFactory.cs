using LabOneCinema.Artifacts;
using LabOneCinema.People;

namespace LabOneCinema.Factory
{
    public abstract class BaseFilmFactory
    {
        protected abstract double Factor { get; }
        public Film MakeFilm(string name, string producerName, string writerName, params string[] artistNames)
        {
            var producer = new Producer(producerName) {Salary = (decimal) (5 * Factor)};
            var writer = new Writer(writerName) {Salary = (decimal) (2 * Factor)};
            var film = new Film(name, writer, producer);
            producer.DoWork(film);
            writer.DoWork(film.Scenario);
            foreach (var artistName in artistNames)
            {
                var artist = new Artist(artistName);
                producer.Hire(artist, (decimal) (2 * Factor));
                artist.DoWork(film);
            }
            return film;
        }
    }
}