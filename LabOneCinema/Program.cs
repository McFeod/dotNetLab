using System;
using System.Threading;
using LabOneCinema.Artifacts;
using LabOneCinema.Factory;
using LabOneCinema.Collections;

namespace LabOneCinema
{
    internal class Program: MainHelper
    {
        private static void Main(string[] args)
        {
            var scenarioFactory = new RandomScenarioFactory();
            var collection = new Playlist<Scenario>(false);
            for (var i = 0; i < 10000; ++i)
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

            Console.ReadKey();
        }
    }
}
