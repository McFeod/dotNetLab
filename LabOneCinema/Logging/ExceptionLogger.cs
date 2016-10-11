using System;
using System.Threading;
using LabOneCinema.Exceptions;

namespace LabOneCinema.Logging
{
    public class ExceptionLogger: Logger
    {
        /// <summary>
        /// Объект для блокировки
        /// </summary>
        private readonly object _mutex;
        public ExceptionLogger(string path = null) : base(path)
        {
            _mutex = new object();
        }

        /// <summary>
        /// Обработка системных исключений
        /// </summary>
        /// <param name="exception"></param>
        public void HandleSystemException(Exception exception)
        {
            new Thread(() =>
            {
                lock (_mutex)
                {
                    using (var output = GetOutput())
                    {
                        output.WriteLine($"{DateTime.Now}: Системное исключение {exception.ToString()}");
                    }
                }
            }){IsBackground = true}.Start();
        }

        /// <summary>
        /// Обработка пользовательских исключений
        /// </summary>
        /// <param name="exception"></param>
        public void HandleCustomException(CustomException exception)
        {
            new Thread(() =>
            {
                lock (_mutex)
                {
                    using (var output = GetOutput())
                    {
                        output.WriteLine($"{DateTime.Now}: Пользовательское исключение {exception.ToString()}");
                    }
                }
            }){IsBackground = true}.Start();
        }
    }
}