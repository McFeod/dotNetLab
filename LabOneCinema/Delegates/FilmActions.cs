using System;
using System.Linq;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.People;

namespace LabOneCinema.Delegates
{
    public class FilmActions
    {

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

    }
}