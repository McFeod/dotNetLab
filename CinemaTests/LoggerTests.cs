using System.IO;
using CinemaLibrary;
using CinemaLibrary.Exceptions;
using CinemaLibrary.Logging;
using Xunit;

namespace CinemaTests
{
    /// <summary>
    /// Тесты на логгер
    /// </summary>
    public class LoggerTests
    {
        /// <summary>
        /// файл, на котором будем тестировать
        /// </summary>
        private readonly string _filename = "log.txt";

        /// <summary>
        /// Проверка записи в файл
        /// </summary>
        [Fact]
        public void FilmLoggerTest()
        {
            var logger = new FilmLogger(_filename);
            logger.OnLog += MainHelper.PrintToLog;
            TestHelper.GetPlaylist(logger);
            Assert.True(File.Exists(_filename));
        }

        /// <summary>
        /// Проверка обработки различных исключений
        /// </summary>
        [Fact]
        public void ExceptionLoggerTest()
        {
            if (File.Exists(_filename))
            {
                File.Delete(_filename);
            }
            var logger = new ExceptionLogger(_filename);
            logger.HandleCustomException(new NotEnoughPeopleException());
            logger.HandleCustomException(new NegativeValueException());
            logger.HandleCustomException(new StringFormatException());
            logger.HandleSystemException(new FileNotFoundException());
            logger.HandleCustomException(new HiringOrderException());
            var text = File.ReadAllText(_filename);
            Assert.True(text.Contains("Не удалось разобрать строку"));
            Assert.True(text.Contains("Значение не может быть отрицательным"));
            Assert.True(text.Contains("Слишком мало людей для съёмки фильма"));
            Assert.True(text.Contains("Необходимо вызвать Work(film) перед наймом актёров"));
            Assert.True(text.Contains("Не удалось найти указанный файл"));
        }
    }
}