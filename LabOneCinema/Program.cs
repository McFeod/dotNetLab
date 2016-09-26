using System;
using System.IO;
using LabOneCinema.Artifacts;
using LabOneCinema.Collections;
using LabOneCinema.Delegates;
using LabOneCinema.Factory;
using LabOneCinema.Logging;

namespace LabOneCinema
{
    internal class Program: MainHelper
    {
        private static void Main(string[] args)
        {
            var logger = new FilmLogger(Path.Combine("..", "..", "films.log"));
            logger.OnLog += PrintToLog;
            var factoryLow = new LowBudgetFilmFactory(logger);
            var factoryHigh = new HighBudgetFilmFactory(logger);
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

        }
    }
}
