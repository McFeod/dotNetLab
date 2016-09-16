using System;
using System.Linq;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.People;

namespace LabOneCinema.Delegates
{
    /// <summary>
    /// Определение типа делегата, реализующего операцию сравнения
    /// </summary>
    /// <param name="first">Первый элемент сравнения</param>
    /// <param name="second">Второй элемент сравнения</param>
    /// <typeparam name="T">Тип элементов</typeparam>

    public delegate int ComparsionRule<in T>(T first, T second);

    /* Реализуем несколько операций сравнения для фильмов */

    public class FilmComparsion
    {
        /// <summary>
        /// Сравнение по продолжительности фильма
        /// </summary>
        public static int DurationOrder(Film first, Film second)
        {
            return first.Duration.CompareTo(second.Duration);
        }

        /// <summary>
        /// Сравнение по числу актёров
        /// </summary>
        public static int ArtistCountOrder(Film first, Film second)
        {
            return first.Artists.Count.CompareTo(second.Artists.Count);
        }

        /// <summary>
        /// Сравнение по имени режиссёра
        /// </summary>
        public static int ProducerNameOrder(Film first, Film second)
        {
            return String.Compare(first.Producer.Name, second.Producer.Name, StringComparison.Ordinal);
        }

    }

}