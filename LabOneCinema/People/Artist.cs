using LabOneCinema.Artifacts;

namespace LabOneCinema.People
{
    /// <summary>
    /// Класс, описывающий актёра
    /// </summary>
    public class Artist: Person, IWorking<Film>
    {
        public Artist(string name) : base(name)
        {
        }

        /// <summary>
        /// Актёр играет в фильме, увеличивая его длительность
        /// </summary>
        /// <param name="film">Фильм</param>
        public void DoWork(Film film)
        {
            film.Duration += Random.Next(5, 30);
        }
    }
}