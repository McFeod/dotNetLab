using System;
using System.Collections.Generic;
using System.Linq;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.People;

namespace LabOneCinema
{
    public class MainHelper
    {
        private static readonly Random Random = new Random();
        public static void PrintProperties<T>(IEnumerable<T> list, string property, string separator)
        {
            Console.WriteLine(string.Join(separator,
                list.Select(x => x.GetType().GetProperty(property).GetValue(x, null))
            ));
        }

        /* Пример метода, используемого как Action...*/

        /// <summary>
        /// Печать бюджета фильма
        /// </summary>
        /// <param name="film">Фильм</param>
        public static void PrintBudget(Film film)
        {
            var budget = film.GetTeam().Select(i => ((Person) i).Salary).Sum();
            Console.WriteLine($"Бюджет фильма \"{film.Name}\" равен {budget}$");
        }


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