using System;
using System.IO;
using System.Linq;
using System.Threading;
using LabOneCinema.Artifacts;
using LabOneCinema.Factory;
using LabOneCinema.Logging;
using LabOneCinema.Collections;

namespace LabOneCinema
{
    internal class Program: MainHelper
    {
        private static void Main(string[] args)
        {
            var scenarioFactory = new RandomScenarioFactory();
            var collection = new Playlist<Scenario>(false);
            for (var i = 0; i < 1000; ++i)
            {
                collection.Add(scenarioFactory.MakeScenario());
            }
            var sortingTask = collection.StartAsyncSort(
                (first, second) => first.PageCount.CompareTo(second.PageCount),
                (msg, progress) => Console.WriteLine($"{msg}: {progress*100}%"));

            // пока коллекция сортируется, главный поток спамит в stdout
            while (!sortingTask.IsCompleted)
            {
                Thread.Sleep(50);
                Console.WriteLine("Ready? Ready? Ready? Ready? Ready? Ready? Ready?");
            }

            // Console.WriteLine(string.Join("\n", collection.Select((x) => $"{x.Name}: {x.PageCount}")));

            var logger = new FilmLogger(Path.Combine("..", "..", "films.log"));
            logger.OnLog += PrintToLog;
            var factoryHigh = new HighBudgetFilmFactory(logger);
            var film = factoryHigh.MakeFilm(
                "Компиляция",
                "Ушаков Виталий",
                "Шершова Луиза",
                "Соколов Вышеслав",
                "Шалдыбин Степан",
                "Наумова Юлия",
                "Лебедев Митофан",
                "Прокофьев Фрол",
                "Русина Варвара"
            );
        }
    }
}
