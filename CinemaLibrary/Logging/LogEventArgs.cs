using System;
using System.IO;
using CinemaLibrary.Artifacts;

namespace CinemaLibrary.Logging
{
    /// <summary>
    /// Аргументы события OnLog
    /// </summary>
    public class LogEventArgs: EventArgs
    {
        /// <summary>
        /// Аргументы от события нижнего уровня
        /// </summary>
        public EventArgs Nested;

        /// <summary>
        /// Тип события
        /// </summary>
        public EventType Type;

        /// <summary>
        /// Открытый для записи дескриптор
        /// </summary>
        public TextWriter Output;

        /// <summary>
        /// Объект, вызвавший изначальное событие
        /// </summary>
        public Film Sender;
    }
}