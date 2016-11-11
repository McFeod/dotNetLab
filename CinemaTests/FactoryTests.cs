using System.IO;
using CinemaLibrary.Exceptions;
using CinemaLibrary.Factory;
using Xunit;

namespace CinemaTests
{
    /// <summary>
    /// Тесты на работу фабрик
    /// </summary>
    public class FactoryTests
    {
        /// <summary>
        /// Путь к папке с файлами, из которых производится загрузка фильмов
        /// </summary>
        private readonly string _assetPath = Path.Combine("..", "..", "Assets");

        /// <summary>
        /// Проверка загрузки корректного файла с фильмом
        /// </summary>
        [Fact]
        public void TestConfigFilmFactory()
        {
            var factory = new ConfigFilmFactory();
            var film = factory.LoadFilm(Path.Combine(_assetPath, "film_1.csv"));
            Assert.NotNull(film);
        }

        /// <summary>
        /// Проверка порождения исключения при загрузке фильма с актёром без гонорара
        /// </summary>
        [Fact]
        public void TestConfigFilmFactoryIncorrectActor()
        {
            var factory = new ConfigFilmFactory();
            Assert.Throws<StringFormatException>(()=>
            {
                factory.LoadFilm(Path.Combine(_assetPath, "film_error_1.csv"));
            });
        }

        /// <summary>
        /// Проверка порождения исключения при загрузке фильма, где у кого-то из работников киностудии
        /// жалование не является числом
        /// </summary>
        [Fact]
        public void TestConfigFilmFactoryIncorrectSalary()
        {
            var factory = new ConfigFilmFactory();
            Assert.Throws<StringFormatException>(()=>
            {
                factory.LoadFilm(Path.Combine(_assetPath, "film_error_2.csv"));
            });
        }

        /// <summary>
        /// Проверка порождения исключения при загрузке фильма, где у кого-то из работников киностудии
        /// жалование является отрицательным числом
        /// </summary>
        [Fact]
        public void TestConfigFilmFactoryNegativeSalary()
        {
            var factory = new ConfigFilmFactory();
            Assert.Throws<NegativeValueException>(()=>
            {
                factory.LoadFilm(Path.Combine(_assetPath, "film_error_3.csv"));
            });
        }

        /// <summary>
        /// Проверка создания рандомного сценария
        /// </summary>
        [Fact]
        public void TestRandomFactory()
        {
            var factory = new RandomScenarioFactory();
            Assert.Equal(factory.MakeScenario().Name, "Scenario #1");
        }
    }
}