using System;
using LabOneCinema.Artifacts;

namespace LabOneCinema.Factory
{
    public class RandomScenarioFactory
    {
        /// <summary>
        /// Ведём подсчёт числу созданных сценариев (для генерации названия)
        /// </summary>
        private int _filmsCreated;

        private readonly Random _random;

        public RandomScenarioFactory()
        {
            _filmsCreated = 0;
            _random = new Random();
        }

        /// <summary>
        /// Создание сценария с произвольным числом страниц
        /// </summary>
        /// <returns>Сценарий</returns>
        public Scenario MakeScenario()
        {
            _filmsCreated++;
            return new Scenario()
            {
                Name = $"Scenario #{_filmsCreated}",
                PageCount = (ushort)_random.Next(10, 2000)
            };
        }
    }
}