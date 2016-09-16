using System;
using System.Linq;
using LabOneCinema.Artifacts;
using LabOneCinema.People;

namespace LabOneCinema.Delegates
{
    public class FilmFunctions
    {
        private static readonly Random Random = new Random();

        /* Пример метода, используемого как Func*/

        /// <summary>
        /// Получение имени случайного актёра фильма
        /// </summary>
        /// <param name="film">Фильм</param>
        /// <returns>Актёр</returns>
        public static string RandomArtist(Film film)
        {
            return film.Artists.ElementAt(Random.Next(film.Artists.Count)).Name;
        }
    }
}