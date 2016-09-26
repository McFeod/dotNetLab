using System;
using System.Collections.Generic;
using System.Linq;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.Logging;
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

        /************************************** 3 лабораторная ********************************************************/

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

        /************************************** 4 лабораторная ********************************************************/

        /// <summary>
        /// Внешний метод для печати в лог
        /// </summary>
        /// <param name="obj">Объект, вызвавший событие</param>
        /// <param name="args">Информация о событии</param>
        public static void PrintToLog(object obj, LogEventArgs args)
        {
            string message;
            switch (args.Type)
            {
                case EventType.WriterWorks:
                    var writer = (Writer) obj;
                    var pages = ((WorkerEventArgs) args.Nested).Measurement;
                    message = $"Сценарист {writer.Name} продолжил работу (дописано страниц: {pages})";
                    break;
                case EventType.ArtistWorks:
                    var artist = (Artist) obj;
                    var duration = ((WorkerEventArgs) args.Nested).Measurement;
                    message = $"Актёр {artist.Name} продолжил работу (отснято минут: {duration})";
                    break;
                case EventType.ProducerWorks:
                    var producer = (Producer) obj;
                    message = $"Режиссёр {producer.Name} начал работу над фильмом";
                    break;
                case EventType.ProducerHires:
                    producer = (Producer) obj;
                    var hired = (Artist) ((HiringEventArgs) args.Nested).Hired;
                    message = $"Режиссёр {producer.Name} привлёк к съёмкам актёра {hired.Name}," +
                              $" чей гонорар составил {hired.Salary}$";
                    break;
                case EventType.FilmGrows:
                    var film = (Film) obj;
                    message = $"Продолжительность фильма в минутах: {film.Duration}";
                    break;
                case EventType.ScenarioGrows:
                    var scenario = (Scenario) obj;
                    message = $"Длина сценария в страницах: {(int) scenario.PageCount}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            args.Output.WriteLine($"Фильм \"{args.Sender.Name}\", {DateTime.Now}: {message}");

        }
    }
}