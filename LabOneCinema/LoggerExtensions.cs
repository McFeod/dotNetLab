using System;
using CinemaLibrary.Logging;

namespace LabOneCinema
{
    /// <summary>
    /// Расширяем функциональность логгера
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Теперь логгер наконец-то может просто взять строку и записать её
        /// </summary>
        /// <param name="logger">Сам логгер</param>
        /// <param name="message">Строка, выводимая в лог</param>
        public static void Log(this Logger logger, string message)
        {
            logger.GetOutput().WriteLine($"{DateTime.Now}: {message}");
        }
    }
}