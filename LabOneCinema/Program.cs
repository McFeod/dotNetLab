using System;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.Factory;

namespace LabOneCinema
{
    internal class Program: MainHelper
    {
        private static void Main(string[] args)
        {
            var factoryLow = new LowBudgetFilmFactory();
            var factoryHigh = new HighBudgetFilmFactory();
            var playlist = new Playlist<Film>()
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
                "Сорокина Дина",
                "Ильин Бернар"
            );
            playlist.Add(anotherFilm);

            // проверка случаности порядка воспроизведения в плейлисте

            for (var i = 0; i < 10; ++i)
            {
                PrintProperties(playlist, "Name", "\t|\t");
            }

            // проверим *-вариантности

            Console.WriteLine("До работы:");
            Console.WriteLine(anotherFilm.Credits);
            foreach (var i in anotherFilm.GetTeam())
            {
                i.DoWork(anotherFilm);
            }

            Console.WriteLine("После:");
            Console.WriteLine(anotherFilm.Credits);
        }
    }
}
