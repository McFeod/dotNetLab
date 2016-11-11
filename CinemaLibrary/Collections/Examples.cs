using System.Collections.Generic;
using CinemaLibrary.Artifacts;
using CinemaLibrary.People;

namespace CinemaLibrary.Collections
{
    /// <summary>
    /// Примеры ковариантности и контравариантности
    /// </summary>
    public static class Examples
    {
        /// <summary>
        /// Пример ковариантности.
        /// Получение людей, работающих над фильмом, в виде одного списка
        /// </summary>
        /// <param name="film">Фильм</param>
        public static List<IWorking<Artifact>> GetTeam(this Film film)
        {
            var result = new List<IWorking<Artifact>> {film.Writer, film.Producer};
            result.AddRange(film.Artists);
            return result;
        }

        /// <summary>
        /// Пример контравариантности. Просто, чтобы был.
        /// </summary>
        /// <param name="film">Фильм</param>
        public static void ContravarianceExample(this Film film)
        {
            IHiring<Person> boss = new Boss("John Doe");
            IHiring<Artist> producer = boss;
        }
    }
}