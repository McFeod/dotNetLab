using System;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.Delegates;
using LabOneCinema.Factory;

namespace LabOneCinema
{
    internal class Program: MainHelper
    {
        private static void Main(string[] args)
        {
            var factoryLow = new LowBudgetFilmFactory();
            var factoryHigh = new HighBudgetFilmFactory();
            var playlist = new Playlist<Film>(false)
            {
                factoryLow.MakeFilm(
                    "Охотники за бургерами",
                    "Чапко Бронислава",
                    "Веселков Григорий",
                    "Петров Аристарх",
                    "Литвина Ева",
                    "Андронова Амина"
                ),
                factoryHigh.MakeFilm(
                    "Компиляция",
                    "Ушаков Виталий",
                    "Шершова Луиза",
                    "Соколов Вышеслав",
                    "Шалдыбин Степан",
                    "Наумова Юлия",
                    "Лебедев Митофан",
                    "Прокофьев Фрол",
                    "Русина Варвара"
                )
            };
            var anotherFilm = factoryLow.MakeFilm(
                "Ржавчина",
                "Захаров Евграф",
                "Ушаков Роман",
                "Дмитриева Каролина",
                "Ильин Бернар"
            );
            playlist.Add(anotherFilm);


            /* Применение сортировок*/

            playlist.Sort(FilmComparsion.DurationOrder);
            PrintProperties(playlist, "Name", "\t|\t");
            Console.WriteLine("===============================================================");

            playlist.Sort(FilmComparsion.ArtistCountOrder);
            PrintProperties(playlist, "Name", "\t|\t");
            Console.WriteLine("===============================================================");

            playlist.Sort(FilmComparsion.ProducerNameOrder);
            PrintProperties(playlist, "Name", "\t|\t");
            Console.WriteLine("===============================================================");


            /* Применение Action */

            playlist.ApplyAction(FilmActions.PrintBudget);


            /* Применение Func */

            var crossover = playlist.GetAnnotation(FilmFunctions.RandomArtist);

            Console.WriteLine("Публика с нетерпением ждёт фильм, в котором сыграют " +
                              string.Join(", ", crossover));
        }
    }
}
